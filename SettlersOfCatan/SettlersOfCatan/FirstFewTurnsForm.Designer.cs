namespace SettlersOfCatan
{
    partial class FirstFewTurnsForm
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.PlaceRoadsAndSettlementsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(182, 100);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(129, 23);
            this.CloseButton.TabIndex = 30;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PlaceRoadsAndSettlementsLabel
            // 
            this.PlaceRoadsAndSettlementsLabel.AutoSize = true;
            this.PlaceRoadsAndSettlementsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaceRoadsAndSettlementsLabel.Location = new System.Drawing.Point(99, 32);
            this.PlaceRoadsAndSettlementsLabel.Name = "PlaceRoadsAndSettlementsLabel";
            this.PlaceRoadsAndSettlementsLabel.Size = new System.Drawing.Size(301, 24);
            this.PlaceRoadsAndSettlementsLabel.TabIndex = 31;
            this.PlaceRoadsAndSettlementsLabel.Text = "Place a road and a Settlement now";
            // 
            // FirstFewTurnsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 170);
            this.Controls.Add(this.PlaceRoadsAndSettlementsLabel);
            this.Controls.Add(this.CloseButton);
            this.Name = "FirstFewTurnsForm";
            this.Text = "FirstFewTurnsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label PlaceRoadsAndSettlementsLabel;
    }
}