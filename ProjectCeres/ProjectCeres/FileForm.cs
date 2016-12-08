using System;
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
        //private Bitmap image;
        private Bitmap currentImage;
        private FileNode node;
        private int projectWidth;
        private int projectHeight;
        bool isLoaded;
        bool isValid;

        public FileForm(FileNode fn)
        {
            InitializeComponent();
            xBox.LostFocus += XBox_LostFocus;
            yBox.LostFocus += YBox_LostFocus;
            xScaleBox.LostFocus += XScaleBox_LostFocus;
            yScaleBox.LostFocus += YScaleBox_LostFocus;
            xPos = fn.XPos;
            yPos = fn.YPos;
            xScale = fn.XScale;
            yScale = fn.YScale;
            node = fn;
            currentImage = fn.image;
            okButton.Enabled = (currentImage!=null);
            projectWidth = node.getOutputGrid().Width;
            projectHeight = node.getOutputGrid().Height;
            isLoaded = (currentImage != null);
            isValid = false;
            updateText();
        }

        private void updateText()
        {
            yScaleBox.Text = "" + yScale;
            xScaleBox.Text = "" + xScale;
            xBox.Text = "" + xPos;
            yBox.Text = "" + yPos;
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
            isValid = true;
            Close();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.bmp, *.png) | *.jpg; *.jpeg; *.jpe; *.bmp; *.png";
            ofd.Title = "Heightmap from file";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentImage = new Bitmap(ofd.FileName);
                xScale = (float)projectWidth / currentImage.Width;
                yScale = (float)projectHeight / currentImage.Height;
                okButton.Enabled = true;
                isLoaded = true;
                loadPreview();
                updateText();
            }
            /*xBox.ReadOnly = false;
            yBox.ReadOnly = false;
            xScaleBox.ReadOnly = false;
            xScaleBox.ReadOnly = false;*/
            
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
        public bool Valid { get { return isLoaded&&isValid; } }
        public float XScale { get { return xScale; } }
        public float YScale { get { return yScale; } }
        public int XPosition { get { return xPos; } }
        public int YPosition { get { return yPos; } }
        public Bitmap LoadedImage { get { return currentImage; } }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xScale = (float)projectWidth / currentImage.Width;
            yScale = (float)projectHeight / currentImage.Height;
            updateText();
            loadPreview();
        }
    }
}
