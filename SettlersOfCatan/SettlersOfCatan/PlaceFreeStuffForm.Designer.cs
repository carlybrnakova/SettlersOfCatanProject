namespace SettlersOfCatan
{
    partial class PlaceFreeStuffForm
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
			this.PlaceStuffBeforeEndingLabel = new System.Windows.Forms.Label();
			this.CloseButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// PlaceStuffBeforeEndingLabel
			// 
			this.PlaceStuffBeforeEndingLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.PlaceStuffBeforeEndingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PlaceStuffBeforeEndingLabel.Location = new System.Drawing.Point(0, 0);
			this.PlaceStuffBeforeEndingLabel.Name = "PlaceStuffBeforeEndingLabel";
			this.PlaceStuffBeforeEndingLabel.Size = new System.Drawing.Size(709, 87);
			this.PlaceStuffBeforeEndingLabel.TabIndex = 31;
			this.PlaceStuffBeforeEndingLabel.Text = "Place the rest of your free roads/settlements before ending turn";
			this.PlaceStuffBeforeEndingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CloseButton
			// 
			this.CloseButton.Location = new System.Drawing.Point(263, 90);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(129, 23);
			this.CloseButton.TabIndex = 32;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// PlaceFreeStuffForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(709, 119);
			this.Controls.Add(this.CloseButton);
			this.Controls.Add(this.PlaceStuffBeforeEndingLabel);
			this.Name = "PlaceFreeStuffForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Unplaced Roads/Settlements";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PlaceStuffBeforeEndingLabel;
        private System.Windows.Forms.Button CloseButton;
    }
}