using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DGManager.Backend
{
    [PointConverter(Description="Border Points Ascii (.asc)", Extensions=".asc")]
    public class AscPointConverter : IPointReader
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            List<PointOfInterestList> pois = new List<PointOfInterestList>();
            PointOfInterestList curList = new PointOfInterestList();
            pois.Add(curList);
            curList.ListName = "AL-FL";
            int lastLine = 1;
            int curLine = -1;
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                if (int.TryParse(values[0].Trim(), out curLine))
                {
                    if (lastLine != curLine)
                    {
                        curList = new PointOfInterestList();
                        curList.SourceFile = Path.GetFileName(filename);
                        pois.Add(curList);
                        curList.ListName = values[1].Trim();
                        lastLine = curLine;
                    }
                    curList.Add(new PointOfInterest(double.Parse(values[3].Trim()), -double.Parse(values[4].Trim())));
                }
            }

            return pois;
        }

        #endregion
    }
}
