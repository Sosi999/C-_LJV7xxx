//----------------------------------------------------------------------------- 
// <copyright file="PreStartHighSpeedForm.cs" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LJV7_DllSampleAll.Forms
{
	public partial class PreStartHighSpeedForm : Form
	{
		#region Field
		/// <summary>
		/// High-speed communication start request structure
		/// </summary>
		private LJV7IF_HIGH_SPEED_PRE_START_REQ _req;
		#endregion

		#region Property
		/// <summary>
		/// High-speed communication start request structure
		/// </summary>
		public LJV7IF_HIGH_SPEED_PRE_START_REQ Req
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
					_req.bySendPos = Convert.ToByte(_txtboxSendPos.Text);
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
		public PreStartHighSpeedForm()
		{
			InitializeComponent();

			// Field initialization
			_req = new LJV7IF_HIGH_SPEED_PRE_START_REQ();
		}
		#endregion
	}
}
