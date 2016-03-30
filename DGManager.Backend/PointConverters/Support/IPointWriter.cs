using System;

namespace DGManager.Backend
{
    public interface IPointWriter
    {
        void WriteFile(PointWriterArgs args);
    }
}
