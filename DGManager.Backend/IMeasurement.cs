using System;

namespace DGManager.Backend
{
	public interface IMeasurement
	{
		bool HasValue { get;}
		double GetValue();
		double GetValue(double defaultValue);
		double GetValue(MeasurementSystem system);
		double GetValue(MeasurementSystem system, double defaultValue);
		void SetValue(double value);
		void SetValue(double value, MeasurementSystem system);
		string ToString(MeasurementSystem system);
		string ToString(MeasurementSystem system, double? defaultValue);
	}
}
