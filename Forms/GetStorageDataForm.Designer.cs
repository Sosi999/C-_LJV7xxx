namespace LJV7_DllSampleAll.Forms
{
	partial class GetStorageDataForm
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
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnOk = new System.Windows.Forms.Button();
			this._lblSurface = new System.Windows.Forms.Label();
			this._lblStartNo = new System.Windows.Forms.Label();
			this._lblDataCnt = new System.Windows.Forms.Label();
			this._txtboxSurface = new System.Windows.Forms.TextBox();
			this._txtboxStartNo = new System.Windows.Forms.TextBox();
			this._txtboxDataCnt = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(219, 130);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 25);
			this._btnCancel.TabIndex = 4;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnOk
			// 
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(128, 130);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 25);
			this._btnOk.TabIndex = 3;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = true;
			// 
			// _lblSurface
			// 
			this._lblSurface.AutoSize = true;
			this._lblSurface.Location = new System.Drawing.Point(126, 16);
			this._lblSurface.Name = "_lblSurface";
			this._lblSurface.Size = new System.Drawing.Size(122, 13);
			this._lblSurface.TabIndex = 21;
			this._lblSurface.Text = "Storage surface to read";
			// 
			// _lblStartNo
			// 
			this._lblStartNo.AutoSize = true;
			this._lblStartNo.Location = new System.Drawing.Point(126, 57);
			this._lblStartNo.Name = "_lblStartNo";
			this._lblStartNo.Size = new System.Drawing.Size(172, 13);
			this._lblStartNo.TabIndex = 22;
			this._lblStartNo.Text = "Data number to start reading from";
			// 
			// _lblDataCnt
			// 
			this._lblDataCnt.AutoSize = true;
			this._lblDataCnt.Location = new System.Drawing.Point(126, 93);
			this._lblDataCnt.Name = "_lblDataCnt";
			this._lblDataCnt.Size = new System.Drawing.Size(123, 13);
			this._lblDataCnt.TabIndex = 23;
			this._lblDataCnt.Text = "Number of items to read";
			// 
			// _txtboxSurface
			// 
			this._txtboxSurface.Location = new System.Drawing.Point(12, 13);
			this._txtboxSurface.Name = "_txtboxSurface";
			this._txtboxSurface.Size = new System.Drawing.Size(100, 21);
			this._txtboxSurface.TabIndex = 0;
			this._txtboxSurface.Text = "0";
			// 
			// _txtboxStartNo
			// 
			this._txtboxStartNo.Location = new System.Drawing.Point(12, 50);
			this._txtboxStartNo.Name = "_txtboxStartNo";
			this._txtboxStartNo.Size = new System.Drawing.Size(100, 21);
			this._txtboxStartNo.TabIndex = 1;
			this._txtboxStartNo.Text = "0";
			// 
			// _txtboxDataCnt
			// 
			this._txtboxDataCnt.Location = new System.Drawing.Point(12, 90);
			this._txtboxDataCnt.Name = "_txtboxDataCnt";
			this._txtboxDataCnt.Size = new System.Drawing.Size(100, 21);
			this._txtboxDataCnt.TabIndex = 2;
			this._txtboxDataCnt.Text = "1";
			// 
			// GetStorageDataForm
			// 
			this.AcceptButton = this._btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(317, 170);
			this.Controls.Add(this._txtboxDataCnt);
			this.Controls.Add(this._txtboxStartNo);
			this.Controls.Add(this._txtboxSurface);
			this.Controls.Add(this._lblDataCnt);
			this.Controls.Add(this._lblStartNo);
			this.Controls.Add(this._lblSurface);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GetStorageDataForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GetStorageData";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.Label _lblSurface;
		private System.Windows.Forms.Label _lblStartNo;
		private System.Windows.Forms.Label _lblDataCnt;
		private System.Windows.Forms.TextBox _txtboxSurface;
		private System.Windows.Forms.TextBox _txtboxStartNo;
		private System.Windows.Forms.TextBox _txtboxDataCnt;
	}
}