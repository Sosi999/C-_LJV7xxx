namespace LJV7_DllSampleAll.Forms
{
	partial class GetErrorForm
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
			this._txtboxErrCnt = new System.Windows.Forms.TextBox();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnOk = new System.Windows.Forms.Button();
			this._lblErrCnt = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _txtboxErrCnt
			// 
			this._txtboxErrCnt.Location = new System.Drawing.Point(180, 13);
			this._txtboxErrCnt.Name = "_txtboxErrCnt";
			this._txtboxErrCnt.Size = new System.Drawing.Size(75, 21);
			this._txtboxErrCnt.TabIndex = 12;
			this._txtboxErrCnt.Text = "10";
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(180, 62);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 25);
			this._btnCancel.TabIndex = 11;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnOk
			// 
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(75, 62);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 25);
			this._btnOk.TabIndex = 10;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = true;
			// 
			// _lblErrCnt
			// 
			this._lblErrCnt.Location = new System.Drawing.Point(17, 10);
			this._lblErrCnt.Name = "_lblErrCnt";
			this._lblErrCnt.Size = new System.Drawing.Size(157, 38);
			this._lblErrCnt.TabIndex = 9;
			this._lblErrCnt.Text = "Amount of system \r\nerror information to receive";
			// 
			// GetErrorForm
			// 
			this.AcceptButton = this._btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(266, 102);
			this.Controls.Add(this._txtboxErrCnt);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Controls.Add(this._lblErrCnt);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GetErrorForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Get the detailed error information.";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _txtboxErrCnt;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.Label _lblErrCnt;
	}
}