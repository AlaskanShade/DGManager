using System;
using System.Collections.Generic;
using System.IO;

namespace DGManager.Backend.PointConverters
{
    [PointConverter(Description="OziExplorer Track File (.plt)", Extensions=".plt")]
    public class OziPltPointConverter : IPointReader, IPointWriter
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            string[] lines = File.ReadAllLines(filename);
            List<PointOfInterestList> tracks = new List<PointOfInterestList>();
            PointOfInterestList curList = null;
            for (int i = 6; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                if (fields.Length != 7)
                    continue;
                if (fields[2].Trim() == "1")
                {
                    curList = new PointOfInterestList();
                    curList.SourceFile = Path.GetFileName(filename);
                    tracks.Add(curList);
                }
                PointOfInterest newPoint = new PointOfInterest(double.Parse(fields[0]), 
                    double.Parse(fields[1])) 
                    { 
                        TypePoi = 2, 
                        Altitude = new ElevationMeasurement(double.Parse(fields[3]) * Constants.ELEVATION_FACTOR_IMPERIAL) 
                    };
                newPoint.When = newPoint.When.AddSeconds(double.Parse(fields[4]) * 24 * 60 * 60); 
                curList.Add(newPoint);
            }
            return tracks;
        }

        #endregion

        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            using (StreamWriter sw = new StreamWriter(args.Filename, false))
            {
                sw.WriteLine("OziExplorer Track Point File Version 2.1");
                sw.WriteLine("WGS 84");
                sw.WriteLine("Altitude is in Feet");
                sw.WriteLine("Reserved 3");
                sw.WriteLine("0,3,0,Track 000,0,0,0,0");
                sw.WriteLine("0");
                foreach (PointOfInterestList track in args.Tracks)
                    for (int i = 0; i < track.Count; i++)
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", track[i].Latitude, track[i].Longitude, (i == 0 ? 1 : 0), track[i].Altitude.GetValue(MeasurementSystem.Imperial), track[i].When.ToOADate(), track[i].When.ToString("yyyy-MMM-dd"), track[i].When.ToString("hh:mm:ss"));
                sw.Close();
            }
        }

        #endregion
    }
}
