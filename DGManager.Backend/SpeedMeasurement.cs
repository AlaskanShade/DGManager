using System;

namespace DGManager.Backend
{
	public class SpeedMeasurement : MeasurementBase
	{
		protected override string ValueFormatString
		{
			get
			{
				return "{0:0.00}";
			}
		}

		protected override MeasurementSystem StandardSystem
		{
			get
			{
				return MeasurementSystem.Metric;
			}
		}

		public SpeedMeasurement(double value) : base(value)
		{
		}

		public SpeedMeasurement()
		{
		}

		protected override double ConvertSpecificSystemToStandardSystem(double value, MeasurementSystem specificSystem)
		{
			switch (specificSystem)
			{
				case MeasurementSystem.Metric:
					return value;
				case MeasurementSystem.Imperial:
					return value * Constants.SPEED_FACTOR_IMPERIAL;
				case MeasurementSystem.Nautical:
					return value * Constants.SPEED_FACTOR_NAUTICAL;
				default:
					return value;
			}
		}

		protected override double ConvertStandardSystemToSpecificSystem(double value, MeasurementSystem specificSystem)
		{
			switch (specificSystem)
			{
				case MeasurementSystem.Metric:
					return value;
				case MeasurementSystem.Imperial:
					return value / Constants.SPEED_FACTOR_IMPERIAL;
				case MeasurementSystem.Nautical:
					return value / Constants.SPEED_FACTOR_NAUTICAL;
				default:
					return value;
			}
		}

		protected override string GetStringRepresentationOfSystem(MeasurementSystem system)
		{
			switch (system)
			{
				case MeasurementSystem.Metric:
					return "km/h";
				case MeasurementSystem.Imperial:
					return "mi/h";
				case MeasurementSystem.Nautical:
					return "kt";
				default:
					return String.Empty;
			}
		}
	}
}
