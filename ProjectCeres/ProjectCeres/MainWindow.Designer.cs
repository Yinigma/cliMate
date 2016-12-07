using System.Drawing;

namespace ProjectCeres
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.NodeTab = new System.Windows.Forms.TabPage();
            this.nodePanel = new ProjectCeres.NodePanel();
            this.NodeToolStrip = new System.Windows.Forms.ToolStrip();
            this.fileImportButton = new System.Windows.Forms.ToolStripButton();
            this.perlinNoiseButton = new System.Windows.Forms.ToolStripButton();
            this.plateSimButton = new System.Windows.Forms.ToolStripButton();
            this.DrawMapButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.outputButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.debugButton = new System.Windows.Forms.ToolStripButton();
            this.debugInputButton = new System.Windows.Forms.ToolStripButton();
            this.imageTab = new System.Windows.Forms.TabPage();
            this.DispLabel = new System.Windows.Forms.Label();
            this.DisplayOptionBox = new System.Windows.Forms.ComboBox();
            this.mapDisplay = new System.Windows.Forms.PictureBox();
            this.testTab = new System.Windows.Forms.TabPage();
            this.testPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTabs.SuspendLayout();
            this.NodeTab.SuspendLayout();
            this.NodeToolStrip.SuspendLayout();
            this.imageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapDisplay)).BeginInit();
            this.testTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabs
            // 
            this.MainTabs.Controls.Add(this.NodeTab);
            this.MainTabs.Controls.Add(this.imageTab);
            this.MainTabs.Controls.Add(this.testTab);
            this.MainTabs.Location = new System.Drawing.Point(0, 27);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(846, 413);
            this.MainTabs.TabIndex = 0;
            this.MainTabs.SelectedIndexChanged += new System.EventHandler(this.MainTabs_SelectedIndexChanged);
            // 
            // NodeTab
            // 
            this.NodeTab.Controls.Add(this.nodePanel);
            this.NodeTab.Controls.Add(this.NodeToolStrip);
            this.NodeTab.Location = new System.Drawing.Point(4, 22);
            this.NodeTab.Name = "NodeTab";
            this.NodeTab.Padding = new System.Windows.Forms.Padding(3);
            this.NodeTab.Size = new System.Drawing.Size(838, 387);
            this.NodeTab.TabIndex = 0;
            this.NodeTab.Text = "Nodes";
            this.NodeTab.UseVisualStyleBackColor = true;
            // 
            // nodePanel
            // 
            this.nodePanel.CurrentNode = 0;
            this.nodePanel.Location = new System.Drawing.Point(30, 0);
            this.nodePanel.Map = null;
            this.nodePanel.Name = "nodePanel";
            this.nodePanel.Size = new System.Drawing.Size(808, 387);
            this.nodePanel.TabIndex = 1;
            // 
            // NodeToolStrip
            // 
            this.NodeToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.NodeToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.NodeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileImportButton,
            this.perlinNoiseButton,
            this.plateSimButton,
            this.DrawMapButton,
            this.toolStripSeparator1,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripSeparator2,
            this.outputButton,
            this.toolStripSeparator3,
            this.debugButton,
            this.debugInputButton});
            this.NodeToolStrip.Location = new System.Drawing.Point(3, 3);
            this.NodeToolStrip.Name = "NodeToolStrip";
            this.NodeToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.NodeToolStrip.Size = new System.Drawing.Size(25, 381);
            this.NodeToolStrip.TabIndex = 0;
            this.NodeToolStrip.Text = "toolStrip1";
            // 
            // fileImportButton
            // 
            this.fileImportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fileImportButton.Image = global::ProjectCeres.Properties.Resources.file;
            this.fileImportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileImportButton.Name = "fileImportButton";
            this.fileImportButton.Size = new System.Drawing.Size(22, 24);
            this.fileImportButton.Text = "File Import";
            this.fileImportButton.Click += new System.EventHandler(this.fileImportButton_Click);
            // 
            // perlinNoiseButton
            // 
            this.perlinNoiseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.perlinNoiseButton.Image = global::ProjectCeres.Properties.Resources.perlin2;
            this.perlinNoiseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.perlinNoiseButton.Name = "perlinNoiseButton";
            this.perlinNoiseButton.Size = new System.Drawing.Size(22, 24);
            this.perlinNoiseButton.Text = "Noise Node";
            this.perlinNoiseButton.Click += new System.EventHandler(this.perlinNoiseButton_Click);
            // 
            // plateSimButton
            // 
            this.plateSimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.plateSimButton.Image = global::ProjectCeres.Properties.Resources.tectonics2;
            this.plateSimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plateSimButton.Name = "plateSimButton";
            this.plateSimButton.Size = new System.Drawing.Size(22, 24);
            this.plateSimButton.Text = "Tectonic Node";
            // 
            // DrawMapButton
            // 
            this.DrawMapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawMapButton.Image = global::ProjectCeres.Properties.Resources.drawing;
            this.DrawMapButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawMapButton.Name = "DrawMapButton";
            this.DrawMapButton.Size = new System.Drawing.Size(22, 24);
            this.DrawMapButton.Text = "Drawing Node";
            this.DrawMapButton.Click += new System.EventHandler(this.DrawMapButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(22, 6);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(22, 24);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(22, 24);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(22, 24);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(22, 6);
            // 
            // outputButton
            // 
            this.outputButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.outputButton.Image = global::ProjectCeres.Properties.Resources.output;
            this.outputButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(22, 24);
            this.outputButton.Text = "Output Node";
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(22, 6);
            // 
            // debugButton
            // 
            this.debugButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.debugButton.Image = ((System.Drawing.Image)(resources.GetObject("debugButton.Image")));
            this.debugButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(22, 24);
            this.debugButton.Text = "Debug";
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // debugInputButton
            // 
            this.debugInputButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.debugInputButton.Image = ((System.Drawing.Image)(resources.GetObject("debugInputButton.Image")));
            this.debugInputButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugInputButton.Name = "debugInputButton";
            this.debugInputButton.Size = new System.Drawing.Size(22, 24);
            this.debugInputButton.Text = "debugInput";
            this.debugInputButton.Click += new System.EventHandler(this.debugInputButton_Click);
            // 
            // imageTab
            // 
            this.imageTab.Controls.Add(this.DispLabel);
            this.imageTab.Controls.Add(this.DisplayOptionBox);
            this.imageTab.Controls.Add(this.mapDisplay);
            this.imageTab.Location = new System.Drawing.Point(4, 22);
            this.imageTab.Name = "imageTab";
            this.imageTab.Padding = new System.Windows.Forms.Padding(3);
            this.imageTab.Size = new System.Drawing.Size(838, 387);
            this.imageTab.TabIndex = 1;
            this.imageTab.Text = "Map";
            this.imageTab.UseVisualStyleBackColor = true;
            // 
            // DispLabel
            // 
            this.DispLabel.AutoSize = true;
            this.DispLabel.Location = new System.Drawing.Point(8, 141);
            this.DispLabel.Name = "DispLabel";
            this.DispLabel.Size = new System.Drawing.Size(41, 13);
            this.DispLabel.TabIndex = 2;
            this.DispLabel.Text = "Display";
            // 
            // DisplayOptionBox
            // 
            this.DisplayOptionBox.FormattingEnabled = true;
            this.DisplayOptionBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DisplayOptionBox.Items.AddRange(new object[] {
            "Height",
            "Temperature",
            "Moisture",
            "Biomes"});
            this.DisplayOptionBox.Location = new System.Drawing.Point(8, 157);
            this.DisplayOptionBox.Name = "DisplayOptionBox";
            this.DisplayOptionBox.Size = new System.Drawing.Size(134, 21);
            this.DisplayOptionBox.TabIndex = 1;
            this.DisplayOptionBox.SelectedIndexChanged += new System.EventHandler(this.DisplayOptionBox_SelectedIndexChanged);
            // 
            // mapDisplay
            // 
            this.mapDisplay.InitialImage = global::ProjectCeres.Properties.Resources.bobrossEdit;
            this.mapDisplay.Location = new System.Drawing.Point(205, 0);
            this.mapDisplay.Name = "mapDisplay";
            this.mapDisplay.Size = new System.Drawing.Size(633, 387);
            this.mapDisplay.TabIndex = 0;
            this.mapDisplay.TabStop = false;
            this.mapDisplay.Click += new System.EventHandler(this.mapDisplay_Click);
            // 
            // testTab
            // 
            this.testTab.Controls.Add(this.testPanel);
            this.testTab.Location = new System.Drawing.Point(4, 22);
            this.testTab.Name = "testTab";
            this.testTab.Size = new System.Drawing.Size(838, 387);
            this.testTab.TabIndex = 2;
            this.testTab.Text = "Test";
            this.testTab.UseVisualStyleBackColor = true;
            // 
            // testPanel
            // 
            this.testPanel.Location = new System.Drawing.Point(9, 3);
            this.testPanel.Name = "testPanel";
            this.testPanel.Size = new System.Drawing.Size(819, 377);
            this.testPanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "mainMenuStrip";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.newToolStripMenuItem.Text = "New..";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 441);
            this.Controls.Add(this.MainTabs);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Project Ceres";
            this.MainTabs.ResumeLayout(false);
            this.NodeTab.ResumeLayout(false);
            this.NodeTab.PerformLayout();
            this.NodeToolStrip.ResumeLayout(false);
            this.NodeToolStrip.PerformLayout();
            this.imageTab.ResumeLayout(false);
            this.imageTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapDisplay)).EndInit();
            this.testTab.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabs;
        private System.Windows.Forms.TabPage NodeTab;
        private System.Windows.Forms.TabPage imageTab;
        private System.Windows.Forms.TabPage testTab;
        private System.Windows.Forms.PictureBox mapDisplay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStrip NodeToolStrip;
        private System.Windows.Forms.ToolStripButton fileImportButton;
        private System.Windows.Forms.ToolStripButton perlinNoiseButton;
        private System.Windows.Forms.ToolStripButton plateSimButton;
        private System.Windows.Forms.ToolStripButton DrawMapButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.Label DispLabel;
        private System.Windows.Forms.ComboBox DisplayOptionBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton outputButton;
        private NodePanel nodePanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton debugButton;
        private System.Windows.Forms.ToolStripButton debugInputButton;
        private System.Windows.Forms.Panel testPanel;
    }
}

