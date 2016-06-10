namespace DGManager
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BottomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.PortStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.WorkProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.SeparatorStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.UtcStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DisplayUnitStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.photosContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.manuallyGeocodeSelectedPhotosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftRightSplitContainer = new System.Windows.Forms.SplitContainer();
            this.LeftTopBottomSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TracksTreeView = new DGManager.TreeViewMultiSelect();
            this.contextMenuTracks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reducePointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrimPointsGroupBox = new System.Windows.Forms.GroupBox();
            this.trimTrackButton = new System.Windows.Forms.Button();
            this.seperateTracksButton = new System.Windows.Forms.Button();
            this.ResetTrimTrackBarsButton = new System.Windows.Forms.Button();
            this.EnableTrimPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.TrimEndLabel = new System.Windows.Forms.Label();
            this.TrimStartLabel = new System.Windows.Forms.Label();
            this.TrimEndTrackBar = new System.Windows.Forms.TrackBar();
            this.TrimStartTrackBar = new System.Windows.Forms.TrackBar();
            this.RightTabControl = new System.Windows.Forms.TabControl();
            this.PointsTabPage = new System.Windows.Forms.TabPage();
            this.PointsListView = new System.Windows.Forms.ListView();
            this.contextMenuPoints = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTrimStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTrimEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MapTabPage = new System.Windows.Forms.TabPage();
            this.PhotoGeocodingTabPage = new System.Windows.Forms.TabPage();
            this.GeocodingSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CommitGeocodingButton = new System.Windows.Forms.Button();
            this.AdvancedSettingsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.OffsetGroupBox = new System.Windows.Forms.GroupBox();
            this.ResetOffsetLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.CameraOffsetEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.SetOffsetLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.CameraOffsetSignComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CameraOffsetSecondsUpDown = new System.Windows.Forms.NumericUpDown();
            this.CameraOffsetHoursUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CameraOffsetMinutesUpDown = new System.Windows.Forms.NumericUpDown();
            this.ToggleShowAllOnMapButton = new System.Windows.Forms.Button();
            this.PerformGeocodingButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.AddPhotosButton = new System.Windows.Forms.Button();
            this.PhotosGridView = new System.Windows.Forms.DataGridView();
            this.ShowOnMapColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LatitudeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongitudeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagePreview = new System.Windows.Forms.TabPage();
            this.trackPreview1 = new DGManager.TrackPreview();
            this.tabPageChart = new System.Windows.Forms.TabPage();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TopBottomSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDirections = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.checkSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyCheckSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.removeSelectedTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeCheckedTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveTrackUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedTracksInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedMetricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedImperialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedNauticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceMetricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceImperialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceNauticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevationMetricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevationImperialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayPrecisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nineDigitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.streetMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satelliteMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hybridMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terrainMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.defaultMapTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streetDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satelliteDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hybridDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.overviewMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.advancedGMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticallyCheckForNewVersionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTCShiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geocodingSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPXSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kMLSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.readToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadLatestTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.gPSMouseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutDGManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Port = new System.IO.Ports.SerialPort(this.components);
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.DataOperationBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.OpenMultiFilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BottomStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRightSplitContainer)).BeginInit();
            this.LeftRightSplitContainer.Panel1.SuspendLayout();
            this.LeftRightSplitContainer.Panel2.SuspendLayout();
            this.LeftRightSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTopBottomSplitContainer)).BeginInit();
            this.LeftTopBottomSplitContainer.Panel1.SuspendLayout();
            this.LeftTopBottomSplitContainer.Panel2.SuspendLayout();
            this.LeftTopBottomSplitContainer.SuspendLayout();
            this.contextMenuTracks.SuspendLayout();
            this.TrimPointsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrimEndTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrimStartTrackBar)).BeginInit();
            this.RightTabControl.SuspendLayout();
            this.PointsTabPage.SuspendLayout();
            this.contextMenuPoints.SuspendLayout();
            this.PhotoGeocodingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GeocodingSplitContainer)).BeginInit();
            this.GeocodingSplitContainer.Panel1.SuspendLayout();
            this.GeocodingSplitContainer.Panel2.SuspendLayout();
            this.GeocodingSplitContainer.SuspendLayout();
            this.OffsetGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraOffsetSecondsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraOffsetHoursUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraOffsetMinutesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhotosGridView)).BeginInit();
            this.tabPagePreview.SuspendLayout();
            this.tabPageChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopBottomSplitContainer)).BeginInit();
            this.TopBottomSplitContainer.Panel1.SuspendLayout();
            this.TopBottomSplitContainer.Panel2.SuspendLayout();
            this.TopBottomSplitContainer.SuspendLayout();
            this.TopMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomStatusStrip
            // 
            this.BottomStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PortStatusLabel,
            this.WorkProgressBar,
            this.SeparatorStatusLabel,
            this.UtcStatusLabel,
            this.DisplayUnitStatusLabel});
            this.BottomStatusStrip.Location = new System.Drawing.Point(0, 486);
            this.BottomStatusStrip.Name = "BottomStatusStrip";
            this.BottomStatusStrip.Size = new System.Drawing.Size(776, 22);
            this.BottomStatusStrip.TabIndex = 1;
            this.BottomStatusStrip.Text = "statusStrip1";
            // 
            // PortStatusLabel
            // 
            this.PortStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.PortStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.PortStatusLabel.Name = "PortStatusLabel";
            this.PortStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.PortStatusLabel.Size = new System.Drawing.Size(24, 17);
            // 
            // WorkProgressBar
            // 
            this.WorkProgressBar.Name = "WorkProgressBar";
            this.WorkProgressBar.Size = new System.Drawing.Size(150, 16);
            this.WorkProgressBar.Step = 1;
            // 
            // SeparatorStatusLabel
            // 
            this.SeparatorStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.SeparatorStatusLabel.Name = "SeparatorStatusLabel";
            this.SeparatorStatusLabel.Size = new System.Drawing.Size(551, 17);
            this.SeparatorStatusLabel.Spring = true;
            // 
            // UtcStatusLabel
            // 
            this.UtcStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.UtcStatusLabel.Name = "UtcStatusLabel";
            this.UtcStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.UtcStatusLabel.Size = new System.Drawing.Size(10, 17);
            // 
            // DisplayUnitStatusLabel
            // 
            this.DisplayUnitStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.DisplayUnitStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.DisplayUnitStatusLabel.Name = "DisplayUnitStatusLabel";
            this.DisplayUnitStatusLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.DisplayUnitStatusLabel.Size = new System.Drawing.Size(24, 17);
            // 
            // photosContextMenuStrip
            // 
            this.photosContextMenuStrip.Name = "photosContextMenuStrip";
            this.photosContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // manuallyGeocodeSelectedPhotosToolStripMenuItem
            // 
            this.manuallyGeocodeSelectedPhotosToolStripMenuItem.Name = "manuallyGeocodeSelectedPhotosToolStripMenuItem";
            this.manuallyGeocodeSelectedPhotosToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // LeftRightSplitContainer
            // 
            this.LeftRightSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftRightSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.LeftRightSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.LeftRightSplitContainer.Name = "LeftRightSplitContainer";
            // 
            // LeftRightSplitContainer.Panel1
            // 
            this.LeftRightSplitContainer.Panel1.Controls.Add(this.LeftTopBottomSplitContainer);
            this.LeftRightSplitContainer.Panel1MinSize = 215;
            // 
            // LeftRightSplitContainer.Panel2
            // 
            this.LeftRightSplitContainer.Panel2.Controls.Add(this.RightTabControl);
            this.LeftRightSplitContainer.Size = new System.Drawing.Size(776, 332);
            this.LeftRightSplitContainer.SplitterDistance = 215;
            this.LeftRightSplitContainer.TabIndex = 1;
            this.LeftRightSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.LeftRightSplitContainer_SplitterMoved);
            // 
            // LeftTopBottomSplitContainer
            // 
            this.LeftTopBottomSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTopBottomSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.LeftTopBottomSplitContainer.IsSplitterFixed = true;
            this.LeftTopBottomSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.LeftTopBottomSplitContainer.Name = "LeftTopBottomSplitContainer";
            this.LeftTopBottomSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LeftTopBottomSplitContainer.Panel1
            // 
            this.LeftTopBottomSplitContainer.Panel1.Controls.Add(this.TracksTreeView);
            // 
            // LeftTopBottomSplitContainer.Panel2
            // 
            this.LeftTopBottomSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.LeftTopBottomSplitContainer.Panel2.Controls.Add(this.TrimPointsGroupBox);
            this.LeftTopBottomSplitContainer.Size = new System.Drawing.Size(215, 332);
            this.LeftTopBottomSplitContainer.SplitterDistance = 170;
            this.LeftTopBottomSplitContainer.TabIndex = 1;
            // 
            // TracksTreeView
            // 
            this.TracksTreeView.CheckBoxes = true;
            this.TracksTreeView.ContextMenuStrip = this.contextMenuTracks;
            this.TracksTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TracksTreeView.HideSelection = false;
            this.TracksTreeView.LabelEdit = true;
            this.TracksTreeView.Location = new System.Drawing.Point(0, 0);
            this.TracksTreeView.Name = "TracksTreeView";
            this.TracksTreeView.Size = new System.Drawing.Size(215, 170);
            this.TracksTreeView.TabIndex = 0;
            this.TracksTreeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TracksTreeView_BeforeLabelEdit);
            this.TracksTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TracksTreeView_AfterLabelEdit);
            this.TracksTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TracksTreeView_AfterCheck);
            this.TracksTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TracksTreeView_AfterSelect);
            this.TracksTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TracksTreeView_NodeMouseDoubleClick);
            this.TracksTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TracksTreeView_KeyDown);
            // 
            // contextMenuTracks
            // 
            this.contextMenuTracks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteTrackToolStripMenuItem,
            this.reducePointsToolStripMenuItem});
            this.contextMenuTracks.Name = "contextMenuTracks";
            this.contextMenuTracks.Size = new System.Drawing.Size(162, 48);
            // 
            // deleteTrackToolStripMenuItem
            // 
            this.deleteTrackToolStripMenuItem.Name = "deleteTrackToolStripMenuItem";
            this.deleteTrackToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.deleteTrackToolStripMenuItem.Text = "Delete Track";
            this.deleteTrackToolStripMenuItem.Click += new System.EventHandler(this.deleteTrackToolStripMenuItem_Click);
            // 
            // reducePointsToolStripMenuItem
            // 
            this.reducePointsToolStripMenuItem.Name = "reducePointsToolStripMenuItem";
            this.reducePointsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.reducePointsToolStripMenuItem.Text = "Reduce Points ...";
            this.reducePointsToolStripMenuItem.Click += new System.EventHandler(this.reducePointsToolStripMenuItem_Click);
            // 
            // TrimPointsGroupBox
            // 
            this.TrimPointsGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.TrimPointsGroupBox.Controls.Add(this.trimTrackButton);
            this.TrimPointsGroupBox.Controls.Add(this.seperateTracksButton);
            this.TrimPointsGroupBox.Controls.Add(this.ResetTrimTrackBarsButton);
            this.TrimPointsGroupBox.Controls.Add(this.EnableTrimPointsCheckBox);
            this.TrimPointsGroupBox.Controls.Add(this.TrimEndLabel);
            this.TrimPointsGroupBox.Controls.Add(this.TrimStartLabel);
            this.TrimPointsGroupBox.Controls.Add(this.TrimEndTrackBar);
            this.TrimPointsGroupBox.Controls.Add(this.TrimStartTrackBar);
            this.TrimPointsGroupBox.Location = new System.Drawing.Point(5, 4);
            this.TrimPointsGroupBox.Name = "TrimPointsGroupBox";
            this.TrimPointsGroupBox.Size = new System.Drawing.Size(208, 148);
            this.TrimPointsGroupBox.TabIndex = 0;
            this.TrimPointsGroupBox.TabStop = false;
            this.TrimPointsGroupBox.Text = "Trim points from trip";
            // 
            // trimTrackButton
            // 
            this.trimTrackButton.AutoSize = true;
            this.trimTrackButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.trimTrackButton.Location = new System.Drawing.Point(41, 115);
            this.trimTrackButton.Name = "trimTrackButton";
            this.trimTrackButton.Size = new System.Drawing.Size(37, 23);
            this.trimTrackButton.TabIndex = 6;
            this.trimTrackButton.Text = "Trim";
            this.trimTrackButton.UseVisualStyleBackColor = true;
            this.trimTrackButton.Click += new System.EventHandler(this.trimTrackButton_Click);
            // 
            // seperateTracksButton
            // 
            this.seperateTracksButton.Location = new System.Drawing.Point(86, 115);
            this.seperateTracksButton.Name = "seperateTracksButton";
            this.seperateTracksButton.Size = new System.Drawing.Size(60, 23);
            this.seperateTracksButton.TabIndex = 5;
            this.seperateTracksButton.Text = "Seperate";
            this.seperateTracksButton.UseVisualStyleBackColor = true;
            this.seperateTracksButton.Click += new System.EventHandler(this.seperateTracksButton_Click);
            // 
            // ResetTrimTrackBarsButton
            // 
            this.ResetTrimTrackBarsButton.Location = new System.Drawing.Point(153, 115);
            this.ResetTrimTrackBarsButton.Name = "ResetTrimTrackBarsButton";
            this.ResetTrimTrackBarsButton.Size = new System.Drawing.Size(44, 23);
            this.ResetTrimTrackBarsButton.TabIndex = 1;
            this.ResetTrimTrackBarsButton.Text = "Reset";
            this.ResetTrimTrackBarsButton.UseVisualStyleBackColor = true;
            this.ResetTrimTrackBarsButton.Click += new System.EventHandler(this.ResetTrimTrackBarsButton_Click);
            // 
            // EnableTrimPointsCheckBox
            // 
            this.EnableTrimPointsCheckBox.AutoSize = true;
            this.EnableTrimPointsCheckBox.Location = new System.Drawing.Point(136, 19);
            this.EnableTrimPointsCheckBox.Name = "EnableTrimPointsCheckBox";
            this.EnableTrimPointsCheckBox.Size = new System.Drawing.Size(65, 17);
            this.EnableTrimPointsCheckBox.TabIndex = 1;
            this.EnableTrimPointsCheckBox.Text = "Enabled";
            this.EnableTrimPointsCheckBox.UseVisualStyleBackColor = true;
            this.EnableTrimPointsCheckBox.CheckedChanged += new System.EventHandler(this.EnableTrimPointsCheckBox_CheckedChanged);
            // 
            // TrimEndLabel
            // 
            this.TrimEndLabel.AutoSize = true;
            this.TrimEndLabel.Location = new System.Drawing.Point(7, 67);
            this.TrimEndLabel.Name = "TrimEndLabel";
            this.TrimEndLabel.Size = new System.Drawing.Size(71, 13);
            this.TrimEndLabel.TabIndex = 4;
            this.TrimEndLabel.Text = "Trim from end";
            // 
            // TrimStartLabel
            // 
            this.TrimStartLabel.AutoSize = true;
            this.TrimStartLabel.Location = new System.Drawing.Point(7, 23);
            this.TrimStartLabel.Name = "TrimStartLabel";
            this.TrimStartLabel.Size = new System.Drawing.Size(73, 13);
            this.TrimStartLabel.TabIndex = 2;
            this.TrimStartLabel.Text = "Trim from start";
            // 
            // TrimEndTrackBar
            // 
            this.TrimEndTrackBar.Location = new System.Drawing.Point(3, 82);
            this.TrimEndTrackBar.Maximum = 200;
            this.TrimEndTrackBar.Name = "TrimEndTrackBar";
            this.TrimEndTrackBar.Size = new System.Drawing.Size(200, 45);
            this.TrimEndTrackBar.TabIndex = 3;
            this.TrimEndTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.TrimEndTrackBar, "0");
            this.TrimEndTrackBar.Value = 200;
            this.TrimEndTrackBar.ValueChanged += new System.EventHandler(this.TrimTrackBar_SetTooltip);
            this.TrimEndTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TrimTrackBar_KeyUp);
            this.TrimEndTrackBar.MouseCaptureChanged += new System.EventHandler(this.TrimTrackBar_AfterValueChanged);
            this.TrimEndTrackBar.MouseEnter += new System.EventHandler(this.TrimTrackBar_SetTooltip);
            this.TrimEndTrackBar.MouseLeave += new System.EventHandler(this.TrimTrackBar_RemoveTooltip);
            this.TrimEndTrackBar.MouseHover += new System.EventHandler(this.TrimTrackBar_SetTooltip);
            // 
            // TrimStartTrackBar
            // 
            this.TrimStartTrackBar.Location = new System.Drawing.Point(3, 38);
            this.TrimStartTrackBar.Maximum = 100;
            this.TrimStartTrackBar.Name = "TrimStartTrackBar";
            this.TrimStartTrackBar.Size = new System.Drawing.Size(200, 45);
            this.TrimStartTrackBar.TabIndex = 1;
            this.TrimStartTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.TrimStartTrackBar, "0");
            this.TrimStartTrackBar.ValueChanged += new System.EventHandler(this.TrimTrackBar_SetTooltip);
            this.TrimStartTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TrimTrackBar_KeyUp);
            this.TrimStartTrackBar.MouseCaptureChanged += new System.EventHandler(this.TrimTrackBar_AfterValueChanged);
            this.TrimStartTrackBar.MouseEnter += new System.EventHandler(this.TrimTrackBar_SetTooltip);
            this.TrimStartTrackBar.MouseLeave += new System.EventHandler(this.TrimTrackBar_RemoveTooltip);
            this.TrimStartTrackBar.MouseHover += new System.EventHandler(this.TrimTrackBar_SetTooltip);
            // 
            // RightTabControl
            // 
            this.RightTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.RightTabControl.Controls.Add(this.PointsTabPage);
            this.RightTabControl.Controls.Add(this.MapTabPage);
            this.RightTabControl.Controls.Add(this.PhotoGeocodingTabPage);
            this.RightTabControl.Controls.Add(this.tabPagePreview);
            this.RightTabControl.Controls.Add(this.tabPageChart);
            this.RightTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTabControl.Location = new System.Drawing.Point(0, 0);
            this.RightTabControl.Name = "RightTabControl";
            this.RightTabControl.SelectedIndex = 0;
            this.RightTabControl.Size = new System.Drawing.Size(557, 332);
            this.RightTabControl.TabIndex = 0;
            this.RightTabControl.SelectedIndexChanged += new System.EventHandler(this.RightTabControl_SelectedIndexChanged);
            // 
            // PointsTabPage
            // 
            this.PointsTabPage.Controls.Add(this.PointsListView);
            this.PointsTabPage.Location = new System.Drawing.Point(4, 4);
            this.PointsTabPage.Name = "PointsTabPage";
            this.PointsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PointsTabPage.Size = new System.Drawing.Size(549, 306);
            this.PointsTabPage.TabIndex = 0;
            this.PointsTabPage.Text = "Points";
            this.PointsTabPage.UseVisualStyleBackColor = true;
            // 
            // PointsListView
            // 
            this.PointsListView.ContextMenuStrip = this.contextMenuPoints;
            this.PointsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PointsListView.FullRowSelect = true;
            this.PointsListView.Location = new System.Drawing.Point(3, 3);
            this.PointsListView.MultiSelect = false;
            this.PointsListView.Name = "PointsListView";
            this.PointsListView.Size = new System.Drawing.Size(543, 300);
            this.PointsListView.TabIndex = 1;
            this.PointsListView.UseCompatibleStateImageBehavior = false;
            this.PointsListView.View = System.Windows.Forms.View.Details;
            this.PointsListView.VirtualMode = true;
            this.PointsListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.pointsListView_RetrieveVirtualItem);
            this.PointsListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PointsListView_KeyPress);
            this.PointsListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PointsListView_KeyUp);
            // 
            // contextMenuPoints
            // 
            this.contextMenuPoints.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitTrackToolStripMenuItem,
            this.setTrimStartToolStripMenuItem,
            this.setTrimEndToolStripMenuItem,
            this.removePointsToolStripMenuItem});
            this.contextMenuPoints.Name = "contextMenuStrip1";
            this.contextMenuPoints.Size = new System.Drawing.Size(162, 92);
            // 
            // splitTrackToolStripMenuItem
            // 
            this.splitTrackToolStripMenuItem.Name = "splitTrackToolStripMenuItem";
            this.splitTrackToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.splitTrackToolStripMenuItem.Text = "Split Track";
            this.splitTrackToolStripMenuItem.Click += new System.EventHandler(this.splitTrackToolStripMenuItem_Click);
            // 
            // setTrimStartToolStripMenuItem
            // 
            this.setTrimStartToolStripMenuItem.Name = "setTrimStartToolStripMenuItem";
            this.setTrimStartToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.setTrimStartToolStripMenuItem.Text = "Set Trim Start";
            this.setTrimStartToolStripMenuItem.Click += new System.EventHandler(this.setTrimStartToolStripMenuItem_Click);
            // 
            // setTrimEndToolStripMenuItem
            // 
            this.setTrimEndToolStripMenuItem.Name = "setTrimEndToolStripMenuItem";
            this.setTrimEndToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.setTrimEndToolStripMenuItem.Text = "Set Trim End";
            this.setTrimEndToolStripMenuItem.Click += new System.EventHandler(this.setTrimEndToolStripMenuItem_Click);
            // 
            // removePointsToolStripMenuItem
            // 
            this.removePointsToolStripMenuItem.Name = "removePointsToolStripMenuItem";
            this.removePointsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.removePointsToolStripMenuItem.Text = "Remove Point(s)";
            this.removePointsToolStripMenuItem.Click += new System.EventHandler(this.removePointsToolStripMenuItem_Click);
            // 
            // MapTabPage
            // 
            this.MapTabPage.Location = new System.Drawing.Point(4, 4);
            this.MapTabPage.Name = "MapTabPage";
            this.MapTabPage.Size = new System.Drawing.Size(549, 306);
            this.MapTabPage.TabIndex = 2;
            this.MapTabPage.Text = "Google Maps";
            this.MapTabPage.UseVisualStyleBackColor = true;
            // 
            // PhotoGeocodingTabPage
            // 
            this.PhotoGeocodingTabPage.BackColor = System.Drawing.Color.Transparent;
            this.PhotoGeocodingTabPage.Controls.Add(this.GeocodingSplitContainer);
            this.PhotoGeocodingTabPage.Location = new System.Drawing.Point(4, 4);
            this.PhotoGeocodingTabPage.Name = "PhotoGeocodingTabPage";
            this.PhotoGeocodingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PhotoGeocodingTabPage.Size = new System.Drawing.Size(549, 306);
            this.PhotoGeocodingTabPage.TabIndex = 3;
            this.PhotoGeocodingTabPage.Text = "Photo Geocoding";
            this.PhotoGeocodingTabPage.UseVisualStyleBackColor = true;
            // 
            // GeocodingSplitContainer
            // 
            this.GeocodingSplitContainer.BackColor = System.Drawing.Color.Transparent;
            this.GeocodingSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeocodingSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.GeocodingSplitContainer.IsSplitterFixed = true;
            this.GeocodingSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.GeocodingSplitContainer.Name = "GeocodingSplitContainer";
            this.GeocodingSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // GeocodingSplitContainer.Panel1
            // 
            this.GeocodingSplitContainer.Panel1.Controls.Add(this.CommitGeocodingButton);
            this.GeocodingSplitContainer.Panel1.Controls.Add(this.AdvancedSettingsLinkLabel);
            this.GeocodingSplitContainer.Panel1.Controls.Add(this.OffsetGroupBox);
            this.GeocodingSplitContainer.Panel1.Controls.Add(this.ToggleShowAllOnMapButton);
            this.GeocodingSplitContainer.Panel1.Controls.Add(this.PerformGeocodingButton);
            this.GeocodingSplitContainer.Panel1.Controls.Add(this.ClearButton);
            this.GeocodingSplitContainer.Panel1.Controls.Add(this.AddPhotosButton);
            this.GeocodingSplitContainer.Panel1MinSize = 60;
            // 
            // GeocodingSplitContainer.Panel2
            // 
            this.GeocodingSplitContainer.Panel2.Controls.Add(this.PhotosGridView);
            this.GeocodingSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.GeocodingSplitContainer.Size = new System.Drawing.Size(543, 300);
            this.GeocodingSplitContainer.SplitterDistance = 61;
            this.GeocodingSplitContainer.TabIndex = 2;
            // 
            // CommitGeocodingButton
            // 
            this.CommitGeocodingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommitGeocodingButton.Location = new System.Drawing.Point(481, -1);
            this.CommitGeocodingButton.Name = "CommitGeocodingButton";
            this.CommitGeocodingButton.Size = new System.Drawing.Size(59, 23);
            this.CommitGeocodingButton.TabIndex = 16;
            this.CommitGeocodingButton.Text = "Commit";
            this.CommitGeocodingButton.UseVisualStyleBackColor = true;
            this.CommitGeocodingButton.Click += new System.EventHandler(this.CommitGeocodingButton_Click);
            // 
            // AdvancedSettingsLinkLabel
            // 
            this.AdvancedSettingsLinkLabel.AutoSize = true;
            this.AdvancedSettingsLinkLabel.Location = new System.Drawing.Point(427, 36);
            this.AdvancedSettingsLinkLabel.Name = "AdvancedSettingsLinkLabel";
            this.AdvancedSettingsLinkLabel.Size = new System.Drawing.Size(97, 13);
            this.AdvancedSettingsLinkLabel.TabIndex = 15;
            this.AdvancedSettingsLinkLabel.TabStop = true;
            this.AdvancedSettingsLinkLabel.Text = "Advanced Settings";
            this.AdvancedSettingsLinkLabel.Click += new System.EventHandler(this.geocodingSettingsToolStripMenuItem_Click);
            // 
            // OffsetGroupBox
            // 
            this.OffsetGroupBox.Controls.Add(this.ResetOffsetLinkLabel);
            this.OffsetGroupBox.Controls.Add(this.label4);
            this.OffsetGroupBox.Controls.Add(this.CameraOffsetEnabledCheckBox);
            this.OffsetGroupBox.Controls.Add(this.SetOffsetLinkLabel);
            this.OffsetGroupBox.Controls.Add(this.label3);
            this.OffsetGroupBox.Controls.Add(this.CameraOffsetSignComboBox);
            this.OffsetGroupBox.Controls.Add(this.label2);
            this.OffsetGroupBox.Controls.Add(this.CameraOffsetSecondsUpDown);
            this.OffsetGroupBox.Controls.Add(this.CameraOffsetHoursUpDown);
            this.OffsetGroupBox.Controls.Add(this.label1);
            this.OffsetGroupBox.Controls.Add(this.CameraOffsetMinutesUpDown);
            this.OffsetGroupBox.Location = new System.Drawing.Point(3, 23);
            this.OffsetGroupBox.Name = "OffsetGroupBox";
            this.OffsetGroupBox.Size = new System.Drawing.Size(418, 36);
            this.OffsetGroupBox.TabIndex = 14;
            this.OffsetGroupBox.TabStop = false;
            // 
            // ResetOffsetLinkLabel
            // 
            this.ResetOffsetLinkLabel.AutoSize = true;
            this.ResetOffsetLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetOffsetLinkLabel.Location = new System.Drawing.Point(275, 14);
            this.ResetOffsetLinkLabel.Name = "ResetOffsetLinkLabel";
            this.ResetOffsetLinkLabel.Size = new System.Drawing.Size(34, 13);
            this.ResetOffsetLinkLabel.TabIndex = 17;
            this.ResetOffsetLinkLabel.TabStop = true;
            this.ResetOffsetLinkLabel.Text = "Reset";
            this.ResetOffsetLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ResetOffsetLinkLabel_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "h";
            // 
            // CameraOffsetEnabledCheckBox
            // 
            this.CameraOffsetEnabledCheckBox.AutoSize = true;
            this.CameraOffsetEnabledCheckBox.Location = new System.Drawing.Point(44, 14);
            this.CameraOffsetEnabledCheckBox.Name = "CameraOffsetEnabledCheckBox";
            this.CameraOffsetEnabledCheckBox.Size = new System.Drawing.Size(15, 14);
            this.CameraOffsetEnabledCheckBox.TabIndex = 15;
            this.CameraOffsetEnabledCheckBox.UseVisualStyleBackColor = true;
            this.CameraOffsetEnabledCheckBox.CheckedChanged += new System.EventHandler(this.CameraOffsetChanged);
            // 
            // SetOffsetLinkLabel
            // 
            this.SetOffsetLinkLabel.AutoSize = true;
            this.SetOffsetLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetOffsetLinkLabel.Location = new System.Drawing.Point(314, 14);
            this.SetOffsetLinkLabel.Name = "SetOffsetLinkLabel";
            this.SetOffsetLinkLabel.Size = new System.Drawing.Size(98, 13);
            this.SetOffsetLinkLabel.TabIndex = 14;
            this.SetOffsetLinkLabel.TabStop = true;
            this.SetOffsetLinkLabel.Text = "Show Offset Helper";
            this.SetOffsetLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SetOffsetLinkLabel_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Offset:";
            // 
            // CameraOffsetSignComboBox
            // 
            this.CameraOffsetSignComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CameraOffsetSignComboBox.FormattingEnabled = true;
            this.CameraOffsetSignComboBox.Items.AddRange(new object[] {
            "+",
            "-"});
            this.CameraOffsetSignComboBox.Location = new System.Drawing.Point(65, 11);
            this.CameraOffsetSignComboBox.Name = "CameraOffsetSignComboBox";
            this.CameraOffsetSignComboBox.Size = new System.Drawing.Size(43, 21);
            this.CameraOffsetSignComboBox.TabIndex = 7;
            this.CameraOffsetSignComboBox.SelectedValueChanged += new System.EventHandler(this.CameraOffsetChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "s";
            // 
            // CameraOffsetSecondsUpDown
            // 
            this.CameraOffsetSecondsUpDown.Location = new System.Drawing.Point(224, 11);
            this.CameraOffsetSecondsUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.CameraOffsetSecondsUpDown.Name = "CameraOffsetSecondsUpDown";
            this.CameraOffsetSecondsUpDown.Size = new System.Drawing.Size(35, 20);
            this.CameraOffsetSecondsUpDown.TabIndex = 12;
            this.CameraOffsetSecondsUpDown.ValueChanged += new System.EventHandler(this.CameraOffsetChanged);
            // 
            // CameraOffsetHoursUpDown
            // 
            this.CameraOffsetHoursUpDown.Location = new System.Drawing.Point(112, 11);
            this.CameraOffsetHoursUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CameraOffsetHoursUpDown.Name = "CameraOffsetHoursUpDown";
            this.CameraOffsetHoursUpDown.Size = new System.Drawing.Size(43, 20);
            this.CameraOffsetHoursUpDown.TabIndex = 8;
            this.CameraOffsetHoursUpDown.ValueChanged += new System.EventHandler(this.CameraOffsetChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "m";
            // 
            // CameraOffsetMinutesUpDown
            // 
            this.CameraOffsetMinutesUpDown.Location = new System.Drawing.Point(172, 11);
            this.CameraOffsetMinutesUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.CameraOffsetMinutesUpDown.Name = "CameraOffsetMinutesUpDown";
            this.CameraOffsetMinutesUpDown.Size = new System.Drawing.Size(35, 20);
            this.CameraOffsetMinutesUpDown.TabIndex = 10;
            this.CameraOffsetMinutesUpDown.ValueChanged += new System.EventHandler(this.CameraOffsetChanged);
            // 
            // ToggleShowAllOnMapButton
            // 
            this.ToggleShowAllOnMapButton.Location = new System.Drawing.Point(182, 0);
            this.ToggleShowAllOnMapButton.Name = "ToggleShowAllOnMapButton";
            this.ToggleShowAllOnMapButton.Size = new System.Drawing.Size(119, 23);
            this.ToggleShowAllOnMapButton.TabIndex = 3;
            this.ToggleShowAllOnMapButton.Text = "Toggle Show On Map";
            this.ToggleShowAllOnMapButton.UseVisualStyleBackColor = true;
            this.ToggleShowAllOnMapButton.Click += new System.EventHandler(this.ToggleShowAllOnMapButton_Click);
            // 
            // PerformGeocodingButton
            // 
            this.PerformGeocodingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PerformGeocodingButton.Location = new System.Drawing.Point(354, 0);
            this.PerformGeocodingButton.MaximumSize = new System.Drawing.Size(120, 23);
            this.PerformGeocodingButton.MinimumSize = new System.Drawing.Size(120, 23);
            this.PerformGeocodingButton.Name = "PerformGeocodingButton";
            this.PerformGeocodingButton.Size = new System.Drawing.Size(120, 23);
            this.PerformGeocodingButton.TabIndex = 1;
            this.PerformGeocodingButton.Text = "Perform Geocoding";
            this.PerformGeocodingButton.UseVisualStyleBackColor = true;
            this.PerformGeocodingButton.Click += new System.EventHandler(this.PerformGeocodingButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(84, 0);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AddPhotosButton
            // 
            this.AddPhotosButton.Location = new System.Drawing.Point(3, 0);
            this.AddPhotosButton.Name = "AddPhotosButton";
            this.AddPhotosButton.Size = new System.Drawing.Size(75, 23);
            this.AddPhotosButton.TabIndex = 0;
            this.AddPhotosButton.Text = "Add Photos";
            this.AddPhotosButton.UseVisualStyleBackColor = true;
            this.AddPhotosButton.Click += new System.EventHandler(this.AddPhotosButton_Click);
            // 
            // PhotosGridView
            // 
            this.PhotosGridView.AllowUserToAddRows = false;
            this.PhotosGridView.AllowUserToDeleteRows = false;
            this.PhotosGridView.AllowUserToResizeRows = false;
            this.PhotosGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.PhotosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PhotosGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShowOnMapColumn,
            this.PathColumn,
            this.TimeColumn,
            this.DateColumn,
            this.LatitudeColumn,
            this.LongitudeColumn,
            this.LocationColumn});
            this.PhotosGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhotosGridView.Location = new System.Drawing.Point(0, 3);
            this.PhotosGridView.Name = "PhotosGridView";
            this.PhotosGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.PhotosGridView.RowTemplate.Height = 20;
            this.PhotosGridView.Size = new System.Drawing.Size(543, 232);
            this.PhotosGridView.TabIndex = 1;
            this.PhotosGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PhotosGridView_CellDoubleClick);
            // 
            // ShowOnMapColumn
            // 
            this.ShowOnMapColumn.HeaderText = "Show On Map";
            this.ShowOnMapColumn.Name = "ShowOnMapColumn";
            // 
            // PathColumn
            // 
            this.PathColumn.HeaderText = "Path";
            this.PathColumn.Name = "PathColumn";
            this.PathColumn.ReadOnly = true;
            // 
            // TimeColumn
            // 
            this.TimeColumn.HeaderText = "Time";
            this.TimeColumn.Name = "TimeColumn";
            this.TimeColumn.ReadOnly = true;
            // 
            // DateColumn
            // 
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            // 
            // LatitudeColumn
            // 
            this.LatitudeColumn.HeaderText = "Latitude";
            this.LatitudeColumn.Name = "LatitudeColumn";
            this.LatitudeColumn.ReadOnly = true;
            // 
            // LongitudeColumn
            // 
            this.LongitudeColumn.HeaderText = "Longitude";
            this.LongitudeColumn.Name = "LongitudeColumn";
            this.LongitudeColumn.ReadOnly = true;
            // 
            // LocationColumn
            // 
            this.LocationColumn.HeaderText = "Location";
            this.LocationColumn.Name = "LocationColumn";
            this.LocationColumn.ReadOnly = true;
            // 
            // tabPagePreview
            // 
            this.tabPagePreview.Controls.Add(this.trackPreview1);
            this.tabPagePreview.Location = new System.Drawing.Point(4, 4);
            this.tabPagePreview.Name = "tabPagePreview";
            this.tabPagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreview.Size = new System.Drawing.Size(549, 306);
            this.tabPagePreview.TabIndex = 4;
            this.tabPagePreview.Text = "Preview";
            this.tabPagePreview.UseVisualStyleBackColor = true;
            // 
            // trackPreview1
            // 
            this.trackPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackPreview1.Location = new System.Drawing.Point(3, 3);
            this.trackPreview1.Name = "trackPreview1";
            this.trackPreview1.OffsetX = 0;
            this.trackPreview1.OffsetY = 0;
            this.trackPreview1.Size = new System.Drawing.Size(543, 300);
            this.trackPreview1.TabIndex = 0;
            this.trackPreview1.Zoom = 1F;
            // 
            // tabPageChart
            // 
            this.tabPageChart.Controls.Add(this.zedGraphControl);
            this.tabPageChart.Location = new System.Drawing.Point(4, 4);
            this.tabPageChart.Name = "tabPageChart";
            this.tabPageChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChart.Size = new System.Drawing.Size(549, 306);
            this.tabPageChart.TabIndex = 5;
            this.tabPageChart.Text = "Chart";
            this.tabPageChart.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(543, 300);
            this.zedGraphControl.TabIndex = 0;
            this.zedGraphControl.UseExtendedPrintDialog = true;
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(776, 126);
            this.LogTextBox.TabIndex = 0;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.DefaultExt = "*.gpx";
            this.OpenFileDialog.Multiselect = true;
            // 
            // TopBottomSplitContainer
            // 
            this.TopBottomSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopBottomSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.TopBottomSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.TopBottomSplitContainer.Name = "TopBottomSplitContainer";
            this.TopBottomSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // TopBottomSplitContainer.Panel1
            // 
            this.TopBottomSplitContainer.Panel1.Controls.Add(this.LeftRightSplitContainer);
            // 
            // TopBottomSplitContainer.Panel2
            // 
            this.TopBottomSplitContainer.Panel2.Controls.Add(this.LogTextBox);
            this.TopBottomSplitContainer.Size = new System.Drawing.Size(776, 462);
            this.TopBottomSplitContainer.SplitterDistance = 332;
            this.TopBottomSplitContainer.TabIndex = 3;
            this.TopBottomSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.TopBottomSplitContainer_SplitterMoved);
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.portToolStripMenuItem,
            this.memoryToolStripMenuItem,
            this.toolStripMenuItem1});
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Size = new System.Drawing.Size(776, 24);
            this.TopMenuStrip.TabIndex = 0;
            this.TopMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openMoreToolStripMenuItem,
            this.toolStripMenuItemDirections,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openMoreToolStripMenuItem
            // 
            this.openMoreToolStripMenuItem.Name = "openMoreToolStripMenuItem";
            this.openMoreToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.openMoreToolStripMenuItem.Text = "Open More";
            this.openMoreToolStripMenuItem.Click += new System.EventHandler(this.openMoreToolStripMenuItem_Click);
            // 
            // toolStripMenuItemDirections
            // 
            this.toolStripMenuItemDirections.Name = "toolStripMenuItemDirections";
            this.toolStripMenuItemDirections.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItemDirections.Text = "Get Directions (experimental)";
            this.toolStripMenuItemDirections.Click += new System.EventHandler(this.toolStripMenuItemDirections_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(224, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(224, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAllFilesToolStripMenuItem,
            this.uncheckAllFilesToolStripMenuItem,
            this.toolStripSeparator3,
            this.checkSelectedFilesToolStripMenuItem,
            this.uncheckSelectedFilesToolStripMenuItem,
            this.onlyCheckSelectedFilesToolStripMenuItem,
            this.toolStripSeparator11,
            this.removeSelectedTracksToolStripMenuItem,
            this.removeAllTracksToolStripMenuItem,
            this.mergeCheckedTracksToolStripMenuItem,
            this.moveTrackUpToolStripMenuItem,
            this.downloadPathsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // checkAllFilesToolStripMenuItem
            // 
            this.checkAllFilesToolStripMenuItem.Name = "checkAllFilesToolStripMenuItem";
            this.checkAllFilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.checkAllFilesToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.checkAllFilesToolStripMenuItem.Text = "Check All Tracks";
            this.checkAllFilesToolStripMenuItem.Click += new System.EventHandler(this.checkAllFilesToolStripMenuItem_Click);
            // 
            // uncheckAllFilesToolStripMenuItem
            // 
            this.uncheckAllFilesToolStripMenuItem.Name = "uncheckAllFilesToolStripMenuItem";
            this.uncheckAllFilesToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.uncheckAllFilesToolStripMenuItem.Text = "Uncheck All Tracks";
            this.uncheckAllFilesToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(236, 6);
            // 
            // checkSelectedFilesToolStripMenuItem
            // 
            this.checkSelectedFilesToolStripMenuItem.Name = "checkSelectedFilesToolStripMenuItem";
            this.checkSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.checkSelectedFilesToolStripMenuItem.Text = "Check Selected Tracks";
            this.checkSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.checkSelectedFilesToolStripMenuItem_Click);
            // 
            // uncheckSelectedFilesToolStripMenuItem
            // 
            this.uncheckSelectedFilesToolStripMenuItem.Name = "uncheckSelectedFilesToolStripMenuItem";
            this.uncheckSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.uncheckSelectedFilesToolStripMenuItem.Text = "Uncheck Selected Tracks";
            this.uncheckSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.uncheckSelectedFilesToolStripMenuItem_Click);
            // 
            // onlyCheckSelectedFilesToolStripMenuItem
            // 
            this.onlyCheckSelectedFilesToolStripMenuItem.Name = "onlyCheckSelectedFilesToolStripMenuItem";
            this.onlyCheckSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.onlyCheckSelectedFilesToolStripMenuItem.Text = "Only Check Selected Tracks";
            this.onlyCheckSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.onlyCheckSelectedFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(236, 6);
            // 
            // removeSelectedTracksToolStripMenuItem
            // 
            this.removeSelectedTracksToolStripMenuItem.Name = "removeSelectedTracksToolStripMenuItem";
            this.removeSelectedTracksToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.removeSelectedTracksToolStripMenuItem.Text = "Remove Selected Tracks";
            this.removeSelectedTracksToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedTracksToolStripMenuItem_Click);
            // 
            // removeAllTracksToolStripMenuItem
            // 
            this.removeAllTracksToolStripMenuItem.Name = "removeAllTracksToolStripMenuItem";
            this.removeAllTracksToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.removeAllTracksToolStripMenuItem.Text = "Remove All Tracks";
            this.removeAllTracksToolStripMenuItem.Click += new System.EventHandler(this.removeAllTracksToolStripMenuItem_Click);
            // 
            // mergeCheckedTracksToolStripMenuItem
            // 
            this.mergeCheckedTracksToolStripMenuItem.Name = "mergeCheckedTracksToolStripMenuItem";
            this.mergeCheckedTracksToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.mergeCheckedTracksToolStripMenuItem.Text = "Merge Checked Tracks";
            this.mergeCheckedTracksToolStripMenuItem.Click += new System.EventHandler(this.mergeCheckedTracksToolStripMenuItem_Click);
            // 
            // moveTrackUpToolStripMenuItem
            // 
            this.moveTrackUpToolStripMenuItem.Name = "moveTrackUpToolStripMenuItem";
            this.moveTrackUpToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.moveTrackUpToolStripMenuItem.Text = "Move Track Up";
            this.moveTrackUpToolStripMenuItem.Click += new System.EventHandler(this.moveTrackUpToolStripMenuItem_Click);
            // 
            // downloadPathsToolStripMenuItem
            // 
            this.downloadPathsToolStripMenuItem.Name = "downloadPathsToolStripMenuItem";
            this.downloadPathsToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.downloadPathsToolStripMenuItem.Text = "Download Paths (experimental)";
            this.downloadPathsToolStripMenuItem.Click += new System.EventHandler(this.downloadPathsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkedTracksInfoToolStripMenuItem,
            this.chartToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // checkedTracksInfoToolStripMenuItem
            // 
            this.checkedTracksInfoToolStripMenuItem.Name = "checkedTracksInfoToolStripMenuItem";
            this.checkedTracksInfoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.checkedTracksInfoToolStripMenuItem.Text = "Checked Tracks Info";
            this.checkedTracksInfoToolStripMenuItem.Click += new System.EventHandler(this.checkedTracksInfoToolStripMenuItem_Click);
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.CheckOnClick = true;
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.chartToolStripMenuItem.Text = "Chart (experimental)";
            this.chartToolStripMenuItem.Click += new System.EventHandler(this.chartToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayUnitToolStripMenuItem,
            this.displayPrecisionToolStripMenuItem,
            this.googleMapsToolStripMenuItem,
            this.updatingToolStripMenuItem,
            this.uTCShiftToolStripMenuItem,
            this.trackSettingsToolStripMenuItem,
            this.geocodingSettingsToolStripMenuItem,
            this.gPXSettingsToolStripMenuItem,
            this.kMLSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // displayUnitToolStripMenuItem
            // 
            this.displayUnitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speedToolStripMenuItem,
            this.distanceToolStripMenuItem,
            this.elevationToolStripMenuItem});
            this.displayUnitToolStripMenuItem.Name = "displayUnitToolStripMenuItem";
            this.displayUnitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.displayUnitToolStripMenuItem.Text = "Display Unit";
            // 
            // speedToolStripMenuItem
            // 
            this.speedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speedMetricToolStripMenuItem,
            this.speedImperialToolStripMenuItem,
            this.speedNauticalToolStripMenuItem});
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.speedToolStripMenuItem.Text = "Speed";
            // 
            // speedMetricToolStripMenuItem
            // 
            this.speedMetricToolStripMenuItem.Checked = true;
            this.speedMetricToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.speedMetricToolStripMenuItem.Name = "speedMetricToolStripMenuItem";
            this.speedMetricToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.speedMetricToolStripMenuItem.Tag = "Radio";
            this.speedMetricToolStripMenuItem.Text = "Metric";
            this.speedMetricToolStripMenuItem.Click += new System.EventHandler(this.speedUnitMenuItem_Click);
            // 
            // speedImperialToolStripMenuItem
            // 
            this.speedImperialToolStripMenuItem.Name = "speedImperialToolStripMenuItem";
            this.speedImperialToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.speedImperialToolStripMenuItem.Tag = "Radio";
            this.speedImperialToolStripMenuItem.Text = "Imperial";
            this.speedImperialToolStripMenuItem.Click += new System.EventHandler(this.speedUnitMenuItem_Click);
            // 
            // speedNauticalToolStripMenuItem
            // 
            this.speedNauticalToolStripMenuItem.Name = "speedNauticalToolStripMenuItem";
            this.speedNauticalToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.speedNauticalToolStripMenuItem.Tag = "Radio";
            this.speedNauticalToolStripMenuItem.Text = "Nautical";
            this.speedNauticalToolStripMenuItem.Click += new System.EventHandler(this.speedUnitMenuItem_Click);
            // 
            // distanceToolStripMenuItem
            // 
            this.distanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distanceMetricToolStripMenuItem,
            this.distanceImperialToolStripMenuItem,
            this.distanceNauticalToolStripMenuItem});
            this.distanceToolStripMenuItem.Name = "distanceToolStripMenuItem";
            this.distanceToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.distanceToolStripMenuItem.Text = "Distance";
            this.distanceToolStripMenuItem.Click += new System.EventHandler(this.distanceUnitMenuItem_Click);
            // 
            // distanceMetricToolStripMenuItem
            // 
            this.distanceMetricToolStripMenuItem.Checked = true;
            this.distanceMetricToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.distanceMetricToolStripMenuItem.Name = "distanceMetricToolStripMenuItem";
            this.distanceMetricToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.distanceMetricToolStripMenuItem.Tag = "Radio";
            this.distanceMetricToolStripMenuItem.Text = "Metric";
            this.distanceMetricToolStripMenuItem.Click += new System.EventHandler(this.distanceUnitMenuItem_Click);
            // 
            // distanceImperialToolStripMenuItem
            // 
            this.distanceImperialToolStripMenuItem.Name = "distanceImperialToolStripMenuItem";
            this.distanceImperialToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.distanceImperialToolStripMenuItem.Tag = "Radio";
            this.distanceImperialToolStripMenuItem.Text = "Imperial";
            this.distanceImperialToolStripMenuItem.Click += new System.EventHandler(this.distanceUnitMenuItem_Click);
            // 
            // distanceNauticalToolStripMenuItem
            // 
            this.distanceNauticalToolStripMenuItem.Name = "distanceNauticalToolStripMenuItem";
            this.distanceNauticalToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.distanceNauticalToolStripMenuItem.Tag = "Radio";
            this.distanceNauticalToolStripMenuItem.Text = "Nautical";
            this.distanceNauticalToolStripMenuItem.Click += new System.EventHandler(this.distanceUnitMenuItem_Click);
            // 
            // elevationToolStripMenuItem
            // 
            this.elevationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elevationMetricToolStripMenuItem,
            this.elevationImperialToolStripMenuItem});
            this.elevationToolStripMenuItem.Name = "elevationToolStripMenuItem";
            this.elevationToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.elevationToolStripMenuItem.Text = "Elevation";
            // 
            // elevationMetricToolStripMenuItem
            // 
            this.elevationMetricToolStripMenuItem.Checked = true;
            this.elevationMetricToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.elevationMetricToolStripMenuItem.Name = "elevationMetricToolStripMenuItem";
            this.elevationMetricToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.elevationMetricToolStripMenuItem.Tag = "Radio";
            this.elevationMetricToolStripMenuItem.Text = "Metric";
            this.elevationMetricToolStripMenuItem.Click += new System.EventHandler(this.elevationUnitMenuItem_Click);
            // 
            // elevationImperialToolStripMenuItem
            // 
            this.elevationImperialToolStripMenuItem.Name = "elevationImperialToolStripMenuItem";
            this.elevationImperialToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.elevationImperialToolStripMenuItem.Tag = "Radio";
            this.elevationImperialToolStripMenuItem.Text = "Imperial";
            this.elevationImperialToolStripMenuItem.Click += new System.EventHandler(this.elevationUnitMenuItem_Click);
            // 
            // displayPrecisionToolStripMenuItem
            // 
            this.displayPrecisionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullToolStripMenuItem,
            this.nineDigitsToolStripMenuItem});
            this.displayPrecisionToolStripMenuItem.Name = "displayPrecisionToolStripMenuItem";
            this.displayPrecisionToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.displayPrecisionToolStripMenuItem.Text = "Display Precision";
            // 
            // fullToolStripMenuItem
            // 
            this.fullToolStripMenuItem.Checked = true;
            this.fullToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fullToolStripMenuItem.Name = "fullToolStripMenuItem";
            this.fullToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fullToolStripMenuItem.Tag = "Radio";
            this.fullToolStripMenuItem.Text = "Full";
            this.fullToolStripMenuItem.Click += new System.EventHandler(this.fullToolStripMenuItem_Click);
            // 
            // nineDigitsToolStripMenuItem
            // 
            this.nineDigitsToolStripMenuItem.Name = "nineDigitsToolStripMenuItem";
            this.nineDigitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nineDigitsToolStripMenuItem.Tag = "Radio";
            this.nineDigitsToolStripMenuItem.Text = "9 Significant Figures";
            this.nineDigitsToolStripMenuItem.Click += new System.EventHandler(this.nineDigitsToolStripMenuItem_Click);
            // 
            // googleMapsToolStripMenuItem
            // 
            this.googleMapsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallControlsToolStripMenuItem,
            this.normalControlsToolStripMenuItem,
            this.toolStripSeparator5,
            this.streetMapToolStripMenuItem,
            this.satelliteMapToolStripMenuItem,
            this.hybridMapToolStripMenuItem,
            this.terrainMapToolStripMenuItem,
            this.toolStripSeparator6,
            this.defaultMapTypeToolStripMenuItem,
            this.toolStripSeparator7,
            this.overviewMapToolStripMenuItem,
            this.toolStripSeparator8,
            this.advancedGMapsToolStripMenuItem});
            this.googleMapsToolStripMenuItem.Name = "googleMapsToolStripMenuItem";
            this.googleMapsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.googleMapsToolStripMenuItem.Text = "Google Maps";
            // 
            // smallControlsToolStripMenuItem
            // 
            this.smallControlsToolStripMenuItem.Name = "smallControlsToolStripMenuItem";
            this.smallControlsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.smallControlsToolStripMenuItem.Tag = "Radio";
            this.smallControlsToolStripMenuItem.Text = "Small Controls";
            this.smallControlsToolStripMenuItem.Click += new System.EventHandler(this.smallControlsToolStripMenuItem_Click);
            // 
            // normalControlsToolStripMenuItem
            // 
            this.normalControlsToolStripMenuItem.Name = "normalControlsToolStripMenuItem";
            this.normalControlsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.normalControlsToolStripMenuItem.Tag = "Radio";
            this.normalControlsToolStripMenuItem.Text = "Normal Controls";
            this.normalControlsToolStripMenuItem.Click += new System.EventHandler(this.normalControlsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(165, 6);
            // 
            // streetMapToolStripMenuItem
            // 
            this.streetMapToolStripMenuItem.Name = "streetMapToolStripMenuItem";
            this.streetMapToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.streetMapToolStripMenuItem.Text = "Street Map";
            this.streetMapToolStripMenuItem.Click += new System.EventHandler(this.streetMapToolStripMenuItem_Click);
            // 
            // satelliteMapToolStripMenuItem
            // 
            this.satelliteMapToolStripMenuItem.Name = "satelliteMapToolStripMenuItem";
            this.satelliteMapToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.satelliteMapToolStripMenuItem.Text = "Satellite Map";
            this.satelliteMapToolStripMenuItem.Click += new System.EventHandler(this.satelliteMapToolStripMenuItem_Click);
            // 
            // hybridMapToolStripMenuItem
            // 
            this.hybridMapToolStripMenuItem.Name = "hybridMapToolStripMenuItem";
            this.hybridMapToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.hybridMapToolStripMenuItem.Text = "Hybrid Map";
            this.hybridMapToolStripMenuItem.Click += new System.EventHandler(this.hybridMapToolStripMenuItem_Click);
            // 
            // terrainMapToolStripMenuItem
            // 
            this.terrainMapToolStripMenuItem.Name = "terrainMapToolStripMenuItem";
            this.terrainMapToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.terrainMapToolStripMenuItem.Text = "Terrain Map";
            this.terrainMapToolStripMenuItem.Click += new System.EventHandler(this.terrainMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(165, 6);
            // 
            // defaultMapTypeToolStripMenuItem
            // 
            this.defaultMapTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.streetDefaultToolStripMenuItem,
            this.satelliteDefaultToolStripMenuItem,
            this.hybridDefaultToolStripMenuItem});
            this.defaultMapTypeToolStripMenuItem.Name = "defaultMapTypeToolStripMenuItem";
            this.defaultMapTypeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.defaultMapTypeToolStripMenuItem.Text = "Default Map Type";
            // 
            // streetDefaultToolStripMenuItem
            // 
            this.streetDefaultToolStripMenuItem.Name = "streetDefaultToolStripMenuItem";
            this.streetDefaultToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.streetDefaultToolStripMenuItem.Tag = "Radio";
            this.streetDefaultToolStripMenuItem.Text = "Street";
            this.streetDefaultToolStripMenuItem.Click += new System.EventHandler(this.streetDefaultToolStripMenuItem_Click);
            // 
            // satelliteDefaultToolStripMenuItem
            // 
            this.satelliteDefaultToolStripMenuItem.Name = "satelliteDefaultToolStripMenuItem";
            this.satelliteDefaultToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.satelliteDefaultToolStripMenuItem.Tag = "Radio";
            this.satelliteDefaultToolStripMenuItem.Text = "Satellite";
            this.satelliteDefaultToolStripMenuItem.Click += new System.EventHandler(this.satelliteDefaultToolStripMenuItem_Click);
            // 
            // hybridDefaultToolStripMenuItem
            // 
            this.hybridDefaultToolStripMenuItem.Name = "hybridDefaultToolStripMenuItem";
            this.hybridDefaultToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.hybridDefaultToolStripMenuItem.Tag = "Radio";
            this.hybridDefaultToolStripMenuItem.Text = "Hybrid";
            this.hybridDefaultToolStripMenuItem.Click += new System.EventHandler(this.hybridDefaultToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(165, 6);
            // 
            // overviewMapToolStripMenuItem
            // 
            this.overviewMapToolStripMenuItem.Name = "overviewMapToolStripMenuItem";
            this.overviewMapToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.overviewMapToolStripMenuItem.Text = "Overview Map";
            this.overviewMapToolStripMenuItem.Click += new System.EventHandler(this.overviewMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(165, 6);
            // 
            // advancedGMapsToolStripMenuItem
            // 
            this.advancedGMapsToolStripMenuItem.Name = "advancedGMapsToolStripMenuItem";
            this.advancedGMapsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.advancedGMapsToolStripMenuItem.Text = "Advanced...";
            this.advancedGMapsToolStripMenuItem.Click += new System.EventHandler(this.advancedGMapsToolStripMenuItem_Click);
            // 
            // updatingToolStripMenuItem
            // 
            this.updatingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automaticallyCheckForNewVersionsToolStripMenuItem});
            this.updatingToolStripMenuItem.Name = "updatingToolStripMenuItem";
            this.updatingToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.updatingToolStripMenuItem.Text = "Updating";
            // 
            // automaticallyCheckForNewVersionsToolStripMenuItem
            // 
            this.automaticallyCheckForNewVersionsToolStripMenuItem.Checked = true;
            this.automaticallyCheckForNewVersionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automaticallyCheckForNewVersionsToolStripMenuItem.Name = "automaticallyCheckForNewVersionsToolStripMenuItem";
            this.automaticallyCheckForNewVersionsToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.automaticallyCheckForNewVersionsToolStripMenuItem.Text = "Automatically Check For New Versions";
            this.automaticallyCheckForNewVersionsToolStripMenuItem.Click += new System.EventHandler(this.automaticallyCheckForNewVersionsToolStripMenuItem_Click);
            // 
            // uTCShiftToolStripMenuItem
            // 
            this.uTCShiftToolStripMenuItem.Name = "uTCShiftToolStripMenuItem";
            this.uTCShiftToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.uTCShiftToolStripMenuItem.Text = "UTC Shift...";
            this.uTCShiftToolStripMenuItem.Click += new System.EventHandler(this.uTCShiftToolStripMenuItem_Click);
            // 
            // trackSettingsToolStripMenuItem
            // 
            this.trackSettingsToolStripMenuItem.Name = "trackSettingsToolStripMenuItem";
            this.trackSettingsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.trackSettingsToolStripMenuItem.Text = "Track Settings...";
            this.trackSettingsToolStripMenuItem.Click += new System.EventHandler(this.trackSettingsToolStripMenuItem_Click);
            // 
            // geocodingSettingsToolStripMenuItem
            // 
            this.geocodingSettingsToolStripMenuItem.Name = "geocodingSettingsToolStripMenuItem";
            this.geocodingSettingsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.geocodingSettingsToolStripMenuItem.Text = "Geocoding Settings...";
            this.geocodingSettingsToolStripMenuItem.Click += new System.EventHandler(this.geocodingSettingsToolStripMenuItem_Click);
            // 
            // gPXSettingsToolStripMenuItem
            // 
            this.gPXSettingsToolStripMenuItem.Name = "gPXSettingsToolStripMenuItem";
            this.gPXSettingsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.gPXSettingsToolStripMenuItem.Text = "GPX Settings...";
            this.gPXSettingsToolStripMenuItem.Click += new System.EventHandler(this.gPXSettingsToolStripMenuItem_Click);
            // 
            // kMLSettingsToolStripMenuItem
            // 
            this.kMLSettingsToolStripMenuItem.Name = "kMLSettingsToolStripMenuItem";
            this.kMLSettingsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.kMLSettingsToolStripMenuItem.Text = "KML Settings...";
            this.kMLSettingsToolStripMenuItem.Click += new System.EventHandler(this.kMLSettingsToolStripMenuItem_Click);
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.portToolStripMenuItem.Text = "&Port";
            // 
            // memoryToolStripMenuItem
            // 
            this.memoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.identificationToolStripMenuItem,
            this.toolStripSeparator10,
            this.readToolStripMenuItem,
            this.downloadLatestTracksToolStripMenuItem,
            this.toolStripSeparator9,
            this.gPSMouseToolStripMenuItem1,
            this.toolStripSeparator4,
            this.clearToolStripMenuItem});
            this.memoryToolStripMenuItem.Name = "memoryToolStripMenuItem";
            this.memoryToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.memoryToolStripMenuItem.Text = "&Device";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.configurationToolStripMenuItem.Text = "Configuration...";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // identificationToolStripMenuItem
            // 
            this.identificationToolStripMenuItem.Name = "identificationToolStripMenuItem";
            this.identificationToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.identificationToolStripMenuItem.Text = "Identification";
            this.identificationToolStripMenuItem.Click += new System.EventHandler(this.identificationToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(205, 6);
            // 
            // readToolStripMenuItem
            // 
            this.readToolStripMenuItem.Name = "readToolStripMenuItem";
            this.readToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.readToolStripMenuItem.Text = "Download All Tracks";
            this.readToolStripMenuItem.Click += new System.EventHandler(this.readToolStripMenuItem_Click);
            // 
            // downloadLatestTracksToolStripMenuItem
            // 
            this.downloadLatestTracksToolStripMenuItem.Name = "downloadLatestTracksToolStripMenuItem";
            this.downloadLatestTracksToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.downloadLatestTracksToolStripMenuItem.Text = "Download Latest Tracks...";
            this.downloadLatestTracksToolStripMenuItem.Click += new System.EventHandler(this.downloadLatestTracksToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(205, 6);
            // 
            // gPSMouseToolStripMenuItem1
            // 
            this.gPSMouseToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.gPSMouseToolStripMenuItem1.Name = "gPSMouseToolStripMenuItem1";
            this.gPSMouseToolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            this.gPSMouseToolStripMenuItem1.Text = "GPS Mouse";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(205, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.clearToolStripMenuItem.Text = "Clear Memory";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForNewVersionToolStripMenuItem,
            this.aboutDGManagerToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // checkForNewVersionToolStripMenuItem
            // 
            this.checkForNewVersionToolStripMenuItem.Name = "checkForNewVersionToolStripMenuItem";
            this.checkForNewVersionToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.checkForNewVersionToolStripMenuItem.Text = "Check For New Version";
            this.checkForNewVersionToolStripMenuItem.Click += new System.EventHandler(this.checkForNewVersionToolStripMenuItem_Click);
            // 
            // aboutDGManagerToolStripMenuItem
            // 
            this.aboutDGManagerToolStripMenuItem.Name = "aboutDGManagerToolStripMenuItem";
            this.aboutDGManagerToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.aboutDGManagerToolStripMenuItem.Text = "About DG Manager.NET";
            this.aboutDGManagerToolStripMenuItem.Click += new System.EventHandler(this.aboutDGManagerToolStripMenuItem_Click);
            // 
            // Port
            // 
            this.Port.BaudRate = 115200;
            this.Port.PortName = "null";
            this.Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Port_DataReceived);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "*.gpx";
            // 
            // DataOperationBackgroundWorker
            // 
            this.DataOperationBackgroundWorker.WorkerReportsProgress = true;
            this.DataOperationBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UpdateProgress);
            this.DataOperationBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FileOperationBackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 508);
            this.Controls.Add(this.TopBottomSplitContainer);
            this.Controls.Add(this.BottomStatusStrip);
            this.Controls.Add(this.TopMenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DG Manager.NET";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_Drag);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_Drag);
            this.BottomStatusStrip.ResumeLayout(false);
            this.BottomStatusStrip.PerformLayout();
            this.LeftRightSplitContainer.Panel1.ResumeLayout(false);
            this.LeftRightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftRightSplitContainer)).EndInit();
            this.LeftRightSplitContainer.ResumeLayout(false);
            this.LeftTopBottomSplitContainer.Panel1.ResumeLayout(false);
            this.LeftTopBottomSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftTopBottomSplitContainer)).EndInit();
            this.LeftTopBottomSplitContainer.ResumeLayout(false);
            this.contextMenuTracks.ResumeLayout(false);
            this.TrimPointsGroupBox.ResumeLayout(false);
            this.TrimPointsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrimEndTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrimStartTrackBar)).EndInit();
            this.RightTabControl.ResumeLayout(false);
            this.PointsTabPage.ResumeLayout(false);
            this.contextMenuPoints.ResumeLayout(false);
            this.PhotoGeocodingTabPage.ResumeLayout(false);
            this.GeocodingSplitContainer.Panel1.ResumeLayout(false);
            this.GeocodingSplitContainer.Panel1.PerformLayout();
            this.GeocodingSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GeocodingSplitContainer)).EndInit();
            this.GeocodingSplitContainer.ResumeLayout(false);
            this.OffsetGroupBox.ResumeLayout(false);
            this.OffsetGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraOffsetSecondsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraOffsetHoursUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraOffsetMinutesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhotosGridView)).EndInit();
            this.tabPagePreview.ResumeLayout(false);
            this.tabPageChart.ResumeLayout(false);
            this.TopBottomSplitContainer.Panel1.ResumeLayout(false);
            this.TopBottomSplitContainer.Panel2.ResumeLayout(false);
            this.TopBottomSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopBottomSplitContainer)).EndInit();
            this.TopBottomSplitContainer.ResumeLayout(false);
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip TopMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem memoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkAllFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uncheckAllFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem checkSelectedFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem displayUnitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uTCShiftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem displayPrecisionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fullToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nineDigitsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem identificationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem readToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutDGManagerToolStripMenuItem;
		private System.Windows.Forms.StatusStrip BottomStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel PortStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel SeparatorStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel UtcStatusLabel;
		private System.Windows.Forms.SplitContainer LeftRightSplitContainer;
		private System.Windows.Forms.TextBox LogTextBox;
		private TreeViewMultiSelect TracksTreeView;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.SplitContainer TopBottomSplitContainer;
		private System.Windows.Forms.ToolStripMenuItem googleMapsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem smallControlsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem normalControlsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem streetMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem satelliteMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hybridMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem overviewMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem defaultMapTypeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem streetDefaultToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem satelliteDefaultToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hybridDefaultToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.IO.Ports.SerialPort Port;
		private System.Windows.Forms.ToolStripMenuItem uncheckSelectedFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem onlyCheckSelectedFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripProgressBar WorkProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel DisplayUnitStatusLabel;
		private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.ComponentModel.BackgroundWorker DataOperationBackgroundWorker;
		private System.Windows.Forms.ToolStripMenuItem trackSettingsToolStripMenuItem;
		private System.Windows.Forms.TabControl RightTabControl;
        private System.Windows.Forms.TabPage PointsTabPage;
		private System.Windows.Forms.TabPage MapTabPage;
		private System.Windows.Forms.SplitContainer LeftTopBottomSplitContainer;
		private System.Windows.Forms.GroupBox TrimPointsGroupBox;
		private System.Windows.Forms.TrackBar TrimStartTrackBar;
		private System.Windows.Forms.Label TrimEndLabel;
		private System.Windows.Forms.TrackBar TrimEndTrackBar;
		private System.Windows.Forms.Label TrimStartLabel;
		private System.Windows.Forms.Button ResetTrimTrackBarsButton;
		private System.Windows.Forms.CheckBox EnableTrimPointsCheckBox;
		private System.Windows.Forms.TabPage PhotoGeocodingTabPage;
		private System.Windows.Forms.DataGridView PhotosGridView;
		private System.Windows.Forms.SplitContainer GeocodingSplitContainer;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.Button PerformGeocodingButton;
		private System.Windows.Forms.Button AddPhotosButton;
		private System.Windows.Forms.OpenFileDialog OpenMultiFilesDialog;
		private System.Windows.Forms.Button ToggleShowAllOnMapButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem advancedGMapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geocodingSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gPXSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkedTracksInfoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem speedMetricToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem speedImperialToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem speedNauticalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem distanceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem distanceMetricToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem distanceImperialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distanceNauticalToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem downloadLatestTracksToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkForNewVersionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updatingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem automaticallyCheckForNewVersionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem gPSMouseToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem removeAllTracksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedTracksToolStripMenuItem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown CameraOffsetSecondsUpDown;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown CameraOffsetMinutesUpDown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown CameraOffsetHoursUpDown;
		private System.Windows.Forms.ComboBox CameraOffsetSignComboBox;
		private System.Windows.Forms.GroupBox OffsetGroupBox;
		private System.Windows.Forms.LinkLabel AdvancedSettingsLinkLabel;
		private System.Windows.Forms.LinkLabel SetOffsetLinkLabel;
		private System.Windows.Forms.CheckBox CameraOffsetEnabledCheckBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel ResetOffsetLinkLabel;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ShowOnMapColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn PathColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn TimeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn LatitudeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn LongitudeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationColumn;
		private System.Windows.Forms.ToolStripMenuItem kMLSettingsToolStripMenuItem;
        private System.Windows.Forms.ListView PointsListView;
    	private System.Windows.Forms.ContextMenuStrip photosContextMenuStrip;
    	private System.Windows.Forms.ToolStripMenuItem manuallyGeocodeSelectedPhotosToolStripMenuItem;
    	private System.Windows.Forms.ContextMenuStrip contextMenuPoints;
		private System.Windows.Forms.ToolStripMenuItem splitTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setTrimStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setTrimEndToolStripMenuItem;
        private System.Windows.Forms.Button seperateTracksButton;
        private System.Windows.Forms.ToolStripMenuItem elevationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elevationMetricToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elevationImperialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeCheckedTracksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveTrackUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePointsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPagePreview;
        private TrackPreview trackPreview1;
        private System.Windows.Forms.ContextMenuStrip contextMenuTracks;
        private System.Windows.Forms.ToolStripMenuItem reducePointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terrainMapToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageChart;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.ToolStripMenuItem deleteTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDirections;
        private System.Windows.Forms.ToolStripMenuItem downloadPathsToolStripMenuItem;
        private System.Windows.Forms.Button CommitGeocodingButton;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.Button trimTrackButton;
    }
}

