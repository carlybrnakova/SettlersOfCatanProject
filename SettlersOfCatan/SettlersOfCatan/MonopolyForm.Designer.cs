namespace SettlersOfCatan
{
    partial class MonopolyForm
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
			this.MonopolyLabel = new System.Windows.Forms.Label();
			this.MonopolyComboBox = new System.Windows.Forms.ComboBox();
			this.MonopolyButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// MonopolyLabel
			// 
			this.MonopolyLabel.AutoSize = true;
			this.MonopolyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.MonopolyLabel.Location = new System.Drawing.Point(40, 31);
			this.MonopolyLabel.Name = "MonopolyLabel";
			this.MonopolyLabel.Size = new System.Drawing.Size(298, 20);
			this.MonopolyLabel.TabIndex = 0;
			this.MonopolyLabel.Text = "Pick the resource you wish to monopolize";
			// 
			// MonopolyComboBox
			// 
			this.MonopolyComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.MonopolyComboBox.FormattingEnabled = true;
			this.MonopolyComboBox.Items.AddRange(new object[] {
            "ore",
            "wool",
            "lumber",
            "grain",
            "brick"});
			this.MonopolyComboBox.Location = new System.Drawing.Point(131, 115);
			this.MonopolyComboBox.Name = "MonopolyComboBox";
			this.MonopolyComboBox.Size = new System.Drawing.Size(121, 26);
			this.MonopolyComboBox.TabIndex = 1;
			this.MonopolyComboBox.Text = "Resource";
			// 
			// MonopolyButton
			// 
			this.MonopolyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.MonopolyButton.Location = new System.Drawing.Point(152, 217);
			this.MonopolyButton.Name = "MonopolyButton";
			this.MonopolyButton.Size = new System.Drawing.Size(75, 28);
			this.MonopolyButton.TabIndex = 2;
			this.MonopolyButton.Text = "Submit";
			this.MonopolyButton.UseVisualStyleBackColor = true;
			this.MonopolyButton.Click += new System.EventHandler(this.MonopolyButton_Click);
			// 
			// MonopolyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(375, 313);
			this.Controls.Add(this.MonopolyButton);
			this.Controls.Add(this.MonopolyComboBox);
			this.Controls.Add(this.MonopolyLabel);
			this.Name = "MonopolyForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Monopoly";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MonopolyLabel;
        private System.Windows.Forms.ComboBox MonopolyComboBox;
        private System.Windows.Forms.Button MonopolyButton;
    }
}