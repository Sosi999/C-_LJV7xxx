//----------------------------------------------------------------------------- 
// <copyright file="OutSelectForm" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LJV7_DllSampleAll.Forms
{
	public partial class OutSelectForm : Form
	{
		#region Field
		/// <summary>
		/// Auto zero on request and off request
		/// </summary>
		private byte _onOff;

		/// <summary>
		/// The bits of the parameter are used to specify the processing target OUTs.
		/// </summary>
		private uint _out;
		#endregion

		#region Property
		/// <summary>
		/// Other than 0: auto zero on request, 0: auto zero off request
		/// </summary>
		public byte OnOff
		{
			get { return _onOff; }
		}

		/// <summary>
		/// The bits of the parameter are used to specify the processing target OUTs.
		/// </summary>
		public uint Out
		{
			get { return _out; }
		}
		#endregion

		#region Event
		/// <summary>
		/// Close start event
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

		#region Method
		/// <summary>
		/// Constructor
		/// </summary>
		public OutSelectForm(bool isOnOffVisible)
		{
			InitializeComponent();

			// Field initialization
			_onOff = 0;
			_out = 0;

			// Control display control
			_lblOnOff.Visible = isOnOffVisible;
			_txtboxOnOff.Visible = isOnOffVisible;
			_lblOnOffDescription.Visible = isOnOffVisible;
		}
		#endregion
	}
}
