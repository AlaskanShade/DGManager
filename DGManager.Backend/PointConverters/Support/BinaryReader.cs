using System;
using System.Text;
using System.IO;

namespace DGManager.Backend.PointConverters
{
    public static class BinaryReader
    {
        public static short ReadShort(Stream s)
        {
            return (short)s.ReadByte();
        }

        public static Int32 ReadInt(Stream s)
        {
            return (int)((uint)s.ReadByte() | (uint)s.ReadByte() << 8 | (uint)s.ReadByte() << 16 | (uint)s.ReadByte() << 24);
        }

        public static string ReadString(Stream s)
        {
            StringBuilder sb = new StringBuilder();
            int curChar;
            while ((curChar = s.ReadByte()) > 0)
                sb.Append((char)curChar);
            return sb.ToString();
        }
    }
}
