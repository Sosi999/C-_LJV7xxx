//----------------------------------------------------------------------------- 
// <copyright file="GetBatchProfileForm.cs" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LJV7_DllSampleAll.Forms
{
	public partial class GetBatchProfileForm : Form
	{
		#region Field
		/// <summary>
		/// High-speed mode get profile request structure (batch measurement: on)
		/// </summary>
		private LJV7IF_GET_BATCH_PROFILE_REQ _req;
		#endregion

		#region Property
		/// <summary>
		/// High-speed mode get profile request structure (batch measurement: on)
		/// </summary>
		public LJV7IF_GET_BATCH_PROFILE_REQ Req
		{
			get { return _req; }
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
					_req.byTargetBank = Convert.ToByte(_txtboxTargetBank.Text, 16);
					_req.byPosMode = Convert.ToByte(_txtboxPosMode.Text, 16);
					_req.dwGetBatchNo = Convert.ToUInt32(_txtboxGetBatchNo.Text);
					_req.dwGetProfNo = Convert.ToUInt32(_txtboxGetProfNo.Text);
					_req.byGetProfCnt = Convert.ToByte(_txtboxGetProfCnt.Text);
					_req.byErase = Convert.ToByte(_txtboxErase.Text);
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
		public GetBatchProfileForm()
		{
			InitializeComponent();

			// Field initialization
			_req = new LJV7IF_GET_BATCH_PROFILE_REQ();
		}
		#endregion
	}
}
