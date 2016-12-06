namespace ProjectCeres
{
    partial class Canvas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Canvas));
            this.tempPicBox = new System.Windows.Forms.PictureBox();
            this.tickTimer = new System.Windows.Forms.Timer(this.components);
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.brushSettingsPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.brushSpeedBox = new System.Windows.Forms.NumericUpDown();
            this.brushTypePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.brushSizeBox = new System.Windows.Forms.NumericUpDown();
            this.toolboxPanel = new System.Windows.Forms.Panel();
            this.toolLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tempPicBox)).BeginInit();
            this.drawingPanel.SuspendLayout();
            this.brushSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushSpeedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeBox)).BeginInit();
            this.toolboxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tempPicBox
            // 
            this.tempPicBox.Location = new System.Drawing.Point(2, 2);
            this.tempPicBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tempPicBox.Name = "tempPicBox";
            this.tempPicBox.Size = new System.Drawing.Size(434, 362);
            this.tempPicBox.TabIndex = 0;
            this.tempPicBox.TabStop = false;
            // 
            // tickTimer
            // 
            this.tickTimer.Interval = 10;
            this.tickTimer.Tick += new System.EventHandler(this.tickTimer_Tick);
            // 
            // drawingPanel
            // 
            this.drawingPanel.AutoScroll = true;
            this.drawingPanel.Controls.Add(this.tempPicBox);
            this.drawingPanel.Location = new System.Drawing.Point(9, 10);
            this.drawingPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(517, 481);
            this.drawingPanel.TabIndex = 1;
            // 
            // brushSettingsPanel
            // 
            this.brushSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.brushSettingsPanel.Controls.Add(this.label4);
            this.brushSettingsPanel.Controls.Add(this.label3);
            this.brushSettingsPanel.Controls.Add(this.brushSpeedBox);
            this.brushSettingsPanel.Controls.Add(this.brushTypePanel);
            this.brushSettingsPanel.Controls.Add(this.label2);
            this.brushSettingsPanel.Controls.Add(this.label1);
            this.brushSettingsPanel.Controls.Add(this.brushSizeBox);
            this.brushSettingsPanel.Location = new System.Drawing.Point(530, 12);
            this.brushSettingsPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brushSettingsPanel.Name = "brushSettingsPanel";
            this.brushSettingsPanel.Size = new System.Drawing.Size(100, 479);
            this.brushSettingsPanel.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Brush Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Brush speed";
            // 
            // brushSpeedBox
            // 
            this.brushSpeedBox.Location = new System.Drawing.Point(4, 102);
            this.brushSpeedBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brushSpeedBox.Name = "brushSpeedBox";
            this.brushSpeedBox.Size = new System.Drawing.Size(90, 20);
            this.brushSpeedBox.TabIndex = 5;
            // 
            // brushTypePanel
            // 
            this.brushTypePanel.Location = new System.Drawing.Point(4, 192);
            this.brushTypePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brushTypePanel.Name = "brushTypePanel";
            this.brushTypePanel.Size = new System.Drawing.Size(88, 154);
            this.brushTypePanel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Brush Shape";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Brush size";
            // 
            // brushSizeBox
            // 
            this.brushSizeBox.Location = new System.Drawing.Point(2, 54);
            this.brushSizeBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brushSizeBox.Name = "brushSizeBox";
            this.brushSizeBox.Size = new System.Drawing.Size(90, 20);
            this.brushSizeBox.TabIndex = 1;
            // 
            // toolboxPanel
            // 
            this.toolboxPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolboxPanel.Controls.Add(this.toolLayoutPanel);
            this.toolboxPanel.Controls.Add(this.label5);
            this.toolboxPanel.Location = new System.Drawing.Point(640, 12);
            this.toolboxPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolboxPanel.Name = "toolboxPanel";
            this.toolboxPanel.Size = new System.Drawing.Size(100, 479);
            this.toolboxPanel.TabIndex = 7;
            // 
            // toolLayoutPanel
            // 
            this.toolLayoutPanel.Location = new System.Drawing.Point(3, 24);
            this.toolLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolLayoutPanel.Name = "toolLayoutPanel";
            this.toolLayoutPanel.Size = new System.Drawing.Size(91, 191);
            this.toolLayoutPanel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, -2);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Toolbox";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(9, 496);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(134, 48);
            this.confirmButton.TabIndex = 8;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(394, 496);
            this.resetButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(132, 49);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Canvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 554);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.toolboxPanel);
            this.Controls.Add(this.brushSettingsPanel);
            this.Controls.Add(this.drawingPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Canvas";
            this.Text = "Canvas";
            this.Load += new System.EventHandler(this.Canvas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tempPicBox)).EndInit();
            this.drawingPanel.ResumeLayout(false);
            this.brushSettingsPanel.ResumeLayout(false);
            this.brushSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushSpeedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeBox)).EndInit();
            this.toolboxPanel.ResumeLayout(false);
            this.toolboxPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox tempPicBox;
        private System.Windows.Forms.Timer tickTimer;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Panel brushSettingsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown brushSizeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel brushTypePanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown brushSpeedBox;
        private System.Windows.Forms.Panel toolboxPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel toolLayoutPanel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button resetButton;
    }
}