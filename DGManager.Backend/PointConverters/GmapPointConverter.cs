using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;
using System.Drawing;

namespace DGManager.Backend
{
    [PointConverter(Description="Google Map Javascript", Extensions=".htm,.html,.js", DefaultExtension=".htm")]
    public class GmapPointConverter : IPointReader, IPointWriter
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            int poiCount = 0;

            List<PointOfInterestList> tracks = new List<PointOfInterestList>();

            string file = File.ReadAllText(filename);
            MatchCollection mc = Regex.Matches(file, @"\{id:.*?laddr:""(?<name>[^""]*)"".*?latlng:\{lat:(?<lat>-?[\d.]*),lng:(?<lon>-?[\d.]*)");
            if (mc.Count > 0)
                foreach (Match m in mc)
                {
                    PointOfInterestList newList = new PointOfInterestList();
                    newList.SourceFile = Path.GetFileName(filename);
                    PointOfInterest newPoint = new PointOfInterest();
                    newList.ListName = m.Groups["name"].Value;
                    newPoint.Name = m.Groups["name"].Value;
                    newPoint.Latitude = double.Parse(m.Groups["lat"].Value);
                    newPoint.Longitude = double.Parse(m.Groups["lon"].Value);
                    newList.Add(newPoint);
                    tracks.Add(newList);
                    poiCount++;
                }
            else
            {
                mc = Regex.Matches(file, @"\{id:""(?<name>[^""]*)"",points:""(?<points>[^""]*)"",levels:""(?<levels>[^""]*)"".*?\}", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
                Match steps = Regex.Match(file, "\\{steps:\\[(\\{polyline:(?<line>\\d+),ppt:(?<point>\\d+)\\},?)*\\]\\}", RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);
                foreach (Match m in mc)
                {
                    PointOfInterestList newTrack = GeoUtil.GetLine(m.Groups["name"].Value, m.Groups["points"].Value.Replace("\\\\", "\\"));
                    newTrack.SourceFile = Path.GetFileName(filename);
                    if (newTrack.Count > 0)
                    {
                        tracks.Add(newTrack);
                        poiCount += newTrack.Count;
                    }
                }
                if (steps.Success)
                {
                    int segments = steps.Groups[1].Captures.Count;
                    PointOfInterestList[] trackSegs = new PointOfInterestList[segments];
                    int nextPosition = 0, lastSegment = 0;
                    for (int i = 1; i < segments; i++)
                    {
                        int track = int.Parse(steps.Groups["line"].Captures[i].Value);
                        int point = int.Parse(steps.Groups["point"].Captures[i].Value);
                        if (lastSegment != track)
                        {
                            nextPosition = 0;
                            lastSegment = track;
                        }
                        trackSegs[i - 1] = new PointOfInterestList();
                        for (int j = nextPosition; j < point; j++)
                            trackSegs[i - 1].Add(tracks[track][j]);
                        nextPosition = point + 1;
                    }
                    trackSegs[segments - 1] = new PointOfInterestList();
                    while (nextPosition < tracks[tracks.Count - 1].Count)
                    {
                        trackSegs[segments - 1].Add(tracks[tracks.Count - 1][nextPosition]);
                        nextPosition++;
                    }
                    tracks.Clear();
                    tracks.AddRange(trackSegs);
                }
                Match panel = Regex.Match(file, @"panel:""(.*?)(?<!\\)""", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
                if (panel.Success)
                {
                    string text = Regex.Replace(panel.Groups[1].Value, "\\\\x([0-9a-fA-F]{2})", m => ((char)Int16.Parse(m.Groups[1].Value, NumberStyles.HexNumber)).ToString());
                    mc = Regex.Matches(text, "<td class=dirsegtext id=dirsegtext[_0-9]*>(.*?)</td>", RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);
                    for (int i = 0; i < mc.Count; i++)
                        tracks[i].ListName = Regex.Replace(mc[i].Groups[1].Value, "<[^>]*>", "");
                }
            }
            //DataOperationBackgroundWorker.ReportProgress(i + 1);

            args.Log(poiCount + " points loaded");
            return tracks;
        }

        #endregion

        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            StringBuilder sb = new StringBuilder();
            int totalCheckedPointCount = args.Tracks[0].Count;
            int totalTrimmedPointCount = (args.Tracks[0].IsTrimmed) ? (args.Tracks[0].TrimEnd - args.Tracks[0].TrimStart) : args.Tracks[0].Count;
            PointOfInterestList firstList = args.Tracks[0];
            bool hasPoints = false;
            firstList.CalcBBox(true);

            for (int i = 1; i < args.Tracks.Count; i++)
            {
                PointOfInterestList poiList = args.Tracks[i];
                totalCheckedPointCount += poiList.Count;
                totalTrimmedPointCount += poiList.IsTrimmed ? (poiList.TrimEnd - poiList.TrimStart) : poiList.Count;
                poiList.BBox.N = firstList.BBox.N;
                poiList.BBox.S = firstList.BBox.S;
                poiList.BBox.E = firstList.BBox.E;
                poiList.BBox.W = firstList.BBox.W;
                poiList.CalcBBox(false);
                firstList = poiList;
            }

            //firstList = args.Tracks[0];

            if (Settings.GMapsStrictHtml)
            {
                sb.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">");
                sb.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\">");
            }
            else
                sb.AppendLine("<html>");
            sb.AppendLine("  <head>");
            sb.AppendLine("    <meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\"/>");
            sb.AppendFormat("    <title>Generated on {0:yyyy}/{0:MM}/{0:dd} by DGManager.NET</title>{1}", DateTime.Today, Environment.NewLine);
            sb.AppendLine("    <style type=\"text/css\">");
            sb.AppendLine("       img.gv_wpt_thumbnail { width:300px !important }");
            sb.AppendLine("    </style>");
            sb.AppendFormat("    <script src=\"http://maps.google.com/maps?file=api&amp;v=2&amp;key={0}\" type=\"text/javascript\"></script>{1}", Settings.GMapsApiKey, Environment.NewLine);
            sb.AppendLine("    <script type=\"text/javascript\">");
            sb.AppendLine("   // <![CDATA[");
            if (args.IncludeGMapEvents)
            {
                sb.AppendLine("   // this will trigger a document loaded event upon completion");
                sb.AppendLine("   // useful for signaling to the parent container to query our state");
                sb.AppendLine("   function NullReload()");
                sb.AppendLine("   {");
                sb.AppendLine("   	var f = document.getElementById('nulldoc');");
                sb.AppendLine("   	f.src = f.src;");
                sb.AppendLine("   }");
            }
            sb.AppendLine("    var map;");
            sb.AppendLine("    function load() {");
            sb.AppendLine("      if (GBrowserIsCompatible()) {");
            sb.AppendLine("       var map = new GMap2(document.getElementById(\"map\"));");
            sb.AppendLine("       map.enableDoubleClickZoom();");
            sb.AppendLine("       map.enableContinuousZoom();");
            sb.AppendLine("       map.enableScrollWheelZoom();");
            if (Settings.GMapsSmallControls)
            {
                sb.AppendLine("       map.addControl(new GSmallMapControl3D());");
            }
            else
            {
                sb.AppendLine("       map.addControl(new GLargeMapControl3D());");
            }
            sb.AppendLine("       map.addControl(new GHierarchicalMapTypeControl());");
            if (!Settings.GMapsMapButton)
            {
                sb.AppendLine("       map.removeMapType(G_NORMAL_MAP);");
            }
            if (!Settings.GMapsSatelliteButton)
            {
                sb.AppendLine("       map.removeMapType(G_SATELLITE_MAP);");
            }
            if (!Settings.GMapsHybridButton)
            {
                sb.AppendLine("       map.removeMapType(G_HYBRID_MAP);");
            }
            if (Settings.GMapsTerrainButton)
            {
                sb.AppendLine("       map.addMapType(G_PHYSICAL_MAP);");
            }
            if (Settings.GMapsOverviewMap)
            {
                sb.AppendLine("       map.addControl(new GOverviewMapControl(new GSize( 150, 100)));");
            }
            sb.AppendFormat(CultureInfo.InvariantCulture, "       var s = {0};{1}", firstList.BBox.S, Environment.NewLine);
            sb.AppendFormat(CultureInfo.InvariantCulture, "       var n = {0};{1}", firstList.BBox.N, Environment.NewLine);
            sb.AppendFormat(CultureInfo.InvariantCulture, "       var w = {0};{1}", firstList.BBox.W, Environment.NewLine);
            sb.AppendFormat(CultureInfo.InvariantCulture, "       var e = {0};{1}", firstList.BBox.E, Environment.NewLine);
            sb.AppendLine("      var SW = new GLatLng(s,w);");
            sb.AppendLine("  	   var NE = new GLatLng(n,e);");
            sb.AppendLine("  	   var Bnd = new GLatLngBounds(SW,NE);");
            sb.AppendLine("  	   var Zoom = map.getBoundsZoomLevel(Bnd);");
			sb.AppendLine("        map.addControl(new GScaleControl());");
            sb.AppendLine("  	   map.setCenter(Bnd.getCenter(), Zoom);");
            sb.AppendLine("       var icon = new GIcon(); icon.iconSize = new GSize(16, 16); icon.iconAnchor = new GPoint(8, 8);");
            sb.AppendLine("       wpts = new Array();");
            sb.AppendLine("       var points = [];");
            if (args.IncludeGMapEvents)
            {
                sb.AppendLine("       	GEvent.addListener(map, \"singlerightclick\", function(pixel, tile, pin) {");
                sb.AppendLine("       			var pt = map.fromContainerPixelToLatLng(pixel)");
                sb.AppendLine("       			if (pin == null) {");
                sb.AppendLine("       			    map.addOverlay(new GMarker(new GLatLng(pt.lat(), pt.lng())));");
                sb.AppendLine("               		document.getElementById('hidLat').value = pt.lat();");
                sb.AppendLine("               		document.getElementById('hidLong').value = pt.lng();");
                sb.AppendLine("               		NullReload();");
                sb.AppendLine("          		}");
                sb.AppendLine("           	});");
            }


            bool dropPoints = Settings.GMapsDropPoints && totalTrimmedPointCount > Settings.GMapsDropPointsThreshold;
            int droppedPoints = 0;
            int trimmedPoints = 0;
            bool isFirstTrack = true;
            int trackIndex = 0;

            foreach (PointOfInterestList poiList in args.Tracks)
            {
                if (poiList.Count > 1)
                {
                    //sb.AppendLine("points = [];");

                    //fudge the value to provide more granularity at the lower end
                    double dropPointsMinDistance = 0;

                    if (Settings.GMapsDropPointsMinDistance > 0 && Settings.GMapsDropPointsMinDistance <= 10)
                    {
                        dropPointsMinDistance = Settings.GMapsDropPointsMinDistance / 5;
                    }
                    else if (Settings.GMapsDropPointsMinDistance > 10 && Settings.GMapsDropPointsMinDistance <= 20)
                    {
                        dropPointsMinDistance = Settings.GMapsDropPointsMinDistance / 2;
                    }
                    else if (Settings.GMapsDropPointsMinDistance > 20 && Settings.GMapsDropPointsMinDistance <= 30)
                    {
                        dropPointsMinDistance = Settings.GMapsDropPointsMinDistance / 2;
                    }
                    else if (Settings.GMapsDropPointsMinDistance > 30 && Settings.GMapsDropPointsMinDistance <= 40)
                    {
                        dropPointsMinDistance = Settings.GMapsDropPointsMinDistance * 2;
                    }
                    else if (Settings.GMapsDropPointsMinDistance > 40)
                    {
                        dropPointsMinDistance = Settings.GMapsDropPointsMinDistance * 5;
                    }

                    Color lineColor = isFirstTrack ? Settings.GMapsLineColor : ColorGenerator.GetColorForTrack(trackIndex);
                    string hexColor = String.Format("'#{0}{1}{2}'",
                                                    Convert.ToString(lineColor.R, 16).PadLeft(2, '0'),
                                                    Convert.ToString(lineColor.G, 16).PadLeft(2, '0'),
                                                    Convert.ToString(lineColor.B, 16).PadLeft(2, '0'));
                    int droppedPointsInTrack;
                    int trimmedPointsInTrack;
                    sb.Append(ListToGoogleMaps(poiList, isFirstTrack, dropPoints, dropPointsMinDistance, hexColor, out droppedPointsInTrack, out trimmedPointsInTrack));

                    droppedPoints += droppedPointsInTrack;
                    trimmedPoints += trimmedPointsInTrack;

					//sb.AppendFormat("        map.addOverlay(new GPolyline(points,{0},{1}{2}));" + Environment.NewLine,
                    //    (isFirstTrack && Settings.GMapsSpecifyLineColor) || (!isFirstTrack && Settings.GMapsDifferentTrackColors) ? hexColor : "null",
                    //    Settings.GMapsSpecifyLineWidth ? Settings.GMapsLineWidth.ToString() : "null",
                    //    Settings.GMapsSpecifyLineOpacity ? "," + ((double)Settings.GMapsLineOpacity / 100).ToString(CultureInfo.InvariantCulture) : "");

                    isFirstTrack = false;
                    trackIndex++;
                }
                else
                {
                    if (poiList[0].Symbol == null)
                        sb.AppendLine(PointToGMapPinPoint(poiList[0]));
                    else
                    {
                        string imagePath = String.Format("{0}\\WptTypes\\{1}.gif", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), poiList[0].Symbol);
                        //sb.AppendFormat("wpts.push( GV_Marker(map,{{lat:{0},lon:{1},name:'{2}',desc:'',url:\"{3}\",thumbnail:\"{3}\",color:'',icon:'camera'}}) );{4}",
                        //    poiList[0].Latitude.ToString(CultureInfo.InvariantCulture),
                        //    poiList[0].Longitude.ToString(CultureInfo.InvariantCulture),
                        //    poiList[0].Name.Replace("'", "\\'"),
                        //    "file:///" + imagePath.Replace(@"\", "/"), Environment.NewLine);
                        sb.AppendFormat("map.addOverlay(new GMarker(new GLatLng({0}, {1}), {{icon: new GIcon(icon, '{2}'), title: '{3}' }}) );{4}",
                            poiList[0].Latitude.ToString(CultureInfo.InvariantCulture),
                            poiList[0].Longitude.ToString(CultureInfo.InvariantCulture),
                            String.Format("file:///{0}", imagePath.Replace(@"\", "/")),
                            (poiList[0].Name ?? poiList.DisplayName).Replace("'", "\\'"), Environment.NewLine);
                    }
                    //hasPoints = true;
                }
            }

            if (args.Photos != null)
                args.Photos.ForEach(image =>
                {
                    if (image.Location != null)
                    {
                        hasPoints = true;
                        sb.AppendFormat("wpts.push( GV_Marker(map,{{lat:{0},lon:{1},name:'{2}',desc:'',url:\"{3}\",thumbnail:\"{3}\",color:'',icon:'camera'}}) );", 
									image.Location.Latitude.ToString(CultureInfo.InvariantCulture), 
									image.Location.Longitude.ToString(CultureInfo.InvariantCulture), 
									Path.GetFileNameWithoutExtension(image.FilePath), 
									String.Format("file:///{0}", image.FilePath.Replace(@"\", "/")));
                    }
                });

            if (hasPoints)
            {
                sb.AppendLine(
                    "window.setTimeout('GV_Filter_Waypoints(map,wpts)',100); // the delay lets IE6 realize the markers are in the cache");
            }

            switch (Settings.GMapsDefaultMapType)
            {
                case GMapType.Street:
                    sb.AppendLine("        map.setMapType(G_NORMAL_MAP);");
                    break;
                case GMapType.Satellite:
                    sb.AppendLine("        map.setMapType(G_SATELLITE_MAP);");
                    break;
                case GMapType.Hybrid:
                    sb.AppendLine("        map.setMapType(G_HYBRID_MAP);");
                    break;
            }
            sb.AppendLine("      }");
            sb.AppendLine("    }");
            sb.AppendLine("    //]]>");
            sb.AppendLine("    </script>");

            if (hasPoints)
            {
                sb.AppendLine("    <script src=\"http://maps.gpsvisualizer.com/google_maps/functions.js\" type=\"text/javascript\"></script>");
            }

            sb.AppendLine("  </head>");
            sb.AppendLine("  <body style=\"width: 100%; height: 100%; margin: 0; padding: 0;\" onload=\"load()\" onunload=\"GUnload()\">");
            sb.AppendLine("    <div id=\"map\"  style=\"position: absolute; top: 0; left: 0; width: 100%; height: 100%;\"></div>");
            if (args.IncludeGMapEvents)
            {
                sb.AppendLine("    <input type=\"hidden\" id='hidLat' />");
                sb.AppendLine("    <input type=\"hidden\" id='hidLong' />");
                sb.AppendLine("    	<iframe id=\"nulldoc\" src=\"GPSNullDoc.html\" style=\"width:0px;height:0px;display:none;\">");
                sb.AppendLine("    	</iframe>");
            }
            sb.AppendLine("  </body>");
            sb.AppendLine("</html>");

            if (droppedPoints > 0 || trimmedPoints > 0)
            {
                args.Log(String.Format("Out of {0} points:", totalCheckedPointCount));

                if (trimmedPoints > 0)
                {
                    args.Log(String.Format("   {0} points were trimmed ({1:#.}%)", trimmedPoints, (double)(trimmedPoints * 100) / totalCheckedPointCount));
                }

                if (droppedPoints > 0)
                {
                    args.Log(String.Format("   {0} points were dropped ({1:#.}%)", droppedPoints, (double)(droppedPoints * 100) / totalCheckedPointCount));
                }
            }

			if (!String.IsNullOrEmpty(args.Filename))
				using (StreamWriter sw = new StreamWriter(args.Filename))
				{
					sw.Write(sb.ToString());
					sw.Close();
				}
			else
			{
				byte[] output = ASCIIEncoding.ASCII.GetBytes(sb.ToString());
				args.OutputStream.Write(output, 0, output.Length);
			}
        }

        private static string ListToGoogleMaps(PointOfInterestList list, bool isFirstTrack, bool dropPoints, double minDistanceBtwPoints, string hexColor, out int droppedPoints, out int trimmedPoints)
        {
            StringBuilder sb = new StringBuilder();
			StringBuilder sbEncode = new StringBuilder();
			StringBuilder sbLevels = new StringBuilder();
            droppedPoints = 0;
            trimmedPoints = 0;
            PointOfInterest lastNonDroppedPoint = null;
            bool startPinPlaced = false;
			int prev_x = 0, prev_y = 0;
			string levelValues = "C@?@A@?@B@?@A@?@B@?@A@?@";
			int levelPos = 0;

            for (int i = 0; i < list.Count; i++)
            {
                PointOfInterest poi = list[i];

                if (!list.PointIsTrimmed(i))
                {
                    if (!dropPoints || i == list.Count - 1 || poi.IsManual
                        || poi.DistanceToPoint(list[i + 1]) >= minDistanceBtwPoints
                        || lastNonDroppedPoint == null || poi.DistanceToPoint(lastNonDroppedPoint) >= minDistanceBtwPoints)
                    {
                        if (!startPinPlaced && Settings.GMapsDisplayStartIcon)
                            sb.AppendLine(PointToGMapPinPoint(poi, Settings.GMapsStartIcon));
                        startPinPlaced = true;
                        //sb.AppendLine(PointToGoogleMap(poi));
						int x = Convert.ToInt32(poi.Latitude / .00001);
						int y = Convert.ToInt32(poi.Longitude / .00001);

						int delta_x = x - prev_x;
						int delta_y = y - prev_y;

						prev_x = x;
						prev_y = y;

						sbEncode.Append(GeoUtil.Encode(delta_x).Replace(@"\", @"\\"));
						sbEncode.Append(GeoUtil.Encode(delta_y).Replace(@"\", @"\\"));
						sbLevels.Append(levelValues[levelPos]);
						levelPos++;
						if (levelPos == levelValues.Length) levelPos = 0;

                        if (Settings.GuessManualPoints && poi.IsManual)
                        {
                            sb.AppendLine(PointToGMapPinPoint(poi));
                        }

                        lastNonDroppedPoint = poi;
                    }
                    else
                    {
                        droppedPoints++;
                    }
                }
                else
                {
                    trimmedPoints++;
                }
            }
            if (Settings.GMapsDisplayEndIcon && lastNonDroppedPoint != null)
                sb.AppendLine(PointToGMapPinPoint(lastNonDroppedPoint, Settings.GMapsEndIcon));
            sbLevels.Length--;
            sbLevels.Append(levelValues[0]);
			sb.AppendFormat("map.addOverlay(new GPolyline.fromEncoded({{ color: {3}, weight: {4}, points: \"{0}\", levels: \"{1}\", zoomFactor: 32, numLevels: 5 }}));{2}", 
							sbEncode, sbLevels, Environment.NewLine, (isFirstTrack && Settings.GMapsSpecifyLineColor) || (!isFirstTrack && Settings.GMapsDifferentTrackColors) ? hexColor : "null",
							Settings.GMapsSpecifyLineWidth ? Settings.GMapsLineWidth.ToString() : "null");
            //todo: figure out opacity. Settings.GMapsSpecifyLineOpacity ? "," + ((double)Settings.GMapsLineOpacity / 100).ToString(CultureInfo.InvariantCulture) : "");

            return sb.ToString();
        }

        //private static string PointToGoogleMap(PointOfInterest point)
        //{
        //    return String.Format("points.push(new GLatLng({0}, {1}));",
        //        point.Latitude.ToString(CultureInfo.InvariantCulture),
        //        point.Longitude.ToString(CultureInfo.InvariantCulture));
        //}

        private static string PointToGMapPinPoint(PointOfInterest point)
        {
            return String.Format("map.addOverlay(new GMarker(new GLatLng({0}, {1})));",
                point.Latitude.ToString(CultureInfo.InvariantCulture),
                point.Longitude.ToString(CultureInfo.InvariantCulture));
        }

        private static string PointToGMapPinPoint(PointOfInterest point, string icon)
        {
            return String.Format("map.addOverlay(new GMarker(new GLatLng({0}, {1}), new GIcon(G_DEFAULT_ICON, '{2}')) );",
                point.Latitude.ToString(CultureInfo.InvariantCulture),
                point.Longitude.ToString(CultureInfo.InvariantCulture),
                icon);
        }

        #endregion
    }
}
