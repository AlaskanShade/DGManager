using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace DGManager.Backend.PointConverters
{
    [PointConverter(Description="OpenStreetMap File (.osm)", Extensions=".osm")]
    public class OsmPointConverter : IPointReader
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            FileStream fs = File.OpenRead(filename);
            XmlReader xRead = XmlReader.Create(fs);
            Dictionary<int, PointOfInterest> nodes = new Dictionary<int, PointOfInterest>();
            List<PointOfInterestList> tracks = new List<PointOfInterestList>();

            while (xRead.Read())
            {
                if (xRead.NodeType == XmlNodeType.Element && xRead.Name == "node")
                {
                    PointOfInterest newNode = new PointOfInterest();
                    int id = int.Parse(xRead.GetAttribute("id"));
                    newNode.Latitude = double.Parse(xRead.GetAttribute("lat"));
                    newNode.Longitude = double.Parse(xRead.GetAttribute("lon"));
                    nodes.Add(id, newNode);
                }
                else if (xRead.NodeType == XmlNodeType.Element && xRead.Name == "way")
                {
                    XmlReader wayRead = xRead.ReadSubtree();
                    PointOfInterestList track = new PointOfInterestList();
                    track.SourceFile = Path.GetFileName(filename);
                    while (wayRead.Read())
                    {
                        if (wayRead.NodeType == XmlNodeType.Element && wayRead.Name == "nd")
                        {
                            int id = int.Parse(wayRead.GetAttribute("ref"));
                            if (nodes.ContainsKey(id))
                                track.Add(nodes[id]);
                        }
                        else if (wayRead.NodeType == XmlNodeType.Element && wayRead.Name == "tag" && wayRead.GetAttribute("k") == "name")
                        {
                            track.ListName = wayRead.GetAttribute("v");
                        }
                    }
                    if (track.Count > 0)
                        tracks.Add(track);
                }
            }

            fs.Close();
            return tracks;
        }

        #endregion
    }
}
