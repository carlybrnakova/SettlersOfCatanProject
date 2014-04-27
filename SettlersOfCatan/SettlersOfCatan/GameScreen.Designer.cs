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
            this.generateResourcesTest = new System.Windows.Forms.Button();
            this.WoolAmountLabel = new System.Windows.Forms.Label();
            this.BrickAmountLabel = new System.Windows.Forms.Label();
            this.GrainAmountLabel = new System.Windows.Forms.Label();
            this.LumberAmountLabel = new System.Windows.Forms.Label();
            this.OreAmountLabel = new System.Windows.Forms.Label();
            this.WoolLabel = new System.Windows.Forms.Label();
            this.BrickLabel = new System.Windows.Forms.Label();
            this.GrainLabel = new System.Windows.Forms.Label();
            this.LumberLabel = new System.Windows.Forms.Label();
            this.OreLabel = new System.Windows.Forms.Label();
            this.VerticalSeparator2 = new System.Windows.Forms.Label();
            this.VerticalSeparator1 = new System.Windows.Forms.Label();
            this.ItemToBuildComboBox = new System.Windows.Forms.ComboBox();
            this.ProposeTradeButton = new System.Windows.Forms.Button();
            this.BuyDevCardButton = new System.Windows.Forms.Button();
            this.MaterialsLabel = new System.Windows.Forms.Label();
            this.EndTurnButton = new System.Windows.Forms.Button();
            this.CurrentPlayerNameLabel = new System.Windows.Forms.Label();
            this.RollDiceButton = new System.Windows.Forms.Button();
            this.CurrentRollLabel = new System.Windows.Forms.Label();
            this.RollNumberLabel = new System.Windows.Forms.Label();
            this.PlayerInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerInfoPanel
            // 
            this.PlayerInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PlayerInfoPanel.Controls.Add(this.generateResourcesTest);
            this.PlayerInfoPanel.Controls.Add(this.WoolAmountLabel);
            this.PlayerInfoPanel.Controls.Add(this.BrickAmountLabel);
            this.PlayerInfoPanel.Controls.Add(this.GrainAmountLabel);
            this.PlayerInfoPanel.Controls.Add(this.LumberAmountLabel);
            this.PlayerInfoPanel.Controls.Add(this.OreAmountLabel);
            this.PlayerInfoPanel.Controls.Add(this.WoolLabel);
            this.PlayerInfoPanel.Controls.Add(this.BrickLabel);
            this.PlayerInfoPanel.Controls.Add(this.GrainLabel);
            this.PlayerInfoPanel.Controls.Add(this.LumberLabel);
            this.PlayerInfoPanel.Controls.Add(this.OreLabel);
            this.PlayerInfoPanel.Controls.Add(this.VerticalSeparator2);
            this.PlayerInfoPanel.Controls.Add(this.VerticalSeparator1);
            this.PlayerInfoPanel.Controls.Add(this.ItemToBuildComboBox);
            this.PlayerInfoPanel.Controls.Add(this.ProposeTradeButton);
            this.PlayerInfoPanel.Controls.Add(this.BuyDevCardButton);
            this.PlayerInfoPanel.Controls.Add(this.MaterialsLabel);
            this.PlayerInfoPanel.Controls.Add(this.EndTurnButton);
            this.PlayerInfoPanel.Location = new System.Drawing.Point(1068, 36);
            this.PlayerInfoPanel.Name = "PlayerInfoPanel";
            this.PlayerInfoPanel.Size = new System.Drawing.Size(493, 213);
            this.PlayerInfoPanel.TabIndex = 1;
            // 
            // generateResourcesTest
            // 
            this.generateResourcesTest.Location = new System.Drawing.Point(87, 11);
            this.generateResourcesTest.Name = "generateResourcesTest";
            this.generateResourcesTest.Size = new System.Drawing.Size(152, 23);
            this.generateResourcesTest.TabIndex = 18;
            this.generateResourcesTest.Text = "generate resources (test)";
            this.generateResourcesTest.UseVisualStyleBackColor = true;
            this.generateResourcesTest.Click += new System.EventHandler(this.generateResourcesTest_Click);
            // 
            // WoolAmountLabel
            // 
            this.WoolAmountLabel.AutoSize = true;
            this.WoolAmountLabel.Location = new System.Drawing.Point(52, 137);
            this.WoolAmountLabel.Name = "WoolAmountLabel";
            this.WoolAmountLabel.Size = new System.Drawing.Size(13, 13);
            this.WoolAmountLabel.TabIndex = 17;
            this.WoolAmountLabel.Text = "0";
            // 
            // BrickAmountLabel
            // 
            this.BrickAmountLabel.AutoSize = true;
            this.BrickAmountLabel.Location = new System.Drawing.Point(52, 112);
            this.BrickAmountLabel.Name = "BrickAmountLabel";
            this.BrickAmountLabel.Size = new System.Drawing.Size(13, 13);
            this.BrickAmountLabel.TabIndex = 16;
            this.BrickAmountLabel.Text = "0";
            // 
            // GrainAmountLabel
            // 
            this.GrainAmountLabel.AutoSize = true;
            this.GrainAmountLabel.Location = new System.Drawing.Point(52, 89);
            this.GrainAmountLabel.Name = "GrainAmountLabel";
            this.GrainAmountLabel.Size = new System.Drawing.Size(13, 13);
            this.GrainAmountLabel.TabIndex = 15;
            this.GrainAmountLabel.Text = "0";
            // 
            // LumberAmountLabel
            // 
            this.LumberAmountLabel.AutoSize = true;
            this.LumberAmountLabel.Location = new System.Drawing.Point(52, 64);
            this.LumberAmountLabel.Name = "LumberAmountLabel";
            this.LumberAmountLabel.Size = new System.Drawing.Size(13, 13);
            this.LumberAmountLabel.TabIndex = 14;
            this.LumberAmountLabel.Text = "0";
            // 
            // OreAmountLabel
            // 
            this.OreAmountLabel.AutoSize = true;
            this.OreAmountLabel.Location = new System.Drawing.Point(52, 39);
            this.OreAmountLabel.Name = "OreAmountLabel";
            this.OreAmountLabel.Size = new System.Drawing.Size(13, 13);
            this.OreAmountLabel.TabIndex = 13;
            this.OreAmountLabel.Text = "0";
            // 
            // WoolLabel
            // 
            this.WoolLabel.AutoSize = true;
            this.WoolLabel.Location = new System.Drawing.Point(11, 137);
            this.WoolLabel.Name = "WoolLabel";
            this.WoolLabel.Size = new System.Drawing.Size(35, 13);
            this.WoolLabel.TabIndex = 12;
            this.WoolLabel.Text = "Wool:";
            // 
            // BrickLabel
            // 
            this.BrickLabel.AutoSize = true;
            this.BrickLabel.Location = new System.Drawing.Point(12, 112);
            this.BrickLabel.Name = "BrickLabel";
            this.BrickLabel.Size = new System.Drawing.Size(34, 13);
            this.BrickLabel.TabIndex = 11;
            this.BrickLabel.Text = "Brick:";
            // 
            // GrainLabel
            // 
            this.GrainLabel.AutoSize = true;
            this.GrainLabel.Location = new System.Drawing.Point(11, 89);
            this.GrainLabel.Name = "GrainLabel";
            this.GrainLabel.Size = new System.Drawing.Size(35, 13);
            this.GrainLabel.TabIndex = 10;
            this.GrainLabel.Text = "Grain:";
            // 
            // LumberLabel
            // 
            this.LumberLabel.AutoSize = true;
            this.LumberLabel.Location = new System.Drawing.Point(3, 61);
            this.LumberLabel.Name = "LumberLabel";
            this.LumberLabel.Size = new System.Drawing.Size(45, 13);
            this.LumberLabel.TabIndex = 9;
            this.LumberLabel.Text = "Lumber:";
            // 
            // OreLabel
            // 
            this.OreLabel.AutoSize = true;
            this.OreLabel.Location = new System.Drawing.Point(19, 39);
            this.OreLabel.Name = "OreLabel";
            this.OreLabel.Size = new System.Drawing.Size(27, 13);
            this.OreLabel.TabIndex = 8;
            this.OreLabel.Text = "Ore:";
            // 
            // VerticalSeparator2
            // 
            this.VerticalSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.VerticalSeparator2.Location = new System.Drawing.Point(256, -2);
            this.VerticalSeparator2.Name = "VerticalSeparator2";
            this.VerticalSeparator2.Size = new System.Drawing.Size(2, 177);
            this.VerticalSeparator2.TabIndex = 7;
            this.VerticalSeparator2.Text = "label1";
            // 
            // VerticalSeparator1
            // 
            this.VerticalSeparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.VerticalSeparator1.Location = new System.Drawing.Point(79, -2);
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
            this.ProposeTradeButton.Click += new System.EventHandler(this.ProposeTradeButton_Click);
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
            this.MaterialsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaterialsLabel.Location = new System.Drawing.Point(3, 11);
            this.MaterialsLabel.Name = "MaterialsLabel";
            this.MaterialsLabel.Size = new System.Drawing.Size(49, 13);
            this.MaterialsLabel.TabIndex = 2;
            this.MaterialsLabel.Text = "Materials";
            // 
            // EndTurnButton
            // 
            this.EndTurnButton.Location = new System.Drawing.Point(6, 178);
            this.EndTurnButton.Name = "EndTurnButton";
            this.EndTurnButton.Size = new System.Drawing.Size(75, 23);
            this.EndTurnButton.TabIndex = 0;
            this.EndTurnButton.Text = "End Turn";
            this.EndTurnButton.UseVisualStyleBackColor = true;
            this.EndTurnButton.Click += new System.EventHandler(this.EndTurnButton_Click);
            // 
            // CurrentPlayerNameLabel
            // 
            this.CurrentPlayerNameLabel.AutoSize = true;
            this.CurrentPlayerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPlayerNameLabel.Location = new System.Drawing.Point(1064, 9);
            this.CurrentPlayerNameLabel.Name = "CurrentPlayerNameLabel";
            this.CurrentPlayerNameLabel.Size = new System.Drawing.Size(129, 24);
            this.CurrentPlayerNameLabel.TabIndex = 1;
            this.CurrentPlayerNameLabel.Text = "Current Player";
            // 
            // RollDiceButton
            // 
            this.RollDiceButton.Location = new System.Drawing.Point(1068, 290);
            this.RollDiceButton.Name = "RollDiceButton";
            this.RollDiceButton.Size = new System.Drawing.Size(83, 78);
            this.RollDiceButton.TabIndex = 2;
            this.RollDiceButton.Text = "ROLL!";
            this.RollDiceButton.UseVisualStyleBackColor = true;
            this.RollDiceButton.Click += new System.EventHandler(this.RollDiceButton_Click);
            // 
            // CurrentRollLabel
            // 
            this.CurrentRollLabel.AutoSize = true;
            this.CurrentRollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentRollLabel.Location = new System.Drawing.Point(1157, 290);
            this.CurrentRollLabel.Name = "CurrentRollLabel";
            this.CurrentRollLabel.Size = new System.Drawing.Size(101, 20);
            this.CurrentRollLabel.TabIndex = 3;
            this.CurrentRollLabel.Text = "Current Roll: ";
            // 
            // RollNumberLabel
            // 
            this.RollNumberLabel.AutoSize = true;
            this.RollNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollNumberLabel.Location = new System.Drawing.Point(1185, 323);
            this.RollNumberLabel.Name = "RollNumberLabel";
            this.RollNumberLabel.Size = new System.Drawing.Size(29, 31);
            this.RollNumberLabel.TabIndex = 4;
            this.RollNumberLabel.Text = "0";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 912);
            this.Controls.Add(this.RollNumberLabel);
            this.Controls.Add(this.CurrentRollLabel);
            this.Controls.Add(this.RollDiceButton);
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
        private System.Windows.Forms.Label OreLabel;
        private System.Windows.Forms.Label GrainLabel;
        private System.Windows.Forms.Label LumberLabel;
        private System.Windows.Forms.Label WoolAmountLabel;
        private System.Windows.Forms.Label BrickAmountLabel;
        private System.Windows.Forms.Label GrainAmountLabel;
        private System.Windows.Forms.Label LumberAmountLabel;
        private System.Windows.Forms.Label OreAmountLabel;
        private System.Windows.Forms.Label WoolLabel;
        private System.Windows.Forms.Label BrickLabel;
        private System.Windows.Forms.Button generateResourcesTest;
        private System.Windows.Forms.Button RollDiceButton;
        private System.Windows.Forms.Label CurrentRollLabel;
        private System.Windows.Forms.Label RollNumberLabel;
    }
}