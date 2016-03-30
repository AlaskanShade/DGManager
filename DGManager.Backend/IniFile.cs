using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

//http://jachman.wordpress.com/2006/09/11/how-to-access-ini-files-in-c-net/
namespace DGManager.Backend
{
	/// <summary>
	/// Create a New INI file to store or load data
	/// </summary>
	public class IniFile
	{
		public string path;

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section,
			 string key, string val, string filePath);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,
					string key, string defaultValue, [In, Out] char[] retVal,
			 int size, string filePath);

		/// <summary>
		/// INIFile Constructor.
		/// </summary>
		/// <PARAM name="path"></PARAM>
		public IniFile(string path)
		{
			this.path = path;
		}
		/// <summary>
		/// Write Data to the INI File
		/// </summary>
		/// <PARAM name="category"></PARAM>
		/// category name
		/// <PARAM name="key"></PARAM>
		/// key Name
		/// <PARAM name="value"></PARAM>
		/// value Name
		private void WriteValue(string category, string key, string value)
		{
			WritePrivateProfileString(category, key, value, this.path);
		}

		/// <summary>
		/// Read Data Value From the Ini File
		/// </summary>
		/// <PARAM name="category"></PARAM>
		/// <PARAM name="key"></PARAM>
		/// <PARAM name="Path"></PARAM>
		/// <returns></returns>
		private string ReadValue(string category, string key, string defaultValue)
		{
			char[] resultChars = new char[255];
			int i = GetPrivateProfileString(category, key, defaultValue, resultChars,
													  255, this.path);
			string result = new string(resultChars);
			return result.Remove(result.IndexOf('\0'));
		}

		public string ReadString(string category, string key)
		{
			return ReadString(category, key, String.Empty);
		}
		
		public string ReadString(string category, string key, string defaultValue)
		{
			return ReadValue(category, key, defaultValue);
		}

		public int ReadInt32(string category, string key)
		{
			return ReadInt32(category, key, 0);
		}

		public int ReadInt32(string category, string key, int defaultValue)
		{
			return Convert.ToInt32(ReadValue(category, key, defaultValue.ToString()));
		}

		public double ReadDouble(string category, string key)
		{
			return ReadDouble(category, key, 0);
		}

		public double ReadDouble(string category, string key, double defaultValue)
		{
			return Convert.ToDouble(ReadValue(category, key, defaultValue.ToString(CultureInfo.InvariantCulture)));
		}

		public bool ReadBoolean(string category, string key)
		{
			return ReadBoolean(category, key, false);
		}

		public bool ReadBoolean(string category, string key, bool defaultValue)
		{
			return Convert.ToBoolean(ReadValue(category, key, defaultValue.ToString()));
		}
		
		public void WriteString(string category, string key, string value)
		{
			WriteValue(category, key, value);
		}

		public void WriteInt32(string category, string key, int value)
		{
			WriteValue(category, key, value.ToString(CultureInfo.InvariantCulture));
		}

		public void WriteDouble(string category, string key, double value)
		{
			WriteValue(category, key, value.ToString(CultureInfo.InvariantCulture));
		}

		public void WriteBoolean(string category, string key, bool value)
		{
			WriteValue(category, key, value.ToString(CultureInfo.InvariantCulture));
		}

		public IList<string> GetCategories()
		{
			char[] resultChars = new char[65536];
			GetPrivateProfileString(null, null, null, resultChars, 65536, path);
			string resultString = new string(resultChars);
			List<string> result = new List<string>(resultString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries));
			return result;
		}

		public IList<string> GetKeys(string category)
		{
			char[] resultChars = new char[32768];
			GetPrivateProfileString(category, null, null, resultChars, 32768, path);
			string resultString = new string(resultChars);
			List<string> result = new List<string>(resultString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries));
			return result;
		}
	}
}
