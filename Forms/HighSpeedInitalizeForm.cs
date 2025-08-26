//----------------------------------------------------------------------------- 
// <copyright file="HighSpeedInitalizeForm.cs" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LJV7_DllSampleAll.Forms
{
	public partial class HighSpeedInitalizeForm : OpenEthernetForm
	{
		#region Field
		/// <summary>
		/// Port number (high speed)
		/// </summary>
		private ushort _highSpeedPortNo;

		/// <summary>
		/// Number of profiles
		/// </summary>
		private uint _profileCnt;
		#endregion

		#region Property
		/// <summary>
		/// Port number (high speed)
		/// </summary>
		public ushort HighSpeedPortNo
		{
			get { return _highSpeedPortNo; }
		}

		/// <summary>
		/// Number of profiles
		/// </summary>
		public uint ProfileCnt
		{
			get { return _profileCnt; }
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
					_highSpeedPortNo = Convert.ToUInt16(_txtboxPortHighSpeed.Text);
					_profileCnt = Convert.ToUInt32(_txtboxProfileCnt.Text);
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
		/// <param name="isEtherVisible">Ethernet settings display setting</param>
		public HighSpeedInitalizeForm(bool isEtherVisible)
		{
			InitializeComponent();

			// Field initialization
			_highSpeedPortNo = 0;
			_profileCnt = 0;
			
			// Control display setting
			SetControlVisible(isEtherVisible);
		}

		/// <summary>
		/// Control display setting
		/// </summary>
		/// <param name="isVisible"></param>
		protected override void SetControlVisible(bool isVisible)
		{
			_lblPortHighSpeed.Visible = isVisible;
			_txtboxPortHighSpeed.Visible = isVisible;

			base.SetControlVisible(isVisible);
		}
		#endregion
	}
}
