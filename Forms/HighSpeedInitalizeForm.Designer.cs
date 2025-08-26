namespace LJV7_DllSampleAll.Forms
{
	partial class HighSpeedInitalizeForm
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
			this._txtboxPortHighSpeed = new System.Windows.Forms.TextBox();
			this._lblPortHighSpeed = new System.Windows.Forms.Label();
			this._lblProfileCnt = new System.Windows.Forms.Label();
			this._txtboxProfileCnt = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// _btnOk
			// 
			this._btnOk.Location = new System.Drawing.Point(217, 166);
			this._btnOk.Size = new System.Drawing.Size(75, 25);
			// 
			// _btnCancel
			// 
			this._btnCancel.Location = new System.Drawing.Point(314, 166);
			this._btnCancel.Size = new System.Drawing.Size(75, 25);
			// 
			// _txtboxPortHighSpeed
			// 
			this._txtboxPortHighSpeed.Location = new System.Drawing.Point(118, 103);
			this._txtboxPortHighSpeed.Name = "_txtboxPortHighSpeed";
			this._txtboxPortHighSpeed.Size = new System.Drawing.Size(157, 21);
			this._txtboxPortHighSpeed.TabIndex = 10;
			this._txtboxPortHighSpeed.Text = "24692";
			// 
			// _lblPortHighSpeed
			// 
			this._lblPortHighSpeed.AutoSize = true;
			this._lblPortHighSpeed.Location = new System.Drawing.Point(12, 106);
			this._lblPortHighSpeed.Name = "_lblPortHighSpeed";
			this._lblPortHighSpeed.Size = new System.Drawing.Size(90, 13);
			this._lblPortHighSpeed.TabIndex = 11;
			this._lblPortHighSpeed.Text = "Port (high speed)";
			// 
			// _lblProfileCnt
			// 
			this._lblProfileCnt.AutoSize = true;
			this._lblProfileCnt.Location = new System.Drawing.Point(12, 138);
			this._lblProfileCnt.Name = "_lblProfileCnt";
			this._lblProfileCnt.Size = new System.Drawing.Size(95, 13);
			this._lblProfileCnt.TabIndex = 12;
			this._lblProfileCnt.Text = "Number of profiles";
			// 
			// _txtboxProfileCnt
			// 
			this._txtboxProfileCnt.Location = new System.Drawing.Point(118, 134);
			this._txtboxProfileCnt.Name = "_txtboxProfileCnt";
			this._txtboxProfileCnt.Size = new System.Drawing.Size(64, 21);
			this._txtboxProfileCnt.TabIndex = 13;
			this._txtboxProfileCnt.Text = "1";
			// 
			// HighSpeedInitalizeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(417, 204);
			this.Controls.Add(this._txtboxProfileCnt);
			this.Controls.Add(this._lblProfileCnt);
			this.Controls.Add(this._txtboxPortHighSpeed);
			this.Controls.Add(this._lblPortHighSpeed);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "HighSpeedInitalizeForm";
			this.Text = "HighSpeedInitalize";
			this.Controls.SetChildIndex(this._btnCancel, 0);
			this.Controls.SetChildIndex(this._btnOk, 0);
			this.Controls.SetChildIndex(this._lblPortHighSpeed, 0);
			this.Controls.SetChildIndex(this._txtboxPortHighSpeed, 0);
			this.Controls.SetChildIndex(this._lblProfileCnt, 0);
			this.Controls.SetChildIndex(this._txtboxProfileCnt, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _txtboxPortHighSpeed;
		private System.Windows.Forms.Label _lblPortHighSpeed;
		private System.Windows.Forms.Label _lblProfileCnt;
		private System.Windows.Forms.TextBox _txtboxProfileCnt;
	}
}