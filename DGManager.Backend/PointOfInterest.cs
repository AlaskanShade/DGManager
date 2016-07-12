using System;
using System.Web;

namespace DGManager.Backend
{
	public class PointOfInterest : ICloneable, IEquatable<PointOfInterest>
    {
        #region Fields
        private byte typePoi;
        #endregion

        #region Properties
        // 0 = position, 1 = position/time, 2 = position/time/elevation
        public byte TypePoi
		{
            get { if (When == DateTime.MinValue) return 0; return typePoi; }
			set { typePoi = value; }
		}

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public ElevationMeasurement Altitude { get; set; }

        public SpeedMeasurement Speed { get; set; }

        public DistanceMeasurement Distance { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Symbol { get; set; }
		
		public string NameHtml
		{
			get
			{
				return HttpUtility.HtmlEncode(Name);
			}
		}

		public string NameWPT
		{
			get
			{
				if (Name.Length < 40)
                    return Name.PadRight(40, ' ');
				return Name;
			}
		}

        public int Order { get; set; }

        public DateTime When { get; set; }

        public bool IsManual { get; set; }
        #endregion

        public PointOfInterest()
		{
		}

        public PointOfInterest(double latitude, double longitude)
        {
            TypePoi = 0;
            Latitude = latitude;
            Longitude = longitude;
        }
		
		public PointOfInterest(PointOfInterest source)
		{
			TypePoi = source.TypePoi;
			Longitude = source.Longitude;
			Latitude = source.Latitude;
			Name = source.Name;
			Altitude = source.Altitude;
			Order = source.Order;
		}

		public double DistanceToPoint(PointOfInterest point)
		{
			return Support.DistanceBetweenPoints(Latitude, Longitude, point.Latitude, point.Longitude);
		}

		public double BearingToPoint(PointOfInterest point)
		{
			return Support.BearingBetweenPoints(Latitude, Longitude, point.Latitude, point.Longitude);
		}

		public static int ComparePointsByDate(PointOfInterest x, PointOfInterest y)
		{
			return x.When.CompareTo(y.When);
		}

        public static int ComparePointsNorthToSound(PointOfInterest x, PointOfInterest y)
        {
            return y.Latitude.CompareTo(x.Latitude);
        }

        //public override string ToString()
        //{
        //    return String.Format("{0}, {1}, \"{2}\", \"{3}\"",
        //        Longitude.ToString().ToString(CultureInfo.InvariantCulture),
        //        Latitude.ToString(CultureInfo.InvariantCulture),
        //        GetCsvDisplayString(39, Name), Name);
        //}

        //private static string GetCsvDisplayString(int maxLength, string input)
        //{
        //    int open = input.IndexOf('(');
        //    int close = input.IndexOf(')');
        //    if (open > -1 && close > open)
        //        return input.Substring(open + 1, Math.Min(close - open - 1, maxLength));
        //    if (input.Length > maxLength)
        //        return input.Substring(0, maxLength);
        //    return input;
        //}

        #region ICloneable Members

        public object Clone()
        {
            return new PointOfInterest(Latitude, Longitude) { Altitude = Altitude, 
                Distance = Distance, IsManual = IsManual, Name = Name, Order = Order, 
                Speed = Speed, Symbol = Symbol, TypePoi = TypePoi, When = When };
        }

        #endregion

        #region IEquatable<PointOfInterest> Members

        public bool Equals(PointOfInterest other)
        {
            return Latitude == other.Latitude && Longitude == other.Longitude && When == other.When;
        }

        #endregion
    }
}
