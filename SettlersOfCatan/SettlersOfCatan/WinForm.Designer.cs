namespace SettlersOfCatan
{
    partial class WinForm
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
			this.WinnerLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// WinnerLabel
			// 
			this.WinnerLabel.AutoSize = true;
			this.WinnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
			this.WinnerLabel.Location = new System.Drawing.Point(52, 27);
			this.WinnerLabel.Name = "WinnerLabel";
			this.WinnerLabel.Size = new System.Drawing.Size(166, 39);
			this.WinnerLabel.TabIndex = 0;
			this.WinnerLabel.Text = "WINNER!";
			// 
			// WinForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(264, 100);
			this.Controls.Add(this.WinnerLabel);
			this.Name = "WinForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Congratulations!";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WinnerLabel;
    }
}