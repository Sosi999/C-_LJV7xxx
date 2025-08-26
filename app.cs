using LiveCharts;
using LiveCharts.Defaults;           // ObservablePoint
using LiveCharts.WinForms;           // CartesianChart (WinForms)
using LiveCharts.Wpf;
using LJV7_DllSampleAll.Datas;
using LJV7_DllSampleAll.Forms;
using LJV7_DllSampleAll.Properties;
using Newtonsoft.Json;               // nếu dùng Save/Load JSON
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging; // để save ảnh PNG vào MemoryStream
using System.Globalization;          // cho InvariantCulture
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WFChart = LiveCharts.WinForms.CartesianChart;
using WpfBrushes = System.Windows.Media.Brushes;
using WpfLineSeries = LiveCharts.Wpf.LineSeries; // alias cho WPF LineSeries
using System.Diagnostics;              // Stopwatch
using System.Text.RegularExpressions;  // Regex, RegexOptions


namespace LJV7_DllSampleAll
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer updateTimer;
        private bool isUpdating = false;
        private string _templatePath = null;
        //private bool isUpdating1 = false;
        // --- Move XYZ state ---
        private int _speedPercent = 50;      // 0..100 (default 50)
        private double _distanceMm = 10.0;   // default 10 mm
        private bool _teachMode = false;
        private CancellationTokenSource _serialCts;
        private Task _serialReaderTask;
        private readonly ConcurrentQueue<string> _rxLines = new ConcurrentQueue<string>();
        private TaskCompletionSource<bool> _waitOkTcs;   // dùng để “đợi OK” khi cần
        private WpfLineSeries _xyTemplateSeries;
        private WpfLineSeries _xyMeasuredSeries;

        // (tuỳ chọn) cho cartesianChart1
        private WpfLineSeries _c1TemplateSeries;
        private WpfLineSeries _c1MeasuredSeries;

        private readonly object _poseLock = new object();
        private double _lastX = double.NaN, _lastY = double.NaN, _lastZ = double.NaN;
        SerialPort arduinoPort;


        private string _lastImagePath = null;
        private string _lastLoadedImageFullPath = null;
        private double _scanStepMm = 15.0;
        
        #region Teach&Run Model
        public class PointTemplate
        {
            public int Index;
            public double X, Y, Z;
            public List<double> ProfX = new List<double>();
            public List<double> ProfY = new List<double>();
        }

        public class TemplateSet
        {
            public string Name = "Default";
            public DateTime Created = DateTime.Now;
            public List<PointTemplate> Points = new List<PointTemplate>();

            public string ImageBase64 = null;  // Ảnh preview encode base64 (PNG)
            public string ImageName = null;    // Tên hiển thị của ảnh (nếu có)
            public string ImagePath = null;  // (tuỳ chọn) đường dẫn ảnh relative so với file .json
        }

        private TemplateSet _template = new TemplateSet();
        #endregion

        #region Enum
        
        public enum JudgeResult
        {
            OK,
            NG
        }


        /// <summary>
        /// Send command definition
        /// </summary>
        /// <remark>Defined for separate return code distinction</remark>
        public enum SendCommand
        {
            /// <summary>None</summary>
            None,
            /// <summary>Restart</summary>
            RebootController,
            /// <summary>Trigger</summary>
            Trigger,
            /// <summary>Start measurement</summary>
            StartMeasure,
            /// <summary>Stop measurement</summary>
            StopMeasure,
            /// <summary>Auto zero</summary>
            AutoZero,
            /// <summary>Timing</summary>
            Timing,
            /// <summary>Reset</summary>
            Reset,
            /// <summary>Program switch</summary>
            ChangeActiveProgram,
            /// <summary>Get measurement results</summary>
            GetMeasurementValue,

            /// <summary>Get profiles</summary>
            GetProfile,
            /// <summary>Get batch profiles (operation mode "high-speed (profile only)")</summary>
            GetBatchProfile,
            /// <summary>Get profiles (operation mode "advanced (with OUT measurement)")</summary>
            GetProfileAdvance,
            /// <summary>Get batch profiles (operation mode "advanced (with OUT measurement)").</summary>
            GetBatchProfileAdvance,

            /// <summary>Start storage</summary>
            StartStorage,
            /// <summary>Stop storage</summary>
            StopStorage,
            /// <summary>Get storage status</summary>
            GetStorageStatus,
            /// <summary>Manual storage request</summary>
            RequestStorage,
            /// <summary>Get storage data</summary>
            GetStorageData,
            /// <summary>Get profile storage data</summary>
            GetStorageProfile,
            /// <summary>Get batch profile storage data.</summary>
            GetStorageBatchProfile,

            /// <summary>Initialize USB high-speed data communication</summary>
            HighSpeedDataUsbCommunicationInitalize,
            /// <summary>Initialize Ethernet high-speed data communication</summary>
            HighSpeedDataEthernetCommunicationInitalize,
            /// <summary>Request preparation before starting high-speed data communication</summary>
            PreStartHighSpeedDataCommunication,
            /// <summary>Start high-speed data communication</summary>
            StartHighSpeedDataCommunication,
        }

        #endregion

        #region Field

        /// <summary>Ethernet settings structure </summary>
        private LJV7IF_ETHERNET_CONFIG _ethernetConfig;
        private LJV7IF_ETHERNET_CONFIG _ethernetConfig1;
        /// <summary>Measurement data list</summary>
        private List<MeasureData> _measureDatas;
        /// <summary>Current device ID</summary>
        private int _currentDeviceId;
        /// <summary>Send command</summary>
        private SendCommand _sendCommand;
        /// <summary>Callback function used during high-speed communication</summary>
        private HighSpeedDataCallBack _callback;
        /// <summary>Callback function used during high-speed communication (count only)</summary>
        private HighSpeedDataCallBack _callbackOnlyCount;

        /// The following are maintained in arrays to support multiple controllers.
        /// <summary>Array of profile information structures</summary>
        private LJV7IF_PROFILE_INFO[] _profileInfo;
        /// <summary>Array of controller information</summary>
        private DeviceData[] _deviceData;
        /// <summary>Array of labels that indicate the controller status</summary>
        private Label[] _deviceStatusLabels;
        /// <summary>Array of labels that indicate the number of received profiles </summary>
        private Label[] _receivedProfileCountLabels;

        #endregion

        #region Event handler(for single-function)

        #region Button for operating the DLL
        /// <summary>
        /// "Initialize" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitialize_Click(object sender, EventArgs e)
        {
            int rc = NativeMethods.LJV7IF_Initialize();
            AddLogResult(rc, Resources.SID_INITIALIZE);

            for (int i = 0; i < _deviceData.Length; i++)
            {
                _deviceData[i].Status = DeviceStatus.NoConnection;
                _deviceStatusLabels[i].Text = _deviceData[i].GetStatusString();
            }
        }

        /// <summary>
        /// "GetVersion" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetVersion_Click(object sender, EventArgs e)
        {
            AddLogResult((int)Rc.Ok, Resources.SID_GET_VERSION);
            AddLog(NativeMethods.LJV7IF_GetVersion().ToString("x"));
        }

        /// <summary>
        /// "Finalize" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinalize_Click(object sender, EventArgs e)
        {
            int rc = NativeMethods.LJV7IF_Finalize();
            AddLogResult(rc, Resources.SID_FINALIZE);
            for (int i = 0; i < _deviceData.Length; i++)
            {
                _deviceData[i].Status = DeviceStatus.NoConnection;
                _deviceStatusLabels[i].Text = _deviceData[i].GetStatusString();
            }
        }
        #endregion

        #region Button for establishing and disconnecting the communication path with the controller
        /// <summary>
        /// "UsbOpen" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUsbOpen_Click(object sender, EventArgs e)
        {
            int rc = NativeMethods.LJV7IF_UsbOpen(_currentDeviceId);
            // @Point
            // # Enter the "_currentDeviceId" set here for the communication settings into the arguments of each DLL function.
            // # If you want to get data from multiple controllers, prepare and set multiple "_currentDeviceId" values,
            //   enter these values into the arguments of the DLL functions, and then use the functions.

            AddLogResult(rc, Resources.SID_USB_OPEN);

            _deviceData[_currentDeviceId].Status = (rc == (int)Rc.Ok) ? DeviceStatus.Usb : DeviceStatus.NoConnection;
            _deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
        }

        /// <summary>
        /// "EthernetOpen" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEthernetOpen_Click(object sender, EventArgs e)
        {
            using (OpenEthernetForm openEthernetForm = new OpenEthernetForm())
            {
                if (DialogResult.OK == openEthernetForm.ShowDialog())
                {
                    LJV7IF_ETHERNET_CONFIG ethernetConfig = openEthernetForm.EthernetConfig;
                    // @Point
                    // # Enter the "_currentDeviceId" set here for the communication settings into the arguments of each DLL function.
                    // # If you want to get data from multiple controllers, prepare and set multiple "_currentDeviceId" values,
                    //   enter these values into the arguments of the DLL functions, and then use the functions.

                    int rc = NativeMethods.LJV7IF_EthernetOpen(_currentDeviceId, ref ethernetConfig);
                    AddLogResult(rc, Resources.SID_ETHERNET_OPEN);

                    if (rc == (int)Rc.Ok)
                    {
                        _deviceData[_currentDeviceId].Status = DeviceStatus.Ethernet;
                        _deviceData[_currentDeviceId].EthernetConfig = ethernetConfig;
                    }
                    else
                    {
                        _deviceData[_currentDeviceId].Status = DeviceStatus.NoConnection;
                    }
                    _deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
                }
            }
        }

        /// <summary>
        /// "CommClose" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommClose_Click(object sender, EventArgs e)
        {
            int rc = NativeMethods.LJV7IF_CommClose(_currentDeviceId);
            AddLogResult(rc, Resources.SID_COMM_CLOSE);

            _deviceData[_currentDeviceId].Status = DeviceStatus.NoConnection;
            _deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
        }
        #endregion

        #region Buttons for controlling the system
        /// <summary>
        /// "RebootController" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRebootController_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.RebootController;

            int rc = NativeMethods.LJV7IF_RebootController(_currentDeviceId);
            AddLogResult(rc, Resources.SID_REBOOT_CONTROLLER);
        }

        /// <summary>
        /// "RetrunToFactorySetting" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrunToFactorySetting_Click(object sender, EventArgs e)
        {
            int rc = NativeMethods.LJV7IF_RetrunToFactorySetting(_currentDeviceId);
            AddLogResult(rc, Resources.SID_RETRUN_TO_FACTORY_SETTING);
        }

        /// <summary>
        /// "GetError" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetError_Click(object sender, EventArgs e)
        {
            using (GetErrorForm getErrorForm = new GetErrorForm())
            {
                if (DialogResult.OK == getErrorForm.ShowDialog())
                {
                    byte errCnt = 0;
                    ushort[] errCode = new ushort[Math.Max((int)getErrorForm.RcvMax, 1)];
                    using (PinnedObject pin = new PinnedObject(errCode))
                    {
                        int rc = NativeMethods.LJV7IF_GetError(_currentDeviceId, getErrorForm.RcvMax, ref errCnt, pin.Pointer);
                        AddLogResult(rc, Resources.SID_GET_ERROR);
                        if (rc == (int)Rc.Ok)
                        {
                            AddLog(string.Format(@"ErrCnt:{0}", errCnt.ToString("x")));
                            for (int i = 0; i < errCnt; i++)
                            {
                                AddLog(string.Format(@"ErrCode[{0}]:0x{1:0000}", i, errCode[i].ToString("x4")));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// "ClearError" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearError_Click(object sender, EventArgs e)
        {
            using (ClearErrorForm clearErrorForm = new ClearErrorForm())
            {
                if (DialogResult.OK == clearErrorForm.ShowDialog())
                {
                    int rc = NativeMethods.LJV7IF_ClearError(_currentDeviceId, clearErrorForm.ErrCode);
                    AddLogResult(rc, Resources.SID_CLEAR_ERROR);
                }
            }
        }
        #endregion

        #region Buttons for controlling measurements
        /// <summary>
        /// "Trigger" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrigger_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.Trigger;

            int rc = NativeMethods.LJV7IF_Trigger(_currentDeviceId);
            AddLogResult(rc, Resources.SID_TRIGGER);
        }

        /// <summary>
        /// "StartMeasure" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartMeasure_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.StartMeasure;

            int rc = NativeMethods.LJV7IF_StartMeasure(_currentDeviceId);
            AddLogResult(rc, Resources.SID_START_MEASURE);
        }

        /// <summary>
        /// "StopMeasure" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopMeasure_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.StopMeasure;

            int rc = NativeMethods.LJV7IF_StopMeasure(_currentDeviceId);
            AddLogResult(rc, Resources.SID_STOP_MEASURE);
        }

        /// <summary>
        /// "AutoZero" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoZero_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.AutoZero;

            using (OutSelectForm autoZeroForm = new OutSelectForm(true))
            {
                if (DialogResult.OK == autoZeroForm.ShowDialog())
                {
                    int rc = NativeMethods.LJV7IF_AutoZero(_currentDeviceId, autoZeroForm.OnOff, autoZeroForm.Out);
                    AddLogResult(rc, Resources.SID_AUTO_ZERO);
                }
            }
        }

        /// <summary>
        /// "Timing" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTiming_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.Timing;

            using (OutSelectForm autoZeroForm = new OutSelectForm(true))
            {
                if (DialogResult.OK == autoZeroForm.ShowDialog())
                {
                    int rc = NativeMethods.LJV7IF_Timing(_currentDeviceId, autoZeroForm.OnOff, autoZeroForm.Out);
                    AddLogResult(rc, Resources.SID_TIMING);
                }
            }
        }

        /// <summary>
        /// "Reset" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.Reset;

            using (OutSelectForm resetForm = new OutSelectForm(false))
            {
                if (DialogResult.OK == resetForm.ShowDialog())
                {
                    int rc = NativeMethods.LJV7IF_Reset(_currentDeviceId, resetForm.Out);
                    AddLogResult(rc, Resources.SID_RESET);
                }
            }
        }

        /// <summary>
        /// "ClearMemory" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearMemory_Click(object sender, EventArgs e)
        {
            int rc = NativeMethods.LJV7IF_ClearMemory(_currentDeviceId);
            AddLogResult(rc, Resources.SID_CLEAR_MEMORY);
        }
        #endregion

        #region Buttons for modifying or reading settings
        /// <summary>
        /// "SetSetting" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetSetting_Click(object sender, EventArgs e)
        {
            using (SettingForm settingForm = new SettingForm(true))
            {
                if (DialogResult.OK == settingForm.ShowDialog())
                {
                    LJV7IF_TARGET_SETTING targetSetting = settingForm.TargetSetting;
                    using (PinnedObject pin = new PinnedObject(settingForm.Data))
                    {
                        uint dwError = 0;
                        int rc = NativeMethods.LJV7IF_SetSetting(_currentDeviceId, settingForm.Depth, targetSetting,
                            pin.Pointer, (uint)settingForm.Data.Length, ref dwError);
                        // @Point
                        // # There are three setting areas: a) the write settings area, b) the running area, and c) the save area.
                        //   * Specify a) for the setting level when you want to change multiple settings. However, to reflect settings in the LJ-V operations, you have to call LJV7IF_ReflectSetting.
                        //	 * Specify b) for the setting level when you want to change one setting but you don't mind if this setting is returned to its value prior to the change when the power is turned off.
                        //	 * Specify c) for the setting level when you want to change one setting and you want this new value to be retained even when the power is turned off.

                        // @Point
                        //  As a usage example, we will show how to use SettingForm to configure settings such that sending a setting, with SettingForm using its initial values,
                        //  will change the sampling period in the running area to "100 Hz."
                        //  Also see the GetSetting function.

                        AddLogResult(rc, Resources.SID_SET_SETTING);
                        if (rc != (int)Rc.Ok)
                        {
                            AddError(dwError);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// "GetSetting" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        private void btnGetSetting_Click(object sender, EventArgs e)
        {
            using (SettingForm settingForm = new SettingForm(false))
            {
                if (DialogResult.OK == settingForm.ShowDialog())
                {
                    LJV7IF_TARGET_SETTING targetSetting = settingForm.TargetSetting;
                    byte[] data = new byte[settingForm.DataLength];
                    using (PinnedObject pin = new PinnedObject(data))
                    {
                        int rc = NativeMethods.LJV7IF_GetSetting(_currentDeviceId, settingForm.Depth, targetSetting,
                            pin.Pointer, (uint)settingForm.DataLength);
                        // @Point
                        //  We have prepared an object for reading the sampling period into the setting's initial value.
                        //  Also see the SetSetting function.

                        AddLogResult(rc, Resources.SID_GET_SETTING);
                        if (rc == (int)Rc.Ok)
                        {
                            AddLog("\t    0  1  2  3  4  5  6  7");
                            StringBuilder sb = new StringBuilder();
                            // Get data display
                            for (int i = 0; i < settingForm.DataLength; i++)
                            {
                                if ((i % 8) == 0) sb.Append(string.Format("  [0x{0:x4}] ", i));

                                sb.Append(string.Format("{0:x2} ", data[i]));
                                if (((i % 8) == 7) || (i == settingForm.DataLength - 1))
                                {
                                    AddLog(sb.ToString());
                                    sb.Remove(0, sb.Length);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// "InitializeSetting" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitializeSetting_Click(object sender, EventArgs e)
        {
            using (DepthProgramSelectForm depthProgramSelectForm = new DepthProgramSelectForm(true, true))
            {
                if (DialogResult.OK == depthProgramSelectForm.ShowDialog())
                {
                    int rc = NativeMethods.LJV7IF_InitializeSetting(_currentDeviceId, depthProgramSelectForm.Depth, depthProgramSelectForm.Target);
                    AddLogResult(rc, Resources.SID_INITIALIZE_SETTING);
                }
            }
        }

        /// <summary>
        /// "ReflectSetting" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdataSetting_Click(object sender, EventArgs e)
        {
            using (DepthProgramSelectForm depthProgramSelectForm = new DepthProgramSelectForm(true, false))
            {
                if (DialogResult.OK == depthProgramSelectForm.ShowDialog())
                {
                    uint dwError = 0;
                    int rc = NativeMethods.LJV7IF_ReflectSetting(_currentDeviceId, depthProgramSelectForm.Depth, ref dwError);

                    AddLogResult(rc, Resources.SID_UPDATA_SETTING);
                    if (rc != (int)Rc.Ok)
                    {
                        AddError(dwError);
                    }
                }
            }
        }

        /// <summary>
        /// "RewriteTemporarySetting" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRewriteTemporarySetting_Click(object sender, EventArgs e)
        {
            using (DepthProgramSelectForm depthProgramSelectForm = new DepthProgramSelectForm(true, false))
            {
                if (DialogResult.OK == depthProgramSelectForm.ShowDialog())
                {
                    int rc = NativeMethods.LJV7IF_RewriteTemporarySetting(_currentDeviceId, depthProgramSelectForm.Depth);
                    AddLogResult(rc, Resources.SID_REWRITE_TEMPORARY_SETTING);
                }
            }
        }

        /// <summary>
        /// "CheckMemoryAccess" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckMemoryAccess_Click(object sender, EventArgs e)
        {
            byte busy = 0;
            int rc = NativeMethods.LJV7IF_CheckMemoryAccess(_currentDeviceId, ref busy);
            AddLogResult(rc, Resources.SID_CHECK_MEMORY_ACCESS);
            if (rc == (int)Rc.Ok)
            {
                if (busy != 0)
                {
                    AddLog(@"Accessing the save area");
                }
                else
                {
                    AddLog(@"No access");
                }
            }
        }

        /// <summary>
        /// "SetTime" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetTime_Click(object sender, EventArgs e)
        {
            using (TimeForm timeForm = new TimeForm())
            {
                if (DialogResult.OK == timeForm.ShowDialog())
                {
                    LJV7IF_TIME time = timeForm.Time;
                    int rc = NativeMethods.LJV7IF_SetTime(_currentDeviceId, ref time);
                    AddLogResult(rc, Resources.SID_SET_TIME);
                }
            }
        }

        /// <summary>
        /// "GetTime" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetTime_Click(object sender, EventArgs e)
        {
            LJV7IF_TIME time = new LJV7IF_TIME();
            int rc = NativeMethods.LJV7IF_GetTime(_currentDeviceId, ref time);
            AddLogResult(rc, Resources.SID_GET_TIME);
            if (rc == (int)Rc.Ok)
            {
                AddLog(Utility.ConvertToLogString(time).ToString());
            }
        }

        /// <summary>
        /// "ChangeActiveProgram" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeActiveProgram_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.ChangeActiveProgram;

            using (DepthProgramSelectForm depthProgramSelectForm = new DepthProgramSelectForm(false, true))
            {
                if (DialogResult.OK == depthProgramSelectForm.ShowDialog())
                {
                    int rc = NativeMethods.LJV7IF_ChangeActiveProgram(_currentDeviceId, depthProgramSelectForm.Target);
                    AddLogResult(rc, Resources.SID_CHANGE_ACTIVE_PROGRAM);
                }
            }
        }

        /// <summary>
        /// "GetActiveProgram" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetActiveProgram_Click(object sender, EventArgs e)
        {
            byte progNo = 0;
            int rc = NativeMethods.LJV7IF_GetActiveProgram(_currentDeviceId, ref progNo);
            AddLogResult(rc, Resources.SID_GET_ACTIVE_PROGRAM);
            if (rc == (int)Rc.Ok)
            {
                AddLog(string.Format(@"ProgNo:{0}", progNo));
            }
        }
        #endregion

        #region Button for getting the measurement results
        /// <summary>
        /// "GetMeasurementValue" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetMeasurementValue_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.GetMeasurementValue;

            LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];
            int rc = NativeMethods.LJV7IF_GetMeasurementValue(_currentDeviceId, measureData);
            AddLogResult(rc, Resources.SID_GET_MEASUREMENT_VALUE);
            if (rc == (int)Rc.Ok)
            {
                _measureDatas.Clear();
                _measureDatas.Add(new MeasureData(0, measureData));

                for (int i = 0; i < NativeMethods.MeasurementDataCount; i++)
                {
                    AddLog(string.Format("  OUT{0:00}: {1}", (i + 1), Utility.ConvertToLogString(measureData[i]).ToString()));
                }
            }
        }

        /// <summary>
        /// "GetProfile" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetProfile_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.GetProfile;

            using (ProfileForm profileForm = new ProfileForm())
            {
                if (DialogResult.OK == profileForm.ShowDialog())
                {
                    _deviceData[_currentDeviceId].ProfileData.Clear();
                    _deviceData[_currentDeviceId].MeasureData.Clear();
                    LJV7IF_GET_PROFILE_REQ req = profileForm.Req;
                    LJV7IF_GET_PROFILE_RSP rsp = new LJV7IF_GET_PROFILE_RSP();
                    LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
                    uint oneProfDataBuffSize = GetOneProfileDataSize();
                    uint allProfDataBuffSize = oneProfDataBuffSize * req.byGetProfCnt;
                    int[] profileData = new int[allProfDataBuffSize / Marshal.SizeOf(typeof(int))];

                    using (PinnedObject pin = new PinnedObject(profileData))
                    {
                        int rc = NativeMethods.LJV7IF_GetProfile(_currentDeviceId, ref req, ref rsp, ref profileInfo, pin.Pointer, allProfDataBuffSize);
                        AddLogResult(rc, Resources.SID_GET_PROFILE);
                        if (rc == (int)Rc.Ok)
                        {
                            // Response data display
                            AddLog(Utility.ConvertToLogString(rsp).ToString());
                            AddLog(Utility.ConvertToLogString(profileInfo).ToString());

                            AnalyzeProfileData((int)rsp.byGetProfCnt, ref profileInfo, profileData);

                            // Profile export
                            if (DataExporter.ExportOneProfile(_deviceData[_currentDeviceId].ProfileData.ToArray(), 0, _txtboxProfileFilePath.Text))
                            {
                                AddLog(@"###Saved!!");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// "GetBatchProfile" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetBatchProfile_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.GetBatchProfile;

            using (GetBatchProfileForm getBatchProfileForm = new GetBatchProfileForm())
            {
                if (DialogResult.OK == getBatchProfileForm.ShowDialog())
                {
                    _deviceData[_currentDeviceId].ProfileData.Clear();
                    _deviceData[_currentDeviceId].MeasureData.Clear();
                    // Set the command function
                    LJV7IF_GET_BATCH_PROFILE_REQ req = getBatchProfileForm.Req;
                    LJV7IF_GET_BATCH_PROFILE_RSP rsp = new LJV7IF_GET_BATCH_PROFILE_RSP();
                    LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
                    uint oneDataSize = GetOneProfileDataSize();
                    uint allDataSize = oneDataSize * getBatchProfileForm.Req.byGetProfCnt;
                    int[] profileData = new int[allDataSize / Marshal.SizeOf(typeof(int))];

                    using (PinnedObject pin = new PinnedObject(profileData))
                    {
                        // Send the command
                        int rc = NativeMethods.LJV7IF_GetBatchProfile(_currentDeviceId, ref req, ref rsp, ref profileInfo, pin.Pointer, allDataSize);
                        // @Point
                        // # When reading all the profiles from a single batch, the specified number of profiles may not be read.
                        // # To read the remaining profiles after the first set of profiles have been read,
                        //    set the specification method (byPosMode)to 0x02, specify the batch number (dwGetBatchNo),
                        //    and then set the number to start reading profiles from (dwGetProfNo) and the number of profiles to read (byGetProfCnt) to values 
                        //    that specify a range of profiles that have not been read to read the profiles in order.
                        // # For the basic code, see "btnGetBatchProfileEx_Click."

                        // Result output
                        AddLogResult(rc, Resources.SID_GET_BATCH_PROFILE);
                        if (rc == (int)Rc.Ok)
                        {
                            // Response data display
                            AddLog(Utility.ConvertToLogString(rsp).ToString());
                            AddLog(Utility.ConvertToLogString(profileInfo).ToString());

                            AnalyzeProfileData((int)rsp.byGetProfCnt, ref profileInfo, profileData);

                            // Profile export
                            if (DataExporter.ExportOneProfile(_deviceData[_currentDeviceId].ProfileData.ToArray(), 0, _txtboxProfileFilePath.Text))
                            {
                                AddLog(@"###Saved!!");
                            }

                        }
                    }
                }
            }
        }

        /// <summary>
        /// "GetProfileAdvance" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetProfileAdvance_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.GetProfileAdvance;
            _deviceData[_currentDeviceId].ProfileData.Clear();
            _deviceData[_currentDeviceId].MeasureData.Clear();
            _measureDatas.Clear();

            // Set the command function
            LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
            uint dataSize = GetOneProfileDataSize();
            int[] profileData = new int[dataSize / Marshal.SizeOf(typeof(int))];
            LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

            using (PinnedObject pin = new PinnedObject(profileData))
            {
                // Send the command
                int rc = NativeMethods.LJV7IF_GetProfileAdvance(_currentDeviceId, ref profileInfo, pin.Pointer, dataSize, measureData);

                // Result output
                AddLogResult(rc, Resources.SID_GET_PROFILE_ADVANCE);
                if (rc == (int)Rc.Ok)
                {
                    // Response data display
                    AddLog(Utility.ConvertToLogString(profileInfo).ToString());

                    _measureDatas.Add(new MeasureData(0, measureData));
                    AnalyzeProfileData(1, ref profileInfo, profileData);
                    for (int i = 0; i < NativeMethods.MeasurementDataCount; i++)
                    {
                        AddLog(string.Format("  OUT{0:00}: {1}", (i + 1), Utility.ConvertToLogString(measureData[i]).ToString()));
                    }
                }
            }
        }

        /// <summary>
        /// "GetBatchProfileAdvance" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetBatchProfileAdvance_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.GetBatchProfileAdvance;

            using (GetBatchprofileAdvanceForm getBatchprofileAdvanceForm = new GetBatchprofileAdvanceForm())
            {
                if (DialogResult.OK == getBatchprofileAdvanceForm.ShowDialog())
                {
                    _deviceData[_currentDeviceId].ProfileData.Clear();
                    _deviceData[_currentDeviceId].MeasureData.Clear();
                    _measureDatas.Clear();

                    // Set the command function
                    LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ req = getBatchprofileAdvanceForm.Req;
                    LJV7IF_GET_BATCH_PROFILE_ADVANCE_RSP rsp = new LJV7IF_GET_BATCH_PROFILE_ADVANCE_RSP();
                    LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
                    uint oneDataSize = GetOneProfileDataSize() + (uint)Utility.GetByteSize(Utility.TypeOfStruct.MEASURE_DATA) * (uint)NativeMethods.MeasurementDataCount;
                    uint allDataSize = oneDataSize * getBatchprofileAdvanceForm.Req.byGetProfCnt;
                    int[] profileData = new int[allDataSize / Marshal.SizeOf(typeof(int))];
                    LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];
                    LJV7IF_MEASURE_DATA[] batchMeasureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

                    using (PinnedObject pin = new PinnedObject(profileData))
                    {
                        // Send the command
                        int rc = NativeMethods.LJV7IF_GetBatchProfileAdvance(_currentDeviceId, ref req, ref rsp,
                            ref profileInfo, pin.Pointer, allDataSize, batchMeasureData, measureData);
                        // @Point
                        // # When reading all the profiles from a single batch, the specified number of profiles may not be read.
                        // # To read the remaining profiles after the first set of profiles have been read,
                        //    set the specification method (byPosMode)to 0x02, specify the batch number (dwGetBatchNo),
                        //    and then set the number to start reading profiles from (dwGetProfNo) and the number of profiles to read (byGetProfCnt) to values 
                        //    that specify a range of profiles that have not been read to read the profiles in order.
                        // # For the basic code, see "btnGetBatchProfileEx_Click."

                        // Result output
                        AddLogResult(rc, Resources.SID_GET_BATCH_PROFILE_ADVANCE);
                        if (rc == (int)Rc.Ok)
                        {
                            _measureDatas.Add(new MeasureData(0, measureData));
                            AddLog(Utility.ConvertToLogString(rsp).ToString());
                            AddLog(Utility.ConvertToLogString(profileInfo).ToString());
                            for (int i = 0; i < NativeMethods.MeasurementDataCount; i++)
                            {
                                AddLog(string.Format("  OUT{0:00}: {1}", (i + 1), Utility.ConvertToLogString(measureData[i]).ToString()));
                            }

                            AnalyzeBatchData((int)rsp.byGetProfCnt, ref profileInfo, false, profileData, 0);

                            // Profile export
                            if (DataExporter.ExportOneProfile(_deviceData[_currentDeviceId].ProfileData.ToArray(), 0, _txtboxProfileFilePath.Text))
                            {
                                AddLog(@"###Saved!!");
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Button for storage-related functions
        /// <summary>
        /// "StartStorage" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartStorage_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.StartStorage;

            int rc = NativeMethods.LJV7IF_StartStorage(_currentDeviceId);
            AddLogResult(rc, Resources.SID_START_STORAGE);
        }

        /// <summary>
        /// "StopStorage" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopStorage_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.StopStorage;

            int rc = NativeMethods.LJV7IF_StopStorage(_currentDeviceId);
            AddLogResult(rc, Resources.SID_STOP_STORAGE);
        }

        /// <summary>
        /// "GetStorageStatus" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetStorageStatus_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.GetStorageStatus;

            using (GetStorageStatusForm getStorageStatusForm = new GetStorageStatusForm())
            {
                if (DialogResult.OK == getStorageStatusForm.ShowDialog())
                {
                    LJV7IF_GET_STRAGE_STATUS_REQ req = getStorageStatusForm.Req;
                    // @Point
                    // # dwReadArea is the target surface to read.
                    //   The target surface to read indicates where in the internal memory usage area to read.
                    // # The method to use in specifying dwReadArea varies depending on how internal memory is allocated.
                    //   * Double buffer
                    //      0 indicates the active surface, 1 indicates surface A, and 2 indicates surface B.
                    //   * Entire area (overwrite)
                    //      Fixed to 1
                    //   * Entire area (do not overwrite)
                    //      After a setting modification, data is saved in surfaces 1, 2, 3, and so on in order, and 0 is set as the active surface.
                    // # For details, see "9.2.9.2 Internal memory."

                    LJV7IF_GET_STRAGE_STATUS_RSP rsp = new LJV7IF_GET_STRAGE_STATUS_RSP();
                    LJV7IF_STORAGE_INFO storageInfo = new LJV7IF_STORAGE_INFO();

                    int rc = NativeMethods.LJV7IF_GetStorageStatus(_currentDeviceId, ref req, ref rsp, ref storageInfo);
                    // @Point
                    // # Terminology	
                    //  * Base time … time expressed with 32 bits (<- the time when the setting was changed)
                    //  * Accumulated date and time	 … counter value that indicates the elapsed time, in units of 10 ms, from the base time
                    // # The accumulated date and time are stored in the accumulated data.
                    // # The accumulated time of read data is calculated as shown below.
                    //   Accumulated time = "base time (stBaseTime of LJV7IF_GET_STORAGE_RSP)" + "accumulated date and time × 10 ms"

                    AddLogResult(rc, Resources.SID_GET_STORAGE_STATUS);
                    if (rc == (int)Rc.Ok)
                    {
                        // Response data display
                        AddLog(Utility.ConvertToLogString(rsp).ToString());
                        AddLog(Utility.ConvertToLogString(storageInfo).ToString());
                    }
                }
            }
        }

        /// <summary>
        /// "GetStorageData" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetStorageData_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.GetStorageData;

            using (GetStorageDataForm getStorageData = new GetStorageDataForm())
            {
                if (DialogResult.OK == getStorageData.ShowDialog())
                {
                    _measureDatas.Clear();
                    LJV7IF_GET_STORAGE_REQ req = getStorageData.Req;
                    // @Point
                    // # dwReadArea is the target surface to read.
                    //    The target surface to read indicates where in the internal memory usage area to read.
                    // # The method to use in specifying dwReadArea varies depending on how internal memory is allocated.
                    //   * Double buffer
                    //      0 indicates the active surface, 1 indicates surface A, and 2 indicates surface B.
                    //   * Entire area (overwrite)
                    //      Fixed to 1
                    //   * Entire area (do not overwrite)
                    //      After a setting modification, data is saved in surfaces 1, 2, 3, and so on in order, and 0 is set as the active surface.
                    // # For details, see "9.2.9.2 Internal memory."

                    LJV7IF_STORAGE_INFO storageInfo = new LJV7IF_STORAGE_INFO();
                    LJV7IF_GET_STORAGE_RSP rsp = new LJV7IF_GET_STORAGE_RSP();
                    uint oneDataSize = (uint)(Marshal.SizeOf(typeof(uint)) + (uint)Utility.GetByteSize(Utility.TypeOfStruct.MEASURE_DATA) * (uint)NativeMethods.MeasurementDataCount);
                    uint allDataSize = Math.Min(Define.READ_DATA_SIZE, oneDataSize * getStorageData.Req.dwDataCnt);
                    byte[] receiveData = new byte[allDataSize];
                    using (PinnedObject pin = new PinnedObject(receiveData))
                    {
                        int rc = NativeMethods.LJV7IF_GetStorageData(_currentDeviceId, ref req, ref storageInfo, ref rsp, pin.Pointer, allDataSize);
                        AddLogResult(rc, Resources.SID_GET_STORAGE_DATA);
                        // @Point
                        // # Terminology	
                        //  * Base time … time expressed with 32 bits (<- the time when the setting was changed)
                        //  * Accumulated date and time	 … counter value that indicates the elapsed time, in units of 10 ms, from the base time
                        // # The accumulated date and time are stored in the accumulated data.
                        // # The accumulated time of read data is calculated as shown below.
                        //   Accumulated time = "base time (stBaseTime of LJV7IF_GET_STORAGE_RSP)" + "accumulated date and time × 10 ms"

                        if (rc == (int)Rc.Ok)
                        {
                            // Temporarily retain the get data.
                            int byteSize = MeasureData.GetByteSize();
                            for (int i = 0; i < (int)rsp.dwDataCnt; i++)
                            {
                                _measureDatas.Add(new MeasureData(receiveData, byteSize * i));
                            }

                            // Response data display
                            AddLog(Utility.ConvertToLogString(storageInfo).ToString());
                            AddLog(Utility.ConvertToLogString(rsp).ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// "GetStorageProfile" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetStorageProfile_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.GetStorageProfile;

            using (GetStorageDataForm getStorageData = new GetStorageDataForm())
            {
                if (DialogResult.OK == getStorageData.ShowDialog())
                {
                    _deviceData[_currentDeviceId].ProfileData.Clear();
                    _deviceData[_currentDeviceId].MeasureData.Clear();
                    _measureDatas.Clear();
                    LJV7IF_GET_STORAGE_REQ req = getStorageData.Req;
                    // @Point
                    // # dwReadArea is the target surface to read.
                    //   The target surface to read indicates where in the internal memory usage area to read.
                    // # The method to use in specifying dwReadArea varies depending on how internal memory is allocated.
                    //   * Double buffer
                    //      0 indicates the active surface, 1 indicates surface A, and 2 indicates surface B.
                    //   * Entire area (overwrite)
                    //      Fixed to 1
                    //   * Entire area (do not overwrite)
                    //      After a setting modification, data is saved in surfaces 1, 2, 3, and so on in order, and 0 is set as the active surface.
                    // # For details, see "9.2.9.2 Internal memory."

                    LJV7IF_STORAGE_INFO storageInfo = new LJV7IF_STORAGE_INFO();
                    LJV7IF_GET_STORAGE_RSP rsp = new LJV7IF_GET_STORAGE_RSP();
                    LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();

                    uint oneDataSize = (uint)(Marshal.SizeOf(typeof(uint)) + (uint)Utility.GetByteSize(Utility.TypeOfStruct.MEASURE_DATA)
                        * (uint)NativeMethods.MeasurementDataCount * 2 + GetOneProfileDataSize());
                    uint allDataSize = Math.Min(Define.READ_DATA_SIZE, oneDataSize * getStorageData.Req.dwDataCnt);
                    byte[] receiveData = new byte[allDataSize];
                    using (PinnedObject pin = new PinnedObject(receiveData))
                    {
                        int rc = NativeMethods.LJV7IF_GetStorageProfile(_currentDeviceId, ref req, ref storageInfo, ref rsp, ref profileInfo, pin.Pointer, allDataSize);
                        // @Point
                        // # Terminology	
                        //  * Base time … time expressed with 32 bits (<- the time when the setting was changed)
                        //  * Accumulated date and time	 … counter value that indicates the elapsed time, in units of 10 ms, from the base time
                        // # The accumulated date and time are stored in the accumulated data.
                        // # The accumulated time of read data is calculated as shown below.
                        //   Accumulated time = "base time (stBaseTime of LJV7IF_GET_STORAGE_RSP)" + "accumulated date and time × 10 ms"

                        // @Point
                        // # When reading multiple profiles, the specified number of profiles may not be read.
                        // # To read the remaining profiles after the first set of profiles have been read,
                        //   set the number to start reading profiles from (dwStartNo) and the number of profiles to read (byDataCnt) 
                        //   to values that specify a range of profiles that have not been read to read the profiles in order.
                        // # For the basic code, see "btnGetBatchProfileEx_Click."

                        AddLogResult(rc, Resources.SID_GET_STORAGE_PROFILE);
                        if (rc == (int)Rc.Ok)
                        {
                            // Temporarily retain the get data.
                            int measureDataSize = MeasureData.GetByteSize();
                            int profileDataSize = ProfileData.CalculateDataSize(profileInfo) * Marshal.SizeOf(typeof(int));
                            int profileMeasureDataSize = Utility.GetByteSize(Utility.TypeOfStruct.MEASURE_DATA) * NativeMethods.MeasurementDataCount;
                            int byteSize = measureDataSize + profileDataSize + profileMeasureDataSize;
                            byte[] tempRecvieMeasureData = new byte[profileMeasureDataSize];

                            for (int i = 0; i < (int)rsp.dwDataCnt; i++)
                            {
                                _measureDatas.Add(new MeasureData(receiveData, byteSize * i));
                                _deviceData[_currentDeviceId].ProfileData.Add(new ProfileData(receiveData, (measureDataSize + byteSize * i), profileInfo));
                                Buffer.BlockCopy(receiveData, (measureDataSize + profileDataSize + byteSize * i), tempRecvieMeasureData, 0, profileMeasureDataSize);
                                _deviceData[_currentDeviceId].MeasureData.Add(new MeasureData(tempRecvieMeasureData));
                            }

                            // Response data display
                            AddLog(Utility.ConvertToLogString(storageInfo).ToString());
                            AddLog(Utility.ConvertToLogString(rsp).ToString());
                            AddLog(Utility.ConvertToLogString(profileInfo).ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// "GetStorageBatchProfile" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetStorageBatchProfile_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.GetStorageBatchProfile;

            using (GetStorageBatchProfileForm getStorageBatchProfileForm = new GetStorageBatchProfileForm())
            {
                if (DialogResult.OK == getStorageBatchProfileForm.ShowDialog())
                {
                    _deviceData[_currentDeviceId].ProfileData.Clear();
                    _deviceData[_currentDeviceId].MeasureData.Clear();
                    _measureDatas.Clear();
                    // Set the function data
                    LJV7IF_GET_BATCH_PROFILE_STORAGE_REQ req = getStorageBatchProfileForm.Req;
                    LJV7IF_STORAGE_INFO storageInfo = new LJV7IF_STORAGE_INFO();
                    LJV7IF_GET_BATCH_PROFILE_STORAGE_RSP rsp = new LJV7IF_GET_BATCH_PROFILE_STORAGE_RSP();
                    LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
                    uint oneDataSize = GetOneProfileDataSize() + (uint)(Utility.GetByteSize(Utility.TypeOfStruct.MEASURE_DATA) * (uint)NativeMethods.MeasurementDataCount);
                    uint allDataSize = oneDataSize * getStorageBatchProfileForm.Req.byGetProfCnt;
                    LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];
                    int[] profileData = new int[allDataSize / Marshal.SizeOf(typeof(int))];
                    uint offsetTime = 0;

                    using (PinnedObject pin = new PinnedObject(profileData))
                    {
                        // Send the command
                        int rc = NativeMethods.LJV7IF_GetStorageBatchProfile(_currentDeviceId, ref req, ref storageInfo,
                            ref rsp, ref profileInfo, pin.Pointer, allDataSize, ref offsetTime, measureData);
                        // @Point
                        // # Terminology	
                        //  * Base time … time expressed with 32 bits (<- the time when the setting was changed)
                        //  * Accumulated date and time	 … counter value that indicates the elapsed time, in units of 10 ms, from the base time
                        // # The accumulated date and time are stored in the accumulated data.
                        // # The accumulated time of read data is calculated as shown below.
                        //   Accumulated time = "base time (stBaseTime of LJV7IF_GET_STORAGE_RSP)" + "accumulated date and time × 10 ms"

                        // @Point
                        // # When reading all the profiles from a single batch, the specified number of profiles may not be read.	
                        // # To read the remaining profiles after the first set of profiles have been read, 
                        //   specify the batch number (dwGetBatchNo), and then set the number to start reading profiles 
                        //   from (dwGetTopProfNo) and the number of profiles to read (byGetProfCnt) to values 
                        //   that specify a range of profiles that have not been read to read the profiles in order.
                        // # For the basic code, see "btnGetBatchProfileEx_Click."

                        // Result output
                        AddLogResult(rc, Resources.SID_GET_STORAGE_BATCH_PROFILE);
                        if (rc == (int)Rc.Ok)
                        {
                            AnalyzeBatchData((int)rsp.byGetProfCnt, ref profileInfo, false, profileData, 0);

                            _measureDatas.Add(new MeasureData(offsetTime, measureData));
                            // Response data display
                            AddLog(Utility.ConvertToLogString(storageInfo).ToString());
                            AddLog(Utility.ConvertToLogString(rsp).ToString());
                            AddLog(Utility.ConvertToLogString(profileInfo).ToString());
                            AddLog(string.Format(@"offsetTime	:{0}", offsetTime));
                        }
                    }
                }
            }
        }
        #endregion

        #region Buttons related to high-speed data communication
        /// <summary>
        /// "HighSpeedDataUsbCommunicationInitalize" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHighSpeedDataUsbCommunicationInitalize_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.HighSpeedDataUsbCommunicationInitalize;

            using (HighSpeedInitalizeForm highSpeedInitalizeForm = new HighSpeedInitalizeForm(false))
            {
                if (DialogResult.OK == highSpeedInitalizeForm.ShowDialog())
                {
                    _deviceData[_currentDeviceId].ProfileData.Clear();  // Clear the retained profile data.
                    _deviceData[_currentDeviceId].MeasureData.Clear();

                    int rc = NativeMethods.LJV7IF_HighSpeedDataUsbCommunicationInitalize(_currentDeviceId,
                        (_chkOnlyProfileCount.Checked ? _callbackOnlyCount : _callback),
                        highSpeedInitalizeForm.ProfileCnt, (uint)_currentDeviceId);
                    // @Point
                    // # When the frequency of calls is low, the callback function may not be called once per specified number of profiles.
                    // # The callback function is called when both of the following conditions are met.
                    //   * There is one packet of received data.
                    //   * The specified number of profiles have been received by the time the call frequency has been met.

                    AddLogResult(rc, Resources.SID_HIGH_SPEED_DATA_USB_COMMUNICATION_INITALIZE);

                    if (rc == (int)Rc.Ok) _deviceData[_currentDeviceId].Status = DeviceStatus.UsbFast;
                    _deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
                }
            }
        }

        /// <summary>
        /// "HighSpeedDataEthernetCommunicationInitalize" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHighSpeedDataEthernetCommunicationInitalize_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.HighSpeedDataEthernetCommunicationInitalize;

            using (HighSpeedInitalizeForm highSpeedInitalizeForm = new HighSpeedInitalizeForm(true))
            {
                highSpeedInitalizeForm.EthernetConfig = _deviceData[_currentDeviceId].EthernetConfig;

                if (DialogResult.OK == highSpeedInitalizeForm.ShowDialog())
                {
                    _deviceData[_currentDeviceId].ProfileData.Clear();  //Clear the retained profile data.
                    _deviceData[_currentDeviceId].MeasureData.Clear();

                    LJV7IF_ETHERNET_CONFIG ethernetConfig = highSpeedInitalizeForm.EthernetConfig;
                    int rc = NativeMethods.LJV7IF_HighSpeedDataEthernetCommunicationInitalize(_currentDeviceId, ref ethernetConfig,
                        highSpeedInitalizeForm.HighSpeedPortNo, (_chkOnlyProfileCount.Checked ? _callbackOnlyCount : _callback),
                        highSpeedInitalizeForm.ProfileCnt, (uint)_currentDeviceId);
                    // @Point
                    // # When the frequency of calls is low, the callback function may not be called once per specified number of profiles.
                    // # The callback function is called when both of the following conditions are met.
                    //   * There is one packet of received data.
                    //   * The specified number of profiles have been received by the time the call frequency has been met.

                    AddLogResult(rc, Resources.SID_HIGH_SPEED_DATA_ETHERNET_COMMUNICATION_INITALIZE);

                    if (rc == (int)Rc.Ok)
                    {
                        _deviceData[_currentDeviceId].Status = DeviceStatus.EthernetFast;
                        _deviceData[_currentDeviceId].EthernetConfig = ethernetConfig;
                    }
                    _deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();

                }
            }
        }

        /// <summary>
        /// "PreStartHighSpeedDataCommunication" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreStartHighSpeedDataCommunication_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.PreStartHighSpeedDataCommunication;

            using (PreStartHighSpeedForm preStartHighSpeedForm = new PreStartHighSpeedForm())
            {
                if (DialogResult.OK == preStartHighSpeedForm.ShowDialog())
                {
                    LJV7IF_HIGH_SPEED_PRE_START_REQ req = preStartHighSpeedForm.Req;
                    // @Point
                    // # SendPos is used to specify which profile to start sending data from during high-speed communication.
                    // # When "Overwrite" is specified for the operation when memory full and 
                    //   "0: From previous send complete position" is specified for the send start position,
                    //    if the LJ-V continues to accumulate profiles, the LJ-V memory will become full,
                    //    and the profile at the previous send complete position will be overwritten with a new profile.
                    //    In this situation, because the profile at the previous send complete position is not saved, an error will occur.

                    LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();

                    int rc = NativeMethods.LJV7IF_PreStartHighSpeedDataCommunication(_currentDeviceId, ref req, ref profileInfo);
                    AddLogResult(rc, Resources.SID_PRE_START_HIGH_SPEED_DATA_COMMUNICATION);
                    if (rc == (int)Rc.Ok)
                    {
                        // Response data display
                        AddLog(Utility.ConvertToLogString(profileInfo).ToString());
                        _profileInfo[_currentDeviceId] = profileInfo;
                    }
                }
            }
        }

        /// <summary>
        /// "StartHighSpeedDataCommunication" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartHighSpeedDataCommunication_Click(object sender, EventArgs e)
        {
            _sendCommand = SendCommand.StartHighSpeedDataCommunication;

            ThreadSafeBuffer.ClearBuffer(_currentDeviceId);
            _receivedProfileCountLabels[_currentDeviceId].Text = "0";
            int rc = NativeMethods.LJV7IF_StartHighSpeedDataCommunication(_currentDeviceId);
            // @Point
            //  If the LJ-V does not measure the profile for 30 seconds from the start of transmission,
            //  "0x00000008" is stored in dwNotify of the callback function.

            AddLogResult(rc, Resources.SID_START_HIGH_SPEED_DATA_COMMUNICATION);
        }

        /// <summary>
        /// "StopHighSpeedDataCommunication" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopHighSpeedDataCommunication_Click(object sender, EventArgs e)
        {
            int rc = NativeMethods.LJV7IF_StopHighSpeedDataCommunication(_currentDeviceId);
            AddLogResult(rc, Resources.SID_STOP_HIGH_SPEED_DATA_COMMUNICATION);
        }

        /// <summary>
        /// "HighSpeedDataCommunicationFinalize" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHighSpeedDataCommunicationFinalize_Click(object sender, EventArgs e)
        {
            int rc = NativeMethods.LJV7IF_HighSpeedDataCommunicationFinalize(_currentDeviceId);
            AddLogResult(rc, Resources.SID_HIGH_SPEED_DATA_COMMUNICATION_FINALIZE);

            switch (_deviceData[_currentDeviceId].Status)
            {
                case DeviceStatus.UsbFast:
                    _deviceData[_currentDeviceId].Status = DeviceStatus.Usb;
                    break;
                case DeviceStatus.EthernetFast:
                    LJV7IF_ETHERNET_CONFIG config = _deviceData[_currentDeviceId].EthernetConfig;
                    _deviceData[_currentDeviceId].Status = DeviceStatus.Ethernet;
                    _deviceData[_currentDeviceId].EthernetConfig = config;
                    break;
                default:
                    break;
            }
            _deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();

        }
        #endregion

        #region Button for settings / results

        /// <summary>
        /// "Clear the log" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogClear_Click(object sender, EventArgs e)
        {
            _txtboxLog.Clear();
        }

        /// <summary>
        /// "..." button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProfileFileSave_Click(object sender, EventArgs e)
        {
            if (_profileFileSave.ShowDialog(this) == DialogResult.Cancel) return;
            _txtboxProfileFilePath.Text = _profileFileSave.FileName;
            _txtboxProfileFilePath.SelectionStart = _txtboxProfileFilePath.Text.Length;
        }

        /// <summary>
        /// "Save the profile" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int profileNo = (int)_nudProfileNo.Value;
            if (profileNo >= _deviceData[_currentDeviceId].ProfileData.Count)
            {
                AddLog("There is no profile specified.");
                return;
            }

            if (DataExporter.ExportOneProfile(_deviceData[_currentDeviceId].ProfileData.ToArray(), profileNo, _txtboxProfileFilePath.Text))
            {
                AddLog("Saved");
            }
        }

        /// <summary>
        /// "Save the measurement value" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveMeasureData_Click(object sender, EventArgs e)
        {
            DataExporter.ExportMeasureData(_measureDatas.ToArray(), _txtboxProfileFilePath.Text);
            DataExporter.ExportMeasureData(_deviceData[_currentDeviceId].MeasureData.ToArray(), _txtboxProfileFilePath.Text + "2.txt");
        }
        #endregion

        #region Other event handlers
        /// <summary>
        /// "ID" option button (also known as a radio button) event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _rdDevice_CheckedChanged(object sender, EventArgs e)
        {
            _currentDeviceId = GetSelectedDeviceId();
        }

        /// <summary>
        /// Event handler for the timer used during high-speed communication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timerHighSpeedReceive_Tick(object sender, EventArgs e)
        {
            int count = 0;
            uint notify = 0;
            int batchNo = 0;
            for (int i = 0; i < NativeMethods.DeviceCount; i++)
            {
                if (_chkOnlyProfileCount.Checked)
                {
                    _receivedProfileCountLabels[i].Text = ThreadSafeBuffer.GetCount(i, out notify, out batchNo).ToString();
                }
                else
                {
                    List<int[]> data = ThreadSafeBuffer.Get(i, out notify, out batchNo);
                    if (data.Count == 0) continue;

                    foreach (int[] profile in data)
                    {
                        if (_deviceData[i].ProfileData.Count < Define.WRITE_DATA_SIZE)
                        {
                            _deviceData[i].ProfileData.Add(new ProfileData(profile, _profileInfo[i]));
                        }
                        count++;
                    }
                    _receivedProfileCountLabels[i].Text = (Convert.ToInt32(_receivedProfileCountLabels[i].Text) + count).ToString();
                }

                if (notify != 0)
                {
                    AddLog(string.Format("  notify[{0}] = {1,0:x8}\tbatch[{0}] = {2}", i, notify, batchNo));
                }
            }

        }

        /// <summary>
        /// "Timer start check box" event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _chkStartTimer_CheckedChanged(object sender, EventArgs e)
        {
            bool isStart = _chkStartTimer.Checked;
            if (isStart)
            {
                _timerHighSpeedReceive.Interval = (int)_numInterval.Value;
                _timerHighSpeedReceive.Start();
            }
            else
            {
                _timerHighSpeedReceive.Stop();
            }
            _numInterval.Enabled = !isStart;
            _chkOnlyProfileCount.Enabled = !isStart;
        }

        #endregion

        #endregion

        #region Event handler(for combination-function)

        #region Initialization and Exit event handler
        /// <summary>
        /// "Communication establishment" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Initialize the DLL, and then establish a USB or Ethernet communication path.</remarks>
        private void btnEstablishCommunicationEx_Click(object sender, EventArgs e)
        {
            Rc rc = Rc.Ok;
            // Initialize the DLL
            rc = (Rc)NativeMethods.LJV7IF_Initialize();
            if (!CheckReturnCode(rc)) return;

            // Open the communication path
            if (_rdUsb.Checked && radioButton3.Checked)
            {
                rc = (Rc)NativeMethods.LJV7IF_UsbOpen(Define.DEVICE_ID);
            }
            else
            {
                // Generate the settings for Ethernet communication.
                try
                {
                    _ethernetConfig.abyIpAddress = new byte[] {
                        Convert.ToByte(_txtIpFirstSegment.Text),
                        Convert.ToByte(_txtIpSecondSegment.Text),
                        Convert.ToByte(_txtIpThirdSegment.Text),
                        Convert.ToByte(_txtIpFourthSegment.Text),

                    };
                    _ethernetConfig.wPortNo = Convert.ToUInt16(_txtCommandPort.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                    return;
                }

                rc = (Rc)NativeMethods.LJV7IF_EthernetOpen(Define.DEVICE_ID, ref _ethernetConfig);
            }
            if (!CheckReturnCode(rc)) return;
        }

        /// <summary>
        /// "Communication finalization" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Processing of the finalization of communication with the controller</remarks>
        private void btnTerminateCommunicationEx_Click(object sender, EventArgs e)
        {
            Rc rc = Rc.Ok;
            // Close the communication
            rc = (Rc)NativeMethods.LJV7IF_CommClose(Define.DEVICE_ID);
            if (!CheckReturnCode(rc)) return;

            // Finalize the DLL
            rc = (Rc)NativeMethods.LJV7IF_Finalize();
            if (!CheckReturnCode(rc)) return;
        }

        /// <summary>
        /// When the "Ethernet" option button (also known as a radio button) is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _rdEthernet_CheckedChanged(object sender, EventArgs e)
        {
            _grpEthernetSetting.Enabled = _rdEthernet.Checked;
        }

        #endregion

        #region Get measurement results event handler
        /// <summary>
        /// "Get current values" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Get the latest measurement values of OUT1 to OUT16.</remarks>
        private void btnGetMeasureValueEx_Click(object sender, EventArgs e)
        {
            LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];
            Rc rc = (Rc)NativeMethods.LJV7IF_GetMeasurementValue(Define.DEVICE_ID, measureData);
            Console.WriteLine(rc.ToString());
            if (!CheckReturnCode(rc)) return;
            MeasureData data = new MeasureData(measureData);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < NativeMethods.MeasurementDataCount; i++)
            {
                sb.Append(string.Format("OUT {0:d2}:\t{1,0:f4}\r\n", (i + 1), measureData[i].fValue));
            }

            _txtMeasureData.Text = sb.ToString();
        }

        /// <summary>
        /// Browse ("...") button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReferenceSavePathEx_Click(object sender, EventArgs e)
        {
            if (_profileFileSave.ShowDialog() != DialogResult.OK) return;
            _txtSavePath.Text = _profileFileSave.FileName;
        }

        /// <summary>
        /// "Get high-speed mode profiles" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Get profiles in high-speed mode, and then output profile data to file.
        /// </remarks>
        private void btnGetProfileEx_Click(object sender, EventArgs e)
        {
            LJV7IF_GET_PROFILE_REQ req = new LJV7IF_GET_PROFILE_REQ();
            req.byTargetBank = (byte)ProfileBank.Active;
            req.byPosMode = (byte)ProfilePos.Current;
            req.dwGetProfNo = 0;
            req.byGetProfCnt = 10;
            req.byErase = 0;

            LJV7IF_GET_PROFILE_RSP rsp = new LJV7IF_GET_PROFILE_RSP();
            LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();

            int profileDataSize = Define.MAX_PROFILE_COUNT +
                (Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / Marshal.SizeOf(typeof(int));
            int[] receiveBuffer = new int[profileDataSize * req.byGetProfCnt];

            using (ProgressForm progressForm = new ProgressForm())
            {
                Cursor.Current = Cursors.WaitCursor;

                progressForm.Status = Status.Communicating;
                progressForm.Show(this);
                progressForm.Refresh();

                // Get profiles.
                using (PinnedObject pin = new PinnedObject(receiveBuffer))
                {
                    Rc rc = (Rc)NativeMethods.LJV7IF_GetProfile(Define.DEVICE_ID, ref req, ref rsp, ref profileInfo, pin.Pointer,
                        (uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))));
                    if (!CheckReturnCode(rc)) return;
                }

                // Output the data of each profile
                List<ProfileData> profileDatas = new List<ProfileData>();
                int unitSize = ProfileData.CalculateDataSize(profileInfo);
                for (int i = 0; i < rsp.byGetProfCnt; i++)
                {
                    profileDatas.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
                }

                progressForm.Status = Status.Saving;
                progressForm.Refresh();

                // Save the file
                SaveProfile(profileDatas, _txtSavePath.Text);
            }
        }

        /// <summary>
        /// "Get high-speed mode batch profiles" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Read one batch worth of committed profiles that have been acquired with batch measurement in high-speed mode.
        /// </remarks>
        private void btnGetBatchProfileEx_Click(object sender, EventArgs e)
        {
            // Specify the target batch to get.
            LJV7IF_GET_BATCH_PROFILE_REQ req = new LJV7IF_GET_BATCH_PROFILE_REQ();
            req.byTargetBank = (byte)ProfileBank.Active;
            req.byPosMode = (byte)BatchPos.Commited;
            req.dwGetBatchNo = 0;
            req.dwGetProfNo = 0;
            req.byGetProfCnt = byte.MaxValue;
            req.byErase = 0;

            LJV7IF_GET_BATCH_PROFILE_RSP rsp = new LJV7IF_GET_BATCH_PROFILE_RSP();
            LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();

            int profileDataSize = Define.MAX_PROFILE_COUNT +
                (Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / Marshal.SizeOf(typeof(int));
            int[] receiveBuffer = new int[profileDataSize * req.byGetProfCnt];

            using (ProgressForm progressForm = new ProgressForm())
            {
                Cursor.Current = Cursors.WaitCursor;

                progressForm.Status = Status.Communicating;
                progressForm.Show(this);
                progressForm.Refresh();

                List<ProfileData> profileDatas = new List<ProfileData>();
                // Get profiles
                using (PinnedObject pin = new PinnedObject(receiveBuffer))
                {
                    Rc rc = (Rc)NativeMethods.LJV7IF_GetBatchProfile(Define.DEVICE_ID, ref req, ref rsp, ref profileInfo, pin.Pointer,
                        (uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))));
                    // @Point
                    // # When reading all the profiles from a single batch, the specified number of profiles may not be read.
                    // # To read the remaining profiles after the first set of profiles have been read, set the specification method (byPosMode)to 0x02, 
                    //   specify the batch number (dwGetBatchNo), and then set the number to start reading profiles from (dwGetProfNo) and 
                    //   the number of profiles to read (byGetProfCnt) to values that specify a range of profiles that have not been read to read the profiles in order.
                    // # In more detail, this process entails:
                    //   * First configure req as listed below and call this function again.
                    //      byPosMode = LJV7IF_BATCH_POS_SPEC
                    //      dwGetBatchNo = batch number that was read
                    //      byGetProfCnt = Profile number of unread in the batch
                    //   * Furthermore, if all profiles in the batch are not read,update the starting position for reading profiles (req.dwGetProfNo) and
                    //     the number of profiles to read (req.byGetProfCnt), and then call LJV7IF_GetBatchProfile again. (Repeat this process until all the profiles have been read.)

                    if (!CheckReturnCode(rc)) return;

                    // Output the data of each profile
                    int unitSize = ProfileData.CalculateDataSize(profileInfo);
                    for (int i = 0; i < rsp.byGetProfCnt; i++)
                    {
                        profileDatas.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
                    }

                    // Get all profiles within the batch.
                    req.byPosMode = (byte)BatchPos.Spec;
                    req.dwGetBatchNo = rsp.dwGetBatchNo;
                    do
                    {
                        // Update the get profile position
                        req.dwGetProfNo = rsp.dwGetBatchTopProfNo + rsp.byGetProfCnt;
                        req.byGetProfCnt = (byte)Math.Min((uint)(byte.MaxValue), (rsp.dwCurrentBatchProfCnt - req.dwGetProfNo));

                        rc = (Rc)NativeMethods.LJV7IF_GetBatchProfile(Define.DEVICE_ID, ref req, ref rsp, ref profileInfo, pin.Pointer,
                            (uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))));
                        if (!CheckReturnCode(rc)) return;
                        for (int i = 0; i < rsp.byGetProfCnt; i++)
                        {
                            profileDatas.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
                        }
                    } while (rsp.dwGetBatchProfCnt != (rsp.dwGetBatchTopProfNo + rsp.byGetProfCnt));
                }

                progressForm.Status = Status.Saving;
                progressForm.Refresh();
                // Save the file
                SaveProfile(profileDatas, _txtSavePath.Text);
            }
        }

        /// <summary>
        /// "Get advanced mode profiles" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Get profiles in advanced mode, and then output profile data to file.
        /// </remarks>
        private void btnGetProfileAdvanceEx_Click(object sender, EventArgs e)
        {
            LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
            LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];         // OUT1 to OUT16 measurement value

            int profileDataSize = Define.MAX_PROFILE_COUNT +
                (Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / Marshal.SizeOf(typeof(int));
            int[] receiveBuffer = new int[profileDataSize];  // 3,207 (total of the header, the footer, and the 3,200 data entries)

            using (PinnedObject pin = new PinnedObject(receiveBuffer))
            {
                Rc rc = (Rc)NativeMethods.LJV7IF_GetProfileAdvance(Define.DEVICE_ID, ref profileInfo, pin.Pointer,
                (uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))), measureData);

                if (!CheckReturnCode(rc)) return;
            }

            List<ProfileData> profileDatas = new List<ProfileData>();
            // Output the data of each profile
            profileDatas.Add(new ProfileData(receiveBuffer, 0, profileInfo));

            // Save the file
            SaveProfile(profileDatas, _txtSavePath.Text);
        }

        /// <summary>
        /// "Get advanced mode batch profiles" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Read one batch worth of committed profiles that have been acquired with batch measurement in advanced mode.
        /// </remarks>
        private void btnGetBatchProfileAdvanceEx_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We will start Advanced mode get batch profiles.");
            LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ req = new LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ();    // Get request structure
            req.byPosMode = (byte)BatchPos.Commited;
            req.dwGetBatchNo = 0;
            req.dwGetProfNo = 0;
            req.byGetProfCnt = byte.MaxValue;

            LJV7IF_GET_BATCH_PROFILE_ADVANCE_RSP rsp = new LJV7IF_GET_BATCH_PROFILE_ADVANCE_RSP();
            LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
            LJV7IF_MEASURE_DATA[] batchMeasureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];
            LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

            int profileDataSize = Define.MAX_PROFILE_COUNT +
                (Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / Marshal.SizeOf(typeof(int));
            int measureDataSize = Marshal.SizeOf(typeof(LJV7IF_MEASURE_DATA)) * NativeMethods.MeasurementDataCount / Marshal.SizeOf(typeof(int));
            int[] receiveBuffer = new int[(profileDataSize + measureDataSize) * req.byGetProfCnt];

            using (ProgressForm progressForm = new ProgressForm())
            {
                Cursor.Current = Cursors.WaitCursor;
                progressForm.Status = Status.Communicating;
                progressForm.Show(this);
                progressForm.Refresh();

                List<ProfileData> profileDatas = new List<ProfileData>();
                // Get profiles.
                using (PinnedObject pin = new PinnedObject(receiveBuffer))
                {
                    Rc rc = (Rc)NativeMethods.LJV7IF_GetBatchProfileAdvance(Define.DEVICE_ID, ref req, ref rsp, ref profileInfo, pin.Pointer,
                        (uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))), batchMeasureData, measureData);
                    // @Point
                    // # When reading all the profiles from a single batch, the specified number of profiles may not be read.
                    // # To read the remaining profiles after the first set of profiles have been read, set the specification method (byPosMode)to 0x02, 
                    //  specify the batch number (dwGetBatchNo), and then set the number to start reading profiles from (dwGetProfNo) and 
                    //  the number of profiles to read (byGetProfCnt) to values that specify a range of profiles that have not been read to read the profiles in order.
                    // # In more detail, this process entails:
                    //  * First configure req as listed below and call this function again.
                    //     byPosMode = LJV7IF_BATCH_POS_SPEC
                    //     dwGetBatchNo = batch number that was read
                    //     byGetProfCnt = Profile number of unread in the batch
                    //  * Furthermore, if all profiles in the batch are not read,update the starting position for reading profiles (req.dwGetProfNo) and
                    //	  the number of profiles to read (req.byGetProfCnt), and then call LJV7IF_GetBatchProfile again. (Repeat this process until all the profiles have been read.)

                    if (!CheckReturnCode(rc)) return;

                    // Output the data of each profile
                    int unitSize = ProfileData.CalculateDataSize(profileInfo) + measureDataSize;
                    for (int i = 0; i < rsp.byGetProfCnt; i++)
                    {
                        profileDatas.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
                    }

                    // Get all profiles within the batch.
                    req.byPosMode = (byte)BatchPos.Spec;
                    req.dwGetBatchNo = rsp.dwGetBatchNo;
                    do
                    {
                        // Update the get profile position
                        req.dwGetProfNo = rsp.dwGetBatchTopProfNo + rsp.byGetProfCnt;
                        req.byGetProfCnt = (byte)Math.Min((uint)(byte.MaxValue), (rsp.dwGetBatchProfCnt - req.dwGetProfNo));

                        rc = (Rc)NativeMethods.LJV7IF_GetBatchProfileAdvance(Define.DEVICE_ID, ref req, ref rsp, ref profileInfo, pin.Pointer,
                            (uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))), batchMeasureData, measureData);
                        if (!CheckReturnCode(rc)) return;
                        for (int i = 0; i < rsp.byGetProfCnt; i++)
                        {
                            profileDatas.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
                        }
                    } while (rsp.dwGetBatchProfCnt != (rsp.dwGetBatchTopProfNo + rsp.byGetProfCnt));
                }

                progressForm.Status = Status.Saving;
                progressForm.Refresh();

                // Save the file
                SaveProfile(profileDatas, _txtSavePath.Text);
            }
        }

        #endregion

        #region High-speed data communication event handler
        /// <summary>
        /// High-speed data communication "Start" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Perform the preparations for starting high-speed data communication, and then start high-speed data communication.</remarks>
        private void btnBeginHighSpeedCommunicationEx_Click(object sender, EventArgs e)
        {
            // Stop and finalize high-speed data communication.
            NativeMethods.LJV7IF_StopHighSpeedDataCommunication(Define.DEVICE_ID);
            NativeMethods.LJV7IF_HighSpeedDataCommunicationFinalize(Define.DEVICE_ID);

            // Initialize the data.
            ThreadSafeBuffer.Clear(Define.DEVICE_ID);
            Rc rc = Rc.Ok;

            // Initialize the high-speed communication path
            // High-speed communication start preparations
            LJV7IF_HIGH_SPEED_PRE_START_REQ req = new LJV7IF_HIGH_SPEED_PRE_START_REQ();
            try
            {
                uint frequency = Convert.ToUInt32(_txtCallbackFrequency.Text);
                uint threadId = (uint)Define.DEVICE_ID;

                if (_rdUsb.Checked)
                {
                    // Initialize USB high-speed data communication
                    rc = (Rc)NativeMethods.LJV7IF_HighSpeedDataUsbCommunicationInitalize(Define.DEVICE_ID, _callback, frequency, threadId);
                }
                else
                {
                    // Generate the settings for Ethernet communication.
                    ushort highSpeedPort = 0;
                    _ethernetConfig.abyIpAddress = new byte[] {
                        Convert.ToByte(_txtIpFirstSegment.Text),
                        Convert.ToByte(_txtIpSecondSegment.Text),
                        Convert.ToByte(_txtIpThirdSegment.Text),
                        Convert.ToByte(_txtIpFourthSegment.Text)
                    };
                    _ethernetConfig.wPortNo = Convert.ToUInt16(_txtCommandPort.Text);
                    highSpeedPort = Convert.ToUInt16(_txtHighSpeedPort.Text);

                    // Initialize Ethernet high-speed data communication
                    rc = (Rc)NativeMethods.LJV7IF_HighSpeedDataEthernetCommunicationInitalize(Define.DEVICE_ID, ref _ethernetConfig,
                        highSpeedPort, _callback, frequency, threadId);
                }
                if (!CheckReturnCode(rc)) return;
                req.bySendPos = Convert.ToByte(_txtStartProfileNo.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }

            // High-speed data communication start preparations
            LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
            rc = (Rc)NativeMethods.LJV7IF_PreStartHighSpeedDataCommunication(Define.DEVICE_ID, ref req, ref profileInfo);
            if (!CheckReturnCode(rc)) return;

            // Start high-speed data communication.
            rc = (Rc)NativeMethods.LJV7IF_StartHighSpeedDataCommunication(Define.DEVICE_ID);
            if (!CheckReturnCode(rc)) return;

            _lblReceiveProfileCount.Text = "0";
            _timerHighSpeed.Start();
        }

        /// <summary>
        /// High-speed data communication "Exit" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Stop high-speed data communication and perform high-speed data communication finalization processing.</remarks>
        private void btnEndHighSpeedDataCommunicationEx_Click(object sender, EventArgs e)
        {
            // Stop high-speed data communication.
            Rc rc = (Rc)NativeMethods.LJV7IF_StopHighSpeedDataCommunication(Define.DEVICE_ID);
            if (CheckReturnCode(rc))
            {
                // Finalize high-speed data communication.
                rc = (Rc)NativeMethods.LJV7IF_HighSpeedDataCommunicationFinalize(Define.DEVICE_ID);
                CheckReturnCode(rc);
            }
        }

        /// <summary>
        /// Timer event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timerHighSpeed_Tick(object sender, EventArgs e)
        {
            uint notify = 0;
            int batcnNo = 0;
            List<int[]> data = ThreadSafeBuffer.Get(Define.DEVICE_ID, out notify, out batcnNo);

            uint count = 0;
            foreach (int[] profile in data)
            {
                // Process received data here
                count++;
            }
            _lblReceiveProfileCount.Text = (Convert.ToUInt32(_lblReceiveProfileCount.Text) + count).ToString();

            if ((notify & 0xFFFF) != 0)
            {
                // If the lower 16 bits of the notification are not 0, high-speed communication was interrupted, so stop the timer.
                _timerHighSpeed.Stop();
                MessageBox.Show(string.Format("Finalize communication.0x{0:x8}", notify));
            }

            if ((notify & 0x10000) != 0)
            {
                // A descriptor is included here if processing when batch measurement is finished is required.
            }
        }

        #endregion

        #region Reading or writing settings for each program number event handler

        /// <summary>
        /// Browse ("...") button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnReferenceProgramFilePathEx_Click(object sender, EventArgs e)
        {
            if (_openProgramFileDialog.ShowDialog() != DialogResult.OK) return;
            _txtProgramFilePath.Text = _openProgramFileDialog.FileName;
        }

        /// <summary>
        /// "Sending settings (PC -> LJ)" button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Send settings in the file to the controller</remarks>
        private void btnSetSettingEx_Click(object sender, EventArgs e)
        {
            if (_txtProgramFilePath.Text.Length == 0) return;
            if (File.Exists(_txtProgramFilePath.Text) == false) return;

            // Parameter
            LJV7IF_TARGET_SETTING setting = GetSelectedProgramTargetSetting();
            UInt32 size = GetSelectedProgramDataSize();

            // Allocate buffer
            byte[] receiveBuffer = new byte[size];
            // Load program data
            using (FileStream fs = new FileStream(_txtProgramFilePath.Text, FileMode.Open))
            {
                //It is a very simple validation method.
                if (fs.Length != size)
                {
                    MessageBox.Show("File size is not match.");
                    return;
                }
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    reader.Read(receiveBuffer, 0, (int)size);
                }
            }

            using (PinnedObject pin = new PinnedObject(receiveBuffer))
            {
                // Upload
                uint error = 0;
                Rc rc = (Rc)NativeMethods.LJV7IF_SetSetting(Define.DEVICE_ID, (byte)SettingDepth.Running, setting, pin.Pointer, size, ref error);
                if (!CheckReturnCode(rc)) return;
            }
        }

        /// <summary>
        /// "Receiving settings (LJ -> PC)" button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Receive settings from the controller, and then write these settings to the file</remarks>
        private void btnGetSettingEx_Click(object sender, EventArgs e)
        {
            if (_txtProgramFilePath.Text.Length == 0) return;

            // Parameter
            LJV7IF_TARGET_SETTING setting = GetSelectedProgramTargetSetting();
            UInt32 size = GetSelectedProgramDataSize();                          // Environment:60, Common:12, Program number:10932

            // Allocate buffer
            byte[] receiveBuffer = new byte[size];
            using (PinnedObject pin = new PinnedObject(receiveBuffer))
            {
                // Download
                Rc rc = (Rc)NativeMethods.LJV7IF_GetSetting(Define.DEVICE_ID, (byte)SettingDepth.Running, setting, pin.Pointer, size);
                if (!CheckReturnCode(rc)) return;
            }
            // Save program data
            using (FileStream fs = new FileStream(_txtProgramFilePath.Text, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(receiveBuffer);
            }
        }

        #endregion

        #endregion

        #region Method(for single-function)

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();


            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            lblImageName.Text = "(no image)";

            btnTeachMode.Click += (s, e) => SetTeachMode(true);
            btnAutoMode.Click += (s, e) => SetTeachMode(false);

            // khởi tạo mặc định (tuỳ bạn muốn vào mode nào lúc mở app)
            SetTeachMode(true);   // vào TEACH ngay khi chạy

            // set default to UI
            if (txtSpeed != null) txtSpeed.Text = _speedPercent.ToString();
            if (txtDistance != null) txtDistance.Text = _distanceMm.ToString("0.###");

            // SPEED +/- or typing
            btnSpeedPlus.Click += (s, e) => SetSpeed(_speedPercent + 5);
            btnSpeedMinus.Click += (s, e) => SetSpeed(_speedPercent - 5);
            txtSpeed.Leave += (s, e) =>
            {
                int v;
                if (!int.TryParse(txtSpeed.Text, out v)) v = _speedPercent;
                SetSpeed(v);
            };
            // optional: block non-digit
            txtSpeed.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };

            // DISTANCE +/- or typing
            btnDistPlus.Click += (s, e) => SetDistance(_distanceMm + 1);
            btnDistMinus.Click += (s, e) => SetDistance(Math.Max(0, _distanceMm - 1));
            txtDistance.Leave += (s, e) =>
            {
                double v;
                if (!double.TryParse(txtDistance.Text, out v)) v = _distanceMm;
                SetDistance(v);
            };
            // allow digits, dot, backspace
            txtDistance.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
                // only one dot
                if (e.KeyChar == '.' && (txtDistance.Text.IndexOf('.') > -1)) e.Handled = true;
            };

            // JOG buttons
            btnXp.Click += (s, e) => JogAxis("X", +_distanceMm);
            btnXm.Click += (s, e) => JogAxis("X", -_distanceMm);
            btnYp.Click += (s, e) => JogAxis("Y", +_distanceMm);
            btnYm.Click += (s, e) => JogAxis("Y", -_distanceMm);
            btnZp.Click += (s, e) => JogAxis("Z", +_distanceMm);
            btnZm.Click += (s, e) => JogAxis("Z", -_distanceMm);

            // Field initialization
            _sendCommand = SendCommand.None;
            _deviceData = new DeviceData[NativeMethods.DeviceCount];
            _measureDatas = new List<MeasureData>();
            _callback = new HighSpeedDataCallBack(ReceiveHighSpeedData);
            _callbackOnlyCount = new HighSpeedDataCallBack(CountProfileReceive);
            _deviceStatusLabels = new Label[] {
                _lblDeviceStatus0, _lblDeviceStatus1, _lblDeviceStatus2,
                _lblDeviceStatus3, _lblDeviceStatus4, _lblDeviceStatus5};

            _receivedProfileCountLabels = new Label[] {
                _lblReceiveProfileCount0, _lblReceiveProfileCount1, _lblReceiveProfileCount2,
                _lblReceiveProfileCount3, _lblReceiveProfileCount4, _lblReceiveProfileCount5};

            for (int i = 0; i < NativeMethods.DeviceCount; i++)
            {
                _deviceData[i] = new DeviceData();
                _deviceStatusLabels[i].Text = _deviceData[i].GetStatusString();
            }
            _profileInfo = new LJV7IF_PROFILE_INFO[NativeMethods.DeviceCount];

            // Communication button comment setting
            SetCommandBtnString();

            // Control initialization
            _cmbMeasureX.DataSource = GetMeasureRangeList();
            _cmbReceivedBinning.DataSource = GetReceivedBiginning();
            _cmbCompressX.DataSource = GetCompressX();

            _cmbMeasureX.SelectedValue = Define.MEASURE_RANGE_FULL;
            _cmbReceivedBinning.SelectedValue = Define.RECEIVED_BINNING_OFF;
            _cmbCompressX.SelectedValue = Define.COMPRESS_X_OFF;

            _cbxSelectProgram.SelectedIndex = 2;

            // For use in profile export control
            //_txtboxProfileFilePath.Text = Directory.GetCurrentDirectory() + @"\" + Define.DEFAULT_PROFILE_FILE_NAME;
            //_txtboxProfileFilePath.SelectionStart = _txtboxProfileFilePath.Text.Length;

            // Control.CheckForIllegalCrossThreadCalls = false;

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 1000; 
            updateTimer.Tick += (s, e) => Print2D();

            // Khởi tạo cổng Serial
            arduinoPort = new SerialPort();
            arduinoPort.BaudRate = 9600;

            // Load danh sách cổng COM tự động
            LoadAvailablePorts();
        }

        /// <summary>
        /// AnalyzeProfileData
        /// </summary>
        /// <param name="profileCount">Number of profiles that were read</param>
        /// <param name="profileInfo">Profile information structure</param>
        /// <param name="profileData">Acquired profile data</param>
        private void AnalyzeProfileData(int profileCount, ref LJV7IF_PROFILE_INFO profileInfo, int[] profileData)
        {
            int dataUnit = ProfileData.CalculateDataSize(profileInfo);
            AnalyzeProfileData(profileCount, ref profileInfo, profileData, 0, dataUnit);
        }

        /// <summary>
        /// AnalyzeProfileData
        /// </summary>
        /// <param name="profileCount">Number of profiles that were read</param>
        /// <param name="profileInfo">Profile information structure</param>
        /// <param name="profileData">Acquired profile data</param>
        /// <param name="startProfileIndex">Start position of the profiles to copy</param>
        /// <param name="dataUnit">Profile data size</param>
        private void AnalyzeProfileData(int profileCount, ref LJV7IF_PROFILE_INFO profileInfo, int[] profileData, int startProfileIndex, int dataUnit)
        {
            int readPropfileDataSize = ProfileData.CalculateDataSize(profileInfo);
            int[] tempRecvieProfileData = new int[readPropfileDataSize];

            // Profile data retention
            for (int i = 0; i < profileCount; i++)
            {
                Array.Copy(profileData, (startProfileIndex + i * dataUnit), tempRecvieProfileData, 0, readPropfileDataSize);

                _deviceData[_currentDeviceId].ProfileData.Add(new ProfileData(tempRecvieProfileData, profileInfo));
            }
        }

        /// <summary>
        /// AnalyzeBatchData
        /// </summary>
        /// <param name="profileCount">Number of profiles that were read</param>
        /// <param name="profileInfo">Profile information structure</param>
        /// <param name="includeTimeData">Whether to include the time offset</param>
        /// <param name="batchData">Acquired batch profile data</param>
        /// <param name="startProfileIndex">Start position of the profiles to copy</param>
        private void AnalyzeBatchData(int profileCount, ref LJV7IF_PROFILE_INFO profileInfo, bool includeTimeData, int[] batchData, int startProfileIndex)
        {
            int offsetTimeSize = (includeTimeData) ? 1 : 0;
            int readPropfileDataSize = ProfileData.CalculateDataSize(profileInfo);
            int readMeasureDataSize = Utility.GetByteSize(Utility.TypeOfStruct.MEASURE_DATA) * (int)NativeMethods.MeasurementDataCount;
            int dataUnit = offsetTimeSize + readPropfileDataSize + readMeasureDataSize / Marshal.SizeOf(typeof(int));
            int[] tempRecvieProfileData = new int[readPropfileDataSize];
            byte[] tempRecvieMeasureData = new byte[readMeasureDataSize];
            uint offestTime = 0;

            // Profile data retention
            for (int i = 0; i < profileCount; i++)
            {
                if (includeTimeData)
                {
                    offestTime = (uint)batchData[startProfileIndex + i * dataUnit];
                }
                Array.Copy(batchData, (startProfileIndex + i * dataUnit + offsetTimeSize), tempRecvieProfileData, 0, readPropfileDataSize);
                _deviceData[_currentDeviceId].ProfileData.Add(new ProfileData(tempRecvieProfileData, profileInfo));

                Buffer.BlockCopy(batchData, (startProfileIndex + i * dataUnit + offsetTimeSize + readPropfileDataSize) * Marshal.SizeOf(typeof(int)),
                    tempRecvieMeasureData, 0, readMeasureDataSize);
                _deviceData[_currentDeviceId].MeasureData.Add(new MeasureData(tempRecvieMeasureData));
                if (includeTimeData)
                {
                    _deviceData[_currentDeviceId].MeasureData[i].OffsetTime = offestTime;
                }
            }
        }

        /// <summary>
        /// Get the profile data size
        /// </summary>
        /// <returns>Data size of one profile (in units of bytes)</returns>
        private uint GetOneProfileDataSize()
        {
            // Buffer size (in units of bytes)
            uint retBuffSize = 0;

            // Basic size
            int basicSize = (int)_cmbMeasureX.SelectedValue / (int)_cmbReceivedBinning.SelectedValue;
            basicSize /= (int)_cmbCompressX.SelectedValue;

            // Number of headers
            retBuffSize += (uint)basicSize * (_rdbtnOneHead.Checked ? 1U : 2U);

            // Envelope setting
            retBuffSize *= (_chkboxEnvelope.Checked ? 2U : 1U);

            //in units of bytes
            retBuffSize *= (uint)Marshal.SizeOf(typeof(uint));

            // Sizes of the header and footer structures
            LJV7IF_PROFILE_HEADER profileHeader = new LJV7IF_PROFILE_HEADER();
            retBuffSize += (uint)Marshal.SizeOf(profileHeader);
            LJV7IF_PROFILE_FOOTER profileFooter = new LJV7IF_PROFILE_FOOTER();
            retBuffSize += (uint)Marshal.SizeOf(profileFooter);

            return retBuffSize;
        }

        /// <summary>
        /// Method that is called from the DLL as a callback function
        /// </summary>
        /// <param name="buffer">Leading pointer of the received data</param>
        /// <param name="size">Size in units of bytes of one profile</param>
        /// <param name="count">Number of profiles</param>
        /// <param name="notify">Completion flag</param>
        /// <param name="user">Thread ID (value passed during initialization)</param>
        public static void ReceiveHighSpeedData(IntPtr buffer, uint size, uint count, uint notify, uint user)
        {
            // @Point
            // Take care to only implement storing profile data in a thread save buffer in the callback function.
            // As the thread used to call the callback function is the same as the thread used to receive data,
            // the processing time of the callback function affects the speed at which data is received,
            // and may stop communication from being performed properly in some environments.

            uint profileSize = (uint)(size / Marshal.SizeOf(typeof(int)));
            List<int[]> receiveBuffer = new List<int[]>();
            int[] bufferArray = new int[profileSize * count];
            Marshal.Copy(buffer, bufferArray, 0, (int)(profileSize * count));

            // Profile data retention
            for (int i = 0; i < count; i++)
            {
                int[] oneProfile = new int[profileSize];
                Array.Copy(bufferArray, i * profileSize, oneProfile, 0, profileSize);
                receiveBuffer.Add(oneProfile);
            }

            ThreadSafeBuffer.Add((int)user, receiveBuffer, notify);
        }

        /// <summary>
        /// Method that is called from the DLL as a callback function
        /// </summary>
        /// <param name="buffer">Leading pointer of the received data</param>
        /// <param name="size">Size in units of bytes of one profile</param>
        /// <param name="count">Number of profiles</param>
        /// <param name="notify">Completion flag</param>
        /// <param name="user">Thread ID (value passed during initialization)</param>
        public static void CountProfileReceive(IntPtr buffer, uint size, uint count, uint notify, uint user)
        {
            // @Point
            // Take care to only implement storing profile data in a thread save buffer in the callback function.
            // As the thread used to call the callback function is the same as the thread used to receive data,
            // the processing time of the callback function affects the speed at which data is received,
            // and may stop communication from being performed properly in some environments.

            ThreadSafeBuffer.AddCount((int)user, count, notify);
        }

        /// <summary>
        /// Get the ID of the selected device.
        /// </summary>
        /// <returns>Device ID</returns>
        private int GetSelectedDeviceId()
        {
            foreach (Control control in _pnlDeviceId.Controls)
            {
                RadioButton rd = control as RadioButton;
                if ((rd == null) || (!rd.Checked)) continue;

                return Convert.ToInt32(rd.Tag);
            }

            return -1;
        }

        /// <summary>
        /// Get the measurement range.
        /// </summary>
        /// <returns>List used as the combo box data source</returns>
        private List<DictionaryEntry> GetMeasureRangeList()
        {
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            list.Add(new DictionaryEntry(Resources.SID_MEASURE_RANGE_FULL, Define.MEASURE_RANGE_FULL));
            list.Add(new DictionaryEntry(Resources.SID_MEASURE_RANGE_MIDDLE, Define.MEASURE_RANGE_MIDDLE));
            list.Add(new DictionaryEntry(Resources.SID_MEASURE_RANGE_SMALL, Define.MEASURE_RANGE_SMALL));
            return list;
        }

        /// <summary>
        /// Get the light reception characteristic binning list.
        /// </summary>
        /// <returns>List used as the combo box data source</returns>
        private List<DictionaryEntry> GetReceivedBiginning()
        {
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            list.Add(new DictionaryEntry(Resources.SID_RECEIVED_BINNING_OFF, Define.RECEIVED_BINNING_OFF));
            list.Add(new DictionaryEntry(Resources.SID_RECEIVED_BINNING_ON, Define.RECEIVED_BINNING_ON));
            return list;
        }

        /// <summary>
        /// Get the light reception characteristic binning list.
        /// </summary>
        /// <returns>List used as the combo box data source</returns>
        private List<DictionaryEntry> GetCompressX()
        {
            List<DictionaryEntry> list = new List<DictionaryEntry>();
            list.Add(new DictionaryEntry(Resources.SID_COMPRESS_X_OFF, Define.COMPRESS_X_OFF));
            list.Add(new DictionaryEntry(Resources.SID_COMPRESS_X_2, Define.COMPRESS_X_2));
            list.Add(new DictionaryEntry(Resources.SID_COMPRESS_X_4, Define.COMPRESS_X_4));
            return list;
        }

        /// <summary>
        /// Communication button string setting
        /// </summary>
        private void SetCommandBtnString()
        {
            // Set the communication button comment here to match it with the log output string.
            _btnUsbOpen.Text = Resources.SID_USB_OPEN;
            _btnGetTime.Text = Resources.SID_GET_TIME;
            _btnGetVersion.Text = Resources.SID_GET_VERSION;
            _btnFinalize.Text = Resources.SID_FINALIZE;
            _btnInitialize.Text = Resources.SID_INITIALIZE;
            _btnCommClose.Text = Resources.SID_COMM_CLOSE;
            _btnEthernetOpen.Text = Resources.SID_ETHERNET_OPEN;
            _btnGetActiveProgram.Text = Resources.SID_GET_ACTIVE_PROGRAM;
            _btnHighSpeedDataCommunicationFinalize.Text = Resources.SID_HIGH_SPEED_DATA_COMMUNICATION_FINALIZE;
            _btnStopHighSpeedDataCommunication.Text = Resources.SID_STOP_HIGH_SPEED_DATA_COMMUNICATION;
            _btnStartHighSpeedDataCommunication.Text = Resources.SID_START_HIGH_SPEED_DATA_COMMUNICATION;
            _btnPreStartHighSpeedDataCommunication.Text = Resources.SID_PRE_START_HIGH_SPEED_DATA_COMMUNICATION;
            _btnHighSpeedDataUsbCommunicationInitalize.Text = Resources.SID_HIGH_SPEED_DATA_USB_COMMUNICATION_INITALIZE;
            _btnHighSpeedDataEthernetCommunicationInitalize.Text = Resources.SID_HIGH_SPEED_DATA_ETHERNET_COMMUNICATION_INITALIZE;
            _btnRewriteTemporarySetting.Text = Resources.SID_REWRITE_TEMPORARY_SETTING;
            _btnGetStorageBatchProfile.Text = Resources.SID_GET_STORAGE_BATCH_PROFILE;
            _btnGetStorageProfile.Text = Resources.SID_GET_STORAGE_PROFILE;
            _btnGetStorageData.Text = Resources.SID_GET_STORAGE_DATA;
            _btnGetStorageStatus.Text = Resources.SID_GET_STORAGE_STATUS;
            _btnStopStorage.Text = Resources.SID_STOP_STORAGE;
            _btnStartStorage.Text = Resources.SID_START_STORAGE;
            _btnGetBatchProfileAdvance.Text = Resources.SID_GET_BATCH_PROFILE_ADVANCE;
            _btnGetProfileAdvance.Text = Resources.SID_GET_PROFILE_ADVANCE;
            _btnGetBatchProfile.Text = Resources.SID_GET_BATCH_PROFILE;
            _btnGetProfile.Text = Resources.SID_GET_PROFILE;
            _btnGetMeasurementValue.Text = Resources.SID_GET_MEASUREMENT_VALUE;
            _btnChangeActiveProgram.Text = Resources.SID_CHANGE_ACTIVE_PROGRAM;
            _btnSetTime.Text = Resources.SID_SET_TIME;
            _btnUpdataSetting.Text = Resources.SID_UPDATA_SETTING;
            _btnCheckMemoryAccess.Text = Resources.SID_CHECK_MEMORY_ACCESS;
            _btnSetSetting.Text = Resources.SID_SET_SETTING;
            _btnGetSetting.Text = Resources.SID_GET_SETTING;
            _btnClearMemory.Text = Resources.SID_CLEAR_MEMORY;
            _btnReset.Text = Resources.SID_RESET;
            _btnTiming.Text = Resources.SID_TIMING;
            _btnAutoZero.Text = Resources.SID_AUTO_ZERO;
            _btnStopMeasure.Text = Resources.SID_STOP_MEASURE;
            _btnStartMeasure.Text = Resources.SID_START_MEASURE;
            _btnTrigger.Text = Resources.SID_TRIGGER;
            _btnClearError.Text = Resources.SID_CLEAR_ERROR;
            _btnGetError.Text = Resources.SID_GET_ERROR;
            _btnRetrunToFactorySetting.Text = Resources.SID_RETRUN_TO_FACTORY_SETTING;
            _btnRebootController.Text = Resources.SID_REBOOT_CONTROLLER;
        }

        #region Log output

        /// <summary>
        /// Log output
        /// </summary>
        /// <param name="strLog">Output log</param>
        private void AddLog(string strLog)
        {
            _txtboxLog.AppendText(strLog + Environment.NewLine);
            _txtboxLog.SelectionStart = _txtboxLog.Text.Length;
            _txtboxLog.Focus();
            _txtboxLog.ScrollToCaret();
        }

        /// <summary>
        /// Communication command result log output
        /// </summary>
        /// <param name="rc">Return code from the DLL</param>
        /// <param name="commandName">Command name to be output in the log</param>
        private void AddLogResult(int rc, string commandName)
        {
            if (rc == (int)Rc.Ok)
            {
                AddLog(string.Format(Resources.SID_LOG_FORMAT, commandName, Resources.SID_RESULT_OK, rc));
            }
            else
            {
                AddLog(string.Format(Resources.SID_LOG_FORMAT, commandName, Resources.SID_RESULT_NG, rc));
                AddErrorLog(rc);
            }
        }

        /// <summary>
        /// Error log output
        /// </summary>
        /// <param name="rc">Return code</param>
        private void AddErrorLog(int rc)
        {
            if (rc < 0x8000)
            {
                // Common return code
                CommonErrorLog(rc);
            }
            else
            {
                // Individual return code
                IndividualErrorLog(rc);
            }
        }

        /// <summary>
        /// Add Error
        /// </summary>
        /// <param name="dwError"></param>
        private void AddError(uint dwError)
        {
            _txtboxLog.AppendText("  ErrorCode : 0x" + dwError.ToString("x8") + Environment.NewLine);
            _txtboxLog.SelectionStart = _txtboxLog.Text.Length;
            _txtboxLog.Focus();
            _txtboxLog.ScrollToCaret();
        }

        /// <summary>
        /// Common return code log output
        /// </summary>
        /// <param name="rc">Return code</param>
        private void CommonErrorLog(int rc)
        {
            switch (rc)
            {
                case (int)Rc.Ok:
                    AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_OK));
                    break;
                case (int)Rc.ErrOpenDevice:
                    AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_OPEN_DEVICE));
                    break;
                case (int)Rc.ErrNoDevice:
                    AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_NO_DEVICE));
                    break;
                case (int)Rc.ErrSend:
                    AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_SEND));
                    break;
                case (int)Rc.ErrReceive:
                    AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_RECEIVE));
                    break;
                case (int)Rc.ErrTimeout:
                    AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_TIMEOUT));
                    break;
                case (int)Rc.ErrParameter:
                    AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_PARAMETER));
                    break;
                case (int)Rc.ErrNomemory:
                    AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_NOMEMORY));
                    break;
                default:
                    AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                    break;
            }
        }

        /// <summary>
        /// Individual return code log output
        /// </summary>
        /// <param name="rc">Return code</param>
        private void IndividualErrorLog(int rc)
        {
            switch (_sendCommand)
            {
                case SendCommand.RebootController:
                    {
                        switch (rc)
                        {
                            case 0x80A0:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Accessing the save area"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.Trigger:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The trigger mode is not [external trigger]"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.StartMeasure:
                case SendCommand.StopMeasure:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Batch measurements are off"));
                                break;
                            case 0x80A0:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Batch measurement start processing could not be performed because the REMOTE terminal is off or the LASER_OFF terminal is on"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.AutoZero:
                case SendCommand.Timing:
                case SendCommand.Reset:
                case SendCommand.GetMeasurementValue:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.ChangeActiveProgram:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The change program setting is [terminal]"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.GetProfile:
                case SendCommand.GetProfileAdvance:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [advanced (with OUT measurement)]"));
                                break;
                            case 0x8081:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Batch measurements on and profile compression (time axis) off"));
                                break;
                            case 0x80A0:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"No profile data"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.GetBatchProfile:
                case SendCommand.GetBatchProfileAdvance:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [advanced (with OUT measurement)]"));
                                break;
                            case 0x8081:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Not [batch measurements on and profile compression (time axis) off]"));
                                break;
                            case 0x80A0:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"No batch data (batch measurements not run even once)"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;

                case SendCommand.StartStorage:
                case SendCommand.StopStorage:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                                break;
                            case 0x8081:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Storage target setting is [OFF] (no storage)"));
                                break;
                            case 0x8082:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The storage condition setting is not [terminal/command]"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.GetStorageStatus:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.GetStorageData:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                                break;
                            case 0x8081:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The storage target setting is not [OUT value]"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.GetStorageProfile:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                                break;
                            case 0x8081:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The storage target setting is not profile, or batch measurements on and profile compression (time axis) off"));
                                break;
                            case 0x8082:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Batch measurements on and profile compression (time axis) off"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.GetStorageBatchProfile:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                                break;
                            case 0x8081:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The storage target setting is not profile, or batch measurements on and profile compression (time axis) off"));
                                break;
                            case 0x8082:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Not [batch measurements on and profile compression (time axis) off]"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.HighSpeedDataUsbCommunicationInitalize:
                case SendCommand.HighSpeedDataEthernetCommunicationInitalize:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [advanced (with OUT measurement)]"));
                                break;
                            case 0x80A1:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Already performing high-speed communication error (for high-speed communication)"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                case SendCommand.PreStartHighSpeedDataCommunication:
                case SendCommand.StartHighSpeedDataCommunication:
                    {
                        switch (rc)
                        {
                            case 0x8080:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [advanced (with OUT measurement)]"));
                                break;
                            case 0x8081:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The data specified as the send start position does not exist"));
                                break;
                            case 0x80A0:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"A high-speed data communication connection was not established"));
                                break;
                            case 0x80A1:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Already performing high-speed communication error (for high-speed communication)"));
                                break;
                            case 0x80A4:
                                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The send target data was cleared"));
                                break;
                            default:
                                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                                break;
                        }
                    }
                    break;
                default:
                    AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                    break;
            }
        }

        #endregion


        #endregion

        #region Method(for combination-function)
        /// <summary>
        /// Create program download/upload parameters depends on combobox selection.
        /// </summary>
        /// <returns>Setting item structure</returns>
        private LJV7IF_TARGET_SETTING GetSelectedProgramTargetSetting()
        {
            LJV7IF_TARGET_SETTING setting;
            setting.byCategory = 0xFF;    // means all parameter
            setting.byItem = 0x00;
            setting.reserve = 0;
            setting.byTarget1 = 0;        // This is used when you want to set a setting item in greater detail
            setting.byTarget2 = 0;
            setting.byTarget3 = 0;
            setting.byTarget4 = 0;

            if (_cbxSelectProgram.SelectedIndex == 0)
            {
                setting.byType = (byte)SettingType.Environment;
            }
            else if (_cbxSelectProgram.SelectedIndex == 1)
            {
                setting.byType = (byte)SettingType.Common;
            }
            else
            {
                setting.byType = (byte)(SettingType)((int)SettingType.Program00 + (_cbxSelectProgram.SelectedIndex - 2));
            }

            return setting;
        }


        /// <summary>
        /// GetSelectedProgramDataSize
        /// </summary>
        /// <returns>Program settingsサイズ</returns>
        private UInt32 GetSelectedProgramDataSize()
        {
            if (_cbxSelectProgram.SelectedIndex == 0) return NativeMethods.EnvironmentSettingSize;
            if (_cbxSelectProgram.SelectedIndex == 1) return NativeMethods.CommonSettingSize;
            return NativeMethods.ProgramSettingSize;
        }

        /// <summary>
        /// Return code check
        /// </summary>
        /// <param name="rc">Return code</param>
        /// <returns>Is the return code OK?</returns>
        /// <remarks>If the return code is not OK, display a message and return false.</remarks>
        private bool CheckReturnCode(Rc rc)
        {
            if (rc == Rc.Ok) return true;
            MessageBox.Show(this, string.Format("Error: 0x{0,8:x}", rc), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        /// <summary>
        /// Output profile data to a file.
        /// </summary>
        /// <param name="profileDatas">Profile data to output</param>
        /// <param name="savePath">Full path to the file to save</param>
        /// <remarks>Output data in TSV format.</remarks>
        private static void SaveProfile(List<ProfileData> profileDatas, string savePath)
        {
            try
            {
                // Save the profile
                using (StreamWriter sw = new StreamWriter(savePath, false, Encoding.GetEncoding("utf-16")))
                {
                    // X-axis output
                    sw.WriteLine(ProfileData.GetXPosString(profileDatas[0].ProfInfo));

                    // Output the data of each profile
                    foreach (ProfileData profile in profileDatas)
                    {
                        StringBuilder sb = new StringBuilder();
                        int dataCount = profile.ProfDatas.Length;

                        for (int i = 0; i < dataCount; i++)
                        {
                            sb.AppendFormat("{0}\t", profile.ProfDatas[i]);
                        }
                        sw.WriteLine(sb);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
        #region Connect Draw 2D

        private void _rdEthernet1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox10.Enabled = radioButton4.Checked;
        }

        private void btnEstablishCommunicationEx1_Click(object sender, EventArgs e)
        {
            Rc rc = Rc.Ok;
            // Initialize the DLL
            rc = (Rc)NativeMethods.LJV7IF_Initialize();
            if (!CheckReturnCode(rc)) return;

            // Open the communication path
            if (_rdUsb.Checked && radioButton3.Checked)
            {
                rc = (Rc)NativeMethods.LJV7IF_UsbOpen(Define.DEVICE_ID);
            }
            else
            {
                // Generate the settings for Ethernet communication.
                try
                {
                    _ethernetConfig1.abyIpAddress = new byte[] {
                        Convert.ToByte(_txtIpFirstSegment1.Text),
                        Convert.ToByte(_txtIpSecondSegment1.Text),
                        Convert.ToByte(_txtIpThirdSegment1.Text),
                        Convert.ToByte(_txtIpFourthSegment1.Text)
                    };
                    _ethernetConfig1.wPortNo = Convert.ToUInt16(_txtCommandPort1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                    return;
                }

                rc = (Rc)NativeMethods.LJV7IF_EthernetOpen(Define.DEVICE_ID, ref _ethernetConfig1);
            }
            if (!CheckReturnCode(rc)) return;
        }
        #endregion

        #region Setup LiveChart
        private void PlotScatterChart(List<double> xValues, List<double> yValues, bool isTemplate)
        {
            // vẽ đồng thời lên cả 2 chart
            foreach (var chart in new LiveCharts.WinForms.CartesianChart[] { cartesianChart1, cartesianChartXY })
            {
                if (chart == null) continue;                    // phòng khi 1 chart không có trên form
                if (chart.Series == null) chart.Series = new LiveCharts.SeriesCollection();

                // đảm bảo đã có series mẫu (xanh) ở index 0
                if (chart.Series.Count == 0)
                {
                    var templateSeries = new LiveCharts.Wpf.LineSeries
                    {
                        Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint>(),
                        StrokeThickness = 2,
                        PointGeometry = null,
                        Stroke = System.Windows.Media.Brushes.Blue,
                        Title = "Biên dạng mẫu"
                    };
                    chart.Series.Add(templateSeries);
                }

                if (isTemplate)
                {
                    var templateSeries = (LiveCharts.Wpf.LineSeries)chart.Series[0];
                    templateSeries.Values.Clear();
                    for (int i = 0; i < xValues.Count; i++)
                        templateSeries.Values.Add(new LiveCharts.Defaults.ObservablePoint(xValues[i], yValues[i]));
                }
                else
                {
                    // đảm bảo có series đo (đỏ) ở index 1
                    if (chart.Series.Count < 2)
                    {
                        var testSeries = new LiveCharts.Wpf.LineSeries
                        {
                            Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint>(),
                            StrokeThickness = 2,
                            PointGeometry = null,
                            Stroke = System.Windows.Media.Brushes.Red,
                            Title = "Biên dạng kiểm tra"
                        };
                        chart.Series.Add(testSeries);
                    }

                    var testSeriesExisting = (LiveCharts.Wpf.LineSeries)chart.Series[1];
                    testSeriesExisting.Values.Clear();
                    for (int i = 0; i < xValues.Count; i++)
                        testSeriesExisting.Values.Add(new LiveCharts.Defaults.ObservablePoint(xValues[i], yValues[i]));
                }

                // tối giản tương tác/hiệu ứng
                chart.DisableAnimations = true;
                chart.Hoverable = false;
                chart.DataTooltip = null;
                chart.Zoom = LiveCharts.ZoomingOptions.None;
                chart.Pan = LiveCharts.PanningOptions.None;
                chart.Update(true, true);
            }
        }

        #endregion

        #region draw2D Auto
        private readonly object lockObject = new object();

        private async void updateTimer_Tick(object sender, EventArgs e)
        {
            if (Monitor.TryEnter(lockObject))
            {
                try
                {
                    if (isUpdating) return;
                    isUpdating = true;

                    await Task.Run(() => Print2D());
                }
                finally
                {
                    isUpdating = false;
                    Monitor.Exit(lockObject);
                }
            }
        }
        private List<double> xValues = new List<double>();
        private List<double> yValues = new List<double>();
        private void Print2D()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(Print2D));
                return;
            }

            var profileInfo = new LJV7IF_PROFILE_INFO();
            var measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

            int profileDataSize = Define.MAX_PROFILE_COUNT +
                (Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / Marshal.SizeOf(typeof(int));
            var receiveBuffer = new int[profileDataSize];

            using (var pin = new PinnedObject(receiveBuffer))
            {
                Rc rc = (Rc)NativeMethods.LJV7IF_GetProfileAdvance(Define.DEVICE_ID, ref profileInfo, pin.Pointer,
                    (uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))), measureData);

                if (!CheckReturnCode(rc)) return;
            }

            var profileDatas = new List<ProfileData>
            {
                new ProfileData(receiveBuffer, 0, profileInfo)
            };

            foreach (var profile in profileDatas)
            {
                if (profile.ProfDatas.Length == 0) continue;

                var currentProfile = new List<Tuple<double, double>>();
                var xValues = new List<double>();
                var yValues = new List<double>();

                for (int i = 0; i < profile.ProfDatas.Length; i++)
                {
                    double data = profile.ProfDatas[i] / 100000.0;
                    if (data < -100) continue;

                    double x = -8.0 + i * 0.02;
                    xValues.Add(x);
                    yValues.Add(data);
                    currentProfile.Add(new Tuple<double, double>(x, data));
                }

                if (xValues.Any() && yValues.Any())
                {
                    PlotScatterChart(xValues, yValues, false);
                    lock (allProfiles)
                    {
                        allProfiles.Add(currentProfile); // Thêm profile hiện tại vào danh sách chính
                    }
                }
            }
        }
        private void btnAutoDraw_Click(object sender, EventArgs e)
        {
            if (isUpdating)
            {
                updateTimer.Stop(); // Dừng Timer
                isUpdating = false;
                btnAutoDraw.Text = "START DRAW"; // Cập nhật nhãn nút
                MessageBox.Show($"AutoDraw stopped. Total profiles captured: {allProfiles.Count}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (int.TryParse(delayTime.Text, out int interval) && interval > 0)
                {
                    updateTimer.Interval = interval; // Đặt khoảng thời gian cập nhật
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên dương cho thời gian cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                allProfiles.Clear(); // Xóa danh sách cũ trước khi bắt đầu
                updateTimer.Start(); // Bắt đầu Timer
                isUpdating = true;
                btnAutoDraw.Text = "STOP DRAW";
            }
        }

        #endregion

        #region Save Auto Profile .txt

        private List<List<Tuple<double, double>>> allProfiles = new List<List<Tuple<double, double>>>();
        private void btnLinkAutoProfile_Click(object sender, EventArgs e)
        {
            if (_profileFileSave.ShowDialog(this) == DialogResult.Cancel) return;

            linkSaveAutoProfile.Text = _profileFileSave.FileName;
            linkSaveAutoProfile.SelectionStart = linkSaveAutoProfile.Text.Length;
        }

        private void btnSaveAutoProfile_Click(object sender, EventArgs e)
        {
            if (allProfiles.Count == 0)
            {
                MessageBox.Show("No profiles to save. Please run AutoDraw first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = linkSaveAutoProfile.Text;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Please select a file path first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Profile Data (X-Values, Y-Values)");
                    for (int i = 0; i < allProfiles.Count; i++)
                    {
                        writer.WriteLine($"Profile {i + 1}:");
                        foreach (var point in allProfiles[i])
                        {
                            writer.WriteLine($"{point.Item1}\t{point.Item2}");
                        }
                            writer.WriteLine(); // Thêm dòng trống giữa các profile
                    }
                }
                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region draw2D OneTimes

        private List<double> xValues1 = new List<double>();
        private List<double> yValues1 = new List<double>();

        private void Print2D1()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(Print2D1));
                return;
            }

            var profileInfo = new LJV7IF_PROFILE_INFO();
            var measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

            int profileDataSize = Define.MAX_PROFILE_COUNT +
                (Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / Marshal.SizeOf(typeof(int));
            var receiveBuffer = new int[profileDataSize];

            using (var pin = new PinnedObject(receiveBuffer))
            {
                Rc rc = (Rc)NativeMethods.LJV7IF_GetProfileAdvance(Define.DEVICE_ID, ref profileInfo, pin.Pointer,
                    (uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))), measureData);

                if (!CheckReturnCode(rc)) return;
            }

            var profileDatas = new List<ProfileData>
    {
        new ProfileData(receiveBuffer, 0, profileInfo)
    };

            xValues1.Clear(); // Xóa dữ liệu cũ trước khi vẽ
            yValues1.Clear();

            foreach (var profile in profileDatas)
            {
                if (profile.ProfDatas.Length == 0) continue;

                var currentProfile = new List<Tuple<double, double>>();

                for (int i = 0; i < profile.ProfDatas.Length; i++)
                {
                    double data = profile.ProfDatas[i] / 100000.0;
                    if (data < -100) continue;

                    double x = -8.0 + i * 0.02;
                    xValues1.Add(x); // Lưu giá trị x vào danh sách chung
                    yValues1.Add(data); // Lưu giá trị y vào danh sách chung
                    currentProfile.Add(new Tuple<double, double>(x, data));
                }

                if (xValues1.Any() && yValues1.Any())
                {
                    //PlotScatterChart(xValues1, yValues1, false );
                    lock (allProfiles)
                    {
                        allProfiles.Add(currentProfile); // Thêm profile hiện tại vào danh sách chính
                    }
                }
            }
        }

        private void drawOneProfile_Click(object sender, EventArgs e)
        {
            Print2D1();
        }
        #endregion

        #region Save One Profile .txt

        private void saveOneProfileToFile(string filePath, List<double> xValues, List<double> yValues)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    //writer.WriteLine("X-Values\tY-Values"); // Tiêu đề
                    for (int i = 0; i < xValues.Count; i++)
                    {
                        writer.WriteLine($"{xValues[i]}\t{yValues[i]}");
                    }
                }
                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLinkOneProfile_Click(object sender, EventArgs e)
        {
            if (_profileFileSave.ShowDialog(this) == DialogResult.Cancel) return;

            linkSaveOneProfile.Text = _profileFileSave.FileName;
            linkSaveOneProfile.SelectionStart = linkSaveOneProfile.Text.Length;
        }

        private void btnsaveOneProfile_Click(object sender, EventArgs e)
        {
            if (xValues1.Count == 0 || yValues1.Count == 0)
            {
                MessageBox.Show("No data to save. Please generate data first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = linkSaveOneProfile.Text;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Please select a file path first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            saveOneProfileToFile(filePath, xValues1, yValues1);
        }
        #endregion

        #region Move XYZ

        private const int DEFAULT_BTN_SPEED_PERCENT = 50;   // 0..100%
        private const double DEFAULT_BTN_STEP_MM = 0;     // mm
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            SetupChart(cartesianChartXY, out _xyTemplateSeries, out _xyMeasuredSeries);
            SetupChart(cartesianChart1, out _c1TemplateSeries, out _c1MeasuredSeries);

            LoadAvailablePorts();
        }
        private void SetupChart(WFChart chart,
                        out WpfLineSeries template,
                        out WpfLineSeries measured)
        {
            template = new WpfLineSeries
            {
                Title = "Template",
                Values = new ChartValues<ObservablePoint>(),
                Stroke = WpfBrushes.Blue,
                StrokeThickness = 2,
                PointGeometry = null
            };

            measured = new WpfLineSeries
            {
                Title = "Measured",
                Values = new ChartValues<ObservablePoint>(),
                Stroke = WpfBrushes.Red,
                StrokeThickness = 2,
                PointGeometry = null
            };

            chart.Series = new SeriesCollection { template, measured };

            // tuỳ chọn: tắt hiệu ứng/tooltip/zoom-pan cho mượt
            chart.DisableAnimations = true;
            chart.Hoverable = false;
            chart.DataTooltip = null;
            chart.Zoom = LiveCharts.ZoomingOptions.None;
            chart.Pan = LiveCharts.PanningOptions.None;
        }

        private void UpdateSeries(WpfLineSeries series, IList<double> xs, IList<double> ys)
        {
            if (series == null) return;

            // thread-safe khi gọi từ background:
            if (InvokeRequired) { BeginInvoke(new Action(() => UpdateSeries(series, xs, ys))); return; }

            series.Values.Clear();

            int n = Math.Min(xs?.Count ?? 0, ys?.Count ?? 0);
            for (int i = 0; i < n; i++)
            {
                double y = ys[i];
                if (double.IsNaN(y) || double.IsInfinity(y)) continue; // bỏ NaN/inf nếu có
                series.Values.Add(new ObservablePoint(xs[i], y));
            }
        }
        private void PlotTemplate(IList<double> x, IList<double> y, bool _)
        {
            UpdateSeries(_xyTemplateSeries, x, y);
            // nếu muốn vẽ cả chart thứ hai:
            UpdateSeries(_c1TemplateSeries, x, y);
        }

        private void PlotMeasured(IList<double> x, IList<double> y, bool _)
        {
            UpdateSeries(_xyMeasuredSeries, x, y);
            // nếu muốn vẽ cả chart thứ hai:
            UpdateSeries(_c1MeasuredSeries, x, y);
        }
        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            LoadAvailablePorts();
        }
        private void LoadAvailablePorts()
        {
            try
            {
                // Lấy danh sách cổng COM hiện có
                string[] portNames = SerialPort.GetPortNames();

                // Xóa danh sách cũ trước khi cập nhật
                comboBoxPorts.Items.Clear();

                // Nếu có cổng COM, thêm vào combobox
                if (portNames.Length > 0)
                {
                    comboBoxPorts.Items.AddRange(portNames);
                    comboBoxPorts.SelectedIndex = 0; // Chọn cổng đầu tiên mặc định
                }
                else
                {
                    comboBoxPorts.Items.Add("Không tìm thấy cổng COM");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi quét cổng COM: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem đã chọn cổng COM chưa
                if (comboBoxPorts.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn cổng COM trước khi kết nối.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (arduinoPort == null) arduinoPort = new SerialPort();
                // Nếu cổng đã mở, không cần mở lại
                if (arduinoPort.IsOpen)
                {
                    return;
                }

                // Thiết lập cổng kết nối
                arduinoPort.PortName = comboBoxPorts.SelectedItem.ToString();
                arduinoPort.BaudRate = 9600; // Đặt tốc độ truyền, có thể thay đổi theo Arduino
                arduinoPort.Encoding = System.Text.Encoding.ASCII; // thêm dòng này
                arduinoPort.NewLine = "\n";                        // thêm dòng này
                arduinoPort.Open(); // Mở cổng kết nối

                // Cập nhật UI
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                UpdateConnectionStatus(true);
                StartSerialReader();   // BẮT BUỘC gọi sau khi mở cổng
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Lỗi: Cổng COM đang bị chiếm dụng bởi một chương trình khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("Lỗi: Không thể truy cập cổng COM. Hãy kiểm tra lại kết nối.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                _serialStopping = true;              // báo dừng mọi vòng đọc
                System.Threading.Thread.Sleep(5);    // cho vòng đọc thoát
                StopSerialReader();
                if (arduinoPort != null && arduinoPort.IsOpen)
                    arduinoPort.Close();

                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                UpdateConnectionStatus(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _serialStopping = false;             // sẵn sàng cho lần kết nối sau
            }
        }
        private void StartSerialReader()
        {
            StopSerialReader(); // nếu có task cũ
            _serialCts = new CancellationTokenSource();
            arduinoPort.Encoding = System.Text.Encoding.ASCII;  // tránh lỗi decode
            _serialReaderTask = Task.Run(() => SerialReadLoopAsync(_serialCts.Token));
        }

        private void StopSerialReader()
        {
            try { _serialCts?.Cancel(); } catch { }
            try { _serialReaderTask?.Wait(200); } catch { }
            _serialReaderTask = null;
            _serialCts = null;
        }

        private async Task SerialReadLoopAsync(CancellationToken ct)
        {
            var sb = new System.Text.StringBuilder(256);
            var buf = new byte[256];

            while (!ct.IsCancellationRequested)
            {
                try
                {
                    if (arduinoPort == null || !arduinoPort.IsOpen)
                    {
                        await Task.Delay(50, ct);
                        continue;
                    }

                    // đọc async từ BaseStream (không block UI)
                    int n = await arduinoPort.BaseStream.ReadAsync(buf, 0, buf.Length, ct);
                    if (n <= 0) continue;

                    var s = System.Text.Encoding.ASCII.GetString(buf, 0, n);
                    foreach (char c in s)
                    {
                        if (c == '\n' || c == '\r')
                        {
                            var line = sb.ToString().Trim();
                            sb.Clear();
                            if (line.Length > 0) HandleOneLine(line); // xử lý từng dòng
                        }
                        else sb.Append(c);
                    }
                }
                catch (OperationCanceledException) { break; }
                catch (Exception)
                {
                    // cổng đóng / rút dây -> tạm nghỉ chút rồi đọc tiếp
                    await Task.Delay(50, ct);
                }
            }
        }

        private void HandleOneLine(string line)
        {
            // log ra listbox (UI thread)
            if (listBoxCommands.IsHandleCreated)
                listBoxCommands.BeginInvoke((Action)(() => {
                    listBoxCommands.Items.Add("Recv: " + line);
                    listBoxCommands.TopIndex = listBoxCommands.Items.Count - 1;
                }));

            // cập nhật label nếu là POS ...
            if (line.StartsWith("POS", StringComparison.OrdinalIgnoreCase))
            {
                if (TryParsePosLine(line, out var x, out var y, out var z))
                {
                    UpdatePoseLabelSafe(x, y, z);  // đã có sẵn UI update:contentReference[oaicite:1]{index=1}
                    lock (_poseLock) { _lastX = x; _lastY = y; _lastZ = z; }  // <-- THÊM
                }
                return;
            }

            // đánh thức ai đang “đợi OK”
            if (string.Equals(line, "OK", StringComparison.OrdinalIgnoreCase))
                _waitOkTcs?.TrySetResult(true);
            _rxLines.Enqueue(line);
        }
        private async Task<string> WaitForLineAsync(Func<string, bool> predicate, int timeoutMs, int pollDelayMs = 10)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                while (_rxLines.TryDequeue(out var s))
                {
                    if (predicate(s)) return s;
                }
                await Task.Delay(pollDelayMs);
            }
            return null;
        }

        private async Task<(double x, double y, double z)?> QueryPoseOnceAsync(int timeoutMs = 1000)
        {
            // gửi lệnh hỏi vị trí
            SendSerial("POS?"); // dùng hàm SendSerial sẵn có:contentReference[oaicite:3]{index=3}

            // đợi một dòng dạng POS...
            var line = await WaitForLineAsync(s => s.StartsWith("POS", StringComparison.OrdinalIgnoreCase), timeoutMs);
            if (line == null) return null;

            if (TryParsePosLine(line, out var x, out var y, out var z))
                return (x, y, z);

            return null;
        }
        private static bool Near(double a, double b, double tol) => Math.Abs(a - b) <= tol;

        private async Task<bool> WaitPositionAsync(
            double tx, double ty, double tz,
            double tol = 0.02,     // mm, tuỳ bạn
            int timeoutMs = 2000,  // tổng thời gian đợi
            int pollMs = 500       // tần suất hỏi POS?
        )
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            // cố dùng last pose sẵn có trước
            double lx, ly, lz;
            lock (_poseLock) { lx = _lastX; ly = _lastY; lz = _lastZ; }
            if (!double.IsNaN(lx) && Near(lx, tx, tol) && Near(ly, ty, tol) && Near(lz, tz, tol))
                return true;

            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                var pose = await QueryPoseOnceAsync(timeoutMs: Math.Min(pollMs, 500));
                if (pose.HasValue)
                {
                    var (x, y, z) = pose.Value;
                    if (Near(x, tx, tol) && Near(y, ty, tol) && Near(z, tz, tol))
                        return true;
                }
                await Task.Delay(pollMs);
            }
            return false;
        }
        private void UpdateConnectionStatus(bool isConnected)
        {
            if (isConnected)
            {
                lblConnectionStatus.Text = "Connected";
                lblConnectionStatus.ForeColor = Color.Green;
            }
            else
            {
                lblConnectionStatus.Text = "Disconnected";
                lblConnectionStatus.ForeColor = Color.Red;
            }
        }

        // Gửi chuỗi xuống Arduino và log
        // Gửi chuỗi xuống Arduino và log (KHÔNG đọc POS ở đây)
        private void SendSerial(string cmd)
        {
            if (arduinoPort != null && arduinoPort.IsOpen)
            {
                if (!cmd.EndsWith("\n")) cmd += "\n";
                arduinoPort.Write(cmd);
                LogMessage("Sent: " + cmd.Trim());
            }
            else
            {
                MessageBox.Show("Chưa kết nối Arduino.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdatePoseLabelSafe(double x, double y, double z)
        {
            string s = $"POS: X={x:0.###}  Y={y:0.###}  Z={z:0.###}";
            if (lblCurrentPose.InvokeRequired)
                lblCurrentPose.BeginInvoke((Action)(() => lblCurrentPose.Text = s));
            else
                lblCurrentPose.Text = s;
        }

        private void UpdatePoseLabelNA()
        {
            string s = "POS: N/A (không đọc được)";
            if (lblCurrentPose.InvokeRequired)
                lblCurrentPose.BeginInvoke((Action)(() => lblCurrentPose.Text = s));
            else
                lblCurrentPose.Text = s;
        }

        // Gửi 1 bước jog: SPD <percent> rồi JOG <axis><±mm>
        private async void SendJog(string axis, double deltaMm, int speedPercent)
        {
            int p = Math.Max(0, Math.Min(100, speedPercent));
            await SendSerialAsync("SPD " + p);
            string jog = string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "JOG {0}{1:0.###}", (axis ?? "X").ToUpperInvariant(), deltaMm);
            await SendSerialAsync(jog, expectOk: true, okTimeoutMs: 5000);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SendHomeCommand();
        }

        private async void SendHomeCommand()
        {
            await SendSerialAsync("HOME", expectOk: true, okTimeoutMs: 30000);
        }

        private void btnXp_Click(object sender, EventArgs e)
        {
            SendJog("X", +DEFAULT_BTN_STEP_MM, DEFAULT_BTN_SPEED_PERCENT); // 50% + 1mm
        }
        private void btnXm_Click(object sender, EventArgs e)
        {
            SendJog("X", -DEFAULT_BTN_STEP_MM, DEFAULT_BTN_SPEED_PERCENT);
        }
        private void btnYp_Click(object sender, EventArgs e)
        {
            SendJog("Y", +DEFAULT_BTN_STEP_MM, DEFAULT_BTN_SPEED_PERCENT);
        }
        private void btnYm_Click(object sender, EventArgs e)
        {
            SendJog("Y", -DEFAULT_BTN_STEP_MM, DEFAULT_BTN_SPEED_PERCENT);
        }
        private void btnZp_Click(object sender, EventArgs e)
        {
            SendJog("Z", +DEFAULT_BTN_STEP_MM, DEFAULT_BTN_SPEED_PERCENT);
        }
        private void btnZm_Click(object sender, EventArgs e)
        {
            SendJog("Z", -DEFAULT_BTN_STEP_MM, DEFAULT_BTN_SPEED_PERCENT);
        }


        private void LogMessage(string message)
        {
            listBoxCommands.Invoke((MethodInvoker)delegate
            {
                listBoxCommands.Items.Add($"{message}");

                // Tự động cuộn xuống dòng cuối cùng
                listBoxCommands.TopIndex = listBoxCommands.Items.Count - 1;
            });
        }
        private volatile bool _serialStopping = false;

        private string ReadLineWithTimeout(int ms = 1500)
        {
            // Trả về string (có thể rỗng) – KHÔNG ném exception
            var sb = new System.Text.StringBuilder();

            // kiểm tra cổng trước khi đọc
            if (arduinoPort == null || !arduinoPort.IsOpen) return "";

            int deadline = Environment.TickCount + ms;
            try
            {
                while (!_serialStopping && (ms <= 0 || Environment.TickCount < deadline))
                {
                    // nếu cổng đóng trong lúc đọc → thoát êm
                    if (arduinoPort == null || !arduinoPort.IsOpen) break;

                    // đọc những gì đang có
                    int available = 0;
                    try { available = arduinoPort.BytesToRead; }
                    catch (IOException) { break; }
                    catch (InvalidOperationException) { break; }

                    if (available > 0)
                    {
                        // đọc theo bytes để tránh lỗi encoder
                        var buf = new byte[Math.Min(available, 256)];
                        int n;
                        try { n = arduinoPort.Read(buf, 0, buf.Length); }
                        catch (TimeoutException) { n = 0; }
                        catch (IOException) { break; }
                        catch (InvalidOperationException) { break; }

                        if (n > 0)
                        {
                            // Serial của Arduino thường là ASCII -> dùng Encoding.ASCII cho chắc
                            var s = System.Text.Encoding.ASCII.GetString(buf, 0, n);

                            foreach (char c in s)
                            {
                                if (c == '\n' || c == '\r')
                                {
                                    var line = sb.ToString().Trim();
                                    if (!string.IsNullOrEmpty(line)) return line; // kết thúc 1 dòng
                                    sb.Clear(); // bỏ dòng rỗng, tiếp tục ghép
                                }
                                else
                                {
                                    sb.Append(c);
                                }
                            }
                        }
                    }

                    // nới CPU + bơm message để UI không đơ
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1);
                }
            }
            catch (IOException)
            {
                // cổng bị đóng khi đang đọc → trả về những gì có
            }
            catch (InvalidOperationException)
            {
                // SerialPort disposed → trả về những gì có
            }

            return sb.ToString().Trim(); // có thể rỗng nếu không nhận được gì
        }
        private bool TryGetCurrentPose(out double x, out double y, out double z)
        {
            x = y = z = 0;
            if (arduinoPort == null || !arduinoPort.IsOpen) return false;

            try { arduinoPort.DiscardInBuffer(); } catch { /* ignore */ }
            try { arduinoPort.WriteLine("GETPOS"); } catch { return false; }

            // cho MCU 1 nhịp rất ngắn để in ra
            System.Threading.Thread.Sleep(5);

            for (int i = 0; i < 5; i++)
            {
                var line = ReadLineWithTimeout(1500);
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (!line.StartsWith("POS", StringComparison.OrdinalIgnoreCase)) continue;

                var tokens = line.Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length >= 7 && tokens[0] == "POS" && tokens[1] == "X" && tokens[3] == "Y" && tokens[5] == "Z")
                {
                    if (double.TryParse(tokens[2], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var xx) &&
                        double.TryParse(tokens[4], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var yy) &&
                        double.TryParse(tokens[6], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var zz))
                    { x = xx; y = yy; z = zz; return true; }
                }
            }
            return false;
        }

        private async Task SendSerialAsync(string cmd, bool expectOk = false, int okTimeoutMs = 4000)
        {
            if (arduinoPort == null || !arduinoPort.IsOpen)
            {
                MessageBox.Show("Chưa kết nối Arduino.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!cmd.EndsWith("\n")) cmd += "\n";
            arduinoPort.Write(cmd);
            LogMessage("Sent: " + cmd.Trim());

            if (expectOk)
            {
                var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                _waitOkTcs = tcs;

                using (var cts = new CancellationTokenSource(okTimeoutMs))
                using (cts.Token.Register(() => tcs.TrySetCanceled()))
                {
                    try { await tcs.Task; }
                    catch { /* timeout: không sao, chỉ là không thấy OK */ }
                    finally { if (_waitOkTcs == tcs) _waitOkTcs = null; }
                }
            }
        }

        private bool TryParsePosLine(string line, out double x, out double y, out double z)
        {
            x = y = z = 0;
            var tokens = line.Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length >= 7 && tokens[0].Equals("POS", StringComparison.OrdinalIgnoreCase)
                && tokens[1] == "X" && tokens[3] == "Y" && tokens[5] == "Z")
            {
                return double.TryParse(tokens[2], System.Globalization.NumberStyles.Float,
                                       System.Globalization.CultureInfo.InvariantCulture, out x)
                    && double.TryParse(tokens[4], System.Globalization.NumberStyles.Float,
                                       System.Globalization.CultureInfo.InvariantCulture, out y)
                    && double.TryParse(tokens[6], System.Globalization.NumberStyles.Float,
                                       System.Globalization.CultureInfo.InvariantCulture, out z);
            }
            return false;
        }
        private void btnClearCommands_Click(object sender, EventArgs e)
        {
            listBoxCommands.Items.Clear();
        }

        #endregion

        #region Compare sample vs reality

        #region Load file

        private List<double> xValuesTemplate = new List<double>();
        private List<double> yValuesTemplate = new List<double>();

        private void LoadTemplateProfile(string filePath)
        {
            try
            {
                xValuesTemplate.Clear();
                yValuesTemplate.Clear();

                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('\t');
                        if (parts.Length >= 2 &&
                            double.TryParse(parts[0], out double x) &&
                            double.TryParse(parts[1], out double y))
                        {
                            xValuesTemplate.Add(x);
                            yValuesTemplate.Add(y);
                        }
                    }
                }

                // Vẽ đường biên dạng mẫu với màu Xanh dương
                PlotTemplateProfile(xValuesTemplate, yValuesTemplate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Draw sample

        private void PlotTemplateProfile(List<double> xValues, List<double> yValues)
        {
            if (cartesianChartXY.Series.Count == 0)
            {
                cartesianChartXY.Series.Clear(); // Xóa dữ liệu cũ trước khi vẽ
            }

            var templateSeries = new LineSeries
            {
                Values = new ChartValues<LiveCharts.Defaults.ObservablePoint>(),
                StrokeThickness = 2,
                PointGeometry = null,
                Stroke = System.Windows.Media.Brushes.Blue, // Màu Xanh dương cho mẫu
                Title = "Biên dạng mẫu"
            };

            for (int i = 0; i < xValues.Count; i++)
            {
                templateSeries.Values.Add(new LiveCharts.Defaults.ObservablePoint(xValues[i], yValues[i]));
            }

            cartesianChartXY.Series.Add(templateSeries);
        }

        #endregion

        #region Open and load fie sample

        private void btnOpenTemplateProfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Chọn file biên dạng mẫu"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadTemplateProfile(openFileDialog.FileName);
            }
        }

        #endregion

        #region Draw red sample

        private void PlotMeasuredProfile(List<double> xValues, List<double> yValues)
        {
            // Kiểm tra nếu đã có 2 đường, chỉ cập nhật đường thứ hai (màu đỏ)
            if (cartesianChartXY.Series.Count > 1)
            {
                var measuredSeries = (LineSeries)cartesianChartXY.Series[1];
                measuredSeries.Values.Clear();

                for (int i = 0; i < xValues.Count; i++)
                {
                    measuredSeries.Values.Add(new LiveCharts.Defaults.ObservablePoint(xValues[i], yValues[i]));
                }
            }
            else
            {
                // Thêm đường kiểm tra màu đỏ
                var measuredSeries = new LineSeries
                {
                    Values = new ChartValues<LiveCharts.Defaults.ObservablePoint>(),
                    StrokeThickness = 2,
                    PointGeometry = null,
                    Stroke = System.Windows.Media.Brushes.Red, // Màu Đỏ cho đường kiểm tra
                    Title = "Biên dạng kiểm tra"
                };

                for (int i = 0; i < xValues.Count; i++)
                {
                    measuredSeries.Values.Add(new LiveCharts.Defaults.ObservablePoint(xValues[i], yValues[i]));
                }

                cartesianChartXY.Series.Add(measuredSeries);
            }
        }

        private void btnLinkFileSample_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Chọn file biên dạng mẫu"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                linkFileSample.Text = openFileDialog.FileName; // Hiển thị đường dẫn trong TextBox
            }
        }

        private void drawSampleProfile_Click(object sender, EventArgs e)
        {
            string filePath = linkFileSample.Text.Trim();

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Vui lòng chọn một file hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadTemplateProfile(filePath);
        }



        #endregion

        #endregion

        private void SetSpeed(int p)
        {
            // clamp 0..100
            _speedPercent = Math.Max(0, Math.Min(100, p));
            if (txtSpeed != null) txtSpeed.Text = _speedPercent.ToString();

            // gửi sang Arduino áp tốc độ
            SendSerial("SPD " + _speedPercent);
        }

        private void SetDistance(double mm)
        {
            // không âm
            _distanceMm = Math.Max(0, mm);
            if (txtDistance != null) txtDistance.Text = _distanceMm.ToString("0.###");
        }

        private async void JogAxis(string axis, double deltaMm)
        {
            await SendSerialAsync("SPD " + _speedPercent);
            string cmd = "JOG " + axis + deltaMm.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture);
            await SendSerialAsync(cmd, expectOk: true);
        }

        private void TeachPoint(int idx)
        {
            // dừng AutoDraw để tránh giành resource khi đang Timer
            if (isUpdating) { updateTimer.Stop(); isUpdating = false; btnAutoDraw.Text = "START DRAW"; }

            // 1) lấy toạ độ hiện tại
            double x, y, z;
            if (!TryGetCurrentPose(out x, out y, out z))
            {
                MessageBox.Show("Không đọc được vị trí hiện tại (GETPOS).");
                return;
            }

            // 2) lấy một profile (đổ vào xValues1, yValues1)
            Print2D1();
            if (xValues1.Count == 0 || yValues1.Count == 0)
            {
                MessageBox.Show("Không lấy được profile (xValues1/yValues1 rỗng).");
                return;
            }

            // 3) lưu/ghi đè mẫu
            var pt = _template.Points.Find(p => p.Index == idx);
            if (pt == null)
            {
                pt = new PointTemplate { Index = idx };
                _template.Points.Add(pt);
            }
            pt.X = x; pt.Y = y; pt.Z = z;
            pt.ProfX = new List<double>(xValues1);
            pt.ProfY = new List<double>(yValues1);

            // 4) vẽ đường mẫu (xanh dương) lên chart chính
            PlotTemplate(pt.ProfX, pt.ProfY, true);

            MessageBox.Show($"Đã TEACH P{idx} @ ({x:0.###},{y:0.###},{z:0.###})");
        }
        private void btnPos1_Click(object s, EventArgs e) => TeachPoint(1);
        private void btnPos2_Click(object s, EventArgs e) => TeachPoint(2);
        private void btnPos3_Click(object s, EventArgs e) => TeachPoint(3);
        private void btnPos4_Click(object s, EventArgs e) => TeachPoint(4);

        private (int shift, double offset, double mae, double peak, List<double> alignedY)
    AlignByShiftAndOffset(List<double> measY, List<double> templY, int maxShiftPoints = 80)
        {
            int nT = templY?.Count ?? 0;
            int nM = measY?.Count ?? 0;
            if (nT == 0 || nM == 0)
                return (0, double.NaN, double.NaN, double.NaN, new List<double>());

            double bestMae = double.MaxValue;
            double bestPeak = double.MaxValue;
            int bestShift = 0;
            double bestOffset = 0;

            for (int s = -maxShiftPoints; s <= maxShiftPoints; s++)
            {
                int startT = Math.Max(0, -s);
                int startM = Math.Max(0, s);
                int len = Math.Min(nT - startT, nM - startM);
                if (len <= 10) continue;

                // Ước lượng offset tối ưu = mean(template - measured) trên phần overlap
                double sum = 0; int valid = 0;
                for (int i = 0; i < len; i++)
                {
                    double mv = measY[startM + i];
                    double tv = templY[startT + i];
                    if (double.IsNaN(mv) || double.IsNaN(tv) || double.IsInfinity(mv) || double.IsInfinity(tv)) continue;
                    sum += (tv - mv);
                    valid++;
                }
                if (valid == 0) continue;
                double offset = sum / valid;

                // Tính MAE & Peak với offset này
                double mae = 0, peak = 0; int cnt = 0;
                for (int i = 0; i < len; i++)
                {
                    double mv = measY[startM + i] + offset;
                    double tv = templY[startT + i];
                    if (double.IsNaN(mv) || double.IsNaN(tv) || double.IsInfinity(mv) || double.IsInfinity(tv)) continue;
                    double diff = Math.Abs(mv - tv);
                    mae += diff; if (diff > peak) peak = diff;
                    cnt++;
                }
                if (cnt == 0) continue;
                mae /= cnt;

                // Chọn phương án tốt nhất
                if (mae < bestMae || (Math.Abs(mae - bestMae) < 1e-9 && peak < bestPeak))
                {
                    bestMae = mae; bestPeak = peak; bestShift = s; bestOffset = offset;
                }
            }

            // Build measured đã căn chỉnh trên lưới template (không overlap thì gán NaN)
            var aligned = new List<double>(nT);
            for (int i = 0; i < nT; i++)
            {
                int j = i + bestShift; // measured index
                if (j >= 0 && j < nM) aligned.Add(measY[j] + bestOffset);
                else aligned.Add(double.NaN);
            }

            return (bestShift, bestOffset, bestMae, bestPeak, aligned);
        }

        private (JudgeResult res, (double mae, double peak, int shift, double offset) metrics, List<double> alignedY)
    JudgeWithAutoAlign(List<double> measY, List<double> templY, double maeThresh, double peakThresh, int maxShiftPts = 80)
        {
            if ((measY?.Count ?? 0) == 0 || (templY?.Count ?? 0) == 0)
                return (JudgeResult.NG, (double.NaN, double.NaN, 0, double.NaN), new List<double>());

            var r = AlignByShiftAndOffset(measY, templY, maxShiftPts);
            bool ok = (r.mae <= maeThresh) && (r.peak <= peakThresh);
            return (ok ? JudgeResult.OK : JudgeResult.NG, (r.mae, r.peak, r.shift, r.offset), r.alignedY);
        }

        private (JudgeResult res, (double mae, double peak) metrics) JudgeSimple(
            List<double> meas,
            List<double> templ,
            double maeThresh,
            double peakThresh)
        {
            int n = Math.Min(meas?.Count ?? 0, templ?.Count ?? 0);
            if (n <= 0)
                return (JudgeResult.NG, (double.NaN, double.NaN));

            double maeSum = 0.0;
            double peak = 0.0;
            int valid = 0;

            for (int i = 0; i < n; i++)
            {
                double mv = meas[i];
                double tv = templ[i];

                // Bỏ qua điểm lỗi
                if (double.IsNaN(mv) || double.IsNaN(tv) ||
                    double.IsInfinity(mv) || double.IsInfinity(tv))
                    continue;

                double diff = Math.Abs(mv - tv);
                maeSum += diff;
                if (diff > peak) peak = diff;
                valid++;
            }

            if (valid == 0)
                return (JudgeResult.NG, (double.NaN, double.NaN));

            double mae = maeSum / valid;

            bool ok = (mae <= maeThresh) && (peak <= peakThresh);
            return (ok ? JudgeResult.OK : JudgeResult.NG, (mae, peak));
        }

        private async Task RunAutoAsync()
        {
            var pts = new List<PointTemplate>(_template.Points);
            pts.Sort((a, b) => a.Index.CompareTo(b.Index));
            if (pts.Count == 0) { MessageBox.Show("Chưa TEACH điểm nào."); return; }

            // dừng AutoDraw nếu đang chạy
            if (isUpdating) { updateTimer.Stop(); isUpdating = false; btnAutoDraw.Text = "START DRAW"; }

            btnAutoMode.Enabled = false;
            try
            {
                foreach (var p in pts)
                {
                    // 1) GOTO và CHỜ OK từ Arduino (đảm bảo đã đứng yên)
                    await SendSerialAsync(
                        string.Format(CultureInfo.InvariantCulture,
                            "GOTO X{0:0.###} Y{1:0.###} Z{2:0.###}", p.X, p.Y, p.Z),
                        expectOk: true,
                        okTimeoutMs: 2000);

                    // 1b) (tuỳ chọn) xác minh vị trí: gửi "GETPOS" (hoặc "POS?") và kiểm tra sai lệch <= tol
                    var reached = await WaitPositionAsync(p.X, p.Y, p.Z, tol: 0.02, timeoutMs: 8000, pollMs: 150);
                    // nếu bạn tin rằng OK = đã đến đích, có thể bỏ khúc WaitPositionAsync

                    // 2) Đo 1 profile (KHÔNG vẽ trong hàm đo)
                    var (mx, my) = AcquireOneProfile();

                    // 3) So sánh + auto-align
                    var (res, metrics, alignedY) = JudgeWithAutoAlign(my, p.ProfY, 0.1, 1.0, 50);


                    // 4) Vẽ SAU khi so sánh: xanh = template, đỏ = measured (đã align)
                    PlotTemplate(p.ProfX, p.ProfY, true); // xanh – mẫu
                    PlotMeasured(p.ProfX, alignedY, false); // đỏ – measured đã căn chỉnh

                    // 5) Log kết quả
                    double stepMm = 0.02;
                    double shiftMm = metrics.shift * stepMm;
                    AddLog($"Align shift = {metrics.shift} pts (~{shiftMm:0.###} mm), " +
                           $"offsetY = {metrics.offset:0.###} mm, MAE = {metrics.mae:0.###}, " +
                           $"Peak = {metrics.peak:0.###}, Result = {res}");

                    // 6) Popup
                    var win = new ResultWindow();
                    win.SetData($"Position {p.Index}", p.ProfX, p.ProfY, p.ProfX, alignedY, res == JudgeResult.OK);
                    win.Show();

                    if (chkStopOnNG.Checked && res == JudgeResult.NG) break;
                    await Task.Delay(50);
                }
            }
            finally { btnAutoMode.Enabled = true; }
        }
        private async void btnAutoMode_Click(object sender, EventArgs e) => await RunAutoAsync();
        private (List<double> X, List<double> Y) AcquireOneProfile()
        {
            var profileInfo = new LJV7IF_PROFILE_INFO();
            var measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

            int profileDataSize = Define.MAX_PROFILE_COUNT +
                (Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / Marshal.SizeOf(typeof(int));
            var receiveBuffer = new int[profileDataSize];

            using (var pin = new PinnedObject(receiveBuffer))
            {
                Rc rc = (Rc)NativeMethods.LJV7IF_GetProfileAdvance(
                    Define.DEVICE_ID, ref profileInfo, pin.Pointer,
                    (uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))), measureData);
                if (!CheckReturnCode(rc)) return (new List<double>(), new List<double>());
            }

            var profile = new ProfileData(receiveBuffer, 0, profileInfo);

            var xs = new List<double>();
            var ys = new List<double>();
            for (int i = 0; i < profile.ProfDatas.Length; i++)
            {
                double y = profile.ProfDatas[i] / 100000.0;
                if (y < -100) continue; // bỏ outlier theo code cũ
                double x = -8.0 + i * 0.02;
                xs.Add(x);
                ys.Add(y);
            }
            return (xs, ys);
        }
        private async Task WaitMotionSettledAsync(int settleMs = 200)
        {
            await Task.Delay(settleMs); // tạm thời: chờ cơ học dừng
                                        // nâng cấp sau: đợi đến khi POS đổi < ngưỡng trong N lần đọc liên tiếp
        }
        private void SaveTemplateToJson()
        {
            var sfd = new SaveFileDialog
            {
                Filter = "Template (*.json)|*.json",
                FileName = string.IsNullOrEmpty(_templatePath) ? "teach.json" : Path.GetFileName(_templatePath),
                InitialDirectory = string.IsNullOrEmpty(_templatePath)
             ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
             : Path.GetDirectoryName(_templatePath)
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            // Nếu pictureBox có ảnh → xuất sidecar cạnh JSON
            string sidecarName = Path.GetFileNameWithoutExtension(sfd.FileName) + ".preview.png";
            string sidecarFull = Path.Combine(Path.GetDirectoryName(sfd.FileName), sidecarName);

            if (pictureBoxPreview.Image != null)
            {
                try
                {
                    using (var bmp = new Bitmap(pictureBoxPreview.Image))
                    {
                        bmp.Save(sidecarFull, ImageFormat.Png);
                    }

                    // Cập nhật vào template (relative path)
                    _template.ImagePath = sidecarName;
                    _template.ImageName = string.IsNullOrEmpty(lblImageName?.Text) ? sidecarName : lblImageName.Text;

                    // Bảo đảm có Base64 (để JSON luôn chứa ảnh)
                    using (var ms = new MemoryStream())
                    {
                        pictureBoxPreview.Image.Save(ms, ImageFormat.Png);
                        _template.ImageBase64 = Convert.ToBase64String(ms.ToArray());
                    }
                }
                catch
                {
                    // Không xoá info ảnh nếu lỗi vặt; ít nhất giữ Base64 đã gắn khi load ảnh
                }
            }
            
            // Ghi JSON
            var json = JsonConvert.SerializeObject(_template, Formatting.Indented);
            File.WriteAllText(sfd.FileName, json);

            _templatePath = sfd.FileName;
            if (lblTemplatePath != null) lblTemplatePath.Text = Path.GetFileName(_templatePath);

            MessageBox.Show("Đã lưu template + ảnh.\n- JSON: " + Path.GetFileName(sfd.FileName) +
                            (File.Exists(sidecarFull) ? "\n- Ảnh:  " + Path.GetFileName(sidecarFull) : ""));
        }
        private void LoadTemplateFromJson()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Template (*.json)|*.json|Tất cả (*.*)|*.*";
                if (!string.IsNullOrEmpty(_templatePath))
                    ofd.InitialDirectory = Path.GetDirectoryName(_templatePath);

                if (ofd.ShowDialog() != DialogResult.OK) return;

                var json = File.ReadAllText(ofd.FileName);
                _template = JsonConvert.DeserializeObject<TemplateSet>(json) ?? new TemplateSet();

                _templatePath = ofd.FileName;
                if (lblTemplatePath != null)
                    lblTemplatePath.Text = Path.GetFileName(_templatePath);

                // ---- Nạp ảnh: 1) Base64  2) ImagePath (relative)  3) Sidecar auto ----
                // Dọn ảnh cũ
                if (pictureBoxPreview.Image != null)
                {
                    pictureBoxPreview.Image.Dispose();
                    pictureBoxPreview.Image = null;
                }

                bool loaded = false;

                // 1) Base64
                try
                {
                    if (!string.IsNullOrEmpty(_template.ImageBase64))
                    {
                        var bytes = Convert.FromBase64String(_template.ImageBase64);
                        using (var ms = new MemoryStream(bytes))
                        {
                            pictureBoxPreview.Image = new Bitmap(ms);
                        }
                        loaded = true;
                    }
                }
                catch { /* bỏ qua, thử cách khác */ }

                // 2) ImagePath (relative)
                if (!loaded && !string.IsNullOrEmpty(_template.ImagePath))
                {
                    try
                    {
                        string imgFull = Path.Combine(Path.GetDirectoryName(_templatePath), _template.ImagePath);
                        if (File.Exists(imgFull))
                        {
                            // Load không khóa file
                            using (var fs = new FileStream(imgFull, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            using (var ms2 = new MemoryStream())
                            {
                                fs.CopyTo(ms2);
                                ms2.Position = 0;
                                pictureBoxPreview.Image = new Bitmap(ms2);
                            }
                            loaded = true;
                        }
                    }
                    catch { /* ignore */ }
                }

                // 3) Sidecar auto: <basename>.preview.png (phòng khi JSON cũ chưa có ImagePath)
                if (!loaded)
                {
                    string guess = Path.Combine(
                        Path.GetDirectoryName(_templatePath),
                        Path.GetFileNameWithoutExtension(_templatePath) + ".preview.png");
                    if (File.Exists(guess))
                    {
                        try
                        {
                            using (var fs = new FileStream(guess, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            using (var ms3 = new MemoryStream())
                            {
                                fs.CopyTo(ms3);
                                ms3.Position = 0;
                                pictureBoxPreview.Image = new Bitmap(ms3);
                            }
                            _template.ImagePath = Path.GetFileName(guess); // cập nhật vào template cho lần sau
                            loaded = true;
                        }
                        catch { /* ignore */ }
                    }
                }

                // Cập nhật label tên ảnh
                if (lblImageName != null)
                {
                    if (loaded)
                        lblImageName.Text = string.IsNullOrEmpty(_template.ImageName)
                            ? (!string.IsNullOrEmpty(_template.ImagePath) ? _template.ImagePath : "(embedded image)")
                            : _template.ImageName;
                    else
                        lblImageName.Text = "(no image)";
                }

                // Vẽ lại chart nếu cần
                var first = _template.Points.Count > 0 ? _template.Points[0] : null;
                if (first != null) PlotScatterChart(first.ProfX, first.ProfY, true);

                MessageBox.Show("Đã mở template" + (loaded ? " + ảnh." : ". (không tìm thấy ảnh)"));
            }
        }
        private void SetTeachMode(bool teach)
        {
            _teachMode = teach;

            // enable nhóm TEACH, disable nhóm AUTO
            grpTeach.Enabled = teach;
            btnAutoMode.Enabled = teach; // nếu muốn khoá nút Auto khi đang Teach

            if (teach)
            {
                lblMode.Text = "TEACH MODE";
                lblMode.ForeColor = Color.White; 
                lblMode.BackColor = Color.Blue;
            }
            else
            {
                lblMode.Text = "AUTO MODE";
                lblMode.ForeColor = Color.Red;
                lblMode.BackColor = Color.Blue;

            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|Tất cả (*.*)|*.*";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                // Hiển thị ảnh lên pictureBoxPreview (không khoá file)
                if (pictureBoxPreview.Image != null)
                {
                    pictureBoxPreview.Image.Dispose();
                    pictureBoxPreview.Image = null;
                }
                using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    pictureBoxPreview.Image = new Bitmap(ms);
                }
                pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;

                // Cập nhật label
                if (lblImageName != null) lblImageName.Text = Path.GetFileName(ofd.FileName);

                // GẮN THẲNG VÀO TEMPLATE (để lần Save sau không rỗng)
                _lastLoadedImageFullPath = ofd.FileName;

                // 2 lựa chọn:
                // a) Lưu đường dẫn tương đối (sẽ chuẩn hoá khi Save)
                _template.ImagePath = Path.GetFileName(ofd.FileName);
                _template.ImageName = Path.GetFileName(ofd.FileName);

                // b) Nhúng Base64 luôn (để JSON mới chắc chắn có ảnh)
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        pictureBoxPreview.Image.Save(ms, ImageFormat.Png);
                        _template.ImageBase64 = Convert.ToBase64String(ms.ToArray());
                    }
                }
                catch { /* ignore */ }
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxPreview.Image != null)
            {
                pictureBoxPreview.Image.Dispose();
                pictureBoxPreview.Image = null;
            }
            lblImageName.Text = "(no image)";
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveTemplateToJson();
        }

        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            LoadTemplateFromJson();
        }

        private async void BtnScanArea_Click(object sender, EventArgs e)
        {
            // ====== CẤU HÌNH ======
            const string CMD_GETPOS = "GETPOS";
            const double posTolMm = 0.05;

            // ====== helpers SERIAL / PARSE / MOVE ======
            async Task WaitOkAsync(int timeoutMs = 10000)
            {
                var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                using (var cts = new CancellationTokenSource(timeoutMs))
                {
                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            while (!cts.IsCancellationRequested)
                            {
                                if (_rxLines.TryDequeue(out var line))
                                {
                                    if (line.Trim().Equals("OK", StringComparison.OrdinalIgnoreCase))
                                    {
                                        tcs.TrySetResult(true);
                                        return;
                                    }
                                }
                                await Task.Delay(5);
                            }
                            tcs.TrySetException(new TimeoutException("Timeout đợi OK"));
                        }
                        catch (Exception ex) { tcs.TrySetException(ex); }
                    });
                    await tcs.Task;
                }
            }

            void SendCmd(string cmd)
            {
                if (arduinoPort == null || !arduinoPort.IsOpen)
                    throw new InvalidOperationException("Arduino chưa kết nối.");
                arduinoPort.WriteLine(cmd);
            }

            bool TryParseXY(string line, out double x, out double y)
            {
                x = y = double.NaN;

                var rx = new Regex(@"X\s*[:=]?\s*(-?\d+(?:\.\d+)?)\s*[,;\s]+Y\s*[:=]?\s*(-?\d+(?:\.\d+)?)",
                                   RegexOptions.IgnoreCase);
                var m = rx.Match(line);
                if (m.Success &&
                    double.TryParse(m.Groups[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out x) &&
                    double.TryParse(m.Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out y))
                {
                    return true;
                }

                var rxNum = new Regex(@"-?\d+(?:\.\d+)?");
                var mm = rxNum.Matches(line);
                if (mm.Count >= 2 &&
                    double.TryParse(mm[0].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out x) &&
                    double.TryParse(mm[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out y))
                {
                    return true;
                }
                return false;
            }

            async Task<(double X, double Y)> QueryPosAsync(int timeoutMs = 2000)
            {
                SendCmd(CMD_GETPOS);
                var sw = Stopwatch.StartNew();
                while (sw.ElapsedMilliseconds < timeoutMs)
                {
                    while (_rxLines.TryDequeue(out var line))
                    {
                        if (TryParseXY(line, out var xx, out var yy))
                            return (xx, yy);
                    }
                    await Task.Delay(10);
                }
                throw new TimeoutException("Timeout đợi trả vị trí từ Arduino.");
            }

            async Task EnsureAtAsync(double xTarget, double yTarget, double tolMm = posTolMm, int timeoutMs = 6000)
            {
                var sw = Stopwatch.StartNew();
                while (sw.ElapsedMilliseconds < timeoutMs)
                {
                    var p = await QueryPosAsync(1500);
                    if (Math.Abs(p.X - xTarget) <= tolMm && Math.Abs(p.Y - yTarget) <= tolMm) return;
                    await Task.Delay(80);
                }
                throw new TimeoutException(
                    string.Format(CultureInfo.InvariantCulture,
                        "Không xác nhận được vị trí ({0:0.###},{1:0.###}) trong thời gian cho phép.", xTarget, yTarget));
            }

            async Task MoveToAndEnsureAsync(double xMm, double yMm, int speedPercent, bool scanOn, double tolMm = posTolMm)
            {
                SendCmd(scanOn ? "SCAN_ON" : "SCAN_OFF");
                SendCmd(string.Format(CultureInfo.InvariantCulture,
                    "MOVE X{0:0.###} Y{1:0.###} S{2}", xMm, yMm, speedPercent));
                await WaitOkAsync();
                await EnsureAtAsync(xMm, yMm, tolMm);
            }

            // ====== Lấy 1 profile bằng GetProfileAdvance -> trả về mảng double (mm) ======
            double[] TryGetOneProfileMm()
            {
                var profileInfo = new LJV7IF_PROFILE_INFO();
                var measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

                // Kích thước buffer: MAX_PROFILE_COUNT + header/footer theo mẫu Keyence
                int profileDataSize = Define.MAX_PROFILE_COUNT +
                    (Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / Marshal.SizeOf(typeof(int));

                var receiveBuffer = new int[profileDataSize];

                using (var pin = new PinnedObject(receiveBuffer))
                {
                    Rc rc = (Rc)NativeMethods.LJV7IF_GetProfileAdvance(
                        Define.DEVICE_ID,
                        ref profileInfo,
                        pin.Pointer,
                        (uint)(receiveBuffer.Length * Marshal.SizeOf(typeof(int))),
                        measureData);

                    if (rc != Rc.Ok) return null;
                }

                // Dùng lớp ProfileData sẵn có để bóc data
                var pd = new ProfileData(receiveBuffer, 0, profileInfo);
                if (pd.ProfDatas == null || pd.ProfDatas.Length == 0) return null;

                // Scale và lọc invalid (< -100 sau khi scale)
                var list = new List<double>(pd.ProfDatas.Length);
                for (int i = 0; i < pd.ProfDatas.Length; i++)
                {
                    double v = pd.ProfDatas[i] / 100000.0; // mm
                    if (v < -100) continue;                // loại điểm invalid
                    list.Add(v);
                }
                return list.Count > 0 ? list.ToArray() : null;
            }

            // Thu profile mỗi periodMs (ms) trong khi đang chạy
            async Task<List<double[]>> CollectProfilesWhileMovingAsync(int periodMs, CancellationToken token)
            {
                var profiles = new List<double[]>();
                if (periodMs < 1) periodMs = 1;

                double ticksPerMs = (double)Stopwatch.Frequency / 1000.0;
                long nextTick = Stopwatch.GetTimestamp();

                while (!token.IsCancellationRequested)
                {
                    // Mỗi chu kỳ chỉ lấy 1 profile (time-based sampling)
                    var p = TryGetOneProfileMm();
                    if (p != null) profiles.Add(p);

                    nextTick += (long)(periodMs * ticksPerMs);
                    var now = Stopwatch.GetTimestamp();
                    int waitMs = (int)Math.Max(0, (nextTick - now) / ticksPerMs);

                    try { await Task.Delay(waitMs, token); }
                    catch (TaskCanceledException) { break; }
                }
                return profiles;
            }

            // ====== LOGIC QUÉT ======
            try
            {
                if (isUpdating) return;
                isUpdating = true;

                // 1) tham số người dùng
                double W = double.Parse(txtSizeW.Text, CultureInfo.InvariantCulture); // span theo X
                double H = double.Parse(txtSizeH.Text, CultureInfo.InvariantCulture); // span theo Y (mỗi đường)
                int speed = _speedPercent;
                double stepX = _scanStepMm;
                int periodMs = Math.Max(1, int.Parse(txtLinePeriod.Text));            // <<< THÊM DÒNG NÀY
                double x0 = 0, y0 = 0;

                // 2) chọn file lưu: một file .txt chứa TẤT CẢ
                string outPath = null;
                using (var sfd = new SaveFileDialog
                {
                    Title = "Chọn nơi lưu dữ liệu quét",
                    Filter = "Text file (*.txt)|*.txt",
                    FileName = "scan_lines.txt",
                    OverwritePrompt = true
                })
                {
                    if (sfd.ShowDialog(this) != DialogResult.OK) { MessageBox.Show("Đã hủy lưu."); return; }
                    outPath = sfd.FileName;
                }

                // 3) bắt đầu ghi (xóa cũ nếu có)
                using (var sw = new StreamWriter(outPath, false, Encoding.UTF8))
                {
                    for (double x = x0; x <= x0 + W + 1e-6; x += stepX)
                    {
                        double yStart = y0;
                        double yEnd = y0 + H;

                        // (a) tới đầu đường, tắt scan, xác nhận
                        await MoveToAndEnsureAsync(x, yStart, speed, scanOn: false);

                        // (b) bật scan, chạy tới cuối đường và THU THẬP theo periodMs
                        List<double[]> profiles;
                        using (var cts = new CancellationTokenSource())
                        {
                            var collectorTask = CollectProfilesWhileMovingAsync(periodMs, cts.Token); // <<< SỬA Ở ĐÂY

                            SendCmd("SCAN_ON");
                            SendCmd(string.Format(CultureInfo.InvariantCulture,
                                "MOVE X{0:0.###} Y{1:0.###} S{2}", x, yEnd, speed));

                            await WaitOkAsync(); // đợi MOVE xong
                            cts.Cancel();
                            try { profiles = await collectorTask; }
                            catch { profiles = new List<double[]>(); }
                            SendCmd("SCAN_OFF");

                            // (c) xác nhận vị trí cuối đường
                            await EnsureAtAsync(x, yEnd, posTolMm);
                        }

                        // (d) GHI THEO ĐỊNH DẠNG YÊU CẦU
                        sw.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "X{0:0.###}Y{1:0.###}-X{2:0.###}Y{3:0.###}", x, yStart, x, yEnd));

                        foreach (var arr in profiles)
                        {
                            var line = string.Join(", ", arr.Select(v => v.ToString("0.####", CultureInfo.InvariantCulture)).ToArray());
                            sw.WriteLine(line);
                        }
                        sw.WriteLine();
                        sw.Flush();
                    }
                }

                // 4) mở file sau khi xong
                System.Diagnostics.Process.Start("notepad.exe", outPath);
                MessageBox.Show("Đã lưu dữ liệu vào: " + outPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi quét: " + ex.Message);
            }
            finally
            {
                isUpdating = false;
            }
        }
    }
}
