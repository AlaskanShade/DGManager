using System;
using System.Drawing;
using Nini.Config;
using System.IO;
using System.Reflection;

namespace DGManager.Backend
{
    public enum ColorFormat { NamedColor, ARGBColor }
    
    public enum UtcShiftType
	{
		None = 0,
		Specified = 1,
		Auto = 2
	}

	public enum GMapType
	{
		Street = 0,
		Satellite = 1,
		Hybrid = 2
	}

	public enum TrackMode
	{
		GlobalSat = 0,
		Logical = 1
	}

	public enum TimespanSign
	{
		Positive = '+',
		Negative = '-'
	}

	public enum MeasurementSystem
	{
		Metric = 0,
		Imperial = 1,
		Nautical = 2
	}
	
	public class Settings
    {
        #region Fields (and default values)
        private static string port = "COM3";
		private static int left = 100;
		private static int top = 100;
		private static int width = 780;
		private static int height = 500;
		private static int tracksListWidth = 215;
		private static int logPanelHeight = 120;
		private static MeasurementSystem speedMeasurementSystem = MeasurementSystem.Metric;
		private static MeasurementSystem distanceMeasurementSystem = MeasurementSystem.Metric;
		private static MeasurementSystem elevationMeasurementSystem = MeasurementSystem.Metric;
		private static UtcShiftType utcShiftType = UtcShiftType.Auto;
		private static int utcShift;
        private static string timeDisplayFormat = String.Empty;
		private static bool fullPrecision = true;
        private static bool gMapsStrictHtml = true;
		private static bool gMapsMapButton = true;
		private static bool gMapsSatelliteButton = true;
		private static bool gMapsHybridButton = true;
		private static bool gMapsTerrainButton = true;
		private static GMapType gMapsDefaultMapType = GMapType.Street;
		private static Color gMapsLineColour = Color.Blue;
		private static int gMapsLineWidth = 3;
		private static int gMapsLineOpacity = 80;
		private static int gMapsDropPointsThreshold = 1000;
		private static double gMapsDropPointsMinDistance = 5;
		private static string gMapsApiKey = Constants.GMAPS_DEFAULT_API_KEY;
        private static string gMapsStartIcon = "http://www.google.com/mapfiles/dd-start.png";
        private static string gMapsEndIcon = "http://www.google.com/mapfiles/dd-end.png";
		private static TrackMode trackMode = TrackMode.Logical;
		private static int newTrackThresholdMins = 10;
		private static bool applyTrackModeWhenLoadingGSD = true;
		private static TimeSpan cameraOffsetTimespan = new TimeSpan(0);
		private static TimespanSign cameraOffsetSign = TimespanSign.Positive;
		private static bool gpxIncludeWaypoints = true;
		private static bool gpxIncludeRoutes = true;
		private static bool gpxIncludeTracks = true;
		private static bool gpxSaveSpeedData = true;
		private static int downloadLatestTracksLastDays = 7;
		private static bool autoCheckNewVersion = true;
		private static int geocodeInterpolationThresholdSecs = 60;
		private static int geocodePlanBThresholdMins = 20;
		private static bool revGeoEnabled = true;
		private static bool revGeoUseGoogleMaps = true;
		private static bool revGeoSetImageDescription = true;
		private static bool revGeoSetXPComment = true;
		private static bool revGeoSetXPKeywords = true;
		private static bool revGeoSetXPSubject = true;
		private static bool revGeoSetUserComment = true;
		private static bool revGeoSetIptcKeywords = true;
		private static bool revGeoSetIptcCaption = true;
		private static string kmlPhotoPathPrefix = String.Empty;
        private static string manualGeocodeLastLocationLat = "56.16757394687361";
        private static string manualGeocodeLastLocationLon = "10.1865792274475";
        private static bool manualGeocodeRememberLastLocation = true;
        #endregion

        // To add new settings to this class, simply create the property and then apply the 'IniConfig' attribute to it.
        // The Load and Save methods will dynamically use these to read and write the file.
        #region Properties
        [IniConfig("Settings")]
		public static string Port
		{
			get { return port; }
			set { port = value; }
		}

        [IniConfig("Display")]
		public static int Left
		{
			get { return left; }
			set { left = value; }
		}

        [IniConfig("Display")]
		public static int Top
		{
			get { return top; }
			set { top = value; }
		}

        [IniConfig("Display")]
		public static int Width
		{
			get { return width; }
			set { width = value; }
		}

        [IniConfig("Display")]
		public static int Height
		{
			get { return height; }
			set { height = value; }
		}

        [IniConfig("Display")]
		public static int TracksListWidth
		{
			get { return tracksListWidth; }
			set { tracksListWidth = value; }
		}

        [IniConfig("Display")]
		public static int LogPanelHeight
		{
			get { return logPanelHeight; }
			set { logPanelHeight = value; }
		}

        [IniConfig("Settings")]
        public static bool IsDebug { get; set; }

        [IniConfig("Settings")]
		public static MeasurementSystem SpeedMeasurementSystem
		{
			get { return speedMeasurementSystem; }
			set { speedMeasurementSystem = value; }
		}

        [IniConfig("Settings")]
		public static MeasurementSystem DistanceMeasurementSystem
		{
			get { return distanceMeasurementSystem; }
			set { distanceMeasurementSystem = value; }
		}

        [IniConfig("Settings")]
		public static MeasurementSystem ElevationMeasurementSystem
		{
			get { return elevationMeasurementSystem; }
			set { elevationMeasurementSystem = value; }
		}

        [IniConfig("Settings")]
		public static UtcShiftType UtcShiftType
		{
			get { return utcShiftType; }
			set { utcShiftType = value; }
		}

        [IniConfig("Settings")]
		public static int UtcShift
		{
			get 
            {
                switch (Settings.UtcShiftType)
                {
                    case UtcShiftType.None:
                        return 0;
                    case UtcShiftType.Specified:
                        return utcShift;
                    case UtcShiftType.Auto:
                        return (int)TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalHours;
                    default:
                        return 0;
                }
            }
			set { utcShift = value; }
		}

        [IniConfig("Settings")]
        public static string TimeDisplayFormat
        {
            get
            {
                if (String.IsNullOrEmpty(timeDisplayFormat)) return "yyyy-MM-dd HH:mm";
                return timeDisplayFormat;
            }
            set { timeDisplayFormat = value; }
        }

        [IniConfig("Settings")]
		public static bool FullPrecision
		{
			get { return fullPrecision; }
			set { fullPrecision = value; }
		}

        [IniConfig("GMaps", "StrictHtml")]
        public static bool GMapsStrictHtml { get { return gMapsStrictHtml; } set { gMapsStrictHtml = value; } }

        [IniConfig("GMaps", "SmallControls")]
        public static bool GMapsSmallControls { get; set; }

        [IniConfig("GMaps", "MapButton")]
		public static bool GMapsMapButton
		{
			get
			{
				return gMapsMapButton;
			}
			set
			{
				gMapsMapButton = value;
			}
		}

        [IniConfig("GMaps", "SatelliteButton")]
		public static bool GMapsSatelliteButton
		{
			get
			{
				return gMapsSatelliteButton;
			}
			set
			{
				gMapsSatelliteButton = value;
			}
		}

        [IniConfig("GMaps", "HybridButton")]
		public static bool GMapsHybridButton
		{
			get
			{
				return gMapsHybridButton;
			}
			set
			{
				gMapsHybridButton = value;
			}
		}

        [IniConfig("GMaps", "TerrainButton")]
		public static bool GMapsTerrainButton
		{
			get
			{
				return gMapsTerrainButton;
			}
			set
			{
				gMapsTerrainButton = value;
			}
		}

        [IniConfig("GMaps", "OverviewMap")]
        public static bool GMapsOverviewMap { get; set; }

        [IniConfig("GMaps", "DefaultMapType")]
		public static GMapType GMapsDefaultMapType
		{
			get
			{
				return gMapsDefaultMapType;
			}
			set
			{
				gMapsDefaultMapType = value;
			}
		}

        [IniConfig("GMaps", "LineColourR", ReadOnly = true), Obsolete("Use GMapsLineColor")]
        public static int GMapsLineColourR
        {
            get { return GMapsLineColour.R; }
            set { GMapsLineColour = Color.FromArgb(value, GMapsLineColour.G, GMapsLineColour.B); }
        }

        [IniConfig("GMaps", "LineColourG", ReadOnly = true), Obsolete("Use GMapsLineColor")]
        public static int GMapsLineColourG
        {
            get { return GMapsLineColour.G; }
            set { GMapsLineColour = Color.FromArgb(GMapsLineColour.R, value, GMapsLineColour.B); }
        }

        [IniConfig("GMaps", "LineColourB", ReadOnly = true), Obsolete("Use GMapsLineColor")]
        public static int GMapsLineColourB
        {
            get { return GMapsLineColour.B; }
            set { GMapsLineColour = Color.FromArgb(GMapsLineColour.R, GMapsLineColour.G, value); }
        }

        [IniConfig("GMaps", "LineColour")]
        public static Color GMapsLineColour
        {
            get
            {
                return gMapsLineColour;
            }
            set
            {
                gMapsLineColour = value;
            }
        }

        [IniConfig("GMaps", "LineWidth")]
		public static int GMapsLineWidth
		{
			get
			{
				return gMapsLineWidth;
			}
			set
			{
				gMapsLineWidth = value;
			}
		}

        [IniConfig("GMaps", "LineOpacity")]
		public static int GMapsLineOpacity
		{
			get
			{
				return gMapsLineOpacity;
			}
			set
			{
				gMapsLineOpacity = value;
			}
		}

        [IniConfig("GMaps", "SpecifyLineColour")]
        public static bool GMapsSpecifyLineColour { get; set; }

        [IniConfig("GMaps", "SpecifyLineWidth")]
        public static bool GMapsSpecifyLineWidth { get; set; }

        [IniConfig("GMaps", "SpecifyLineOpacity")]
        public static bool GMapsSpecifyLineOpacity { get; set; }

        [IniConfig("GMaps", "DropPoints")]
        public static bool GMapsDropPoints { get; set; }

        [IniConfig("GMaps", "DropPointsThreshold")]
		public static int GMapsDropPointsThreshold
		{
			get
			{
				return gMapsDropPointsThreshold;
			}
			set
			{
				gMapsDropPointsThreshold = value;
			}
		}

        [IniConfig("GMaps", "DropPointsMinDistance")]
		public static double GMapsDropPointsMinDistance
		{
			get
			{
				return gMapsDropPointsMinDistance;
			}
			set
			{
				gMapsDropPointsMinDistance = value;
			}
		}

        [IniConfig("GMaps", "DifferentTrackColours")]
        public static bool GMapsDifferentTrackColours { get; set; }

        [IniConfig("GMaps", "ApiKey")]
		public static string GMapsApiKey
		{
			get
			{
				return gMapsApiKey;
			}
			set
			{
				gMapsApiKey = value;
			}
		}

        [IniConfig("GMaps", "DisplayStartIcon")]
        public static bool GMapsDisplayStartIcon { get; set; }

        [IniConfig("GMaps", "StartIconUrl")]
        public static string GMapsStartIcon { get { return gMapsStartIcon; } set { gMapsStartIcon = value; } }

        [IniConfig("GMaps", "DisplayEndIcon")]
        public static bool GMapsDisplayEndIcon { get; set; }

        [IniConfig("GMaps", "EndIconUrl")]
        public static string GMapsEndIcon { get { return gMapsEndIcon; } set { gMapsEndIcon = value; } }

        [IniConfig("Settings")]
		public static TrackMode TrackMode
		{
			get
			{
				return trackMode;
			}
			set
			{
				trackMode = value;
			}
		}

        [IniConfig("Settings")]
		public static int NewTrackThresholdMins
		{
			get
			{
				return newTrackThresholdMins;
			}
			set
			{
				newTrackThresholdMins = value;
			}
		}

        [IniConfig("Settings")]
		public static bool ApplyTrackModeWhenLoadingGSD
		{
			get { return applyTrackModeWhenLoadingGSD; }
			set { applyTrackModeWhenLoadingGSD = value; }
		}

        [IniConfig("Settings")]
        public static bool GuessManualPoints { get; set; }

        [IniConfig("Settings")]
        public static string LastLoadDir { get; set; }

        [IniConfig("Settings")]
        public static string LastPhotoDir { get; set; }

        [IniConfig("Settings")]
        public static string LastSaveDir { get; set; }

        [IniConfig("Settings")]
		public static TimeSpan CameraOffsetTimespan
		{
			get
			{
				return cameraOffsetTimespan;
			}
			set
			{
				cameraOffsetTimespan = value;
			}
		}

        [IniConfig("Settings")]
		public static TimespanSign CameraOffsetSign
		{
			get
			{
				return cameraOffsetSign;
			}
			set
			{
				cameraOffsetSign = value;
			}
		}

        [IniConfig("Settings")]
        public static bool CameraOffsetEnabled { get; set; }

        [IniConfig("Settings")]
		public static bool GpxIncludeWaypoints
		{
			get
			{
				return gpxIncludeWaypoints;
			}
			set
			{
				gpxIncludeWaypoints = value;
			}
		}

        [IniConfig("Settings")]
		public static bool GpxIncludeRoutes
		{
			get
			{
				return gpxIncludeRoutes;
			}
			set
			{
				gpxIncludeRoutes = value;
			}
		}

        [IniConfig("Settings")]
		public static bool GpxIncludeTracks
		{
			get
			{
				return gpxIncludeTracks;
			}
			set
			{
				gpxIncludeTracks = value;
			}
		}

        [IniConfig("Settings")]
		public static bool GpxSaveSpeedData
		{
			get
			{
				return gpxSaveSpeedData;
			}
			set
			{
				gpxSaveSpeedData = value;
			}
		}

        [IniConfig("Settings")]
		public static int DownloadLatestTracksLastDays
		{
			get
			{
				return downloadLatestTracksLastDays;
			}
			set
			{
				downloadLatestTracksLastDays = value;
			}
		}

        [IniConfig("Settings")]
		public static bool AutoCheckNewVersion
		{
			get
			{
				return autoCheckNewVersion;
			}
			set
			{
				autoCheckNewVersion = value;
			}
		}

        [IniConfig("Settings")]
        public static bool SetImageModDateToGeocodeDate { get; set; }

        [IniConfig("Settings")]
		public static int GeocodeInterpolationThresholdSecs
		{
			get
			{
				return geocodeInterpolationThresholdSecs;
			}
			set
			{
				geocodeInterpolationThresholdSecs = value;
			}
		}

        [IniConfig("Settings")]
        public static bool GeocodePlanBThresholdEnabled { get; set; }

        [IniConfig("Settings")]
		public static int GeocodePlanBThresholdMins
		{
			get
			{
				return geocodePlanBThresholdMins;
			}
			set
			{
				geocodePlanBThresholdMins = value;
			}
		}

        [IniConfig("Settings")]
		public static bool RevGeoEnabled
		{
			get
			{
				return revGeoEnabled;
			}
			set
			{
				revGeoEnabled = value;
			}
		}

        [IniConfig("Settings")]
		public static bool RevGeoUseGoogleMaps
		{
			get
			{
				return revGeoUseGoogleMaps;
			}
			set
			{
				revGeoUseGoogleMaps = value;
			}
		}

        [IniConfig("Settings")]
		public static bool RevGeoSetImageDescription
		{
			get
			{
				return revGeoSetImageDescription;
			}
			set
			{
				revGeoSetImageDescription = value;
			}
		}

        [IniConfig("Settings")]
		public static bool RevGeoSetXPComment
		{
			get
			{
				return revGeoSetXPComment;
			}
			set
			{
				revGeoSetXPComment = value;
			}
		}

        [IniConfig("Settings")]
		public static bool RevGeoSetXPKeywords
		{
			get
			{
				return revGeoSetXPKeywords;
			}
			set
			{
				revGeoSetXPKeywords = value;
			}
		}

        [IniConfig("Settings")]
		public static bool RevGeoSetXPSubject
		{
			get
			{
				return revGeoSetXPSubject;
			}
			set
			{
				revGeoSetXPSubject = value;
			}
		}

        [IniConfig("Settings")]
		public static bool RevGeoSetUserComment
		{
			get
			{
				return revGeoSetUserComment;
			}
			set
			{
				revGeoSetUserComment = value;
			}
		}

        [IniConfig("Settings")]
		public static bool RevGeoSetIptcKeywords
		{
			get
			{
				return revGeoSetIptcKeywords;
			}
			set
			{
				revGeoSetIptcKeywords = value;
			}
		}

        [IniConfig("Settings")]
		public static bool RevGeoSetIptcCaption
		{
			get
			{
				return revGeoSetIptcCaption;
			}
			set
			{
				revGeoSetIptcCaption = value;
			}
		}

        [IniConfig("Settings")]
        public static bool KmlUsePhotoPathPrefix { get; set; }

        [IniConfig("Settings")]
		public static string KmlPhotoPathPrefix
		{
			get
			{
				return kmlPhotoPathPrefix;
			}
			set
			{
				kmlPhotoPathPrefix = value;
			}
        }

        [IniConfig("Settings")]
        public static string ManualGeocodeLastLocationLat
        {
            get { return manualGeocodeLastLocationLat; }
            set { manualGeocodeLastLocationLat = value; }
        }

        [IniConfig("Settings")]
        public static string ManualGeocodeLastLocationLon
        {
            get { return manualGeocodeLastLocationLon; }
            set { manualGeocodeLastLocationLon = value; }
        }

        [IniConfig("Settings")]
        public static bool ManualGeocodeRememberLastLocation
        {
            get { return manualGeocodeRememberLastLocation; }
            set { manualGeocodeRememberLastLocation = value; }
        }
        #endregion

        public static void LoadSettings(string path)
        {
            if (!File.Exists(Path.Combine(path, Constants.CONFIG_FILENAME))) return;
            IConfigSource ini = new IniConfigSource(Path.Combine(path, Constants.CONFIG_FILENAME));
            Array.ForEach(typeof(Settings).GetProperties(), pi =>
            {
                object[] att = pi.GetCustomAttributes(typeof(IniConfigAttribute), true);
                if (att.Length > 0)
                {
                    IniConfigAttribute iniAt = att[0] as IniConfigAttribute;
                    IConfig config = ini.Configs[iniAt.Category];
                    if (config != null)
                    {
                        string iniName = (String.IsNullOrEmpty(iniAt.Name) ? pi.Name : iniAt.Name);
                        if (config.Contains(iniName))
                            if (pi.PropertyType == typeof(int))
                                pi.SetValue(null, config.GetInt(iniName), null);
                            else if (pi.PropertyType == typeof(double))
                                pi.SetValue(null, config.GetDouble(iniName), null);
                            else if (pi.PropertyType == typeof(bool))
                                pi.SetValue(null, config.GetBoolean(iniName), null);
                            else if (pi.PropertyType == typeof(string))
                                pi.SetValue(null, config.Get(iniName), null);
                            else if (pi.PropertyType == typeof(Color))
                                pi.SetValue(null, DeserializeColor(config.GetString(iniName)), null);
                            else if (pi.PropertyType.IsEnum)
                            {
                                string sVal = config.GetString(iniName);
                                int iVal;
                                if (int.TryParse(sVal, out iVal))
                                    pi.SetValue(null, iVal, null);
                                else if (sVal.Length == 1)
                                    pi.SetValue(null, (int)sVal[0], null);
                                else if (sVal.Length > 0)
                                    pi.SetValue(null, Enum.Parse(pi.PropertyType, sVal), null);
                            }
                    }
                }
            });
        }

        public static void SaveSettings(string path)
        {
            IniConfigSource ini = new IniConfigSource();
            foreach (PropertyInfo pi in typeof(Settings).GetProperties())
            {
                object[] att = pi.GetCustomAttributes(typeof(IniConfigAttribute), true);
                if (att.Length > 0)
                {
                    IniConfigAttribute iniAt = att[0] as IniConfigAttribute;
                    if (iniAt.ReadOnly) continue;
                    IConfig config = ini.Configs[iniAt.Category];
                    if (config == null)
                        config = ini.AddConfig(iniAt.Category);
                    string iniName = (String.IsNullOrEmpty(iniAt.Name) ? pi.Name : iniAt.Name);
                    object val = pi.GetValue(null, null);
                    if (val != null)
                    {
                        if (pi.PropertyType.IsEnum)
                        {
                            if (iniAt.IsNumericEnum)
                                config.Set(iniName, (int)val);
                            else
                                config.Set(iniName, val.ToString());
                        }
                        else if (pi.PropertyType == typeof(Color))
                            config.Set(iniName, SerializeColor((Color)val));
                        else
                            config.Set(iniName, val);
                    }
                }
            }

            using (FileStream iniFileStream = new FileStream(Path.Combine(path, Constants.CONFIG_FILENAME), FileMode.Create, FileAccess.Write))
            {
                ini.Save(iniFileStream);
                iniFileStream.Close();
            }
        }

        public static string SerializeColor(Color color)
        {
            if (color.IsNamedColor)
                return string.Format("{0}:{1}",
                    ColorFormat.NamedColor, color.Name);
            return string.Format("{0}:{1}:{2}:{3}",
                ColorFormat.ARGBColor,
                color.R, color.G, color.B);
        }

        public static Color DeserializeColor(string color)
        {
            byte r, g, b;

            string[] pieces = color.Split(new char[] { ':' });

            ColorFormat colorType = (ColorFormat)
                Enum.Parse(typeof(ColorFormat), pieces[0], true);

            switch (colorType)
            {
                case ColorFormat.NamedColor:
                    return Color.FromName(pieces[1]);

                case ColorFormat.ARGBColor:
                    r = byte.Parse(pieces[1]);
                    g = byte.Parse(pieces[2]);
                    b = byte.Parse(pieces[3]);

                    return Color.FromArgb(255, r, g, b);
            }
            return Color.Empty;
        }
    }

    public class IniConfigAttribute : Attribute
    {

        /// <summary>
        /// The category that this setting is found under
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// The key name of this setting
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// If true, the value will be read/written as a numeric value.  Otherwise it will be a character value.
        /// </summary>
        public bool IsNumericEnum { get; set; }
        /// <summary>
        /// If true, this setting will be read from the file, but not written back.  Useful for legacy entries.
        /// </summary>
        public bool ReadOnly { get; set; }

        public IniConfigAttribute(string category)
        {
            Category = category;
        }

        public IniConfigAttribute(string category, string name) : this(category)
        {
            Name = name;
        }
    }
    /*
    [XmlType]
    public class DGManagerConfig
    {
        private string _port;
        private WindowState _position;
        private bool _isDebug;
        private MeasurementSystem _speedMeasurementSystem;
        private MeasurementSystem _distanceMeasurementSystem;
        private MeasurementSystem _elevationMeasurementSystem;
        private UtcShiftType _utcShiftType;
        private int _utcShift;
        private string _timeDisplayFormat;
        private bool _fullPrecision;
        // v These do not yet have properties v //
        private TrackMode _trackMode;
        private int _newTrackThreshold;
        private bool _applyTrackModeWhenLoadingGSD;
        private bool _guessManualPoints;
        private string _lastLoadDir;
        private string _lastPhotoDir;
        private string _lastSaveDir;
        private TimeSpan _cameraOffset;
        private TimespanSign _cameraOffsetSign;
        private bool _cameraOffsetEnabled;
        private bool _gpxIncludeWaypoints;
        private bool _gpxIncludeRoutes;
        private bool _gpxIncludeTracks;
        private bool _gpxSaveSpeedData;
        private int _downloadLatestTracksLastDays;
        private bool _autoCheckNewVersion;
        private bool _setImageModDateToGeocodeDate;
        // ^ These do not have properties ^ //

        public string Port { get { return _port; } set { _port = value; } }
        public WindowState WindowPosition { get { return _position; } set { _position = value; } }
        public bool IsDebug { get { return _isDebug; } set { _isDebug = value; } }
        public MeasurementSystem SpeedMeasurementSystem { get { return _speedMeasurementSystem; } set { _speedMeasurementSystem = value; } }
        public MeasurementSystem DistanceMeasurementSystem { get { return _distanceMeasurementSystem; } set { _distanceMeasurementSystem = value; } }
        public MeasurementSystem ElevationMeasurementSystem { get { return _elevationMeasurementSystem; } set { _elevationMeasurementSystem = value; } }
        public UtcShiftType UtcShiftType { get { return _utcShiftType; } set { _utcShiftType = value; } }
        public int UtcShift { get { return _utcShift; } set { _utcShift = value; } }
        public string TimeDisplayFormat { get { return _timeDisplayFormat; } set { _timeDisplayFormat = value; } }
        public bool FullPrecision { get { return _fullPrecision; } set { _fullPrecision = value; } }
    }

    [XmlType]
    public class WindowState
    {
        private int _left;
        private int _top;
        private int _width;
        private int _height;
        private int _tracksListWidth;
        private int _logPanelHeight;

        [XmlAttribute]
        public int Left { get { return _left; } set { _left = value; } }
        [XmlAttribute]
        public int Top { get { return _top; } set { _top = value; } }
        [XmlAttribute]
        public int Width { get { return _width; } set { _width = value; } }
        [XmlAttribute]
        public int Height { get { return _height; } set { _height = value; } }
        public int TracksListWidth { get { return _tracksListWidth; } set { _tracksListWidth = value; } }
        public int LogPanelHeight { get { return _logPanelHeight; } set { _logPanelHeight = value; } }

        public WindowState() { }

        public WindowState(int top, int left, int width, int height)
        {
            _top = top;
            _left = left;
            _width = width;
            _height = height;
        }

        public WindowState(Rectangle bounds) : this(bounds.Top, bounds.Left, bounds.Width, bounds.Height)
        {
        }
    }

    [XmlType]
    public class GMapsConfig
    {
        private GMapsInterfaceConfig _controls;
        private GMapsLineConfig _lineConfig;
        private bool _dropPoints;
        private int _dropPointsThreshold;
        private double _dropPointsMinDistance;
        private string _apiKey;

        public GMapsInterfaceConfig InterfaceConfig { get { return _controls; } set { _controls = value; } }
        public GMapsLineConfig LineConfig { get { return _lineConfig; } set { _lineConfig = value; } }
        public bool DropPoints { get { return _dropPoints; } set { _dropPoints = value; } }
        public int DropPointsThreshold { get { return _dropPointsThreshold; } set { _dropPointsThreshold = value; } }
        public double DropPointsMinDistance { get { return _dropPointsMinDistance; } set { _dropPointsMinDistance = value; } }
        public string ApiKey { get { return _apiKey; } set { _apiKey = value; } }

        public GMapsConfig()
        {
            _controls = new GMapsInterfaceConfig();
            _lineConfig = new GMapsLineConfig();
        }

        [XmlType]
        public class GMapsInterfaceConfig
        {
            private bool _smallControls;
            private bool _mapButton;
            private bool _satelliteButton;
            private bool _hybridButton;
            private bool _terrainButton;
            private bool _overviewMap;
            private GMapType _defaultMapType;

            [XmlAttribute]
            public bool SmallControls { get { return _smallControls; } set { _smallControls = value; } }
            [XmlAttribute]
            public bool MapButton { get { return _mapButton; } set { _mapButton = value; } }
            [XmlAttribute]
            public bool SatelliteButton { get { return _satelliteButton; } set { _satelliteButton = value; } }
            [XmlAttribute]
            public bool HybridButton { get { return _hybridButton; } set { _hybridButton = value; } }
            [XmlAttribute]
            public bool TerrainButton { get { return _terrainButton; } set { _terrainButton = value; } }
            [XmlAttribute]
            public bool OverviewMap { get { return _overviewMap; } set { _overviewMap = value; } }
            [XmlAttribute]
            public GMapType DefaultMapType { get { return _defaultMapType; } set { _defaultMapType = value; } }
        }

        [XmlType]
        public class GMapsLineConfig
        {
            private bool _specifyLineColor;
            private Color _lineColor;
            private bool _specifyLineWidth;
            private int _lineWidth;
            private bool _specifyLineOpacity;
            private int _lineOpacity;
            private bool _differentTrackColors;
            private bool _displayStart;
            private string _startIcon;
            private bool _displayEnd;
            private string _endIcon;

            [XmlAttribute]
            public bool SpecifyLineColor { get { return _specifyLineColor; } set { _specifyLineColor = value; } }
            [XmlIgnore]
            public Color LineColor { get { return _lineColor; } set { _lineColor = value; } }
            [XmlAttribute]
            public string XmlLineColor { get { return Settings.SerializeColor(_lineColor); } set { _lineColor = Settings.DeserializeColor(value); } }
            [XmlAttribute]
            public bool DifferentTrackColors { get { return _differentTrackColors; } set { _differentTrackColors = value; } }
            [XmlAttribute]
            public bool SpecifyLineWidth { get { return _specifyLineWidth; } set { _specifyLineWidth = value; } }
            [XmlAttribute]
            public int LineWidth { get { return _lineWidth; } set { _lineWidth = value; } }
            [XmlAttribute]
            public bool SpecifyLineOpacity { get { return _specifyLineOpacity; } set { _specifyLineOpacity = value; } }
            [XmlAttribute]
            public int LineOpacity { get { return _lineOpacity; } set { _lineOpacity = value; } }
            [XmlAttribute]
            public bool DisplayStartIcon { get { return _displayStart; } set { _displayStart = value; } }
            [XmlAttribute]
            public string StartIcon { get { return _startIcon; } set { _startIcon = value; } }
            [XmlAttribute]
            public bool DisplayEndIcon { get { return _displayEnd; } set { _displayEnd = value; } }
            [XmlAttribute]
            public string EndIcon { get { return _endIcon; } set { _endIcon = value; } }
        }
    }
    */
}
