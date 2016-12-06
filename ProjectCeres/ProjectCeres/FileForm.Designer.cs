namespace ProjectCeres
{
    partial class FileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileForm));
            this.xBox = new System.Windows.Forms.TextBox();
            this.Position = new System.Windows.Forms.Label();
            this.yBox = new System.Windows.Forms.TextBox();
            this.xPosition = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lockBox = new System.Windows.Forms.CheckBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.previewLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.yScaleBox = new System.Windows.Forms.TextBox();
            this.xScaleBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.previewBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(35, 102);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(77, 20);
            this.xBox.TabIndex = 0;
            // 
            // Position
            // 
            this.Position.AutoSize = true;
            this.Position.Location = new System.Drawing.Point(12, 83);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(44, 13);
            this.Position.TabIndex = 1;
            this.Position.Text = "Position";
            // 
            // yBox
            // 
            this.yBox.Location = new System.Drawing.Point(35, 128);
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(77, 20);
            this.yBox.TabIndex = 2;
            // 
            // xPosition
            // 
            this.xPosition.AutoSize = true;
            this.xPosition.Location = new System.Drawing.Point(12, 105);
            this.xPosition.Name = "xPosition";
            this.xPosition.Size = new System.Drawing.Size(14, 13);
            this.xPosition.TabIndex = 3;
            this.xPosition.Text = "X";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(12, 131);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(14, 13);
            this.yLabel.TabIndex = 4;
            this.yLabel.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Scale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "X";
            // 
            // lockBox
            // 
            this.lockBox.AutoSize = true;
            this.lockBox.Location = new System.Drawing.Point(15, 248);
            this.lockBox.Name = "lockBox";
            this.lockBox.Size = new System.Drawing.Size(78, 17);
            this.lockBox.TabIndex = 11;
            this.lockBox.Text = "Lock scale";
            this.lockBox.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(61, 33);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 12;
            this.loadButton.Text = "Load File";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Location = new System.Drawing.Point(232, 31);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(45, 13);
            this.previewLabel.TabIndex = 13;
            this.previewLabel.Text = "Preview";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(18, 353);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 35);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(99, 353);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 35);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "I regret everything";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // yScaleBox
            // 
            this.yScaleBox.Location = new System.Drawing.Point(35, 205);
            this.yScaleBox.Name = "yScaleBox";
            this.yScaleBox.Size = new System.Drawing.Size(77, 20);
            this.yScaleBox.TabIndex = 17;
            // 
            // xScaleBox
            // 
            this.xScaleBox.Location = new System.Drawing.Point(35, 179);
            this.xScaleBox.Name = "xScaleBox";
            this.xScaleBox.Size = new System.Drawing.Size(77, 20);
            this.xScaleBox.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Fit to map";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(232, 50);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(550, 360);
            this.previewBox.TabIndex = 5;
            this.previewBox.TabStop = false;
            // 
            // FileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 422);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.yScaleBox);
            this.Controls.Add(this.xScaleBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.lockBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xPosition);
            this.Controls.Add(this.yBox);
            this.Controls.Add(this.Position);
            this.Controls.Add(this.xBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileForm";
            this.Text = "Load an image";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.Label Position;
        private System.Windows.Forms.TextBox yBox;
        private System.Windows.Forms.Label xPosition;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox lockBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox yScaleBox;
        private System.Windows.Forms.TextBox xScaleBox;
        private System.Windows.Forms.Button button1;
    }
}