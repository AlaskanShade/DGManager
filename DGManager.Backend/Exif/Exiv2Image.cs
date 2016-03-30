using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DGManager.Backend.Exif
{
	public class Exiv2Image : IDisposable
	{
		private int imageHandle;
		private Dictionary<string, List<string>> tags;
		
		private Dictionary<string, List<string>> Tags
		{
			get
			{
				if (tags == null)
				{
					tags = new Dictionary<string, List<string>>();
					RetrieveAllTags();
				}

				return tags;
			}
			set
			{
				tags = value;
			}
		}

		public Exiv2Image(string filePath)
		{
			imageHandle = Exiv2Wrapper.OpenFileImage(filePath);
		}

		public object GetMetadata(Exiv2MetaType metaType)
		{
			string metaString = GetMetadata(metaType.Tag);
			return metaString;
		}

		public string GetMetadata(string tag)
		{
			StringBuilder buffer = new StringBuilder(2048);

			Exiv2Wrapper.ReadMeta(imageHandle, tag, buffer, 2048);

			return buffer.ToString();
		}

		public void EnumMetadata(Exiv2EnumMetaDelegate enumerator)
		{
			Exiv2Wrapper.EnumMeta(imageHandle, enumerator);
		}

		public void SetMetadata(Exiv2MetaType metaType, string value, Exiv2DataType type)
		{
      //remove most comon danish/swedish values
      string cleanedValue =
        value.Replace("Å", "Aa").Replace("å", "aa").Replace("Ø", "Oe").Replace("ø", "oe").Replace("Æ", "Ae").Replace(
          "æ", "ae").Replace("Ö", "Oe").Replace("ö", "oe").Replace("Ä", "Ae").Replace("ä", "ae");
      SetMetadata(metaType.Tag, cleanedValue, type);
		}

		public void SetMetadata(string tag, string value, Exiv2DataType type)
		{
      if (type != Exiv2DataType.asciiString)
        Exiv2Wrapper.ModifyMeta(imageHandle, tag, value, type);
      else
      {
        //remove most comon danish/swedish values
        string cleanedValue =
          value.Replace("Å", "Aa").Replace("å", "aa").Replace("Ø", "Oe").Replace("ø", "oe").Replace("Æ", "Ae").Replace(
            "æ", "ae").Replace("Ö", "Oe").Replace("ö", "oe").Replace("Ä", "Ae").Replace("ä", "ae");
        Exiv2Wrapper.ModifyMeta(imageHandle, tag, cleanedValue, type);
      }
		}

		public void SetMetadata(string tag, byte[] value, Exiv2DataType type)
		{
			Exiv2Wrapper.ModifyMeta(imageHandle, tag, value, type);
		}

		public void AddMetadata(string tag, string value, Exiv2DataType type)
		{
      //remove most comon danish/swedish values
      string cleanedValue =
        value.Replace("Å", "Aa").Replace("å", "aa").Replace("Ø", "Oe").Replace("ø", "oe").Replace("Æ", "Ae").Replace(
          "æ", "ae").Replace("Ö", "Oe").Replace("ö", "oe").Replace("Ä", "Ae").Replace("ä", "ae");

      Exiv2Wrapper.AddMeta(imageHandle, tag, cleanedValue, type);
		}

		#region SetMetadata methods for various data types
		public void SetMetadata(Exiv2MetaType metaType, string value)
		{
      //remove most comon danish/swedish values
      string cleanedValue =
        value.Replace("Å", "Aa").Replace("å", "aa").Replace("Ø", "Oe").Replace("ø", "oe").Replace("Æ", "Ae").Replace(
          "æ", "ae").Replace("Ö", "Oe").Replace("ö", "oe").Replace("Ä", "Ae").Replace("ä", "ae");
      SetMetadata(metaType.Tag, cleanedValue, metaType.DataType);
		}

		public void SetMetadata(Exiv2MetaType metaType, byte[] value)
		{
			SetMetadata(metaType.Tag, value, metaType.DataType);
		}

		public void AddMetadata(Exiv2MetaType metaType, string value)
		{
      //remove most comon danish/swedish values
      string cleanedValue =
        value.Replace("Å", "Aa").Replace("å", "aa").Replace("Ø", "Oe").Replace("ø", "oe").Replace("Æ", "Ae").Replace(
          "æ", "ae").Replace("Ö", "Oe").Replace("ö", "oe").Replace("Ä", "Ae").Replace("ä", "ae");
      AddMetadata(metaType.Tag, cleanedValue, metaType.DataType);
		}

		public void SetMetadata(Exiv2MetaType metaType, double value)
		{
			value = Math.Abs(value);

			if (metaType.MetaType == Exiv2MetaTypeEnum.GPSLatitude || metaType.MetaType == Exiv2MetaTypeEnum.GPSLongitude ||
				metaType.MetaType == Exiv2MetaTypeEnum.GPSDestLatitude || metaType.MetaType == Exiv2MetaTypeEnum.GPSDestLongitude)
			{
				double degrees;
				double minutes;
				double seconds;

				Support.DecimalDegreesToDMS(value, out degrees, out minutes, out seconds);

				SetMetadata(metaType, new int[] { (int)degrees, (int)minutes, (int)Math.Round(seconds * 100) }, new int[] { 1, 1, 100 });
			}
			else
			{
				int denominator = 100000;
				int numerator = (int)Math.Round(value * denominator);

				SetMetadata(metaType, new int[] { numerator }, new int[] { denominator });
			}
		}

		public void SetMetadata(Exiv2MetaType metaType, int[] values)
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < values.Length; i++)
			{
				if (i > 0)
				{
					sb.Append(" ");
				}

				sb.Append(values[i].ToString());
			}

			SetMetadata(metaType, sb.ToString());
		}

		public void SetMetadata(Exiv2MetaType metaType, int[] numerators, int[] denominators)
		{
			if (numerators.Length != denominators.Length)
			{
				throw new ArgumentException("Must provide an equal number of numerators and denominators");
			}

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < numerators.Length; i++ )
			{
				if (i > 0)
				{
					sb.Append(" ");
				}

				sb.AppendFormat("{0}/{1}", numerators[i], denominators[i]);
			}

			SetMetadata(metaType, sb.ToString());
		}
		#endregion

		public void SaveMetadata()
		{
			if (Exiv2Wrapper.SaveImage(imageHandle) != 0)
			{
				throw new ApplicationException("Image could not be saved.");
			}
		}

		public void Dispose()
		{
			Exiv2Wrapper.FreeImage(imageHandle);
		}

		private void RetrieveAllTags()
		{
            EnumMetadata(AddTagToCollection);
		}

		private bool AddTagToCollection(string key, string value, IntPtr user)
		{
			if (!Tags.ContainsKey(key))
			{
				Tags[key] = new List<string>();
			}

			Tags[key].Add(value);

			return true;
		}

		public object GetTag(Exiv2MetaType metaType)
		{
			if (!Tags.ContainsKey(metaType.Tag) || Tags[metaType.Tag] == null || Tags[metaType.Tag].Count == 0)
			{
				return null;
			}

			object returnValue = null;

			switch (metaType.DataType)
			{
				case Exiv2DataType.asciiString:
				case Exiv2DataType.otherString:
					if (metaType == Exiv2MetaType.DateTimeOriginal)
					{
						string datePart = Tags[metaType.Tag][0].Split(new char[] {' '})[0].Replace(":", "-");
						string timePart = Tags[metaType.Tag][0].Split(new char[] {' '})[1];

                        returnValue = DateTime.Parse(String.Format("{0} {1}", datePart, timePart), CultureInfo.InvariantCulture);
					}
					else if (metaType == Exiv2MetaType.IptcKeywords)
					{
						returnValue = Tags[metaType.Tag];
					}
					else
					{
						returnValue = Tags[metaType.Tag].Count > 1 ? Tags[metaType.Tag] : (object) Tags[metaType.Tag][0];
					}
					break;
				case Exiv2DataType.comment:
					string comment = Tags[metaType.Tag][0];
					comment = comment.Replace("charset=\"Unicode\" ", "").Replace("charset=Unicode ", "");
					comment = Encoding.UTF8.GetString(Encoding.Default.GetBytes(comment));
					returnValue = comment;
					break;
				case Exiv2DataType.unsignedRational:
					string[] rationalStrings = Tags[metaType.Tag][0].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
					if (rationalStrings.Length == 3)
					{
						double degrees = Convert.ToDouble(rationalStrings[0].Split(new char[] {'/'})[0]) /
						                 Convert.ToDouble(rationalStrings[0].Split(new char[] {'/'})[1]);

						double minutes = Convert.ToDouble(rationalStrings[1].Split(new char[] {'/'})[0]) /
						                 Convert.ToDouble(rationalStrings[1].Split(new char[] {'/'})[1]);

						double seconds = Convert.ToDouble(rationalStrings[2].Split(new char[] {'/'})[0]) /
						                 Convert.ToDouble(rationalStrings[2].Split(new char[] {'/'})[1]);

						returnValue = (degrees + ((minutes + (seconds/60))/60));
					}
					else if (rationalStrings.Length == 1)
					{
						returnValue = Convert.ToDouble(rationalStrings[0].Split(new char[] { '/' })[0]) /
										  Convert.ToDouble(rationalStrings[0].Split(new char[] { '/' })[1]);
					}
					else
					{
						returnValue = Tags[metaType.Tag][0];
					}
					break;
				case Exiv2DataType.unsignedByte:
					returnValue = Convert.ToByte(Tags[metaType.Tag][0]);
					break;
			}

			return returnValue;
		}
	}
}
