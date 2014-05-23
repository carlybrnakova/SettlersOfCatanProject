namespace SettlersOfCatan
{
    partial class YearOfPlentyForm
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
			this.YearOfPlentyLabel = new System.Windows.Forms.Label();
			this.YearOfPlentyComboBox1 = new System.Windows.Forms.ComboBox();
			this.YearOfPlentyComboBox2 = new System.Windows.Forms.ComboBox();
			this.YearOfPlentyButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// YearOfPlentyLabel
			// 
			this.YearOfPlentyLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.YearOfPlentyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.YearOfPlentyLabel.Location = new System.Drawing.Point(0, 0);
			this.YearOfPlentyLabel.Name = "YearOfPlentyLabel";
			this.YearOfPlentyLabel.Size = new System.Drawing.Size(362, 83);
			this.YearOfPlentyLabel.TabIndex = 0;
			this.YearOfPlentyLabel.Text = "Pick your two resources";
			this.YearOfPlentyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// YearOfPlentyComboBox1
			// 
			this.YearOfPlentyComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.YearOfPlentyComboBox1.FormattingEnabled = true;
			this.YearOfPlentyComboBox1.Items.AddRange(new object[] {
            "ore",
            "wool",
            "lumber",
            "grain",
            "brick"});
			this.YearOfPlentyComboBox1.Location = new System.Drawing.Point(125, 86);
			this.YearOfPlentyComboBox1.Name = "YearOfPlentyComboBox1";
			this.YearOfPlentyComboBox1.Size = new System.Drawing.Size(121, 24);
			this.YearOfPlentyComboBox1.TabIndex = 1;
			this.YearOfPlentyComboBox1.Text = "Resource 1";
			// 
			// YearOfPlentyComboBox2
			// 
			this.YearOfPlentyComboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.YearOfPlentyComboBox2.FormattingEnabled = true;
			this.YearOfPlentyComboBox2.Items.AddRange(new object[] {
            "ore",
            "wool",
            "lumber",
            "grain",
            "brick"});
			this.YearOfPlentyComboBox2.Location = new System.Drawing.Point(125, 154);
			this.YearOfPlentyComboBox2.Name = "YearOfPlentyComboBox2";
			this.YearOfPlentyComboBox2.Size = new System.Drawing.Size(121, 24);
			this.YearOfPlentyComboBox2.TabIndex = 2;
			this.YearOfPlentyComboBox2.Text = "Resource 2";
			// 
			// YearOfPlentyButton
			// 
			this.YearOfPlentyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.YearOfPlentyButton.Location = new System.Drawing.Point(144, 229);
			this.YearOfPlentyButton.Name = "YearOfPlentyButton";
			this.YearOfPlentyButton.Size = new System.Drawing.Size(75, 23);
			this.YearOfPlentyButton.TabIndex = 3;
			this.YearOfPlentyButton.Text = "Submit";
			this.YearOfPlentyButton.UseVisualStyleBackColor = true;
			this.YearOfPlentyButton.Click += new System.EventHandler(this.YearOfPlentyButton_Click);
			// 
			// YearOfPlentyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 291);
			this.Controls.Add(this.YearOfPlentyButton);
			this.Controls.Add(this.YearOfPlentyComboBox2);
			this.Controls.Add(this.YearOfPlentyComboBox1);
			this.Controls.Add(this.YearOfPlentyLabel);
			this.Name = "YearOfPlentyForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Year of Plenty";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label YearOfPlentyLabel;
        private System.Windows.Forms.ComboBox YearOfPlentyComboBox1;
        private System.Windows.Forms.ComboBox YearOfPlentyComboBox2;
        private System.Windows.Forms.Button YearOfPlentyButton;
    }
}