using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LJV7_IF_Test.Forms
{
    public partial class AutoZeroForm : Form
    {
        #region フィールド
        /// <summary>
        /// オートゼロON要求、OFF要求
        /// </summary>
        private byte _onOff;

        /// <summary>
        /// 処理対象とするとOUTをビットで指定
        /// </summary>
        private uint _out;
        #endregion

        #region プロパティ
        /// <summary>
        /// ０以外：オートゼロＯＮ要求、０：ＯＦＦ要求
        /// </summary>
        public byte OnOff
        {
            get { return _onOff; }
        }

        /// <summary>
        /// 処理対象とするとOUTをビットで指定
        /// </summary>
        public uint Out
        {
            get { return _out; }
        }
        #endregion

        #region イベント
        /// <summary>
        /// クローズ開始イベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    _onOff = Convert.ToByte(_txtboxOnOff.Text);
                    _out += _chkboxBit1.Checked ? (uint)1 : (uint)0;
                    _out += _chkboxBit2.Checked ? (uint)(1 << 1) : (uint)0;
                    _out += _chkboxBit3.Checked ? (uint)(1 << 2) : (uint)0;
                    _out += _chkboxBit4.Checked ? (uint)(1 << 3) : (uint)0;
                    _out += _chkboxBit5.Checked ? (uint)(1 << 4) : (uint)0;
                    _out += _chkboxBit6.Checked ? (uint)(1 << 5) : (uint)0;
                    _out += _chkboxBit7.Checked ? (uint)(1 << 6) : (uint)0;
                    _out += _chkboxBit8.Checked ? (uint)(1 << 7) : (uint)0;
                    _out += _chkboxBit9.Checked ? (uint)(1 << 8) : (uint)0;
                    _out += _chkboxBit10.Checked ? (uint)(1 << 9) : (uint)0;
                    _out += _chkboxBit11.Checked ? (uint)(1 << 10) : (uint)0;
                    _out += _chkboxBit12.Checked ? (uint)(1 << 11) : (uint)0;
                    _out += _chkboxBit13.Checked ? (uint)(1 << 12) : (uint)0;
                    _out += _chkboxBit14.Checked ? (uint)(1 << 13) : (uint)0;
                    _out += _chkboxBit15.Checked ? (uint)(1 << 14) : (uint)0;
                    _out += _chkboxBit16.Checked ? (uint)(1 << 15) : (uint)0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                    e.Cancel = true;
                    return;
                }
            }

            base.OnClosing(e);
        }
        #endregion

        #region メソッド
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AutoZeroForm(bool isOnOffVisible)
        {
            InitializeComponent();

            // フィールド初期化
            _onOff = 0;
            _out = 0;

            // コントロール表示制御
            _lblOnOff.Visible = isOnOffVisible;
            _txtboxOnOff.Visible = isOnOffVisible;
            _lblOnOffDescription.Visible = isOnOffVisible;
        }
        #endregion
    }
}
