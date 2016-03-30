using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using DGManager.Backend.Exif;
using Encoder=System.Drawing.Imaging.Encoder;

namespace DGManager.Backend
{
	public class Location
	{

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double? Altitude { get; set; }
	}

	public class JpegHelper
	{
		public static Jpeg GetJpegFromFile(string jpgFileName)
		{
			using (Exiv2Image image = new Exiv2Image(jpgFileName))
			{
                Jpeg jpeg = new Jpeg { FilePath = jpgFileName };
				Location location = null;

				object latitude, longitude, altitude, altitudeRef;
				string latitudeRef, longitudeRef;

				latitude = image.GetTag(Exiv2MetaType.GPSLatitude);
				latitudeRef = (string) image.GetTag(Exiv2MetaType.GPSLatitudeRef);
				longitude = image.GetTag(Exiv2MetaType.GPSLongitude);
				longitudeRef = (string)image.GetTag(Exiv2MetaType.GPSLongitudeRef);
				altitude = image.GetTag(Exiv2MetaType.GPSAltitude);
				altitudeRef = image.GetTag(Exiv2MetaType.GPSAltitudeRef);

				if (latitude != null && latitudeRef != null && longitude != null && longitudeRef != null)
				{
					location = new Location();

					location.Latitude = (double) latitude;
					location.Longitude = (double) longitude;


					if (latitudeRef == "S")
					{
						location.Latitude *= -1;
					}

					if (longitudeRef == "W")
					{
						location.Longitude *= -1;
					}

					if (altitude != null && altitudeRef != null)
					{
						location.Altitude = (double) altitude;

						if ((GpsAltitudeRef) ((byte) altitudeRef) == GpsAltitudeRef.BelowSeaLevel)
						{
							location.Altitude *= -1;
						}
					}
				}

				jpeg.Location = location;

				object dateTimeOriginal = image.GetTag(Exiv2MetaType.DateTimeOriginal);

				if (dateTimeOriginal != null)
				{
					jpeg.OriginalDateTime = (DateTime) dateTimeOriginal;
				}
				else
				{
					jpeg.OriginalDateTime = File.GetCreationTime(jpgFileName);
				}

				//set the millisecond component to zero
				jpeg.OriginalDateTime =
					new DateTime(jpeg.OriginalDateTime.Year, jpeg.OriginalDateTime.Month, jpeg.OriginalDateTime.Day,
					             jpeg.OriginalDateTime.Hour, jpeg.OriginalDateTime.Minute, jpeg.OriginalDateTime.Second);

				jpeg.OffsetDateTime = jpeg.OriginalDateTime;

				return jpeg;
			}
		}

		public static void GetJpegStringTags(Jpeg jpeg)
		{
			using (Exiv2Image image = new Exiv2Image(jpeg.FilePath))
			{
				jpeg.StringTags.Clear();

				if (!String.IsNullOrEmpty((string) image.GetTag(Exiv2MetaType.ImageDescription)))
				{
					jpeg.StringTags[Exiv2MetaType.ImageDescription] = new List<string>();
					jpeg.StringTags[Exiv2MetaType.ImageDescription].Add((string) image.GetTag(Exiv2MetaType.ImageDescription));
				}

				if (!String.IsNullOrEmpty((string) image.GetTag(Exiv2MetaType.XPComment)))
				{
					jpeg.StringTags[Exiv2MetaType.XPComment] = new List<string>();
					jpeg.StringTags[Exiv2MetaType.XPComment].Add((string) image.GetTag(Exiv2MetaType.XPComment));
				}

				if (!String.IsNullOrEmpty((string) image.GetTag(Exiv2MetaType.XPKeywords)))
				{
					jpeg.StringTags[Exiv2MetaType.XPKeywords] = new List<string>();
					jpeg.StringTags[Exiv2MetaType.XPKeywords].Add((string) image.GetTag(Exiv2MetaType.XPKeywords));
				}

				if (!String.IsNullOrEmpty((string) image.GetTag(Exiv2MetaType.XPSubject)))
				{
					jpeg.StringTags[Exiv2MetaType.XPSubject] = new List<string>();
					jpeg.StringTags[Exiv2MetaType.XPSubject].Add((string) image.GetTag(Exiv2MetaType.XPSubject));
				}

				if (!String.IsNullOrEmpty((string) image.GetTag(Exiv2MetaType.UserComment)))
				{
					jpeg.StringTags[Exiv2MetaType.UserComment] = new List<string>();
					jpeg.StringTags[Exiv2MetaType.UserComment].Add((string) image.GetTag(Exiv2MetaType.UserComment));
				}

				if (!String.IsNullOrEmpty((string) image.GetTag(Exiv2MetaType.IptcCaption)))
				{
					jpeg.StringTags[Exiv2MetaType.IptcCaption] = new List<string>();
					jpeg.StringTags[Exiv2MetaType.IptcCaption].Add((string) image.GetTag(Exiv2MetaType.IptcCaption));
				}

				if (image.GetTag(Exiv2MetaType.IptcKeywords) != null)
				{
					jpeg.StringTags[Exiv2MetaType.IptcKeywords] = new List<string>();
					jpeg.StringTags[Exiv2MetaType.IptcKeywords].AddRange((List<string>) image.GetTag(Exiv2MetaType.IptcKeywords));
				}
			}
		}

		public static void SetGpsInfo(Jpeg jpeg, bool setImageModDateToGeocodeDate)
		{
			SetGpsInfo(jpeg.FilePath, jpeg.Location, jpeg.Speed, jpeg.OffsetDateTime, jpeg.GpsDateTime, jpeg.StringTags, setImageModDateToGeocodeDate);
		}

		public static void SetGpsInfo(string jpgFileName, Location location, double? speedInKmph, DateTime offsetDateTime, DateTime gpsDateTime, Dictionary<Exiv2MetaType, List<string>> stringTags, bool setImageModDateToGeocodeDate)
		{
			SetGpsInfo(jpgFileName, location.Latitude, location.Longitude, location.Altitude, speedInKmph, offsetDateTime, gpsDateTime, stringTags, setImageModDateToGeocodeDate);
		}

		public static void SetGpsInfo(string jpgFileName, double lat, double lon, double? alt, double? speedInKmph, DateTime offsetDateTime, DateTime gpsDateTime, Dictionary<Exiv2MetaType, List<string>> stringTags, bool setImageModDateToGeocodeDate)
		{
			DateTime modifiedDate = setImageModDateToGeocodeDate ? offsetDateTime : File.GetLastWriteTime(jpgFileName);

			using (Exiv2Image exivImage = new Exiv2Image(jpgFileName))
			{
				exivImage.SetMetadata(Exiv2MetaType.GPSVersionID, new int[] { 2, 2, 0, 0 });
				exivImage.SetMetadata(Exiv2MetaType.GPSMapDatum, "WGS-84");
				exivImage.SetMetadata(Exiv2MetaType.GPSStatus, "A");
				exivImage.SetMetadata(Exiv2MetaType.GPSDateStamp, String.Format("{0:yyyy}:{0:MM}:{0:dd}", gpsDateTime));
				exivImage.SetMetadata(Exiv2MetaType.GPSTimeStamp, new int[] { gpsDateTime.Hour, gpsDateTime.Minute, gpsDateTime.Second }, new int[] { 1, 1, 1 });
				exivImage.SetMetadata(Exiv2MetaType.GPSLatitude, lat);
				exivImage.SetMetadata(Exiv2MetaType.GPSLongitude, lon);
				exivImage.SetMetadata(Exiv2MetaType.GPSLatitudeRef, lat > 0 ? "N" : "S");
				exivImage.SetMetadata(Exiv2MetaType.GPSLongitudeRef, lon > 0 ? "E" : "W");

				if (speedInKmph.HasValue)
				{
					exivImage.SetMetadata(Exiv2MetaType.GPSSpeed, new int[] { (int)Math.Round(speedInKmph.Value * 100) }, new int[] { 100 });
					exivImage.SetMetadata(Exiv2MetaType.GPSSpeedRef, "K");
				}

				if (alt.HasValue)
				{
					exivImage.SetMetadata(Exiv2MetaType.GPSAltitude, alt.Value);
					exivImage.SetMetadata(Exiv2MetaType.GPSAltitudeRef, (byte)(alt.Value > 0 ? GpsAltitudeRef.AboveSeaLevel : GpsAltitudeRef.BelowSeaLevel));
				}

				foreach (Exiv2MetaType tag in stringTags.Keys)
				{
					if (stringTags[tag].Count == 1)
					{
						if (tag.DataType == Exiv2DataType.comment)
						{
							byte[] preamble = ASCIIEncoding.ASCII.GetBytes("charset=Unicode ");
							byte[] comment = UnicodeEncoding.UTF8.GetBytes(stringTags[tag][0]);

							byte[] fullCommentBytes = new byte[preamble.Length + comment.Length];

							Array.Copy(preamble, fullCommentBytes, preamble.Length);
							Array.Copy(comment, 0, fullCommentBytes, preamble.Length, comment.Length);
							
							exivImage.SetMetadata(tag, fullCommentBytes);
						}
						else
						{
							exivImage.SetMetadata(tag, stringTags[tag][0]);
						}
					}
					else if (stringTags[tag].Count > 1)
					{
                        stringTags[tag].ForEach(tagValue => exivImage.AddMetadata(tag, tagValue));
					}
				}
				
				exivImage.SaveMetadata();
			}

			File.SetLastWriteTime(jpgFileName, modifiedDate);
		}

        //private static ImageCodecInfo GetEncoderInfo(String mimeType)
        //{
        //    int j;
        //    ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
        //    for (j = 0; j < encoders.Length; ++j)
        //    {
        //        if (encoders[j].MimeType == mimeType)
        //            return encoders[j];
        //    } return null;
        //}
	}
}
