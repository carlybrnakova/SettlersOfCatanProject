namespace SettlersOfCatan
{
	partial class RobberForm
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
			this.RobberFormDoubleClickLabel = new System.Windows.Forms.Label();
			this.ReminderLabelRobberForm = new System.Windows.Forms.Label();
			this.RobberFormButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// RobberFormDoubleClickLabel
			// 
			this.RobberFormDoubleClickLabel.AutoSize = true;
			this.RobberFormDoubleClickLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.RobberFormDoubleClickLabel.Location = new System.Drawing.Point(28, 39);
			this.RobberFormDoubleClickLabel.Name = "RobberFormDoubleClickLabel";
			this.RobberFormDoubleClickLabel.Size = new System.Drawing.Size(260, 18);
			this.RobberFormDoubleClickLabel.TabIndex = 0;
			this.RobberFormDoubleClickLabel.Text = "Double-click a hex to place the robber.";
			// 
			// ReminderLabelRobberForm
			// 
			this.ReminderLabelRobberForm.AutoSize = true;
			this.ReminderLabelRobberForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.ReminderLabelRobberForm.Location = new System.Drawing.Point(37, 66);
			this.ReminderLabelRobberForm.Name = "ReminderLabelRobberForm";
			this.ReminderLabelRobberForm.Size = new System.Drawing.Size(234, 18);
			this.ReminderLabelRobberForm.TabIndex = 1;
			this.ReminderLabelRobberForm.Text = "It can\'t be placed on the same hex.";
			// 
			// RobberFormButton
			// 
			this.RobberFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this.RobberFormButton.Location = new System.Drawing.Point(109, 122);
			this.RobberFormButton.Name = "RobberFormButton";
			this.RobberFormButton.Size = new System.Drawing.Size(85, 23);
			this.RobberFormButton.TabIndex = 2;
			this.RobberFormButton.Text = "Understood";
			this.RobberFormButton.UseVisualStyleBackColor = true;
			this.RobberFormButton.Click += new System.EventHandler(this.RobberFormButton_Click);
			// 
			// RobberForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(309, 176);
			this.Controls.Add(this.RobberFormButton);
			this.Controls.Add(this.ReminderLabelRobberForm);
			this.Controls.Add(this.RobberFormDoubleClickLabel);
			this.Name = "RobberForm";
			this.Text = "Instructions";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label RobberFormDoubleClickLabel;
		private System.Windows.Forms.Label ReminderLabelRobberForm;
		private System.Windows.Forms.Button RobberFormButton;
	}
}