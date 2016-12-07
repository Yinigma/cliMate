namespace ProjectCeres
{
    partial class ClampForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.CutoffButton = new System.Windows.Forms.RadioButton();
            this.LimitButton = new System.Windows.Forms.RadioButton();
            this.minBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(46, 178);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(186, 178);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 1;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // CutoffButton
            // 
            this.CutoffButton.AutoSize = true;
            this.CutoffButton.Location = new System.Drawing.Point(186, 43);
            this.CutoffButton.Name = "CutoffButton";
            this.CutoffButton.Size = new System.Drawing.Size(53, 17);
            this.CutoffButton.TabIndex = 2;
            this.CutoffButton.TabStop = true;
            this.CutoffButton.Text = "Cutoff";
            this.CutoffButton.UseVisualStyleBackColor = true;
            // 
            // LimitButton
            // 
            this.LimitButton.AutoSize = true;
            this.LimitButton.Location = new System.Drawing.Point(186, 103);
            this.LimitButton.Name = "LimitButton";
            this.LimitButton.Size = new System.Drawing.Size(46, 17);
            this.LimitButton.TabIndex = 3;
            this.LimitButton.TabStop = true;
            this.LimitButton.Text = "Limit";
            this.LimitButton.UseVisualStyleBackColor = true;
            // 
            // minBox
            // 
            this.minBox.Location = new System.Drawing.Point(46, 100);
            this.minBox.Name = "minBox";
            this.minBox.Size = new System.Drawing.Size(100, 20);
            this.minBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Maximum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Minimum";
            // 
            // maxBox
            // 
            this.maxBox.Location = new System.Drawing.Point(46, 43);
            this.maxBox.Name = "maxBox";
            this.maxBox.Size = new System.Drawing.Size(100, 20);
            this.maxBox.TabIndex = 8;
            // 
            // ClampForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 218);
            this.Controls.Add(this.maxBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minBox);
            this.Controls.Add(this.LimitButton);
            this.Controls.Add(this.CutoffButton);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.OkButton);
            this.Name = "ClampForm";
            this.Text = "ClampForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.RadioButton CutoffButton;
        private System.Windows.Forms.RadioButton LimitButton;
        private System.Windows.Forms.TextBox minBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxBox;
    }
}