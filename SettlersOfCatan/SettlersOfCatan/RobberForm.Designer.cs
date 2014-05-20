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
			this.RobberFormNoteLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// RobberFormDoubleClickLabel
			// 
			this.RobberFormDoubleClickLabel.AutoSize = true;
			this.RobberFormDoubleClickLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.RobberFormDoubleClickLabel.Location = new System.Drawing.Point(80, 22);
			this.RobberFormDoubleClickLabel.Name = "RobberFormDoubleClickLabel";
			this.RobberFormDoubleClickLabel.Size = new System.Drawing.Size(260, 18);
			this.RobberFormDoubleClickLabel.TabIndex = 0;
			this.RobberFormDoubleClickLabel.Text = "Double-click a hex to place the robber.";
			// 
			// ReminderLabelRobberForm
			// 
			this.ReminderLabelRobberForm.AutoSize = true;
			this.ReminderLabelRobberForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.ReminderLabelRobberForm.Location = new System.Drawing.Point(54, 52);
			this.ReminderLabelRobberForm.Name = "ReminderLabelRobberForm";
			this.ReminderLabelRobberForm.Size = new System.Drawing.Size(311, 18);
			this.ReminderLabelRobberForm.TabIndex = 1;
			this.ReminderLabelRobberForm.Text = "It can\'t be placed on the hex that it was just on.";
			// 
			// RobberFormButton
			// 
			this.RobberFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this.RobberFormButton.Location = new System.Drawing.Point(169, 144);
			this.RobberFormButton.Name = "RobberFormButton";
			this.RobberFormButton.Size = new System.Drawing.Size(63, 23);
			this.RobberFormButton.TabIndex = 2;
			this.RobberFormButton.Text = "Close";
			this.RobberFormButton.UseVisualStyleBackColor = true;
			this.RobberFormButton.Click += new System.EventHandler(this.RobberFormButton_Click);
			// 
			// RobberFormNoteLabel
			// 
			this.RobberFormNoteLabel.AutoSize = true;
			this.RobberFormNoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.RobberFormNoteLabel.Location = new System.Drawing.Point(54, 90);
			this.RobberFormNoteLabel.Name = "RobberFormNoteLabel";
			this.RobberFormNoteLabel.Size = new System.Drawing.Size(306, 18);
			this.RobberFormNoteLabel.TabIndex = 3;
			this.RobberFormNoteLabel.Text = "The board will repaint once you end your turn.";
			// 
			// RobberForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 185);
			this.Controls.Add(this.RobberFormNoteLabel);
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
		private System.Windows.Forms.Label RobberFormNoteLabel;
	}
}