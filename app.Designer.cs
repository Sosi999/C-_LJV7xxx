namespace LJV7_DllSampleAll
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._btnUsbOpen = new System.Windows.Forms.Button();
            this._btnGetTime = new System.Windows.Forms.Button();
            this._btnGetVersion = new System.Windows.Forms.Button();
            this._btnFinalize = new System.Windows.Forms.Button();
            this._btnInitialize = new System.Windows.Forms.Button();
            this._btnCommClose = new System.Windows.Forms.Button();
            this._btnEthernetOpen = new System.Windows.Forms.Button();
            this._grpCommand = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this._btnHighSpeedDataUsbCommunicationInitalize = new System.Windows.Forms.Button();
            this._btnHighSpeedDataEthernetCommunicationInitalize = new System.Windows.Forms.Button();
            this._btnPreStartHighSpeedDataCommunication = new System.Windows.Forms.Button();
            this._btnStartHighSpeedDataCommunication = new System.Windows.Forms.Button();
            this._btnStopHighSpeedDataCommunication = new System.Windows.Forms.Button();
            this._btnHighSpeedDataCommunicationFinalize = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this._btnStartStorage = new System.Windows.Forms.Button();
            this._btnStopStorage = new System.Windows.Forms.Button();
            this._btnGetStorageStatus = new System.Windows.Forms.Button();
            this._btnGetStorageData = new System.Windows.Forms.Button();
            this._btnGetStorageProfile = new System.Windows.Forms.Button();
            this._btnGetStorageBatchProfile = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._btnGetMeasurementValue = new System.Windows.Forms.Button();
            this._btnGetProfile = new System.Windows.Forms.Button();
            this._btnGetBatchProfile = new System.Windows.Forms.Button();
            this._btnGetBatchProfileAdvance = new System.Windows.Forms.Button();
            this._btnGetProfileAdvance = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._btnSetSetting = new System.Windows.Forms.Button();
            this._btnGetSetting = new System.Windows.Forms.Button();
            this._btnInitializeSetting = new System.Windows.Forms.Button();
            this._btnUpdataSetting = new System.Windows.Forms.Button();
            this._btnRewriteTemporarySetting = new System.Windows.Forms.Button();
            this._btnCheckMemoryAccess = new System.Windows.Forms.Button();
            this._btnSetTime = new System.Windows.Forms.Button();
            this._btnGetActiveProgram = new System.Windows.Forms.Button();
            this._btnChangeActiveProgram = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._btnTrigger = new System.Windows.Forms.Button();
            this._btnStartMeasure = new System.Windows.Forms.Button();
            this._btnStopMeasure = new System.Windows.Forms.Button();
            this._btnAutoZero = new System.Windows.Forms.Button();
            this._btnClearMemory = new System.Windows.Forms.Button();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnTiming = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._btnRebootController = new System.Windows.Forms.Button();
            this._btnRetrunToFactorySetting = new System.Windows.Forms.Button();
            this._btnGetError = new System.Windows.Forms.Button();
            this._btnClearError = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._grpLog = new System.Windows.Forms.GroupBox();
            this._txtboxLog = new System.Windows.Forms.TextBox();
            this._btnLogClear = new System.Windows.Forms.Button();
            this._grpBufferSize = new System.Windows.Forms.GroupBox();
            this._lblSettingAttention = new System.Windows.Forms.Label();
            this._grpReceived = new System.Windows.Forms.GroupBox();
            this._chkboxEnvelope = new System.Windows.Forms.CheckBox();
            this._cmbCompressX = new System.Windows.Forms.ComboBox();
            this._lblCompressX = new System.Windows.Forms.Label();
            this._grpMeasureRange = new System.Windows.Forms.GroupBox();
            this._cmbReceivedBinning = new System.Windows.Forms.ComboBox();
            this._cmbMeasureX = new System.Windows.Forms.ComboBox();
            this._lblReceivedBinning = new System.Windows.Forms.Label();
            this._lblMeasureX = new System.Windows.Forms.Label();
            this._grpHead = new System.Windows.Forms.GroupBox();
            this._rdbtnOneHead = new System.Windows.Forms.RadioButton();
            this._rdbtnTwoHead = new System.Windows.Forms.RadioButton();
            this._rdbtnWide = new System.Windows.Forms.RadioButton();
            this._grpExport = new System.Windows.Forms.GroupBox();
            this._nudProfileNo = new System.Windows.Forms.NumericUpDown();
            this._txtboxProfileFilePath = new System.Windows.Forms.TextBox();
            this._btnSaveMeasureData = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnProfileFileSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._lblSavePath = new System.Windows.Forms.Label();
            this._profileFileSave = new System.Windows.Forms.SaveFileDialog();
            this._timerHighSpeedReceive = new System.Windows.Forms.Timer(this.components);
            this._lblReceiveProfileCount0 = new System.Windows.Forms.Label();
            this._rdDevice0 = new System.Windows.Forms.RadioButton();
            this._rdDevice2 = new System.Windows.Forms.RadioButton();
            this._rdDevice1 = new System.Windows.Forms.RadioButton();
            this._pnlDeviceId = new System.Windows.Forms.Panel();
            this._lblDeviceStatus5 = new System.Windows.Forms.Label();
            this._lblDeviceStatus4 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this._lblReceiveProfileCount5 = new System.Windows.Forms.Label();
            this._lblReceiveProfileCount4 = new System.Windows.Forms.Label();
            this._lblReceiveProfileCount3 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._lblReceiveProfileCount1 = new System.Windows.Forms.Label();
            this._lblReceiveProfileCount2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._lblDeviceStatus3 = new System.Windows.Forms.Label();
            this._lblDeviceStatus2 = new System.Windows.Forms.Label();
            this._lblDeviceStatus1 = new System.Windows.Forms.Label();
            this._lblDeviceStatus0 = new System.Windows.Forms.Label();
            this._rdDevice3 = new System.Windows.Forms.RadioButton();
            this._chkOnlyProfileCount = new System.Windows.Forms.CheckBox();
            this._chkStartTimer = new System.Windows.Forms.CheckBox();
            this._numInterval = new System.Windows.Forms.NumericUpDown();
            this._rdEthernet1 = new System.Windows.Forms.TabControl();
            this._tabPage1 = new System.Windows.Forms.TabPage();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._lblConectedDevice = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this._tabPage2 = new System.Windows.Forms.TabPage();
            this._grpProgram = new System.Windows.Forms.GroupBox();
            this._btnUploadProgram = new System.Windows.Forms.Button();
            this._btnDownloadProgram = new System.Windows.Forms.Button();
            this._btnReferenceProgramFilePath = new System.Windows.Forms.Button();
            this._txtProgramFilePath = new System.Windows.Forms.TextBox();
            this._lblSelectProgram = new System.Windows.Forms.Label();
            this._cbxSelectProgram = new System.Windows.Forms.ComboBox();
            this._grpHighSpeed = new System.Windows.Forms.GroupBox();
            this._txtCallbackFrequency = new System.Windows.Forms.TextBox();
            this._txtStartProfileNo = new System.Windows.Forms.TextBox();
            this._lblReceiveProfileCount = new System.Windows.Forms.Label();
            this._lblCallbackFrequency = new System.Windows.Forms.Label();
            this._btnTerminateHighSpeedCommunication = new System.Windows.Forms.Button();
            this._lblHighSpeedStartNo = new System.Windows.Forms.Label();
            this._lblReceiveCount = new System.Windows.Forms.Label();
            this._btnBeginHighSpeedDataCommunication = new System.Windows.Forms.Button();
            this._grpGetData = new System.Windows.Forms.GroupBox();
            this._txtMeasureData = new System.Windows.Forms.TextBox();
            this._grpGetProfile = new System.Windows.Forms.GroupBox();
            this._btnGetProfileAdvanceData = new System.Windows.Forms.Button();
            this._btnReferenceSavePath = new System.Windows.Forms.Button();
            this._btnGetBatchProfileDataAdvance = new System.Windows.Forms.Button();
            this._btnGetBatchProfileData = new System.Windows.Forms.Button();
            this._btnGetProfileData = new System.Windows.Forms.Button();
            this._txtSavePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnGetLatestMeasureValue = new System.Windows.Forms.Button();
            this._grpBaseOperation = new System.Windows.Forms.GroupBox();
            this._pnlCommunicationDevice = new System.Windows.Forms.Panel();
            this._rdUsb = new System.Windows.Forms.RadioButton();
            this._rdEthernet = new System.Windows.Forms.RadioButton();
            this._grpEthernetSetting = new System.Windows.Forms.GroupBox();
            this._txtIpFirstSegment = new System.Windows.Forms.TextBox();
            this._txtIpFourthSegment = new System.Windows.Forms.TextBox();
            this._txtIpSecondSegment = new System.Windows.Forms.TextBox();
            this._lblHighSpeedPort = new System.Windows.Forms.Label();
            this._txtIpThirdSegment = new System.Windows.Forms.TextBox();
            this._lblIpSeparator3 = new System.Windows.Forms.Label();
            this._lblIpSeparator2 = new System.Windows.Forms.Label();
            this._txtHighSpeedPort = new System.Windows.Forms.TextBox();
            this._lblIpSeparator1 = new System.Windows.Forms.Label();
            this._txtCommandPort = new System.Windows.Forms.TextBox();
            this._lblIpAddress = new System.Windows.Forms.Label();
            this._lblCommandPort = new System.Windows.Forms.Label();
            this._btnTerminateCommunication = new System.Windows.Forms.Button();
            this._btnEstablishCommunication = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnClearCommands = new System.Windows.Forms.Button();
            this.listBoxCommands = new System.Windows.Forms.ListBox();
            this.bntRefreshPorts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLinkFileSample = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.linkFileSample = new System.Windows.Forms.TextBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.linkSaveOneProfile = new System.Windows.Forms.TextBox();
            this.drawOneProfile = new System.Windows.Forms.Button();
            this.btnSaveOneProfile = new System.Windows.Forms.Button();
            this.btnLinkOneProfile = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.delayTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAutoDraw = new System.Windows.Forms.Button();
            this.btnSaveAutoProfile = new System.Windows.Forms.Button();
            this.linkSaveAutoProfile = new System.Windows.Forms.TextBox();
            this.btnLinkAutoProfile = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this._txtIpFirstSegment1 = new System.Windows.Forms.TextBox();
            this._txtIpFourthSegment1 = new System.Windows.Forms.TextBox();
            this._txtIpSecondSegment1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._txtIpThirdSegment1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._txtHighSpeedPort1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._txtCommandPort1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cartesianChartXY = new LiveCharts.WinForms.CartesianChart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.BtnScanArea = new System.Windows.Forms.Button();
            this.lblImageName = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtLinePeriod = new System.Windows.Forms.TextBox();
            this.txtSizeH = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSizeW = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.lblCurrentPose = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.btnAutoMode = new System.Windows.Forms.Button();
            this.btnTeachMode = new System.Windows.Forms.Button();
            this.grpTeach = new System.Windows.Forms.GroupBox();
            this.lblTemplatePath = new System.Windows.Forms.Label();
            this.btnLoadTemplate = new System.Windows.Forms.Button();
            this.btnSaveTemplate = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chkStopOnNG = new System.Windows.Forms.CheckBox();
            this.btnDistMinus = new System.Windows.Forms.Button();
            this.btnDistPlus = new System.Windows.Forms.Button();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.txtDistance1 = new System.Windows.Forms.Label();
            this.btnPos4 = new System.Windows.Forms.Button();
            this.btnPos2 = new System.Windows.Forms.Button();
            this.btnPos3 = new System.Windows.Forms.Button();
            this.btnPos1 = new System.Windows.Forms.Button();
            this.btnZm = new System.Windows.Forms.Button();
            this.btnZp = new System.Windows.Forms.Button();
            this.btnYm = new System.Windows.Forms.Button();
            this.btnYp = new System.Windows.Forms.Button();
            this.btnXm = new System.Windows.Forms.Button();
            this.btnXp = new System.Windows.Forms.Button();
            this.btnSpeedMinus = new System.Windows.Forms.Button();
            this.btnSpeedPlus = new System.Windows.Forms.Button();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.txtSpeed1 = new System.Windows.Forms.Label();
            this._timerHighSpeed = new System.Windows.Forms.Timer(this.components);
            this._openProgramFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._grpCommand.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._groupBox1.SuspendLayout();
            this._grpLog.SuspendLayout();
            this._grpBufferSize.SuspendLayout();
            this._grpReceived.SuspendLayout();
            this._grpMeasureRange.SuspendLayout();
            this._grpHead.SuspendLayout();
            this._grpExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudProfileNo)).BeginInit();
            this._pnlDeviceId.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numInterval)).BeginInit();
            this._rdEthernet1.SuspendLayout();
            this._tabPage1.SuspendLayout();
            this._groupBox.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this._tabPage2.SuspendLayout();
            this._grpProgram.SuspendLayout();
            this._grpHighSpeed.SuspendLayout();
            this._grpGetData.SuspendLayout();
            this._grpGetProfile.SuspendLayout();
            this._grpBaseOperation.SuspendLayout();
            this._pnlCommunicationDevice.SuspendLayout();
            this._grpEthernetSetting.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.grpTeach.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnUsbOpen
            // 
            this._btnUsbOpen.BackColor = System.Drawing.Color.LightGray;
            this._btnUsbOpen.Location = new System.Drawing.Point(6, 18);
            this._btnUsbOpen.Name = "_btnUsbOpen";
            this._btnUsbOpen.Size = new System.Drawing.Size(145, 23);
            this._btnUsbOpen.TabIndex = 0;
            this._btnUsbOpen.Text = "UsbOpen";
            this._btnUsbOpen.UseVisualStyleBackColor = false;
            this._btnUsbOpen.Click += new System.EventHandler(this.btnUsbOpen_Click);
            // 
            // _btnGetTime
            // 
            this._btnGetTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnGetTime.Location = new System.Drawing.Point(452, 48);
            this._btnGetTime.Name = "_btnGetTime";
            this._btnGetTime.Size = new System.Drawing.Size(143, 23);
            this._btnGetTime.TabIndex = 7;
            this._btnGetTime.Text = "GetTime";
            this._btnGetTime.UseVisualStyleBackColor = false;
            this._btnGetTime.Click += new System.EventHandler(this.btnGetTime_Click);
            // 
            // _btnGetVersion
            // 
            this._btnGetVersion.Location = new System.Drawing.Point(156, 18);
            this._btnGetVersion.Name = "_btnGetVersion";
            this._btnGetVersion.Size = new System.Drawing.Size(136, 23);
            this._btnGetVersion.TabIndex = 1;
            this._btnGetVersion.Text = "GetVersion";
            this._btnGetVersion.UseVisualStyleBackColor = true;
            this._btnGetVersion.Click += new System.EventHandler(this.btnGetVersion_Click);
            // 
            // _btnFinalize
            // 
            this._btnFinalize.Location = new System.Drawing.Point(303, 18);
            this._btnFinalize.Name = "_btnFinalize";
            this._btnFinalize.Size = new System.Drawing.Size(143, 23);
            this._btnFinalize.TabIndex = 2;
            this._btnFinalize.Text = "Finalize";
            this._btnFinalize.UseVisualStyleBackColor = true;
            this._btnFinalize.Click += new System.EventHandler(this.btnFinalize_Click);
            // 
            // _btnInitialize
            // 
            this._btnInitialize.Location = new System.Drawing.Point(6, 18);
            this._btnInitialize.Name = "_btnInitialize";
            this._btnInitialize.Size = new System.Drawing.Size(144, 23);
            this._btnInitialize.TabIndex = 0;
            this._btnInitialize.Text = "Initialize";
            this._btnInitialize.UseVisualStyleBackColor = true;
            this._btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // _btnCommClose
            // 
            this._btnCommClose.BackColor = System.Drawing.Color.LightGray;
            this._btnCommClose.Location = new System.Drawing.Point(304, 18);
            this._btnCommClose.Name = "_btnCommClose";
            this._btnCommClose.Size = new System.Drawing.Size(143, 23);
            this._btnCommClose.TabIndex = 2;
            this._btnCommClose.Text = "CommClose";
            this._btnCommClose.UseVisualStyleBackColor = false;
            this._btnCommClose.Click += new System.EventHandler(this.btnCommClose_Click);
            // 
            // _btnEthernetOpen
            // 
            this._btnEthernetOpen.BackColor = System.Drawing.Color.LightGray;
            this._btnEthernetOpen.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnEthernetOpen.Location = new System.Drawing.Point(157, 18);
            this._btnEthernetOpen.Name = "_btnEthernetOpen";
            this._btnEthernetOpen.Size = new System.Drawing.Size(136, 23);
            this._btnEthernetOpen.TabIndex = 1;
            this._btnEthernetOpen.Text = "EthernetOpen";
            this._btnEthernetOpen.UseVisualStyleBackColor = false;
            this._btnEthernetOpen.Click += new System.EventHandler(this.btnEthernetOpen_Click);
            // 
            // _grpCommand
            // 
            this._grpCommand.BackColor = System.Drawing.Color.Linen;
            this._grpCommand.Controls.Add(this.groupBox7);
            this._grpCommand.Controls.Add(this.groupBox6);
            this._grpCommand.Controls.Add(this.groupBox5);
            this._grpCommand.Controls.Add(this.groupBox4);
            this._grpCommand.Controls.Add(this.groupBox3);
            this._grpCommand.Controls.Add(this.groupBox2);
            this._grpCommand.Controls.Add(this.groupBox1);
            this._grpCommand.Controls.Add(this._groupBox1);
            this._grpCommand.Location = new System.Drawing.Point(3, 3);
            this._grpCommand.Name = "_grpCommand";
            this._grpCommand.Size = new System.Drawing.Size(618, 675);
            this._grpCommand.TabIndex = 0;
            this._grpCommand.TabStop = false;
            this._grpCommand.Text = "Communication command";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this._btnHighSpeedDataUsbCommunicationInitalize);
            this.groupBox7.Controls.Add(this._btnHighSpeedDataEthernetCommunicationInitalize);
            this.groupBox7.Controls.Add(this._btnPreStartHighSpeedDataCommunication);
            this.groupBox7.Controls.Add(this._btnStartHighSpeedDataCommunication);
            this.groupBox7.Controls.Add(this._btnStopHighSpeedDataCommunication);
            this.groupBox7.Controls.Add(this._btnHighSpeedDataCommunicationFinalize);
            this.groupBox7.Location = new System.Drawing.Point(9, 557);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(603, 110);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "High-speed data communication related functions";
            // 
            // _btnHighSpeedDataUsbCommunicationInitalize
            // 
            this._btnHighSpeedDataUsbCommunicationInitalize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._btnHighSpeedDataUsbCommunicationInitalize.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnHighSpeedDataUsbCommunicationInitalize.Location = new System.Drawing.Point(6, 18);
            this._btnHighSpeedDataUsbCommunicationInitalize.Name = "_btnHighSpeedDataUsbCommunicationInitalize";
            this._btnHighSpeedDataUsbCommunicationInitalize.Size = new System.Drawing.Size(141, 41);
            this._btnHighSpeedDataUsbCommunicationInitalize.TabIndex = 0;
            this._btnHighSpeedDataUsbCommunicationInitalize.Text = "HighSpeedDataUSB CommunicationInitalize";
            this._btnHighSpeedDataUsbCommunicationInitalize.UseVisualStyleBackColor = false;
            this._btnHighSpeedDataUsbCommunicationInitalize.Click += new System.EventHandler(this.btnHighSpeedDataUsbCommunicationInitalize_Click);
            // 
            // _btnHighSpeedDataEthernetCommunicationInitalize
            // 
            this._btnHighSpeedDataEthernetCommunicationInitalize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._btnHighSpeedDataEthernetCommunicationInitalize.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnHighSpeedDataEthernetCommunicationInitalize.Location = new System.Drawing.Point(153, 18);
            this._btnHighSpeedDataEthernetCommunicationInitalize.Name = "_btnHighSpeedDataEthernetCommunicationInitalize";
            this._btnHighSpeedDataEthernetCommunicationInitalize.Size = new System.Drawing.Size(141, 41);
            this._btnHighSpeedDataEthernetCommunicationInitalize.TabIndex = 1;
            this._btnHighSpeedDataEthernetCommunicationInitalize.Text = "HighSpeedDataEthernet CommunicationInitalize";
            this._btnHighSpeedDataEthernetCommunicationInitalize.UseVisualStyleBackColor = false;
            this._btnHighSpeedDataEthernetCommunicationInitalize.Click += new System.EventHandler(this.btnHighSpeedDataEthernetCommunicationInitalize_Click);
            // 
            // _btnPreStartHighSpeedDataCommunication
            // 
            this._btnPreStartHighSpeedDataCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._btnPreStartHighSpeedDataCommunication.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnPreStartHighSpeedDataCommunication.Location = new System.Drawing.Point(300, 18);
            this._btnPreStartHighSpeedDataCommunication.Name = "_btnPreStartHighSpeedDataCommunication";
            this._btnPreStartHighSpeedDataCommunication.Size = new System.Drawing.Size(145, 41);
            this._btnPreStartHighSpeedDataCommunication.TabIndex = 2;
            this._btnPreStartHighSpeedDataCommunication.Text = "PreStartHighSpeedData Communication";
            this._btnPreStartHighSpeedDataCommunication.UseVisualStyleBackColor = false;
            this._btnPreStartHighSpeedDataCommunication.Click += new System.EventHandler(this.btnPreStartHighSpeedDataCommunication_Click);
            // 
            // _btnStartHighSpeedDataCommunication
            // 
            this._btnStartHighSpeedDataCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._btnStartHighSpeedDataCommunication.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnStartHighSpeedDataCommunication.Location = new System.Drawing.Point(449, 18);
            this._btnStartHighSpeedDataCommunication.Name = "_btnStartHighSpeedDataCommunication";
            this._btnStartHighSpeedDataCommunication.Size = new System.Drawing.Size(143, 41);
            this._btnStartHighSpeedDataCommunication.TabIndex = 3;
            this._btnStartHighSpeedDataCommunication.Text = "StartHighSpeed DataCommunication";
            this._btnStartHighSpeedDataCommunication.UseVisualStyleBackColor = false;
            this._btnStartHighSpeedDataCommunication.Click += new System.EventHandler(this.btnStartHighSpeedDataCommunication_Click);
            // 
            // _btnStopHighSpeedDataCommunication
            // 
            this._btnStopHighSpeedDataCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._btnStopHighSpeedDataCommunication.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnStopHighSpeedDataCommunication.Location = new System.Drawing.Point(7, 65);
            this._btnStopHighSpeedDataCommunication.Name = "_btnStopHighSpeedDataCommunication";
            this._btnStopHighSpeedDataCommunication.Size = new System.Drawing.Size(140, 41);
            this._btnStopHighSpeedDataCommunication.TabIndex = 4;
            this._btnStopHighSpeedDataCommunication.Text = "StopHighSpeedData Communication";
            this._btnStopHighSpeedDataCommunication.UseVisualStyleBackColor = false;
            this._btnStopHighSpeedDataCommunication.Click += new System.EventHandler(this.btnStopHighSpeedDataCommunication_Click);
            // 
            // _btnHighSpeedDataCommunicationFinalize
            // 
            this._btnHighSpeedDataCommunicationFinalize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this._btnHighSpeedDataCommunicationFinalize.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnHighSpeedDataCommunicationFinalize.Location = new System.Drawing.Point(153, 65);
            this._btnHighSpeedDataCommunicationFinalize.Name = "_btnHighSpeedDataCommunicationFinalize";
            this._btnHighSpeedDataCommunicationFinalize.Size = new System.Drawing.Size(141, 41);
            this._btnHighSpeedDataCommunicationFinalize.TabIndex = 5;
            this._btnHighSpeedDataCommunicationFinalize.Text = "HighSpeedData CommunicationFinalize";
            this._btnHighSpeedDataCommunicationFinalize.UseVisualStyleBackColor = false;
            this._btnHighSpeedDataCommunicationFinalize.Click += new System.EventHandler(this.btnHighSpeedDataCommunicationFinalize_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this._btnStartStorage);
            this.groupBox6.Controls.Add(this._btnStopStorage);
            this.groupBox6.Controls.Add(this._btnGetStorageStatus);
            this.groupBox6.Controls.Add(this._btnGetStorageData);
            this.groupBox6.Controls.Add(this._btnGetStorageProfile);
            this.groupBox6.Controls.Add(this._btnGetStorageBatchProfile);
            this.groupBox6.Location = new System.Drawing.Point(6, 470);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(606, 79);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Storage-related functions";
            // 
            // _btnStartStorage
            // 
            this._btnStartStorage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnStartStorage.Location = new System.Drawing.Point(7, 18);
            this._btnStartStorage.Name = "_btnStartStorage";
            this._btnStartStorage.Size = new System.Drawing.Size(143, 23);
            this._btnStartStorage.TabIndex = 0;
            this._btnStartStorage.Text = "StartStorage";
            this._btnStartStorage.UseVisualStyleBackColor = false;
            this._btnStartStorage.Click += new System.EventHandler(this.btnStartStorage_Click);
            // 
            // _btnStopStorage
            // 
            this._btnStopStorage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnStopStorage.Location = new System.Drawing.Point(156, 18);
            this._btnStopStorage.Name = "_btnStopStorage";
            this._btnStopStorage.Size = new System.Drawing.Size(141, 23);
            this._btnStopStorage.TabIndex = 1;
            this._btnStopStorage.Text = "StopStorage";
            this._btnStopStorage.UseVisualStyleBackColor = false;
            this._btnStopStorage.Click += new System.EventHandler(this.btnStopStorage_Click);
            // 
            // _btnGetStorageStatus
            // 
            this._btnGetStorageStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnGetStorageStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetStorageStatus.Location = new System.Drawing.Point(303, 18);
            this._btnGetStorageStatus.Name = "_btnGetStorageStatus";
            this._btnGetStorageStatus.Size = new System.Drawing.Size(143, 23);
            this._btnGetStorageStatus.TabIndex = 2;
            this._btnGetStorageStatus.Text = "GetStorageStatus";
            this._btnGetStorageStatus.UseVisualStyleBackColor = false;
            this._btnGetStorageStatus.Click += new System.EventHandler(this.btnGetStorageStatus_Click);
            // 
            // _btnGetStorageData
            // 
            this._btnGetStorageData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnGetStorageData.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetStorageData.Location = new System.Drawing.Point(452, 18);
            this._btnGetStorageData.Name = "_btnGetStorageData";
            this._btnGetStorageData.Size = new System.Drawing.Size(143, 23);
            this._btnGetStorageData.TabIndex = 3;
            this._btnGetStorageData.Text = "GetStorageData";
            this._btnGetStorageData.UseVisualStyleBackColor = false;
            this._btnGetStorageData.Click += new System.EventHandler(this.btnGetStorageData_Click);
            // 
            // _btnGetStorageProfile
            // 
            this._btnGetStorageProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnGetStorageProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetStorageProfile.Location = new System.Drawing.Point(8, 47);
            this._btnGetStorageProfile.Name = "_btnGetStorageProfile";
            this._btnGetStorageProfile.Size = new System.Drawing.Size(142, 23);
            this._btnGetStorageProfile.TabIndex = 4;
            this._btnGetStorageProfile.Text = "GetStorageProfile";
            this._btnGetStorageProfile.UseVisualStyleBackColor = false;
            this._btnGetStorageProfile.Click += new System.EventHandler(this.btnGetStorageProfile_Click);
            // 
            // _btnGetStorageBatchProfile
            // 
            this._btnGetStorageBatchProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._btnGetStorageBatchProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetStorageBatchProfile.Location = new System.Drawing.Point(156, 47);
            this._btnGetStorageBatchProfile.Name = "_btnGetStorageBatchProfile";
            this._btnGetStorageBatchProfile.Size = new System.Drawing.Size(141, 23);
            this._btnGetStorageBatchProfile.TabIndex = 5;
            this._btnGetStorageBatchProfile.Text = "GetStorageBatchProfile";
            this._btnGetStorageBatchProfile.UseVisualStyleBackColor = false;
            this._btnGetStorageBatchProfile.Click += new System.EventHandler(this.btnGetStorageBatchProfile_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._btnGetMeasurementValue);
            this.groupBox5.Controls.Add(this._btnGetProfile);
            this.groupBox5.Controls.Add(this._btnGetBatchProfile);
            this.groupBox5.Controls.Add(this._btnGetBatchProfileAdvance);
            this.groupBox5.Controls.Add(this._btnGetProfileAdvance);
            this.groupBox5.Location = new System.Drawing.Point(6, 387);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(606, 78);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Get measurement results";
            // 
            // _btnGetMeasurementValue
            // 
            this._btnGetMeasurementValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnGetMeasurementValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetMeasurementValue.Location = new System.Drawing.Point(8, 18);
            this._btnGetMeasurementValue.Name = "_btnGetMeasurementValue";
            this._btnGetMeasurementValue.Size = new System.Drawing.Size(142, 23);
            this._btnGetMeasurementValue.TabIndex = 0;
            this._btnGetMeasurementValue.Text = "GetMeasurementValue";
            this._btnGetMeasurementValue.UseVisualStyleBackColor = false;
            this._btnGetMeasurementValue.Click += new System.EventHandler(this.btnGetMeasurementValue_Click);
            // 
            // _btnGetProfile
            // 
            this._btnGetProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnGetProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetProfile.Location = new System.Drawing.Point(8, 44);
            this._btnGetProfile.Name = "_btnGetProfile";
            this._btnGetProfile.Size = new System.Drawing.Size(142, 23);
            this._btnGetProfile.TabIndex = 1;
            this._btnGetProfile.Text = "GetProfile";
            this._btnGetProfile.UseVisualStyleBackColor = false;
            this._btnGetProfile.Click += new System.EventHandler(this.btnGetProfile_Click);
            // 
            // _btnGetBatchProfile
            // 
            this._btnGetBatchProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnGetBatchProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetBatchProfile.Location = new System.Drawing.Point(156, 44);
            this._btnGetBatchProfile.Name = "_btnGetBatchProfile";
            this._btnGetBatchProfile.Size = new System.Drawing.Size(141, 23);
            this._btnGetBatchProfile.TabIndex = 2;
            this._btnGetBatchProfile.Text = "GetBatchProfile";
            this._btnGetBatchProfile.UseVisualStyleBackColor = false;
            this._btnGetBatchProfile.Click += new System.EventHandler(this.btnGetBatchProfile_Click);
            // 
            // _btnGetBatchProfileAdvance
            // 
            this._btnGetBatchProfileAdvance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnGetBatchProfileAdvance.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetBatchProfileAdvance.Location = new System.Drawing.Point(452, 44);
            this._btnGetBatchProfileAdvance.Name = "_btnGetBatchProfileAdvance";
            this._btnGetBatchProfileAdvance.Size = new System.Drawing.Size(143, 23);
            this._btnGetBatchProfileAdvance.TabIndex = 4;
            this._btnGetBatchProfileAdvance.Text = "GetBatchProfileAdvance";
            this._btnGetBatchProfileAdvance.UseVisualStyleBackColor = false;
            this._btnGetBatchProfileAdvance.Click += new System.EventHandler(this.btnGetBatchProfileAdvance_Click);
            // 
            // _btnGetProfileAdvance
            // 
            this._btnGetProfileAdvance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnGetProfileAdvance.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetProfileAdvance.Location = new System.Drawing.Point(303, 44);
            this._btnGetProfileAdvance.Name = "_btnGetProfileAdvance";
            this._btnGetProfileAdvance.Size = new System.Drawing.Size(143, 23);
            this._btnGetProfileAdvance.TabIndex = 3;
            this._btnGetProfileAdvance.Text = "GetProfileAdvance";
            this._btnGetProfileAdvance.UseVisualStyleBackColor = false;
            this._btnGetProfileAdvance.Click += new System.EventHandler(this.btnGetProfileAdvance_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._btnSetSetting);
            this.groupBox4.Controls.Add(this._btnGetSetting);
            this.groupBox4.Controls.Add(this._btnInitializeSetting);
            this.groupBox4.Controls.Add(this._btnUpdataSetting);
            this.groupBox4.Controls.Add(this._btnRewriteTemporarySetting);
            this.groupBox4.Controls.Add(this._btnCheckMemoryAccess);
            this.groupBox4.Controls.Add(this._btnSetTime);
            this.groupBox4.Controls.Add(this._btnGetActiveProgram);
            this.groupBox4.Controls.Add(this._btnGetTime);
            this.groupBox4.Controls.Add(this._btnChangeActiveProgram);
            this.groupBox4.Location = new System.Drawing.Point(6, 271);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(606, 109);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Functions related to modifying or reading settings";
            // 
            // _btnSetSetting
            // 
            this._btnSetSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnSetSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnSetSetting.Location = new System.Drawing.Point(7, 18);
            this._btnSetSetting.Name = "_btnSetSetting";
            this._btnSetSetting.Size = new System.Drawing.Size(143, 23);
            this._btnSetSetting.TabIndex = 0;
            this._btnSetSetting.Text = "SetSetting";
            this._btnSetSetting.UseVisualStyleBackColor = false;
            this._btnSetSetting.Click += new System.EventHandler(this.btnSetSetting_Click);
            // 
            // _btnGetSetting
            // 
            this._btnGetSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnGetSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetSetting.Location = new System.Drawing.Point(156, 18);
            this._btnGetSetting.Name = "_btnGetSetting";
            this._btnGetSetting.Size = new System.Drawing.Size(141, 23);
            this._btnGetSetting.TabIndex = 1;
            this._btnGetSetting.Text = "GetSetting";
            this._btnGetSetting.UseVisualStyleBackColor = false;
            this._btnGetSetting.Click += new System.EventHandler(this.btnGetSetting_Click);
            // 
            // _btnInitializeSetting
            // 
            this._btnInitializeSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnInitializeSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnInitializeSetting.Location = new System.Drawing.Point(303, 18);
            this._btnInitializeSetting.Name = "_btnInitializeSetting";
            this._btnInitializeSetting.Size = new System.Drawing.Size(145, 23);
            this._btnInitializeSetting.TabIndex = 2;
            this._btnInitializeSetting.Text = "InitializeSetting";
            this._btnInitializeSetting.UseVisualStyleBackColor = false;
            this._btnInitializeSetting.Click += new System.EventHandler(this.btnInitializeSetting_Click);
            // 
            // _btnUpdataSetting
            // 
            this._btnUpdataSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnUpdataSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnUpdataSetting.Location = new System.Drawing.Point(454, 18);
            this._btnUpdataSetting.Name = "_btnUpdataSetting";
            this._btnUpdataSetting.Size = new System.Drawing.Size(143, 23);
            this._btnUpdataSetting.TabIndex = 3;
            this._btnUpdataSetting.Text = "ReflectSetting";
            this._btnUpdataSetting.UseVisualStyleBackColor = false;
            this._btnUpdataSetting.Click += new System.EventHandler(this.btnUpdataSetting_Click);
            // 
            // _btnRewriteTemporarySetting
            // 
            this._btnRewriteTemporarySetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnRewriteTemporarySetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnRewriteTemporarySetting.Location = new System.Drawing.Point(7, 48);
            this._btnRewriteTemporarySetting.Name = "_btnRewriteTemporarySetting";
            this._btnRewriteTemporarySetting.Size = new System.Drawing.Size(143, 23);
            this._btnRewriteTemporarySetting.TabIndex = 4;
            this._btnRewriteTemporarySetting.Text = "RewriteTemporarySetting";
            this._btnRewriteTemporarySetting.UseVisualStyleBackColor = false;
            this._btnRewriteTemporarySetting.Click += new System.EventHandler(this.btnRewriteTemporarySetting_Click);
            // 
            // _btnCheckMemoryAccess
            // 
            this._btnCheckMemoryAccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnCheckMemoryAccess.Location = new System.Drawing.Point(156, 47);
            this._btnCheckMemoryAccess.Name = "_btnCheckMemoryAccess";
            this._btnCheckMemoryAccess.Size = new System.Drawing.Size(141, 23);
            this._btnCheckMemoryAccess.TabIndex = 5;
            this._btnCheckMemoryAccess.Text = "CheckMemoryAccess";
            this._btnCheckMemoryAccess.UseVisualStyleBackColor = false;
            this._btnCheckMemoryAccess.Click += new System.EventHandler(this.btnCheckMemoryAccess_Click);
            // 
            // _btnSetTime
            // 
            this._btnSetTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnSetTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnSetTime.Location = new System.Drawing.Point(303, 48);
            this._btnSetTime.Name = "_btnSetTime";
            this._btnSetTime.Size = new System.Drawing.Size(145, 23);
            this._btnSetTime.TabIndex = 6;
            this._btnSetTime.Text = "SetTime";
            this._btnSetTime.UseVisualStyleBackColor = false;
            this._btnSetTime.Click += new System.EventHandler(this.btnSetTime_Click);
            // 
            // _btnGetActiveProgram
            // 
            this._btnGetActiveProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnGetActiveProgram.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetActiveProgram.Location = new System.Drawing.Point(157, 77);
            this._btnGetActiveProgram.Name = "_btnGetActiveProgram";
            this._btnGetActiveProgram.Size = new System.Drawing.Size(140, 23);
            this._btnGetActiveProgram.TabIndex = 9;
            this._btnGetActiveProgram.Text = "GetActiveProgram";
            this._btnGetActiveProgram.UseVisualStyleBackColor = false;
            this._btnGetActiveProgram.Click += new System.EventHandler(this.btnGetActiveProgram_Click);
            // 
            // _btnChangeActiveProgram
            // 
            this._btnChangeActiveProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnChangeActiveProgram.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnChangeActiveProgram.Location = new System.Drawing.Point(10, 78);
            this._btnChangeActiveProgram.Name = "_btnChangeActiveProgram";
            this._btnChangeActiveProgram.Size = new System.Drawing.Size(141, 23);
            this._btnChangeActiveProgram.TabIndex = 8;
            this._btnChangeActiveProgram.Text = "ChangeActiveProgram";
            this._btnChangeActiveProgram.UseVisualStyleBackColor = false;
            this._btnChangeActiveProgram.Click += new System.EventHandler(this.btnChangeActiveProgram_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._btnTrigger);
            this.groupBox3.Controls.Add(this._btnStartMeasure);
            this.groupBox3.Controls.Add(this._btnStopMeasure);
            this.groupBox3.Controls.Add(this._btnAutoZero);
            this.groupBox3.Controls.Add(this._btnClearMemory);
            this.groupBox3.Controls.Add(this._btnReset);
            this.groupBox3.Controls.Add(this._btnTiming);
            this.groupBox3.Location = new System.Drawing.Point(4, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(608, 79);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Measurement control";
            // 
            // _btnTrigger
            // 
            this._btnTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._btnTrigger.Location = new System.Drawing.Point(9, 18);
            this._btnTrigger.Name = "_btnTrigger";
            this._btnTrigger.Size = new System.Drawing.Size(143, 23);
            this._btnTrigger.TabIndex = 0;
            this._btnTrigger.Text = "Trigger";
            this._btnTrigger.UseVisualStyleBackColor = false;
            this._btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
            // 
            // _btnStartMeasure
            // 
            this._btnStartMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._btnStartMeasure.Location = new System.Drawing.Point(158, 18);
            this._btnStartMeasure.Name = "_btnStartMeasure";
            this._btnStartMeasure.Size = new System.Drawing.Size(141, 23);
            this._btnStartMeasure.TabIndex = 1;
            this._btnStartMeasure.Text = "StartMeasure";
            this._btnStartMeasure.UseVisualStyleBackColor = false;
            this._btnStartMeasure.Click += new System.EventHandler(this.btnStartMeasure_Click);
            // 
            // _btnStopMeasure
            // 
            this._btnStopMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._btnStopMeasure.Location = new System.Drawing.Point(305, 18);
            this._btnStopMeasure.Name = "_btnStopMeasure";
            this._btnStopMeasure.Size = new System.Drawing.Size(145, 23);
            this._btnStopMeasure.TabIndex = 2;
            this._btnStopMeasure.Text = "StopMeasure";
            this._btnStopMeasure.UseVisualStyleBackColor = false;
            this._btnStopMeasure.Click += new System.EventHandler(this.btnStopMeasure_Click);
            // 
            // _btnAutoZero
            // 
            this._btnAutoZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._btnAutoZero.Location = new System.Drawing.Point(454, 18);
            this._btnAutoZero.Name = "_btnAutoZero";
            this._btnAutoZero.Size = new System.Drawing.Size(143, 23);
            this._btnAutoZero.TabIndex = 3;
            this._btnAutoZero.Text = "AutoZero";
            this._btnAutoZero.UseVisualStyleBackColor = false;
            this._btnAutoZero.Click += new System.EventHandler(this.btnAutoZero_Click);
            // 
            // _btnClearMemory
            // 
            this._btnClearMemory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._btnClearMemory.Location = new System.Drawing.Point(305, 51);
            this._btnClearMemory.Name = "_btnClearMemory";
            this._btnClearMemory.Size = new System.Drawing.Size(145, 23);
            this._btnClearMemory.TabIndex = 6;
            this._btnClearMemory.Text = "ClearMemory";
            this._btnClearMemory.UseVisualStyleBackColor = false;
            this._btnClearMemory.Click += new System.EventHandler(this.btnClearMemory_Click);
            // 
            // _btnReset
            // 
            this._btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._btnReset.Location = new System.Drawing.Point(158, 51);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(141, 23);
            this._btnReset.TabIndex = 5;
            this._btnReset.Text = "Reset";
            this._btnReset.UseVisualStyleBackColor = false;
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _btnTiming
            // 
            this._btnTiming.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._btnTiming.Location = new System.Drawing.Point(9, 51);
            this._btnTiming.Name = "_btnTiming";
            this._btnTiming.Size = new System.Drawing.Size(143, 23);
            this._btnTiming.TabIndex = 4;
            this._btnTiming.Text = "Timing";
            this._btnTiming.UseVisualStyleBackColor = false;
            this._btnTiming.Click += new System.EventHandler(this.btnTiming_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._btnRebootController);
            this.groupBox2.Controls.Add(this._btnRetrunToFactorySetting);
            this.groupBox2.Controls.Add(this._btnGetError);
            this.groupBox2.Controls.Add(this._btnClearError);
            this.groupBox2.Location = new System.Drawing.Point(6, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(606, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System control";
            // 
            // _btnRebootController
            // 
            this._btnRebootController.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._btnRebootController.Location = new System.Drawing.Point(6, 18);
            this._btnRebootController.Name = "_btnRebootController";
            this._btnRebootController.Size = new System.Drawing.Size(144, 23);
            this._btnRebootController.TabIndex = 0;
            this._btnRebootController.Text = "RebootController";
            this._btnRebootController.UseVisualStyleBackColor = false;
            this._btnRebootController.Click += new System.EventHandler(this.btnRebootController_Click);
            // 
            // _btnRetrunToFactorySetting
            // 
            this._btnRetrunToFactorySetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._btnRetrunToFactorySetting.Location = new System.Drawing.Point(156, 18);
            this._btnRetrunToFactorySetting.Name = "_btnRetrunToFactorySetting";
            this._btnRetrunToFactorySetting.Size = new System.Drawing.Size(136, 23);
            this._btnRetrunToFactorySetting.TabIndex = 1;
            this._btnRetrunToFactorySetting.Text = "RetrunToFactorySetting";
            this._btnRetrunToFactorySetting.UseVisualStyleBackColor = false;
            this._btnRetrunToFactorySetting.Click += new System.EventHandler(this.btnRetrunToFactorySetting_Click);
            // 
            // _btnGetError
            // 
            this._btnGetError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._btnGetError.ForeColor = System.Drawing.SystemColors.ControlText;
            this._btnGetError.Location = new System.Drawing.Point(303, 18);
            this._btnGetError.Name = "_btnGetError";
            this._btnGetError.Size = new System.Drawing.Size(143, 23);
            this._btnGetError.TabIndex = 2;
            this._btnGetError.Text = "GetError";
            this._btnGetError.UseVisualStyleBackColor = false;
            this._btnGetError.Click += new System.EventHandler(this.btnGetError_Click);
            // 
            // _btnClearError
            // 
            this._btnClearError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._btnClearError.Location = new System.Drawing.Point(452, 18);
            this._btnClearError.Name = "_btnClearError";
            this._btnClearError.Size = new System.Drawing.Size(143, 23);
            this._btnClearError.TabIndex = 3;
            this._btnClearError.Text = "ClearError";
            this._btnClearError.UseVisualStyleBackColor = false;
            this._btnClearError.Click += new System.EventHandler(this.btnClearError_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btnCommClose);
            this.groupBox1.Controls.Add(this._btnEthernetOpen);
            this.groupBox1.Controls.Add(this._btnUsbOpen);
            this.groupBox1.Location = new System.Drawing.Point(5, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Establish/disconnect the communication path with the controller";
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._btnInitialize);
            this._groupBox1.Controls.Add(this._btnGetVersion);
            this._groupBox1.Controls.Add(this._btnFinalize);
            this._groupBox1.Location = new System.Drawing.Point(6, 18);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(606, 50);
            this._groupBox1.TabIndex = 0;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "Operations for the DLL";
            // 
            // _grpLog
            // 
            this._grpLog.Controls.Add(this._txtboxLog);
            this._grpLog.Controls.Add(this._btnLogClear);
            this._grpLog.Location = new System.Drawing.Point(12, 174);
            this._grpLog.Name = "_grpLog";
            this._grpLog.Size = new System.Drawing.Size(339, 126);
            this._grpLog.TabIndex = 0;
            this._grpLog.TabStop = false;
            this._grpLog.Text = "Operation result log";
            // 
            // _txtboxLog
            // 
            this._txtboxLog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtboxLog.Location = new System.Drawing.Point(6, 42);
            this._txtboxLog.Multiline = true;
            this._txtboxLog.Name = "_txtboxLog";
            this._txtboxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtboxLog.Size = new System.Drawing.Size(315, 70);
            this._txtboxLog.TabIndex = 1;
            // 
            // _btnLogClear
            // 
            this._btnLogClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._btnLogClear.Location = new System.Drawing.Point(7, 14);
            this._btnLogClear.Name = "_btnLogClear";
            this._btnLogClear.Size = new System.Drawing.Size(96, 23);
            this._btnLogClear.TabIndex = 0;
            this._btnLogClear.Text = "Clear the log";
            this._btnLogClear.UseVisualStyleBackColor = true;
            this._btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // _grpBufferSize
            // 
            this._grpBufferSize.Controls.Add(this._lblSettingAttention);
            this._grpBufferSize.Controls.Add(this._grpReceived);
            this._grpBufferSize.Controls.Add(this._grpMeasureRange);
            this._grpBufferSize.Controls.Add(this._grpHead);
            this._grpBufferSize.Location = new System.Drawing.Point(12, 306);
            this._grpBufferSize.Name = "_grpBufferSize";
            this._grpBufferSize.Size = new System.Drawing.Size(339, 198);
            this._grpBufferSize.TabIndex = 3;
            this._grpBufferSize.TabStop = false;
            this._grpBufferSize.Text = "Buffer size setting (set and used when reading profiles)";
            // 
            // _lblSettingAttention
            // 
            this._lblSettingAttention.AutoSize = true;
            this._lblSettingAttention.Location = new System.Drawing.Point(6, 15);
            this._lblSettingAttention.Name = "_lblSettingAttention";
            this._lblSettingAttention.Size = new System.Drawing.Size(253, 12);
            this._lblSettingAttention.TabIndex = 4;
            this._lblSettingAttention.Text = "*Match the setting of the controller with this application";
            // 
            // _grpReceived
            // 
            this._grpReceived.Controls.Add(this._chkboxEnvelope);
            this._grpReceived.Controls.Add(this._cmbCompressX);
            this._grpReceived.Controls.Add(this._lblCompressX);
            this._grpReceived.Location = new System.Drawing.Point(6, 142);
            this._grpReceived.Name = "_grpReceived";
            this._grpReceived.Size = new System.Drawing.Size(317, 50);
            this._grpReceived.TabIndex = 3;
            this._grpReceived.TabStop = false;
            this._grpReceived.Text = "Profile settings";
            // 
            // _chkboxEnvelope
            // 
            this._chkboxEnvelope.AutoSize = true;
            this._chkboxEnvelope.Checked = true;
            this._chkboxEnvelope.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkboxEnvelope.Location = new System.Drawing.Point(196, 20);
            this._chkboxEnvelope.Name = "_chkboxEnvelope";
            this._chkboxEnvelope.Size = new System.Drawing.Size(98, 16);
            this._chkboxEnvelope.TabIndex = 2;
            this._chkboxEnvelope.Text = "Envelope setting";
            this._chkboxEnvelope.UseVisualStyleBackColor = true;
            // 
            // _cmbCompressX
            // 
            this._cmbCompressX.DisplayMember = "Key";
            this._cmbCompressX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbCompressX.FormattingEnabled = true;
            this._cmbCompressX.Location = new System.Drawing.Point(127, 18);
            this._cmbCompressX.Name = "_cmbCompressX";
            this._cmbCompressX.Size = new System.Drawing.Size(59, 20);
            this._cmbCompressX.TabIndex = 1;
            this._cmbCompressX.ValueMember = "Value";
            // 
            // _lblCompressX
            // 
            this._lblCompressX.AutoSize = true;
            this._lblCompressX.Location = new System.Drawing.Point(6, 22);
            this._lblCompressX.Name = "_lblCompressX";
            this._lblCompressX.Size = new System.Drawing.Size(99, 12);
            this._lblCompressX.TabIndex = 0;
            this._lblCompressX.Text = "Compression (X axis)";
            // 
            // _grpMeasureRange
            // 
            this._grpMeasureRange.Controls.Add(this._cmbReceivedBinning);
            this._grpMeasureRange.Controls.Add(this._cmbMeasureX);
            this._grpMeasureRange.Controls.Add(this._lblReceivedBinning);
            this._grpMeasureRange.Controls.Add(this._lblMeasureX);
            this._grpMeasureRange.Location = new System.Drawing.Point(6, 70);
            this._grpMeasureRange.Name = "_grpMeasureRange";
            this._grpMeasureRange.Size = new System.Drawing.Size(317, 67);
            this._grpMeasureRange.TabIndex = 2;
            this._grpMeasureRange.TabStop = false;
            this._grpMeasureRange.Text = "Imaging settings";
            // 
            // _cmbReceivedBinning
            // 
            this._cmbReceivedBinning.DisplayMember = "Key";
            this._cmbReceivedBinning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbReceivedBinning.FormattingEnabled = true;
            this._cmbReceivedBinning.Location = new System.Drawing.Point(182, 42);
            this._cmbReceivedBinning.Name = "_cmbReceivedBinning";
            this._cmbReceivedBinning.Size = new System.Drawing.Size(91, 20);
            this._cmbReceivedBinning.TabIndex = 3;
            this._cmbReceivedBinning.ValueMember = "Value";
            // 
            // _cmbMeasureX
            // 
            this._cmbMeasureX.DisplayMember = "Key";
            this._cmbMeasureX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbMeasureX.FormattingEnabled = true;
            this._cmbMeasureX.Location = new System.Drawing.Point(182, 17);
            this._cmbMeasureX.Name = "_cmbMeasureX";
            this._cmbMeasureX.Size = new System.Drawing.Size(91, 20);
            this._cmbMeasureX.TabIndex = 1;
            this._cmbMeasureX.ValueMember = "Value";
            // 
            // _lblReceivedBinning
            // 
            this._lblReceivedBinning.AutoSize = true;
            this._lblReceivedBinning.Location = new System.Drawing.Point(13, 46);
            this._lblReceivedBinning.Name = "_lblReceivedBinning";
            this._lblReceivedBinning.Size = new System.Drawing.Size(39, 12);
            this._lblReceivedBinning.TabIndex = 2;
            this._lblReceivedBinning.Text = "Binning";
            // 
            // _lblMeasureX
            // 
            this._lblMeasureX.AutoSize = true;
            this._lblMeasureX.Location = new System.Drawing.Point(12, 19);
            this._lblMeasureX.Name = "_lblMeasureX";
            this._lblMeasureX.Size = new System.Drawing.Size(144, 12);
            this._lblMeasureX.TabIndex = 0;
            this._lblMeasureX.Text = "Measurement range X direction";
            // 
            // _grpHead
            // 
            this._grpHead.Controls.Add(this._rdbtnOneHead);
            this._grpHead.Controls.Add(this._rdbtnTwoHead);
            this._grpHead.Controls.Add(this._rdbtnWide);
            this._grpHead.Location = new System.Drawing.Point(6, 30);
            this._grpHead.Name = "_grpHead";
            this._grpHead.Size = new System.Drawing.Size(317, 38);
            this._grpHead.TabIndex = 1;
            this._grpHead.TabStop = false;
            this._grpHead.Text = "Head";
            // 
            // _rdbtnOneHead
            // 
            this._rdbtnOneHead.AutoSize = true;
            this._rdbtnOneHead.Location = new System.Drawing.Point(21, 17);
            this._rdbtnOneHead.Name = "_rdbtnOneHead";
            this._rdbtnOneHead.Size = new System.Drawing.Size(68, 16);
            this._rdbtnOneHead.TabIndex = 0;
            this._rdbtnOneHead.Text = "One Head";
            this._rdbtnOneHead.UseVisualStyleBackColor = true;
            // 
            // _rdbtnTwoHead
            // 
            this._rdbtnTwoHead.AutoSize = true;
            this._rdbtnTwoHead.Checked = true;
            this._rdbtnTwoHead.Location = new System.Drawing.Point(104, 17);
            this._rdbtnTwoHead.Name = "_rdbtnTwoHead";
            this._rdbtnTwoHead.Size = new System.Drawing.Size(69, 16);
            this._rdbtnTwoHead.TabIndex = 1;
            this._rdbtnTwoHead.TabStop = true;
            this._rdbtnTwoHead.Text = "Two Head";
            this._rdbtnTwoHead.UseVisualStyleBackColor = true;
            // 
            // _rdbtnWide
            // 
            this._rdbtnWide.AutoSize = true;
            this._rdbtnWide.Location = new System.Drawing.Point(187, 17);
            this._rdbtnWide.Name = "_rdbtnWide";
            this._rdbtnWide.Size = new System.Drawing.Size(104, 16);
            this._rdbtnWide.TabIndex = 2;
            this._rdbtnWide.Text = "Two heads (wide)";
            this._rdbtnWide.UseVisualStyleBackColor = true;
            // 
            // _grpExport
            // 
            this._grpExport.Controls.Add(this._nudProfileNo);
            this._grpExport.Controls.Add(this._txtboxProfileFilePath);
            this._grpExport.Controls.Add(this._btnSaveMeasureData);
            this._grpExport.Controls.Add(this._btnSave);
            this._grpExport.Controls.Add(this._btnProfileFileSave);
            this._grpExport.Controls.Add(this.label2);
            this._grpExport.Controls.Add(this._lblSavePath);
            this._grpExport.Location = new System.Drawing.Point(12, 571);
            this._grpExport.Name = "_grpExport";
            this._grpExport.Size = new System.Drawing.Size(339, 92);
            this._grpExport.TabIndex = 4;
            this._grpExport.TabStop = false;
            this._grpExport.Text = "Save the results file";
            // 
            // _nudProfileNo
            // 
            this._nudProfileNo.Location = new System.Drawing.Point(170, 42);
            this._nudProfileNo.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this._nudProfileNo.Name = "_nudProfileNo";
            this._nudProfileNo.Size = new System.Drawing.Size(43, 20);
            this._nudProfileNo.TabIndex = 4;
            // 
            // _txtboxProfileFilePath
            // 
            this._txtboxProfileFilePath.Location = new System.Drawing.Point(105, 18);
            this._txtboxProfileFilePath.Name = "_txtboxProfileFilePath";
            this._txtboxProfileFilePath.Size = new System.Drawing.Size(189, 20);
            this._txtboxProfileFilePath.TabIndex = 1;
            // 
            // _btnSaveMeasureData
            // 
            this._btnSaveMeasureData.Location = new System.Drawing.Point(193, 65);
            this._btnSaveMeasureData.Name = "_btnSaveMeasureData";
            this._btnSaveMeasureData.Size = new System.Drawing.Size(130, 23);
            this._btnSaveMeasureData.TabIndex = 6;
            this._btnSaveMeasureData.Text = "Save the measurement value";
            this._btnSaveMeasureData.UseVisualStyleBackColor = true;
            this._btnSaveMeasureData.Click += new System.EventHandler(this.btnSaveMeasureData_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(44, 65);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(132, 23);
            this._btnSave.TabIndex = 5;
            this._btnSave.Text = "Save the profile";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnProfileFileSave
            // 
            this._btnProfileFileSave.Location = new System.Drawing.Point(300, 18);
            this._btnProfileFileSave.Name = "_btnProfileFileSave";
            this._btnProfileFileSave.Size = new System.Drawing.Size(25, 18);
            this._btnProfileFileSave.TabIndex = 2;
            this._btnProfileFileSave.Text = "...";
            this._btnProfileFileSave.UseVisualStyleBackColor = true;
            this._btnProfileFileSave.Click += new System.EventHandler(this.btnProfileFileSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Index of the profile to save";
            // 
            // _lblSavePath
            // 
            this._lblSavePath.AutoSize = true;
            this._lblSavePath.Location = new System.Drawing.Point(9, 22);
            this._lblSavePath.Name = "_lblSavePath";
            this._lblSavePath.Size = new System.Drawing.Size(78, 12);
            this._lblSavePath.TabIndex = 0;
            this._lblSavePath.Text = "Save destination";
            // 
            // _profileFileSave
            // 
            this._profileFileSave.Filter = "Profile (*.txt)|*.txt | all files (*.*)|*.*";
            // 
            // _timerHighSpeedReceive
            // 
            this._timerHighSpeedReceive.Interval = 500;
            this._timerHighSpeedReceive.Tick += new System.EventHandler(this._timerHighSpeedReceive_Tick);
            // 
            // _lblReceiveProfileCount0
            // 
            this._lblReceiveProfileCount0.AutoSize = true;
            this._lblReceiveProfileCount0.BackColor = System.Drawing.Color.Transparent;
            this._lblReceiveProfileCount0.Location = new System.Drawing.Point(3, 31);
            this._lblReceiveProfileCount0.Name = "_lblReceiveProfileCount0";
            this._lblReceiveProfileCount0.Size = new System.Drawing.Size(10, 12);
            this._lblReceiveProfileCount0.TabIndex = 1;
            this._lblReceiveProfileCount0.Text = "0";
            // 
            // _rdDevice0
            // 
            this._rdDevice0.AutoSize = true;
            this._rdDevice0.Checked = true;
            this._rdDevice0.Location = new System.Drawing.Point(8, 32);
            this._rdDevice0.Name = "_rdDevice0";
            this._rdDevice0.Size = new System.Drawing.Size(28, 16);
            this._rdDevice0.TabIndex = 2;
            this._rdDevice0.TabStop = true;
            this._rdDevice0.Tag = "0";
            this._rdDevice0.Text = "&0";
            this._rdDevice0.UseVisualStyleBackColor = true;
            this._rdDevice0.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // _rdDevice2
            // 
            this._rdDevice2.AutoSize = true;
            this._rdDevice2.Location = new System.Drawing.Point(8, 66);
            this._rdDevice2.Name = "_rdDevice2";
            this._rdDevice2.Size = new System.Drawing.Size(28, 16);
            this._rdDevice2.TabIndex = 6;
            this._rdDevice2.Tag = "2";
            this._rdDevice2.Text = "&2";
            this._rdDevice2.UseVisualStyleBackColor = true;
            this._rdDevice2.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // _rdDevice1
            // 
            this._rdDevice1.AutoSize = true;
            this._rdDevice1.Location = new System.Drawing.Point(8, 49);
            this._rdDevice1.Name = "_rdDevice1";
            this._rdDevice1.Size = new System.Drawing.Size(28, 16);
            this._rdDevice1.TabIndex = 4;
            this._rdDevice1.Tag = "1";
            this._rdDevice1.Text = "&1";
            this._rdDevice1.UseVisualStyleBackColor = true;
            this._rdDevice1.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // _pnlDeviceId
            // 
            this._pnlDeviceId.BackColor = System.Drawing.Color.DarkGray;
            this._pnlDeviceId.Controls.Add(this._lblDeviceStatus5);
            this._pnlDeviceId.Controls.Add(this._lblDeviceStatus4);
            this._pnlDeviceId.Controls.Add(this.radioButton2);
            this._pnlDeviceId.Controls.Add(this.radioButton1);
            this._pnlDeviceId.Controls.Add(this.panel1);
            this._pnlDeviceId.Controls.Add(this.label5);
            this._pnlDeviceId.Controls.Add(this.label4);
            this._pnlDeviceId.Controls.Add(this._lblDeviceStatus3);
            this._pnlDeviceId.Controls.Add(this._lblDeviceStatus2);
            this._pnlDeviceId.Controls.Add(this._lblDeviceStatus1);
            this._pnlDeviceId.Controls.Add(this._lblDeviceStatus0);
            this._pnlDeviceId.Controls.Add(this._rdDevice3);
            this._pnlDeviceId.Controls.Add(this._rdDevice2);
            this._pnlDeviceId.Controls.Add(this._rdDevice1);
            this._pnlDeviceId.Controls.Add(this._rdDevice0);
            this._pnlDeviceId.Location = new System.Drawing.Point(12, 30);
            this._pnlDeviceId.Name = "_pnlDeviceId";
            this._pnlDeviceId.Size = new System.Drawing.Size(334, 140);
            this._pnlDeviceId.TabIndex = 1;
            this._pnlDeviceId.Tag = "";
            // 
            // _lblDeviceStatus5
            // 
            this._lblDeviceStatus5.AutoSize = true;
            this._lblDeviceStatus5.Location = new System.Drawing.Point(55, 118);
            this._lblDeviceStatus5.Name = "_lblDeviceStatus5";
            this._lblDeviceStatus5.Size = new System.Drawing.Size(65, 12);
            this._lblDeviceStatus5.TabIndex = 65;
            this._lblDeviceStatus5.Text = "Unconnected";
            // 
            // _lblDeviceStatus4
            // 
            this._lblDeviceStatus4.AutoSize = true;
            this._lblDeviceStatus4.Location = new System.Drawing.Point(55, 102);
            this._lblDeviceStatus4.Name = "_lblDeviceStatus4";
            this._lblDeviceStatus4.Size = new System.Drawing.Size(65, 12);
            this._lblDeviceStatus4.TabIndex = 64;
            this._lblDeviceStatus4.Text = "Unconnected";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 114);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(28, 16);
            this.radioButton2.TabIndex = 63;
            this.radioButton2.Tag = "5";
            this.radioButton2.Text = "&5";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 97);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(28, 16);
            this.radioButton1.TabIndex = 62;
            this.radioButton1.Tag = "4";
            this.radioButton1.Text = "&4";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this._lblReceiveProfileCount5);
            this.panel1.Controls.Add(this._lblReceiveProfileCount4);
            this.panel1.Controls.Add(this._lblReceiveProfileCount3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._lblReceiveProfileCount0);
            this.panel1.Controls.Add(this._lblReceiveProfileCount1);
            this.panel1.Controls.Add(this._lblReceiveProfileCount2);
            this.panel1.Location = new System.Drawing.Point(205, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 135);
            this.panel1.TabIndex = 59;
            // 
            // _lblReceiveProfileCount5
            // 
            this._lblReceiveProfileCount5.AutoSize = true;
            this._lblReceiveProfileCount5.BackColor = System.Drawing.Color.Transparent;
            this._lblReceiveProfileCount5.Location = new System.Drawing.Point(3, 114);
            this._lblReceiveProfileCount5.Name = "_lblReceiveProfileCount5";
            this._lblReceiveProfileCount5.Size = new System.Drawing.Size(10, 12);
            this._lblReceiveProfileCount5.TabIndex = 6;
            this._lblReceiveProfileCount5.Text = "0";
            // 
            // _lblReceiveProfileCount4
            // 
            this._lblReceiveProfileCount4.AutoSize = true;
            this._lblReceiveProfileCount4.BackColor = System.Drawing.Color.Transparent;
            this._lblReceiveProfileCount4.Location = new System.Drawing.Point(3, 97);
            this._lblReceiveProfileCount4.Name = "_lblReceiveProfileCount4";
            this._lblReceiveProfileCount4.Size = new System.Drawing.Size(10, 12);
            this._lblReceiveProfileCount4.TabIndex = 5;
            this._lblReceiveProfileCount4.Text = "0";
            // 
            // _lblReceiveProfileCount3
            // 
            this._lblReceiveProfileCount3.AutoSize = true;
            this._lblReceiveProfileCount3.BackColor = System.Drawing.Color.Transparent;
            this._lblReceiveProfileCount3.Location = new System.Drawing.Point(3, 79);
            this._lblReceiveProfileCount3.Name = "_lblReceiveProfileCount3";
            this._lblReceiveProfileCount3.Size = new System.Drawing.Size(10, 12);
            this._lblReceiveProfileCount3.TabIndex = 4;
            this._lblReceiveProfileCount3.Text = "0";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Number of \r\nreceived profiles";
            // 
            // _lblReceiveProfileCount1
            // 
            this._lblReceiveProfileCount1.AutoSize = true;
            this._lblReceiveProfileCount1.BackColor = System.Drawing.Color.Transparent;
            this._lblReceiveProfileCount1.Location = new System.Drawing.Point(3, 48);
            this._lblReceiveProfileCount1.Name = "_lblReceiveProfileCount1";
            this._lblReceiveProfileCount1.Size = new System.Drawing.Size(10, 12);
            this._lblReceiveProfileCount1.TabIndex = 2;
            this._lblReceiveProfileCount1.Text = "0";
            // 
            // _lblReceiveProfileCount2
            // 
            this._lblReceiveProfileCount2.AutoSize = true;
            this._lblReceiveProfileCount2.BackColor = System.Drawing.Color.Transparent;
            this._lblReceiveProfileCount2.Location = new System.Drawing.Point(3, 65);
            this._lblReceiveProfileCount2.Name = "_lblReceiveProfileCount2";
            this._lblReceiveProfileCount2.Size = new System.Drawing.Size(10, 12);
            this._lblReceiveProfileCount2.TabIndex = 3;
            this._lblReceiveProfileCount2.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "State (USB / IP address)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID";
            // 
            // _lblDeviceStatus3
            // 
            this._lblDeviceStatus3.AutoSize = true;
            this._lblDeviceStatus3.Location = new System.Drawing.Point(55, 84);
            this._lblDeviceStatus3.Name = "_lblDeviceStatus3";
            this._lblDeviceStatus3.Size = new System.Drawing.Size(65, 12);
            this._lblDeviceStatus3.TabIndex = 61;
            this._lblDeviceStatus3.Text = "Unconnected";
            // 
            // _lblDeviceStatus2
            // 
            this._lblDeviceStatus2.AutoSize = true;
            this._lblDeviceStatus2.Location = new System.Drawing.Point(55, 66);
            this._lblDeviceStatus2.Name = "_lblDeviceStatus2";
            this._lblDeviceStatus2.Size = new System.Drawing.Size(65, 12);
            this._lblDeviceStatus2.TabIndex = 7;
            this._lblDeviceStatus2.Text = "Unconnected";
            // 
            // _lblDeviceStatus1
            // 
            this._lblDeviceStatus1.AutoSize = true;
            this._lblDeviceStatus1.Location = new System.Drawing.Point(55, 51);
            this._lblDeviceStatus1.Name = "_lblDeviceStatus1";
            this._lblDeviceStatus1.Size = new System.Drawing.Size(65, 12);
            this._lblDeviceStatus1.TabIndex = 5;
            this._lblDeviceStatus1.Text = "Unconnected";
            // 
            // _lblDeviceStatus0
            // 
            this._lblDeviceStatus0.AutoSize = true;
            this._lblDeviceStatus0.Location = new System.Drawing.Point(55, 35);
            this._lblDeviceStatus0.Name = "_lblDeviceStatus0";
            this._lblDeviceStatus0.Size = new System.Drawing.Size(65, 12);
            this._lblDeviceStatus0.TabIndex = 3;
            this._lblDeviceStatus0.Text = "Unconnected";
            // 
            // _rdDevice3
            // 
            this._rdDevice3.AutoSize = true;
            this._rdDevice3.Location = new System.Drawing.Point(8, 80);
            this._rdDevice3.Name = "_rdDevice3";
            this._rdDevice3.Size = new System.Drawing.Size(28, 16);
            this._rdDevice3.TabIndex = 60;
            this._rdDevice3.Tag = "3";
            this._rdDevice3.Text = "&3";
            this._rdDevice3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this._rdDevice3.UseVisualStyleBackColor = true;
            this._rdDevice3.CheckedChanged += new System.EventHandler(this._rdDevice_CheckedChanged);
            // 
            // _chkOnlyProfileCount
            // 
            this._chkOnlyProfileCount.AutoSize = true;
            this._chkOnlyProfileCount.Checked = true;
            this._chkOnlyProfileCount.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkOnlyProfileCount.Location = new System.Drawing.Point(122, 37);
            this._chkOnlyProfileCount.Name = "_chkOnlyProfileCount";
            this._chkOnlyProfileCount.Size = new System.Drawing.Size(180, 16);
            this._chkOnlyProfileCount.TabIndex = 0;
            this._chkOnlyProfileCount.Text = "Count only the number of profiles.";
            this._chkOnlyProfileCount.UseVisualStyleBackColor = true;
            // 
            // _chkStartTimer
            // 
            this._chkStartTimer.AutoSize = true;
            this._chkStartTimer.Location = new System.Drawing.Point(122, 18);
            this._chkStartTimer.Name = "_chkStartTimer";
            this._chkStartTimer.Size = new System.Drawing.Size(87, 16);
            this._chkStartTimer.TabIndex = 1;
            this._chkStartTimer.Text = "Start the timer";
            this._chkStartTimer.UseVisualStyleBackColor = true;
            this._chkStartTimer.CheckedChanged += new System.EventHandler(this._chkStartTimer_CheckedChanged);
            // 
            // _numInterval
            // 
            this._numInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._numInterval.Location = new System.Drawing.Point(242, 18);
            this._numInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._numInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._numInterval.Name = "_numInterval";
            this._numInterval.Size = new System.Drawing.Size(64, 20);
            this._numInterval.TabIndex = 2;
            this._numInterval.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // _rdEthernet1
            // 
            this._rdEthernet1.Controls.Add(this._tabPage1);
            this._rdEthernet1.Controls.Add(this._tabPage2);
            this._rdEthernet1.Controls.Add(this.tabPage1);
            this._rdEthernet1.Controls.Add(this.tabPage2);
            this._rdEthernet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rdEthernet1.Location = new System.Drawing.Point(0, 0);
            this._rdEthernet1.Name = "_rdEthernet1";
            this._rdEthernet1.SelectedIndex = 0;
            this._rdEthernet1.Size = new System.Drawing.Size(1152, 755);
            this._rdEthernet1.TabIndex = 0;
            // 
            // _tabPage1
            // 
            this._tabPage1.BackColor = System.Drawing.Color.Linen;
            this._tabPage1.Controls.Add(this._groupBox);
            this._tabPage1.Controls.Add(this._grpCommand);
            this._tabPage1.Location = new System.Drawing.Point(4, 21);
            this._tabPage1.Name = "_tabPage1";
            this._tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage1.Size = new System.Drawing.Size(1144, 730);
            this._tabPage1.TabIndex = 0;
            this._tabPage1.Text = "[DLL functions] Simple function sample";
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._lblConectedDevice);
            this._groupBox.Controls.Add(this.groupBox8);
            this._groupBox.Controls.Add(this._grpLog);
            this._groupBox.Controls.Add(this._grpExport);
            this._groupBox.Controls.Add(this._grpBufferSize);
            this._groupBox.Controls.Add(this._pnlDeviceId);
            this._groupBox.Location = new System.Drawing.Point(627, 5);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(351, 674);
            this._groupBox.TabIndex = 1;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "Setting / Result";
            // 
            // _lblConectedDevice
            // 
            this._lblConectedDevice.AutoSize = true;
            this._lblConectedDevice.Location = new System.Drawing.Point(10, 14);
            this._lblConectedDevice.Name = "_lblConectedDevice";
            this._lblConectedDevice.Size = new System.Drawing.Size(282, 12);
            this._lblConectedDevice.TabIndex = 5;
            this._lblConectedDevice.Text = "Controller connection status (Up to 6 units can be connected)";
            // 
            // groupBox8
            // 
            this.groupBox8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox8.Controls.Add(this._chkOnlyProfileCount);
            this.groupBox8.Controls.Add(this._numInterval);
            this.groupBox8.Controls.Add(this._chkStartTimer);
            this.groupBox8.Location = new System.Drawing.Point(12, 507);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(339, 59);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Profile-related settings ( set and used during high-speed communication)";
            // 
            // _tabPage2
            // 
            this._tabPage2.BackColor = System.Drawing.Color.AliceBlue;
            this._tabPage2.Controls.Add(this._grpProgram);
            this._tabPage2.Controls.Add(this._grpHighSpeed);
            this._tabPage2.Controls.Add(this._grpGetData);
            this._tabPage2.Controls.Add(this._grpBaseOperation);
            this._tabPage2.Location = new System.Drawing.Point(4, 21);
            this._tabPage2.Name = "_tabPage2";
            this._tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage2.Size = new System.Drawing.Size(1144, 730);
            this._tabPage2.TabIndex = 1;
            this._tabPage2.Text = "[DLL functions] Combination sample";
            // 
            // _grpProgram
            // 
            this._grpProgram.Controls.Add(this._btnUploadProgram);
            this._grpProgram.Controls.Add(this._btnDownloadProgram);
            this._grpProgram.Controls.Add(this._btnReferenceProgramFilePath);
            this._grpProgram.Controls.Add(this._txtProgramFilePath);
            this._grpProgram.Controls.Add(this._lblSelectProgram);
            this._grpProgram.Controls.Add(this._cbxSelectProgram);
            this._grpProgram.Location = new System.Drawing.Point(28, 194);
            this._grpProgram.Name = "_grpProgram";
            this._grpProgram.Size = new System.Drawing.Size(441, 114);
            this._grpProgram.TabIndex = 1;
            this._grpProgram.TabStop = false;
            this._grpProgram.Text = "Reading or writing settings for each program number";
            // 
            // _btnUploadProgram
            // 
            this._btnUploadProgram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnUploadProgram.Location = new System.Drawing.Point(19, 78);
            this._btnUploadProgram.Name = "_btnUploadProgram";
            this._btnUploadProgram.Size = new System.Drawing.Size(189, 23);
            this._btnUploadProgram.TabIndex = 4;
            this._btnUploadProgram.Text = "Sending settings (PC -> LJ)";
            this._btnUploadProgram.UseVisualStyleBackColor = true;
            this._btnUploadProgram.Click += new System.EventHandler(this.btnSetSettingEx_Click);
            // 
            // _btnDownloadProgram
            // 
            this._btnDownloadProgram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnDownloadProgram.Location = new System.Drawing.Point(235, 78);
            this._btnDownloadProgram.Name = "_btnDownloadProgram";
            this._btnDownloadProgram.Size = new System.Drawing.Size(189, 23);
            this._btnDownloadProgram.TabIndex = 5;
            this._btnDownloadProgram.Text = "Receiving settings (LJ -> PC)";
            this._btnDownloadProgram.UseVisualStyleBackColor = true;
            this._btnDownloadProgram.Click += new System.EventHandler(this.btnGetSettingEx_Click);
            // 
            // _btnReferenceProgramFilePath
            // 
            this._btnReferenceProgramFilePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnReferenceProgramFilePath.Location = new System.Drawing.Point(373, 50);
            this._btnReferenceProgramFilePath.Name = "_btnReferenceProgramFilePath";
            this._btnReferenceProgramFilePath.Size = new System.Drawing.Size(51, 23);
            this._btnReferenceProgramFilePath.TabIndex = 3;
            this._btnReferenceProgramFilePath.Text = "...";
            this._btnReferenceProgramFilePath.UseVisualStyleBackColor = true;
            this._btnReferenceProgramFilePath.Click += new System.EventHandler(this._btnReferenceProgramFilePathEx_Click);
            // 
            // _txtProgramFilePath
            // 
            this._txtProgramFilePath.Location = new System.Drawing.Point(19, 53);
            this._txtProgramFilePath.Name = "_txtProgramFilePath";
            this._txtProgramFilePath.Size = new System.Drawing.Size(347, 20);
            this._txtProgramFilePath.TabIndex = 2;
            // 
            // _lblSelectProgram
            // 
            this._lblSelectProgram.AutoSize = true;
            this._lblSelectProgram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblSelectProgram.Location = new System.Drawing.Point(17, 30);
            this._lblSelectProgram.Name = "_lblSelectProgram";
            this._lblSelectProgram.Size = new System.Drawing.Size(90, 12);
            this._lblSelectProgram.TabIndex = 0;
            this._lblSelectProgram.Text = "Select the program";
            // 
            // _cbxSelectProgram
            // 
            this._cbxSelectProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxSelectProgram.FormattingEnabled = true;
            this._cbxSelectProgram.Items.AddRange(new object[] {
            "Environment",
            "Common",
            "Program0",
            "Program1",
            "Program2",
            "Program3",
            "Program4",
            "Program5",
            "Program6",
            "Program7",
            "Program8",
            "Program9",
            "Program10",
            "Program11",
            "Program12",
            "Program13",
            "Program14",
            "Program15"});
            this._cbxSelectProgram.Location = new System.Drawing.Point(130, 29);
            this._cbxSelectProgram.Name = "_cbxSelectProgram";
            this._cbxSelectProgram.Size = new System.Drawing.Size(101, 20);
            this._cbxSelectProgram.TabIndex = 1;
            // 
            // _grpHighSpeed
            // 
            this._grpHighSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._grpHighSpeed.Controls.Add(this._txtCallbackFrequency);
            this._grpHighSpeed.Controls.Add(this._txtStartProfileNo);
            this._grpHighSpeed.Controls.Add(this._lblReceiveProfileCount);
            this._grpHighSpeed.Controls.Add(this._lblCallbackFrequency);
            this._grpHighSpeed.Controls.Add(this._btnTerminateHighSpeedCommunication);
            this._grpHighSpeed.Controls.Add(this._lblHighSpeedStartNo);
            this._grpHighSpeed.Controls.Add(this._lblReceiveCount);
            this._grpHighSpeed.Controls.Add(this._btnBeginHighSpeedDataCommunication);
            this._grpHighSpeed.Location = new System.Drawing.Point(485, 283);
            this._grpHighSpeed.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._grpHighSpeed.Name = "_grpHighSpeed";
            this._grpHighSpeed.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._grpHighSpeed.Size = new System.Drawing.Size(440, 120);
            this._grpHighSpeed.TabIndex = 3;
            this._grpHighSpeed.TabStop = false;
            this._grpHighSpeed.Text = "High-speed data communication";
            // 
            // _txtCallbackFrequency
            // 
            this._txtCallbackFrequency.Location = new System.Drawing.Point(338, 50);
            this._txtCallbackFrequency.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtCallbackFrequency.Name = "_txtCallbackFrequency";
            this._txtCallbackFrequency.Size = new System.Drawing.Size(45, 20);
            this._txtCallbackFrequency.TabIndex = 4;
            this._txtCallbackFrequency.Text = "10";
            // 
            // _txtStartProfileNo
            // 
            this._txtStartProfileNo.Location = new System.Drawing.Point(338, 23);
            this._txtStartProfileNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtStartProfileNo.Name = "_txtStartProfileNo";
            this._txtStartProfileNo.Size = new System.Drawing.Size(45, 20);
            this._txtStartProfileNo.TabIndex = 2;
            this._txtStartProfileNo.Text = "2";
            // 
            // _lblReceiveProfileCount
            // 
            this._lblReceiveProfileCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblReceiveProfileCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblReceiveProfileCount.Location = new System.Drawing.Point(305, 79);
            this._lblReceiveProfileCount.Name = "_lblReceiveProfileCount";
            this._lblReceiveProfileCount.Size = new System.Drawing.Size(78, 17);
            this._lblReceiveProfileCount.TabIndex = 6;
            this._lblReceiveProfileCount.Text = "123456789";
            this._lblReceiveProfileCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblCallbackFrequency
            // 
            this._lblCallbackFrequency.AutoSize = true;
            this._lblCallbackFrequency.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblCallbackFrequency.Location = new System.Drawing.Point(107, 47);
            this._lblCallbackFrequency.Name = "_lblCallbackFrequency";
            this._lblCallbackFrequency.Size = new System.Drawing.Size(149, 12);
            this._lblCallbackFrequency.TabIndex = 3;
            this._lblCallbackFrequency.Text = "Callback function call frequency";
            // 
            // _btnTerminateHighSpeedCommunication
            // 
            this._btnTerminateHighSpeedCommunication.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnTerminateHighSpeedCommunication.Location = new System.Drawing.Point(6, 50);
            this._btnTerminateHighSpeedCommunication.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._btnTerminateHighSpeedCommunication.Name = "_btnTerminateHighSpeedCommunication";
            this._btnTerminateHighSpeedCommunication.Size = new System.Drawing.Size(75, 23);
            this._btnTerminateHighSpeedCommunication.TabIndex = 7;
            this._btnTerminateHighSpeedCommunication.Text = "Finalize ";
            this._btnTerminateHighSpeedCommunication.UseVisualStyleBackColor = true;
            this._btnTerminateHighSpeedCommunication.Click += new System.EventHandler(this.btnEndHighSpeedDataCommunicationEx_Click);
            // 
            // _lblHighSpeedStartNo
            // 
            this._lblHighSpeedStartNo.AutoSize = true;
            this._lblHighSpeedStartNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblHighSpeedStartNo.Location = new System.Drawing.Point(107, 23);
            this._lblHighSpeedStartNo.Name = "_lblHighSpeedStartNo";
            this._lblHighSpeedStartNo.Size = new System.Drawing.Size(88, 12);
            this._lblHighSpeedStartNo.TabIndex = 1;
            this._lblHighSpeedStartNo.Text = "Send start position";
            // 
            // _lblReceiveCount
            // 
            this._lblReceiveCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblReceiveCount.Location = new System.Drawing.Point(107, 71);
            this._lblReceiveCount.Name = "_lblReceiveCount";
            this._lblReceiveCount.Size = new System.Drawing.Size(288, 25);
            this._lblReceiveCount.TabIndex = 5;
            this._lblReceiveCount.Text = "Number of received \r\nhigh-speed communication profiles";
            // 
            // _btnBeginHighSpeedDataCommunication
            // 
            this._btnBeginHighSpeedDataCommunication.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnBeginHighSpeedDataCommunication.Location = new System.Drawing.Point(6, 18);
            this._btnBeginHighSpeedDataCommunication.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._btnBeginHighSpeedDataCommunication.Name = "_btnBeginHighSpeedDataCommunication";
            this._btnBeginHighSpeedDataCommunication.Size = new System.Drawing.Size(75, 23);
            this._btnBeginHighSpeedDataCommunication.TabIndex = 0;
            this._btnBeginHighSpeedDataCommunication.Text = "Start";
            this._btnBeginHighSpeedDataCommunication.UseVisualStyleBackColor = true;
            this._btnBeginHighSpeedDataCommunication.Click += new System.EventHandler(this.btnBeginHighSpeedCommunicationEx_Click);
            // 
            // _grpGetData
            // 
            this._grpGetData.Controls.Add(this._txtMeasureData);
            this._grpGetData.Controls.Add(this._grpGetProfile);
            this._grpGetData.Controls.Add(this._btnGetLatestMeasureValue);
            this._grpGetData.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this._grpGetData.Location = new System.Drawing.Point(485, 6);
            this._grpGetData.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._grpGetData.Name = "_grpGetData";
            this._grpGetData.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._grpGetData.Size = new System.Drawing.Size(441, 223);
            this._grpGetData.TabIndex = 2;
            this._grpGetData.TabStop = false;
            this._grpGetData.Text = "Get measurement results";
            // 
            // _txtMeasureData
            // 
            this._txtMeasureData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtMeasureData.Location = new System.Drawing.Point(127, 19);
            this._txtMeasureData.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtMeasureData.Multiline = true;
            this._txtMeasureData.Name = "_txtMeasureData";
            this._txtMeasureData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtMeasureData.Size = new System.Drawing.Size(307, 82);
            this._txtMeasureData.TabIndex = 1;
            // 
            // _grpGetProfile
            // 
            this._grpGetProfile.Controls.Add(this._btnGetProfileAdvanceData);
            this._grpGetProfile.Controls.Add(this._btnReferenceSavePath);
            this._grpGetProfile.Controls.Add(this._btnGetBatchProfileDataAdvance);
            this._grpGetProfile.Controls.Add(this._btnGetBatchProfileData);
            this._grpGetProfile.Controls.Add(this._btnGetProfileData);
            this._grpGetProfile.Controls.Add(this._txtSavePath);
            this._grpGetProfile.Controls.Add(this.label1);
            this._grpGetProfile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpGetProfile.Location = new System.Drawing.Point(6, 108);
            this._grpGetProfile.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._grpGetProfile.Name = "_grpGetProfile";
            this._grpGetProfile.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._grpGetProfile.Size = new System.Drawing.Size(427, 111);
            this._grpGetProfile.TabIndex = 2;
            this._grpGetProfile.TabStop = false;
            this._grpGetProfile.Text = "Get profiles";
            // 
            // _btnGetProfileAdvanceData
            // 
            this._btnGetProfileAdvanceData.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this._btnGetProfileAdvanceData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnGetProfileAdvanceData.Location = new System.Drawing.Point(6, 78);
            this._btnGetProfileAdvanceData.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._btnGetProfileAdvanceData.Name = "_btnGetProfileAdvanceData";
            this._btnGetProfileAdvanceData.Size = new System.Drawing.Size(201, 23);
            this._btnGetProfileAdvanceData.TabIndex = 5;
            this._btnGetProfileAdvanceData.Text = "Get advanced mode profiles";
            this._btnGetProfileAdvanceData.UseVisualStyleBackColor = true;
            this._btnGetProfileAdvanceData.Click += new System.EventHandler(this.btnGetProfileAdvanceEx_Click);
            // 
            // _btnReferenceSavePath
            // 
            this._btnReferenceSavePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnReferenceSavePath.Location = new System.Drawing.Point(391, 19);
            this._btnReferenceSavePath.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._btnReferenceSavePath.Name = "_btnReferenceSavePath";
            this._btnReferenceSavePath.Size = new System.Drawing.Size(30, 23);
            this._btnReferenceSavePath.TabIndex = 2;
            this._btnReferenceSavePath.Text = "...";
            this._btnReferenceSavePath.UseVisualStyleBackColor = true;
            this._btnReferenceSavePath.Click += new System.EventHandler(this.btnReferenceSavePathEx_Click);
            // 
            // _btnGetBatchProfileDataAdvance
            // 
            this._btnGetBatchProfileDataAdvance.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this._btnGetBatchProfileDataAdvance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnGetBatchProfileDataAdvance.Location = new System.Drawing.Point(219, 78);
            this._btnGetBatchProfileDataAdvance.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._btnGetBatchProfileDataAdvance.Name = "_btnGetBatchProfileDataAdvance";
            this._btnGetBatchProfileDataAdvance.Size = new System.Drawing.Size(201, 23);
            this._btnGetBatchProfileDataAdvance.TabIndex = 6;
            this._btnGetBatchProfileDataAdvance.Text = "Get advanced mode batch profiles";
            this._btnGetBatchProfileDataAdvance.UseVisualStyleBackColor = true;
            this._btnGetBatchProfileDataAdvance.Click += new System.EventHandler(this.btnGetBatchProfileAdvanceEx_Click);
            // 
            // _btnGetBatchProfileData
            // 
            this._btnGetBatchProfileData.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this._btnGetBatchProfileData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnGetBatchProfileData.Location = new System.Drawing.Point(219, 48);
            this._btnGetBatchProfileData.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._btnGetBatchProfileData.Name = "_btnGetBatchProfileData";
            this._btnGetBatchProfileData.Size = new System.Drawing.Size(201, 23);
            this._btnGetBatchProfileData.TabIndex = 4;
            this._btnGetBatchProfileData.Text = "Get high-speed mode batch profiles";
            this._btnGetBatchProfileData.UseVisualStyleBackColor = true;
            this._btnGetBatchProfileData.Click += new System.EventHandler(this.btnGetBatchProfileEx_Click);
            // 
            // _btnGetProfileData
            // 
            this._btnGetProfileData.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this._btnGetProfileData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnGetProfileData.Location = new System.Drawing.Point(6, 48);
            this._btnGetProfileData.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._btnGetProfileData.Name = "_btnGetProfileData";
            this._btnGetProfileData.Size = new System.Drawing.Size(201, 23);
            this._btnGetProfileData.TabIndex = 3;
            this._btnGetProfileData.Text = "Get high-speed mode profiles";
            this._btnGetProfileData.UseVisualStyleBackColor = true;
            this._btnGetProfileData.Click += new System.EventHandler(this.btnGetProfileEx_Click);
            // 
            // _txtSavePath
            // 
            this._txtSavePath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSavePath.Location = new System.Drawing.Point(103, 23);
            this._txtSavePath.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtSavePath.Name = "_txtSavePath";
            this._txtSavePath.Size = new System.Drawing.Size(283, 21);
            this._txtSavePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save path";
            // 
            // _btnGetLatestMeasureValue
            // 
            this._btnGetLatestMeasureValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnGetLatestMeasureValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnGetLatestMeasureValue.Location = new System.Drawing.Point(6, 18);
            this._btnGetLatestMeasureValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._btnGetLatestMeasureValue.Name = "_btnGetLatestMeasureValue";
            this._btnGetLatestMeasureValue.Size = new System.Drawing.Size(115, 23);
            this._btnGetLatestMeasureValue.TabIndex = 0;
            this._btnGetLatestMeasureValue.Text = "Get Current values";
            this._btnGetLatestMeasureValue.UseVisualStyleBackColor = true;
            this._btnGetLatestMeasureValue.Click += new System.EventHandler(this.btnGetMeasureValueEx_Click);
            // 
            // _grpBaseOperation
            // 
            this._grpBaseOperation.Controls.Add(this._pnlCommunicationDevice);
            this._grpBaseOperation.Controls.Add(this._btnTerminateCommunication);
            this._grpBaseOperation.Controls.Add(this._btnEstablishCommunication);
            this._grpBaseOperation.Location = new System.Drawing.Point(28, 6);
            this._grpBaseOperation.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._grpBaseOperation.Name = "_grpBaseOperation";
            this._grpBaseOperation.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._grpBaseOperation.Size = new System.Drawing.Size(441, 179);
            this._grpBaseOperation.TabIndex = 0;
            this._grpBaseOperation.TabStop = false;
            this._grpBaseOperation.Text = "Establish/disconnect the communication path with the controller";
            // 
            // _pnlCommunicationDevice
            // 
            this._pnlCommunicationDevice.Controls.Add(this._rdUsb);
            this._pnlCommunicationDevice.Controls.Add(this._rdEthernet);
            this._pnlCommunicationDevice.Controls.Add(this._grpEthernetSetting);
            this._pnlCommunicationDevice.Location = new System.Drawing.Point(6, 49);
            this._pnlCommunicationDevice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._pnlCommunicationDevice.Name = "_pnlCommunicationDevice";
            this._pnlCommunicationDevice.Size = new System.Drawing.Size(418, 120);
            this._pnlCommunicationDevice.TabIndex = 1;
            // 
            // _rdUsb
            // 
            this._rdUsb.AutoSize = true;
            this._rdUsb.Checked = true;
            this._rdUsb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._rdUsb.Location = new System.Drawing.Point(3, 5);
            this._rdUsb.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._rdUsb.Name = "_rdUsb";
            this._rdUsb.Size = new System.Drawing.Size(42, 16);
            this._rdUsb.TabIndex = 0;
            this._rdUsb.TabStop = true;
            this._rdUsb.Text = "USB";
            this._rdUsb.UseVisualStyleBackColor = true;
            // 
            // _rdEthernet
            // 
            this._rdEthernet.AutoSize = true;
            this._rdEthernet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._rdEthernet.Location = new System.Drawing.Point(3, 24);
            this._rdEthernet.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._rdEthernet.Name = "_rdEthernet";
            this._rdEthernet.Size = new System.Drawing.Size(61, 16);
            this._rdEthernet.TabIndex = 1;
            this._rdEthernet.Text = "Ethernet";
            this._rdEthernet.UseVisualStyleBackColor = true;
            this._rdEthernet.CheckedChanged += new System.EventHandler(this._rdEthernet_CheckedChanged);
            // 
            // _grpEthernetSetting
            // 
            this._grpEthernetSetting.Controls.Add(this._txtIpFirstSegment);
            this._grpEthernetSetting.Controls.Add(this._txtIpFourthSegment);
            this._grpEthernetSetting.Controls.Add(this._txtIpSecondSegment);
            this._grpEthernetSetting.Controls.Add(this._lblHighSpeedPort);
            this._grpEthernetSetting.Controls.Add(this._txtIpThirdSegment);
            this._grpEthernetSetting.Controls.Add(this._lblIpSeparator3);
            this._grpEthernetSetting.Controls.Add(this._lblIpSeparator2);
            this._grpEthernetSetting.Controls.Add(this._txtHighSpeedPort);
            this._grpEthernetSetting.Controls.Add(this._lblIpSeparator1);
            this._grpEthernetSetting.Controls.Add(this._txtCommandPort);
            this._grpEthernetSetting.Controls.Add(this._lblIpAddress);
            this._grpEthernetSetting.Controls.Add(this._lblCommandPort);
            this._grpEthernetSetting.Enabled = false;
            this._grpEthernetSetting.Location = new System.Drawing.Point(23, 30);
            this._grpEthernetSetting.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._grpEthernetSetting.Name = "_grpEthernetSetting";
            this._grpEthernetSetting.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._grpEthernetSetting.Size = new System.Drawing.Size(374, 84);
            this._grpEthernetSetting.TabIndex = 1;
            this._grpEthernetSetting.TabStop = false;
            // 
            // _txtIpFirstSegment
            // 
            this._txtIpFirstSegment.Location = new System.Drawing.Point(229, 11);
            this._txtIpFirstSegment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtIpFirstSegment.Name = "_txtIpFirstSegment";
            this._txtIpFirstSegment.Size = new System.Drawing.Size(25, 20);
            this._txtIpFirstSegment.TabIndex = 1;
            this._txtIpFirstSegment.Text = "192";
            // 
            // _txtIpFourthSegment
            // 
            this._txtIpFourthSegment.Location = new System.Drawing.Point(328, 11);
            this._txtIpFourthSegment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtIpFourthSegment.Name = "_txtIpFourthSegment";
            this._txtIpFourthSegment.Size = new System.Drawing.Size(25, 20);
            this._txtIpFourthSegment.TabIndex = 3;
            this._txtIpFourthSegment.Text = "1";
            // 
            // _txtIpSecondSegment
            // 
            this._txtIpSecondSegment.Location = new System.Drawing.Point(262, 11);
            this._txtIpSecondSegment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtIpSecondSegment.Name = "_txtIpSecondSegment";
            this._txtIpSecondSegment.Size = new System.Drawing.Size(25, 20);
            this._txtIpSecondSegment.TabIndex = 2;
            this._txtIpSecondSegment.Text = "168";
            // 
            // _lblHighSpeedPort
            // 
            this._lblHighSpeedPort.AutoSize = true;
            this._lblHighSpeedPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblHighSpeedPort.Location = new System.Drawing.Point(15, 60);
            this._lblHighSpeedPort.Name = "_lblHighSpeedPort";
            this._lblHighSpeedPort.Size = new System.Drawing.Size(216, 12);
            this._lblHighSpeedPort.TabIndex = 9;
            this._lblHighSpeedPort.Text = "TCP port number (high-speed communication)";
            // 
            // _txtIpThirdSegment
            // 
            this._txtIpThirdSegment.Location = new System.Drawing.Point(295, 11);
            this._txtIpThirdSegment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtIpThirdSegment.Name = "_txtIpThirdSegment";
            this._txtIpThirdSegment.Size = new System.Drawing.Size(25, 20);
            this._txtIpThirdSegment.TabIndex = 2;
            this._txtIpThirdSegment.Text = "0";
            // 
            // _lblIpSeparator3
            // 
            this._lblIpSeparator3.AutoSize = true;
            this._lblIpSeparator3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblIpSeparator3.Location = new System.Drawing.Point(320, 18);
            this._lblIpSeparator3.Name = "_lblIpSeparator3";
            this._lblIpSeparator3.Size = new System.Drawing.Size(8, 12);
            this._lblIpSeparator3.TabIndex = 6;
            this._lblIpSeparator3.Text = ".";
            // 
            // _lblIpSeparator2
            // 
            this._lblIpSeparator2.AutoSize = true;
            this._lblIpSeparator2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblIpSeparator2.Location = new System.Drawing.Point(288, 18);
            this._lblIpSeparator2.Name = "_lblIpSeparator2";
            this._lblIpSeparator2.Size = new System.Drawing.Size(8, 12);
            this._lblIpSeparator2.TabIndex = 5;
            this._lblIpSeparator2.Text = ".";
            // 
            // _txtHighSpeedPort
            // 
            this._txtHighSpeedPort.Location = new System.Drawing.Point(293, 56);
            this._txtHighSpeedPort.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtHighSpeedPort.Name = "_txtHighSpeedPort";
            this._txtHighSpeedPort.Size = new System.Drawing.Size(59, 20);
            this._txtHighSpeedPort.TabIndex = 10;
            this._txtHighSpeedPort.Text = "24692";
            // 
            // _lblIpSeparator1
            // 
            this._lblIpSeparator1.AutoSize = true;
            this._lblIpSeparator1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblIpSeparator1.Location = new System.Drawing.Point(254, 18);
            this._lblIpSeparator1.Name = "_lblIpSeparator1";
            this._lblIpSeparator1.Size = new System.Drawing.Size(8, 12);
            this._lblIpSeparator1.TabIndex = 4;
            this._lblIpSeparator1.Text = ".";
            // 
            // _txtCommandPort
            // 
            this._txtCommandPort.Location = new System.Drawing.Point(294, 36);
            this._txtCommandPort.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtCommandPort.Name = "_txtCommandPort";
            this._txtCommandPort.Size = new System.Drawing.Size(59, 20);
            this._txtCommandPort.TabIndex = 8;
            this._txtCommandPort.Text = "24691";
            // 
            // _lblIpAddress
            // 
            this._lblIpAddress.AutoSize = true;
            this._lblIpAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblIpAddress.Location = new System.Drawing.Point(15, 17);
            this._lblIpAddress.Name = "_lblIpAddress";
            this._lblIpAddress.Size = new System.Drawing.Size(52, 12);
            this._lblIpAddress.TabIndex = 0;
            this._lblIpAddress.Text = "IP address";
            // 
            // _lblCommandPort
            // 
            this._lblCommandPort.AutoSize = true;
            this._lblCommandPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblCommandPort.Location = new System.Drawing.Point(15, 39);
            this._lblCommandPort.Name = "_lblCommandPort";
            this._lblCommandPort.Size = new System.Drawing.Size(84, 12);
            this._lblCommandPort.TabIndex = 7;
            this._lblCommandPort.Text = "TCP port number";
            // 
            // _btnTerminateCommunication
            // 
            this._btnTerminateCommunication.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnTerminateCommunication.Location = new System.Drawing.Point(207, 18);
            this._btnTerminateCommunication.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._btnTerminateCommunication.Name = "_btnTerminateCommunication";
            this._btnTerminateCommunication.Size = new System.Drawing.Size(196, 23);
            this._btnTerminateCommunication.TabIndex = 1;
            this._btnTerminateCommunication.Text = "Communication finalization";
            this._btnTerminateCommunication.UseVisualStyleBackColor = true;
            this._btnTerminateCommunication.Click += new System.EventHandler(this.btnTerminateCommunicationEx_Click);
            // 
            // _btnEstablishCommunication
            // 
            this._btnEstablishCommunication.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._btnEstablishCommunication.Location = new System.Drawing.Point(6, 18);
            this._btnEstablishCommunication.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._btnEstablishCommunication.Name = "_btnEstablishCommunication";
            this._btnEstablishCommunication.Size = new System.Drawing.Size(196, 23);
            this._btnEstablishCommunication.TabIndex = 0;
            this._btnEstablishCommunication.Text = "Communication establishment";
            this._btnEstablishCommunication.UseVisualStyleBackColor = true;
            this._btnEstablishCommunication.Click += new System.EventHandler(this.btnEstablishCommunicationEx_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox13);
            this.tabPage1.Controls.Add(this.groupBox12);
            this.tabPage1.Controls.Add(this.groupBox11);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.cartesianChartXY);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1144, 730);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "2D Chart";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btnClearCommands);
            this.groupBox13.Controls.Add(this.listBoxCommands);
            this.groupBox13.Controls.Add(this.bntRefreshPorts);
            this.groupBox13.Controls.Add(this.button1);
            this.groupBox13.Controls.Add(this.btnLinkFileSample);
            this.groupBox13.Controls.Add(this.label15);
            this.groupBox13.Controls.Add(this.linkFileSample);
            this.groupBox13.Controls.Add(this.lblConnectionStatus);
            this.groupBox13.Controls.Add(this.comboBoxPorts);
            this.groupBox13.Controls.Add(this.btnDisconnect);
            this.groupBox13.Controls.Add(this.btnConnect);
            this.groupBox13.Controls.Add(this.btnHome);
            this.groupBox13.Location = new System.Drawing.Point(576, 8);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(561, 179);
            this.groupBox13.TabIndex = 30;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Draw Sample And Move To Waypoint";
            // 
            // btnClearCommands
            // 
            this.btnClearCommands.Location = new System.Drawing.Point(439, 96);
            this.btnClearCommands.Name = "btnClearCommands";
            this.btnClearCommands.Size = new System.Drawing.Size(75, 21);
            this.btnClearCommands.TabIndex = 45;
            this.btnClearCommands.Text = "Clear ";
            this.btnClearCommands.UseVisualStyleBackColor = true;
            this.btnClearCommands.Click += new System.EventHandler(this.btnClearCommands_Click);
            // 
            // listBoxCommands
            // 
            this.listBoxCommands.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxCommands.FormattingEnabled = true;
            this.listBoxCommands.ItemHeight = 14;
            this.listBoxCommands.Location = new System.Drawing.Point(258, 73);
            this.listBoxCommands.Name = "listBoxCommands";
            this.listBoxCommands.Size = new System.Drawing.Size(175, 74);
            this.listBoxCommands.TabIndex = 44;
            // 
            // bntRefreshPorts
            // 
            this.bntRefreshPorts.Location = new System.Drawing.Point(18, 49);
            this.bntRefreshPorts.Name = "bntRefreshPorts";
            this.bntRefreshPorts.Size = new System.Drawing.Size(75, 23);
            this.bntRefreshPorts.TabIndex = 42;
            this.bntRefreshPorts.Text = "RefreshPorts";
            this.bntRefreshPorts.UseVisualStyleBackColor = true;
            this.bntRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 41;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.drawSampleProfile_Click);
            // 
            // btnLinkFileSample
            // 
            this.btnLinkFileSample.Location = new System.Drawing.Point(439, 34);
            this.btnLinkFileSample.Name = "btnLinkFileSample";
            this.btnLinkFileSample.Size = new System.Drawing.Size(27, 21);
            this.btnLinkFileSample.TabIndex = 40;
            this.btnLinkFileSample.Text = "...";
            this.btnLinkFileSample.UseVisualStyleBackColor = true;
            this.btnLinkFileSample.Click += new System.EventHandler(this.btnLinkFileSample_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(256, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 39;
            this.label15.Text = "Link File Sample";
            // 
            // linkFileSample
            // 
            this.linkFileSample.Location = new System.Drawing.Point(258, 34);
            this.linkFileSample.Name = "linkFileSample";
            this.linkFileSample.Size = new System.Drawing.Size(175, 20);
            this.linkFileSample.TabIndex = 38;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.Red;
            this.lblConnectionStatus.Location = new System.Drawing.Point(14, 143);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(107, 20);
            this.lblConnectionStatus.TabIndex = 34;
            this.lblConnectionStatus.Text = "Disconnected";
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(18, 21);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(121, 20);
            this.comboBoxPorts.TabIndex = 32;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(18, 107);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 31;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(18, 79);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 30;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(173, 21);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 29;
            this.btnHome.Text = "Về Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.linkSaveOneProfile);
            this.groupBox12.Controls.Add(this.drawOneProfile);
            this.groupBox12.Controls.Add(this.btnSaveOneProfile);
            this.groupBox12.Controls.Add(this.btnLinkOneProfile);
            this.groupBox12.Controls.Add(this.label14);
            this.groupBox12.Location = new System.Drawing.Point(576, 195);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(561, 80);
            this.groupBox12.TabIndex = 28;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Draw Ones Time";
            // 
            // linkSaveOneProfile
            // 
            this.linkSaveOneProfile.Location = new System.Drawing.Point(40, 44);
            this.linkSaveOneProfile.Name = "linkSaveOneProfile";
            this.linkSaveOneProfile.Size = new System.Drawing.Size(175, 20);
            this.linkSaveOneProfile.TabIndex = 21;
            // 
            // drawOneProfile
            // 
            this.drawOneProfile.Location = new System.Drawing.Point(258, 20);
            this.drawOneProfile.Name = "drawOneProfile";
            this.drawOneProfile.Size = new System.Drawing.Size(75, 21);
            this.drawOneProfile.TabIndex = 17;
            this.drawOneProfile.Text = "Draw";
            this.drawOneProfile.UseVisualStyleBackColor = true;
            this.drawOneProfile.Click += new System.EventHandler(this.drawOneProfile_Click);
            // 
            // btnSaveOneProfile
            // 
            this.btnSaveOneProfile.Location = new System.Drawing.Point(258, 44);
            this.btnSaveOneProfile.Name = "btnSaveOneProfile";
            this.btnSaveOneProfile.Size = new System.Drawing.Size(75, 21);
            this.btnSaveOneProfile.TabIndex = 24;
            this.btnSaveOneProfile.Text = "Save";
            this.btnSaveOneProfile.UseVisualStyleBackColor = true;
            this.btnSaveOneProfile.Click += new System.EventHandler(this.btnsaveOneProfile_Click);
            // 
            // btnLinkOneProfile
            // 
            this.btnLinkOneProfile.Location = new System.Drawing.Point(221, 44);
            this.btnLinkOneProfile.Name = "btnLinkOneProfile";
            this.btnLinkOneProfile.Size = new System.Drawing.Size(27, 21);
            this.btnLinkOneProfile.TabIndex = 22;
            this.btnLinkOneProfile.Text = "...";
            this.btnLinkOneProfile.UseVisualStyleBackColor = true;
            this.btnLinkOneProfile.Click += new System.EventHandler(this.btnLinkOneProfile_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 12);
            this.label14.TabIndex = 23;
            this.label14.Text = "Link Save Profile";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.delayTime);
            this.groupBox11.Controls.Add(this.label12);
            this.groupBox11.Controls.Add(this.btnAutoDraw);
            this.groupBox11.Controls.Add(this.btnSaveAutoProfile);
            this.groupBox11.Controls.Add(this.linkSaveAutoProfile);
            this.groupBox11.Controls.Add(this.btnLinkAutoProfile);
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Location = new System.Drawing.Point(23, 195);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(530, 80);
            this.groupBox11.TabIndex = 27;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Auto Draw";
            // 
            // delayTime
            // 
            this.delayTime.Location = new System.Drawing.Point(15, 43);
            this.delayTime.Name = "delayTime";
            this.delayTime.Size = new System.Drawing.Size(100, 20);
            this.delayTime.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "Delayed Time";
            // 
            // btnAutoDraw
            // 
            this.btnAutoDraw.Location = new System.Drawing.Point(123, 41);
            this.btnAutoDraw.Name = "btnAutoDraw";
            this.btnAutoDraw.Size = new System.Drawing.Size(75, 23);
            this.btnAutoDraw.TabIndex = 0;
            this.btnAutoDraw.Text = "Auto Draw";
            this.btnAutoDraw.UseVisualStyleBackColor = true;
            this.btnAutoDraw.Click += new System.EventHandler(this.btnAutoDraw_Click);
            // 
            // btnSaveAutoProfile
            // 
            this.btnSaveAutoProfile.Location = new System.Drawing.Point(437, 38);
            this.btnSaveAutoProfile.Name = "btnSaveAutoProfile";
            this.btnSaveAutoProfile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAutoProfile.TabIndex = 25;
            this.btnSaveAutoProfile.Text = "Save";
            this.btnSaveAutoProfile.UseVisualStyleBackColor = true;
            this.btnSaveAutoProfile.Click += new System.EventHandler(this.btnSaveAutoProfile_Click);
            // 
            // linkSaveAutoProfile
            // 
            this.linkSaveAutoProfile.Location = new System.Drawing.Point(223, 41);
            this.linkSaveAutoProfile.Name = "linkSaveAutoProfile";
            this.linkSaveAutoProfile.Size = new System.Drawing.Size(175, 20);
            this.linkSaveAutoProfile.TabIndex = 18;
            // 
            // btnLinkAutoProfile
            // 
            this.btnLinkAutoProfile.Location = new System.Drawing.Point(404, 39);
            this.btnLinkAutoProfile.Name = "btnLinkAutoProfile";
            this.btnLinkAutoProfile.Size = new System.Drawing.Size(27, 23);
            this.btnLinkAutoProfile.TabIndex = 19;
            this.btnLinkAutoProfile.Text = "...";
            this.btnLinkAutoProfile.UseVisualStyleBackColor = true;
            this.btnLinkAutoProfile.Click += new System.EventHandler(this.btnLinkAutoProfile_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(221, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "Link Save Profile";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.panel2);
            this.groupBox9.Controls.Add(this.button3);
            this.groupBox9.Controls.Add(this.button4);
            this.groupBox9.Location = new System.Drawing.Point(23, 8);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox9.Size = new System.Drawing.Size(530, 179);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Establish/disconnect the communication path with the controller";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Controls.Add(this.groupBox10);
            this.panel2.Location = new System.Drawing.Point(6, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 120);
            this.panel2.TabIndex = 1;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton3.Location = new System.Drawing.Point(3, 5);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(42, 16);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "USB";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton4.Location = new System.Drawing.Point(3, 24);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(61, 16);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Text = "Ethernet";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this._rdEthernet1_CheckedChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.Transparent;
            this.groupBox10.Controls.Add(this._txtIpFirstSegment1);
            this.groupBox10.Controls.Add(this._txtIpFourthSegment1);
            this.groupBox10.Controls.Add(this._txtIpSecondSegment1);
            this.groupBox10.Controls.Add(this.label6);
            this.groupBox10.Controls.Add(this._txtIpThirdSegment1);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.label8);
            this.groupBox10.Controls.Add(this._txtHighSpeedPort1);
            this.groupBox10.Controls.Add(this.label9);
            this.groupBox10.Controls.Add(this._txtCommandPort1);
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Controls.Add(this.label11);
            this.groupBox10.Enabled = false;
            this.groupBox10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox10.Location = new System.Drawing.Point(23, 30);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox10.Size = new System.Drawing.Size(374, 84);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            // 
            // _txtIpFirstSegment1
            // 
            this._txtIpFirstSegment1.Location = new System.Drawing.Point(229, 11);
            this._txtIpFirstSegment1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtIpFirstSegment1.Name = "_txtIpFirstSegment1";
            this._txtIpFirstSegment1.Size = new System.Drawing.Size(25, 20);
            this._txtIpFirstSegment1.TabIndex = 1;
            this._txtIpFirstSegment1.Text = "172";
            // 
            // _txtIpFourthSegment1
            // 
            this._txtIpFourthSegment1.Location = new System.Drawing.Point(328, 11);
            this._txtIpFourthSegment1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtIpFourthSegment1.Name = "_txtIpFourthSegment1";
            this._txtIpFourthSegment1.Size = new System.Drawing.Size(25, 20);
            this._txtIpFourthSegment1.TabIndex = 3;
            this._txtIpFourthSegment1.Text = "1";
            // 
            // _txtIpSecondSegment1
            // 
            this._txtIpSecondSegment1.Location = new System.Drawing.Point(262, 11);
            this._txtIpSecondSegment1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtIpSecondSegment1.Name = "_txtIpSecondSegment1";
            this._txtIpSecondSegment1.Size = new System.Drawing.Size(25, 20);
            this._txtIpSecondSegment1.TabIndex = 2;
            this._txtIpSecondSegment1.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(15, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "TCP port number (high-speed communication)";
            // 
            // _txtIpThirdSegment1
            // 
            this._txtIpThirdSegment1.Location = new System.Drawing.Point(295, 11);
            this._txtIpThirdSegment1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtIpThirdSegment1.Name = "_txtIpThirdSegment1";
            this._txtIpThirdSegment1.Size = new System.Drawing.Size(25, 20);
            this._txtIpThirdSegment1.TabIndex = 2;
            this._txtIpThirdSegment1.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(320, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(8, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = ".";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(288, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(8, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = ".";
            // 
            // _txtHighSpeedPort1
            // 
            this._txtHighSpeedPort1.Location = new System.Drawing.Point(293, 56);
            this._txtHighSpeedPort1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtHighSpeedPort1.Name = "_txtHighSpeedPort1";
            this._txtHighSpeedPort1.Size = new System.Drawing.Size(59, 20);
            this._txtHighSpeedPort1.TabIndex = 10;
            this._txtHighSpeedPort1.Text = "24692";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(254, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(8, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = ".";
            // 
            // _txtCommandPort1
            // 
            this._txtCommandPort1.Location = new System.Drawing.Point(294, 36);
            this._txtCommandPort1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtCommandPort1.Name = "_txtCommandPort1";
            this._txtCommandPort1.Size = new System.Drawing.Size(59, 20);
            this._txtCommandPort1.TabIndex = 8;
            this._txtCommandPort1.Text = "24691";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(15, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "IP address";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(15, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "TCP port number";
            // 
            // button3
            // 
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(207, 18);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Communication finalization";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnTerminateCommunicationEx_Click);
            // 
            // button4
            // 
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(6, 18);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Communication establishment";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnEstablishCommunicationEx1_Click);
            // 
            // cartesianChartXY
            // 
            this.cartesianChartXY.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesianChartXY.Location = new System.Drawing.Point(8, 278);
            this.cartesianChartXY.Name = "cartesianChartXY";
            this.cartesianChartXY.Size = new System.Drawing.Size(1130, 449);
            this.cartesianChartXY.TabIndex = 2;
            this.cartesianChartXY.Text = "cartesianChart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox14);
            this.tabPage2.Controls.Add(this.pictureBoxPreview);
            this.tabPage2.Controls.Add(this.lblCurrentPose);
            this.tabPage2.Controls.Add(this.lblMode);
            this.tabPage2.Controls.Add(this.cartesianChart1);
            this.tabPage2.Controls.Add(this.btnAutoMode);
            this.tabPage2.Controls.Add(this.btnTeachMode);
            this.tabPage2.Controls.Add(this.grpTeach);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1144, 730);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Teaching and Auto";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.BtnScanArea);
            this.groupBox14.Controls.Add(this.lblImageName);
            this.groupBox14.Controls.Add(this.button2);
            this.groupBox14.Controls.Add(this.btnLoadImage);
            this.groupBox14.Controls.Add(this.label23);
            this.groupBox14.Controls.Add(this.label21);
            this.groupBox14.Controls.Add(this.txtLinePeriod);
            this.groupBox14.Controls.Add(this.txtSizeH);
            this.groupBox14.Controls.Add(this.label20);
            this.groupBox14.Controls.Add(this.label18);
            this.groupBox14.Controls.Add(this.label22);
            this.groupBox14.Controls.Add(this.txtSizeW);
            this.groupBox14.Controls.Add(this.label19);
            this.groupBox14.Location = new System.Drawing.Point(608, 417);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(528, 305);
            this.groupBox14.TabIndex = 49;
            this.groupBox14.TabStop = false;
            // 
            // BtnScanArea
            // 
            this.BtnScanArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnScanArea.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnScanArea.Location = new System.Drawing.Point(120, 200);
            this.BtnScanArea.Name = "BtnScanArea";
            this.BtnScanArea.Size = new System.Drawing.Size(141, 80);
            this.BtnScanArea.TabIndex = 47;
            this.BtnScanArea.Text = "Start Scan 3D";
            this.BtnScanArea.UseVisualStyleBackColor = false;
            this.BtnScanArea.Click += new System.EventHandler(this.BtnScanArea_Click);
            // 
            // lblImageName
            // 
            this.lblImageName.AutoSize = true;
            this.lblImageName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageName.Location = new System.Drawing.Point(354, 10);
            this.lblImageName.Name = "lblImageName";
            this.lblImageName.Size = new System.Drawing.Size(102, 23);
            this.lblImageName.TabIndex = 46;
            this.lblImageName.Text = "(no image)";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(348, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 42);
            this.button2.TabIndex = 45;
            this.button2.Text = "Clear Image";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadImage.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImage.Location = new System.Drawing.Point(348, 34);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(159, 42);
            this.btnLoadImage.TabIndex = 45;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(268, 139);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 33);
            this.label23.TabIndex = 43;
            this.label23.Text = "ms";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(268, 87);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 33);
            this.label21.TabIndex = 43;
            this.label21.Text = "mm";
            // 
            // txtLinePeriod
            // 
            this.txtLinePeriod.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLinePeriod.Location = new System.Drawing.Point(129, 135);
            this.txtLinePeriod.Name = "txtLinePeriod";
            this.txtLinePeriod.Size = new System.Drawing.Size(120, 41);
            this.txtLinePeriod.TabIndex = 38;
            // 
            // txtSizeH
            // 
            this.txtSizeH.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSizeH.Location = new System.Drawing.Point(129, 83);
            this.txtSizeH.Name = "txtSizeH";
            this.txtSizeH.Size = new System.Drawing.Size(120, 41);
            this.txtSizeH.TabIndex = 38;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(268, 33);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 33);
            this.label20.TabIndex = 42;
            this.label20.Text = "mm";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(23, 33);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 33);
            this.label18.TabIndex = 23;
            this.label18.Text = "Width:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(23, 139);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 33);
            this.label22.TabIndex = 37;
            this.label22.Text = "Time";
            // 
            // txtSizeW
            // 
            this.txtSizeW.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSizeW.Location = new System.Drawing.Point(129, 29);
            this.txtSizeW.Name = "txtSizeW";
            this.txtSizeW.Size = new System.Drawing.Size(120, 41);
            this.txtSizeW.TabIndex = 24;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(23, 87);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 33);
            this.label19.TabIndex = 37;
            this.label19.Text = "Height:";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPreview.Image")));
            this.pictureBoxPreview.InitialImage = null;
            this.pictureBoxPreview.Location = new System.Drawing.Point(608, 12);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(528, 399);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 48;
            this.pictureBoxPreview.TabStop = false;
            // 
            // lblCurrentPose
            // 
            this.lblCurrentPose.AutoSize = true;
            this.lblCurrentPose.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPose.Location = new System.Drawing.Point(238, 375);
            this.lblCurrentPose.Name = "lblCurrentPose";
            this.lblCurrentPose.Size = new System.Drawing.Size(178, 36);
            this.lblCurrentPose.TabIndex = 47;
            this.lblCurrentPose.Text = "Current Pose";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.BackColor = System.Drawing.Color.Silver;
            this.lblMode.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(21, 374);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(202, 36);
            this.lblMode.TabIndex = 31;
            this.lblMode.Text = "AUTO MODE";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesianChart1.Location = new System.Drawing.Point(15, 86);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(587, 279);
            this.cartesianChart1.TabIndex = 29;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // btnAutoMode
            // 
            this.btnAutoMode.BackColor = System.Drawing.Color.Red;
            this.btnAutoMode.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoMode.ForeColor = System.Drawing.Color.White;
            this.btnAutoMode.Location = new System.Drawing.Point(15, 12);
            this.btnAutoMode.Name = "btnAutoMode";
            this.btnAutoMode.Size = new System.Drawing.Size(216, 68);
            this.btnAutoMode.TabIndex = 27;
            this.btnAutoMode.Text = "AUTO MODE";
            this.btnAutoMode.UseVisualStyleBackColor = false;
            this.btnAutoMode.Click += new System.EventHandler(this.btnAutoMode_Click);
            // 
            // btnTeachMode
            // 
            this.btnTeachMode.BackColor = System.Drawing.Color.Blue;
            this.btnTeachMode.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeachMode.ForeColor = System.Drawing.Color.White;
            this.btnTeachMode.Location = new System.Drawing.Point(255, 12);
            this.btnTeachMode.Name = "btnTeachMode";
            this.btnTeachMode.Size = new System.Drawing.Size(216, 68);
            this.btnTeachMode.TabIndex = 28;
            this.btnTeachMode.Text = "TEACH MODE";
            this.btnTeachMode.UseVisualStyleBackColor = false;
            // 
            // grpTeach
            // 
            this.grpTeach.Controls.Add(this.lblTemplatePath);
            this.grpTeach.Controls.Add(this.btnLoadTemplate);
            this.grpTeach.Controls.Add(this.btnSaveTemplate);
            this.grpTeach.Controls.Add(this.label17);
            this.grpTeach.Controls.Add(this.label16);
            this.grpTeach.Controls.Add(this.chkStopOnNG);
            this.grpTeach.Controls.Add(this.btnDistMinus);
            this.grpTeach.Controls.Add(this.btnDistPlus);
            this.grpTeach.Controls.Add(this.txtDistance);
            this.grpTeach.Controls.Add(this.txtDistance1);
            this.grpTeach.Controls.Add(this.btnPos4);
            this.grpTeach.Controls.Add(this.btnPos2);
            this.grpTeach.Controls.Add(this.btnPos3);
            this.grpTeach.Controls.Add(this.btnPos1);
            this.grpTeach.Controls.Add(this.btnZm);
            this.grpTeach.Controls.Add(this.btnZp);
            this.grpTeach.Controls.Add(this.btnYm);
            this.grpTeach.Controls.Add(this.btnYp);
            this.grpTeach.Controls.Add(this.btnXm);
            this.grpTeach.Controls.Add(this.btnXp);
            this.grpTeach.Controls.Add(this.btnSpeedMinus);
            this.grpTeach.Controls.Add(this.btnSpeedPlus);
            this.grpTeach.Controls.Add(this.txtSpeed);
            this.grpTeach.Controls.Add(this.txtSpeed1);
            this.grpTeach.Location = new System.Drawing.Point(15, 417);
            this.grpTeach.Name = "grpTeach";
            this.grpTeach.Size = new System.Drawing.Size(587, 307);
            this.grpTeach.TabIndex = 30;
            this.grpTeach.TabStop = false;
            // 
            // lblTemplatePath
            // 
            this.lblTemplatePath.AutoSize = true;
            this.lblTemplatePath.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplatePath.Location = new System.Drawing.Point(407, 34);
            this.lblTemplatePath.Name = "lblTemplatePath";
            this.lblTemplatePath.Size = new System.Drawing.Size(123, 23);
            this.lblTemplatePath.TabIndex = 46;
            this.lblTemplatePath.Text = "(no template)";
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadTemplate.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTemplate.Location = new System.Drawing.Point(492, 57);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(79, 42);
            this.btnLoadTemplate.TabIndex = 45;
            this.btnLoadTemplate.Text = "Load Template";
            this.btnLoadTemplate.UseVisualStyleBackColor = false;
            this.btnLoadTemplate.Click += new System.EventHandler(this.btnLoadTemplate_Click);
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSaveTemplate.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTemplate.Location = new System.Drawing.Point(407, 57);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(79, 42);
            this.btnSaveTemplate.TabIndex = 44;
            this.btnSaveTemplate.Text = "Save Template";
            this.btnSaveTemplate.UseVisualStyleBackColor = false;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(223, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 33);
            this.label17.TabIndex = 43;
            this.label17.Text = "mm";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(223, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 33);
            this.label16.TabIndex = 42;
            this.label16.Text = "%";
            // 
            // chkStopOnNG
            // 
            this.chkStopOnNG.AutoSize = true;
            this.chkStopOnNG.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStopOnNG.Location = new System.Drawing.Point(6, 272);
            this.chkStopOnNG.Name = "chkStopOnNG";
            this.chkStopOnNG.Size = new System.Drawing.Size(195, 35);
            this.chkStopOnNG.TabIndex = 41;
            this.chkStopOnNG.Text = "Stop when NG";
            this.chkStopOnNG.UseVisualStyleBackColor = true;
            // 
            // btnDistMinus
            // 
            this.btnDistMinus.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDistMinus.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistMinus.Location = new System.Drawing.Point(337, 82);
            this.btnDistMinus.Name = "btnDistMinus";
            this.btnDistMinus.Size = new System.Drawing.Size(42, 42);
            this.btnDistMinus.TabIndex = 40;
            this.btnDistMinus.Text = "-";
            this.btnDistMinus.UseVisualStyleBackColor = false;
            // 
            // btnDistPlus
            // 
            this.btnDistPlus.BackColor = System.Drawing.Color.Red;
            this.btnDistPlus.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistPlus.Location = new System.Drawing.Point(288, 82);
            this.btnDistPlus.Name = "btnDistPlus";
            this.btnDistPlus.Size = new System.Drawing.Size(42, 42);
            this.btnDistPlus.TabIndex = 39;
            this.btnDistPlus.Text = "+";
            this.btnDistPlus.UseVisualStyleBackColor = false;
            // 
            // txtDistance
            // 
            this.txtDistance.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistance.Location = new System.Drawing.Point(134, 83);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(83, 41);
            this.txtDistance.TabIndex = 38;
            // 
            // txtDistance1
            // 
            this.txtDistance1.AutoSize = true;
            this.txtDistance1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistance1.Location = new System.Drawing.Point(6, 87);
            this.txtDistance1.Name = "txtDistance1";
            this.txtDistance1.Size = new System.Drawing.Size(122, 33);
            this.txtDistance1.TabIndex = 37;
            this.txtDistance1.Text = "Distance:";
            // 
            // btnPos4
            // 
            this.btnPos4.BackColor = System.Drawing.Color.Cyan;
            this.btnPos4.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPos4.Location = new System.Drawing.Point(407, 212);
            this.btnPos4.Name = "btnPos4";
            this.btnPos4.Size = new System.Drawing.Size(137, 57);
            this.btnPos4.TabIndex = 36;
            this.btnPos4.Text = "Position 4";
            this.btnPos4.UseVisualStyleBackColor = false;
            this.btnPos4.Click += new System.EventHandler(this.btnPos4_Click);
            // 
            // btnPos2
            // 
            this.btnPos2.BackColor = System.Drawing.Color.Cyan;
            this.btnPos2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPos2.Location = new System.Drawing.Point(242, 215);
            this.btnPos2.Name = "btnPos2";
            this.btnPos2.Size = new System.Drawing.Size(137, 57);
            this.btnPos2.TabIndex = 35;
            this.btnPos2.Text = "Position 2";
            this.btnPos2.UseVisualStyleBackColor = false;
            this.btnPos2.Click += new System.EventHandler(this.btnPos2_Click);
            // 
            // btnPos3
            // 
            this.btnPos3.BackColor = System.Drawing.Color.Cyan;
            this.btnPos3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPos3.Location = new System.Drawing.Point(407, 157);
            this.btnPos3.Name = "btnPos3";
            this.btnPos3.Size = new System.Drawing.Size(137, 57);
            this.btnPos3.TabIndex = 34;
            this.btnPos3.Text = "Position 3";
            this.btnPos3.UseVisualStyleBackColor = false;
            this.btnPos3.Click += new System.EventHandler(this.btnPos3_Click);
            // 
            // btnPos1
            // 
            this.btnPos1.BackColor = System.Drawing.Color.Cyan;
            this.btnPos1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPos1.Location = new System.Drawing.Point(242, 157);
            this.btnPos1.Name = "btnPos1";
            this.btnPos1.Size = new System.Drawing.Size(137, 57);
            this.btnPos1.TabIndex = 33;
            this.btnPos1.Text = "Position 1";
            this.btnPos1.UseVisualStyleBackColor = false;
            this.btnPos1.Click += new System.EventHandler(this.btnPos1_Click);
            // 
            // btnZm
            // 
            this.btnZm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnZm.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZm.Location = new System.Drawing.Point(159, 215);
            this.btnZm.Name = "btnZm";
            this.btnZm.Size = new System.Drawing.Size(58, 54);
            this.btnZm.TabIndex = 32;
            this.btnZm.Text = "Z-";
            this.btnZm.UseVisualStyleBackColor = false;
            this.btnZm.Click += new System.EventHandler(this.btnZm_Click);
            // 
            // btnZp
            // 
            this.btnZp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnZp.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZp.Location = new System.Drawing.Point(159, 157);
            this.btnZp.Name = "btnZp";
            this.btnZp.Size = new System.Drawing.Size(58, 54);
            this.btnZp.TabIndex = 31;
            this.btnZp.Text = "Z+";
            this.btnZp.UseVisualStyleBackColor = false;
            this.btnZp.Click += new System.EventHandler(this.btnZp_Click);
            // 
            // btnYm
            // 
            this.btnYm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnYm.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYm.Location = new System.Drawing.Point(80, 215);
            this.btnYm.Name = "btnYm";
            this.btnYm.Size = new System.Drawing.Size(58, 54);
            this.btnYm.TabIndex = 30;
            this.btnYm.Text = "Y-";
            this.btnYm.UseVisualStyleBackColor = false;
            this.btnYm.Click += new System.EventHandler(this.btnYm_Click);
            // 
            // btnYp
            // 
            this.btnYp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnYp.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYp.Location = new System.Drawing.Point(80, 157);
            this.btnYp.Name = "btnYp";
            this.btnYp.Size = new System.Drawing.Size(58, 54);
            this.btnYp.TabIndex = 29;
            this.btnYp.Text = "Y+";
            this.btnYp.UseVisualStyleBackColor = false;
            this.btnYp.Click += new System.EventHandler(this.btnYp_Click);
            // 
            // btnXm
            // 
            this.btnXm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXm.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXm.Location = new System.Drawing.Point(6, 215);
            this.btnXm.Name = "btnXm";
            this.btnXm.Size = new System.Drawing.Size(58, 54);
            this.btnXm.TabIndex = 28;
            this.btnXm.Text = "X-";
            this.btnXm.UseVisualStyleBackColor = false;
            this.btnXm.Click += new System.EventHandler(this.btnXm_Click);
            // 
            // btnXp
            // 
            this.btnXp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXp.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXp.Location = new System.Drawing.Point(6, 157);
            this.btnXp.Name = "btnXp";
            this.btnXp.Size = new System.Drawing.Size(58, 54);
            this.btnXp.TabIndex = 27;
            this.btnXp.Text = "X+";
            this.btnXp.UseVisualStyleBackColor = false;
            this.btnXp.Click += new System.EventHandler(this.btnXp_Click);
            // 
            // btnSpeedMinus
            // 
            this.btnSpeedMinus.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSpeedMinus.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeedMinus.Location = new System.Drawing.Point(337, 28);
            this.btnSpeedMinus.Name = "btnSpeedMinus";
            this.btnSpeedMinus.Size = new System.Drawing.Size(42, 42);
            this.btnSpeedMinus.TabIndex = 26;
            this.btnSpeedMinus.Text = "-";
            this.btnSpeedMinus.UseVisualStyleBackColor = false;
            // 
            // btnSpeedPlus
            // 
            this.btnSpeedPlus.BackColor = System.Drawing.Color.Red;
            this.btnSpeedPlus.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeedPlus.Location = new System.Drawing.Point(288, 28);
            this.btnSpeedPlus.Name = "btnSpeedPlus";
            this.btnSpeedPlus.Size = new System.Drawing.Size(42, 42);
            this.btnSpeedPlus.TabIndex = 25;
            this.btnSpeedPlus.Text = "+";
            this.btnSpeedPlus.UseVisualStyleBackColor = false;
            // 
            // txtSpeed
            // 
            this.txtSpeed.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeed.Location = new System.Drawing.Point(134, 29);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(83, 41);
            this.txtSpeed.TabIndex = 24;
            // 
            // txtSpeed1
            // 
            this.txtSpeed1.AutoSize = true;
            this.txtSpeed1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeed1.Location = new System.Drawing.Point(6, 33);
            this.txtSpeed1.Name = "txtSpeed1";
            this.txtSpeed1.Size = new System.Drawing.Size(93, 33);
            this.txtSpeed1.TabIndex = 23;
            this.txtSpeed1.Text = "Speed:";
            // 
            // _timerHighSpeed
            // 
            this._timerHighSpeed.Interval = 200;
            this._timerHighSpeed.Tick += new System.EventHandler(this._timerHighSpeed_Tick);
            // 
            // _openProgramFileDialog
            // 
            this._openProgramFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 755);
            this.Controls.Add(this._rdEthernet1);
            this.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "DLL Function Sample";
            this._grpCommand.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this._groupBox1.ResumeLayout(false);
            this._grpLog.ResumeLayout(false);
            this._grpLog.PerformLayout();
            this._grpBufferSize.ResumeLayout(false);
            this._grpBufferSize.PerformLayout();
            this._grpReceived.ResumeLayout(false);
            this._grpReceived.PerformLayout();
            this._grpMeasureRange.ResumeLayout(false);
            this._grpMeasureRange.PerformLayout();
            this._grpHead.ResumeLayout(false);
            this._grpHead.PerformLayout();
            this._grpExport.ResumeLayout(false);
            this._grpExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudProfileNo)).EndInit();
            this._pnlDeviceId.ResumeLayout(false);
            this._pnlDeviceId.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numInterval)).EndInit();
            this._rdEthernet1.ResumeLayout(false);
            this._tabPage1.ResumeLayout(false);
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this._tabPage2.ResumeLayout(false);
            this._grpProgram.ResumeLayout(false);
            this._grpProgram.PerformLayout();
            this._grpHighSpeed.ResumeLayout(false);
            this._grpHighSpeed.PerformLayout();
            this._grpGetData.ResumeLayout(false);
            this._grpGetData.PerformLayout();
            this._grpGetProfile.ResumeLayout(false);
            this._grpGetProfile.PerformLayout();
            this._grpBaseOperation.ResumeLayout(false);
            this._pnlCommunicationDevice.ResumeLayout(false);
            this._pnlCommunicationDevice.PerformLayout();
            this._grpEthernetSetting.ResumeLayout(false);
            this._grpEthernetSetting.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.grpTeach.ResumeLayout(false);
            this.grpTeach.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnUsbOpen;
        private System.Windows.Forms.Button _btnGetTime;
        private System.Windows.Forms.Button _btnGetVersion;
        private System.Windows.Forms.Button _btnFinalize;
        private System.Windows.Forms.Button _btnInitialize;
        private System.Windows.Forms.Button _btnCommClose;
        private System.Windows.Forms.Button _btnEthernetOpen;
        private System.Windows.Forms.GroupBox _grpCommand;
        private System.Windows.Forms.Button _btnAutoZero;
        private System.Windows.Forms.Button _btnStopMeasure;
        private System.Windows.Forms.Button _btnStartMeasure;
        private System.Windows.Forms.Button _btnTrigger;
        private System.Windows.Forms.Button _btnClearError;
        private System.Windows.Forms.Button _btnGetError;
        private System.Windows.Forms.Button _btnRetrunToFactorySetting;
        private System.Windows.Forms.Button _btnRebootController;
        private System.Windows.Forms.Button _btnStopStorage;
        private System.Windows.Forms.Button _btnStartStorage;
        private System.Windows.Forms.Button _btnGetBatchProfileAdvance;
        private System.Windows.Forms.Button _btnGetProfileAdvance;
        private System.Windows.Forms.Button _btnGetBatchProfile;
        private System.Windows.Forms.Button _btnGetProfile;
        private System.Windows.Forms.Button _btnGetMeasurementValue;
        private System.Windows.Forms.Button _btnChangeActiveProgram;
        private System.Windows.Forms.Button _btnSetTime;
        private System.Windows.Forms.Button _btnUpdataSetting;
        private System.Windows.Forms.Button _btnCheckMemoryAccess;
        private System.Windows.Forms.Button _btnSetSetting;
        private System.Windows.Forms.Button _btnGetSetting;
        private System.Windows.Forms.Button _btnClearMemory;
        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.Button _btnTiming;
        private System.Windows.Forms.Button _btnGetStorageStatus;
        private System.Windows.Forms.Button _btnGetStorageData;
        private System.Windows.Forms.Button _btnGetStorageProfile;
        private System.Windows.Forms.Button _btnGetStorageBatchProfile;
        private System.Windows.Forms.Button _btnRewriteTemporarySetting;
        private System.Windows.Forms.Button _btnHighSpeedDataEthernetCommunicationInitalize;
        private System.Windows.Forms.Button _btnPreStartHighSpeedDataCommunication;
        private System.Windows.Forms.Button _btnStartHighSpeedDataCommunication;
        private System.Windows.Forms.Button _btnHighSpeedDataCommunicationFinalize;
        private System.Windows.Forms.Button _btnStopHighSpeedDataCommunication;
        private System.Windows.Forms.Button _btnGetActiveProgram;
        private System.Windows.Forms.GroupBox _grpLog;
        private System.Windows.Forms.Button _btnLogClear;
        private System.Windows.Forms.TextBox _txtboxLog;
        private System.Windows.Forms.Button _btnInitializeSetting;
        private System.Windows.Forms.GroupBox _grpBufferSize;
        private System.Windows.Forms.CheckBox _chkboxEnvelope;
        private System.Windows.Forms.GroupBox _grpHead;
        private System.Windows.Forms.RadioButton _rdbtnTwoHead;
        private System.Windows.Forms.RadioButton _rdbtnOneHead;
        private System.Windows.Forms.GroupBox _grpMeasureRange;
        private System.Windows.Forms.Label _lblReceivedBinning;
        private System.Windows.Forms.Label _lblMeasureX;
        private System.Windows.Forms.GroupBox _grpReceived;
        private System.Windows.Forms.ComboBox _cmbMeasureX;
        private System.Windows.Forms.ComboBox _cmbReceivedBinning;
        private System.Windows.Forms.Button _btnHighSpeedDataUsbCommunicationInitalize;
        private System.Windows.Forms.GroupBox _grpExport;
        private System.Windows.Forms.TextBox _txtboxProfileFilePath;
        private System.Windows.Forms.Button _btnProfileFileSave;
        private System.Windows.Forms.SaveFileDialog _profileFileSave;
        private System.Windows.Forms.RadioButton _rdbtnWide;
        private System.Windows.Forms.ComboBox _cmbCompressX;
        private System.Windows.Forms.Label _lblCompressX;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Label _lblSavePath;
        private System.Windows.Forms.NumericUpDown _nudProfileNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer _timerHighSpeedReceive;
        private System.Windows.Forms.Label _lblReceiveProfileCount0;
        private System.Windows.Forms.Button _btnSaveMeasureData;
        private System.Windows.Forms.RadioButton _rdDevice0;
        private System.Windows.Forms.RadioButton _rdDevice2;
        private System.Windows.Forms.RadioButton _rdDevice1;
        private System.Windows.Forms.Panel _pnlDeviceId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lblDeviceStatus2;
        private System.Windows.Forms.Label _lblDeviceStatus1;
        private System.Windows.Forms.Label _lblDeviceStatus0;
        private System.Windows.Forms.Label _lblReceiveProfileCount2;
        private System.Windows.Forms.Label _lblReceiveProfileCount1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox _chkOnlyProfileCount;
        private System.Windows.Forms.CheckBox _chkStartTimer;
        private System.Windows.Forms.NumericUpDown _numInterval;
        private System.Windows.Forms.TabControl _rdEthernet1;
        private System.Windows.Forms.TabPage _tabPage1;
        private System.Windows.Forms.TabPage _tabPage2;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox _grpHighSpeed;
        private System.Windows.Forms.TextBox _txtCallbackFrequency;
        private System.Windows.Forms.TextBox _txtStartProfileNo;
        private System.Windows.Forms.Label _lblReceiveProfileCount;
        private System.Windows.Forms.Label _lblCallbackFrequency;
        private System.Windows.Forms.Label _lblHighSpeedStartNo;
        private System.Windows.Forms.Label _lblReceiveCount;
        private System.Windows.Forms.Button _btnTerminateHighSpeedCommunication;
        private System.Windows.Forms.Button _btnBeginHighSpeedDataCommunication;
        private System.Windows.Forms.GroupBox _grpGetData;
        private System.Windows.Forms.TextBox _txtMeasureData;
        private System.Windows.Forms.GroupBox _grpGetProfile;
        private System.Windows.Forms.Button _btnGetProfileAdvanceData;
        private System.Windows.Forms.Button _btnReferenceSavePath;
        private System.Windows.Forms.Button _btnGetBatchProfileDataAdvance;
        private System.Windows.Forms.Button _btnGetBatchProfileData;
        private System.Windows.Forms.Button _btnGetProfileData;
        private System.Windows.Forms.TextBox _txtSavePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnGetLatestMeasureValue;
        private System.Windows.Forms.GroupBox _grpBaseOperation;
        private System.Windows.Forms.Panel _pnlCommunicationDevice;
        private System.Windows.Forms.RadioButton _rdUsb;
        private System.Windows.Forms.RadioButton _rdEthernet;
        private System.Windows.Forms.GroupBox _grpEthernetSetting;
        private System.Windows.Forms.TextBox _txtIpFirstSegment;
        private System.Windows.Forms.TextBox _txtIpFourthSegment;
        private System.Windows.Forms.TextBox _txtIpSecondSegment;
        private System.Windows.Forms.TextBox _txtIpThirdSegment;
        private System.Windows.Forms.Label _lblIpSeparator3;
        private System.Windows.Forms.Label _lblIpSeparator2;
        private System.Windows.Forms.Label _lblHighSpeedPort;
        private System.Windows.Forms.TextBox _txtHighSpeedPort;
        private System.Windows.Forms.Label _lblIpSeparator1;
        private System.Windows.Forms.TextBox _txtCommandPort;
        private System.Windows.Forms.Label _lblIpAddress;
        private System.Windows.Forms.Label _lblCommandPort;
        private System.Windows.Forms.Button _btnTerminateCommunication;
        private System.Windows.Forms.Button _btnEstablishCommunication;
        private System.Windows.Forms.GroupBox _grpProgram;
        private System.Windows.Forms.Button _btnUploadProgram;
        private System.Windows.Forms.Button _btnDownloadProgram;
        private System.Windows.Forms.Button _btnReferenceProgramFilePath;
        private System.Windows.Forms.TextBox _txtProgramFilePath;
        private System.Windows.Forms.Label _lblSelectProgram;
        private System.Windows.Forms.ComboBox _cbxSelectProgram;
        private System.Windows.Forms.Label _lblConectedDevice;
        private System.Windows.Forms.Label _lblDeviceStatus3;
        private System.Windows.Forms.RadioButton _rdDevice3;
        private System.Windows.Forms.Label _lblReceiveProfileCount3;
        private System.Windows.Forms.Label _lblDeviceStatus4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label _lblDeviceStatus5;
        private System.Windows.Forms.Label _lblReceiveProfileCount5;
        private System.Windows.Forms.Label _lblReceiveProfileCount4;
        private System.Windows.Forms.Timer _timerHighSpeed;
        private System.Windows.Forms.OpenFileDialog _openProgramFileDialog;
        private System.Windows.Forms.Label _lblSettingAttention;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnAutoDraw;
        private LiveCharts.WinForms.CartesianChart cartesianChartXY;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox _txtIpFirstSegment1;
        private System.Windows.Forms.TextBox _txtIpFourthSegment1;
        private System.Windows.Forms.TextBox _txtIpSecondSegment1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _txtIpThirdSegment1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _txtHighSpeedPort1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _txtCommandPort1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox delayTime;
        private System.Windows.Forms.Button btnSaveAutoProfile;
        private System.Windows.Forms.Button btnSaveOneProfile;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnLinkOneProfile;
        private System.Windows.Forms.TextBox linkSaveOneProfile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnLinkAutoProfile;
        private System.Windows.Forms.TextBox linkSaveAutoProfile;
        private System.Windows.Forms.Button drawOneProfile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox linkFileSample;
        private System.Windows.Forms.Button btnLinkFileSample;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bntRefreshPorts;
        private System.Windows.Forms.ListBox listBoxCommands;
        private System.Windows.Forms.Button btnClearCommands;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblMode;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button btnAutoMode;
        private System.Windows.Forms.Button btnTeachMode;
        private System.Windows.Forms.GroupBox grpTeach;
        private System.Windows.Forms.CheckBox chkStopOnNG;
        private System.Windows.Forms.Button btnDistMinus;
        private System.Windows.Forms.Button btnDistPlus;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label txtDistance1;
        private System.Windows.Forms.Button btnPos4;
        private System.Windows.Forms.Button btnPos2;
        private System.Windows.Forms.Button btnPos3;
        private System.Windows.Forms.Button btnPos1;
        private System.Windows.Forms.Button btnZm;
        private System.Windows.Forms.Button btnZp;
        private System.Windows.Forms.Button btnYm;
        private System.Windows.Forms.Button btnYp;
        private System.Windows.Forms.Button btnXm;
        private System.Windows.Forms.Button btnXp;
        private System.Windows.Forms.Button btnSpeedMinus;
        private System.Windows.Forms.Button btnSpeedPlus;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label txtSpeed1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnLoadTemplate;
        private System.Windows.Forms.Button btnSaveTemplate;
        private System.Windows.Forms.Label lblTemplatePath;
        private System.Windows.Forms.Label lblCurrentPose;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label lblImageName;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSizeH;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtSizeW;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtLinePeriod;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button BtnScanArea;
    }
}

