using System;
using System.Text;
using System.IO;
using System.Globalization;

namespace DGManager.Backend.PointConverters
{
    [PointConverter(Description="POI File (.poi)", Extensions=".poi")]
    public class PoiPointConverter : IPointWriter
    {
        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            using (StreamWriter sw = new StreamWriter(args.Filename))
            {
                try
                {
                    sw.WriteLine("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" ?>");
                    sw.WriteLine("<!DOCTYPE poix PUBLIC \"-//MOSTEC//POIX V2.0//EN\" \"poix.dtd\">");
                    sw.WriteLine("<poix version=\"2.0\">");
                    sw.WriteLine("<format>");
                    sw.WriteLine("<datum>wgs84</datum>");
                    sw.WriteLine("<unit>degree</unit>");
                    sw.WriteLine("</format>");
                    foreach (PointOfInterestList list in args.Tracks)
                        foreach (PointOfInterest poi in list)
                            sw.Write(PointToPOI(poi));
                    sw.Write("</poix>");
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        private static string PointToPOI(PointOfInterest point)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<poi>");
            sb.AppendLine("<point>");
            sb.AppendLine("<pos>");
            sb.AppendFormat("<lat>{0}</lat>{1}", point.Latitude.ToString(CultureInfo.InvariantCulture), Environment.NewLine);
            sb.AppendFormat("<lon>{0}</lon>{1}", point.Longitude.ToString(CultureInfo.InvariantCulture), Environment.NewLine);
            sb.AppendLine("</pos>");
            sb.AppendLine("</point>");
            sb.AppendFormat("<name><nb>{0}</nb></name>{1}", point.NameHtml, Environment.NewLine);
            sb.AppendLine("</poi>");

            return sb.ToString();
        }

        #endregion
    }
}
