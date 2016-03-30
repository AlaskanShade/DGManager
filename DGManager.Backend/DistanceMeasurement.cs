using System;

namespace DGManager.Backend
{
	public class DistanceMeasurement : MeasurementBase
	{
		protected override string ValueFormatString
		{
			get
			{
				return "{0:0.##}";
			}
		}

		protected override MeasurementSystem StandardSystem
		{
			get
			{
				return MeasurementSystem.Metric;
			}
		}

		public DistanceMeasurement(double value) : base(value)
		{
		}

		public DistanceMeasurement()
		{
		}

		protected override double ConvertSpecificSystemToStandardSystem(double value, MeasurementSystem specificSystem)
		{
			switch (specificSystem)
			{
				case MeasurementSystem.Metric:
					return value * Constants.DISTANCE_FACTOR_METRIC;
				case MeasurementSystem.Imperial:
					return value * Constants.DISTANCE_FACTOR_IMPERIAL;
				case MeasurementSystem.Nautical:
					return value * Constants.DISTANCE_FACTOR_NAUTICAL;
				default:
					return value;
			}
		}

		protected override double ConvertStandardSystemToSpecificSystem(double value, MeasurementSystem specificSystem)
		{
			switch (specificSystem)
			{
				case MeasurementSystem.Metric:
					return value / Constants.DISTANCE_FACTOR_METRIC;
				case MeasurementSystem.Imperial:
					return value / Constants.DISTANCE_FACTOR_IMPERIAL;
				case MeasurementSystem.Nautical:
					return value / Constants.DISTANCE_FACTOR_NAUTICAL;
				default:
					return value;
			}
		}

		protected override string GetStringRepresentationOfSystem(MeasurementSystem system)
		{
			switch (system)
			{
				case MeasurementSystem.Metric:
					return "m";
				case MeasurementSystem.Imperial:
					return "mi";
				case MeasurementSystem.Nautical:
					return "nm";
				default:
					return String.Empty;
			}
		}
	}
}
