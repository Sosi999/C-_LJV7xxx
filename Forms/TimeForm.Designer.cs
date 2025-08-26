namespace LJV7_DllSampleAll.Forms
{
	partial class TimeForm
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
			this._txtboxYear = new System.Windows.Forms.TextBox();
			this._lblYear = new System.Windows.Forms.Label();
			this._txtboxMonth = new System.Windows.Forms.TextBox();
			this._lblMonth = new System.Windows.Forms.Label();
			this._txtboxDay = new System.Windows.Forms.TextBox();
			this._lblDay = new System.Windows.Forms.Label();
			this._txtboxHour = new System.Windows.Forms.TextBox();
			this._lblHour = new System.Windows.Forms.Label();
			this._txtboxMinute = new System.Windows.Forms.TextBox();
			this._lblMinute = new System.Windows.Forms.Label();
			this._txtboxSecond = new System.Windows.Forms.TextBox();
			this._lblSecond = new System.Windows.Forms.Label();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnOk = new System.Windows.Forms.Button();
			this._lblTimeDescription = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _txtboxYear
			// 
			this._txtboxYear.Location = new System.Drawing.Point(69, 49);
			this._txtboxYear.Name = "_txtboxYear";
			this._txtboxYear.Size = new System.Drawing.Size(99, 21);
			this._txtboxYear.TabIndex = 28;
			this._txtboxYear.Text = "99";
			// 
			// _lblYear
			// 
			this._lblYear.AutoSize = true;
			this._lblYear.Location = new System.Drawing.Point(24, 52);
			this._lblYear.Name = "_lblYear";
			this._lblYear.Size = new System.Drawing.Size(29, 13);
			this._lblYear.TabIndex = 27;
			this._lblYear.Text = "Year";
			// 
			// _txtboxMonth
			// 
			this._txtboxMonth.Location = new System.Drawing.Point(69, 76);
			this._txtboxMonth.Name = "_txtboxMonth";
			this._txtboxMonth.Size = new System.Drawing.Size(99, 21);
			this._txtboxMonth.TabIndex = 30;
			this._txtboxMonth.Text = "1";
			// 
			// _lblMonth
			// 
			this._lblMonth.AutoSize = true;
			this._lblMonth.Location = new System.Drawing.Point(24, 79);
			this._lblMonth.Name = "_lblMonth";
			this._lblMonth.Size = new System.Drawing.Size(37, 13);
			this._lblMonth.TabIndex = 29;
			this._lblMonth.Text = "Month";
			// 
			// _txtboxDay
			// 
			this._txtboxDay.Location = new System.Drawing.Point(69, 103);
			this._txtboxDay.Name = "_txtboxDay";
			this._txtboxDay.Size = new System.Drawing.Size(99, 21);
			this._txtboxDay.TabIndex = 32;
			this._txtboxDay.Text = "1";
			// 
			// _lblDay
			// 
			this._lblDay.AutoSize = true;
			this._lblDay.Location = new System.Drawing.Point(24, 106);
			this._lblDay.Name = "_lblDay";
			this._lblDay.Size = new System.Drawing.Size(26, 13);
			this._lblDay.TabIndex = 31;
			this._lblDay.Text = "Day";
			// 
			// _txtboxHour
			// 
			this._txtboxHour.Location = new System.Drawing.Point(69, 140);
			this._txtboxHour.Name = "_txtboxHour";
			this._txtboxHour.Size = new System.Drawing.Size(99, 21);
			this._txtboxHour.TabIndex = 34;
			this._txtboxHour.Text = "0";
			// 
			// _lblHour
			// 
			this._lblHour.AutoSize = true;
			this._lblHour.Location = new System.Drawing.Point(24, 143);
			this._lblHour.Name = "_lblHour";
			this._lblHour.Size = new System.Drawing.Size(30, 13);
			this._lblHour.TabIndex = 33;
			this._lblHour.Text = "Hour";
			// 
			// _txtboxMinute
			// 
			this._txtboxMinute.Location = new System.Drawing.Point(69, 167);
			this._txtboxMinute.Name = "_txtboxMinute";
			this._txtboxMinute.Size = new System.Drawing.Size(99, 21);
			this._txtboxMinute.TabIndex = 36;
			this._txtboxMinute.Text = "0";
			// 
			// _lblMinute
			// 
			this._lblMinute.AutoSize = true;
			this._lblMinute.Location = new System.Drawing.Point(24, 170);
			this._lblMinute.Name = "_lblMinute";
			this._lblMinute.Size = new System.Drawing.Size(39, 13);
			this._lblMinute.TabIndex = 35;
			this._lblMinute.Text = "Minute";
			// 
			// _txtboxSecond
			// 
			this._txtboxSecond.Location = new System.Drawing.Point(69, 194);
			this._txtboxSecond.Name = "_txtboxSecond";
			this._txtboxSecond.Size = new System.Drawing.Size(99, 21);
			this._txtboxSecond.TabIndex = 38;
			this._txtboxSecond.Text = "0";
			// 
			// _lblSecond
			// 
			this._lblSecond.AutoSize = true;
			this._lblSecond.Location = new System.Drawing.Point(24, 197);
			this._lblSecond.Name = "_lblSecond";
			this._lblSecond.Size = new System.Drawing.Size(42, 13);
			this._lblSecond.TabIndex = 37;
			this._lblSecond.Text = "Second";
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(107, 237);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 25);
			this._btnCancel.TabIndex = 40;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnOk
			// 
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(12, 237);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 25);
			this._btnOk.TabIndex = 39;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = true;
			// 
			// _lblTimeDescription
			// 
			this._lblTimeDescription.AutoSize = true;
			this._lblTimeDescription.Location = new System.Drawing.Point(44, 20);
			this._lblTimeDescription.Name = "_lblTimeDescription";
			this._lblTimeDescription.Size = new System.Drawing.Size(115, 13);
			this._lblTimeDescription.TabIndex = 41;
			this._lblTimeDescription.Text = "Input range (0 to 255)";
			// 
			// TimeForm
			// 
			this.AcceptButton = this._btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(203, 285);
			this.Controls.Add(this._lblTimeDescription);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Controls.Add(this._txtboxSecond);
			this.Controls.Add(this._lblSecond);
			this.Controls.Add(this._txtboxMinute);
			this.Controls.Add(this._lblMinute);
			this.Controls.Add(this._txtboxHour);
			this.Controls.Add(this._lblHour);
			this.Controls.Add(this._txtboxDay);
			this.Controls.Add(this._lblDay);
			this.Controls.Add(this._txtboxMonth);
			this.Controls.Add(this._lblMonth);
			this.Controls.Add(this._txtboxYear);
			this.Controls.Add(this._lblYear);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TimeForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Date and time settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _txtboxYear;
		private System.Windows.Forms.Label _lblYear;
		private System.Windows.Forms.TextBox _txtboxMonth;
		private System.Windows.Forms.Label _lblMonth;
		private System.Windows.Forms.TextBox _txtboxDay;
		private System.Windows.Forms.Label _lblDay;
		private System.Windows.Forms.TextBox _txtboxHour;
		private System.Windows.Forms.Label _lblHour;
		private System.Windows.Forms.TextBox _txtboxMinute;
		private System.Windows.Forms.Label _lblMinute;
		private System.Windows.Forms.TextBox _txtboxSecond;
		private System.Windows.Forms.Label _lblSecond;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.Label _lblTimeDescription;
	}
}