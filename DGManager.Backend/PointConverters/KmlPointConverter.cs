using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace DGManager.Backend
{
    [PointConverter(Extensions=".kml", Description="Google Earth (.kml)")]
    public class KmlPointConverter : IPointReader, IPointWriter
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            var xDoc = XDocument.Load(filename);
            XNamespace rootName = "http://www.opengis.net/kml/2.2";
            XNamespace gxName = "http://www.google.com/kml/ext/2.2";
            List<PointOfInterestList> tracks = new List<PointOfInterestList>();
            var placemarks = xDoc.Descendants(rootName + "Placemark");
            foreach (var place in placemarks)
            {
                PointOfInterestList track = new PointOfInterestList();
                track.SourceFile = Path.GetFileName(filename);
                track.ListName = place.Element(rootName + "name").Value;
                if (String.IsNullOrEmpty(track.ListName))
                    track.ListName = String.Format("Track {0}", tracks.Count + 1);

                var coordNode = place.Descendants(rootName + "coordinates").Where(n => !String.IsNullOrEmpty(n.Value));
                if (coordNode != null && coordNode.Count() > 0)
                {
                    track.AddRange(Regex.Split(coordNode.First().Value.Trim(), "\\s+")
                        .Select(c => {
                            var point = new PointOfInterest();
                            string[] parts = c.Split(',');
                            point.Longitude = double.Parse(parts[0]);
                            point.Latitude = double.Parse(parts[1]);
                            if (parts.Length > 2)
                                point.Altitude = new ElevationMeasurement(double.Parse(parts[2]));
                            return point;
                        }));
                    tracks.Add(track);
                }
                var trackNode = place.Element(gxName + "Track");
                if (trackNode != null)
                {
                    var currentPoi = new PointOfInterest();
                    foreach (var n in trackNode.Elements())
                    {
                        if (n.Name == rootName + "when")
                            currentPoi.When = DateTime.Parse(n.Value, null, DateTimeStyles.AssumeLocal).ToUniversalTime();
                        if (n.Name == gxName + "coord")
                        {
                            string[] parts = n.Value.Split(' ');
                            currentPoi.Longitude = double.Parse(parts[0]);
                            currentPoi.Latitude = double.Parse(parts[1]);
                            currentPoi.TypePoi = 1;
                            track.Add(currentPoi);
                            currentPoi = new PointOfInterest();
                        }
                    }
                    tracks.Add(track);
                }
            }
            return tracks;
        }

        #endregion

        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            args.Log("Saving data to KML...");
            XNamespace rootName = "http://www.opengis.net/kml/2.2";
            XNamespace gxName = "http://www.google.com/kml/ext/2.2";
            var doc = new XDocument();
            doc.Add(new XElement(rootName + "kml", new XAttribute(XNamespace.Xmlns + "gx", "http://www.google.com/kml/ext/2.2"),
                new XElement(rootName + "Document", 
                    new XElement(rootName + "name", "DG-100 Tracks"),
                    new XElement(rootName + "Snippet", String.Format("Generated {0:g}", DateTime.Now)),
                    new XElement(rootName + "Style", new XAttribute("id", "lineStyle"),
                        new XElement(rootName + "LineStyle",
                            new XElement(rootName + "color", "7fff0000"),
                            new XElement(rootName + "width", "6"))),
                    args.Tracks.Select(t => TrackToPlacemark(t)))));
            doc.Save(args.Filename);

            //TODO test manual points
            if (Settings.GuessManualPoints)
                doc.Root.Element(rootName + "Document").Add(args.Tracks
                    .SelectMany(t => t.Where(p => p.IsManual)
                    .Select(p => new XElement(rootName + "Placemark",
                        new XElement(rootName + "name", p.NameHtml),
                        new XElement(rootName + "Point", 
                            new XElement(rootName + "coordinates", String.Format("{0},{1},{2}", p.Longitude, p.Latitude, p.Altitude.GetValue(0.0))))))));
            // TODO test photos
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
                        doc.Root.Element(rootName + "Document").Add(new XElement(rootName + "Placemark",
                            new XElement(rootName + "name", String.Format("<![CDATA[{0}]]>", Path.GetFileNameWithoutExtension(image.FilePath))),
                            new XElement(rootName + "description", String.Format("<![CDATA[<p>{0}</p><p><a href=\"{1}\"><img src=\"{0}\" width=\"300\"><br>Show image in browser window</a></p>]]>", photoPath, photoPathLink)),
                            new XElement(rootName + "Style",
                                new XElement(rootName + "IconStyle",
                                    new XElement(rootName + "Icon", 
                                        new XElement(rootName + "href", "http://www.panorado.com/Placemark_PF.php?id=UEZfMS4yLjEuMg==")))),
                            new XElement(rootName + "Point",
                                new XElement(rootName + "coordinates", String.Format("{0},{1},{2}", image.Location.Longitude, image.Location.Latitude, image.Location.Altitude.HasValue ? image.Location.Altitude.Value : 0)))));
                    }
                });

            args.Log(String.Format("{0} saved", args.Filename));
        }

        private static XElement TrackToPlacemark(PointOfInterestList track)
        {
            XNamespace rootName = "http://www.opengis.net/kml/2.2";
            XNamespace gxName = "http://www.google.com/kml/ext/2.2";
            var e = new XElement(rootName + "Placemark",
                new XElement(rootName + "name", track.ListName));
            if (track.Count == 1)
                e.Add(new XElement(rootName + "Point"), new XElement(rootName + "coordinates", String.Format("{0}, {1}, 0", track[0].Longitude, track[0].Latitude)));
            else if (track[0].TypePoi > 0) // has time
            {
                var trackNode = new XElement(gxName + "Track");
                e.Add(trackNode);
                if (track[0].TypePoi < 2) // no elevation
                    trackNode.Add(new XElement(rootName + "altitudeMode", "clampToGround"));
                else
                    trackNode.Add(new XElement(rootName + "altitudeMode", "absolute"));
                for (int i = 0; i < track.Count; i++)
                    if (!track.PointIsTrimmed(i))
                    {
                        trackNode.Add(new XElement(rootName + "when", track[i].When));
                        trackNode.Add(new XElement(gxName + "coord", String.Format("{0} {1} {2}", track[i].Longitude, track[i].Latitude, track[i].Altitude != null ? track[i].Altitude.GetValue(0.0) : 0)));
                    }
            }
            else
            {
                var lineNode = new XElement(rootName + "LineString", 
                    new XElement(rootName + "altitudeMode", "clampToGround"));
                e.Add(lineNode);
                var coordNode = new XElement(rootName + "coordinates");
                lineNode.Add(coordNode);
                var coords = new List<string>();
                for (int i = 0; i < track.Count; i++)
                    if (!track.PointIsTrimmed(i))
                        coords.Add(String.Format("{0},{1},{2}", track[i].Longitude, track[i].Latitude, track[i].Altitude != null ? track[i].Altitude.GetValue(0.0) : 0));
                coordNode.Value = String.Join(Environment.NewLine, coords);
            }
            return e;
        }

        #endregion
    }
}
