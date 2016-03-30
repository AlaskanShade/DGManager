using System;
using System.Collections.Generic;

namespace DGManager.Backend
{
    public interface IPointReader
    {
        List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args);
    }
}
