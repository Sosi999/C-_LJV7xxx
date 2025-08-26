namespace LJV7_DllSampleAll.Forms
{
	partial class PreStartHighSpeedForm
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
			this._txtboxSendPos = new System.Windows.Forms.TextBox();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnOk = new System.Windows.Forms.Button();
			this._lblSendPos = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _txtboxSendPos
			// 
			this._txtboxSendPos.Location = new System.Drawing.Point(129, 20);
			this._txtboxSendPos.Name = "_txtboxSendPos";
			this._txtboxSendPos.Size = new System.Drawing.Size(107, 21);
			this._txtboxSendPos.TabIndex = 16;
			this._txtboxSendPos.Text = "2";
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(177, 54);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 25);
			this._btnCancel.TabIndex = 15;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnOk
			// 
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(80, 54);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 25);
			this._btnOk.TabIndex = 14;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = true;
			// 
			// _lblSendPos
			// 
			this._lblSendPos.AutoSize = true;
			this._lblSendPos.Location = new System.Drawing.Point(21, 23);
			this._lblSendPos.Name = "_lblSendPos";
			this._lblSendPos.Size = new System.Drawing.Size(97, 13);
			this._lblSendPos.TabIndex = 13;
			this._lblSendPos.Text = "Send start position";
			// 
			// PreStartHighSpeedForm
			// 
			this.AcceptButton = this._btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(282, 90);
			this.Controls.Add(this._txtboxSendPos);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Controls.Add(this._lblSendPos);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PreStartHighSpeedForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "High-speed communication start request";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _txtboxSendPos;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.Label _lblSendPos;
	}
}