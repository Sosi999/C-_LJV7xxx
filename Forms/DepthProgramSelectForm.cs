//----------------------------------------------------------------------------- 
// <copyright file="DepthProgramSelectForm.cs" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LJV7_DllSampleAll.Forms
{
	public partial class DepthProgramSelectForm : Form
	{
		#region Field
		/// <summary>
		/// Level
		/// </summary>
		private byte _depth;

		/// <summary>
		/// Specified program
		/// </summary>
		private byte _target;
		#endregion

		#region Property

		/// <summary>
		/// Specify to what level the settings written for modification will be reflected (LJ7IF_SETTING_DEPTH).
		/// </summary>
		public byte Depth
		{
			get { return _depth; }
		}

		/// <summary>
		/// Specify the setting that is the target for initialization (LJ7IF_INIT_SETTING_TARGET).
		/// </summary>
		public byte Target
		{
			get { return _target; }
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
					_depth = Convert.ToByte(_txtboxDepth.Text, 16);
					_target = Convert.ToByte(_txtboxTargetProgram.Text, 16);
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
		/// <param name="isDepthVisible">Level control display setting</param>
		/// <param name="isTargetVisible">Specified program control display setting</param>
		public DepthProgramSelectForm(bool isDepthVisible, bool isTargetVisible)
		{
			InitializeComponent();

			// Field initialization
			_depth = 0;
			_target = 0;

			// Control display control
			_lblHexDepth.Visible = isDepthVisible;
			_txtboxDepth.Visible = isDepthVisible;
			_lblDepth.Visible = isDepthVisible;
			_lblDepthDescription.Visible = isDepthVisible;
			_lblHexTarget.Visible = isTargetVisible;
			_txtboxTargetProgram.Visible = isTargetVisible;
			_lblTargetProgram.Visible = isTargetVisible;
			_lblTargetDescription.Visible = isTargetVisible;
		}
		#endregion
	}
}
