namespace LJV7_DllSampleAll.Forms
{
	partial class GetStorageBatchProfileForm
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
			this._txtboxGetBatchTopProfNo = new System.Windows.Forms.TextBox();
			this._txtboxGetBatchNo = new System.Windows.Forms.TextBox();
			this._txtboxSurface = new System.Windows.Forms.TextBox();
			this._lblGetBatchTopProfNo = new System.Windows.Forms.Label();
			this._lblGetBatchNo = new System.Windows.Forms.Label();
			this._lblSurface = new System.Windows.Forms.Label();
			this._txtboxGetProfCnt = new System.Windows.Forms.TextBox();
			this._lblGetProfCnt = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(268, 168);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 25);
			this._btnCancel.TabIndex = 5;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnOk
			// 
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(177, 168);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 25);
			this._btnOk.TabIndex = 4;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = true;
			// 
			// _txtboxGetBatchTopProfNo
			// 
			this._txtboxGetBatchTopProfNo.Location = new System.Drawing.Point(12, 87);
			this._txtboxGetBatchTopProfNo.Name = "_txtboxGetBatchTopProfNo";
			this._txtboxGetBatchTopProfNo.Size = new System.Drawing.Size(100, 21);
			this._txtboxGetBatchTopProfNo.TabIndex = 2;
			this._txtboxGetBatchTopProfNo.Text = "1";
			// 
			// _txtboxGetBatchNo
			// 
			this._txtboxGetBatchNo.Location = new System.Drawing.Point(12, 50);
			this._txtboxGetBatchNo.Name = "_txtboxGetBatchNo";
			this._txtboxGetBatchNo.Size = new System.Drawing.Size(100, 21);
			this._txtboxGetBatchNo.TabIndex = 1;
			this._txtboxGetBatchNo.Text = "0";
			// 
			// _txtboxSurface
			// 
			this._txtboxSurface.Location = new System.Drawing.Point(12, 13);
			this._txtboxSurface.Name = "_txtboxSurface";
			this._txtboxSurface.Size = new System.Drawing.Size(100, 21);
			this._txtboxSurface.TabIndex = 0;
			this._txtboxSurface.Text = "0";
			// 
			// _lblGetBatchTopProfNo
			// 
			this._lblGetBatchTopProfNo.AutoSize = true;
			this._lblGetBatchTopProfNo.Location = new System.Drawing.Point(126, 81);
			this._lblGetBatchTopProfNo.Name = "_lblGetBatchTopProfNo";
			this._lblGetBatchTopProfNo.Size = new System.Drawing.Size(208, 26);
			this._lblGetBatchTopProfNo.TabIndex = 29;
			this._lblGetBatchTopProfNo.Text = "From what profile number \r\nin the batch do you want to get the data?";
			// 
			// _lblGetBatchNo
			// 
			this._lblGetBatchNo.AutoSize = true;
			this._lblGetBatchNo.Location = new System.Drawing.Point(126, 53);
			this._lblGetBatchNo.Name = "_lblGetBatchNo";
			this._lblGetBatchNo.Size = new System.Drawing.Size(111, 13);
			this._lblGetBatchNo.TabIndex = 28;
			this._lblGetBatchNo.Text = "Batch number to read";
			// 
			// _lblSurface
			// 
			this._lblSurface.AutoSize = true;
			this._lblSurface.Location = new System.Drawing.Point(126, 16);
			this._lblSurface.Name = "_lblSurface";
			this._lblSurface.Size = new System.Drawing.Size(122, 13);
			this._lblSurface.TabIndex = 27;
			this._lblSurface.Text = "Storage surface to read";
			// 
			// _txtboxGetProfCnt
			// 
			this._txtboxGetProfCnt.Location = new System.Drawing.Point(12, 129);
			this._txtboxGetProfCnt.Name = "_txtboxGetProfCnt";
			this._txtboxGetProfCnt.Size = new System.Drawing.Size(100, 21);
			this._txtboxGetProfCnt.TabIndex = 3;
			this._txtboxGetProfCnt.Text = "1";
			// 
			// _lblGetProfCnt
			// 
			this._lblGetProfCnt.AutoSize = true;
			this._lblGetProfCnt.Location = new System.Drawing.Point(126, 137);
			this._lblGetProfCnt.Name = "_lblGetProfCnt";
			this._lblGetProfCnt.Size = new System.Drawing.Size(133, 13);
			this._lblGetProfCnt.TabIndex = 33;
			this._lblGetProfCnt.Text = "Number of profiles to read";
			// 
			// GetStorageBatchProfileForm
			// 
			this.AcceptButton = this._btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(360, 204);
			this.Controls.Add(this._txtboxGetProfCnt);
			this.Controls.Add(this._lblGetProfCnt);
			this.Controls.Add(this._txtboxGetBatchTopProfNo);
			this.Controls.Add(this._txtboxGetBatchNo);
			this.Controls.Add(this._txtboxSurface);
			this.Controls.Add(this._lblGetBatchTopProfNo);
			this.Controls.Add(this._lblGetBatchNo);
			this.Controls.Add(this._lblSurface);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GetStorageBatchProfileForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GetStorageBatchProfileForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.TextBox _txtboxGetBatchTopProfNo;
		private System.Windows.Forms.TextBox _txtboxGetBatchNo;
		private System.Windows.Forms.TextBox _txtboxSurface;
		private System.Windows.Forms.Label _lblGetBatchTopProfNo;
		private System.Windows.Forms.Label _lblGetBatchNo;
		private System.Windows.Forms.Label _lblSurface;
		private System.Windows.Forms.TextBox _txtboxGetProfCnt;
		private System.Windows.Forms.Label _lblGetProfCnt;
	}
}