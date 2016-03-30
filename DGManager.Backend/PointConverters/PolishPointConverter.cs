using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DGManager.Backend.PointConverters
{
    [PointConverter(Description = "Polish Map Format (.mp)", Extensions = ".mp")]
    public class PolishPointConverter : IPointReader
    {
        private static Regex rePoints = new Regex(@"\((?<lat>[\d.-]+),(?<lon>[\d.-]+)\)");
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            string region = String.Empty;
            PointOfInterestList currentList = null;
            List<PointOfInterestList> tracks = new List<PointOfInterestList>();
            StreamReader sr = File.OpenText(filename);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.StartsWith(";")) continue;
                if (line.StartsWith("[END"))
                {
                    if (currentList != null)
                    {
                        tracks.Add(currentList);
                        currentList = null;
                    }
                    region = String.Empty;
                    continue;
                }
                else if (line.StartsWith("["))
                {
                    region = line.Trim('[', ']');
                    if (region == "POLYLINE")
                    {
                        currentList = new PointOfInterestList();
                        currentList.SourceFile = Path.GetFileName(filename);
                    }
                    continue;
                }
                if (region == "POLYLINE")
                {
                    string[] parts = line.Split('=');
                    switch (parts[0])
                    {
                        case "Label":
                            currentList.ListName = parts[1];
                            break;
                        case "Data0":
                            foreach (Match m in PolishPointConverter.rePoints.Matches(line))
                                currentList.Add(new PointOfInterest(double.Parse(m.Groups["lat"].Value), double.Parse(m.Groups["lon"].Value)));
                            break;
                    }
                }
            }
            return tracks;
        }

        #endregion
    }
}
