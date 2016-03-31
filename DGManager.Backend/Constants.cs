using System;
using System.Text;

namespace DGManager.Backend
{
	public class Constants
	{
		public static string GSD_TRACKS_CATEGORY = "TP";
		public static string GSD_DATE_CATEGORY = "DATE";
		public static string CONFIG_FILENAME = "dgmanager.ini";
		public static string LOG_FILENAME = "dgmanager-log.txt";
		public static string GMAPS_FILENAME = "GoogleMaps.htm";

        //public static string INI_PORT = "Port";
        //public static string INI_LEFT = "Left";
        //public static string INI_TOP = "Top";
        //public static string INI_WIDTH = "Width";
        //public static string INI_HEIGHT = "Height";
        //public static string INI_TRACKSLISTWIDTH = "TracksListWidth";
        //public static string INI_LOGPANELHEIGHT = "LogPanelHeight";
        //public static string INI_ISDEBUG = "IsDebug";
        //public static string INI_SPEEDMEASUREMENTSYSTEM = "SpeedMeasurementSystem";
        //public static string INI_DISTANCEMEASUREMENTSYSTEM = "DistanceMeasurementSystem";
        //public static string INI_ELEVATIONMEASUREMENTSYSTEM = "ElevationMeasurementSystem";
        //public static string INI_UTCSHIFTTYPE = "UtcShiftType";
        //public static string INI_UTCSHIFT = "UtcShift";
        //public static string INI_TIMEFORMAT = "TimeDisplayFormat";
        //public static string INI_FULLPRECISION = "FullPrecision";
        //public static string INI_SMALLCONTROLS = "SmallControls";
        //public static string INI_MAPBUTTON = "MapButton";
        //public static string INI_SATELLITEBUTTON = "SatelliteButton";
        //public static string INI_HYBRIDBUTTON = "HybridButton";
        //public static string INI_TERRAINBUTTON = "TerrainButton";
        //public static string INI_OVERVIEWMAP = "OverviewMap";
        //public static string INI_DEFAULTMAPTYPE = "DefaultMapType";
        //public static string INI_LINECOLORR = "LineColorR";
        //public static string INI_LINECOLORG = "LineColorG";
        //public static string INI_LINECOLORB = "LineColorB";
        //public static string INI_LINEWIDTH = "LineWidth";
        //public static string INI_LINEOPACITY = "LineOpacity";
        //public static string INI_SPECIFYLINECOLOR = "SpecifyLineColor";
        //public static string INI_SPECIFYLINEWIDTH = "SpecifyLineWidth";
        //public static string INI_SPECIFYLINEOPACITY = "SpecifyLineOpacity";
        //public static string INI_DIFFERENTTRACKCOLORS = "DifferentTrackColors";
        //public static string INI_DROPPOINTS = "DropPoints";
        //public static string INI_DROPPOINTSTHRESHOLD = "DropPointsThreshold";
        //public static string INI_DROPPOINTSMINDISTANCE = "DropPointsMinDistance";
        //public static string INI_GMAPS_DISPLAY_START_ICON = "DisplayStartIcon";
        //public static string INI_GMAPS_DISPLAY_END_ICON = "DisplayEndIcon";
        //public static string INI_GMAPS_START_ICON_URL = "StartIconUrl";
        //public static string INI_GMAPS_END_ICON_URL = "EndIconUrl";
        //public static string INI_APIKEY = "ApiKey";
        //public static string INI_TRACKMODE = "TrackMode";
        //public static string INI_NEWTRACKTHRESHOLDMINS = "NewTrackThresholdMins";
        //public static string INI_APPLYTRACKMODEWHENLOADINGGSD = "ApplyTrackModeWhenLoadingGSD";
        //public static string INI_GUESSMANUALPOINTS = "GuessManualPoints";
        //public static string INI_LASTLOADDIR = "LastLoadDir";
        //public static string INI_LASTPHOTODIR = "LastPhotoDir";
        //public static string INI_LASTSAVEDIR = "LastSaveDir";
        //public static string INI_CAMERAOFFSETENABLED = "CameraOffsetEnabled";
        //public static string INI_CAMERAOFFSETTIMESPAN = "CameraOffsetTimespan";
        //public static string INI_CAMERAOFFSETSIGN = "CameraOffsetSign";
        //public static string INI_GPXINCLUDEWAYPOINTS = "GpxIncludeWaypoints";
        //public static string INI_GPXINCLUDEROUTES = "GpxIncludeRoutes";
        //public static string INI_GPXINCLUDETRACKS = "GpxIncludeTracks";
        //public static string INI_GPXSAVESPEEDDATA = "GpxSaveSpeedData";
        //public static string INI_DOWNLOADLATESTTRACKSLASTDAYS = "DownloadLatestTracksLastDays";
        //public static string INI_AUTOCHECKNEWVERSION = "AutoCheckNewVersion";
        //public static string INI_SETIMAGEMODDATETOGEOCODEDATE = "SetImageModDateToGeocodeDate";
        //public static string INI_GEOCODEINTERPOLATIONTHRESHOLDSECS = "GeocodeInterpolationThresholdSecs";
        //public static string INI_GEOCODEPLANBTHRESHOLDENABLED = "GeocodePlanBThresholdEnabled";
        //public static string INI_GEOCODEPLANBTHRESHOLDMINS = "GeocodePlanBThresholdMins";
        //public static string INI_REVGEOENABLED = "RevGeoEnabled";
        //public static string INI_REVGEOUSEGOOGLEMAPS = "RevGeoUseGoogleMaps";
        //public static string INI_REVGEOSETIMAGEDESCRIPTION = "RevGeoSetImageDescription";
        //public static string INI_REVGEOSETXPCOMMENT = "RevGeoSetXPComment";
        //public static string INI_REVGEOSETXPKEYWORDS = "RevGeoSetXPKeywords";
        //public static string INI_REVGEOSETXPSUBJECT = "RevGeoSetXPSubject";
        //public static string INI_REVGEOSETUSERCOMMENT = "RevGeoSetUserComment";
        //public static string INI_REVGEOSETIPTCKEYWORDS = "RevGeoSetIptcKeywords";
        //public static string INI_REVGEOSETIPTCCAPTION = "RevGeoSetIptcCaption";
        //public static string INI_KMLUSEPHOTOPATHPREFIX = "KmlUsePhotoPathPrefix";
        //public static string INI_KMLPHOTOPATHPREFIX = "KmlPhotoPathPrefix";
        //public static string INI_MANUALGEOCODELASTLOCATIONLAT = "ManualGeocodeLastLocationLat";
        //public static string INI_MANUALGEOCODELASTLOCATIONLON = "ManualGeocodeLastLocationLon";
        //public static string INI_MANUALGEOCODEREMEMBERLASTLOCATION = "ManualGeocodeRememberLastLocation";

        //public static string INI_CATEGORY_DISPLAY = "Display";
        //public static string INI_CATEGORY_SETTINGS = "Settings";
        //public static string INI_CATEGORY_GMAPS = "GMaps";

		public static double SPEED_FACTOR_METRIC = 1;
		public static double DISTANCE_FACTOR_METRIC = 1;
		public static double ELEVATION_FACTOR_METRIC = 1;

		public static double SPEED_FACTOR_IMPERIAL = 1.609344;
		public static double DISTANCE_FACTOR_IMPERIAL = (double)1200 / 3937 * 5280;
		public static double ELEVATION_FACTOR_IMPERIAL = (double)1200 / 3937;

		public static double SPEED_FACTOR_NAUTICAL = 1.852;
		public static double DISTANCE_FACTOR_NAUTICAL = 1852;

		public static string MAIN_WINDOW_TITLE = "DG Manager.NET";

		public static byte ASCII_20 = new ASCIIEncoding().GetBytes(new char[] { (char)20 })[0];

		public static string FILE_RELEASE_RSS_URL = "http://sourceforge.net/export/rss2_projfiles.php?group_id=201598";
		public static string SOURCEFORGE_MODULE_TITLE = "DGManager.NET";

		public static string GEONAMES_SERVICE_URL = "http://ws.geonames.org/findNearbyPlaceName";
		public static string GMAPS_SERVICE_URL = "http://maps.google.com/";
		public static string GMAPS_GEOCODING_SERVICE_URL = "http://maps.google.com/maps/geo";

		public static string GMAPS_DEFAULT_API_KEY = "ABQIAAAAgtxbRmpSCQrDxYbzDAjzaxRctizGfPJhWNUJARiLMd815LsJMxRLGwdcXgGDppEYczc9ENGJdPB-bA";
	}
}