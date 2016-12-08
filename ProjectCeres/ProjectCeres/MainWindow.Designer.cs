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
            this.combinerButton = new System.Windows.Forms.ToolStripButton();
            this.clampButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.outputButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.debugButton = new System.Windows.Forms.ToolStripButton();
            this.debugInputButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteAll = new System.Windows.Forms.ToolStripButton();
            this.imageTab = new System.Windows.Forms.TabPage();
            this.desertBox = new System.Windows.Forms.ComboBox();
            this.savBox = new System.Windows.Forms.ComboBox();
            this.tropBox = new System.Windows.Forms.ComboBox();
            this.temperBox = new System.Windows.Forms.ComboBox();
            this.seasonBox = new System.Windows.Forms.ComboBox();
            this.borBox = new System.Windows.Forms.ComboBox();
            this.woodBox = new System.Windows.Forms.ComboBox();
            this.grassBox = new System.Windows.Forms.ComboBox();
            this.tundraBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.seasonLabel = new System.Windows.Forms.Label();
            this.SeasonSwitcher = new System.Windows.Forms.ComboBox();
            this.DispLabel = new System.Windows.Forms.Label();
            this.DisplayOptionBox = new System.Windows.Forms.ComboBox();
            this.mapDisplay = new System.Windows.Forms.PictureBox();
            this.testTab = new System.Windows.Forms.TabPage();
            this.testPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.openProjectDialog = new System.Windows.Forms.OpenFileDialog();
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
            this.nodePanel.Selected = null;
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
            this.combinerButton,
            this.clampButton,
            this.toolStripSeparator2,
            this.outputButton,
            this.toolStripSeparator3,
            this.debugButton,
            this.debugInputButton,
            this.DeleteAll});
            this.NodeToolStrip.Location = new System.Drawing.Point(3, 3);
            this.NodeToolStrip.Name = "NodeToolStrip";
            this.NodeToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.NodeToolStrip.Size = new System.Drawing.Size(32, 381);
            this.NodeToolStrip.TabIndex = 0;
            this.NodeToolStrip.Text = "toolStrip1";
            // 
            // fileImportButton
            // 
            this.fileImportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fileImportButton.Image = global::ProjectCeres.Properties.Resources.file;
            this.fileImportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileImportButton.Name = "fileImportButton";
            this.fileImportButton.Size = new System.Drawing.Size(29, 24);
            this.fileImportButton.Text = "File Import";
            this.fileImportButton.Click += new System.EventHandler(this.fileImportButton_Click);
            // 
            // perlinNoiseButton
            // 
            this.perlinNoiseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.perlinNoiseButton.Image = global::ProjectCeres.Properties.Resources.perlin2;
            this.perlinNoiseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.perlinNoiseButton.Name = "perlinNoiseButton";
            this.perlinNoiseButton.Size = new System.Drawing.Size(29, 24);
            this.perlinNoiseButton.Text = "Noise Node";
            this.perlinNoiseButton.Click += new System.EventHandler(this.perlinNoiseButton_Click);
            // 
            // plateSimButton
            // 
            this.plateSimButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.plateSimButton.Image = global::ProjectCeres.Properties.Resources.tectonics2;
            this.plateSimButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plateSimButton.Name = "plateSimButton";
            this.plateSimButton.Size = new System.Drawing.Size(29, 24);
            this.plateSimButton.Text = "Tectonic Node";
            // 
            // DrawMapButton
            // 
            this.DrawMapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawMapButton.Image = global::ProjectCeres.Properties.Resources.drawing;
            this.DrawMapButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawMapButton.Name = "DrawMapButton";
            this.DrawMapButton.Size = new System.Drawing.Size(29, 24);
            this.DrawMapButton.Text = "Drawing Node";
            this.DrawMapButton.Click += new System.EventHandler(this.DrawMapButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(29, 6);
            // 
            // combinerButton
            // 
            this.combinerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.combinerButton.Image = ((System.Drawing.Image)(resources.GetObject("combinerButton.Image")));
            this.combinerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.combinerButton.Name = "combinerButton";
            this.combinerButton.Size = new System.Drawing.Size(29, 24);
            this.combinerButton.Text = "Combiner";
            this.combinerButton.Click += new System.EventHandler(this.combinerButton_Click);
            // 
            // clampButton
            // 
            this.clampButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clampButton.Image = ((System.Drawing.Image)(resources.GetObject("clampButton.Image")));
            this.clampButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clampButton.Name = "clampButton";
            this.clampButton.Size = new System.Drawing.Size(29, 24);
            this.clampButton.Text = "toolStripButton7";
            this.clampButton.ToolTipText = "Clamp";
            this.clampButton.Click += new System.EventHandler(this.clampButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(29, 6);
            // 
            // outputButton
            // 
            this.outputButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.outputButton.Image = global::ProjectCeres.Properties.Resources.output;
            this.outputButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(29, 24);
            this.outputButton.Text = "Output Node";
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(29, 6);
            // 
            // debugButton
            // 
            this.debugButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.debugButton.Image = ((System.Drawing.Image)(resources.GetObject("debugButton.Image")));
            this.debugButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(29, 24);
            this.debugButton.Text = "Debug";
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // debugInputButton
            // 
            this.debugInputButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.debugInputButton.Image = ((System.Drawing.Image)(resources.GetObject("debugInputButton.Image")));
            this.debugInputButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugInputButton.Name = "debugInputButton";
            this.debugInputButton.Size = new System.Drawing.Size(29, 24);
            this.debugInputButton.Text = "debugInput";
            this.debugInputButton.Click += new System.EventHandler(this.debugInputButton_Click);
            // 
            // DeleteAll
            // 
            this.DeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteAll.Image = global::ProjectCeres.Properties.Resources.DeleteAll;
            this.DeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteAll.Name = "DeleteAll";
            this.DeleteAll.Size = new System.Drawing.Size(29, 24);
            this.DeleteAll.Text = "Delete All";
            this.DeleteAll.Click += new System.EventHandler(this.DeleteAll_Click);
            // 
            // imageTab
            // 
            this.imageTab.Controls.Add(this.desertBox);
            this.imageTab.Controls.Add(this.savBox);
            this.imageTab.Controls.Add(this.tropBox);
            this.imageTab.Controls.Add(this.temperBox);
            this.imageTab.Controls.Add(this.seasonBox);
            this.imageTab.Controls.Add(this.borBox);
            this.imageTab.Controls.Add(this.woodBox);
            this.imageTab.Controls.Add(this.grassBox);
            this.imageTab.Controls.Add(this.tundraBox);
            this.imageTab.Controls.Add(this.label9);
            this.imageTab.Controls.Add(this.label8);
            this.imageTab.Controls.Add(this.label7);
            this.imageTab.Controls.Add(this.label6);
            this.imageTab.Controls.Add(this.label5);
            this.imageTab.Controls.Add(this.label4);
            this.imageTab.Controls.Add(this.label3);
            this.imageTab.Controls.Add(this.label2);
            this.imageTab.Controls.Add(this.label1);
            this.imageTab.Controls.Add(this.seasonLabel);
            this.imageTab.Controls.Add(this.SeasonSwitcher);
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
            // desertBox
            // 
            this.desertBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.desertBox.FormattingEnabled = true;
            this.desertBox.Items.AddRange(new object[] {
            "Tundra",
            "Grassland",
            "Woodland",
            "Boreal ",
            "Seasonal",
            "Temperate",
            "Tropical",
            "Savanna",
            "Desert"});
            this.desertBox.Location = new System.Drawing.Point(132, 351);
            this.desertBox.Margin = new System.Windows.Forms.Padding(2);
            this.desertBox.Name = "desertBox";
            this.desertBox.Size = new System.Drawing.Size(92, 21);
            this.desertBox.TabIndex = 32;
            // 
            // savBox
            // 
            this.savBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.savBox.FormattingEnabled = true;
            this.savBox.Items.AddRange(new object[] {
            "Tundra",
            "Grassland",
            "Woodland",
            "Boreal ",
            "Seasonal",
            "Temperate",
            "Tropical",
            "Savanna",
            "Desert"});
            this.savBox.Location = new System.Drawing.Point(132, 327);
            this.savBox.Margin = new System.Windows.Forms.Padding(2);
            this.savBox.Name = "savBox";
            this.savBox.Size = new System.Drawing.Size(92, 21);
            this.savBox.TabIndex = 31;
            // 
            // tropBox
            // 
            this.tropBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tropBox.FormattingEnabled = true;
            this.tropBox.Items.AddRange(new object[] {
            "Tundra",
            "Grassland",
            "Woodland",
            "Boreal ",
            "Seasonal",
            "Temperate",
            "Tropical",
            "Savanna",
            "Desert"});
            this.tropBox.Location = new System.Drawing.Point(132, 302);
            this.tropBox.Margin = new System.Windows.Forms.Padding(2);
            this.tropBox.Name = "tropBox";
            this.tropBox.Size = new System.Drawing.Size(92, 21);
            this.tropBox.TabIndex = 30;
            // 
            // temperBox
            // 
            this.temperBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.temperBox.FormattingEnabled = true;
            this.temperBox.Items.AddRange(new object[] {
            "Tundra",
            "Grassland",
            "Woodland",
            "Boreal ",
            "Seasonal",
            "Temperate",
            "Tropical",
            "Savanna",
            "Desert"});
            this.temperBox.Location = new System.Drawing.Point(132, 277);
            this.temperBox.Margin = new System.Windows.Forms.Padding(2);
            this.temperBox.Name = "temperBox";
            this.temperBox.Size = new System.Drawing.Size(92, 21);
            this.temperBox.TabIndex = 29;
            // 
            // seasonBox
            // 
            this.seasonBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seasonBox.FormattingEnabled = true;
            this.seasonBox.Items.AddRange(new object[] {
            "Tundra",
            "Grassland",
            "Woodland",
            "Boreal ",
            "Seasonal",
            "Temperate",
            "Tropical",
            "Savanna",
            "Desert"});
            this.seasonBox.Location = new System.Drawing.Point(132, 252);
            this.seasonBox.Margin = new System.Windows.Forms.Padding(2);
            this.seasonBox.Name = "seasonBox";
            this.seasonBox.Size = new System.Drawing.Size(92, 21);
            this.seasonBox.TabIndex = 28;
            // 
            // borBox
            // 
            this.borBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.borBox.FormattingEnabled = true;
            this.borBox.Items.AddRange(new object[] {
            "Tundra",
            "Grassland",
            "Woodland",
            "Boreal ",
            "Seasonal",
            "Temperate",
            "Tropical",
            "Savanna",
            "Desert"});
            this.borBox.Location = new System.Drawing.Point(132, 227);
            this.borBox.Margin = new System.Windows.Forms.Padding(2);
            this.borBox.Name = "borBox";
            this.borBox.Size = new System.Drawing.Size(92, 21);
            this.borBox.TabIndex = 27;
            // 
            // woodBox
            // 
            this.woodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.woodBox.FormattingEnabled = true;
            this.woodBox.Items.AddRange(new object[] {
            "Tundra",
            "Grassland",
            "Woodland",
            "Boreal ",
            "Seasonal",
            "Temperate",
            "Tropical",
            "Savanna",
            "Desert"});
            this.woodBox.Location = new System.Drawing.Point(132, 202);
            this.woodBox.Margin = new System.Windows.Forms.Padding(2);
            this.woodBox.Name = "woodBox";
            this.woodBox.Size = new System.Drawing.Size(92, 21);
            this.woodBox.TabIndex = 26;
            // 
            // grassBox
            // 
            this.grassBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.grassBox.FormattingEnabled = true;
            this.grassBox.Items.AddRange(new object[] {
            "Tundra",
            "Grassland",
            "Woodland",
            "Boreal ",
            "Seasonal",
            "Temperate",
            "Tropical",
            "Savanna",
            "Desert"});
            this.grassBox.Location = new System.Drawing.Point(132, 178);
            this.grassBox.Margin = new System.Windows.Forms.Padding(2);
            this.grassBox.Name = "grassBox";
            this.grassBox.Size = new System.Drawing.Size(92, 21);
            this.grassBox.TabIndex = 25;
            // 
            // tundraBox
            // 
            this.tundraBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tundraBox.FormattingEnabled = true;
            this.tundraBox.Items.AddRange(new object[] {
            "Tundra",
            "Grassland",
            "Woodland",
            "Boreal ",
            "Seasonal",
            "Temperate",
            "Tropical",
            "Savanna",
            "Desert"});
            this.tundraBox.Location = new System.Drawing.Point(132, 153);
            this.tundraBox.Margin = new System.Windows.Forms.Padding(2);
            this.tundraBox.Name = "tundraBox";
            this.tundraBox.Size = new System.Drawing.Size(92, 21);
            this.tundraBox.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 351);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Replace Desert With";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 330);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Replace Savanna With";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 305);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Replace Tropical With";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 280);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Replace Temperate With";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 255);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Replace Seasonal With";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 230);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Replace Boreal With";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 205);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Replace Woodland With";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Replace Grassland With";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 156);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Replace Tundra With";
            // 
            // seasonLabel
            // 
            this.seasonLabel.AutoSize = true;
            this.seasonLabel.Location = new System.Drawing.Point(11, 200);
            this.seasonLabel.Name = "seasonLabel";
            this.seasonLabel.Size = new System.Drawing.Size(43, 13);
            this.seasonLabel.TabIndex = 4;
            this.seasonLabel.Text = "Season (Northern Hemisphere)";
            // 
            // SeasonSwitcher
            // 
            this.SeasonSwitcher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SeasonSwitcher.FormattingEnabled = true;
            this.SeasonSwitcher.Items.AddRange(new object[] {
            "Normal",
            "Summer",
            "Winter"});
            this.SeasonSwitcher.Location = new System.Drawing.Point(8, 219);
            this.SeasonSwitcher.Name = "SeasonSwitcher";
            this.SeasonSwitcher.Size = new System.Drawing.Size(134, 21);
            this.SeasonSwitcher.TabIndex = 3;
            this.SeasonSwitcher.SelectedIndexChanged += new System.EventHandler(this.SeasonSwitcher_SelectedIndexChanged);
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
            this.DisplayOptionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
<<<<<<< HEAD
            // mapDisplay
            // 
            this.mapDisplay.InitialImage = global::ProjectCeres.Properties.Resources.bobrossEdit;
            this.mapDisplay.Location = new System.Drawing.Point(245, -3);
            this.mapDisplay.Name = "mapDisplay";
            this.mapDisplay.Size = new System.Drawing.Size(597, 387);
=======

            // mapDisplay
            // 
            this.mapDisplay.InitialImage = global::ProjectCeres.Properties.Resources.bobrossEdit;
            this.mapDisplay.Location = new System.Drawing.Point(205, 0);
            this.mapDisplay.Name = "mapDisplay";
            this.mapDisplay.Size = new System.Drawing.Size(633, 387);
>>>>>>> 168c3da29b8e36ffc5c1cb359d947cfa68816a37
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
            this.menuStrip1.BackgroundImage = global::ProjectCeres.Properties.Resources.menuBackground;
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
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem1});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            // 
            // projectToolStripMenuItem1
            // 
            this.projectToolStripMenuItem1.Name = "projectToolStripMenuItem1";
            this.projectToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.projectToolStripMenuItem1.Text = "Project";
            this.projectToolStripMenuItem1.Click += new System.EventHandler(this.projectToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveProjectAsToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            // 
            // saveProjectAsToolStripMenuItem
            // 
            this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveProjectAsToolStripMenuItem.Text = "Save project as";
            this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
            // 
            // openProjectDialog
            // 
            this.openProjectDialog.FileName = "openFileDialog1";
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CliMate";
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
        private System.Windows.Forms.ToolStripButton clampButton;
        private System.Windows.Forms.Label DispLabel;
        private System.Windows.Forms.ComboBox DisplayOptionBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton outputButton;
        private NodePanel nodePanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton debugButton;
        private System.Windows.Forms.ToolStripButton debugInputButton;
        private System.Windows.Forms.Panel testPanel;
        private System.Windows.Forms.Label seasonLabel;
        private System.Windows.Forms.ComboBox SeasonSwitcher;
        private System.Windows.Forms.ComboBox desertBox;
        private System.Windows.Forms.ComboBox savBox;
        private System.Windows.Forms.ComboBox tropBox;
        private System.Windows.Forms.ComboBox temperBox;
        private System.Windows.Forms.ComboBox seasonBox;
        private System.Windows.Forms.ComboBox borBox;
        private System.Windows.Forms.ComboBox woodBox;
        private System.Windows.Forms.ComboBox grassBox;
        private System.Windows.Forms.ComboBox tundraBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton DeleteAll;
        private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveProjectDialog;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openProjectDialog;
        private System.Windows.Forms.ToolStripButton combinerButton;
    }
}
