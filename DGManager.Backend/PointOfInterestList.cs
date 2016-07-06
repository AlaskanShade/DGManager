using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DGManager.Backend
{
    public enum ListType { Track, Waypoint, Route }

	public class PointOfInterestList : List<PointOfInterest>
	{
        //public delegate bool CurrentPointIsNotTrimmedDelegate(); 

        private Guid _id;
		public BoundingBox BBox;
        private int _trimEnd = -1;
        private ListType _type = ListType.Track;

        public Guid ID
        {
            get
            {
                return _id;
            }
        }

        public string SourceFile { get; set; }

        public string ListName { get; set; }

        public string DisplayName
        {
            get { return String.Format("{0} ({1} points)", (String.IsNullOrEmpty(ListName) && Count > 0) ? (this[0].When != DateTime.MinValue ? this[0].When.AddHours(Settings.UtcShift) : this[0].When).ToString(Settings.TimeDisplayFormat) : ListName, Count); }
        }

        public ListType Type { get { return _type; } set { _type = value; } }

        public bool IsTrimmed { get; set; }

        public int TrimStart { get; set; }

        public int TrimEnd { get { return _trimEnd; } set { _trimEnd = value; } }

        public PointOfInterestList()
        {
            _id = Guid.NewGuid();
        }

        public bool PointIsTrimmed(int index)
        {
            return IsTrimmed && (index < TrimStart || index >= TrimEnd);
        }

        public void DrawPath(Graphics graphics)
        {
            DrawPath(graphics, Color.Black);
        }

        public void DrawPath(Graphics graphics, Color color)
        {
            DrawPathZoom(graphics, graphics.ClipBounds, color);
        }

        public void DrawPathZoom(Graphics graphics, RectangleF zoom)
        {
            DrawPathZoom(graphics, zoom, Color.Black);
        }

        public void DrawPathZoom(Graphics graphics, RectangleF zoom, Color color)
        {
            double horizontalProp = zoom.Width / Math.Abs(BBox.W - BBox.E);
            double verticalProp = zoom.Height / Math.Abs(BBox.N - BBox.S);
            PointF lastPoint = PointF.Empty;
            for (int j = 0; j < Count; j++)
            {
                if (!PointIsTrimmed(j))
                {
                    PointOfInterest point = this[j];
                    PointF currentPoint = new PointF(zoom.X + (float)(Math.Abs(point.Longitude - BBox.W) * horizontalProp), zoom.Y + (float)(Math.Abs(point.Latitude - BBox.N) * verticalProp));
                    if (!lastPoint.IsEmpty)
                        graphics.DrawLine(new Pen(color, (float)Settings.GMapsLineWidth), lastPoint, currentPoint);
                    lastPoint = currentPoint;
                }
            }
        }

        public BoundingBox CalcBBox(bool reset)
        {
			double n, s, e, w;
			PointOfInterest poi;

			if (reset)// || Count < 2) // This made the bounding box of multiple points only include the last point
			{
				poi = this[TrimStart];
				n = poi.Latitude;
				s = poi.Latitude;
				e = poi.Longitude;
				w = poi.Longitude;
			}
			else
			{
				n = BBox.N;
				s = BBox.S;
				e = BBox.E;
				w = BBox.W;
			}

			for (int i = (IsTrimmed ? TrimStart : 0); i < Math.Min(IsTrimmed ? TrimEnd : Count, Count); i++)
			{
				poi = this[i];

				if (poi.Latitude > n)
				{
					n = poi.Latitude;
				}

				if (poi.Latitude < s)
				{
					s = poi.Latitude;
				}

				if (poi.Longitude > e)
				{
					e = poi.Longitude;
				}

				if (poi.Longitude < w)
				{
					w = poi.Longitude;
				}
			}

			BBox.N = n;
			BBox.S = s;
			BBox.E = e;
			BBox.W = w;
            return BBox;
        }

		public static int CompareListsByDate(PointOfInterestList x, PointOfInterestList y)
		{
            if (x.Count == 0 || y.Count == 0) return 0;
			return x[0].When.CompareTo(y[0].When);
		}

        public string ToEncodedLine(bool dropPoints, double minDistanceBtwPoints, out int droppedPoints, out int trimmedPoints)
        {
            trimmedPoints = 0;
            droppedPoints = 0;
            StringBuilder sbEncode = new StringBuilder();
            PointOfInterest lastNonDroppedPoint = null;
            int prev_x = 0, prev_y = 0;
            for (int i = 0; i < Count; i++)
            {
                PointOfInterest poi = this[i];

                if (!PointIsTrimmed(i))
                {
                    if (!dropPoints || i == Count - 1 || poi.IsManual
                        || poi.DistanceToPoint(this[i + 1]) >= minDistanceBtwPoints
                        || lastNonDroppedPoint == null || poi.DistanceToPoint(lastNonDroppedPoint) >= minDistanceBtwPoints)
                    {
                        int x = Convert.ToInt32(poi.Latitude / .00001);
                        int y = Convert.ToInt32(poi.Longitude / .00001);

                        int delta_x = x - prev_x;
                        int delta_y = y - prev_y;

                        prev_x = x;
                        prev_y = y;

                        sbEncode.Append(GeoUtil.Encode(delta_x).Replace(@"\", @"\\"));
                        sbEncode.Append(GeoUtil.Encode(delta_y).Replace(@"\", @"\\"));

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
            return sbEncode.ToString();
        }

        public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			
			for (int i = 0; i < Count; i++)
			{
				if (i > 0)
				{
					sb.Append(Environment.NewLine);
				}

				sb.Append(this[i].ToString());
			}

			return sb.ToString();
		}

        public new void Remove(PointOfInterest point)
        {
            int position = IndexOf(point);
            if (position < TrimStart) TrimStart--;
            if (position < TrimEnd) TrimEnd--;
            base.Remove(point);
        }

        public new void RemoveAt(int index)
        {
            if (index < TrimStart) TrimStart--;
            if (index < TrimEnd) TrimEnd--;
            base.RemoveAt(index);
        }

        public void RecalculateDistanceSpeed()
        {
            PointOfInterest lastPoint = null;
            this[0].Distance = null;
            this[0].Speed = null;
            foreach (var poi in this)
            {
                if (lastPoint != null)
                {
                    TimeSpan time = poi.When - lastPoint.When;
                    double dist = poi.DistanceToPoint(lastPoint);
                    if (time.TotalSeconds > 0 && (poi.Speed == null || !poi.Speed.HasValue))
                    {
                        SpeedMeasurement speed = new SpeedMeasurement(dist / 1000 / time.TotalHours);
                        poi.Speed = speed;
                    }
                    if (poi.Distance == null || !poi.Distance.HasValue)
                    {
                        if (lastPoint.Distance == null)
                            poi.Distance = new DistanceMeasurement(dist);
                        else
                            poi.Distance = new DistanceMeasurement(lastPoint.Distance.GetValue(0.0) + dist);
                    }
                }
                lastPoint = poi;
            }
        }
    }
}
