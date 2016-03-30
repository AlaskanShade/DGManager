using System;
using System.Globalization;

namespace DGManager.Backend
{
	public abstract class MeasurementBase : IMeasurement
	{
		private double? value;

		protected abstract string ValueFormatString { get; }

		protected abstract MeasurementSystem StandardSystem { get; }

		public bool HasValue
		{
			get
			{
				return value.HasValue;
			}
		}

		public MeasurementBase()
		{
		}

		public MeasurementBase(double value)
		{
			this.value = value;
		}

		public double GetValue()
		{
			return GetValue(StandardSystem);
		}

		public double GetValue(double defaultValue)
		{
			return GetValue(StandardSystem, defaultValue);
		}

		public double GetValue(MeasurementSystem system)
		{
			if (value.HasValue)
			{
				return ConvertStandardSystemToSpecificSystem(value.Value, system);
			}
			else
			{
				throw new InvalidOperationException("Value is null");
			}
		}

		public double GetValue(MeasurementSystem system, double defaultValue)
		{
			if (value.HasValue)
			{
				return GetValue(system);
			}
			else
			{
				return defaultValue;
			}
		}

		public void SetValue(double newValue)
		{
			SetValue(newValue, StandardSystem);
		}

		public void SetValue(double newValue, MeasurementSystem system)
		{
			value = ConvertSpecificSystemToStandardSystem(newValue, system);
		}

		public string ToString(MeasurementSystem system)
		{
			return String.Format(CultureInfo.InvariantCulture, ValueFormatString + " {1}", GetValue(system), GetStringRepresentationOfSystem(system));
		}

		public string ToString(MeasurementSystem system, double? defaultValue)
		{
			if (HasValue || (!HasValue && defaultValue.HasValue))
			{
                return String.Format(CultureInfo.InvariantCulture, ValueFormatString + " {1}", GetValue(system, defaultValue ?? -1),
					              GetStringRepresentationOfSystem(system));
			}
			else
			{
				return null;
			}
		}

		protected abstract double ConvertSpecificSystemToStandardSystem(double value, MeasurementSystem specificSystem);

		protected abstract double ConvertStandardSystemToSpecificSystem(double value, MeasurementSystem specificSystem);

		protected abstract string GetStringRepresentationOfSystem(MeasurementSystem system);
	}
}
