using System;
using System.IO;
using System.Globalization;

namespace DGManager.Backend.PointConverters
{
    [PointConverter(Description="OziExplorer Waypoint File (.wpt)", Extensions=".wpt")]
    public class WptPointConverter : IPointWriter
    {
        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            using (StreamWriter sw = new StreamWriter(args.Filename))
            {
                try
                {
                    sw.WriteLine("H  SOFTWARE NAME & VERSION");
                    sw.WriteLine(String.Format("I  PCX5 2.09{0}", Environment.NewLine));
                    sw.WriteLine("H  R DATUM                IDX DA            DF            DX            DY            DZ");
                    sw.WriteLine(String.Format("M  G WGS 84               121 +0.000000e+00 +0.000000e+00 +0.000000e+00 +0.000000e+00 +0.000000e+00{0}", Environment.NewLine));
                    sw.WriteLine("H  COORDINATE SYSTEM");
                    sw.WriteLine(String.Format("U  LAT LON DM{0}", Environment.NewLine));
                    sw.WriteLine("H  IDNT   LATITUDE    LONGITUDE    DATE      TIME     ALT   DESCRIPTION                              PROXIMITY     SYMBOL ;waypts");
                    foreach (PointOfInterestList track in args.Tracks)
                        for (int i = 0; i < track.Count; i++)
                        {
                            track[i].Order = i + 1;
                            sw.Write(PointToWpt(track[i]));
                        }
                    sw.Write(Environment.NewLine);
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        private static double FormatLatLong(double latlong)
        {
            //TODO refactor
            double d;
            double m;
            d = latlong;
            d = (int)d;
            m = latlong - d;
            d = d * 1000;
            m = m * 60;
            return d + m;
        }

        private static string PointToWpt(PointOfInterest point)
        {
            //TODO test Wpt writing
            //string s;
            //string t;
            //double d;
            //double m;
            //double r;

            //s = "";
            return String.Format("W  POI{0:000} N{1:0.00000} E{2:0.00000} {4:dd-MMM-yy} -9999 {5} 0.000000e+00  0{6}", point.Order, FormatLatLong(point.Latitude), FormatLatLong(point.Longitude), DateTime.Now, point.NameWPT, Environment.NewLine);

            //s += String.Format("{0}", t.PadLeft(10, '0').Substring(0, 10));
            //t = String.Format(CultureInfo.InvariantCulture, "");

            //string month = DateTime.Now.ToString("MMM");
            //month = month.ToUpperInvariant();

            //s += String.Format("{0}", t.PadLeft(11, '0').Substring(0, 11));

            //return s;
        }

        #endregion
    }
}
