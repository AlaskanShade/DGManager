using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DGManager.Backend.PointConverters.Dialog;
using System.Globalization;

namespace DGManager.Backend
{
    [PointConverter(Description="Comma-Separated Values (.csv)", Extensions=".csv")]
    public class CsvPointConverter : IPointReader, IPointWriter
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            using (CsvFormatDialog dialog = new CsvFormatDialog())
            {
                dialog.Filename = filename;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return dialog.Tracks;
            }
            return new List<PointOfInterestList>();
        }

        #endregion

        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            bool isPoi = true;
            foreach (PointOfInterestList track in args.Tracks)
            {
                if (!isPoi) break;
                if (track.Count > 1)
                    isPoi = false;
                foreach (PointOfInterest poi in track)
                    if (poi.Altitude != null && poi.Altitude.HasValue)
                    {
                        isPoi = false;
                        break;
                    }
            }

		    StringBuilder sb = new StringBuilder();
            using (StreamWriter sw = new StreamWriter(args.Filename, false))
            {
                if (!isPoi)
                {
                    args.Log("Saving data to CSV...");
                    sb.AppendLine("Record Number,Date,Time,Latitude,Longitude,Speed(km/h),Altitude(meters)");
                    int nonTrimmedPointsCount = 0;
                    foreach (PointOfInterestList poiList in args.Tracks)
                        for (int j = 0; j < poiList.Count; j++)
                            if (!poiList.PointIsTrimmed(j))
                            {
                                nonTrimmedPointsCount++;
                                sb.AppendLine(PointToCsv(poiList[j], nonTrimmedPointsCount));
                            }
                    //DataOperationBackgroundWorker.ReportProgress(i + 1);
                }
                else
                {
                    args.Log("Saving data to POI CSV...");
                    foreach (PointOfInterestList poiList in args.Tracks)
                        for (int j = 0; j < poiList.Count; j++)
                            sb.AppendLine(PointToCsv(poiList[j], j + 1));
                    //DataOperationBackgroundWorker.ReportProgress(i + 1);
                }
                sw.Write(sb.ToString());
                sw.Close();
            }

            args.Log(String.Format("{0} saved", args.Filename));
        }

        private static string PointToCsv(PointOfInterest point, int recordNumber)
        {
			double latDegrees;
			double latMinutes;

			Support.DecimalDegreesToDM(point.Latitude, out latDegrees, out latMinutes);

			double lonDegrees;
			double lonMinutes;

			Support.DecimalDegreesToDM(point.Longitude, out lonDegrees, out lonMinutes);

			return String.Format(CultureInfo.InvariantCulture, "{0},{1:yyyy}-{1:MM}-{1:dd},{1:HH}:{1:mm}:{1:ss},{2}{3:00.0000},{4}{5:00.0000},{6},{7}",
				recordNumber,
				point.When.AddHours(Settings.UtcShift),
				latDegrees,
				latMinutes,
				lonDegrees,
				lonMinutes,
				point.Speed.HasValue ? point.Speed.GetValue(MeasurementSystem.Metric).ToString("0.00", CultureInfo.InvariantCulture) : null,
				point.Altitude.HasValue ? point.Altitude.GetValue(MeasurementSystem.Metric).ToString("0.0", CultureInfo.InvariantCulture) : null
				);
        }

        #endregion
    }
}
