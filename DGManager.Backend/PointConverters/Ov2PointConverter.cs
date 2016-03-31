using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DGManager.Backend.PointConverters
{
    [PointConverter(Description="TomTom POI File (.ov2)", Extensions=".ov2")]
    public class Ov2PointConverter : IPointReader, IPointWriter
    {
        #region IPointReader Members

        public List<PointOfInterestList> ParseFile(string filename, PointReaderArgs args)
        {
            FileStream poiStream;
            List<PointOfInterestList> tracks = new List<PointOfInterestList>();
            PointOfInterest poi;

            if (!File.Exists(filename))
            {
                return tracks;
            }

            poiStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);

            try
            {

                while (poiStream.Position < poiStream.Length)
                {

                    int recordType = BinaryReader.ReadShort(poiStream);
                    int recordLength = recordType == 1 ? 21 : BinaryReader.ReadInt(poiStream);

                    poi = new PointOfInterest();
                    switch (recordType)
                    {
                        // Deleted records?
                        case 0:
                            poiStream.Seek((long)recordLength - 5, SeekOrigin.Current);
                            continue;
                        // 'Skipper' records - should define bounds.  doesn't always exist and multiples could exist
                        case 1:
                            poiStream.Seek((long)recordLength - 1, SeekOrigin.Current);
                            continue;
                        // Simple and Extended POI
                        case 2:
                        case 3:
                            poi.Longitude = (double)BinaryReader.ReadInt(poiStream) / 100000;
                            poi.Latitude = (double)BinaryReader.ReadInt(poiStream) / 100000;
                            poi.Name = BinaryReader.ReadString(poiStream);
                            if (recordType == 3)
                            {
                                BinaryReader.ReadString(poiStream); // Unique ID
                                BinaryReader.ReadString(poiStream); // Extra data?
                            }
                            break;
                        default:
                            args.Log(String.Format("Invalid record: {0}", recordType));
                            poiStream.Close();
                            return tracks;
                    }

                    PointOfInterestList track = new PointOfInterestList { ListName = poi.Name, Type = ListType.Waypoint };
                    track.SourceFile = Path.GetFileName(filename);
                    tracks.Add(track);
                    track.Add(poi);
                }
            }
            finally
            {
                poiStream.Close();
            }
            return tracks;
        }

        #endregion

        #region IPointWriter Members

        public void WriteFile(PointWriterArgs args)
        {
            using (FileStream poiStream = new FileStream(args.Filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write) { })
            {
                try
                {
                    foreach (PointOfInterestList list in args.Tracks)
                        foreach (PointOfInterest poi in list)
                            PointToStream(poi, poiStream);
                }
                finally
                {
                    poiStream.Close();
                }
            }
        }

        public static void PointToStream(PointOfInterest point, Stream stream)
        {
            long size = 4 + 4 + 4 + 1 + point.Name.Length + 1;
            long latLong = (long)Math.Truncate(point.Longitude * 100000);

            stream.WriteByte(2);
            byte[] sizeBytes = BitConverter.GetBytes(size);
            stream.Write(sizeBytes, 0, 4);
            byte[] latLongBytes = BitConverter.GetBytes(latLong);
            stream.Write(latLongBytes, 0, 4);
            latLong = (long)Math.Truncate(point.Latitude * 100000);
            latLongBytes = BitConverter.GetBytes(latLong);
            stream.Write(latLongBytes, 0, 4);
            byte[] nameBytes = new ASCIIEncoding().GetBytes(point.Name);
            stream.Write(nameBytes, 0, nameBytes.Length);
        }

        #endregion
    }
}
