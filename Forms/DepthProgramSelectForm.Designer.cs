namespace LJV7_DllSampleAll.Forms
{
	partial class DepthProgramSelectForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._txtboxDepth = new System.Windows.Forms.TextBox();
			this._lblDepth = new System.Windows.Forms.Label();
			this._lblTargetProgram = new System.Windows.Forms.Label();
			this._txtboxTargetProgram = new System.Windows.Forms.TextBox();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnOk = new System.Windows.Forms.Button();
			this._lblDepthDescription = new System.Windows.Forms.Label();
			this._lblHexDepth = new System.Windows.Forms.Label();
			this._lblTargetDescription = new System.Windows.Forms.Label();
			this._lblHexTarget = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _txtboxDepth
			// 
			this._txtboxDepth.Location = new System.Drawing.Point(51, 17);
			this._txtboxDepth.Name = "_txtboxDepth";
			this._txtboxDepth.Size = new System.Drawing.Size(81, 21);
			this._txtboxDepth.TabIndex = 26;
			this._txtboxDepth.Text = "00";
			// 
			// _lblDepth
			// 
			this._lblDepth.AutoSize = true;
			this._lblDepth.Location = new System.Drawing.Point(138, 21);
			this._lblDepth.Name = "_lblDepth";
			this._lblDepth.Size = new System.Drawing.Size(32, 13);
			this._lblDepth.TabIndex = 25;
			this._lblDepth.Text = "Level";
			// 
			// _lblTargetProgram
			// 
			this._lblTargetProgram.AutoSize = true;
			this._lblTargetProgram.Location = new System.Drawing.Point(138, 121);
			this._lblTargetProgram.Name = "_lblTargetProgram";
			this._lblTargetProgram.Size = new System.Drawing.Size(93, 13);
			this._lblTargetProgram.TabIndex = 27;
			this._lblTargetProgram.Text = "Specified program";
			// 
			// _txtboxTargetProgram
			// 
			this._txtboxTargetProgram.Location = new System.Drawing.Point(51, 118);
			this._txtboxTargetProgram.Name = "_txtboxTargetProgram";
			this._txtboxTargetProgram.Size = new System.Drawing.Size(78, 21);
			this._txtboxTargetProgram.TabIndex = 28;
			this._txtboxTargetProgram.Text = "00";
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(279, 233);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 25);
			this._btnCancel.TabIndex = 31;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnOk
			// 
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(183, 233);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 25);
			this._btnOk.TabIndex = 30;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = true;
			// 
			// _lblDepthDescription
			// 
			this._lblDepthDescription.AutoSize = true;
			this._lblDepthDescription.Location = new System.Drawing.Point(21, 46);
			this._lblDepthDescription.Name = "_lblDepthDescription";
			this._lblDepthDescription.Size = new System.Drawing.Size(232, 52);
			this._lblDepthDescription.TabIndex = 32;
			this._lblDepthDescription.Text = "Level (specified with LJV7IF_SETTING_DEPTH) \r\n 0x00  Write settings memory  \r\n 0x" +
				"01  Running memory   \r\n 0x02  Save memory \r\n";
			// 
			// _lblHexDepth
			// 
			this._lblHexDepth.AutoSize = true;
			this._lblHexDepth.Location = new System.Drawing.Point(28, 21);
			this._lblHexDepth.Name = "_lblHexDepth";
			this._lblHexDepth.Size = new System.Drawing.Size(19, 13);
			this._lblHexDepth.TabIndex = 33;
			this._lblHexDepth.Text = "0x";
			// 
			// _lblTargetDescription
			// 
			this._lblTargetDescription.AutoSize = true;
			this._lblTargetDescription.Location = new System.Drawing.Point(18, 150);
			this._lblTargetDescription.Name = "_lblTargetDescription";
			this._lblTargetDescription.Size = new System.Drawing.Size(324, 65);
			this._lblTargetDescription.TabIndex = 34;
			this._lblTargetDescription.Text = "Specified program (specified with LJV7IF_INIT_SETTING_TARGET)\r\n 0x00 program 0\r\n " +
				"0x01 program 1\r\n ...\r\n 0x0F program 15";
			// 
			// _lblHexTarget
			// 
			this._lblHexTarget.AutoSize = true;
			this._lblHexTarget.Location = new System.Drawing.Point(28, 122);
			this._lblHexTarget.Name = "_lblHexTarget";
			this._lblHexTarget.Size = new System.Drawing.Size(19, 13);
			this._lblHexTarget.TabIndex = 35;
			this._lblHexTarget.Text = "0x";
			// 
			// DepthProgramSelectForm
			// 
			this.AcceptButton = this._btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(378, 272);
			this.Controls.Add(this._lblHexTarget);
			this.Controls.Add(this._lblTargetDescription);
			this.Controls.Add(this._lblHexDepth);
			this.Controls.Add(this._lblDepthDescription);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Controls.Add(this._txtboxTargetProgram);
			this.Controls.Add(this._lblTargetProgram);
			this.Controls.Add(this._txtboxDepth);
			this.Controls.Add(this._lblDepth);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DepthProgramSelectForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Program settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _txtboxDepth;
		private System.Windows.Forms.Label _lblDepth;
		private System.Windows.Forms.Label _lblTargetProgram;
		private System.Windows.Forms.TextBox _txtboxTargetProgram;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.Label _lblDepthDescription;
		private System.Windows.Forms.Label _lblHexDepth;
		private System.Windows.Forms.Label _lblTargetDescription;
		private System.Windows.Forms.Label _lblHexTarget;
	}
}