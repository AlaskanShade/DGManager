using System;

namespace DGManager.Backend
{
	public class Support
	{
		// Returns True if a sentence's checksum matches the 
		// calculated checksum
		public static bool IsValidNmeaSentence(string sentence)
		{
			// Compare the characters after the asterisk to the calculation
			return sentence.Substring(sentence.IndexOf("*") + 1) ==
			  GetNmeaChecksum(sentence);
		}

		// Calculates the checksum for a sentence
		public static string GetNmeaChecksum(string sentence)
		{
			// Loop through all chars to get a checksum
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

		public static void DecimalDegreesToDMS(double decimalDegrees, out double degrees, out double minutes, out double seconds)
		{
			degrees = Math.Truncate(decimalDegrees);
			double minutesAndSeconds = Math.Abs((decimalDegrees - degrees) * 60);
			minutes = Math.Truncate(minutesAndSeconds);
			seconds = (minutesAndSeconds - minutes) * 60;
		}

		public static void DecimalDegreesToDM(double decimalDegrees, out double degrees, out double minutes)
		{
			degrees = Math.Truncate(decimalDegrees);
			minutes = Math.Abs((decimalDegrees - degrees) * 60);
		}

		public static double DMSToDecimalDegrees(int degrees, double minutes, double seconds)
		{
			return degrees + (minutes/60) + (seconds/3600);
		}

		public static double DegreesToRadians(double degrees)
		{
			return (Math.PI * degrees) / 180;
		} 

		public static double RadiansToDegrees(double radians)
		{
			return (radians * 180) / Math.PI;
		}

		public static double RadiansToBearing(double radians)
		{
			return (RadiansToDegrees(radians) + 360) % 360;
		}

		public static double BearingBetweenPoints(double lat1, double lon1, double lat2, double lon2)
		{
			lat1 = DegreesToRadians(lat1);
			lat2 = DegreesToRadians(lat2);
			double lonDiff = DegreesToRadians(lon2-lon1);

			return RadiansToBearing(Math.Atan2(Math.Sin(lonDiff) * Math.Cos(lat2), Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(lonDiff)));
		}

		public static double DistanceBetweenPoints(double lat1, double lon1, double lat2, double lon2)
		{
			double dLat = DegreesToRadians(lat2 - lat1);
			double dLon = DegreesToRadians(lon2 - lon1);
			double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
					  Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
					  Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
			double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
			return 6371000 * c;
		}
	}
}
