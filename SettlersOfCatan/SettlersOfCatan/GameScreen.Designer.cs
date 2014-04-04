namespace SettlersOfCatan
{
    partial class GameScreen
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
            this.PlayerInfoPanel = new System.Windows.Forms.Panel();
            this.VerticalSeparator2 = new System.Windows.Forms.Label();
            this.VerticalSeparator1 = new System.Windows.Forms.Label();
            this.ItemToBuildComboBox = new System.Windows.Forms.ComboBox();
            this.ProposeTradeButton = new System.Windows.Forms.Button();
            this.BuyDevCardButton = new System.Windows.Forms.Button();
            this.MaterialsLabel = new System.Windows.Forms.Label();
            this.EndTurnButton = new System.Windows.Forms.Button();
            this.CurrentPlayerNameLabel = new System.Windows.Forms.Label();
            this.PlayerInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerInfoPanel
            // 
            this.PlayerInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PlayerInfoPanel.Controls.Add(this.VerticalSeparator2);
            this.PlayerInfoPanel.Controls.Add(this.VerticalSeparator1);
            this.PlayerInfoPanel.Controls.Add(this.ItemToBuildComboBox);
            this.PlayerInfoPanel.Controls.Add(this.ProposeTradeButton);
            this.PlayerInfoPanel.Controls.Add(this.BuyDevCardButton);
            this.PlayerInfoPanel.Controls.Add(this.MaterialsLabel);
            this.PlayerInfoPanel.Controls.Add(this.EndTurnButton);
            this.PlayerInfoPanel.Location = new System.Drawing.Point(1068, 211);
            this.PlayerInfoPanel.Name = "PlayerInfoPanel";
            this.PlayerInfoPanel.Size = new System.Drawing.Size(493, 189);
            this.PlayerInfoPanel.TabIndex = 1;
            // 
            // VerticalSeparator2
            // 
            this.VerticalSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.VerticalSeparator2.Location = new System.Drawing.Point(256, 10);
            this.VerticalSeparator2.Name = "VerticalSeparator2";
            this.VerticalSeparator2.Size = new System.Drawing.Size(2, 177);
            this.VerticalSeparator2.TabIndex = 7;
            this.VerticalSeparator2.Text = "label1";
            // 
            // VerticalSeparator1
            // 
            this.VerticalSeparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.VerticalSeparator1.Location = new System.Drawing.Point(169, 5);
            this.VerticalSeparator1.Name = "VerticalSeparator1";
            this.VerticalSeparator1.Size = new System.Drawing.Size(2, 177);
            this.VerticalSeparator1.TabIndex = 6;
            this.VerticalSeparator1.Text = "label1";
            // 
            // ItemToBuildComboBox
            // 
            this.ItemToBuildComboBox.FormattingEnabled = true;
            this.ItemToBuildComboBox.Items.AddRange(new object[] {
            "Road",
            "Settlement",
            "City"});
            this.ItemToBuildComboBox.Location = new System.Drawing.Point(304, 71);
            this.ItemToBuildComboBox.Name = "ItemToBuildComboBox";
            this.ItemToBuildComboBox.Size = new System.Drawing.Size(129, 21);
            this.ItemToBuildComboBox.TabIndex = 5;
            this.ItemToBuildComboBox.Text = "Build...";
            this.ItemToBuildComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemToBuildComboBox_SelectedIndexChanged);
            // 
            // ProposeTradeButton
            // 
            this.ProposeTradeButton.Location = new System.Drawing.Point(304, 127);
            this.ProposeTradeButton.Name = "ProposeTradeButton";
            this.ProposeTradeButton.Size = new System.Drawing.Size(129, 23);
            this.ProposeTradeButton.TabIndex = 4;
            this.ProposeTradeButton.Text = "Propose Trade";
            this.ProposeTradeButton.UseVisualStyleBackColor = true;
            // 
            // BuyDevCardButton
            // 
            this.BuyDevCardButton.Location = new System.Drawing.Point(304, 98);
            this.BuyDevCardButton.Name = "BuyDevCardButton";
            this.BuyDevCardButton.Size = new System.Drawing.Size(129, 23);
            this.BuyDevCardButton.TabIndex = 3;
            this.BuyDevCardButton.Text = "Buy Development Card";
            this.BuyDevCardButton.UseVisualStyleBackColor = true;
            // 
            // MaterialsLabel
            // 
            this.MaterialsLabel.AutoSize = true;
            this.MaterialsLabel.Location = new System.Drawing.Point(3, 6);
            this.MaterialsLabel.Name = "MaterialsLabel";
            this.MaterialsLabel.Size = new System.Drawing.Size(49, 13);
            this.MaterialsLabel.TabIndex = 2;
            this.MaterialsLabel.Text = "Materials";
            // 
            // EndTurnButton
            // 
            this.EndTurnButton.Location = new System.Drawing.Point(21, 146);
            this.EndTurnButton.Name = "EndTurnButton";
            this.EndTurnButton.Size = new System.Drawing.Size(75, 23);
            this.EndTurnButton.TabIndex = 0;
            this.EndTurnButton.Text = "End Turn";
            this.EndTurnButton.UseVisualStyleBackColor = true;
            // 
            // CurrentPlayerNameLabel
            // 
            this.CurrentPlayerNameLabel.AutoSize = true;
            this.CurrentPlayerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPlayerNameLabel.Location = new System.Drawing.Point(1064, 184);
            this.CurrentPlayerNameLabel.Name = "CurrentPlayerNameLabel";
            this.CurrentPlayerNameLabel.Size = new System.Drawing.Size(77, 24);
            this.CurrentPlayerNameLabel.TabIndex = 1;
            this.CurrentPlayerNameLabel.Text = "Player 1";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 912);
            this.Controls.Add(this.PlayerInfoPanel);
            this.Controls.Add(this.CurrentPlayerNameLabel);
            this.Name = "GameScreen";
            this.Text = "GameScreen";
            this.PlayerInfoPanel.ResumeLayout(false);
            this.PlayerInfoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlayerInfoPanel;
        private System.Windows.Forms.Label MaterialsLabel;
        private System.Windows.Forms.Label CurrentPlayerNameLabel;
        private System.Windows.Forms.Button EndTurnButton;
        private System.Windows.Forms.Label VerticalSeparator1;
        private System.Windows.Forms.ComboBox ItemToBuildComboBox;
        private System.Windows.Forms.Button ProposeTradeButton;
        private System.Windows.Forms.Button BuyDevCardButton;
        private System.Windows.Forms.Label VerticalSeparator2;
    }
}