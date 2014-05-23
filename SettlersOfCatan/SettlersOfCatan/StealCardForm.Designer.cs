namespace SettlersOfCatan
{
	partial class StealCardForm
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
			this.PlayerNameComboBox = new System.Windows.Forms.ComboBox();
			this.StealCardButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// PlayerNameComboBox
			// 
			this.PlayerNameComboBox.FormattingEnabled = true;
			this.PlayerNameComboBox.Location = new System.Drawing.Point(55, 38);
			this.PlayerNameComboBox.Name = "PlayerNameComboBox";
			this.PlayerNameComboBox.Size = new System.Drawing.Size(184, 21);
			this.PlayerNameComboBox.TabIndex = 0;
			this.PlayerNameComboBox.Text = "Pick who to steal from";
			// 
			// StealCardButton
			// 
			this.StealCardButton.Location = new System.Drawing.Point(108, 103);
			this.StealCardButton.Name = "StealCardButton";
			this.StealCardButton.Size = new System.Drawing.Size(75, 23);
			this.StealCardButton.TabIndex = 1;
			this.StealCardButton.Text = "Steal";
			this.StealCardButton.UseVisualStyleBackColor = true;
			this.StealCardButton.Click += new System.EventHandler(this.StealCardButton_Click);
			// 
			// StealCardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 175);
			this.Controls.Add(this.StealCardButton);
			this.Controls.Add(this.PlayerNameComboBox);
			this.Name = "StealCardForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Take a Card";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox PlayerNameComboBox;
		private System.Windows.Forms.Button StealCardButton;
	}
}