namespace LJV7_DllSampleAll.Forms
{
	partial class ClearErrorForm
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
			this._lblClearErrCode = new System.Windows.Forms.Label();
			this._txtboxErrCode = new System.Windows.Forms.TextBox();
			this._lblHexErrCode = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(198, 62);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 25);
			this._btnCancel.TabIndex = 33;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnOk
			// 
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(102, 62);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 25);
			this._btnOk.TabIndex = 32;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = true;
			this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
			// 
			// _lblClearErrCode
			// 
			this._lblClearErrCode.AutoSize = true;
			this._lblClearErrCode.Location = new System.Drawing.Point(110, 21);
			this._lblClearErrCode.Name = "_lblClearErrCode";
			this._lblClearErrCode.Size = new System.Drawing.Size(155, 13);
			this._lblClearErrCode.TabIndex = 34;
			this._lblClearErrCode.Text = "Error code of the error to clear";
			// 
			// _txtboxErrCode
			// 
			this._txtboxErrCode.Location = new System.Drawing.Point(33, 16);
			this._txtboxErrCode.MaxLength = 4;
			this._txtboxErrCode.Name = "_txtboxErrCode";
			this._txtboxErrCode.Size = new System.Drawing.Size(71, 21);
			this._txtboxErrCode.TabIndex = 35;
			this._txtboxErrCode.Text = "0084";
			// 
			// _lblHexErrCode
			// 
			this._lblHexErrCode.AutoSize = true;
			this._lblHexErrCode.Location = new System.Drawing.Point(12, 21);
			this._lblHexErrCode.Name = "_lblHexErrCode";
			this._lblHexErrCode.Size = new System.Drawing.Size(19, 13);
			this._lblHexErrCode.TabIndex = 37;
			this._lblHexErrCode.Text = "0x";
			// 
			// ClearErrorForm
			// 
			this.AcceptButton = this._btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(292, 106);
			this.Controls.Add(this._lblHexErrCode);
			this.Controls.Add(this._txtboxErrCode);
			this.Controls.Add(this._lblClearErrCode);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ClearErrorForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Clear the error";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.Label _lblClearErrCode;
		private System.Windows.Forms.TextBox _txtboxErrCode;
		private System.Windows.Forms.Label _lblHexErrCode;
	}
}