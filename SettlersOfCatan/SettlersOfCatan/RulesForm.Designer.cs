namespace SettlersOfCatan
{
    partial class RulesForm
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
			this.RulesLabel = new System.Windows.Forms.Label();
			this.RulesBackButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// RulesLabel
			// 
			this.RulesLabel.AutoSize = true;
			this.RulesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
			this.RulesLabel.Location = new System.Drawing.Point(208, 29);
			this.RulesLabel.Name = "RulesLabel";
			this.RulesLabel.Size = new System.Drawing.Size(147, 55);
			this.RulesLabel.TabIndex = 0;
			this.RulesLabel.Text = "Rules";
			// 
			// RulesBackButton
			// 
			this.RulesBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.RulesBackButton.Location = new System.Drawing.Point(218, 288);
			this.RulesBackButton.Name = "RulesBackButton";
			this.RulesBackButton.Size = new System.Drawing.Size(125, 49);
			this.RulesBackButton.TabIndex = 1;
			this.RulesBackButton.Text = "Back";
			this.RulesBackButton.UseVisualStyleBackColor = true;
			this.RulesBackButton.Click += new System.EventHandler(this.RulesBackButton_Click);
			// 
			// RulesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(546, 369);
			this.Controls.Add(this.RulesBackButton);
			this.Controls.Add(this.RulesLabel);
			this.Name = "RulesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Rules";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RulesLabel;
        private System.Windows.Forms.Button RulesBackButton;
    }
}