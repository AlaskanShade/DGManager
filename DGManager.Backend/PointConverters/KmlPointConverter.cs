using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DGManager.Backend
{
    [PointConverter(Extensions=".kml", Description="Google Earth (.kml)")]
    public class KmlPointConverter : IPointReader, IPointWriter
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            string file = File.ReadAllText(filename);
            MatchCollection mc = Regex.Matches(file, "<Placemark>(.*?)</Placemark>", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
            List<PointOfInterestList> tracks = new List<PointOfInterestList>();
            for (int i = 0; i < mc.Count; i++)
            {
                PointOfInterestList track = new PointOfInterestList();
                track.SourceFile = Path.GetFileName(filename);
                Match nameMatch = Regex.Match(mc[i].Value, "<name>(.*?)</name>", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
                if (nameMatch.Success) track.ListName = nameMatch.Groups[1].Value;

                Match m = Regex.Match(mc[i].Value, "<coordinates>(.*?)</coordinates>", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
                string[] coords = Regex.Split(m.Groups[1].Value.Trim(), "(?<!,)[ \n]");
                tracks.Add(track);
                Array.ForEach(coords, coord =>
                {
                    PointOfInterest point = new PointOfInterest();
                    string[] parts = coord.Split(',');
                    point.Longitude = double.Parse(parts[0]);
                    point.Latitude = double.Parse(parts[1]);
                    if (parts.Length > 2)
                        point.Altitude = new ElevationMeasurement(double.Parse(parts[2]));
                    track.Add(point);
                });
                track[0].Name = String.Format("Track {0}", i);
            }
            return tracks;
        }

        #endregion

        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder manualPointsBuilder = new StringBuilder();
            using (StreamWriter sw = new StreamWriter(args.Filename, false))
            {
                args.Log("Saving data to KML...");
                sb.AppendLine("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
                sb.AppendLine("<kml xmlns=\"http://earth.google.com/kml/2.1\"");
                sb.AppendLine("	xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"");
                sb.AppendLine("	xsi:schemaLocation=\"http://earth.google.com/kml/2.1 ");
                sb.AppendLine("	http://code.google.com/apis/kml/schema/kml21.xsd\">");
                sb.AppendLine("  <Document>");
                sb.AppendLine("    <name>DG-100 Tracks</name>");
                sb.AppendFormat("    <Snippet>Generated {0:g}</Snippet>{1}", DateTime.Now, Environment.NewLine);
                sb.AppendLine("    <Style id=\"lineStyle\">");
                sb.AppendLine("      <LineStyle>");
                sb.AppendLine("        <color>7fff0000</color>");
                sb.AppendLine("        <width>6</width>");
                sb.AppendLine("      </LineStyle>");
                sb.AppendLine("    </Style>");
                for (int i = 0; i < args.Tracks.Count; i++)
                {
                    PointOfInterestList track = args.Tracks[i];
                    bool writtenHeader = false;
                    for (int j = 0; j < track.Count; j++)
                        if (track.Count > 1)
                        {
                            if (!track.PointIsTrimmed(j))
                            {
                                if (!writtenHeader)
                                {
                                    sb.AppendLine("    <Placemark>");
                                    sb.AppendLine(String.Format("  	  <name>{0}</name>", track.DisplayName));
                                    sb.AppendLine("  		<styleUrl>#lineStyle</styleUrl>");
                                    sb.AppendLine("  		<LineString>");
                                    sb.AppendLine("  		    <tessellate>1</tessellate>");
                                    sb.AppendLine("  			<coordinates>");
                                    writtenHeader = true;
                                }
                                if (writtenHeader)
                                    sb.Append(PointToKML(track[j], manualPointsBuilder));
                            }
                            if (writtenHeader && j == (track.Count - 1))
                            {
                                sb.AppendLine("  			</coordinates>");
                                sb.AppendLine("  		</LineString>");
                                sb.AppendLine("  	</Placemark>");
                            }
                        }
                        else
                        {
                            sb.AppendLine("    <Placemark>");
                            sb.AppendLine(String.Format("  	  <name>{0}</name>", track.DisplayName));
                            sb.AppendLine("      <Point>");
                            sb.AppendLine(String.Format("       <coordinates>{0}, {1}, 0</coordinates>", track[0].Longitude, track[1].Latitude));
                            sb.AppendLine("      </Point>");
                            sb.AppendLine("    </Placemark>");
                        }
                    args.ReportProgress(i + 1);
                }
                if (Settings.GuessManualPoints)
                    sb.AppendLine(manualPointsBuilder.ToString());
                if (args.Photos != null)
                    args.Photos.ForEach(image =>
                    {
                        if (image.Location != null)
                        {
                            string photoPath;
                            string photoPathLink;
                            if (Settings.KmlUsePhotoPathPrefix)
                            {
                                photoPath = Settings.KmlPhotoPathPrefix + Path.GetFileName(image.FilePath);
                                photoPathLink = photoPath;
                            }
                            else
                            {
                                photoPath = image.FilePath;
                                photoPathLink = String.Format("file:///{0}", image.FilePath.Replace(@"\", "/").Replace(" ", "%20"));
                            }
                            sb.AppendFormat("<Placemark><name><![CDATA[{0}]]></name><description><![CDATA[<p>{1}</p><p><a href=\"{2}\"><img src=\"{1}\" width=\"300\"><br>Show image in browser window</a></p>]]></description><Style><IconStyle><Icon><href>http://www.panorado.com/Placemark_PF.php?id=UEZfMS4yLjEuMg==</href></Icon></IconStyle></Style><Point><coordinates>{3},{4},{5}</coordinates></Point></Placemark>", Path.GetFileNameWithoutExtension(image.FilePath), photoPath, photoPathLink, image.Location.Longitude.ToString(CultureInfo.InvariantCulture), image.Location.Latitude.ToString(CultureInfo.InvariantCulture), image.Location.Altitude.HasValue ? image.Location.Altitude.Value.ToString(CultureInfo.InvariantCulture) : "0");
                        }
                    });
                sb.AppendLine("  </Document>");
                sb.AppendLine("</kml>");
                sw.Write(sb.ToString());
                sw.Close();
            }

            args.Log(String.Format("{0} saved", args.Filename));
        }

        private static string PointToKML(PointOfInterest point)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("      <Placemark>");
            sb.AppendFormat("        <name>{0}</name>{1}", point.NameHtml, Environment.NewLine);
            //sb.AppendLine("        <styleUrl>#waypoint</styleUrl>");
            sb.AppendLine("        <Point>");
            sb.AppendFormat("          <coordinates>{0},{1},{2}</coordinates>{3}",
                                 point.Longitude.ToString(CultureInfo.InvariantCulture),
                                 point.Latitude.ToString(CultureInfo.InvariantCulture),
                                 point.Altitude.GetValue(0.0).ToString(CultureInfo.InvariantCulture), 
                                 Environment.NewLine);
            sb.AppendLine("        </Point>");
            sb.AppendLine("      </Placemark>");

            return sb.ToString();
        }

        private static string PointToKML(PointOfInterest point, StringBuilder manualPointsBuilder)
        {
            if (point.IsManual)
            {
                manualPointsBuilder.Append(PointToKML(point));
            }

            return String.Format("{0},{1},{2} ",
                                 point.Longitude.ToString(CultureInfo.InvariantCulture),
                                 point.Latitude.ToString(CultureInfo.InvariantCulture),
                                 point.Altitude.GetValue(0.0).ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}
