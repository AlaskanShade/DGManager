using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace DGManager.Backend
{
    [PointConverter(Description="NMEA File(s)", Extensions=".nmea,.log", DefaultExtension = ".log")]
    public class NmeaPointConverter : IPointReader, IPointWriter
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            int poiCount = 0;

            List<PointOfInterestList> tracks = new List<PointOfInterestList>();

            PointOfInterestList pointsOfInterest = new PointOfInterestList();
            pointsOfInterest.SourceFile = Path.GetFileName(filename);
            StreamReader reader = File.OpenText(filename);
            string sentence;
            PointOfInterest prevPoi = null;
            List<string> sentences = new List<string>();

            while ((sentence = reader.ReadLine()) != null)
            {
                sentences.Add(sentence);
            }

            for (int j = 0; j < sentences.Count; j++)
            {
                if (!String.IsNullOrEmpty(sentences[j]))
                {
                    PointOfInterest currentPoi = NmeaParser.Parse(sentences[j]);

                    if (currentPoi != null)
                    {
                        //if this point is the same time and location as the previous point
                        //(but presumably a different type of sentence)
                        //combine the information from both of them
                        if (prevPoi != null && currentPoi.When.TimeOfDay == prevPoi.When.TimeOfDay
                            && currentPoi.Latitude == prevPoi.Latitude
                            && currentPoi.Longitude == prevPoi.Longitude)
                        {
                            PointOfInterest poiToAdd = new PointOfInterest { Latitude = currentPoi.Latitude, Longitude = currentPoi.Longitude };

                            if (prevPoi.When < currentPoi.When)
                            {
                                poiToAdd.When = prevPoi.When;
                            }
                            else
                            {
                                poiToAdd.When = currentPoi.When;
                            }

                            if (prevPoi.Speed.HasValue)
                            {
                                poiToAdd.Speed = prevPoi.Speed;
                                poiToAdd.TypePoi = 1;
                            }
                            else if (currentPoi.Speed.HasValue)
                            {
                                poiToAdd.Speed = currentPoi.Speed;
                                poiToAdd.TypePoi = 1;
                            }

                            if (prevPoi.Altitude.HasValue)
                            {
                                poiToAdd.Altitude = prevPoi.Altitude;
                                poiToAdd.TypePoi = 2;
                            }
                            else if (currentPoi.Altitude.HasValue)
                            {
                                poiToAdd.Altitude = currentPoi.Altitude;
                                poiToAdd.TypePoi = 2;
                            }

                            pointsOfInterest.Add(poiToAdd);
                            poiCount++;
                            prevPoi = null;
                        }
                        else
                        {
                            if (prevPoi != null)
                            {
                                pointsOfInterest.Add(prevPoi);
                                poiCount++;
                            }

                            //last point, doesn't match the previous point so just add it
                            if (j == sentences.Count - 1)
                            {
                                pointsOfInterest.Add(currentPoi);
                                poiCount++;
                            }

                            prevPoi = currentPoi;
                        }
                    }
                }
            }

            pointsOfInterest.Sort(PointOfInterest.ComparePointsByDate);

            tracks.Add(pointsOfInterest);

            args.Log(poiCount + " points loaded");
            return tracks;
        }

        #endregion

        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
			StringBuilder sb = new StringBuilder();
            using (StreamWriter sw = new StreamWriter(args.Filename, false))
            {
                args.Log("Saving data to NMEA...");
                for (int i = 0; i < args.Tracks.Count; i++)
                {
                    PointOfInterestList track = args.Tracks[i];
                    for (int j = 0; j < track.Count; j++)
                        if (!track.PointIsTrimmed(j))
                            sb.AppendLine(PointToNmea(track[j], (j < track.Count - 1) ? track[j + 1] : null));
                    args.ReportProgress(i + 1);
                }
                sw.Write(sb.ToString());
                sw.Close();
            }

            args.Log(String.Format("{0} saved", args.Filename));
        }

        private static string PointToNmea(PointOfInterest point, PointOfInterest nextPoint)
        {
            double latDegrees;
            double latMinutes;

            Support.DecimalDegreesToDM(point.Latitude, out latDegrees, out latMinutes);

            string latDirection = point.Latitude > 0 ? "N" : "S";

            double lonDegrees;
            double lonMinutes;

            Support.DecimalDegreesToDM(point.Longitude, out lonDegrees, out lonMinutes);

            string lonDirection = point.Longitude > 0 ? "E" : "W";

            double knots = point.Speed.GetValue(MeasurementSystem.Nautical, 0);

            double trueCourseDegrees = nextPoint != null ? point.BearingToPoint(nextPoint) : 0;

            string rmcSentence = String.Format(
                CultureInfo.InvariantCulture,
                "$GPRMC,{0:HH}{0:mm}{0:ss},A,{1:00}{2:00.000#####},{3},{4:000}{5:00.000#####},{6},{7:000.##},{8:000.##},{0:dd}{0:MM}{0:yy},,,*",
                point.When,
                Math.Abs(latDegrees),
                latMinutes,
                latDirection,
                Math.Abs(lonDegrees),
                lonMinutes,
                lonDirection,
                knots,
                trueCourseDegrees);

            rmcSentence += Support.GetNmeaChecksum(rmcSentence);

            if (point.Altitude.HasValue)
            {
                string ggaSentence = String.Format(
                    "$GPGGA,{0:HH}{0:mm}{0:ss},{1:00}{2:00.000#####},{3},{4:000}{5:00.000#####},{6},1,00,00.0,{7:00000.##},M,000.0,M,,*",
                    point.When,
                    Math.Abs(latDegrees),
                    latMinutes,
                    latDirection,
                    Math.Abs(lonDegrees),
                    lonMinutes,
                    lonDirection,
                    point.Altitude.GetValue(MeasurementSystem.Metric)
                    );

                ggaSentence += Support.GetNmeaChecksum(ggaSentence);

                return String.Concat(ggaSentence, Environment.NewLine, rmcSentence);
            }
            else
            {
                return rmcSentence;
            }
        }

        #endregion
    }
}
