using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Globalization;

namespace DGManager.Backend
{
    [PointConverter(Description="GPX File(s) (.gpx)", Extensions=".gpx")]
    public class GpxPointConverter : IPointReader, IPointWriter
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            int poiCount = 0;

            List<KeyValuePair<string, XmlNodeList>> gpxTracks = GetGPXTracksFromGPXFile(filename);

            int trackCount = gpxTracks.Count;

            args.Log(String.Format("{0} tracks found", trackCount));

            List<PointOfInterestList> tracks = new List<PointOfInterestList>();

            for (int i = 0; i < gpxTracks.Count; i++)
            {
                XmlNodeList pointNodes = gpxTracks[i].Value;
                PointOfInterestList pointsOfInterest = new PointOfInterestList { ListName = gpxTracks[i].Key };
                pointsOfInterest.SourceFile = Path.GetFileName(filename);
                tracks.Add(pointsOfInterest);

                PointOfInterest lastPoint = null;

                foreach (XmlNode pointNode in pointNodes)
                {
                    PointOfInterest poi = GpxToPoint(pointNode);
                    pointsOfInterest.Add(poi);

                    if (gpxTracks[i].Key == "Waypoints")
                    {
                        pointsOfInterest.ListName = poi.Name;
                        if (pointNode.NextSibling != null && tracks.Count < pointNodes.Count)
                        {
                            pointsOfInterest = new PointOfInterestList();
                            pointsOfInterest.Type = ListType.Waypoint;
                            tracks.Add(pointsOfInterest);
                        }
                    }

                    // Calculate speeds
                    if (lastPoint != null)
                    {
                        TimeSpan time = poi.When - lastPoint.When;
                        double dist = poi.DistanceToPoint(lastPoint);
                        if (time.TotalSeconds > 0 && (poi.Speed == null || !poi.Speed.HasValue))
                        {
                            SpeedMeasurement speed = new SpeedMeasurement(dist / 1000 / time.TotalHours);
                            poi.Speed = speed;
                        }
                        if (poi.Distance == null || !poi.Distance.HasValue)
                        {
                            if (lastPoint.Distance == null)
                                poi.Distance = new DistanceMeasurement(dist);
                            else
                                poi.Distance = new DistanceMeasurement(lastPoint.Distance.GetValue(0.0) + dist);
                        }
                    }
                    lastPoint = poi;
                    poiCount++;
                }

                if (pointsOfInterest.Count > 0 && pointsOfInterest[0].When != DateTime.MinValue)
                    pointsOfInterest.Sort(PointOfInterest.ComparePointsByDate);
                //pointsOfInterest.Sort(PointOfInterest.ComparePointsNorthToSound);
            }
            return tracks;
        }
		
		private static List<KeyValuePair<string, XmlNodeList>> GetGPXTracksFromGPXFile(string fileName)
		{
			XmlDocument gpxDoc = new XmlDocument();
			gpxDoc.Load(fileName);
			
			List<KeyValuePair<string, XmlNodeList>> gpxTracks = new List<KeyValuePair<string, XmlNodeList>>();

			//Waypoints
			if (Settings.GpxIncludeWaypoints)
			{
				XmlNodeList wayPoints = gpxDoc.SelectNodes("//*[local-name()='wpt' and descendant::*[local-name()='time']]");

                //foreach (XmlNode wptNode in wayPoints)
				if (wayPoints.Count > 0)
				{
					gpxTracks.Add(new KeyValuePair<string, XmlNodeList>("Waypoints", wayPoints));
				}
			}

			//Routes
			if (Settings.GpxIncludeRoutes)
			{
				XmlNodeList routes = gpxDoc.GetElementsByTagName("rte");

				foreach (XmlNode route in routes)
				{
					XmlNodeList points = route.SelectNodes(".//*[local-name()='rtept']"); //and descendant::*[local-name()='time']]");
                    XmlNode nameNode = route.SelectSingleNode("*[local-name()='name']");

					if (points.Count > 0)
					{
                        if (nameNode == null)
    					    gpxTracks.Add(new KeyValuePair<string, XmlNodeList>(String.Empty, points));
                        else
                            gpxTracks.Add(new KeyValuePair<string,XmlNodeList>(nameNode.InnerText, points));
					}
				}
			}

			//Track segments
			if (Settings.GpxIncludeTracks)
			{
                XmlNodeList tracks = gpxDoc.GetElementsByTagName("trk");
                foreach (XmlNode track in tracks)
                {
                    XmlNode nameNode = track.SelectSingleNode("*[local-name()='name']");
				    XmlNodeList trackSegs = track.SelectNodes("*[local-name()='trkseg']");

				    foreach (XmlNode trackSeg in trackSegs)
				    {
					    XmlNodeList points = trackSeg.SelectNodes(".//*[local-name()='trkpt']");// and descendant::*[local-name()='time']]");

					    if (points.Count > 0)
					    {
                            if (nameNode == null)
					            gpxTracks.Add(new KeyValuePair<string, XmlNodeList>(String.Empty, points));
                            else
					            gpxTracks.Add(new KeyValuePair<string, XmlNodeList>(nameNode.InnerText, points));
					    }
				    }
                }
			}

			return gpxTracks;
		}

        /// <summary>
        /// Build a PointOfInterest object from a GPX trkpnt node
        /// </summary>
        /// <param name="pointNode"></param>
        private static PointOfInterest GpxToPoint(XmlNode pointNode)
        {
            PointOfInterest point = new PointOfInterest { TypePoi = 0, 
                Latitude = Convert.ToDouble(pointNode.Attributes["lat"].InnerText, CultureInfo.InvariantCulture), 
                Longitude = Convert.ToDouble(pointNode.Attributes["lon"].InnerText, CultureInfo.InvariantCulture) };

			if (pointNode["name"] != null)
			{
                point.Name = pointNode["name"].InnerText;
                if (pointNode["urlname"] != null)
                    point.Name += String.Format("-{0}", pointNode["urlname"].InnerText);
			}

            if (pointNode["sym"] != null)
                point.Symbol = pointNode["sym"].InnerText;

            if (pointNode["time"] != null)
            {
                point.When = DateTime.Parse(pointNode["time"].InnerText, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                point.TypePoi = 1;
            }

			point.Altitude = new ElevationMeasurement();

			if (pointNode["ele"] != null)
			{
				point.Altitude.SetValue(Convert.ToDouble(pointNode["ele"].InnerText, CultureInfo.InvariantCulture));
				point.TypePoi = 2;
			}

			point.Speed = new SpeedMeasurement();

			if (pointNode["extensions"] != null
				 && pointNode["extensions"]["gpxdgm:pointExtension"] != null
				 && pointNode["extensions"]["gpxdgm:pointExtension"]["gpxdgm:speed"] != null)
			{
				point.Speed.SetValue(Convert.ToDouble(pointNode["extensions"]["gpxdgm:pointExtension"]["gpxdgm:speed"].InnerText, CultureInfo.InvariantCulture));
			}
            return point;
        }

        #endregion

        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamWriter sw = new StreamWriter(args.Filename, false))
            {
                args.Log("Saving data to GPX...");
                sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                sb.Append("<gpx version=\"1.1\" ");
                sb.Append("creator=\"DG Manager.NET - http://sourceforge.net/projects/dgmanager-net/\" ");
                sb.Append("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
                sb.Append("xmlns=\"http://www.topografix.com/GPX/1/1\" ");
                if (Settings.GpxSaveSpeedData)
                    sb.Append("xmlns:gpxdgm=\"http://dgmanager-net.sourceforge.net/xmlschemas/GpxExtensions/1.0\" ");
                sb.AppendLine("xsi:schemaLocation=\"http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd http://dgmanager-net.sourceforge.net/xmlschemas/GpxExtensions/1.0 http://dgmanager-net.sourceforge.net/xmlschemas/GpxExtensions/1.0/gpx-dgm.xsd\">");
                int writtenTracks = 0;
                for (int i = 0; i < args.Tracks.Count; i++)
                {
                    PointOfInterestList track = args.Tracks[i];
                    string gpx = ListToGpx(track);
                    if (!String.IsNullOrEmpty(gpx))
                    {
                        sb.Append(gpx);
                        writtenTracks++;
                    }
                    args.ReportProgress(i + 1);
                }
                sb.Append("</gpx>");
                sw.Write(sb.ToString());
                sw.Close();
                args.Log(String.Format("{0} saved ({1} tracks)", args.Filename, writtenTracks));
            }
        }

        private static string ListToGpx(PointOfInterestList list)
        {
            if (list.Count == 0) return String.Empty;
            StringBuilder sb = new StringBuilder();
            if (list.Type != ListType.Waypoint)
            {
                sb.AppendLine(" <trk>");
                if (String.IsNullOrEmpty(list.ListName))
                    sb.AppendLine("  <name>DG-100 Track</name>");
                else
                    sb.AppendFormat(String.Format("  <name>{0}</name>{1}", list.ListName, Environment.NewLine));
                sb.AppendLine("  <type>GPS Tracklog</type>");
                sb.AppendLine("  <trkseg>");
                bool hasPoints = false;
                for (int i = 0; i < list.Count; i++)
                    if (!list.PointIsTrimmed(i))
                    {
                        sb.Append(PointToGPXPath(list[i]));
                        hasPoints = true;
                    }
                sb.AppendLine("  </trkseg>");
                sb.AppendLine(" </trk>");
                if (hasPoints)
                    return sb.ToString();
                return String.Empty;
            }
            sb.AppendFormat("  <wpt lat=\"{0}\" lon=\"{1}\">\n", list[0].Latitude, list[0].Longitude);
            sb.AppendFormat("    <time>{0:yyyy-MM-dd}T00:00:00Z</time>\n", list[0].When);
            sb.AppendFormat("    <name>{0}</name>\n", System.Web.HttpUtility.HtmlEncode(list.ListName));
            sb.AppendFormat("    <desc>{0}</desc>\n", list.ListName);
            sb.AppendLine("    <cmt></cmt>");
            sb.AppendLine("    <sym>Geocache</sym>");
            sb.AppendLine("    <type>Geocache|Traditional Cache</type>");
            sb.AppendLine("    <extensions> <gpxx:WaypointExtension xmlns:gpxx=\"http://www.garmin.com/xmlschemas/GpxExtensions/v3\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.garmin.com/xmlschemas/GpxExtensions/v3 http://www.garmin.com/xmlschemas/GpxExtensions/v3/GpxExtensionsv3.xsd\"> <gpxx:DisplayMode>SymbolAndName</gpxx:DisplayMode> </gpxx:WaypointExtension> </extensions>");
            sb.AppendLine("  </wpt>");
            return sb.ToString();
        }

        private static string PointToGPXPath(PointOfInterest point)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("   <trkpt lat=\"{0}\" lon=\"{1}\">" + Environment.NewLine,
                            point.Latitude.ToString(CultureInfo.InvariantCulture),
                            point.Longitude.ToString(CultureInfo.InvariantCulture));
            string d = String.Format("{0:0000}-{1:00}-{2:00}T{3:00}:{4:00}:{5:00}Z", 
                point.When.Year, point.When.Month, point.When.Day, 
                point.When.Hour, point.When.Minute, point.When.Second);
            
            if (point.TypePoi == 1 || point.TypePoi == 2)
            {
                sb.AppendFormat("    <time>{0}</time>{1}", d, Environment.NewLine);
            }

            if (point.TypePoi == 2)
            {
                sb.AppendFormat("    <ele>{1}</ele>{0}", Environment.NewLine,
                    point.Altitude.GetValue(0.0).ToString(CultureInfo.InvariantCulture));
            }

            if (Settings.GpxSaveSpeedData && point.Speed != null && point.Speed.HasValue)
            {
                sb.AppendFormat("    <extensions>{0}       <gpxdgm:pointExtension>{0}", Environment.NewLine);
                sb.AppendFormat("          <gpxdgm:speed>{0}</gpxdgm:speed>" + Environment.NewLine,
                    point.Speed.GetValue(MeasurementSystem.Metric).ToString(CultureInfo.InvariantCulture));
                sb.AppendFormat("       </gpxdgm:pointExtension>{0}    </extensions>{0}", Environment.NewLine);
            }

            sb.AppendFormat("   </trkpt>{0}", Environment.NewLine);

            return sb.ToString();
        }

        #endregion
    }
}
