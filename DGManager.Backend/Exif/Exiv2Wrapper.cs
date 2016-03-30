using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Runtime.InteropServices;

namespace DGManager.Backend.Exif
{
	public enum Exiv2DataType 
	{ 
		invalidTypeId, 
		unsignedByte, 
		asciiString, 
		unsignedShort, 
      unsignedLong, 
		unsignedRational, 
		invalid6, 
		undefined,
		signedShort, 
		signedLong, 
		signedRational, 
      otherString, 
		isoDate, 
		isoTime,
		comment,
      lastTypeId
	}

	//typedef bool (CALLBACK* METAENUMPROC)(const char *key, const char *value, void *user);
	public delegate bool Exiv2EnumMetaDelegate(string key, string value, IntPtr user);
	
	/// <summary>
	/// Wrapper for Exiv2, not Exiv-to-Wrapper
	/// </summary>
	public class Exiv2Wrapper
	{
		[DllImport("exivsimple.dll")]
		public static extern int OpenFileImage(string file);
		
		[DllImport("exivsimple.dll")]
		public static extern int OpenMemImage(byte[] data, uint size);

		[DllImport("exivsimple.dll")]
		public static extern void FreeImage(int imageHandle);

		[DllImport("exivsimple.dll")]
		public static extern int SaveImage(int imageHandle);

		[DllImport("exivsimple.dll")]
		public static extern int ImageSize(int imageHandle);

		[DllImport("exivsimple.dll")]
		public static extern int ImageData(int imageHandle, ref byte[] buffer, uint size);

		[DllImport("exivsimple.dll")]
		public static extern int ReadMeta(int imageHandle, string key, StringBuilder buffer, int bufferSize);
		
		//EXIVSIMPLE_API int EnumMeta(HIMAGE img, METAENUMPROC proc, void *user);
		[DllImport("exivsimple.dll", CharSet = CharSet.Unicode)]
		private static extern int EnumMeta(int imageHandle, IntPtr proc, IntPtr user);

		public static int EnumMeta(int imageHandle, Exiv2EnumMetaDelegate proc)
		{
			return EnumMeta(imageHandle, Marshal.GetFunctionPointerForDelegate(proc), new IntPtr(1));
		}

		[DllImport("exivsimple.dll")]
		public static extern int AddMeta(int imageHandle, string key, string value, Exiv2DataType type);

		[DllImport("exivsimple.dll")]
		public static extern int ModifyMeta(int imageHandle, string key, string value, Exiv2DataType type);

		[DllImport("exivsimple.dll")]
		public static extern int ModifyMeta(int imageHandle, string key, byte[] value, Exiv2DataType type);

		[DllImport("exivsimple.dll")]
		public static extern int RemoveMeta(int imageHandle, string key);

		static Exiv2Wrapper()
		{
			ResourceExtractor.ExtractResourceToFile("DGManager.Backend.Resources.exivsimple.dll", Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "exivsimple.dll"));
		}
	}
}
