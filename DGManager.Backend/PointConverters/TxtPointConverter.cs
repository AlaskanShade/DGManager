using System;
using System.Text;
using System.IO;
using System.Globalization;

namespace DGManager.Backend
{
    [PointConverter(Description="Text File", Extensions=".txt")]
    public class TxtPointConverter : IPointWriter
    {
        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamWriter sw = new StreamWriter(args.Filename, false))
            {
                args.Log("Saving data to TXT...");
                string speedUnit = null;
                string altitudeUnit = null;
                switch (Settings.SpeedMeasurementSystem)
                {
                    case MeasurementSystem.Metric:
                        speedUnit = "km/h";
                        break;
                    case MeasurementSystem.Imperial:
                        speedUnit = "mi/h";
                        break;
                    case MeasurementSystem.Nautical:
                        speedUnit = "kt";
                        break;
                }
                switch (Settings.ElevationMeasurementSystem)
                {
                    case MeasurementSystem.Metric:
                        altitudeUnit = "m";
                        break;
                    case MeasurementSystem.Imperial:
                        altitudeUnit = "ft";
                        break;
                    case MeasurementSystem.Nautical:
                        altitudeUnit = "nm";
                        break;
                }
                sb.AppendLine(String.Format("Date and time\tLatitude\tLongitude\tSpeed ({0})\tAltitude ({1})", speedUnit, altitudeUnit));
                for (int i = 0; i < args.Tracks.Count; i++)
                {
                    PointOfInterestList track = args.Tracks[i];
                    for (int j = 0; j < track.Count; j++)
                        if (!track.PointIsTrimmed(j))
                            sb.AppendLine(PointToTxt(track[j]));
                    args.ReportProgress(i + 1);
                }
                sw.Write(sb.ToString());
                sw.Close();
            }

            args.Log(String.Format("{0} saved", args.Filename));
        }

        private static string PointToTxt(PointOfInterest point)
        {
            return String.Format(CultureInfo.InvariantCulture, "{0:yyyy}/{0:MM}/{0:dd} {0:HH}:{0:mm}:{0:ss}\t{1:0.000000}\t{2:0.000000}\t{3}\t{4}",
                point.When.AddHours(Settings.UtcShift),
                point.Latitude,
                point.Longitude,
                point.Speed.HasValue ? point.Speed.GetValue(Settings.SpeedMeasurementSystem).ToString("0.00", CultureInfo.InvariantCulture) : null,
                point.Altitude.HasValue ? point.Altitude.GetValue(Settings.ElevationMeasurementSystem).ToString("0.00", CultureInfo.InvariantCulture) : null);
        }

        #endregion
    }
}
