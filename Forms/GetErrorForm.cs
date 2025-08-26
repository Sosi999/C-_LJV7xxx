//----------------------------------------------------------------------------- 
// <copyright file="GetErrorForm.cs" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LJV7_DllSampleAll.Forms
{
	public partial class GetErrorForm : Form
	{
		#region Field
		/// <summary>
		/// Maximum number of system errors to receive
		/// </summary>
		private byte _rcvMax;
		#endregion

		#region Property
		
		/// <summary>
		/// Specify the maximum amount of system error information to receive.
		/// </summary>
		public byte RcvMax
		{
			get { return _rcvMax; }
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
					_rcvMax = Convert.ToByte(_txtboxErrCnt.Text);
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
		public GetErrorForm()
		{
			InitializeComponent();

			// Field initialization
			_rcvMax = 0;
		}
		#endregion
	}
}
