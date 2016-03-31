using System;
using System.Text;
using System.Windows.Forms;
using DGManager.Backend;
using System.Collections.ObjectModel;

namespace DGManager
{
	public partial class TrackInfoDialog : Form
	{
		private int utcShift;
		private MeasurementSystem speedMeasurementSystem;
		private MeasurementSystem distanceMeasurementSystem;
		private MeasurementSystem elevationMeasurementSystem;

		public int UtcShift
		{
			get
			{
				return utcShift;
			}
			set
			{
				utcShift = value;
			}
		}

		public MeasurementSystem SpeedMeasurementSystem
		{
			get
			{
				return speedMeasurementSystem;
			}
			set
			{
				speedMeasurementSystem = value;
			}
		}

		public MeasurementSystem DistanceMeasurementSystem
		{
			get
			{
				return distanceMeasurementSystem;
			}
			set
			{
				distanceMeasurementSystem = value;
			}
		}

		public MeasurementSystem ElevationMeasurementSystem
		{
			get
			{
				return elevationMeasurementSystem;
			}
			set
			{
				elevationMeasurementSystem = value;
			}
		}

		public TrackInfoDialog()
		{
			InitializeComponent();
		}

		public void RefreshTrackInfo(Collection<PointOfInterestList> tracks)
		{
            //TODO Move these into PointOfInterestList?
			int pointsCount = 0;
			DateTime? startDate = null;
			DateTime? endDate = null;
			SpeedMeasurement minSpeed = new SpeedMeasurement();
			SpeedMeasurement maxSpeed = new SpeedMeasurement();
			SpeedMeasurement avgSpeed = new SpeedMeasurement();
			SpeedMeasurement moveAvgSpeed = new SpeedMeasurement();
			SpeedMeasurement sumSpeed = new SpeedMeasurement();
			DateTime minSpeedDate = DateTime.MinValue;
			DateTime maxSpeedDate = DateTime.MinValue;
			ElevationMeasurement minAltitude = new ElevationMeasurement();
			ElevationMeasurement maxAltitude = new ElevationMeasurement();
			ElevationMeasurement avgAltitude = new ElevationMeasurement();
			ElevationMeasurement sumAltitude = new ElevationMeasurement();
            ElevationMeasurement gainAltitude = new ElevationMeasurement();
            ElevationMeasurement lossAltitude = new ElevationMeasurement();
			DateTime minAltitudeDate = DateTime.MinValue;
			DateTime maxAltitudeDate = DateTime.MinValue;
			DistanceMeasurement distance = new DistanceMeasurement(0);
            TimeSpan? totalTime = new TimeSpan?();
            TimeSpan stoppedTime = new TimeSpan();

			foreach (PointOfInterestList track in tracks)
			{
				pointsCount += track.Count;
				PointOfInterest prevPoint = null;
                double lastAltitude = (track[0].Altitude != null && track[0].Altitude.HasValue) ? track[0].Altitude.GetValue() : 0;

				int start = track.IsTrimmed ? track.TrimStart : 0;
				int end = track.IsTrimmed ? track.TrimEnd : track.Count;
				for (int i = start; i < end; i++)
				//foreach (PointOfInterest point in track)
				{
					PointOfInterest point = track[i];
					if (!startDate.HasValue || point.When < startDate)
					{
						startDate = point.When;
					}

					if (!endDate.HasValue || point.When > endDate)
					{
						endDate = point.When;
					}

					if (point.Speed.HasValue)
					{
						if (!minSpeed.HasValue || point.Speed.GetValue() < minSpeed.GetValue())
						{
							minSpeed.SetValue(point.Speed.GetValue());
							minSpeedDate = point.When;
						}

						if (!maxSpeed.HasValue || point.Speed.GetValue() > maxSpeed.GetValue())
						{
							maxSpeed.SetValue(point.Speed.GetValue());
							maxSpeedDate = point.When;
						}

                        if (prevPoint != null && point.Speed.GetValue(0.0) < 1)
                            stoppedTime = stoppedTime.Add(point.When - prevPoint.When);
						sumSpeed.SetValue(sumSpeed.HasValue ? sumSpeed.GetValue() + point.Speed.GetValue() : point.Speed.GetValue());
					}

					if (point.TypePoi == 2 && point.Altitude.HasValue)
					{
						if (!minAltitude.HasValue || point.Altitude.GetValue() < minAltitude.GetValue())
						{
							minAltitude.SetValue(point.Altitude.GetValue());
							minAltitudeDate = point.When;
						}

						if (!maxAltitude.HasValue || point.Altitude.GetValue() > maxAltitude.GetValue())
						{
							maxAltitude.SetValue(point.Altitude.GetValue());
							maxAltitudeDate = point.When;
						}

                        double currentAltitude = point.Altitude.GetValue();
                        if (currentAltitude > lastAltitude)
    						gainAltitude.SetValue((gainAltitude.HasValue ? gainAltitude.GetValue() : 0) + (currentAltitude - lastAltitude));
                        else
    						lossAltitude.SetValue((lossAltitude.HasValue ? lossAltitude.GetValue() : 0) + (lastAltitude - currentAltitude));
						sumAltitude.SetValue(sumAltitude.HasValue ? sumAltitude.GetValue() + currentAltitude : currentAltitude);
                        //if (prevPoint != null)
                        //{
                        //    double slope = Math.Abs((point.Altitude.GetValue() - prevPoint.Altitude.GetValue()) / prevPoint.DistanceToPoint(point));
                        //    if (slope > maxSlope) maxSlope = slope;
                        //}
                        lastAltitude = currentAltitude;
					}

					if (prevPoint != null)
					{
						distance.SetValue(distance.GetValue() + prevPoint.DistanceToPoint(point));
					}

					prevPoint = point;
				}
			}

            totalTime = endDate - startDate;

			if (totalTime.HasValue)
			{
				avgSpeed.SetValue(distance.GetValue() / 1000 / totalTime.Value.TotalHours);
                moveAvgSpeed.SetValue(distance.GetValue() / 1000 / (totalTime.Value - stoppedTime).TotalHours);
			}

			if (sumAltitude.HasValue)
			{
				avgAltitude.SetValue(sumAltitude.GetValue() / pointsCount);
			}

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(String.Format("Data Points: {0}", pointsCount));
			sb.AppendLine("");
			sb.AppendLine(String.Format("Start Time: {0:G}", (startDate.HasValue && startDate != DateTime.MinValue) ? startDate.Value.AddHours(UtcShift) : DateTime.MinValue));
			sb.AppendLine(String.Format("End Time: {0:G}", (endDate.HasValue && endDate != DateTime.MinValue) ? endDate.Value.AddHours(UtcShift) : DateTime.MaxValue));
			sb.AppendLine(String.Format("Total Time: {0}", totalTime));
			sb.AppendLine(String.Format("Stopped Time: {0}", stoppedTime));
			sb.AppendLine("");
			sb.AppendLine(String.Format("Distance: {0}", distance.HasValue ? distance.ToString(DistanceMeasurementSystem) : "N/A"));
			sb.AppendLine("");
			sb.AppendLine(String.Format("Min Speed: {0}", minSpeed.HasValue ? minSpeed.ToString(SpeedMeasurementSystem) + " @ " + minSpeedDate.AddHours(UtcShift).ToString("G") : "N/A"));
			sb.AppendLine(String.Format("Max Speed: {0}", maxSpeed.HasValue ? maxSpeed.ToString(SpeedMeasurementSystem) + " @ " + maxSpeedDate.AddHours(UtcShift).ToString("G") : "N/A"));
			sb.AppendLine(String.Format("Avg Speed: {0}", avgSpeed.HasValue ? avgSpeed.ToString(SpeedMeasurementSystem) : "N/A"));
			sb.AppendLine(String.Format("Moving Avg Speed: {0}", moveAvgSpeed.HasValue ? moveAvgSpeed.ToString(SpeedMeasurementSystem) : "N/A"));
			sb.AppendLine("");
			sb.AppendLine(String.Format("Min Altitude: {0}", minAltitude.HasValue ? minAltitude.ToString(ElevationMeasurementSystem) + " @ " + minAltitudeDate.AddHours(UtcShift).ToString("G") : "N/A"));
			sb.AppendLine(String.Format("Max Altitude: {0}", maxAltitude.HasValue ? maxAltitude.ToString(ElevationMeasurementSystem) + " @ " + maxAltitudeDate.AddHours(UtcShift).ToString("G") : "N/A"));
			sb.AppendLine(String.Format("Avg Altitude: {0}", avgAltitude.HasValue ? avgAltitude.ToString(ElevationMeasurementSystem) : "N/A"));
			sb.AppendLine(String.Format("Total Elevation Gain: {0}", gainAltitude.HasValue ? gainAltitude.ToString(ElevationMeasurementSystem) : "N/A"));
			sb.AppendLine(String.Format("Total Elevation Loss: {0}", lossAltitude.HasValue ? lossAltitude.ToString(ElevationMeasurementSystem) : "N/A"));
            //if (maxSlope > 0)
            //    sb.AppendLine(String.Format("Max Incline: {0:##.#}%", (maxSlope * 100)));

			TrackInfoTextBox.Text = sb.ToString();
			TrackInfoTextBox.Select(0,0);
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}