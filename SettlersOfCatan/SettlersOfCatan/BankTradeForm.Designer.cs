namespace SettlersOfCatan
{
	partial class BankTradeForm
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
			this.ResourceTradeBankComboBox = new System.Windows.Forms.ComboBox();
			this.ResourceGainBankComboBox = new System.Windows.Forms.ComboBox();
			this.BankTradePromptLabel = new System.Windows.Forms.Label();
			this.SubmitBankTradeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ResourceTradeBankComboBox
			// 
			this.ResourceTradeBankComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this.ResourceTradeBankComboBox.FormattingEnabled = true;
			this.ResourceTradeBankComboBox.Items.AddRange(new object[] {
            "ore",
            "grain",
            "wool",
            "brick",
            "lumber"});
			this.ResourceTradeBankComboBox.Location = new System.Drawing.Point(12, 113);
			this.ResourceTradeBankComboBox.Name = "ResourceTradeBankComboBox";
			this.ResourceTradeBankComboBox.Size = new System.Drawing.Size(136, 21);
			this.ResourceTradeBankComboBox.TabIndex = 0;
			this.ResourceTradeBankComboBox.Text = "Resource to Trade";
			// 
			// ResourceGainBankComboBox
			// 
			this.ResourceGainBankComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this.ResourceGainBankComboBox.FormattingEnabled = true;
			this.ResourceGainBankComboBox.Items.AddRange(new object[] {
            "ore",
            "grain",
            "wool",
            "brick",
            "lumber"});
			this.ResourceGainBankComboBox.Location = new System.Drawing.Point(199, 113);
			this.ResourceGainBankComboBox.Name = "ResourceGainBankComboBox";
			this.ResourceGainBankComboBox.Size = new System.Drawing.Size(135, 21);
			this.ResourceGainBankComboBox.TabIndex = 1;
			this.ResourceGainBankComboBox.Text = "Resource to Gain";
			// 
			// BankTradePromptLabel
			// 
			this.BankTradePromptLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.BankTradePromptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.BankTradePromptLabel.Location = new System.Drawing.Point(0, 0);
			this.BankTradePromptLabel.Name = "BankTradePromptLabel";
			this.BankTradePromptLabel.Size = new System.Drawing.Size(346, 90);
			this.BankTradePromptLabel.TabIndex = 4;
			this.BankTradePromptLabel.Text = "Choose your resources:";
			this.BankTradePromptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SubmitBankTradeButton
			// 
			this.SubmitBankTradeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.SubmitBankTradeButton.Location = new System.Drawing.Point(134, 200);
			this.SubmitBankTradeButton.Name = "SubmitBankTradeButton";
			this.SubmitBankTradeButton.Size = new System.Drawing.Size(79, 25);
			this.SubmitBankTradeButton.TabIndex = 5;
			this.SubmitBankTradeButton.Text = "Submit";
			this.SubmitBankTradeButton.UseVisualStyleBackColor = true;
			this.SubmitBankTradeButton.Click += new System.EventHandler(this.SubmitBankTradeButton_Click);
			// 
			// BankTradeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 289);
			this.Controls.Add(this.SubmitBankTradeButton);
			this.Controls.Add(this.BankTradePromptLabel);
			this.Controls.Add(this.ResourceGainBankComboBox);
			this.Controls.Add(this.ResourceTradeBankComboBox);
			this.Name = "BankTradeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bank Trade";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox ResourceTradeBankComboBox;
		private System.Windows.Forms.ComboBox ResourceGainBankComboBox;
		private System.Windows.Forms.Label BankTradePromptLabel;
		private System.Windows.Forms.Button SubmitBankTradeButton;
	}
}