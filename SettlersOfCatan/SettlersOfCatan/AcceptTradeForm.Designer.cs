namespace SettlersOfCatan
{
    partial class AcceptTradeForm
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
            this.AcceptTheTradeLabel = new System.Windows.Forms.Label();
            this.AcceptTradeButton = new System.Windows.Forms.Button();
            this.DeclineTradeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AcceptTheTradeLabel
            // 
            this.AcceptTheTradeLabel.AutoSize = true;
            this.AcceptTheTradeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcceptTheTradeLabel.Location = new System.Drawing.Point(82, 25);
            this.AcceptTheTradeLabel.Name = "AcceptTheTradeLabel";
            this.AcceptTheTradeLabel.Size = new System.Drawing.Size(173, 24);
            this.AcceptTheTradeLabel.TabIndex = 7;
            this.AcceptTheTradeLabel.Text = "Accept The Trade?";
            // 
            // AcceptTradeButton
            // 
            this.AcceptTradeButton.Location = new System.Drawing.Point(37, 148);
            this.AcceptTradeButton.Name = "AcceptTradeButton";
            this.AcceptTradeButton.Size = new System.Drawing.Size(129, 23);
            this.AcceptTradeButton.TabIndex = 28;
            this.AcceptTradeButton.Text = "Accept Trade";
            this.AcceptTradeButton.UseVisualStyleBackColor = true;
            this.AcceptTradeButton.Click += new System.EventHandler(this.AcceptTradeButton_Click);
            // 
            // DeclineTradeButton
            // 
            this.DeclineTradeButton.Location = new System.Drawing.Point(183, 148);
            this.DeclineTradeButton.Name = "DeclineTradeButton";
            this.DeclineTradeButton.Size = new System.Drawing.Size(129, 23);
            this.DeclineTradeButton.TabIndex = 29;
            this.DeclineTradeButton.Text = "Decline Trade";
            this.DeclineTradeButton.UseVisualStyleBackColor = true;
            this.DeclineTradeButton.Click += new System.EventHandler(this.DeclineTradeButton_Click);
            // 
            // AcceptTradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 208);
            this.Controls.Add(this.DeclineTradeButton);
            this.Controls.Add(this.AcceptTradeButton);
            this.Controls.Add(this.AcceptTheTradeLabel);
            this.Name = "AcceptTradeForm";
            this.Text = "AcceptTradeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AcceptTheTradeLabel;
        private System.Windows.Forms.Button AcceptTradeButton;
        private System.Windows.Forms.Button DeclineTradeButton;
    }
}