namespace SettlersOfCatan
{
	partial class ChooseLanguageForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseLanguageForm));
			this.AmericanFlag = new System.Windows.Forms.PictureBox();
			this.SpanishFlag = new System.Windows.Forms.PictureBox();
			this.EnglishLabel = new System.Windows.Forms.Label();
			this.SpanishLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.AmericanFlag)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpanishFlag)).BeginInit();
			this.SuspendLayout();
			// 
			// AmericanFlag
			// 
			this.AmericanFlag.Image = ((System.Drawing.Image)(resources.GetObject("AmericanFlag.Image")));
			this.AmericanFlag.Location = new System.Drawing.Point(38, 24);
			this.AmericanFlag.Name = "AmericanFlag";
			this.AmericanFlag.Size = new System.Drawing.Size(113, 76);
			this.AmericanFlag.TabIndex = 0;
			this.AmericanFlag.TabStop = false;
			this.AmericanFlag.Click += new System.EventHandler(this.AmericanFlag_Click);
			// 
			// SpanishFlag
			// 
			this.SpanishFlag.Image = ((System.Drawing.Image)(resources.GetObject("SpanishFlag.Image")));
			this.SpanishFlag.Location = new System.Drawing.Point(215, 24);
			this.SpanishFlag.Name = "SpanishFlag";
			this.SpanishFlag.Size = new System.Drawing.Size(113, 76);
			this.SpanishFlag.TabIndex = 1;
			this.SpanishFlag.TabStop = false;
			this.SpanishFlag.Click += new System.EventHandler(this.SpanishFlag_Click);
			// 
			// EnglishLabel
			// 
			this.EnglishLabel.AutoSize = true;
			this.EnglishLabel.Location = new System.Drawing.Point(79, 102);
			this.EnglishLabel.Name = "EnglishLabel";
			this.EnglishLabel.Size = new System.Drawing.Size(41, 13);
			this.EnglishLabel.TabIndex = 2;
			this.EnglishLabel.Text = "English";
			// 
			// SpanishLabel
			// 
			this.SpanishLabel.AutoSize = true;
			this.SpanishLabel.Location = new System.Drawing.Point(251, 102);
			this.SpanishLabel.Name = "SpanishLabel";
			this.SpanishLabel.Size = new System.Drawing.Size(45, 13);
			this.SpanishLabel.TabIndex = 3;
			this.SpanishLabel.Text = "Español";
			// 
			// ChooseLanguageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(368, 137);
			this.Controls.Add(this.SpanishLabel);
			this.Controls.Add(this.EnglishLabel);
			this.Controls.Add(this.SpanishFlag);
			this.Controls.Add(this.AmericanFlag);
			this.Name = "ChooseLanguageForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Choose Your Language";
			((System.ComponentModel.ISupportInitialize)(this.AmericanFlag)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SpanishFlag)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox AmericanFlag;
		private System.Windows.Forms.PictureBox SpanishFlag;
		private System.Windows.Forms.Label EnglishLabel;
		private System.Windows.Forms.Label SpanishLabel;
	}
}