using System;
using System.Drawing;

namespace DGManager.Backend
{
	public static class ColorGenerator
	{
	    public enum SuitableColor
	    {
		    MediumPurple, RoyalBlue, Navy, Red, MidnightBlue, Purple,
		    MediumBlue, Yellow, DarkBlue, Green, Crimson, Blue,
		    DarkRed, Lavender, IndianRed, DodgerBlue, Tomato, Orange
	    }

		public static Color GetColorForTrack(int trackIndex)
		{
			Array colorsArray = Enum.GetValues(typeof(SuitableColor));

			return Color.FromName(((SuitableColor)(trackIndex % (colorsArray.Length - 1))).ToString());
		}
	}
}
