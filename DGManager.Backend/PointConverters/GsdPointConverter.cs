using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using IniParser;
using IniParser.Model;

//TODO Test GSD reading/writing
namespace DGManager.Backend
{
    [PointConverter(Description="GlobalSat Data File (*.gsd)", Extensions=".gsd")]
    public class GsdPointConverter : IPointReader, IPointWriter
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
			int trackCount = 0;
			List<PointOfInterestList> tracks = new List<PointOfInterestList>();

            var parser = new FileIniDataParser();
            var ini = parser.ReadFile(filename);
            trackCount += ini[Constants.GSD_TRACKS_CATEGORY].Count;

			args.Log(String.Format("{0} tracks found", trackCount));

			if (trackCount == 0)
			{
				return tracks;
			}

			int poiCount = 0;
			//int currentTrackNumber = 0;

			var trackDateStrings = ini[Constants.GSD_TRACKS_CATEGORY].Select(c => c.Value);
			
			foreach (string trackDate in trackDateStrings)
			{
				if (!String.IsNullOrEmpty(trackDate))
				{
					PointOfInterestList track = new PointOfInterestList();
                    track.SourceFile = Path.GetFileName(filename);
                    int j = 1;

					while (!String.IsNullOrEmpty(ini[trackDate][j.ToString()]))
					{
						PointOfInterest poi = GsdToPoint(ini[trackDate][j.ToString()]);
						track.Add(poi);

						j++;
						poiCount++;
					}

					tracks.Add(track);
					//DataOperationBackgroundWorker.ReportProgress(++currentTrackNumber);
				}
			}

			args.Log(poiCount + " points loaded");

            return tracks;
        }

        private static PointOfInterest GsdToPoint(string gsd)
        {
			//string s;
			string[] elements = gsd.Split(',');
            PointOfInterest point = new PointOfInterest { Latitude = GsToD(elements[0]), 
                Longitude = GsToD(elements[1]), TypePoi = 0 };

			if (elements.Length > 2)
			{
                point.When = DateTime.ParseExact(String.Format("{0} {1}", elements[3].PadLeft(6, '0'), elements[2].PadLeft(6, '0')),
                    "ddMMyy HHmmss", CultureInfo.CurrentCulture);
                //s = String.Format("{0}/{1}/20{2} {3}:{4}:{5}", d.Substring(0, 2), d.Substring(2, 2), d.Substring(4, 2), t.Substring(0, 2), t.Substring(2, 2), t.Substring(4, 2));
				
                //point.When = new DateTime(int.Parse(s.Substring(6, 4)), int.Parse(s.Substring(3, 2)), 
                //    int.Parse(s.Substring(0, 2)), int.Parse(s.Substring(11, 2)), 
                //    int.Parse(s.Substring(14, 2)), int.Parse(s.Substring(17, 2)));

                //gsd = gsd.Substring(gsd.IndexOf(',') + 1);
                //s = gsd.Substring(0, gsd.IndexOf(','));

				if (elements[4] != "-1")
				{
					point.Speed = new SpeedMeasurement(Convert.ToDouble(elements[4]) / 100);
					point.Name = point.Speed.ToString(MeasurementSystem.Metric, 0);
				}
				else
				{
					point.Speed = new SpeedMeasurement();
					point.Name = String.Empty;
				}

				point.TypePoi = 1;

				point.Altitude = new ElevationMeasurement();

				if (elements[5] != "-1")
				{
					point.Altitude.SetValue(Convert.ToInt32(elements[5]) / 10000);
					point.TypePoi = 2;
				}
			}
            return point;
        }

        private static double GsToD(string gs)
        {
            double d = Convert.ToDouble(gs, CultureInfo.InvariantCulture) / 1000000;
            d = Math.Truncate(d) + (d - Math.Truncate(d)) / 0.6;

            return d;
        }

        #endregion

        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            PointOfInterestList poiList;
            PointOfInterest poi;
            DateTime when;

            if (File.Exists(args.Filename))
            {
                File.Delete(args.Filename);
            }

            var parser = new FileIniDataParser();
            var ini = new IniData();

            args.Log("Saving data to GSD...");

            DateTime now = DateTime.Now;
            ini.Sections.Add(new SectionData(Constants.GSD_DATE_CATEGORY));
            ini[Constants.GSD_DATE_CATEGORY]["1"] = String.Format("{0:yyyy}-{0:MM}-{0:dd}-{1}:{0:mm}:{0:ss} {0:tt}", now, now.Hour);

            //IConfig tracksConfig = outputFile.AddConfig(Constants.GSD_TRACKS_CATEGORY);
            ini.Sections.Add(new SectionData(Constants.GSD_TRACKS_CATEGORY));

            for (int i = 0; i < args.Tracks.Count; i++)
            {
                poiList = args.Tracks[i];

                bool writtenHeader = false;
                string whenString = null;
                int pointNum = 1;

                //IConfig thisTrackConfig = null;
                string currentTrackName = null;

                for (int j = 0; j < poiList.Count; j++)
                {
                    if (!poiList.PointIsTrimmed(j))
                    {
                        poi = poiList[j];

                        if (!writtenHeader)
                        {
                            when = poi.When;
                            if (when != DateTime.MinValue)
                                when = when.AddHours(Settings.UtcShift);
                            whenString = String.Format("{0:000},{1:yyyy}-{1:MM}-{1:dd}:{1:HH}:{1:mm}:{1:ss}", i + 1, when);
                            ini[Constants.GSD_TRACKS_CATEGORY][(i + 1).ToString()] = whenString;
                            currentTrackName = whenString;
                            ini.Sections.Add(new SectionData(whenString));
                            writtenHeader = true;
                        }

                        ini[currentTrackName][(pointNum++).ToString()] = PointToGSD(poi);
                    }
                }

                args.ReportProgress(i + 1);
            }

            parser.WriteFile(args.Filename, ini);

            args.Log(String.Format("{0} saved", args.Filename));
        }

        private static string FormatLatLong(double d)
        {
            //TODO refactor this
            string e;
            string s = Math.Abs(Math.Truncate(d)).ToString();
            e = Math.Truncate(Math.Abs((d - Math.Truncate(d)) * 600000)).ToString();
            e = new string('0', 6 - e.Length) + e;
            s += e;
            return String.Format("{0}{1},", (d < 0 ? "-" : ""), s);
        }

        private static string PointToGSD(PointOfInterest point)
        {
            int speed, altitude;
            if (point.TypePoi >= 1 && point.Speed.HasValue)
                speed = (int)(point.Speed.GetValue() * 100);
            else
                speed = -1;
            if (point.TypePoi == 2)
                altitude = (int)(point.Altitude.GetValue(0.0) * 10000);
            else
                altitude = -1;

            //return String.Format("{0},{1:ddMMyy},{1:hhMMss},{2},{3},{4}", speed, point.When, FormatLatLong(point.Longitude), FormatLatLong(point.Latitude), altitude);
            return String.Format("{0},{1},{2:HHmmss},{2:ddMMyy},{3},{4}", FormatLatLong(point.Latitude), FormatLatLong(point.Longitude), point.When, speed, altitude);
        }

        #endregion
    }
}
