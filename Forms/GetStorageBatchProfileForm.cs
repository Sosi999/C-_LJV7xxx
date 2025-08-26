//----------------------------------------------------------------------------- 
// <copyright file="GetStorageBatchProfileForm.c" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LJV7_DllSampleAll.Forms
{
	public partial class GetStorageBatchProfileForm : Form
	{
		#region Field
		/// <summary>
		/// Get batch profile storage request structure
		/// </summary>
		private LJV7IF_GET_BATCH_PROFILE_STORAGE_REQ _req;
		#endregion

		#region Property
		/// <summary>
		/// Get batch profile storage request structure Property
		/// </summary>
		public LJV7IF_GET_BATCH_PROFILE_STORAGE_REQ Req
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
					_req.dwSurface = Convert.ToUInt32(_txtboxSurface.Text);
					_req.dwGetBatchNo = Convert.ToUInt32(_txtboxGetBatchNo.Text);
					_req.dwGetBatchTopProfNo = Convert.ToUInt32(_txtboxGetBatchTopProfNo.Text);
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
		public GetStorageBatchProfileForm()
		{
			InitializeComponent();

			_req = new LJV7IF_GET_BATCH_PROFILE_STORAGE_REQ();
		}
		#endregion
	}
}
