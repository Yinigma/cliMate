namespace ProjectCeres
{
    partial class NoiseForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.PersBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.OctBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LacBox = new System.Windows.Forms.TextBox();
            this.FrequencyGroupBox = new System.Windows.Forms.GroupBox();
            this.FreqBox = new System.Windows.Forms.TextBox();
            this.seedBox = new System.Windows.Forms.TextBox();
            this.seedGroupBox = new System.Windows.Forms.GroupBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.previewGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.FrequencyGroupBox.SuspendLayout();
            this.seedGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.previewGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(151, 490);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(101, 258);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 17;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            // 
            // PersBox
            // 
            this.PersBox.Location = new System.Drawing.Point(6, 19);
            this.PersBox.Name = "PersBox";
            this.PersBox.Size = new System.Drawing.Size(77, 20);
            this.PersBox.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PersBox);
            this.groupBox3.Location = new System.Drawing.Point(84, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 54);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Persistance";
            // 
            // OctBox
            // 
            this.OctBox.Location = new System.Drawing.Point(10, 19);
            this.OctBox.Name = "OctBox";
            this.OctBox.Size = new System.Drawing.Size(77, 20);
            this.OctBox.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OctBox);
            this.groupBox2.Location = new System.Drawing.Point(151, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(109, 54);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Octave Count";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LacBox);
            this.groupBox1.Location = new System.Drawing.Point(14, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 54);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lacunarity";
            // 
            // LacBox
            // 
            this.LacBox.Location = new System.Drawing.Point(9, 19);
            this.LacBox.Name = "LacBox";
            this.LacBox.Size = new System.Drawing.Size(77, 20);
            this.LacBox.TabIndex = 3;
            // 
            // FrequencyGroupBox
            // 
            this.FrequencyGroupBox.Controls.Add(this.FreqBox);
            this.FrequencyGroupBox.Location = new System.Drawing.Point(151, 34);
            this.FrequencyGroupBox.Name = "FrequencyGroupBox";
            this.FrequencyGroupBox.Size = new System.Drawing.Size(110, 54);
            this.FrequencyGroupBox.TabIndex = 23;
            this.FrequencyGroupBox.TabStop = false;
            this.FrequencyGroupBox.Text = "Frequency";
            // 
            // FreqBox
            // 
            this.FreqBox.Location = new System.Drawing.Point(10, 19);
            this.FreqBox.Name = "FreqBox";
            this.FreqBox.Size = new System.Drawing.Size(77, 20);
            this.FreqBox.TabIndex = 3;
            // 
            // seedBox
            // 
            this.seedBox.Location = new System.Drawing.Point(9, 19);
            this.seedBox.Name = "seedBox";
            this.seedBox.Size = new System.Drawing.Size(77, 20);
            this.seedBox.TabIndex = 2;
            // 
            // seedGroupBox
            // 
            this.seedGroupBox.Controls.Add(this.seedBox);
            this.seedGroupBox.Location = new System.Drawing.Point(14, 34);
            this.seedGroupBox.Name = "seedGroupBox";
            this.seedGroupBox.Size = new System.Drawing.Size(109, 54);
            this.seedGroupBox.TabIndex = 21;
            this.seedGroupBox.TabStop = false;
            this.seedGroupBox.Text = "Seed";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(48, 490);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 18;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(54, 19);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(148, 140);
            this.previewBox.TabIndex = 5;
            this.previewBox.TabStop = false;
            // 
            // previewGroupBox
            // 
            this.previewGroupBox.Controls.Add(this.previewBox);
            this.previewGroupBox.Location = new System.Drawing.Point(14, 298);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(247, 169);
            this.previewGroupBox.TabIndex = 22;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Preview";
            // 
            // NoiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 558);
            this.Controls.Add(this.previewGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FrequencyGroupBox);
            this.Controls.Add(this.seedGroupBox);
            this.Controls.Add(this.OKButton);
            this.Name = "NoiseForm";
            this.Text = "Noise";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.FrequencyGroupBox.ResumeLayout(false);
            this.FrequencyGroupBox.PerformLayout();
            this.seedGroupBox.ResumeLayout(false);
            this.seedGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.previewGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox PersBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox OctBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox LacBox;
        private System.Windows.Forms.GroupBox FrequencyGroupBox;
        private System.Windows.Forms.TextBox FreqBox;
        private System.Windows.Forms.TextBox seedBox;
        private System.Windows.Forms.GroupBox seedGroupBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.GroupBox previewGroupBox;
    }
}