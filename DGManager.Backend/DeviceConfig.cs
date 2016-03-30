using System;

namespace DGManager.Backend
{
	public struct DeviceConfig
	{

	    public enum LogFormatType
	    {
		    Pos = 0,
		    PosDateSpeed = 1,
		    PosDateSpeedAltitude = 2,
		    Invalid = 255
	    }

        public LogFormatType LogFormat { get; set; }

        public bool SpeedThresholdEnabled { get; set; }

        public int SpeedThreshold { get; set; }

        public bool DistanceThresholdEnabled { get; set; }

        public int DistanceThreshold { get; set; }

        public bool ModeAIsByDistance { get; set; }

        public bool ModeBIsByDistance { get; set; }

        public bool ModeCIsByDistance { get; set; }

        public int ModeATimeInterval { get; set; }

        public int ModeBTimeInterval { get; set; }

        public int ModeCTimeInterval { get; set; }

        public int ModeADistanceInterval { get; set; }

        public int ModeBDistanceInterval { get; set; }

        public int ModeCDistanceInterval { get; set; }

        public int MemoryUsage { get; set; }
	}
}
