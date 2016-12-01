﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCeres
{
    public partial class FileForm : Form
    {
        //position of the uploaded bitmap
        private int xPos;
        private int yPos;
        //Scale of the uploded bitmap
        private float xScale;
        private float yScale;
        //Image being displayed in the preview box that will be sent to the node
        private Bitmap image;
        private Bitmap currentImage;
        private FileNode node;
        private int projectWidth;
        private int projectHeight;
        bool isValid;

        public FileForm(FileNode fn)
        {
            InitializeComponent();
            lockBox.Checked = true;
            xBox.LostFocus += XBox_LostFocus;
            yBox.LostFocus += YBox_LostFocus;
            xScaleBox.LostFocus += XScaleBox_LostFocus;
            yScaleBox.LostFocus += YScaleBox_LostFocus;
            xPos = 0;
            yPos = 0;
            xScale = 1.0f;
            yScale = 1.0f;
            node = fn;
            image = new Bitmap(node.getOutputGrid().Width, node.getOutputGrid().Height);
            previewBox.Image = image;
            currentImage = null;
            /*xBox.ReadOnly = true;
            yBox.ReadOnly = true;
            xScaleBox.ReadOnly = true;
            yScaleBox.ReadOnly = true;*/
            okButton.Enabled = false;
            projectWidth = node.getOutputGrid().Width;
            projectHeight = node.getOutputGrid().Height;
            isValid = false;
        }

        private void YScaleBox_LostFocus(object sender, EventArgs e)
        {
            try { yScale = float.Parse(yScaleBox.Text); }
            catch (Exception fe) {/*do nothing*/}
            if (yScale <= 0)
            {
                yScale = 0.1f;
            }
            yScaleBox.Text = "" + yScale;
            loadPreview();
        }

        private void XScaleBox_LostFocus(object sender, EventArgs e)
        {
            try { xScale = float.Parse(xScaleBox.Text); }
            catch (Exception fe) {/*do nothing*/}
            if (xScale<=0)
            {
                xScale = 0.1f;
            }
            xScaleBox.Text = "" + xScale;
            loadPreview();
        }

        private void YBox_LostFocus(object sender, EventArgs e)
        {
            try { yPos = int.Parse(yBox.Text); }
            catch (Exception fe) {/*do nothing*/}
            yBox.Text = "" + yPos;
            loadPreview();
        }

        private void XBox_LostFocus(object sender, EventArgs e)
        {
            try { xPos = int.Parse(xBox.Text); }
            catch (Exception fe) {/*do nothing*/}
            xBox.Text = "" + xPos;
            loadPreview();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Purple things");
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.bmp, *.png) | *.jpg; *.jpeg; *.jpe; *.bmp; *.png";
            ofd.Title = "Heightmap from file";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentImage = new Bitmap(ofd.FileName);
            }
            MessageBox.Show("A flie dialog should have opened.");
            /*xBox.ReadOnly = false;
            yBox.ReadOnly = false;
            xScaleBox.ReadOnly = false;
            xScaleBox.ReadOnly = false;*/
            xScale = (float)projectWidth / currentImage.Width;
            yScale = (float)projectHeight / currentImage.Height;
            okButton.Enabled = true;
            isValid = true;
            loadPreview();
        }
        public void loadPreview()
        {
            if (currentImage != null)
            {
                //These calculations are for display only
                float projRatX = (float)previewBox.Width / projectWidth;
                float projRatY = (float)previewBox.Height / projectHeight;
                float correctedX = xPos * projRatX;
                float correctedY = yPos * projRatY;
                float correctedWidth = xScale * currentImage.Width * projRatX;
                float correctedHeight = yScale * currentImage.Height * projRatY;
                Graphics g = previewBox.CreateGraphics();
                g.Clear(previewBox.BackColor);
                g.DrawImage(currentImage, correctedX, correctedY, correctedWidth, correctedHeight);
                previewBox.Update();
            }
        }
        bool Valid { get { return isValid; } }
        float XScale { get { return xScale; } }
        float YScale { get { return yScale; } }
        int XPosition { get { return xPos; } }
        int YPosition { get { return yPos; } }
        Bitmap LoadedImage { get { return currentImage; } }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isValid = false;
            Close();
        }
    }
}
