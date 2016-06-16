using System;

namespace DGManager.Backend
{
	public static class ResourceExtractor
	{
        public static string ExtractResourceToString(string resourceName)
        {
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                var tr = new System.IO.StreamReader(stream);
                return tr.ReadToEnd();
            }
        }
		public static void ExtractResourceToFile(string resourceName, string filename, bool overwrite = false)
		{
            if (System.IO.File.Exists(filename) && overwrite)
                System.IO.File.Delete(filename);
            if (!System.IO.File.Exists(filename))
			{
				using (System.IO.Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
				{
					using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Create))
					{
						byte[] b = new byte[s.Length];
						s.Read(b, 0, b.Length);
						fs.Write(b, 0, b.Length);
					}
				}
			}
		}
	}
}
