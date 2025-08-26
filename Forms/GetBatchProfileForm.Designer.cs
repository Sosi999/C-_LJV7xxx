namespace LJV7_DllSampleAll.Forms
{
	partial class GetBatchProfileForm
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
			this._lblEraseDescription = new System.Windows.Forms.Label();
			this._lblErase = new System.Windows.Forms.Label();
			this._txtboxErase = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this._txtboxPosModeDescription = new System.Windows.Forms.Label();
			this._lblTargetBankDescription = new System.Windows.Forms.Label();
			this._txtboxGetProfCnt = new System.Windows.Forms.TextBox();
			this._lblGetProfCnt = new System.Windows.Forms.Label();
			this._txtboxGetProfNo = new System.Windows.Forms.TextBox();
			this._lblGetProfNo = new System.Windows.Forms.Label();
			this._txtboxPosMode = new System.Windows.Forms.TextBox();
			this._lblPosMode = new System.Windows.Forms.Label();
			this._txtboxTargetBank = new System.Windows.Forms.TextBox();
			this._lblTargetBank = new System.Windows.Forms.Label();
			this._txtboxGetBatchNo = new System.Windows.Forms.TextBox();
			this._lblGetBatchNo = new System.Windows.Forms.Label();
			this._lblProfileDescription = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _btnCancel
			// 
			this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(364, 423);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 25);
			this._btnCancel.TabIndex = 7;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnOk
			// 
			this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(274, 423);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 25);
			this._btnOk.TabIndex = 6;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = true;
			// 
			// _lblEraseDescription
			// 
			this._lblEraseDescription.AutoSize = true;
			this._lblEraseDescription.Location = new System.Drawing.Point(23, 381);
			this._lblEraseDescription.Name = "_lblEraseDescription";
			this._lblEraseDescription.Size = new System.Drawing.Size(221, 26);
			this._lblEraseDescription.TabIndex = 64;
			this._lblEraseDescription.Text = "0: Do not erase the batches that were read.\r\n1: Erase the batches that were read." +
				"";
			// 
			// _lblErase
			// 
			this._lblErase.AutoSize = true;
			this._lblErase.Location = new System.Drawing.Point(96, 361);
			this._lblErase.Name = "_lblErase";
			this._lblErase.Size = new System.Drawing.Size(138, 13);
			this._lblErase.TabIndex = 63;
			this._lblErase.Text = "Already read indication flag";
			// 
			// _txtboxErase
			// 
			this._txtboxErase.Location = new System.Drawing.Point(21, 358);
			this._txtboxErase.Name = "_txtboxErase";
			this._txtboxErase.Size = new System.Drawing.Size(69, 21);
			this._txtboxErase.TabIndex = 5;
			this._txtboxErase.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 281);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(323, 26);
			this.label1.TabIndex = 61;
			this.label1.Text = "When the profile position specification is [0x02: Specify position], \r\nspecify th" +
				"e number of the profile to get.";
			// 
			// _txtboxPosModeDescription
			// 
			this._txtboxPosModeDescription.AutoSize = true;
			this._txtboxPosModeDescription.Location = new System.Drawing.Point(23, 151);
			this._txtboxPosModeDescription.Name = "_txtboxPosModeDescription";
			this._txtboxPosModeDescription.Size = new System.Drawing.Size(217, 52);
			this._txtboxPosModeDescription.TabIndex = 60;
			this._txtboxPosModeDescription.Text = "0x00: From current\r\n0x02: Specify position\r\n0x03: From current after batch commit" +
				"ment\r\n0x04: Current only";
			// 
			// _lblTargetBankDescription
			// 
			this._lblTargetBankDescription.AutoSize = true;
			this._lblTargetBankDescription.Location = new System.Drawing.Point(23, 87);
			this._lblTargetBankDescription.Name = "_lblTargetBankDescription";
			this._lblTargetBankDescription.Size = new System.Drawing.Size(116, 26);
			this._lblTargetBankDescription.TabIndex = 59;
			this._lblTargetBankDescription.Text = "0x00: Active surface\r\n0x01: Inactive surface";
			// 
			// _txtboxGetProfCnt
			// 
			this._txtboxGetProfCnt.Location = new System.Drawing.Point(21, 320);
			this._txtboxGetProfCnt.Name = "_txtboxGetProfCnt";
			this._txtboxGetProfCnt.Size = new System.Drawing.Size(69, 21);
			this._txtboxGetProfCnt.TabIndex = 4;
			this._txtboxGetProfCnt.Text = "1";
			// 
			// _lblGetProfCnt
			// 
			this._lblGetProfCnt.AutoSize = true;
			this._lblGetProfCnt.Location = new System.Drawing.Point(96, 323);
			this._lblGetProfCnt.Name = "_lblGetProfCnt";
			this._lblGetProfCnt.Size = new System.Drawing.Size(220, 13);
			this._lblGetProfCnt.TabIndex = 57;
			this._lblGetProfCnt.Text = "Number of profiles to request the acquisition";
			// 
			// _txtboxGetProfNo
			// 
			this._txtboxGetProfNo.Location = new System.Drawing.Point(21, 257);
			this._txtboxGetProfNo.Name = "_txtboxGetProfNo";
			this._txtboxGetProfNo.Size = new System.Drawing.Size(69, 21);
			this._txtboxGetProfNo.TabIndex = 3;
			this._txtboxGetProfNo.Text = "0";
			// 
			// _lblGetProfNo
			// 
			this._lblGetProfNo.AutoSize = true;
			this._lblGetProfNo.Location = new System.Drawing.Point(96, 260);
			this._lblGetProfNo.Name = "_lblGetProfNo";
			this._lblGetProfNo.Size = new System.Drawing.Size(321, 13);
			this._lblGetProfNo.TabIndex = 55;
			this._lblGetProfNo.Text = "From what number profile do you want to start acquiring profiles?";
			// 
			// _txtboxPosMode
			// 
			this._txtboxPosMode.Location = new System.Drawing.Point(21, 127);
			this._txtboxPosMode.Name = "_txtboxPosMode";
			this._txtboxPosMode.Size = new System.Drawing.Size(69, 21);
			this._txtboxPosMode.TabIndex = 1;
			this._txtboxPosMode.Text = "00";
			// 
			// _lblPosMode
			// 
			this._lblPosMode.AutoSize = true;
			this._lblPosMode.Location = new System.Drawing.Point(96, 130);
			this._lblPosMode.Name = "_lblPosMode";
			this._lblPosMode.Size = new System.Drawing.Size(191, 13);
			this._lblPosMode.TabIndex = 53;
			this._lblPosMode.Text = "Get bank position specification method";
			// 
			// _txtboxTargetBank
			// 
			this._txtboxTargetBank.Location = new System.Drawing.Point(21, 63);
			this._txtboxTargetBank.Name = "_txtboxTargetBank";
			this._txtboxTargetBank.Size = new System.Drawing.Size(69, 21);
			this._txtboxTargetBank.TabIndex = 0;
			this._txtboxTargetBank.Text = "00";
			// 
			// _lblTargetBank
			// 
			this._lblTargetBank.AutoSize = true;
			this._lblTargetBank.Location = new System.Drawing.Point(96, 69);
			this._lblTargetBank.Name = "_lblTargetBank";
			this._lblTargetBank.Size = new System.Drawing.Size(145, 13);
			this._lblTargetBank.TabIndex = 51;
			this._lblTargetBank.Text = "Get profile bank specification";
			// 
			// _txtboxGetBatchNo
			// 
			this._txtboxGetBatchNo.Location = new System.Drawing.Point(21, 216);
			this._txtboxGetBatchNo.Name = "_txtboxGetBatchNo";
			this._txtboxGetBatchNo.Size = new System.Drawing.Size(69, 21);
			this._txtboxGetBatchNo.TabIndex = 2;
			this._txtboxGetBatchNo.Text = "0";
			// 
			// _lblGetBatchNo
			// 
			this._lblGetBatchNo.AutoSize = true;
			this._lblGetBatchNo.Location = new System.Drawing.Point(96, 219);
			this._lblGetBatchNo.Name = "_lblGetBatchNo";
			this._lblGetBatchNo.Size = new System.Drawing.Size(318, 13);
			this._lblGetBatchNo.TabIndex = 66;
			this._lblGetBatchNo.Text = "What is the number of the batch that contains the profile to get?";
			// 
			// _lblProfileDescription
			// 
			this._lblProfileDescription.AutoSize = true;
			this._lblProfileDescription.Location = new System.Drawing.Point(23, 10);
			this._lblProfileDescription.Name = "_lblProfileDescription";
			this._lblProfileDescription.Size = new System.Drawing.Size(395, 26);
			this._lblProfileDescription.TabIndex = 67;
			this._lblProfileDescription.Text = "From what number profile do you want to start acquiring profiles : ushort format " +
				"\r\nother than that above : byte format";
			// 
			// GetBatchProfileForm
			// 
			this.AcceptButton = this._btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(465, 460);
			this.Controls.Add(this._lblProfileDescription);
			this.Controls.Add(this._txtboxGetBatchNo);
			this.Controls.Add(this._lblGetBatchNo);
			this.Controls.Add(this._lblEraseDescription);
			this.Controls.Add(this._lblErase);
			this.Controls.Add(this._txtboxErase);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._txtboxPosModeDescription);
			this.Controls.Add(this._lblTargetBankDescription);
			this.Controls.Add(this._txtboxGetProfCnt);
			this.Controls.Add(this._lblGetProfCnt);
			this.Controls.Add(this._txtboxGetProfNo);
			this.Controls.Add(this._lblGetProfNo);
			this.Controls.Add(this._txtboxPosMode);
			this.Controls.Add(this._lblPosMode);
			this.Controls.Add(this._txtboxTargetBank);
			this.Controls.Add(this._lblTargetBank);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GetBatchProfileForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GetBatchProfileForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.Label _lblEraseDescription;
		private System.Windows.Forms.Label _lblErase;
		private System.Windows.Forms.TextBox _txtboxErase;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label _txtboxPosModeDescription;
		private System.Windows.Forms.Label _lblTargetBankDescription;
		private System.Windows.Forms.TextBox _txtboxGetProfCnt;
		private System.Windows.Forms.Label _lblGetProfCnt;
		private System.Windows.Forms.TextBox _txtboxGetProfNo;
		private System.Windows.Forms.Label _lblGetProfNo;
		private System.Windows.Forms.TextBox _txtboxPosMode;
		private System.Windows.Forms.Label _lblPosMode;
		private System.Windows.Forms.TextBox _txtboxTargetBank;
		private System.Windows.Forms.Label _lblTargetBank;
		private System.Windows.Forms.TextBox _txtboxGetBatchNo;
		private System.Windows.Forms.Label _lblGetBatchNo;
		private System.Windows.Forms.Label _lblProfileDescription;
	}
}