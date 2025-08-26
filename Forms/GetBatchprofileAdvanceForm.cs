//----------------------------------------------------------------------------- 
// <copyright file="GetBatchprofileAdvanceForm.cs" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LJV7_DllSampleAll.Forms
{
	public partial class GetBatchprofileAdvanceForm : Form
	{
		#region Field
		/// <summary>
		/// Advanced mode get profile request structure (batch measurement: on)
		/// </summary>
		private LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ _req;
		#endregion

		#region Property
		/// <summary>
		/// Advanced mode get profile request structure (batch measurement: on)
		/// </summary>
		public LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ Req
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
					_req.byPosMode = Convert.ToByte(_txtboxPosMode.Text, 16);
					_req.dwGetBatchNo = Convert.ToUInt32(_txtboxGetBatchNo.Text);
					_req.dwGetProfNo = Convert.ToUInt32(_txtboxGetProfNo.Text);
					_req.byGetProfCnt = Convert.ToByte(_txtboxGetProfCnt.Text);
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
		public GetBatchprofileAdvanceForm()
		{
			InitializeComponent();

			// Field initialization
			_req = new LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ();
		}
		#endregion
	}
}
