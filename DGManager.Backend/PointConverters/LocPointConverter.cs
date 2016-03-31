using System;
using System.Text;
using System.IO;
using System.Globalization;

namespace DGManager.Backend.PointConverters
{
    [PointConverter(Description="EasyGPS Waypoint File (.loc)", Extensions=".loc")]
    public class LocPointConverter : IPointWriter
    {
        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            using (StreamWriter sw = new StreamWriter(args.Filename))
            {
                try
                {
                    sw.WriteLine("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" ?><loc version=\"1.0\" src=\"EasyGPS\">");
                    foreach (PointOfInterestList list in args.Tracks)
                        foreach (PointOfInterest poi in list)
                            sw.Write(PointToLoc(poi));
                    sw.Write("</loc>");
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        private static string PointToLoc(PointOfInterest point)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<waypoint>");
            sb.AppendFormat("<name id=\"{0}\"><![CDATA[{0}]]></name>", point.Name);
            sb.AppendFormat("<coord lat=\"{0}\" lon=\"{1}\"/>{2}",
                            point.Latitude.ToString(CultureInfo.InvariantCulture),
                            point.Longitude.ToString(CultureInfo.InvariantCulture), 
                            Environment.NewLine);
            sb.AppendLine("</waypoint>");

            return sb.ToString();
        }

        #endregion
    }
}
