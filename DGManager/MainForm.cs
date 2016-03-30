using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DGManager.Backend;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace DGManager
{
	public partial class MainForm : Form
    {
        #region Fields
		private byte[] lastAnswer = new byte[2097];
		private byte[] lastSentence = new byte[2097];
		private byte[] trackData = new byte[2097];
		private int lastAnswerSize;
		private int lastSentenceSize;
		private int lastAnswerPos;
		private int lastHeader;
		private int trackNum;
        private ReducePointsDialog reduceDialog;
		private UtcSettingsDialog utcSettings;
		private TrackSettingsDialog trackSettings;
		private DeviceConfigDialog deviceConfig;
		private AdvancedGMapsDialog advancedGMaps;
		private GeocodingSettingsDialog geocodingSettings;
		private GpxSettingsDialog gpxSettings;
		private TrackInfoDialog trackInfo;
		private DownloadLatestTracksDialog downloadLatestTracks;
		private AboutDialog about;
		private SetCameraOffsetDialog setCameraOffset;
		private KmlSettingsDialog kmlSettings;
        private DoWorkEventHandler currentDataOperationDoWorkHandler;
		private List<PointOfInterest> allPoints;
		private int totalCheckedPointCount;
		private DateTime? oldestDesiredTrackDateUtc;
        private PointOfInterestList loadedPoints;
        private System.Windows.Forms.Timer _timerRefreshGoogle = new System.Windows.Forms.Timer();
        #endregion

        #region Properties
        private int FileNum { get; set; }

		private static string ExeDirectoryPath
		{
			get
			{
				return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			}
		}

		private UtcSettingsDialog UtcSettings
		{
			get
			{
				if (utcSettings == null)
				{
					utcSettings = new UtcSettingsDialog();
				}

				return utcSettings;
			}
			set
			{
				utcSettings = value;
			}
		}

		private TrackSettingsDialog TrackSettings
		{
			get
			{
				if (trackSettings == null)
				{
					trackSettings = new TrackSettingsDialog();
				}

				return trackSettings;
			}
			set
			{
				trackSettings = value;
			}
		}

		public DeviceConfigDialog DeviceConfig
		{
			get
			{
				if (deviceConfig == null)
				{
					deviceConfig = new DeviceConfigDialog();
				}

				return deviceConfig;
			}
			set
			{
				deviceConfig = value;
			}
		}

		public AdvancedGMapsDialog AdvancedGMaps
		{
			get
			{
				if (advancedGMaps == null)
				{
					advancedGMaps = new AdvancedGMapsDialog();
				}

				return advancedGMaps;
			}
			set
			{
				advancedGMaps = value;
			}
		}

		public GeocodingSettingsDialog GeocodingSettings
		{
			get
			{
				if (geocodingSettings == null)
				{
					geocodingSettings = new GeocodingSettingsDialog();
				}

				return geocodingSettings;
			}
			set
			{
				geocodingSettings = value;
			}
		}

		public GpxSettingsDialog GpxSettings
		{
			get
			{
				if (gpxSettings == null)
				{
					gpxSettings = new GpxSettingsDialog();
				}

				return gpxSettings;
			}
			set
			{
				gpxSettings = value;
			}
		}

		public TrackInfoDialog TrackInfo
		{
			get
			{
				if (trackInfo == null)
				{
					trackInfo = new TrackInfoDialog();
				}

				return trackInfo;
			}
			set
			{
				trackInfo = value;
			}
		}

		public DownloadLatestTracksDialog DownloadLatestTracks
		{
			get
			{
				if (downloadLatestTracks == null)
				{
					downloadLatestTracks = new DownloadLatestTracksDialog();
				}

				return downloadLatestTracks;
			}
			set
			{
				downloadLatestTracks = value;
			}
		}

		public AboutDialog About
		{
			get
			{
				if (about == null)
				{
					about = new AboutDialog();
				}

				return about;
			}
			set
			{
				about = value;
			}
		}

		public SetCameraOffsetDialog SetCameraOffset
		{
			get
			{
				if (setCameraOffset == null)
				{
					setCameraOffset = new SetCameraOffsetDialog();
				}

				return setCameraOffset;
			}
			set
			{
				setCameraOffset = value;
			}
		}

		public KmlSettingsDialog KmlSettings
		{
			get
			{
				if (kmlSettings == null)
				{
					kmlSettings = new KmlSettingsDialog();
				}

				return kmlSettings;
			}
			set
			{
				kmlSettings = value;
			}
		}

		private List<PointOfInterest> AllPoints
		{
			get
			{
				if (allPoints == null)
				{
					allPoints = new List<PointOfInterest>();
				}

				return allPoints;
			}
			set
			{
				allPoints = value;
			}
        }
        #endregion

        public MainForm()
		{
			InitializeComponent();
        }

        #region Event Handlers

        #region Form
        private void MainForm_Load(object sender, EventArgs e)
		{
#if !DEBUG
            RightTabControl.TabPages.Remove(tabPageChart);
#else
            chartToolStripMenuItem.Checked = true;
#endif
            _timerRefreshGoogle.Tick += (sender2, e2) => ShowInGoogleMaps();
            SetWindowTitle(null);
			TopMenuStrip.Renderer = new RadioCheckRenderer();
			//LoadSettings();
            Settings.LoadSettings(ExeDirectoryPath);
			ReflectSettingsInUI();
			RefreshPorts();
			//ExtractResources();

			if (Settings.AutoCheckNewVersion)
			{
				CheckForNewVersionAsync(true);
			}

            OpenFileDialog.Filter = DGManager.Backend.PointConverter.openFileFilter;
            SaveFileDialog.Filter = DGManager.Backend.PointConverter.saveFileFilter;

            LoadFiles(Environment.GetCommandLineArgs(), true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Port.IsOpen)
            {
                Port.Close();
            }

            Log("Closing", true);

            if (Settings.IsDebug)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(ExeDirectoryPath, Constants.LOG_FILENAME), true))
                {
                    sw.WriteLine(LogTextBox.Text);
                    sw.Close();
                }
            }

			//SaveSettings();
            Settings.SaveSettings(ExeDirectoryPath);
        }

        private void MainForm_Drag(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = (e.KeyState & 12) > 0 ? DragDropEffects.Copy : DragDropEffects.Move;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            PointsListView.VirtualListSize = 0;
            //TracksTreeView.Nodes.Clear();
            TracksTreeView.Enabled = false;

            LoadFiles((string[])e.Data.GetData(DataFormats.FileDrop), (e.KeyState & 12) == 0);
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Settings.Left = Left;
                Settings.Top = Top;
                Settings.Width = Width;
                Settings.Height = Height;
            }
        }
        #endregion

        #region Menus

        #region File
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Settings.LastLoadDir) && Directory.Exists(Settings.LastLoadDir))
                OpenFileDialog.InitialDirectory = Settings.LastLoadDir;

            if (OpenFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Settings.LastLoadDir = Path.GetDirectoryName(OpenFileDialog.FileName);

            LoadFiles(OpenFileDialog.FileNames, true);
        }

        private void openMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Settings.LastLoadDir) && Directory.Exists(Settings.LastLoadDir))
                OpenFileDialog.InitialDirectory = Settings.LastLoadDir;

            if (OpenFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Settings.LastLoadDir = Path.GetDirectoryName(OpenFileDialog.FileName);

            LoadFiles(OpenFileDialog.FileNames, false);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collection<PointOfInterestList> tracks = GetTracksToSave();
            List<Jpeg> photos = GetSelectedPhotos();
            if (tracks.Count == 0 && photos.Count == 0)
            {
                MessageBox.Show("No tracks to save");
                return;
            }
            DateTime when = tracks[0][0].When;
            if (String.IsNullOrEmpty(SaveFileDialog.FileName) && when != DateTime.MinValue)
                SaveFileDialog.FileName = when.AddHours(Settings.UtcShift).ToString("yyyy-MM-dd");
            if (SaveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                PointWriterArgs args = new PointWriterArgs(SaveFileDialog.FileName, tracks, Log, DataOperationBackgroundWorker.ReportProgress);
                WorkProgressBar.Maximum = args.Tracks.Count;
                currentDataOperationDoWorkHandler = DGManager.Backend.PointConverter.SaveFileAsync;
                DataOperationBackgroundWorker.DoWork += currentDataOperationDoWorkHandler;
                DataOperationBackgroundWorker.RunWorkerAsync(args);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Edit
        private void checkAllFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TracksTreeView.AfterCheck -= TracksTreeView_AfterCheck;

            CheckAllNodes(TracksTreeView.Nodes, true);

            TracksTreeView.AfterCheck += TracksTreeView_AfterCheck;

            RefreshSelectedTabPage();
            RefreshTotalCheckedPointCount();
        }

        private static void CheckAllNodes(TreeNodeCollection nodes, bool value)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = value;
                CheckAllNodes(node.Nodes, value);
            }
        }

        private static void CheckAllNodes(IEnumerable<TreeNode> nodes, bool value)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = value;
                CheckAllNodes(node.Nodes, value);
            }
        }

        private void uncheckAllFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TracksTreeView.AfterCheck -= TracksTreeView_AfterCheck;

            CheckAllNodes(TracksTreeView.Nodes, false);

            TracksTreeView.AfterCheck += TracksTreeView_AfterCheck;

            RefreshSelectedTabPage();
            RefreshTotalCheckedPointCount();
        }

        private void checkSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Change this to handle structured tree
            TracksTreeView.AfterCheck -= TracksTreeView_AfterCheck;

            CheckAllNodes(TracksTreeView.SelectedNodes, true);

            TracksTreeView.AfterCheck += TracksTreeView_AfterCheck;

            RefreshSelectedTabPage();
            RefreshTotalCheckedPointCount();
        }

        private void uncheckSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TracksTreeView.AfterCheck -= TracksTreeView_AfterCheck;

            CheckAllNodes(TracksTreeView.SelectedNodes, false);

            TracksTreeView.AfterCheck += TracksTreeView_AfterCheck;

            RefreshSelectedTabPage();
            RefreshTotalCheckedPointCount();
        }

        private void onlyCheckSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TracksTreeView.AfterCheck -= TracksTreeView_AfterCheck;

            CheckAllNodes(TracksTreeView.Nodes, false);
            CheckAllNodes(TracksTreeView.SelectedNodes, true);

            TracksTreeView.AfterCheck += TracksTreeView_AfterCheck;

            RefreshSelectedTabPage();
            RefreshTotalCheckedPointCount();
        }

        private void removeAllTracksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointsListView.VirtualListSize = 0;
            TracksTreeView.Nodes.Clear();
            SetWindowTitle(null);
        }

        private void removeSelectedTracksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedNodes();

            if (TracksTreeView.Nodes.Count == 0)
            {
                SetWindowTitle(null);
                PointsListView.VirtualListSize = 0;
            }

            RefreshTotalCheckedPointCount();
            RefreshTreeText();
        }

		private void mergeCheckedTracksToolStripMenuItem_Click(object sender, EventArgs e)
		{
            Collection<TreeNode> checkedNodes = GetCheckedTracks(TracksTreeView.Nodes);
            if (checkedNodes.Count < 2) return;
            PointOfInterestList firstCheckedTrack = (checkedNodes[0] as TrackTreeNode).Track;
			for (int i = 1; i < checkedNodes.Count; i++ )
			{
                TrackTreeNode trackNode = checkedNodes[i] as TrackTreeNode;
                if (trackNode != null)
                {
                    PointOfInterestList mergeList = trackNode.Track;
                    if (firstCheckedTrack[firstCheckedTrack.Count - 1].Equals(mergeList[0]))
                        mergeList.RemoveAt(0);
                    firstCheckedTrack.AddRange(mergeList);
                    GetNodeCollection(checkedNodes[i]).RemoveAt(checkedNodes[i].Index);
                    firstCheckedTrack.TrimEnd = firstCheckedTrack.Count - 1;
                }
			}
            RefreshTreeText();
            loadedPoints = null;
			FillGrid();
		}

        private void moveTrackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = TracksTreeView.SelectedNode;
            if (node != null && node.Index > 0)
            {
                int index = node.Index;
                TreeNodeCollection nodes = GetNodeCollection(node);
                nodes.Remove(node);
                nodes.Insert(index - 1, node);
                TracksTreeView.SelectedNode = node;
            }
        }
        #endregion

        #region View
        private void checkedTracksInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collection<TreeNode> nodes = GetCheckedTracks(TracksTreeView.Nodes);
            Collection<PointOfInterestList> checkedTracks = new Collection<PointOfInterestList>();
            TrackTreeNode trackNode;
            foreach (TreeNode node in nodes)
                if ((trackNode = node as TrackTreeNode) != null)
                    checkedTracks.Add(trackNode.Track);

            if (checkedTracks.Count > 0)
            {
                TrackInfo.UtcShift = Settings.UtcShift;
                TrackInfo.SpeedMeasurementSystem = Settings.SpeedMeasurementSystem;
                TrackInfo.DistanceMeasurementSystem = Settings.DistanceMeasurementSystem;
                TrackInfo.ElevationMeasurementSystem = Settings.ElevationMeasurementSystem;
                TrackInfo.RefreshTrackInfo(checkedTracks);
                TrackInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please check one or more tracks.", String.Empty, MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);
            }
        }

        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chartToolStripMenuItem.Checked)
                RightTabControl.TabPages.Add(tabPageChart);
            else
                RightTabControl.TabPages.Remove(tabPageChart);
        }
        #endregion

        #region Settings
		private void speedUnitMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

			switch (clickedItem.Text)
			{
				case "Metric":
					Settings.SpeedMeasurementSystem = MeasurementSystem.Metric;
					break;
				case "Imperial":
					Settings.SpeedMeasurementSystem = MeasurementSystem.Imperial;
					break;
				case "Nautical":
					Settings.SpeedMeasurementSystem = MeasurementSystem.Nautical;
					break;
			}

			speedMetricToolStripMenuItem.Checked = false;
			speedImperialToolStripMenuItem.Checked = false;
			speedNauticalToolStripMenuItem.Checked = false;

			clickedItem.Checked = true;

			FillGrid();
		}

		private void distanceUnitMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

			switch (clickedItem.Text)
			{
				case "Metric":
					Settings.DistanceMeasurementSystem = MeasurementSystem.Metric;
					break;
				case "Imperial":
					Settings.DistanceMeasurementSystem = MeasurementSystem.Imperial;
					break;
				case "Nautical":
					Settings.DistanceMeasurementSystem = MeasurementSystem.Nautical;
					break;
			}

			distanceMetricToolStripMenuItem.Checked = false;
			distanceImperialToolStripMenuItem.Checked = false;
			distanceNauticalToolStripMenuItem.Checked = false;

			clickedItem.Checked = true;

			FillGrid();
		}

		private void elevationUnitMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

			switch (clickedItem.Text)
			{
				case "Metric":
					Settings.ElevationMeasurementSystem = MeasurementSystem.Metric;
					break;
				case "Imperial":
					Settings.ElevationMeasurementSystem = MeasurementSystem.Imperial;
					break;
			}

			elevationMetricToolStripMenuItem.Checked = false;
			elevationImperialToolStripMenuItem.Checked = false;

			clickedItem.Checked = true;

			FillGrid();
		}

		private void fullToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.FullPrecision = true;

			fullToolStripMenuItem.Checked = true;
			nineDigitsToolStripMenuItem.Checked = false;

			FillGrid();
		}

		private void nineDigitsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.FullPrecision = false;

			fullToolStripMenuItem.Checked = false;
			nineDigitsToolStripMenuItem.Checked = true;

			FillGrid();
		}

		private void smallControlsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.GMapsSmallControls = true;

			smallControlsToolStripMenuItem.Checked = true;
			normalControlsToolStripMenuItem.Checked = false;

			if (RightTabControl.SelectedTab == MapTabPage)
			{
				ShowInGoogleMaps();
			}
		}

		private void normalControlsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.GMapsSmallControls = false;

			smallControlsToolStripMenuItem.Checked = false;
			normalControlsToolStripMenuItem.Checked = true;

			if (RightTabControl.SelectedTab == MapTabPage)
			{
				ShowInGoogleMaps();
			}
		}

		private void streetMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (streetMapToolStripMenuItem.Checked)
			{
				streetMapToolStripMenuItem.Checked = false;
				Settings.GMapsMapButton = false;
			}
			else
			{
				streetMapToolStripMenuItem.Checked = true;
				Settings.GMapsMapButton = true;
			}

			if (RightTabControl.SelectedTab == MapTabPage)
			{
				ShowInGoogleMaps();
			}
		}

		private void satelliteMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (satelliteMapToolStripMenuItem.Checked)
			{
				satelliteMapToolStripMenuItem.Checked = false;
				Settings.GMapsSatelliteButton = false;
			}
			else
			{
				satelliteMapToolStripMenuItem.Checked = true;
				Settings.GMapsSatelliteButton = true;
			}

			if (RightTabControl.SelectedTab == MapTabPage)
			{
				ShowInGoogleMaps();
			}
		}

		private void hybridMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (hybridMapToolStripMenuItem.Checked)
			{
				hybridMapToolStripMenuItem.Checked = false;
				Settings.GMapsHybridButton = false;
			}
			else
			{
				hybridMapToolStripMenuItem.Checked = true;
				Settings.GMapsHybridButton = true;
			}

			if (RightTabControl.SelectedTab == MapTabPage)
			{
				ShowInGoogleMaps();
			}
		}

		private void terrainMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (terrainMapToolStripMenuItem.Checked)
			{
				terrainMapToolStripMenuItem.Checked = false;
				Settings.GMapsTerrainButton = false;
			}
			else
			{
				terrainMapToolStripMenuItem.Checked = true;
				Settings.GMapsTerrainButton = true;
			}

			if (RightTabControl.SelectedTab == MapTabPage)
			{
				ShowInGoogleMaps();
			}
		}

		private void streetDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.GMapsDefaultMapType = GMapType.Street;

			streetDefaultToolStripMenuItem.Checked = true;
			satelliteDefaultToolStripMenuItem.Checked = false;
			hybridDefaultToolStripMenuItem.Checked = false;

			if (RightTabControl.SelectedTab == MapTabPage)
			{
				ShowInGoogleMaps();
			}
		}

		private void satelliteDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.GMapsDefaultMapType = GMapType.Satellite;

			streetDefaultToolStripMenuItem.Checked = false;
			satelliteDefaultToolStripMenuItem.Checked = true;
			hybridDefaultToolStripMenuItem.Checked = false;

			if (RightTabControl.SelectedTab == MapTabPage)
			{
				ShowInGoogleMaps();
			}
		}

		private void hybridDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.GMapsDefaultMapType = GMapType.Hybrid;

			streetDefaultToolStripMenuItem.Checked = false;
			satelliteDefaultToolStripMenuItem.Checked = false;
			hybridDefaultToolStripMenuItem.Checked = true;

			if (RightTabControl.SelectedTab == MapTabPage)
			{
				ShowInGoogleMaps();
			}
		}

		private void overviewMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (overviewMapToolStripMenuItem.Checked)
			{
				overviewMapToolStripMenuItem.Checked = false;
				Settings.GMapsOverviewMap = false;
			}
			else
			{
				overviewMapToolStripMenuItem.Checked = true;
				Settings.GMapsOverviewMap = true;
			}

			if (RightTabControl.SelectedTab == MapTabPage)
			{
				ShowInGoogleMaps();
			}
		}

		private void advancedGMapsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AdvancedGMaps.LineColour = Settings.GMapsLineColour;
			AdvancedGMaps.LineWidth = Settings.GMapsLineWidth;
			AdvancedGMaps.LineOpacity = Settings.GMapsLineOpacity;
			AdvancedGMaps.SpecifyLineColour = Settings.GMapsSpecifyLineColour;
			AdvancedGMaps.SpecifyLineWidth = Settings.GMapsSpecifyLineWidth;
			AdvancedGMaps.SpecifyLineOpacity = Settings.GMapsSpecifyLineOpacity;
			AdvancedGMaps.DifferentTrackColours = Settings.GMapsDifferentTrackColours;
			AdvancedGMaps.DropPoints = Settings.GMapsDropPoints;
			AdvancedGMaps.DropPointsThreshold = Settings.GMapsDropPointsThreshold;
			AdvancedGMaps.DropPointsMinDistance = Settings.GMapsDropPointsMinDistance;
			AdvancedGMaps.ApiKey = Settings.GMapsApiKey;
            AdvancedGMaps.DisplayStartIcon = Settings.GMapsDisplayStartIcon;
            AdvancedGMaps.DisplayEndIcon = Settings.GMapsDisplayEndIcon;
            AdvancedGMaps.StartIconUrl = Settings.GMapsStartIcon;
            AdvancedGMaps.EndIconUrl = Settings.GMapsEndIcon;
            AdvancedGMaps.StrictHtml = Settings.GMapsStrictHtml;

			if (AdvancedGMaps.ShowDialog() == DialogResult.OK)
			{
				Settings.GMapsLineColour = AdvancedGMaps.LineColour;
				Settings.GMapsLineWidth = AdvancedGMaps.LineWidth;
				Settings.GMapsLineOpacity = AdvancedGMaps.LineOpacity;
				Settings.GMapsSpecifyLineColour = AdvancedGMaps.SpecifyLineColour;
				Settings.GMapsSpecifyLineWidth = AdvancedGMaps.SpecifyLineWidth;
				Settings.GMapsSpecifyLineOpacity = AdvancedGMaps.SpecifyLineOpacity;
				Settings.GMapsDifferentTrackColours = AdvancedGMaps.DifferentTrackColours;
				Settings.GMapsDropPoints = AdvancedGMaps.DropPoints;
				Settings.GMapsDropPointsThreshold = AdvancedGMaps.DropPointsThreshold;
				Settings.GMapsDropPointsMinDistance = AdvancedGMaps.DropPointsMinDistance;
				Settings.GMapsApiKey = AdvancedGMaps.ApiKey;
                Settings.GMapsDisplayStartIcon = AdvancedGMaps.DisplayStartIcon;
                Settings.GMapsDisplayEndIcon = AdvancedGMaps.DisplayEndIcon;
                Settings.GMapsStartIcon = AdvancedGMaps.StartIconUrl;
                Settings.GMapsEndIcon = AdvancedGMaps.EndIconUrl;
                Settings.GMapsStrictHtml = AdvancedGMaps.StrictHtml;

				if (RightTabControl.SelectedTab == MapTabPage)
				{
					ShowInGoogleMaps();
				}
			}
		}

		private void automaticallyCheckForNewVersionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (automaticallyCheckForNewVersionsToolStripMenuItem.Checked)
			{
				automaticallyCheckForNewVersionsToolStripMenuItem.Checked = false;
				Settings.AutoCheckNewVersion = false;
			}
			else
			{
				automaticallyCheckForNewVersionsToolStripMenuItem.Checked = true;
				Settings.AutoCheckNewVersion = true;
			}
		}

        private void uTCShiftToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UtcSettings.UtcShiftType = Settings.UtcShiftType;
			UtcSettings.UtcShift = Settings.UtcShift;

			if (UtcSettings.ShowDialog() == DialogResult.OK)
			{
				Settings.UtcShiftType = UtcSettings.UtcShiftType;
				Settings.UtcShift = UtcSettings.UtcShift;
				UtcStatusLabel.Text = String.Format("UTC {0} {1}", Settings.UtcShift < 0 ? "-" : "+", Math.Abs(Settings.UtcShift));
			}
		}

		private void trackSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TrackSettings.TrackMode = Settings.TrackMode;
			TrackSettings.NewTrackThresholdMins = Settings.NewTrackThresholdMins;
			TrackSettings.ApplyTrackModeWhenLoadingGSD = Settings.ApplyTrackModeWhenLoadingGSD;
			TrackSettings.GuessManualPoints = Settings.GuessManualPoints;
            TrackSettings.TimeDisplayFormat = Settings.TimeDisplayFormat;

			if (TrackSettings.ShowDialog() == DialogResult.OK)
			{
				Settings.TrackMode = TrackSettings.TrackMode;
				Settings.NewTrackThresholdMins = TrackSettings.NewTrackThresholdMins;
				Settings.ApplyTrackModeWhenLoadingGSD = TrackSettings.ApplyTrackModeWhenLoadingGSD;
				Settings.GuessManualPoints = TrackSettings.GuessManualPoints;
                Settings.TimeDisplayFormat = TrackSettings.TimeDisplayFormat;
                RefreshTreeText();
			}
		}

		private void geocodingSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GeocodingSettings.CameraOffsetEnabled = Settings.CameraOffsetEnabled;
			GeocodingSettings.CameraOffsetTimespan = Settings.CameraOffsetTimespan;
			GeocodingSettings.CameraOffsetSign = Settings.CameraOffsetSign;
			GeocodingSettings.SetImageModDateToGeocodeDate = Settings.SetImageModDateToGeocodeDate;
			GeocodingSettings.GeocodeInterpolationThresholdSecs = Settings.GeocodeInterpolationThresholdSecs;
			GeocodingSettings.GeocodePlanBThresholdEnabled = Settings.GeocodePlanBThresholdEnabled;
			GeocodingSettings.GeocodePlanBThresholdMins = Settings.GeocodePlanBThresholdMins;
			GeocodingSettings.RevGeoEnabled = Settings.RevGeoEnabled;
			GeocodingSettings.RevGeoSetImageDescription = Settings.RevGeoSetImageDescription;
			GeocodingSettings.RevGeoSetXPComment = Settings.RevGeoSetXPComment;
			GeocodingSettings.RevGeoSetXPKeywords = Settings.RevGeoSetXPKeywords;
			GeocodingSettings.RevGeoSetXPSubject = Settings.RevGeoSetXPSubject;
			GeocodingSettings.RevGeoSetUserComment = Settings.RevGeoSetUserComment;
			GeocodingSettings.RevGeoSetIptcKeywords = Settings.RevGeoSetIptcKeywords;
			GeocodingSettings.RevGeoSetIptcCaption = Settings.RevGeoSetIptcCaption;
			GeocodingSettings.RevGeoUseGoogleMaps = Settings.RevGeoUseGoogleMaps;

			if (GeocodingSettings.ShowDialog() == DialogResult.OK)
			{
				Settings.CameraOffsetEnabled = GeocodingSettings.CameraOffsetEnabled;
				Settings.CameraOffsetTimespan = GeocodingSettings.CameraOffsetTimespan;
				Settings.CameraOffsetSign = GeocodingSettings.CameraOffsetSign;
				Settings.SetImageModDateToGeocodeDate = GeocodingSettings.SetImageModDateToGeocodeDate;
				Settings.GeocodePlanBThresholdEnabled = GeocodingSettings.GeocodePlanBThresholdEnabled;
				Settings.GeocodePlanBThresholdMins = GeocodingSettings.GeocodePlanBThresholdMins;
				Settings.GeocodeInterpolationThresholdSecs = GeocodingSettings.GeocodeInterpolationThresholdSecs;
				Settings.RevGeoEnabled = GeocodingSettings.RevGeoEnabled;
				Settings.RevGeoSetImageDescription = GeocodingSettings.RevGeoSetImageDescription;
				Settings.RevGeoSetXPComment = GeocodingSettings.RevGeoSetXPComment;
				Settings.RevGeoSetXPKeywords = GeocodingSettings.RevGeoSetXPKeywords;
				Settings.RevGeoSetXPSubject = GeocodingSettings.RevGeoSetXPSubject;
				Settings.RevGeoSetUserComment = GeocodingSettings.RevGeoSetUserComment;
				Settings.RevGeoSetIptcKeywords = GeocodingSettings.RevGeoSetIptcKeywords;
				Settings.RevGeoSetIptcCaption = GeocodingSettings.RevGeoSetIptcCaption;
				Settings.RevGeoUseGoogleMaps = GeocodingSettings.RevGeoUseGoogleMaps;
				ReflectCameraOffsetInUI();
			}
		}

		private void gPXSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GpxSettings.GpxIncludeWaypoints = Settings.GpxIncludeWaypoints;
			GpxSettings.GpxIncludeRoutes = Settings.GpxIncludeRoutes;
			GpxSettings.GpxIncludeTracks = Settings.GpxIncludeTracks;
			GpxSettings.GpxSaveSpeedData = Settings.GpxSaveSpeedData;

			if (GpxSettings.ShowDialog() == DialogResult.OK)
			{
				Settings.GpxIncludeWaypoints = GpxSettings.GpxIncludeWaypoints;
				Settings.GpxIncludeRoutes = GpxSettings.GpxIncludeRoutes;
				Settings.GpxIncludeTracks = GpxSettings.GpxIncludeTracks;
				Settings.GpxSaveSpeedData = GpxSettings.GpxSaveSpeedData;
			}
		}

		private void kMLSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KmlSettings.KmlUsePhotoPathPrefix = Settings.KmlUsePhotoPathPrefix;
			KmlSettings.KmlPhotoPathPrefix = Settings.KmlPhotoPathPrefix;

			if (KmlSettings.ShowDialog() == DialogResult.OK)
			{
				Settings.KmlUsePhotoPathPrefix = KmlSettings.KmlUsePhotoPathPrefix;
				Settings.KmlPhotoPathPrefix = KmlSettings.KmlPhotoPathPrefix;
			}
		}
        #endregion

        #region Port
		private void portMenuItem_Click(object sender, EventArgs e)
		{
			if (Port.IsOpen)
			{
				//Log(String.Format("Port {0} is already open. You cannot change the port.", Port.PortName));
				//return;

				Port.Close();
			}

			foreach (ToolStripMenuItem portMenuItem in portToolStripMenuItem.DropDownItems)
			{
				if (portMenuItem == sender)
				{
					portMenuItem.Checked = true;
					Settings.Port = portMenuItem.Text;
					Port.PortName = portMenuItem.Text;
                    Log("Port {0} selected", portMenuItem.Text);
					PortStatusLabel.Text = portMenuItem.Text;
				}
				else
				{
					portMenuItem.Checked = false;
				}
			}
		}
        #endregion

        #region Device
		private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Port.IsOpen)
			{
				Port.Open();
			}

			byte[] command = new byte[] { 0xA0, 0xA2, 0x00, 0x01, 0xB7, 0x00, 0xB7, 0xB0, 0xB3 };
			Log("Get Configuration");
			Port.Write(command, 0, 9);
		}

		private void identificationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Port.IsOpen)
			{
				Port.Open();
			}

			byte[] command = new byte[] { 0xA0, 0xA2, 0x00, 0x01, 0xBF, 0x00, 0xBF, 0xB0, 0xB3 };

			Log("Request identification");

			Port.Write(command, 0, command.Length);
		}

		private void readToolStripMenuItem_Click(object sender, EventArgs e)
		{
			oldestDesiredTrackDateUtc = new DateTime?();
			StartDownloadingTracks();
		}

		private void downloadLatestTracksToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DownloadLatestTracks.LastDays = Settings.DownloadLatestTracksLastDays;

			if (DownloadLatestTracks.ShowDialog() == DialogResult.OK)
			{
				Settings.DownloadLatestTracksLastDays = DownloadLatestTracks.LastDays;
				oldestDesiredTrackDateUtc = DateTime.Today.AddDays(-1 * DownloadLatestTracks.LastDays).AddHours(-1 * Settings.UtcShift);
				StartDownloadingTracks();
			}
		}

		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Port.IsOpen)
			{
				Port.Open();
			}

			byte[] command = new byte[] { 0xA0, 0xA2, 0x00, 0x02, 0xBC, 0x01, 0x00, 0xBD, 0xB0, 0xB3 };

			Log("Start GPS Mouse");

			Port.Write(command, 0, 10);
		}

		private void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Port.IsOpen)
			{
				Port.Open();
			}

			byte[] command = new byte[] { 0xA0, 0xA2, 0x00, 0x02, 0xBC, 0x00, 0x00, 0xBC, 0xB0, 0xB3 };

			Log("Stop GPS Mouse");

			Port.Write(command, 0, 10);
		}

		private void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to erase ALL the memory?", "Erase Memory", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
				== DialogResult.Yes)
			{
				if (!Port.IsOpen)
				{
					Port.Open();
				}

				byte[] command = new byte[] { 0xA0, 0xA2, 0x00, 0x03, 0xBA, 0xFF, 0xFF, 0x02, 0xB8, 0xB0, 0xB3 };

				Log("Erasing memory");
				Port.Write(command, 0, 11);
			}
		}
        #endregion

        #region ?
		private void checkForNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CheckForNewVersionAsync(false);
		}

		private void aboutDGManagerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About.ShowDialog();
		}
        #endregion

        #region Photos Context
        private void manuallyGeocodeSelectedPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhotosGridView.SelectedRows.Count == 0)
            {
                return;
            }

            ManualCoordinatesDialog mcd = new ManualCoordinatesDialog();
            if (mcd.ShowDialog() == DialogResult.OK)
            {
                bool calculateSurroundingCoordinates = ((PhotosGridView.SelectedRows.Count > 1) && (mcd.CalculateSurroundingCoordinates));
                Location centerLocation = new Location { Latitude = mcd.Latitude, Longitude = mcd.Longitude };
                List<Location> surroundingLocations =
                  GroupedCoordinatesCalculator.CalculateSurroundingLocations(centerLocation, PhotosGridView.SelectedRows.Count);

                int index = 0;
                foreach (DataGridViewRow row in PhotosGridView.SelectedRows)
                {
                    Jpeg jpg = (Jpeg)row.Tag;
                    if (calculateSurroundingCoordinates)
                    {
                        jpg.Location = surroundingLocations[index++];
                    }
                    else
                    {
                        jpg.Location = centerLocation;
                    }

                    if (Settings.RevGeoEnabled)
                    {
                        try
                        {
                            ReverseGeocoder.AddLocationTags(jpg);
                        }
                        catch (Exception ex)
                        {
                            Log("An error occurred during reverse geocoding: {0}", ex.Message);
                        }
                    }

                    JpegHelper.SetGpsInfo(jpg, Settings.SetImageModDateToGeocodeDate);
                    Log("Successfully geocoded photo: {0} with the location ({1},{2}) and address '{3}'.",
                      jpg.FilePath, jpg.Location.Latitude, jpg.Location.Longitude, jpg.LocationText);
                }
            }
            else
            {
                Log("User cancelled manual geocoding.");
            }
        }
        #endregion

        #region Tracks Context
        private void deleteTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedNodes();
            //foreach (TreeNode selectedNode in TracksTreeView.SelectedNodes)
            //    if (selectedNode.Parent == null)
            //        TracksTreeView.Nodes.Remove(selectedNode);
            //    else
            //        selectedNode.Parent.Nodes.Remove(selectedNode);
        }

        private void reducePointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reduceDialog == null) reduceDialog = new ReducePointsDialog();
            TrackTreeNode selectedNode = TracksTreeView.SelectedNode as TrackTreeNode;
            PointOfInterestList track = selectedNode.Track;
            TracksTreeView.SelectedNode = null;
            if (track == null || track.Count < 3) return;
            reduceDialog.TargetNumber = track.Count;
            if (reduceDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (track[0].When != DateTime.MinValue)
                    track.Sort(PointOfInterest.ComparePointsByDate);
                // Calculate distance if not already
                PointOfInterest endPoint = track[track.Count - 1];
                if (endPoint.Distance == null || !endPoint.Distance.HasValue)
                {
                    PointOfInterest lastPoint = track[0];
                    for (int i = 1; i < track.Count; i++)
                    {
                        double dist = track[i].DistanceToPoint(lastPoint);
                        if (track[i].Distance == null || !track[i].Distance.HasValue)
                        {
                            if (lastPoint.Distance == null)
                                track[i].Distance = new DistanceMeasurement(dist);
                            else
                                track[i].Distance = new DistanceMeasurement(lastPoint.Distance.GetValue(0.0) + dist);
                        }
                        lastPoint = track[i];
                    }
                }
                // Determine approximate distance between each point
                double targetDistance = endPoint.Distance.GetValue() / reduceDialog.TargetNumber;
                for (int i = 1; i < track.Count - 1; )
                {
                    double lastDistance = (i == 1 ? 0 : track[i - 1].Distance.GetValue());
                    if (track[i].Distance.GetValue() - lastDistance < targetDistance)
                    {
                        track[i + 1].Distance.SetValue((track[i + 1].Distance == null || !track[i + 1].Distance.HasValue ? 0 : track[i + 1].Distance.GetValue()) + (track[i].Distance.GetValue() - lastDistance));
                        track.RemoveAt(i);
                    }
                    else
                        i++;
                }
			    selectedNode.Text = String.Format("({0:000}) {1}", selectedNode.Index + 1, track.DisplayName);
                RefreshSelectedTabPage();
            }
        }
        #endregion

        #region Points Context
		private void splitTrackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = TracksTreeView.SelectedNode;
			if (selectedNode == null || PointsListView.SelectedIndices.Count != 1)
				return;
			int splitPoint = PointsListView.SelectedIndices[0];
			PointsListView.SelectedIndices.Clear();
			TracksTreeView.SelectedNode = null;
            loadedPoints = null;

            SplitTrack(selectedNode as TrackTreeNode, splitPoint);

            RefreshTrimControls();
            RefreshTreeText();
            TracksTreeView.SelectedNode = selectedNode;
		}

        private void setTrimStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PointsListView.SelectedIndices.Count != 1) return;
            TrimStartTrackBar.Value = PointsListView.SelectedIndices[0];
            TrackTreeNode trackNode = TracksTreeView.SelectedNode as TrackTreeNode;
            if (trackNode != null)
            {
                PointOfInterestList list = trackNode.Track;
                list.TrimStart = TrimStartTrackBar.Value;
                list.TrimEnd = TrimEndTrackBar.Value;
                list.IsTrimmed = true;
            }
            EnableTrimPointsCheckBox.Checked = true;
            RefreshSelectedTabPage();
        }

        private void setTrimEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PointsListView.SelectedIndices.Count != 1) return;
            TrimEndTrackBar.Value = PointsListView.SelectedIndices[0];
            TrackTreeNode trackNode = TracksTreeView.SelectedNode as TrackTreeNode;
            if (trackNode != null)
            {
                PointOfInterestList list = trackNode.Track;
                list.TrimStart = TrimStartTrackBar.Value;
                list.TrimEnd = TrimEndTrackBar.Value;
                list.IsTrimmed = true;
            }
            EnableTrimPointsCheckBox.Checked = true;
            RefreshSelectedTabPage();
        }

        private void removePointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PointsListView.SelectedIndices.Count == 0) return;
            TrackTreeNode trackNode = TracksTreeView.SelectedNode as TrackTreeNode;
            if (trackNode != null)
            {
                PointOfInterestList list = trackNode.Track;
                for (int i = 0; i < PointsListView.SelectedIndices.Count; i++)
                    list.RemoveAt(PointsListView.SelectedIndices[0]);
                RefreshSelectedTabPage();
            }
        }
        #endregion

        #endregion

        #region UI
        private void TopBottomSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                Settings.LogPanelHeight = TopBottomSplitContainer.Height - TopBottomSplitContainer.SplitterDistance;
        }

        private void LeftRightSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                Settings.TracksListWidth = LeftRightSplitContainer.SplitterDistance;
        }

		private void RightTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshSelectedTabPage();
		}

		private void GMapsWebBrowser_Navigated(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
            if (e.Url.AbsolutePath.Contains("Null"))
            {
                string latStr = ((mshtml.HTMLInputElementClass)(((System.Windows.Forms.WebBrowser)sender).Document.GetElementById("hidLat").DomElement)).IHTMLInputHiddenElement_value;
                string lonStr = ((mshtml.HTMLInputElementClass)(((System.Windows.Forms.WebBrowser)sender).Document.GetElementById("hidLong").DomElement)).IHTMLInputHiddenElement_value;
                if (String.IsNullOrEmpty(latStr) || String.IsNullOrEmpty(lonStr)) return;
                double lat = double.Parse(latStr);
                double lon = double.Parse(lonStr);
                PointOfInterest pnt = new PointOfInterest(lat, lon);
                PointOfInterestList lst = new PointOfInterestList();
                lst.Add(pnt);
                TrackTreeNode newNode = new TrackTreeNode(String.Format("({0:000}) GMap point", TracksTreeView.Nodes.Count + 1)) { Track = lst, Checked = true };
                BeginInvoke(new AddNodeToTreeDelegate(AddNodeToTree), new object[] { TracksTreeView.Nodes, newNode });
            }
            else
			    Log("Google Maps HTML File Loaded");
			//saveGoogleMapFileToolStripMenuItem.Enabled = true;
		}
        #endregion

        #region Tracks
		private void TracksTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
            RefreshTrimControls();
            if (RightTabControl.SelectedTab == PointsTabPage)
            {
                FillGrid();
            }
            else if (RightTabControl.SelectedTab == tabPageChart)
            {
                FillChart();
            }
		}

		private void TracksTreeView_AfterCheck(object sender, TreeViewEventArgs e)
		{
			RefreshTotalCheckedPointCount();
			RefreshSelectedTabPage();
		}

        private void TracksTreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TrackTreeNode trackNode = e.Node as TrackTreeNode;
            if (trackNode != null)
                e.Node.Text = trackNode.Track.ListName;
        }

        private void TracksTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TrackTreeNode trackNode = e.Node as TrackTreeNode;
            if (trackNode == null) return;
            PointOfInterestList list = trackNode.Track;
            if (!String.IsNullOrEmpty(e.Label) || e.Label == " ")
            {
                list.ListName = Regex.Replace(e.Label.Trim(), @"^(?:\(\d{3}\) )?(.+?)(?: \(\d* points\))?$", "$1");
            }
            e.Node.Text = String.Format("({0:000}) {1}", e.Node.Index + 1, list.DisplayName);
            e.CancelEdit = true;
        }

		private void TracksTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TrackInfo.UtcShift = Settings.UtcShift;
			TrackInfo.SpeedMeasurementSystem = Settings.SpeedMeasurementSystem;
			TrackInfo.DistanceMeasurementSystem = Settings.DistanceMeasurementSystem;
			TrackInfo.ElevationMeasurementSystem = Settings.ElevationMeasurementSystem;
            Collection<PointOfInterestList> tracks = new Collection<PointOfInterestList>();
            tracks.Add(((TrackTreeNode)TracksTreeView.SelectedNode).Track);
            TrackInfo.RefreshTrackInfo(tracks);
			TrackInfo.ShowDialog();
		}

        private void TracksTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedNodes();
                e.Handled = true;
            }
        }
        #endregion

        #region Trim Controls
		private void TrimTrackBar_AfterValueChanged(object sender, EventArgs e)
		{
            RefreshSelectedListTrim();
			EnableTrimPointsCheckBox.Checked = true;
			RefreshSelectedTabPage();
		}

		private void TrimTrackBar_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
			{
                RefreshSelectedListTrim();
				EnableTrimPointsCheckBox.Checked = true;
				RefreshSelectedTabPage();
			}
		}

        private void TrimTrackBar_SetTooltip(object sender, EventArgs e)
        {
            TrackBar bar = sender as TrackBar;
            if (bar != null)
                toolTip1.SetToolTip(bar, String.Format("{0}", bar.Value + 1));
        }

        private void TrimTrackBar_RemoveTooltip(object sender, EventArgs e)
        {
            TrackBar bar = sender as TrackBar;
            if (bar != null)
                toolTip1.SetToolTip(bar, String.Empty);
        }

		private void EnableTrimPointsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
            RefreshSelectedListTrim();
			RefreshSelectedTabPage();
		}

        private void seperateTracksButton_Click(object sender, EventArgs e)
        {
			TreeNode selectedNode = TracksTreeView.SelectedNode;
			if (selectedNode == null)
				return;

            if (TrimEndTrackBar.Value != TrimEndTrackBar.Maximum)
                SplitTrack(selectedNode as TrackTreeNode, TrimEndTrackBar.Value);
            if (TrimStartTrackBar.Value != 0)
            {
                selectedNode.Checked = false;
                selectedNode = SplitTrack(selectedNode as TrackTreeNode, TrimStartTrackBar.Value);
                selectedNode.Checked = true;
            }
            RefreshTreeText();

            TracksTreeView.SelectedNode = selectedNode;
            EnableTrimPointsCheckBox.Checked = false;
        }

		private void ResetTrimTrackBarsButton_Click(object sender, EventArgs e)
		{
			TrimStartTrackBar.Value = 0;
			TrimEndTrackBar.Value = TrimEndTrackBar.Maximum;
			RefreshSelectedTabPage();
		}
        #endregion

        #region Photos
		private void AddPhotosButton_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(Settings.LastPhotoDir) && Directory.Exists(Settings.LastPhotoDir))
			{
				OpenMultiFilesDialog.InitialDirectory = Settings.LastPhotoDir;
			}

			OpenMultiFilesDialog.Filter = "JPEG Images (*.jpg, *.jpeg, *.jpe, *.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif";

			if (OpenMultiFilesDialog.ShowDialog() == DialogResult.OK)
			{
				WorkProgressBar.Minimum = 0;
				WorkProgressBar.Value = 0;
				WorkProgressBar.Maximum = OpenMultiFilesDialog.FileNames.Length;
                currentDataOperationDoWorkHandler = LoadPhotos;
				DataOperationBackgroundWorker.DoWork += currentDataOperationDoWorkHandler;
				DataOperationBackgroundWorker.RunWorkerAsync(OpenMultiFilesDialog.FileNames);

				Settings.LastPhotoDir = Path.GetDirectoryName(OpenMultiFilesDialog.FileName);
			}
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			PhotosGridView.Rows.Clear();
		}

		private void PerformGeocodingButton_Click(object sender, EventArgs e)
		{
			if (PhotosGridView.Rows.Count > 0)
			{
				WorkProgressBar.Minimum = 0;
				WorkProgressBar.Value = 0;
				WorkProgressBar.Maximum = PhotosGridView.Rows.Count;
                currentDataOperationDoWorkHandler = PerformGeocoding;
				DataOperationBackgroundWorker.DoWork += currentDataOperationDoWorkHandler;
				DataOperationBackgroundWorker.RunWorkerAsync();
			}
		}

        private void CommitGeocodingButton_Click(object sender, EventArgs e)
        {
            if (PhotosGridView.Rows.Count > 0)
            {
				WorkProgressBar.Minimum = 0;
				WorkProgressBar.Value = 0;
				WorkProgressBar.Maximum = PhotosGridView.Rows.Count;
                currentDataOperationDoWorkHandler = CommitGeocoding;
				DataOperationBackgroundWorker.DoWork += currentDataOperationDoWorkHandler;
				DataOperationBackgroundWorker.RunWorkerAsync();
            }
        }

		private void ToggleShowAllOnMapButton_Click(object sender, EventArgs e)
		{
			bool allChecked = true;

			foreach (DataGridViewRow row in PhotosGridView.Rows)
			{
				if (row.Cells[0].Value == null || !(bool)row.Cells[0].Value)
				{
					allChecked = false;
				}
			}

			foreach (DataGridViewRow row in PhotosGridView.Rows)
			{
				row.Cells[0].Value = !(allChecked);
			}
		}

		private void SetOffsetLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			SetCameraOffset.SetAllPoints(AllPoints);
			SetCameraOffset.UtcShift = Settings.UtcShift;
			SetCameraOffset.CameraOffsetTimespan = Settings.CameraOffsetTimespan;
			SetCameraOffset.CameraOffsetSign = Settings.CameraOffsetSign;

			if (SetCameraOffset.ShowDialog() == DialogResult.OK)
			{
				Settings.CameraOffsetTimespan = SetCameraOffset.CameraOffsetTimespan;
				Settings.CameraOffsetSign = SetCameraOffset.CameraOffsetSign;
				Settings.CameraOffsetEnabled = true;
				ReflectCameraOffsetInUI();
			}
		}

		private void ResetOffsetLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Settings.CameraOffsetTimespan = new TimeSpan(0);
			ReflectCameraOffsetInUI();
		}

		private void PhotosGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (PhotosGridView.Rows[e.RowIndex].Tag != null && !String.IsNullOrEmpty(((Jpeg)PhotosGridView.Rows[e.RowIndex].Tag).FilePath))
			{
				System.Diagnostics.Process.Start(((Jpeg)PhotosGridView.Rows[e.RowIndex].Tag).FilePath);
			}
		}
        #endregion

        private void pointsListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            TrackTreeNode trackNode = TracksTreeView.SelectedNode as TrackTreeNode;
            if (trackNode == null)
            {
                // Gotta return item & subitems - or we get a big, ugly exception.
                //  (This was necessary at one point, but I believe I've fixed it by clearing
                //   the point ListView everywhere the tree control gets cleared.  Left in
                //   to be safe...)
                e.Item = new ListViewItem();

                int nSubItems = PointsListView.Columns.Count - 1;
                for (int i = 0; i < nSubItems; i++)
                    e.Item.SubItems.Add("");

                return;
            }

            if (trackNode == null) return;
            PointOfInterestList pointsOfInterest = trackNode.Track;
            PointOfInterest poi = pointsOfInterest[e.ItemIndex >= pointsOfInterest.Count ? pointsOfInterest.Count - 1 : e.ItemIndex];

            int nRow = e.ItemIndex + 1;

            // Column 1 - Manual Marker
            if (poi.IsManual)
            {
                e.Item = new ListViewItem("--->");     // text arrow to mark manual point
            }
            else
            {
                e.Item = new ListViewItem();
            }

            // Set the background color of the start and end points
            if (EnableTrimPointsCheckBox.Checked && (e.ItemIndex == TrimStartTrackBar.Value || e.ItemIndex == TrimEndTrackBar.Value))
                e.Item.BackColor = Color.LightGray;

            // Column 2 - Row number
            e.Item.SubItems.Add( nRow.ToString() );

            // Column 3 - Latitude
            string str = String.Format(CultureInfo.InvariantCulture, Settings.FullPrecision ? "{0}" : "{0:0.######}", poi.Latitude);
            e.Item.SubItems.Add(str);

            // Column 4 - Longitude
            str = String.Format(CultureInfo.InvariantCulture, Settings.FullPrecision ? "{0}" : "{0:0.######}", poi.Longitude);
            e.Item.SubItems.Add(str);

            if (PointsListView.Columns.Count > 4)
            {
                // Column 5 - Time
                str = poi.When.AddHours(Settings.UtcShift).ToLongTimeString();
                e.Item.SubItems.Add(str);

                // Column 6 - Date
                str = poi.When.AddHours(Settings.UtcShift).ToShortDateString();
                e.Item.SubItems.Add(str);

                // Column 7 - Speed
                str = poi.Speed == null ? String.Empty : poi.Speed.ToString(Settings.SpeedMeasurementSystem, null);
                e.Item.SubItems.Add(str);

                // Column 8 - Distance
				if (poi.Distance != null && poi.Distance.HasValue)
					str = poi.Distance.ToString(Settings.DistanceMeasurementSystem, null);
				else
					str = String.Empty;
                e.Item.SubItems.Add(str);
            }

            if (PointsListView.Columns.Count == 9)
            {
                // Column 9 - Altitude
                str = poi.Altitude.ToString(Settings.ElevationMeasurementSystem, null);
                e.Item.SubItems.Add(str);
            }

        }   // pointsListView_RetrieveVirtualItem

		private void refreshPortsItem_Click(object sender, EventArgs e)
		{
			RefreshPorts();
		}

        private void FileOperationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DataOperationBackgroundWorker.DoWork -= currentDataOperationDoWorkHandler;

			if (e.Error != null)
			{
				throw new ApplicationException(e.Error.Message, e.Error);
			}

            List<PointOfInterestList> tracks = e.Result as List<PointOfInterestList>;
            if (tracks != null && tracks.Count > 0)
            {
                if (Settings.ApplyTrackModeWhenLoadingGSD && Settings.TrackMode == TrackMode.Logical)
                {
                    ReloadAllPoints(new Collection<PointOfInterestList>(tracks));
                    BeginInvoke(new MethodInvoker(GenerateLogicalTracks));
                    Invoke((ThreadStart)delegate() { TracksTreeView.Enabled = true; });
                }
                else
                {
                    if (tracks.Count < 30 && tracks[0].Count > 0 && tracks[0][0].When != DateTime.MinValue)
                        tracks.Sort(PointOfInterestList.CompareListsByDate);

                    List<string> parentNames = new List<string>();
                    List<TreeNode> parentNodes = new List<TreeNode>();
                    tracks.ForEach(track =>
                    {
                        TreeNode parent = null;
                        if (parentNames.Contains(track.SourceFile))
                            parent = parentNodes[parentNames.IndexOf(track.SourceFile)];
                        else
                        {
                            parent = new TreeNode(track.SourceFile);
                            parentNames.Add(track.SourceFile);
                            parentNodes.Add(parent);
                        }
                        TrackTreeNode node = new TrackTreeNode(String.Format("({0:000}) {1}", parent.Nodes.Count + 1, track.DisplayName)) { Track = track };
                        parent.Nodes.Add(node);
                    });

                    Invoke((ThreadStart)delegate() { TracksTreeView.Nodes.AddRange(parentNodes.ToArray()); });
                    Invoke((ThreadStart)delegate() { TracksTreeView.Enabled = true; });

                    int pointsLoaded = 0;
                    tracks.ForEach(list => pointsLoaded += list.Count);

                    Log(String.Format("{0} points loaded", pointsLoaded));

                    RightTabControl.SelectedTab = PointsTabPage;
                    if (tracks.Count > 0)
                    {
                        saveToolStripMenuItem.Enabled = true;
                        TracksTreeView.SelectedNode = TracksTreeView.Nodes[0];
                    }
                    //Invoke(new MethodInvoker(EndReadFromMemory));
                }
            }
        }

        #endregion

        #region Methods

        #region Load/Save
        private void LoadFiles(string[] filenames, bool clearFiles)
        {
            WorkProgressBar.Value = 0;

            if (filenames.Length == 1)
            {
                Log("Loading {0}", filenames[0]);
            }
            else
            {
                Log("Loading {0} files", filenames.Length);
            }

            if (clearFiles)
                TracksTreeView.Nodes.Clear();

            SetWindowTitle(Path.GetFileName(filenames[0]));

            WorkProgressBar.Minimum = 0;
            WorkProgressBar.Maximum = filenames.Length;

            currentDataOperationDoWorkHandler = DGManager.Backend.PointConverter.ParseFilesAsync;
            DataOperationBackgroundWorker.DoWork += currentDataOperationDoWorkHandler;
            DataOperationBackgroundWorker.RunWorkerAsync(new PointReaderArgs(filenames, Log, DataOperationBackgroundWorker.ReportProgress));
        }

		private void LoadPhotos(object sender, DoWorkEventArgs e)
		{
			string[] fileNames = (string[])e.Argument;

			int rowOffset = PhotosGridView.Rows.Count;

			Invoke((ThreadStart)delegate()
				{
					PhotosGridView.RowCount += fileNames.Length;
				});

			Log("Adding {0} files", fileNames.Length);

			for (int i = 0; i < fileNames.Length; i++)
			{
				string filePath = fileNames[i];
				Jpeg jpeg = JpegHelper.GetJpegFromFile(filePath);

				Invoke((ThreadStart)delegate()
				{
					PhotosGridView.Rows[rowOffset + i].Tag = jpeg;
				});

				DataOperationBackgroundWorker.ReportProgress(i + 1);
			}

			Invoke(new MethodInvoker(FillPhotosGrid));

			Log(String.Format("{0} files added", fileNames.Length));
        }
        #endregion

        #region Logging
        private delegate void LogDelegate(string message, bool isDebugMessage);

		public void Log(string message, bool isDebugMessage)
		{
			if (!isDebugMessage || Settings.IsDebug)
			{
				if (InvokeRequired)
				{
					BeginInvoke(new LogDelegate(Log), new object[] { message, isDebugMessage });

					return;
				}

				if (isDebugMessage)
				{
					LogTextBox.Text += "DEBUG: ";
				}

				LogTextBox.Text += message;
				LogTextBox.Text += Environment.NewLine;
				LogTextBox.SelectionStart = LogTextBox.Text.Length;
				LogTextBox.ScrollToCaret();
			}
		}

		public void Log(string message)
		{
			Log(message, false);
        }

        public void Log(string messageFormat, params object[] args)
        {
            Log(String.Format(messageFormat, args));
        }
        #endregion

        #region UI
        private delegate void AddNodeToTreeDelegate(TreeNodeCollection parentNodes, TreeNode node);

		private static void AddNodeToTree(TreeNodeCollection parentNodes, TreeNode node)
		{
			parentNodes.Add(node);
		}

		private void SetWindowTitle(string fileName)
		{
			Version assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
			Text = String.Format("{0} {1}.{2}", Constants.MAIN_WINDOW_TITLE, assemblyVersion.Major, assemblyVersion.Minor);

			if (!String.IsNullOrEmpty(fileName))
			{
                Text += String.Format(" - {0}", fileName);
			}
        }

		private void ReflectSettingsInUI()
		{
			Left = Settings.Left;
			Top = Settings.Top;
			Width = Settings.Width;
			Height = Settings.Height;
			LeftRightSplitContainer.SplitterDistance = Settings.TracksListWidth;
			TopBottomSplitContainer.SplitterDistance = TopBottomSplitContainer.Height - Settings.LogPanelHeight;

			switch (Settings.SpeedMeasurementSystem)
			{
				case MeasurementSystem.Metric:
					speedUnitMenuItem_Click(speedMetricToolStripMenuItem, EventArgs.Empty);
					break;
				case MeasurementSystem.Imperial:
					speedUnitMenuItem_Click(speedImperialToolStripMenuItem, EventArgs.Empty);
					break;
				case MeasurementSystem.Nautical:
					speedUnitMenuItem_Click(speedNauticalToolStripMenuItem, EventArgs.Empty);
					break;
			}

			switch (Settings.DistanceMeasurementSystem)
			{
				case MeasurementSystem.Metric:
					distanceUnitMenuItem_Click(distanceMetricToolStripMenuItem, EventArgs.Empty);
					break;
				case MeasurementSystem.Imperial:
					distanceUnitMenuItem_Click(distanceImperialToolStripMenuItem, EventArgs.Empty);
					break;
				case MeasurementSystem.Nautical:
					distanceUnitMenuItem_Click(distanceNauticalToolStripMenuItem, EventArgs.Empty);
					break;
			}

			switch (Settings.ElevationMeasurementSystem)
			{
				case MeasurementSystem.Metric:
					elevationUnitMenuItem_Click(elevationMetricToolStripMenuItem, EventArgs.Empty);
					break;
				case MeasurementSystem.Imperial:
					elevationUnitMenuItem_Click(elevationImperialToolStripMenuItem, EventArgs.Empty);
					break;
			}

			if (Settings.FullPrecision)
			{
				fullToolStripMenuItem_Click(this, EventArgs.Empty);
			}
			else
			{
				nineDigitsToolStripMenuItem_Click(this, EventArgs.Empty);
			}

			if (Settings.GMapsSmallControls)
			{
				smallControlsToolStripMenuItem_Click(this, null);
			}
			else
			{
				normalControlsToolStripMenuItem_Click(this, null);
			}

			streetMapToolStripMenuItem.Checked = Settings.GMapsMapButton;
			satelliteMapToolStripMenuItem.Checked = Settings.GMapsSatelliteButton;
			hybridMapToolStripMenuItem.Checked = Settings.GMapsHybridButton;
			terrainMapToolStripMenuItem.Checked = Settings.GMapsTerrainButton;
			overviewMapToolStripMenuItem.Checked = Settings.GMapsOverviewMap;

			switch (Settings.GMapsDefaultMapType)
			{
				case GMapType.Street:
					streetDefaultToolStripMenuItem_Click(this, null);
					break;
				case GMapType.Satellite:
					satelliteDefaultToolStripMenuItem_Click(this, null);
					break;
				case GMapType.Hybrid:
					hybridDefaultToolStripMenuItem_Click(this, null);
					break;
			}

			UtcStatusLabel.Text = String.Format("UTC {0} {1}", Settings.UtcShift < 0 ? "-" : "+", Math.Abs(Settings.UtcShift));

			automaticallyCheckForNewVersionsToolStripMenuItem.Checked = Settings.AutoCheckNewVersion;

			ReflectCameraOffsetInUI();
        }

        private void ReflectCameraOffsetInUI()
		{
            CameraOffsetHoursUpDown.ValueChanged -= CameraOffsetChanged;
            CameraOffsetMinutesUpDown.ValueChanged -= CameraOffsetChanged;
            CameraOffsetSecondsUpDown.ValueChanged -= CameraOffsetChanged;
            CameraOffsetEnabledCheckBox.CheckedChanged -= CameraOffsetChanged;
            CameraOffsetSignComboBox.SelectedValueChanged -= CameraOffsetChanged;

			CameraOffsetEnabledCheckBox.Checked = Settings.CameraOffsetEnabled;
			CameraOffsetSignComboBox.SelectedIndex = (Settings.CameraOffsetSign == TimespanSign.Positive) ? 0 : 1;
			CameraOffsetHoursUpDown.Value = Settings.CameraOffsetTimespan.Hours + Settings.CameraOffsetTimespan.Days * 24;
			CameraOffsetMinutesUpDown.Value = Settings.CameraOffsetTimespan.Minutes;
			CameraOffsetSecondsUpDown.Value = Settings.CameraOffsetTimespan.Seconds;

            CameraOffsetHoursUpDown.ValueChanged += CameraOffsetChanged;
            CameraOffsetMinutesUpDown.ValueChanged += CameraOffsetChanged;
            CameraOffsetSecondsUpDown.ValueChanged += CameraOffsetChanged;
            CameraOffsetEnabledCheckBox.CheckedChanged += CameraOffsetChanged;
            CameraOffsetSignComboBox.SelectedValueChanged += CameraOffsetChanged;
		}

		private void RefreshPorts()
		{
			if (Port.IsOpen)
			{
				Port.Close();
			}

			string[] portNamesArray = SerialPort.GetPortNames();

			string portNames = String.Empty;

			bool iniPortExists = false;

			for (int i = 0; i < portNamesArray.Length; i++)
			{
				if (i > 0)
				{
					portNames += ", ";
				}

				portNames += portNamesArray[i];

				if (portNamesArray[i] == Settings.Port)
				{
					iniPortExists = true;
				}
			}

			if (portNamesArray.Length > 0)
			{
                Log(String.Format("Available ports: {0}", portNames), true);
				Port.PortName = iniPortExists ? Settings.Port : portNamesArray[0];
			}
			else
			{
				Log("No COM ports available. Please ensure you have installed the driver and connected the device.");
			}

            Log(String.Format("COM port: {0}", Port.PortName), true);
			PortStatusLabel.Text = Port.PortName;

			SetupPortMenu(iniPortExists);
		}

        private void FillGrid()
        {
            //
            // Get data and take early exits
            //
            TrackTreeNode trackNode = TracksTreeView.SelectedNode as TrackTreeNode;
			if (trackNode == null || TracksTreeView.Nodes.Count == 0)
				return;

            PointOfInterestList pointsOfInterest = trackNode.Track;
			if (pointsOfInterest == null || pointsOfInterest.Count == 0)
				return;

			PointOfInterest poi;

            // check to see if this set of points is already loaded
            //  (avoids triple list load after file is loaded...)
            if (pointsOfInterest == loadedPoints)
            {
                PointsListView.Invalidate();
                return;
            }
            else
                loadedPoints = pointsOfInterest;

            //
            // Reset rows & columns
            //
            PointsListView.VirtualListSize = 0;
            PointsListView.Columns.Clear();

            //
            // Setup new columns
            //
			poi = pointsOfInterest[0];

            // Column 1- Manual Marker
            ColumnHeader hdr = new ColumnHeader { Text = "Manual", Width = 60, TextAlign = HorizontalAlignment.Right };
            PointsListView.Columns.Add(hdr);

            // Column 2 - Sample number
            hdr = new ColumnHeader();
            hdr.Text = "#";
            hdr.Width = 60;
            PointsListView.Columns.Add(hdr);

            // Column 3 - Latitude
            hdr = new ColumnHeader();
            hdr.Text = "Latitude";
            hdr.Width = 105;
            PointsListView.Columns.Add(hdr);

            // Column 4 = Longitude
            hdr = new ColumnHeader();
            hdr.Text = "Longitude";
            hdr.Width = 120;
            PointsListView.Columns.Add(hdr);

            if (poi.TypePoi > 0)
            {
                // Column 5 - Time
                hdr = new ColumnHeader();
                hdr.Text = "Time";
                hdr.Width = 75;
                PointsListView.Columns.Add(hdr);

                // Column 6 - Date
                hdr = new ColumnHeader();
                hdr.Text = "Date";
                hdr.Width = 90;
                PointsListView.Columns.Add(hdr);

                // Column 7 - Speed
                hdr = new ColumnHeader();
                hdr.Text = "Speed";
                hdr.Width = 75;
                hdr.TextAlign = HorizontalAlignment.Right;
                PointsListView.Columns.Add(hdr);

                // Column 8 - Distance
                hdr = new ColumnHeader();
                hdr.Text = "Distance";
                hdr.Width = 75;
                hdr.TextAlign = HorizontalAlignment.Right;
                PointsListView.Columns.Add(hdr);

                if (poi.TypePoi > 1)
                {
                    // Column 9 - Altitude
                    hdr = new ColumnHeader();
                    hdr.Text = "Altitude";
                    hdr.Width = 75;
                    hdr.TextAlign = HorizontalAlignment.Right;
                    PointsListView.Columns.Add(hdr);
                }
            }

            //
            // Setup new rows
            //
            PointsListView.VirtualListSize = pointsOfInterest.Count;

            //
            // Auto-Resize columns
            //      Note: For ListView, ColumnContent resize style only resizes to visible
            //            content rows.  This may be a "feature" of virtual mode in that it
            //            appropriately (IMHO) avoids data for every row.
            //
            //            PointsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void FillPhotosGrid()
		{
			foreach (DataGridViewRow row in PhotosGridView.Rows)
			{
				Jpeg jpeg = (Jpeg)row.Tag;

				jpeg.OffsetDateTime = jpeg.OriginalDateTime;

				if (Settings.CameraOffsetEnabled)
				{
					if (Settings.CameraOffsetSign == TimespanSign.Positive)
					{
						jpeg.OffsetDateTime = jpeg.OffsetDateTime.Add(Settings.CameraOffsetTimespan);
					}
					else
					{
						jpeg.OffsetDateTime = jpeg.OffsetDateTime.Subtract(Settings.CameraOffsetTimespan);
					}
				}

				if (jpeg.Location != null)
				{
					row.Cells[0].ReadOnly = false;
				}
				else
				{
					row.Cells[0].Value = false;
					row.Cells[0].ReadOnly = true;
				}

                row.Cells[1].Value = (jpeg.FilePath.Length <= 50) ? jpeg.FilePath : String.Format("...{0}", jpeg.FilePath.Substring(jpeg.FilePath.Length - 47, 47));
				row.Cells[1].ToolTipText = jpeg.FilePath;
				row.Cells[2].Value = jpeg.OffsetDateTime.ToLongTimeString();
				row.Cells[3].Value = jpeg.OffsetDateTime.ToShortDateString();

				if (jpeg.Location != null)
				{
					row.Cells[4].Value = String.Format("{0:0.######}", jpeg.Location.Latitude);
					row.Cells[5].Value = String.Format("{0:0.######}", jpeg.Location.Longitude);
				}

				row.Cells[6].Value = jpeg.LocationText;
				row.Cells[6].ToolTipText = jpeg.LocationText;
			}

			PhotosGridView.AutoResizeColumns();
		}

		private void ShowInGoogleMaps()
		{
            string htmlFilePath = Path.Combine(ExeDirectoryPath, Constants.GMAPS_FILENAME);
            bool checkedNode = (GetCheckedTracks(TracksTreeView.Nodes).Count > 0);
            PointWriterArgs args = new PointWriterArgs(htmlFilePath, GetTracksToSave(), Log, null) { IncludeGMapEvents = true };
            if (!checkedNode && args.Tracks.Count > 1) return;
            args.Photos = GetSelectedPhotos();
            DGManager.Backend.PointConverter.SaveFile(args);

			Log("Loading Google Maps HTML File");

			GMapsWebBrowser.Navigate(htmlFilePath);
            _timerRefreshGoogle.Stop();
		}

		private void RefreshSelectedTabPage()
		{
			PhotosGridView.EndEdit();

			if (RightTabControl.SelectedTab == PointsTabPage)
			{
				FillGrid();
			}
			else if (RightTabControl.SelectedTab == MapTabPage)
			{
                if (_timerRefreshGoogle.Enabled)
                    _timerRefreshGoogle.Stop();
                _timerRefreshGoogle.Interval = 1000;
                _timerRefreshGoogle.Start();
            }
            else if (RightTabControl.SelectedTab == tabPagePreview)
            {
                trackPreview1.SetTracks(GetTracksToSave());
            }
            else if (RightTabControl.SelectedTab == tabPageChart)
            {
                FillChart();
            }
        }

		private void RefreshTotalCheckedPointCount()
		{
            TrackTreeNode trackNode;
			totalCheckedPointCount = 0;

			foreach (TreeNode node in GetCheckedTracks(TracksTreeView.Nodes))
                if ((trackNode = node as TrackTreeNode) != null && trackNode.Track != null)
				    totalCheckedPointCount += trackNode.Track.Count;
        }

        /// <summary>
        /// Refresh the trim controls based on the selected track
        /// </summary>
        private void RefreshTrimControls()
        {
            TrackTreeNode trackNode;
            if ((trackNode = TracksTreeView.SelectedNode as TrackTreeNode) == null) return;
            PointOfInterestList list = trackNode.Track;
            if (list == null || list.Count == 0) return;
            TrimStartTrackBar.Maximum = list.Count - 1;
            TrimStartTrackBar.Value = list.TrimStart;
            TrimEndTrackBar.Maximum = TrimStartTrackBar.Maximum;
            TrimEndTrackBar.Value = (list.TrimEnd < 0) ? TrimEndTrackBar.Maximum : list.TrimEnd;
            EnableTrimPointsCheckBox.Checked = list.IsTrimmed;
            PointsListView.Invalidate();
        }

        /// <summary>
        /// Refresh the trim values of the selected track with the values from the controls
        /// </summary>
        private void RefreshSelectedListTrim()
        {
            TrackTreeNode trackNode;
            if ((trackNode = TracksTreeView.SelectedNode as TrackTreeNode) != null)
            {
                PointOfInterestList list = trackNode.Track;
                if (list == null) return;
                list.TrimStart = TrimStartTrackBar.Value;
                list.TrimEnd = TrimEndTrackBar.Value;
                list.IsTrimmed = EnableTrimPointsCheckBox.Checked;
            }
        }

		private void UpdateProgress(object sender, ProgressChangedEventArgs e)
		{
            if (e.UserState is string && !String.IsNullOrEmpty(e.UserState.ToString()))
                Log(e.UserState.ToString());
            else
			    WorkProgressBar.Value = e.ProgressPercentage;
		}

		private void CameraOffsetChanged(object sender, EventArgs e)
		{
			Settings.CameraOffsetEnabled = CameraOffsetEnabledCheckBox.Checked;
			if (CameraOffsetSignComboBox.SelectedItem != null)
			{
				Settings.CameraOffsetSign = (TimespanSign)((string)CameraOffsetSignComboBox.SelectedItem)[0];
			}
			Settings.CameraOffsetTimespan = new TimeSpan((int)CameraOffsetHoursUpDown.Value, (int)CameraOffsetMinutesUpDown.Value, (int)CameraOffsetSecondsUpDown.Value);
		}

        private void RefreshTreeText()
        {
            RefreshTreeText(TracksTreeView.Nodes);
        }

        private void RefreshTreeText(TreeNodeCollection nodes)
        {
            TrackTreeNode trackNode;
            foreach (TreeNode node in nodes)
            {
                if ((trackNode = node as TrackTreeNode) != null)
                    node.Text = String.Format("({0:000}) {1}", node.Index + 1, trackNode.Track.DisplayName);
                else if (node.Nodes.Count > 0)
                    RefreshTreeText(node.Nodes);
            }
        }

        private void FillChart()
        {
            zedGraphControl.GraphPane.Title.Text = String.Format("{0} Altitude/Distance", TracksTreeView.SelectedNode.Text);
            zedGraphControl.GraphPane.XAxis.Title.Text = "Distance";
            //zedGraphControl.GraphPane.XAxis.Type = ZedGraph.AxisType.Date;
            zedGraphControl.GraphPane.YAxis.Title.Text = "Altitude";
            ZedGraph.PointPairList points = new ZedGraph.PointPairList();
            TrackTreeNode trackNode = TracksTreeView.SelectedNode as TrackTreeNode;
            if (trackNode == null) return;
            foreach (PointOfInterest point in trackNode.Track)
                if (point.Altitude != null && point.Altitude.HasValue && point.Distance != null && point.Distance.HasValue)
                    points.Add(point.Distance.GetValue(Settings.DistanceMeasurementSystem), point.Altitude.GetValue(Settings.ElevationMeasurementSystem));
            zedGraphControl.GraphPane.CurveList.Clear();
            zedGraphControl.GraphPane.AddCurve("Altitude", points, Color.Blue, ZedGraph.SymbolType.None);
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }

        private void RemoveSelectedNodes()
        {
            Queue<TreeNode> removeNodes = new Queue<TreeNode>(TracksTreeView.SelectedNodes);
            while (removeNodes.Count > 0)
                removeNodes.Dequeue().Remove();
            RefreshTreeText();
            RefreshSelectedTabPage();
        }
        #endregion

        #region Tracks
        private void GenerateLogicalTracks()
		{
            // TODO Add parameter for node collection to allow for structured tree
            PointsListView.VirtualListSize = 0;
			TracksTreeView.Nodes.Clear();
			DateTime prevWhen = DateTime.MinValue;

			for (int i = 0; i < AllPoints.Count; i++)
			{
				PointOfInterest poi = AllPoints[i];

				//if new track
				if (poi.When.Subtract(prevWhen).TotalMinutes > Settings.NewTrackThresholdMins)
				{
					TrackTreeNode node = new TrackTreeNode(String.Format("({0:000}) {1}", TracksTreeView.Nodes.Count + 1, poi.When.AddHours(Settings.UtcShift).ToString(Settings.TimeDisplayFormat)));
					//node.Checked = true;
					node.Track = new PointOfInterestList();
					TracksTreeView.Nodes.Add(node);
				}

				((TrackTreeNode)TracksTreeView.Nodes[TracksTreeView.Nodes.Count - 1]).Track.Add(poi);

				prevWhen = poi.When;
			}
            RefreshTreeText();
		}

		/*
		Say for example you set the DG-100 to record points every 10 seconds. 
		A manual point would be recorded within one of the 10 second time windows.

		A 12:00:10
		B 12:00:20
		C 12:00:23 <- manual point
		D 12:00:30
		E 12:00:40

		If (C-B) is not equal to (B-A) and (B-A) is the same as (E-D) and (D-C) is equal to ((B-A) - (C-B)), then C is determined to be a manual point.

		In this case 3 is not equal to 10, 10 is the same as 10 and 7 is equal to (10 - 3).
		 */
		private void GuessManualPoints()
		{
            Collection<PointOfInterestList> tracks = GetAllTracks(TracksTreeView.Nodes);
			for (int i = 0; i < tracks.Count; i++)
			{
				PointOfInterestList poiList = tracks[i];

				if (poiList.Count >= 5)
				{
					for (int j = 2; j < poiList.Count - 2; j++)
					{
						int prevTimeGap = (int)poiList[j - 1].When.Subtract(poiList[j - 2].When).TotalSeconds;
						int currentTimeGap = (int)poiList[j].When.Subtract(poiList[j - 1].When).TotalSeconds;
						int nextTimeGap = (int)poiList[j + 1].When.Subtract(poiList[j].When).TotalSeconds;
						int nextNextTimeGap = (int)poiList[j + 2].When.Subtract(poiList[j + 1].When).TotalSeconds;

						if (currentTimeGap != prevTimeGap &&
							 currentTimeGap < prevTimeGap &&
							 prevTimeGap == nextNextTimeGap &&
							 nextTimeGap == (prevTimeGap - currentTimeGap))
						{
							poiList[j].IsManual = true;
							Log(
								String.Format("Lat = {0} Long = {1} secs = {2} prevSecs={3}", poiList[j].Latitude, poiList[j].Longitude, currentTimeGap,
												  prevTimeGap), true);

						}
					}
				}
			}
        }

        private static Collection<TreeNode> GetCheckedTracks(TreeNodeCollection nodes)
        {
            return GetCheckedTracks(nodes, false);
        }

        private static Collection<TreeNode> GetCheckedTracks(TreeNodeCollection nodes, bool parentChecked)
        {
            List<TreeNode> checkNodes = new List<TreeNode>();
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                    checkNodes.Add(node);
                if (node.Nodes.Count > 0)
                    checkNodes.AddRange(GetCheckedTracks(node.Nodes, parentChecked || node.Checked));
            }
            return new Collection<TreeNode>(checkNodes);
        }

        /// <summary>
        /// AlaskanShade: This function is currently used only be the preview tab, but can be used by all of the save methods.
        /// </summary>
        /// <returns></returns>
        private Collection<PointOfInterestList> GetTracksToSave()
        {
            return GetTracksToSave(TracksTreeView.Nodes);
        }

        private Collection<PointOfInterestList> GetTracksToSave(TreeNodeCollection nodes)
        {
            Collection<TreeNode> checkedNodes = GetCheckedTracks(nodes);
            if (checkedNodes.Count == 0)
                return GetAllTracks(nodes);
            Collection<PointOfInterestList> tracks = new Collection<PointOfInterestList>();
            TrackTreeNode trackNode;
            foreach (TreeNode node in checkedNodes)
            {
                if ((trackNode = node as TrackTreeNode) != null)
                    tracks.Add(trackNode.Track);
            }
            return tracks;
        }

        private static Collection<PointOfInterestList> GetAllTracks(TreeNodeCollection nodes)
        {
            List<PointOfInterestList> tracks = new List<PointOfInterestList>();
            TrackTreeNode trackNode;
            foreach (TreeNode node in nodes)
            {
                if ((trackNode = node as TrackTreeNode) != null)
                    tracks.Add(trackNode.Track);
                if (node.Nodes.Count > 0)
                    tracks.AddRange(GetAllTracks(node.Nodes));
            }
            return new Collection<PointOfInterestList>(tracks);
        }

        private void ReloadAllPoints(Collection<PointOfInterestList> tracks)
        {
            AllPoints.Clear();
            foreach (PointOfInterestList track in tracks)
                foreach (PointOfInterest poi in track)
                    AllPoints.Add(poi);
            AllPoints.Sort(PointOfInterest.ComparePointsByDate);
        }

        /// <summary>
        /// Get the node collection that contains the given TreeNode
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static TreeNodeCollection GetNodeCollection(TreeNode node)
        {
            if (node.Parent != null)
                return node.Parent.Nodes;
            return node.TreeView.Nodes;
        }

        private static TreeNode SplitTrack(TrackTreeNode selectedNode, int splitPoint)
        {
            PointOfInterestList track = selectedNode.Track;
            PointOfInterestList newTrack = new PointOfInterestList();
            if (splitPoint >= track.Count - 1) return null;
            PointOfInterest split = track[splitPoint].Clone() as PointOfInterest;
            double distanceOffset = (split.Distance != null && split.Distance.HasValue) ? split.Distance.GetValue(0.0) : 0.0;
            while (track.Count > splitPoint)
            {
                newTrack.Add(track[splitPoint]);
                if (track[splitPoint].Distance != null && track[splitPoint].Distance.HasValue)
                    track[splitPoint].Distance.SetValue(track[splitPoint].Distance.GetValue() - distanceOffset);
                track.RemoveAt(splitPoint);
            }
            track.Add(split);
            TrackTreeNode node = new TrackTreeNode("") { Track = newTrack };
            node.Text = String.Format("({0:000}) {1}", node.Index + 1, newTrack.DisplayName);
            GetNodeCollection(selectedNode).Insert(selectedNode.Index + 1, node);
            track.TrimStart = 0;
            track.TrimEnd = -1;
            track.IsTrimmed = false;
            node.Checked = true;
            return node;
        }
        #endregion

        private void EndReadFromMemory()
		{
			PointOfInterestList pointsOfInterest;
			//DateTime when;
			string s;

			TracksTreeView.Enabled = true;

			TrimStartTrackBar.Value = 0;
			TrimEndTrackBar.Value = TrimEndTrackBar.Maximum;

			if (Settings.GuessManualPoints)
			{
				GuessManualPoints();
			}

			if (TracksTreeView.Nodes.Count > 0)
			{
                saveToolStripMenuItem.Enabled = true;
				TracksTreeView.SelectedNode = TracksTreeView.Nodes[0];
				TracksTreeView_AfterSelect(this, null);

                // TODO Make this part recursive to allow for tree structure
				for (int i = 0; i < TracksTreeView.Nodes.Count; i++)
				{
					pointsOfInterest = ((TrackTreeNode)TracksTreeView.Nodes[i]).Track;
					//when = pointsOfInterest[0].When;
                    //if (when != DateTime.MinValue)
    				//	when = when.AddHours(Settings.UtcShift);
                    //if (String.IsNullOrEmpty(pointsOfInterest.ListName))
					//    s = String.Format("({0:000}) {1:MM}/{1:dd}/{1:yyyy} {1:hh}:{1:mm} ", i + 1, when);
                    //else
    					s = String.Format("({0:000}) {1}", i+1, pointsOfInterest.DisplayName);
					TracksTreeView.Nodes[i].Text = s;
				}
			}

			RightTabControl.SelectedTab = PointsTabPage;
			FillGrid();
        }

        #region DG-100
		private void InterpretLastSentence()
		{
			byte[] buffer = new byte[2097];
			byte[] payload = new byte[2097];

			int plLength;
			int nData;
			int rLength;
			byte command;
			int d, t;
			string s, tds, ls;
			byte[] headerRequest = new byte[13];
			byte[] fileRequest = new byte[13];
			int cksum;
			int ah, al;
			byte[] setBytes = new byte[50];
			int fj, fm, fa, fh, fn, fs;
			DateTime dateTime = DateTime.MinValue;

			for (int i = 0; i <= 1040; i++)
			{
				buffer[i] = lastSentence[i];
			}

			if (lastSentenceSize < 3)
			{
				Log("ERROR : not enough data");
				return;
			}

			plLength = buffer[2] * 256 + buffer[3];

			//Log("PLLength: " + plLength, true);

			if (lastSentenceSize < plLength)
			{
				Log(String.Format("ERROR : data too short ({0} < {1})", lastSentenceSize, plLength));
				return;
			}

			for (int j = 0; j < plLength; j++)
			{
				payload[j] = buffer[j + 4];
			}

			command = payload[0];

			switch (command)
			{
				case 0xB7: //Get Config
					//response to set config
					if (plLength == 5)
					{
						if (payload[5] == 1 || payload[4] == 1)
						{
							Log("Configuration updated successfully. Please reboot the device.");
						}
						else
						{
							Log("An error occurred while updating the configuration.");
						}
						return;
					}

					Log("Configuration received");
					DeviceConfig.Config = InterpretDeviceConfig(payload);

					if (DeviceConfig.ShowDialog() == DialogResult.OK)
					{
						setBytes = GenerateDeviceConfigBytes(DeviceConfig.Config);
						Log("Sending new configuration to device.");
						Port.Write(setBytes, 0, 50);
					}
					break;
				case 0xB8: //Set Config
					Log("Set Configuration");
					break;
				case 0xBF: //Get Ident
					Log(String.Format("Get Identification ({0}):", plLength));
					Log(ByteArrayToHexString(payload, plLength));
					break;
				case 0xC0: //Set Ident
					break;
				case 0xBB: //Headers
					Log(String.Format("Get Headers ({0}):", plLength));
					rLength = 12;
					nData = payload[1] * 256 + payload[2];
					Log(String.Format("Got {0} Headers", nData));
					Log(String.Format("({0} bytes)", nData * rLength), true);
					//Log(ByteArrayToHexString(payload, plLength), true);

					if (nData > 85)
					{
						nData = 85;
					}


					for (int i = 0; i < nData; i++)
					{
						ls = String.Empty;
						t = payload[3 + 2 + i * rLength] * 256 * 256 * 256 +
							 payload[3 + 3 + i * rLength] * 256 * 256 +
							 payload[3 + 4 + i * rLength] * 256 +
							 payload[3 + 5 + i * rLength];
						d = payload[3 + 6 + i * rLength] * 256 * 256 * 256 +
							 payload[3 + 7 + i * rLength] * 256 * 256 +
							 payload[3 + 8 + i * rLength] * 256 +
							 payload[3 + 9 + i * rLength];
						tds = d.ToString().PadLeft(6, '0');
                        ls += String.Format("{0}/{1}/20{2} ", tds.Substring(0, 2), tds.Substring(2, 2), tds.Substring(4, 2));
						tds = t.ToString().PadLeft(6, '0');
                        ls += String.Format("{0}:{1}:{2}", tds.Substring(0, 2), tds.Substring(2, 2), tds.Substring(4, 2));
						fj = Convert.ToInt32(ls.Substring(0, 2));
						fm = Convert.ToInt32(ls.Substring(3, 2));
						fa = Convert.ToInt32(ls.Substring(6, 4));
						fh = Convert.ToInt32(ls.Substring(11, 2));
						fn = Convert.ToInt32(ls.Substring(14, 2));
						fs = Convert.ToInt32(ls.Substring(17, 2));

						try
						{
							dateTime = new DateTime(fa, fm, fj, fh, fn, fs);
						}
						catch (ArgumentException)
						{
                            Log(String.Format("Wrong date/time format: {0}", ls));
						}

						//if we're only downloading the latest tracks, check the date
						if (!oldestDesiredTrackDateUtc.HasValue || dateTime >= oldestDesiredTrackDateUtc)
						{
							if (FileNum == -1)
							{
								FileNum = lastHeader + i;
							}

							if (Settings.TrackMode == TrackMode.GlobalSat)
							{
								s = String.Format("({0:000}) {1:}", lastHeader + i + 1, dateTime.ToString(Settings.TimeDisplayFormat));

                                TrackTreeNode newNode = new TrackTreeNode(s) { Track = new PointOfInterestList() };
								//newNode.Checked = true;
								BeginInvoke(new AddNodeToTreeDelegate(AddNodeToTree), new object[] { TracksTreeView.Nodes, newNode });
							}
						}
					}

					if (nData > 0)
					{
						lastHeader = lastHeader + nData;
						ah = (lastHeader & 0xFF00) >> 8;
						al = lastHeader & 0x00FF;
						headerRequest = new byte[] { 0xA0, 0xA2, 0x00, 0x03, 0xBB, 0x00, 0x00, 0x00, 0xBB, 0xB0, 0xB3 };
						headerRequest[5] = Convert.ToByte(ah);
						headerRequest[6] = Convert.ToByte(al);
						cksum = 0xBB + ah + al;
						ah = (cksum & 0xFF00) >> 8;
						al = cksum & 0x00FF;
						headerRequest[7] = Convert.ToByte(ah);
						headerRequest[8] = Convert.ToByte(al);
						Log("Requesting Header " + (lastHeader + 1));
						trackNum = 0;
						Port.Write(headerRequest, 0, 11);
					}
					else
					{
						if (lastHeader == 0)
						{
							Log("No more headers, no tracks");
						}
						else
						{
							if (FileNum == -1)
							{
								Log(String.Format("{0} tracks were found, but none of them were created within the last {1} days", lastHeader, Settings.DownloadLatestTracksLastDays));
								return;
							}

							Log("No more headers, getting tracks");

							BeginInvoke((ThreadStart)delegate()
												{
													WorkProgressBar.Minimum = FileNum;
													WorkProgressBar.Maximum = lastHeader;
													WorkProgressBar.Value = FileNum;
												});

							AllPoints.Clear();

							Log("Requesting Track " + (FileNum + 1));

							ah = (FileNum & 0xFF00) >> 8;
							al = FileNum & 0x00FF;
							fileRequest = new byte[] { 0xA0, 0xA2, 0x00, 0x03, 0xB5, 0x00, 0x00, 0x00, 0xB5, 0xB0, 0xB3 };
							fileRequest[5] = Convert.ToByte(ah);
							fileRequest[6] = Convert.ToByte(al);
							cksum = 0xB5 + ah + al;
							ah = (cksum & 0xFF00) >> 8;
							al = cksum & 0x00FF;
							fileRequest[7] = Convert.ToByte(ah);
							fileRequest[8] = Convert.ToByte(al);
							Port.Write(fileRequest, 0, 11);
						}
					}
					break;
				case 0xB5: //Files
					//Log("Received data for file " + FileNum, true);
					rLength = 1024;
					nData = rLength;

					if (trackNum == 0)
					{
						//Log("Received first half", true);
						//Log(ByteArrayToHexString(payload, rLength), true);

						trackNum = nData;

						for (int i = 0; i < nData; i++)
						{
							trackData[i] = payload[i + 1];
						}

						for (int i = nData; i < 2097; i++)
						{
							trackData[i] = Constants.ASCII_20;
						}
					}
					else
					{
						//Log("Received second half", true);

						for (int i = 0; i < nData; i++)
						{
							trackData[i + trackNum] = payload[i + 1];
						}

						trackNum = 0;

						InterpretTrack();

						BeginInvoke((ThreadStart)delegate()
												{
													WorkProgressBar.Value = FileNum;
												});

						FileNum++;

						if (FileNum < lastHeader)
						{
                            Log(String.Format("Requesting Track {0}", (FileNum + 1)));

							ah = (FileNum & 0xFF00) >> 8;
							al = FileNum & 0x00FF;
							fileRequest = new byte[] { 0xA0, 0xA2, 0x00, 0x03, 0xB5, 0x00, 0x00, 0x00, 0xB5, 0xB0, 0xB3 };
							fileRequest[5] = Convert.ToByte(ah);
							fileRequest[6] = Convert.ToByte(al);
							cksum = 0xB5 + ah + al;
							ah = (cksum & 0xFF00) >> 8;
							al = cksum & 0x00FF;
							fileRequest[7] = Convert.ToByte(ah);
							fileRequest[8] = Convert.ToByte(al);
							Port.Write(fileRequest, 0, 11);
						}
						else
						{
							if (Settings.TrackMode == TrackMode.Logical)
							{
								BeginInvoke(new MethodInvoker(GenerateLogicalTracks));
							}

							BeginInvoke(new MethodInvoker(EndReadFromMemory));

							Log("Done");
						}
					}

					break;
				case 0xBA: //Clear memory
					if (payload[5] == 1 || payload[4] == 1)
					{
						Log("Memory erased successfully.");
					}
					else
					{
						Log("An error occurred while erasing the memory.");
					}
					break;
				case 0xBC: //GPS Mouse Started
					Log("GPS mouse command received successfully.");
					Log(ByteArrayToHexString(lastSentence, lastSentenceSize), true);
					Port.Close();

					BeginInvoke((ThreadStart)delegate()
										{
											if (startToolStripMenuItem.Enabled)
											{
												startToolStripMenuItem.Enabled = false;
												stopToolStripMenuItem.Enabled = true;
											}
											else
											{
												startToolStripMenuItem.Enabled = true;
												stopToolStripMenuItem.Enabled = false;
											}
										});

					break;
				default:
					Log(String.Format("Unknown data ({0}):", plLength));
					Log(ByteArrayToHexString(payload, plLength));
					Log("From sentence:");
					Log(ByteArrayToHexString(lastSentence, lastSentenceSize));
					break;
			}
		}

		private void InterpretTrack()
		{
			byte[] firstTrack = new byte[32];
			byte[] nTrack = new byte[32];
			int n;
			PointOfInterest firstPoi;
			PointOfInterest poi = null;
			int tSize;
			PointOfInterestList poiList = null;
			bool allFF;
			bool all20;

			for (int i = 0; i < 32; i++)
			{
				firstTrack[i] = trackData[i];
			}

			firstPoi = InterpretFormatC(firstTrack);

			switch (firstPoi.TypePoi)
			{
				case 0:
					tSize = 8;
					break;
				case 1:
					tSize = 20;
					break;
				case 2:
					tSize = 32;
					break;
				default:
					Log("ERROR: unknown POI type " + firstPoi.TypePoi);
					return;
			}

			if (Settings.TrackMode == TrackMode.GlobalSat)
			{
                //TODO Evaluate another way to get this node
                TrackTreeNode node = TracksTreeView.Nodes[FileNum - lastHeader + TracksTreeView.Nodes.Count] as TrackTreeNode;
				poiList = node.Track;
				poiList.Add(firstPoi);
			}

			AllPoints.Add(firstPoi);

			int rem;
			n = Math.DivRem(2047 - 32, tSize, out rem);

			int pointCount = 0;

			for (int i = 0; i <= n; i++)
			{
				allFF = true;
				all20 = true;

				for (int j = 0; j < tSize; j++)
				{
					nTrack[j] = trackData[32 + i * tSize + j];

					if (j <= 4)
					{
						allFF = allFF && (nTrack[j] == 0xFF);
						all20 = all20 && (nTrack[j] == 0x20);
					}
				}

				if (allFF || all20)
				{
					continue;
				}

				switch (firstPoi.TypePoi)
				{
					case 0:
						poi = InterpretFormatA(nTrack);
						break;
					case 1:
						poi = InterpretFormatB(nTrack);
						break;
					case 2:
						poi = InterpretFormatC(nTrack);
						break;
				}

				if ((firstPoi.TypePoi == 1 || firstPoi.TypePoi == 2) && poi.When != DateTime.MinValue)
				{
					if (Settings.TrackMode == TrackMode.GlobalSat)
					{
						poiList.Add(poi);
					}

					AllPoints.Add(poi);

					pointCount++;
				}
			}

			Log(String.Format("{0} points in track {1}", pointCount, FileNum + 1));
		}

		private static PointOfInterest InterpretFormatA(byte[] track)
		{
            PointOfInterest poi = new PointOfInterest { };

			double t = track[0] * 256 * 256 * 256 +
				 track[1] * 256 * 256 +
				 track[2] * 256 +
				 track[3];

			double d = t / 1000000;
			d = Math.Truncate(d) + (d - Math.Truncate(d)) / 0.6;

			poi.Latitude = d;

			t = track[4] * 256 * 256 * 256 +
				 track[5] * 256 * 256 +
				 track[6] * 256 +
				 track[7];

			d = t / 1000000;
			d = Math.Truncate(d) + (d - Math.Truncate(d)) / 0.6;

			poi.Longitude = d;

			poi.Altitude = new ElevationMeasurement();

			poi.TypePoi = 0;

			return poi;
		}

		private PointOfInterest InterpretFormatB(byte[] track)
		{
			double td;
			string s, ts;
			PointOfInterest poi = new PointOfInterest();
			int fj, fm, fa, fh, fn, fs;

			double t = track[0] * 256 * 256 * 256 +
				 track[1] * 256 * 256 +
				 track[2] * 256 +
				 track[3];

			double d = t / 1000000;
			d = Math.Truncate(d) + (d - Math.Truncate(d)) / 0.6;

			poi.Latitude = d;

			t = track[4] * 256 * 256 * 256 +
				 track[5] * 256 * 256 +
				 track[6] * 256 +
				 track[7];

			d = t / 1000000;
			d = Math.Truncate(d) + (d - Math.Truncate(d)) / 0.6;

			poi.Longitude = d;

			t = track[8] * 256 * 256 * 256 +
				 track[9] * 256 * 256 +
				 track[10] * 256 +
				 track[11];

			td = track[12] * 256 * 256 * 256 +
				  track[13] * 256 * 256 +
				  track[14] * 256 +
				  track[15];

			s = td.ToString().PadLeft(6, '0');

            ts = String.Format("{0}/{1}/20{2} ", s.Substring(0, 2), s.Substring(2, 2), s.Substring(4, 2));
			s = t.ToString().PadLeft(6, '0');
            ts += String.Format("{0}:{1}:{2}", s.Substring(0, 2), s.Substring(2, 2), s.Substring(4, 2));

			fj = Convert.ToInt32(ts.Substring(0, 2));
			fm = Convert.ToInt32(ts.Substring(3, 2));
			fa = Convert.ToInt32(ts.Substring(6, 4));
			fh = Convert.ToInt32(ts.Substring(11, 2));
			fn = Convert.ToInt32(ts.Substring(14, 2));
			fs = Convert.ToInt32(ts.Substring(17, 2));

			poi.When = DateTime.MinValue;

			try
			{
				poi.When = new DateTime(fa, fm, fj, fh, fn, fs);
			}
			catch (ArgumentException)
			{
                Log(String.Format("Wrong date/time format: {0}", ts));
			}

			t = track[16] * 256 * 256 * 256 +
				 track[17] * 256 * 256 +
				 track[18] * 256 +
				 track[19];

			d = t / 100;

			poi.TypePoi = 1;

			poi.Speed = new SpeedMeasurement(d);
			poi.Name = poi.Speed.ToString(Settings.SpeedMeasurementSystem);

			poi.Altitude = new ElevationMeasurement();

			return poi;
		}

		private PointOfInterest InterpretFormatC(byte[] track)
		{
			double t, td;
			string s, ts;
			double d;
            PointOfInterest poi = new PointOfInterest();
			int fj, fm, fa, fh, fn, fs;

			t = track[0] * 256 * 256 * 256 +
				 track[1] * 256 * 256 +
				 track[2] * 256 +
				 track[3];

			d = t / 1000000;
			d = Math.Truncate(d) + (d - Math.Truncate(d)) / 0.6;

			poi.Latitude = d;

			t = track[4] * 256 * 256 * 256 +
				 track[5] * 256 * 256 +
				 track[6] * 256 +
				 track[7];

			d = t / 1000000;
			d = Math.Truncate(d) + (d - Math.Truncate(d)) / 0.6;

			poi.Longitude = d;

			t = track[8] * 256 * 256 * 256 +
				 track[9] * 256 * 256 +
				 track[10] * 256 +
				 track[11];

			td = track[12] * 256 * 256 * 256 +
				  track[13] * 256 * 256 +
				  track[14] * 256 +
				  track[15];

			s = td.ToString().PadLeft(6, '0');

            ts = String.Format("{0}/{1}/20{2} ", s.Substring(0, 2), s.Substring(2, 2), s.Substring(4, 2));
			s = t.ToString().PadLeft(6, '0');
            ts += String.Format("{0}:{1}:{2}", s.Substring(0, 2), s.Substring(2, 2), s.Substring(4, 2));

			fj = Convert.ToInt32(ts.Substring(0, 2));
			fm = Convert.ToInt32(ts.Substring(3, 2));
			fa = Convert.ToInt32(ts.Substring(6, 4));
			fh = Convert.ToInt32(ts.Substring(11, 2));
			fn = Convert.ToInt32(ts.Substring(14, 2));
			fs = Convert.ToInt32(ts.Substring(17, 2));

			poi.When = DateTime.MinValue;

			try
			{
				poi.When = new DateTime(fa, fm, fj, fh, fn, fs);
			}
			catch (ArgumentException)
			{
				Log("Wrong date/time format: " + ts);
			}

			t = track[16] * 256 * 256 * 256 +
				 track[17] * 256 * 256 +
				 track[18] * 256 +
				 track[19];

			d = t / 100;

			poi.Speed = new SpeedMeasurement(d);
			poi.Name = poi.Speed.ToString(Settings.SpeedMeasurementSystem);

			t = track[20] * 256 * 256 * 256 +
				 track[21] * 256 * 256 +
				 track[22] * 256 +
				 track[23];

			d = t / 10000;

			poi.Altitude = new ElevationMeasurement(d);

			poi.TypePoi = track[31];

			return poi;
		}

		private DeviceConfig InterpretDeviceConfig(byte[] data)
		{
			DeviceConfig config = new DeviceConfig();

			if (data[0] != 0xB7)
			{
				Log("Returned configuration invalid");
				config.LogFormat = DGManager.Backend.DeviceConfig.LogFormatType.Invalid;
				return config;
			}

			config.LogFormat = (DeviceConfig.LogFormatType)data[1];

			switch (config.LogFormat)
			{
				case DGManager.Backend.DeviceConfig.LogFormatType.Pos:
					Log("Position only");
					break;
				case DGManager.Backend.DeviceConfig.LogFormatType.PosDateSpeed:
					Log("Position, speed and date/time");
					break;
				case DGManager.Backend.DeviceConfig.LogFormatType.PosDateSpeedAltitude:
					Log("Position, speed, date/time and altitude");
					break;
			}

			config.SpeedThresholdEnabled = Convert.ToBoolean(data[2]);
			config.SpeedThreshold = (data[3] * 256 * 256 * 256 +
										 data[4] * 256 * 256 +
										 data[5] * 256 +
										 data[6]) / 100;

			config.DistanceThresholdEnabled = Convert.ToBoolean(data[7]);
			config.DistanceThreshold = data[8] * 256 * 256 * 256 +
											 data[9] * 256 * 256 +
											 data[10] * 256 +
											 data[11];

			config.ModeATimeInterval = data[12] * 256 * 256 * 256 +
								data[13] * 256 * 256 +
								data[14] * 256 +
								data[15];
			config.ModeBTimeInterval = data[16] * 256 * 256 * 256 +
								data[17] * 256 * 256 +
								data[18] * 256 +
								data[19];
			config.ModeCTimeInterval = data[20] * 256 * 256 * 256 +
								data[21] * 256 * 256 +
								data[22] * 256 +
								data[23];

			config.ModeAIsByDistance = Convert.ToBoolean(data[26]);
			config.ModeBIsByDistance = Convert.ToBoolean(data[27]);
			config.ModeCIsByDistance = Convert.ToBoolean(data[28]);

			config.ModeADistanceInterval = data[29] * 256 * 256 * 256 +
										data[30] * 256 * 256 +
										data[31] * 256 +
										data[32];

			config.ModeBDistanceInterval = data[33] * 256 * 256 * 256 +
										data[34] * 256 * 256 +
										data[35] * 256 +
										data[36];

			config.ModeCDistanceInterval = data[37] * 256 * 256 * 256 +
										data[38] * 256 * 256 +
										data[39] * 256 +
										data[40];

			config.MemoryUsage = data[42];

			return config;
		}

		private static byte[] GenerateDeviceConfigBytes(DeviceConfig config)
		{
			byte[] data = new byte[50];

			byte b1, b2, b3, b4;

			data[0] = 0xA0;
			data[1] = 0xA2;
			data[2] = 0x00;
			data[3] = 0x2A;
			data[4] = 0xB8;

			data[5 + 0] = Convert.ToByte(config.LogFormat);
			data[5 + 1] = Convert.ToByte(config.SpeedThresholdEnabled);

			IntToBytes(config.SpeedThreshold * 100, out b1, out b2, out b3, out b4);

			data[5 + 2] = b1;
			data[5 + 3] = b2;
			data[5 + 4] = b3;
			data[5 + 5] = b4;

			data[5 + 6] = Convert.ToByte(config.DistanceThresholdEnabled);

			IntToBytes(config.DistanceThreshold, out b1, out b2, out b3, out b4);

			data[5 + 7] = b1;
			data[5 + 8] = b2;
			data[5 + 9] = b3;
			data[5 + 10] = b4;

			IntToBytes(config.ModeATimeInterval, out b1, out b2, out b3, out b4);

			data[5 + 11] = b1;
			data[5 + 12] = b2;
			data[5 + 13] = b3;
			data[5 + 14] = b4;

			IntToBytes(config.ModeBTimeInterval, out b1, out b2, out b3, out b4);

			data[5 + 15] = b1;
			data[5 + 16] = b2;
			data[5 + 17] = b3;
			data[5 + 18] = b4;

			IntToBytes(config.ModeCTimeInterval, out b1, out b2, out b3, out b4);

			data[5 + 19] = b1;
			data[5 + 20] = b2;
			data[5 + 21] = b3;
			data[5 + 22] = b4;

			//23 & 24 not used (but 23 has to be set to 1???)
			data[5 + 23] = 1;

			data[5 + 25] = Convert.ToByte(config.ModeAIsByDistance);
			data[5 + 26] = Convert.ToByte(config.ModeBIsByDistance);
			data[5 + 27] = Convert.ToByte(config.ModeCIsByDistance);

			IntToBytes(config.ModeADistanceInterval, out b1, out b2, out b3, out b4);

			data[5 + 28] = b1;
			data[5 + 29] = b2;
			data[5 + 30] = b3;
			data[5 + 31] = b4;

			IntToBytes(config.ModeBDistanceInterval, out b1, out b2, out b3, out b4);

			data[5 + 32] = b1;
			data[5 + 33] = b2;
			data[5 + 34] = b3;
			data[5 + 35] = b4;

			IntToBytes(config.ModeCDistanceInterval, out b1, out b2, out b3, out b4);

			data[5 + 36] = b1;
			data[5 + 37] = b2;
			data[5 + 38] = b3;
			data[5 + 39] = b4;

			data[5 + 40] = 0x00;

			ushort crc = 0;

			for (int i = 4; i <= 45; i++)
			{
				crc += data[i];
			}

			data[5 + 40 + 1] = Convert.ToByte((crc & 0xFF00) >> 8);
			data[5 + 40 + 2] = Convert.ToByte(crc & 0xFF);

			data[5 + 40 + 3] = 0xB0;
			data[5 + 40 + 4] = 0xB3;

			return data;
		}

		private static void IntToBytes(int integer, out byte b1, out byte b2, out byte b3, out byte b4)
		{
			b1 = Convert.ToByte((integer & 0xFF000000) >> 24);
			b2 = Convert.ToByte((integer & 0x00FF0000) >> 16);
			b3 = Convert.ToByte((integer & 0x0000FF00) >> 08);
			b4 = Convert.ToByte((integer & 0x000000FF));
		}

		private void SetupPortMenu(bool iniPortExists)
		{
			portToolStripMenuItem.DropDownItems.Clear();

			ToolStripMenuItem portMenuItem = new ToolStripMenuItem("Refresh");
            portMenuItem.Click += refreshPortsItem_Click;
			portToolStripMenuItem.DropDownItems.Add(portMenuItem);

			List<string> portNames = new List<string>(SerialPort.GetPortNames());

            portNames.ForEach(delegate(string portName)
            {
                portMenuItem = new ToolStripMenuItem(portName);
                if (portName == Settings.Port || (!iniPortExists && portName == Port.PortName))
                    portMenuItem.Checked = true;
                portMenuItem.Tag = "Radio";
                portMenuItem.Click += portMenuItem_Click;
                portToolStripMenuItem.DropDownItems.Add(portMenuItem);
            });
		}

        //private static string ByteArrayToHexString(byte[] byteArray)
        //{
        //    return ByteArrayToHexString(byteArray, byteArray.Length);
        //}

		private static string ByteArrayToHexString(byte[] byteArray, int length)
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < length && i < byteArray.Length; i++)
			{
				if (i > 0)
				{
					sb.Append(", ");
				}

				sb.Append(Convert.ToString(byteArray[i], 16).ToUpperInvariant().PadLeft(2, '0'));
			}

			return sb.ToString();
        }
 
		private void StartDownloadingTracks()
		{
			if (!Port.IsOpen)
			{
				Port.Open();
			}

			byte[] command = new byte[] { 0xA0, 0xA2, 0x00, 0x03, 0xBB, 0x00, 0x00, 0x00, 0xBB, 0xB0, 0xB3 };
			Log("Get Headers");
			lastHeader = 0;
			FileNum = -1;

            PointsListView.VirtualListSize = 0;
			TracksTreeView.Nodes.Clear();
			TracksTreeView.Enabled = false;
			Port.Write(command, 0, 11);

			SetWindowTitle(null);
		}

		private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			int bytesToRead = Port.BytesToRead;
			byte[] dataBytes = new byte[bytesToRead];
			Port.Read(dataBytes, 0, bytesToRead);

			//invoke randomly chokes sometimes, but without invoke the UI doesn't get updated
			//BeginInvoke(new HandleDataReceivedDelegate(HandleDataReceived), new object[] { dataBytes });
			HandleDataReceived(dataBytes);
		}

		private delegate void HandleDataReceivedDelegate(byte[] dataBytes);

		private void HandleDataReceived(byte[] dataBytes)
		{
			byte[] tempAnswer = new byte[1049];

			for (int i = 0; i < dataBytes.Length; i++)
			{
				lastAnswer[lastAnswerPos + i] = dataBytes[i];
			}

			lastAnswerPos += dataBytes.Length;

			if (lastAnswerPos > 4 && lastAnswerSize == 0)
			{
				lastAnswerSize = Convert.ToInt32(lastAnswer[2]) * 256 + Convert.ToInt32(lastAnswer[3]);
			}

			//full answer received
			if (lastAnswerPos >= lastAnswerSize + 4)
			{
				//start from end of first answer, look for end of next answer?
				for (int i = lastAnswerSize + 2; i < lastAnswerPos; i++)
				{
					//if end found
					if (lastAnswer[i] == 0xB0 && lastAnswer[i + 1] == 0xB3)
					{
						lastSentenceSize = i + 1;

						for (int j = 0; j < (lastSentenceSize + 1); j++)
						{
							lastSentence[j] = lastAnswer[j];
						}

						InterpretLastSentence();

						if (lastAnswerPos > (i + 2))
						{
							for (int j = 0; j <= 1048; j++)
							{
								tempAnswer[j] = Constants.ASCII_20;
							}

							for (int j = (i + 2); j <= lastAnswerPos; j++)
							{
								tempAnswer[j - (i + 2)] = lastAnswer[j];
							}

							for (int j = 0; j <= 1048; j++)
							{
								lastAnswer[j] = Constants.ASCII_20;
							}

							for (int j = 0; j <= (lastAnswerPos - (i + 2)); j++)
							{
								lastAnswer[j] = tempAnswer[j];
							}

							lastAnswerPos -= (i + 2);

							if ((lastAnswerPos > 1 && lastAnswer[lastAnswerPos - 2] == 0xB0 && lastAnswer[lastAnswerPos - 1] == 0xB3) ||
								 (lastAnswerPos == 1 && lastAnswer[lastAnswerPos - 1] == 0xB0 && lastAnswer[lastAnswerPos] == 0xB3))
							{
								lastSentenceSize = lastAnswerPos;

								for (int j = 0; j <= lastSentenceSize; j++)
								{
									lastSentence[j] = lastAnswer[j];
								}

								InterpretLastSentence();

								lastAnswerPos = 0;
								lastAnswerSize = 0;

								for (int j = 0; j <= 1048; j++)
								{
									lastAnswer[j] = Constants.ASCII_20;
								}
							}
						}
						else
						{
							lastAnswerPos = 0;
							lastAnswerSize = 0;

							for (int j = 0; j <= 1048; j++)
							{
								lastAnswer[j] = Constants.ASCII_20;
							}
						}
					}
				}
			}
		}
        #endregion

        #region New Version
        private void CheckForNewVersionEvent(object sender, DoWorkEventArgs e)
		{
			CheckForNewVersion((bool)e.Argument);
		}

		private void CheckForNewVersionAsync(bool ignoreNoNewVersion)
		{
			BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += CheckForNewVersionEvent;
			bgWorker.RunWorkerAsync(ignoreNoNewVersion);
		}

		private void CheckForNewVersion(bool ignoreNoNewVersion)
		{
			Log("Checking for a new version...");

			try
			{
				SoftwareVersion newVersion =
					VersionChecker.CheckForNewVersion(Constants.FILE_RELEASE_RSS_URL, Constants.SOURCEFORGE_MODULE_TITLE);

				if (newVersion == null)
				{
					Log("There is no new version available");

					if (!ignoreNoNewVersion)
					{
						MessageBox.Show("There is no new version available.", String.Empty, MessageBoxButtons.OK,
											 MessageBoxIcon.Information);
					} 
				}
				else
				{
					Log(String.Format("There is a new version available ({0})", newVersion.VersionNumber));
                    using (NewVersionDialog newVersionDialog = new NewVersionDialog { Version = newVersion })
                    {
                        newVersionDialog.ShowDialog();
                    }
				}
			}
			catch
			{
				Log("An error occurred... please check the DG Manager.NET downloads page on SourceForge to see if a new version is available");
			}
        }
        #endregion

        #region Photos
        private List<Jpeg> GetSelectedPhotos()
        {
            List<Jpeg> photos = new List<Jpeg>();
            foreach (DataGridViewRow row in PhotosGridView.Rows)
            {
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value && ((Jpeg)row.Tag).Location != null)
                {
                    photos.Add((Jpeg)row.Tag);
                }
            }
            return photos;
        }

        private void CommitGeocoding(object sender, DoWorkEventArgs e)
        {
            Log("Commit Geocoding started");
            for (int i = 0; i < PhotosGridView.Rows.Count; i++)
            {
                DataGridViewRow row = PhotosGridView.Rows[i];
                Jpeg jpeg = (Jpeg)row.Tag;
                JpegHelper.SetGpsInfo(jpeg, Settings.SetImageModDateToGeocodeDate);
            }
        }

		private void PerformGeocoding(object sender, DoWorkEventArgs e)
		{
			int successCount = 0;
			int failureCount = 0;

			Log("Geocoding started");

            ReloadAllPoints(GetTracksToSave());

			if (Settings.GeocodePlanBThresholdEnabled)
			{
				Log(String.Format("Photos taken within {0} seconds of the nearest point will be geocoded using interpolation. " +
					"Photos taken between {0} seconds and {1} minutes of the nearest point will have their location set to that of the nearest point.", Settings.GeocodeInterpolationThresholdSecs, Settings.GeocodePlanBThresholdMins));
			}
			else
			{
				Log(String.Format(
						"Photos taken within {0} seconds of the nearest point will be geocoded using interpolation. The plan B threshold is disabled.",
						Settings.GeocodeInterpolationThresholdSecs));
			}

			foreach (DataGridViewRow row in PhotosGridView.Rows)
			{
				row.DefaultCellStyle.BackColor = PhotosGridView.BackgroundColor;
			}

			for (int i = 0; i < PhotosGridView.Rows.Count; i++)
			{
				DataGridViewRow row = PhotosGridView.Rows[i];
				Jpeg jpeg = (Jpeg)row.Tag;
				int? closestInterpPointIndex = null;
				PointOfInterest interpPointBefore = null;
				PointOfInterest interpPointAfter = null;
				PointOfInterest closestPlanBPoint = null;
				double? closestInterpPointDiffSecs = null;
				double? closestPlanBPointDiffMins = null;
				TimeSpan? prevPointToPhotoDiff = null;

				jpeg.OffsetDateTime = jpeg.OriginalDateTime;

				if (Settings.CameraOffsetEnabled)
				{
					if (Settings.CameraOffsetSign == TimespanSign.Positive)
					{
						jpeg.OffsetDateTime = jpeg.OffsetDateTime.Add(Settings.CameraOffsetTimespan);
					}
					else
					{
						jpeg.OffsetDateTime = jpeg.OffsetDateTime.Subtract(Settings.CameraOffsetTimespan);
					}
				}

				for (int j = 0; j < AllPoints.Count; j++)
				{
					TimeSpan pointToPhotoDiff = AllPoints[j].When.AddHours(Settings.UtcShift).Subtract(jpeg.OffsetDateTime);

					//if we have passed the point where the photo was taken, stop looking
					if (prevPointToPhotoDiff.HasValue && pointToPhotoDiff.Duration() > prevPointToPhotoDiff.Value.Duration())
					{
						break;
					}

					//interpolation threshold
					if (Math.Abs(pointToPhotoDiff.TotalSeconds) <= Settings.GeocodeInterpolationThresholdSecs
						&&
						 (!closestInterpPointDiffSecs.HasValue || Math.Abs(pointToPhotoDiff.TotalSeconds) < Math.Abs(closestInterpPointDiffSecs.Value)))
					{
						closestInterpPointDiffSecs = pointToPhotoDiff.TotalSeconds;
						closestInterpPointIndex = j;
					}
					//plan B threshold
					else if (Settings.GeocodePlanBThresholdEnabled && !closestInterpPointIndex.HasValue &&
								Math.Abs(pointToPhotoDiff.TotalMinutes) <= Settings.GeocodePlanBThresholdMins
							&& (!closestPlanBPointDiffMins.HasValue || Math.Abs(pointToPhotoDiff.TotalMinutes) < Math.Abs(closestPlanBPointDiffMins.Value)))
					{
						closestPlanBPointDiffMins = pointToPhotoDiff.TotalMinutes;
						closestPlanBPoint = AllPoints[j];
					}

					prevPointToPhotoDiff = pointToPhotoDiff;
				}

				if (closestInterpPointIndex.HasValue)
				{
					//photo taken before point
					if (closestInterpPointDiffSecs >= 0)
					{
						interpPointBefore = (closestInterpPointIndex == 0) ? null : AllPoints[closestInterpPointIndex.Value - 1];
						interpPointAfter = AllPoints[closestInterpPointIndex.Value];
					}
					//photo taken after point
					else
					{
						interpPointBefore = AllPoints[closestInterpPointIndex.Value];
						interpPointAfter = (closestInterpPointIndex == AllPoints.Count - 1) ? null : AllPoints[closestInterpPointIndex.Value + 1];
					}
				}

				//if a point was found within either of the thresholds
				if (interpPointBefore != null || interpPointAfter != null || closestPlanBPoint != null)
				{
					successCount++;
					row.DefaultCellStyle.BackColor = Color.MediumSpringGreen;
					row.Cells[0].Value = true;

					//if there are two points to interpolate from
					if (interpPointBefore != null && interpPointAfter != null)
					{
						double jpegInterpolatePercent = (jpeg.OffsetDateTime - interpPointBefore.When.AddHours(Settings.UtcShift)).TotalSeconds / (interpPointAfter.When.AddHours(Settings.UtcShift) - interpPointBefore.When.AddHours(Settings.UtcShift)).TotalSeconds;
						double latitudeDiff = interpPointAfter.Latitude - interpPointBefore.Latitude;
						double longitudeDiff = interpPointAfter.Longitude - interpPointBefore.Longitude;

						jpeg.Location = new Location();
						jpeg.Location.Latitude = interpPointBefore.Latitude + (latitudeDiff * jpegInterpolatePercent);
						jpeg.Location.Longitude = interpPointBefore.Longitude + (longitudeDiff * jpegInterpolatePercent);

						if (interpPointBefore.TypePoi == 2 && interpPointBefore.Altitude.HasValue)
						{
							double altitudeDiff = (interpPointAfter.Altitude.HasValue) ? interpPointAfter.Altitude.GetValue() - interpPointBefore.Altitude.GetValue() : 0;
							jpeg.Location.Altitude = interpPointBefore.Altitude.GetValue() + (altitudeDiff * jpegInterpolatePercent);
						}
						else
						{
							jpeg.Location.Altitude = null;
						}

						if (interpPointBefore.Speed.HasValue && interpPointAfter.Speed.HasValue)
						{
							double speedDiff = interpPointAfter.Speed.GetValue() - interpPointBefore.Speed.GetValue();
							jpeg.Speed = interpPointBefore.Speed.GetValue() + (speedDiff * jpegInterpolatePercent);
						}
						else if (interpPointBefore.Speed.HasValue)
						{
							jpeg.Speed = interpPointBefore.Speed.GetValue();
						}
						else if (interpPointAfter.Speed.HasValue)
						{
							jpeg.Speed = interpPointAfter.Speed.GetValue();
						}
						else
						{
							jpeg.Speed = null;
						}

						if ((interpPointAfter.When.AddHours(Settings.UtcShift) - jpeg.OffsetDateTime) > (jpeg.OffsetDateTime - interpPointBefore.When.AddHours(Settings.UtcShift)))
						{
							jpeg.GpsDateTime = interpPointBefore.When;
						}
						else
						{
							jpeg.GpsDateTime = interpPointAfter.When;
						}
					}
					//if there is only one interpolation point or only a Plan B point was found
					else
					{
						PointOfInterest closestPoint;

						if (interpPointBefore != null)
						{
							closestPoint = interpPointBefore;
						}
						else if (interpPointAfter != null)
						{
							closestPoint = interpPointAfter;
						}
						else
						{
							closestPoint = closestPlanBPoint;
						}

						jpeg.Location = new Location();
						jpeg.Location.Latitude = closestPoint.Latitude;
						jpeg.Location.Longitude = closestPoint.Longitude;

						if (closestPoint.TypePoi == 2 && closestPoint.Altitude.HasValue)
						{
							jpeg.Location.Altitude = closestPoint.Altitude.GetValue();
						}
						else
						{
							jpeg.Location.Altitude = null;
						}

						if (closestPoint.Speed.HasValue)
						{
							jpeg.Speed = closestPoint.Speed.GetValue();
						}
						else
						{
							jpeg.Speed = null;
						}

						jpeg.GpsDateTime = closestPoint.When;
					}

					if (Settings.RevGeoEnabled)
					{
						try
						{
							JpegHelper.GetJpegStringTags(jpeg);
							ReverseGeocoder.AddLocationTags(jpeg);
						}
						catch (Exception ex)
						{
                            Log(String.Format("An error occurred during reverse geocoding: {0}", ex.Message));
						}
					}

					JpegHelper.SetGpsInfo(jpeg, Settings.SetImageModDateToGeocodeDate);
				}
				else
				{
					failureCount++;
					row.DefaultCellStyle.BackColor = Color.Red;
				}

				DataOperationBackgroundWorker.ReportProgress(i + 1);
			}

			Invoke(new MethodInvoker(FillPhotosGrid));

			Log("Geocoding completed");

			if (successCount > 0)
			{
				Log(String.Format("\n{0} photos were geocoded successfully", successCount));
			}

			if (failureCount > 0)
			{
				Log(String.Format("\n{0} photos could not be geocoded because no matching GPS points were available", failureCount));
			}
        }
        #endregion

        private void toolStripMenuItemDirections_Click(object sender, EventArgs e)
        {
            QueryPathDialog qp = new QueryPathDialog();
            if (qp.ShowDialog() == DialogResult.OK)
            {
                PointOfInterestList track = qp.Track;
				if (track.Count > 0)
				{
                    TreeNode parent = new TreeNode("Directions");
					TrackTreeNode node = new TrackTreeNode(String.Format("({0:000}) {1}", parent.Nodes.Count + 1, track.DisplayName));
					node.Track = track;
                    parent.Nodes.Add(node);
					Invoke((ThreadStart)delegate() { TracksTreeView.Nodes.Add(parent); });
				}
				else
					MessageBox.Show("No path data");
            }
        }

        #endregion

        private void downloadPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<PointOfInterest> points = new List<PointOfInterest>();
            List<string> names = new List<string>();
            foreach (TreeNode nodes in GetCheckedTracks(TracksTreeView.Nodes))
            {
                TrackTreeNode trackNode = nodes as TrackTreeNode;
                if (trackNode != null && trackNode.Track.Count == 1)
                {
                    points.Add(trackNode.Track[0]);
                    names.Add(trackNode.Track.ListName);
                }
            }
            if (points.Count > 1)
            {
                for (int i = 0; i < points.Count - 1; i++)
                {
                    PointOfInterestList path = GeoUtil.DownloadPath(String.Format("{0} {1}", points[i].Latitude, points[i].Longitude), String.Format("{0} {1}", points[i + 1].Latitude, points[i + 1].Longitude));
                    TrackTreeNode newNode = new TrackTreeNode(String.Format("({0:00#}) {1} to {2}", TracksTreeView.Nodes.Count + 1, names[i], names[i + 1]));
                    newNode.Track = path;
                    newNode.Checked = true;
                    BeginInvoke(new AddNodeToTreeDelegate(AddNodeToTree), new object[] { TracksTreeView.Nodes, newNode });
                }
                _timerRefreshGoogle.Interval = 2000;
                _timerRefreshGoogle.Start();
            }
        }
    }
}