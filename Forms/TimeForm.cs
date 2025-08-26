//----------------------------------------------------------------------------- 
// <copyright file="TimeForm.cs" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LJV7_DllSampleAll.Forms
{
	public partial class TimeForm : Form
	{
		#region Field
		/// <summary>
		/// The date and time to set
		/// </summary>
		private LJV7IF_TIME _time;
		#endregion

		#region Property
		/// <summary>
		/// The date and time to set
		/// </summary>
		public LJV7IF_TIME Time
		{
			get { return _time; }
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
					_time.byYear = Convert.ToByte(_txtboxYear.Text);
					_time.byMonth = Convert.ToByte(_txtboxMonth.Text);
					_time.byDay = Convert.ToByte(_txtboxDay.Text);
					_time.byHour = Convert.ToByte(_txtboxHour.Text);
					_time.byMinute = Convert.ToByte(_txtboxMinute.Text);
					_time.bySecond = Convert.ToByte(_txtboxSecond.Text);
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
		public TimeForm()
		{
			InitializeComponent();

			// Field initialization
			_time = new LJV7IF_TIME();
		}
		#endregion
	}
}
