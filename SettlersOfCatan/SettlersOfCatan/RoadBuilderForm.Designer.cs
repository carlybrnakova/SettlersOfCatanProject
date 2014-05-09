namespace SettlersOfCatan
{
    partial class RoadBuilderForm
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
            this.PlaceRoadsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(223, 104);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(129, 23);
            this.CloseButton.TabIndex = 29;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PlaceRoadsLabel
            // 
            this.PlaceRoadsLabel.AutoSize = true;
            this.PlaceRoadsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaceRoadsLabel.Location = new System.Drawing.Point(201, 31);
            this.PlaceRoadsLabel.Name = "PlaceRoadsLabel";
            this.PlaceRoadsLabel.Size = new System.Drawing.Size(202, 24);
            this.PlaceRoadsLabel.TabIndex = 30;
            this.PlaceRoadsLabel.Text = "Place Two Roads Now";
            // 
            // RoadBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 184);
            this.Controls.Add(this.PlaceRoadsLabel);
            this.Controls.Add(this.CloseButton);
            this.Name = "RoadBuilderForm";
            this.Text = "RoadBuilderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label PlaceRoadsLabel;
    }
}