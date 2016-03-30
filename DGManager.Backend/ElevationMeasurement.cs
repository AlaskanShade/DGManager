using System;

namespace DGManager.Backend
{
    public class ElevationMeasurement : MeasurementBase
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

        public ElevationMeasurement(double value)
            : base(value)
        {
        }

        public ElevationMeasurement()
        {
        }

        protected override double ConvertSpecificSystemToStandardSystem(double value, MeasurementSystem specificSystem)
        {
            switch (specificSystem)
            {
                case MeasurementSystem.Metric:
                    return value;
                case MeasurementSystem.Imperial:
                    return value * Constants.ELEVATION_FACTOR_IMPERIAL;
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
                    return value / Constants.ELEVATION_FACTOR_IMPERIAL;
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
                    return "ft";
                case MeasurementSystem.Nautical:
                    return "nm";
                default:
                    return String.Empty;
            }
        }
    }
}
