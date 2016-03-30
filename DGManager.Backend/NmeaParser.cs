using System;
using System.Globalization;

namespace DGManager.Backend
{
	//************************************************************************************
	//**  A high-precision NMEA interpreter
	//**  Adapted from code written by Jon Person, author of "GPS.NET" (www.gpsdotnet.com)
	//************************************************************************************
	public static class NmeaParser
	{
		// Processes information from the GPS receiver
		public static PointOfInterest Parse(string sentence)
		{
			// Discard the sentence if its checksum does not match our calculated checksum
			if (!IsValid(sentence))
			{
				return null;
			}

			// Look at the first word to decide where to go next
			switch (GetWords(sentence)[0])
			{
				case "$GPRMC":
					// A "Recommended Minimum" sentence was found!
					return ParseGPRMC(sentence);
				case "$GPGGA":
					// An "essential fix data" sentence was received
					return ParseGPGGA(sentence);
				default:
					// Indicate that the sentence was not recognized
					return null;
			}
		}

		// Divides a sentence into individual words
		private static string[] GetWords(string sentence)
		{
			return sentence.Split(',');
		}

		// Interprets a $GPRMC message
		private static PointOfInterest ParseGPRMC(string sentence)
		{
            PointOfInterest poi = new PointOfInterest { TypePoi = 0 };
			
			// Divide the sentence into words
			string[] Words = GetWords(sentence);
			// Do we have enough values to describe our location?
			if (!String.IsNullOrEmpty(Words[3]) && !String.IsNullOrEmpty(Words[4]) && !String.IsNullOrEmpty(Words[5]) && !String.IsNullOrEmpty(Words[6]))
			{
				int degrees = Convert.ToInt32(Words[3].Substring(0, 2));
				double minutes = Convert.ToDouble(Words[3].Substring(2), CultureInfo.InvariantCulture);
				poi.Latitude = Support.DMSToDecimalDegrees(degrees, minutes, 0);
				
				if (Words[4].ToUpper() == "S")
				{
					poi.Latitude *= -1;
				}

				degrees = Convert.ToInt32(Words[5].Substring(0, 3));
				minutes = Convert.ToDouble(Words[5].Substring(3), CultureInfo.InvariantCulture);
				poi.Longitude = Support.DMSToDecimalDegrees(degrees, minutes, 0);

				if (Words[6].ToUpper() == "W")
				{
					poi.Longitude *= -1;
				}
			}
			// Do we have enough values to parse satellite-derived time?
			if (!String.IsNullOrEmpty(Words[1]) && !String.IsNullOrEmpty(Words[9]))
			{
				// Yes. Extract hours, minutes, seconds and milliseconds
				int UtcHours = Convert.ToInt32(Words[1].Substring(0, 2));
				int UtcMinutes = Convert.ToInt32(Words[1].Substring(2, 2));
				int UtcSeconds = Convert.ToInt32(Words[1].Substring(4, 2));
				int UtcMilliseconds = 0;
				// Extract milliseconds if it is available
				if (Words[1].Length > 7)
				{
					UtcMilliseconds = Convert.ToInt32(Words[1].Substring(7));
				}
				int UtcDay = Convert.ToInt32(Words[9].Substring(0, 2));
				int UtcMonth = Convert.ToInt32(Words[9].Substring(2, 2));
				int UtcYear = Convert.ToInt32(DateTime.Today.Year.ToString().Substring(0, 2)) * 100 + Convert.ToInt32(Words[9].Substring(4, 2));

				DateTime SatelliteTime = new DateTime(UtcYear, UtcMonth, UtcDay, UtcHours, UtcMinutes, UtcSeconds, UtcMilliseconds);
				// Notify of the new time, adjusted to the local time zone
				poi.When = SatelliteTime;
				poi.TypePoi = 1;
			}

			poi.Speed = new SpeedMeasurement();
			// Do we have enough information to extract the current speed?
			if (!String.IsNullOrEmpty(Words[7]))
			{
				// Yes.
				poi.Speed.SetValue(double.Parse(Words[7], CultureInfo.InvariantCulture), MeasurementSystem.Nautical);
			}
			// Do we have enough information to extract bearing?
            //if (!String.IsNullOrEmpty(Words[8]))
            //{
            //    // Indicate that the sentence was recognized
            //    double Bearing = double.Parse(Words[8], CultureInfo.InvariantCulture);
            //}

			poi.Altitude = new ElevationMeasurement();

			return poi;
		}

		private static PointOfInterest ParseGPGGA(string sentence)
		{
            PointOfInterest poi = new PointOfInterest { TypePoi = 0 };

			// Divide the sentence into words
			string[] Words = GetWords(sentence);
			// Do we have enough values to describe our location?
			if (!String.IsNullOrEmpty(Words[2]) && !String.IsNullOrEmpty(Words[3]) && !String.IsNullOrEmpty(Words[4]) && !String.IsNullOrEmpty(Words[5]))
			{
				int degrees = Convert.ToInt32(Words[2].Substring(0, 2));
				double minutes = Convert.ToDouble(Words[2].Substring(2), CultureInfo.InvariantCulture);
				poi.Latitude = Support.DMSToDecimalDegrees(degrees, minutes, 0);

				if (Words[3].ToUpper() == "S")
				{
					poi.Latitude *= -1;
				}

				degrees = Convert.ToInt32(Words[4].Substring(0, 3));
				minutes = Convert.ToDouble(Words[4].Substring(3), CultureInfo.InvariantCulture);
				poi.Longitude = Support.DMSToDecimalDegrees(degrees, minutes, 0);

				if (Words[5].ToUpper() == "W")
				{
					poi.Longitude *= -1;
				}
			}
			// Do we have enough values to parse satellite-derived time?
			if (Words[1] != "")
			{
				// Yes. Extract hours, minutes, seconds and milliseconds
				int UtcHours = Convert.ToInt32(Words[1].Substring(0, 2));
				int UtcMinutes = Convert.ToInt32(Words[1].Substring(2, 2));
				int UtcSeconds = Convert.ToInt32(Words[1].Substring(4, 2));
				int UtcMilliseconds = 0;
				// Extract milliseconds if it is available
				if (Words[1].Length > 7)
				{
					UtcMilliseconds = Convert.ToInt32(Words[1].Substring(7));
				}
				DateTime UtcToday = DateTime.Today.ToUniversalTime();

				DateTime SatelliteTime = new DateTime(UtcToday.Year, UtcToday.Month, UtcToday.Day, UtcHours, UtcMinutes, UtcSeconds, UtcMilliseconds);
				// Notify of the new time, adjusted to the local time zone
				poi.When = SatelliteTime;
				poi.TypePoi = 1;
			}

			poi.Speed = new SpeedMeasurement();
			poi.Altitude = new ElevationMeasurement();
			// Do we have enough information to extract the current altitude?
			if (Words[9] != "")
			{
				// Yes.
				poi.Altitude.SetValue(double.Parse(Words[9], CultureInfo.InvariantCulture), MeasurementSystem.Metric);
				poi.TypePoi = 2;
			}

			return poi;
		}

		// Returns True if a sentence's checksum matches the calculated checksum
		private static bool IsValid(string sentence)
		{
			// Compare the characters after the asterisk to the calculation
			return !sentence.Contains("*") || sentence.Substring(sentence.IndexOf("*") + 1) == GetChecksum(sentence);
		}

		// Calculates the checksum for a sentence
		private static string GetChecksum(string sentence)
		{
			// Loop through all chars to get a checksum
			//INSTANT C# NOTE: Commented this declaration since looping variables in 'foreach' loops are declared in the 'foreach' header in C#
			//        char Character = '\0';
			int Checksum = 0;
			foreach (char Character in sentence)
			{
				if (Character == '$')
				{
					// Ignore the dollar sign
				}
				else if (Character == '*')
				{
					// Stop processing before the asterisk
					break;
				}
				else
				{
					// Is this the first value for the checksum?
					if (Checksum == 0)
					{
						// Yes. Set the checksum to the value
						Checksum = Convert.ToByte(Character);
					}
					else
					{
						// No. XOR the checksum with this character's value
						Checksum = Checksum ^ Convert.ToByte(Character);
					}
				}
			}
			// Return the checksum formatted as a two-character hexadecimal
			return Checksum.ToString("X2");
		}
	}

}
