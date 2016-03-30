using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DGManager.Backend.PointConverters
{
    [PointConverter(Description="MapExpert 2.0 (.ovl)", Extensions=".ovl")]
    public class OvlPointConverter : IPointReader, IPointWriter
    {
        private static Regex reWaypoint = new Regex("^W(?:aypoint)?,(?<format>D(?:M(?:S)?)?),(?<name>[^,]*),(?<lat>[-\\d.]*),(?<lon>[-\\d.]*),(?<date>[\\d/]*),(?<time>[\\d:]*),(?<desc>.*?)$", RegexOptions.IgnoreCase);
        private static Regex reRouteName = new Regex(@"^RouteName,\d*\s*,(?<name>.*?)$", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
        private static Regex reRoutePoint = new Regex("^RoutePoint,(?<format>D(?:M(?:S)?)?),(?<name>[^,]*),(?<lat>[-\\d.]*),(?<lon>[-\\d.]*),(?<date>[\\d/]*),(?<time>[\\d:]*),(?<desc>.*?)$", RegexOptions.IgnoreCase);
        private static Regex reTrackPoint = new Regex(@"^T(?:rackPoint)?,(?<format>D(?:M(?:S)?)?),(?<lat>[-\d.]*),(?<lon>[-\d.]*),(?<date>[\d/]*),(?<time>[\d:]*),(?<first>\d)$", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

        private static double InterpretLatLon(string format, string input)
        {
            double value = 0;
            string[] parts;
            if (double.TryParse(input, out value))
            {
                switch (format)
                {
                    case "D":
                        return value;
                    case "DM":
                        parts = input.Split('.');
                        return double.Parse(parts[0]) + (double.Parse(String.Format(".{0}", parts[1])) * 5 / 3);
                    case "DMS":
                        parts = input.Split('.');
                        return double.Parse(parts[0]) + (double.Parse(String.Format(".{0}", parts[1].Substring(0, 2))) * 5 / 3) + (double.Parse(parts[1].Substring(2)) / 3600);
                }
            }
            return value;
        }

        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            string[] lines = File.ReadAllLines(filename);
            int trackNum = 1;
            List<PointOfInterestList> tracks = new List<PointOfInterestList>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                Match m = null;
                if ((m = reWaypoint.Match(line)).Success)
                {
                    PointOfInterestList track = new PointOfInterestList { ListName = m.Groups["name"].Value, Type = ListType.Waypoint };
                    track.SourceFile = Path.GetFileName(filename);
                    PointOfInterest point = new PointOfInterest(InterpretLatLon(m.Groups["format"].Value, m.Groups["lat"].Value), 
                        InterpretLatLon(m.Groups["format"].Value, 
                        m.Groups["lon"].Value)) 
                        {
                            When = DateTime.Parse(String.Format("{0} {1}", m.Groups["date"].Value, m.Groups["time"].Value)), 
                            Name = m.Groups["name"].Value, 
                            Description = m.Groups["desc"].Value, TypePoi = 1 
                        };
                    track.Add(point);
                    tracks.Add(track);
                }
                else if ((m = reRouteName.Match(line)).Success)
                {
                    PointOfInterestList track = new PointOfInterestList { Type = ListType.Route, ListName = m.Groups["name"].Value };
                    while (i < lines.Length - 1 && (m = reRoutePoint.Match(lines[i + 1])) != null)
                    {
                        PointOfInterest point = new PointOfInterest(InterpretLatLon(m.Groups["format"].Value, m.Groups["lat"].Value), InterpretLatLon(m.Groups["format"].Value, m.Groups["lon"].Value)) 
                        {
                            When = DateTime.Parse(String.Format("{0} {1}", m.Groups["date"].Value, m.Groups["time"].Value)), 
                            Name = m.Groups["name"].Value, 
                            Description = m.Groups["desc"].Value, TypePoi = 1 
                        };
                        track.Add(point);
                        i++;
                    }
                    tracks.Add(track);
                }
                else if ((m = reTrackPoint.Match(line)).Success)
                {
                    PointOfInterestList track = null;
                    do
                    {
                        if (m.Groups["first"].Value == "1" || track == null)
                        {
                            track = new PointOfInterestList();
                            track.Type = ListType.Track;
                            track.ListName = String.Format("Track {0}", trackNum++);
                            tracks.Add(track);
                        }
                        PointOfInterest point = new PointOfInterest(InterpretLatLon(m.Groups["format"].Value, 
                            m.Groups["lat"].Value), 
                            InterpretLatLon(m.Groups["format"].Value, 
                            m.Groups["lon"].Value)) 
                            { 
                                When = DateTime.Parse(String.Format("{0} {1}", m.Groups["date"].Value, m.Groups["time"].Value)), 
                                TypePoi = 1 
                            };
                        track.Add(point);
                        i++;
                    } while (i < lines.Length - 1 && (m = reTrackPoint.Match(lines[i + 1])).Success);
                    i--;
                }
            }
            return tracks;
        }

        #endregion

        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            using (StreamWriter sw = new StreamWriter(args.Filename))
            {
                foreach (PointOfInterestList list in args.Tracks)
                {
                    if (list.Type == ListType.Route)
                        sw.WriteLine(String.Format("RouteName,{0},{1}", list.Count, list.ListName));
                    foreach (PointOfInterest point in list)
                        switch (list.Type)
                        {
                            case ListType.Track:
                                sw.WriteLine(String.Format("TrackPoint,D,{0},{1},{2},{3},{4}", point.Latitude, point.Longitude, point.When.ToString("MM/dd/yyyy"), point.When.ToString("hh:mm:ss"), (point == list[0] ? 1 : 0)));
                                break;
                            case ListType.Waypoint:
                                sw.WriteLine(String.Format("Waypoint,D,{0},{1},{2},{3},{4},{5}", point.Name, point.Latitude, point.Longitude, point.When.ToString("MM/dd/yyyy"), point.When.ToString("hh:mm:ss"), point.Description));
                                break;
                            case ListType.Route:
                                sw.WriteLine(String.Format("RoutePoint,D,{0},{1},{2},{3},{4},{5}", point.Name, point.Latitude, point.Longitude, point.When.ToString("MM/dd/yyyy"), point.When.ToString("hh:mm:ss"), point.Description));
                                break;
                        }
                }
                sw.Close();
            }
        }

        #endregion
    }
}
