namespace SettlersOfCatan
{
    partial class NewGameForm
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
            this.NewGameLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGameLabel
            // 
            this.NewGameLabel.AutoSize = true;
            this.NewGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.NewGameLabel.Location = new System.Drawing.Point(345, 22);
            this.NewGameLabel.Name = "NewGameLabel";
            this.NewGameLabel.Size = new System.Drawing.Size(265, 55);
            this.NewGameLabel.TabIndex = 0;
            this.NewGameLabel.Text = "New Game";
            this.NewGameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BackButton.Location = new System.Drawing.Point(296, 458);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(80, 39);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.StartButton.Location = new System.Drawing.Point(597, 458);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(81, 39);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 578);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.NewGameLabel);
            this.Name = "NewGameForm";
            this.Text = "New Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NewGameLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button StartButton;
    }
}