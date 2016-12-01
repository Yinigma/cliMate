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
    public partial class MainWindow : Form
    {
        Project currentProject;
        NodeMap map;
        Node selectedNode;

        public MainWindow()
        {
            
            InitializeComponent();
            testPanel.Click += TestPanel_Click;
            currentProject = new Project();
            nodePanel.Map = currentProject.getMap();
            nodePanel.CurrentNode = NodePanel.NONE;
            selectedNode = null;
        }

        //Draws the equiGrid
        private void TestPanel_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            Graphics g = testPanel.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.Red);
            GridDisplayEquiRect.Hexagon[] hexList = currentProject.EquiDisp.dispHex;
            PointF[] curHex = new PointF[6];
            float offX = testPanel.Width / 2.0f;
            float offY = testPanel.Height / 2.0f;
            int brightness;
            for (int i = 0; i< hexList.Length; i++)
            {
                brightness = r.Next(256);
                b.Color = Color.FromArgb(brightness,brightness,brightness);
                if (!hexList[i].isEdge)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        curHex[j] = new PointF(offX + hexList[i].equiVec[j].X * (testPanel.Width / 2.0f), offY + hexList[i].equiVec[j].Y * (testPanel.Height / 2.0f));
                    }
                    g.FillPolygon(b, curHex);
                }
                else
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (hexList[i].equiVec[j].X <= 0)
                        {
                            curHex[j] = new PointF(testPanel.Width + offX + hexList[i].equiVec[j].X * (testPanel.Width / 2.0f), offY + hexList[i].equiVec[j].Y * (testPanel.Height / 2.0f));
                        }
                        else
                        {
                            curHex[j] = new PointF(offX + hexList[i].equiVec[j].X * (testPanel.Width / 2.0f), offY + hexList[i].equiVec[j].Y * (testPanel.Height / 2.0f));
                        }
                    }
                    g.FillPolygon(b, curHex);
                    for (int j = 0; j < 6; j++)
                    {
                        if (hexList[i].equiVec[j].X >= 0)
                        {
                            curHex[j] = new PointF(-testPanel.Width + offX + hexList[i].equiVec[j].X * (testPanel.Width / 2.0f), offY + hexList[i].equiVec[j].Y * (testPanel.Height / 2.0f));
                        }
                        else
                        {
                            curHex[j] = new PointF(offX + hexList[i].equiVec[j].X * (testPanel.Width / 2.0f), offY + hexList[i].equiVec[j].Y * (testPanel.Height / 2.0f));
                        }
                    }
                    g.FillPolygon(b, curHex);
                }
            }
            testPanel.Update();
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            nodePanel.CurrentNode = NodePanel.OUTPUT;
        }

        private void fileImportButton_Click(object sender, EventArgs e)
        {
            nodePanel.CurrentNode = NodePanel.FILE;
        }
        private void debugButton_Click(object sender, EventArgs e)
        {
            nodePanel.CurrentNode = NodePanel.DEBUG;
        }
        private void debugInputButton_Click(object sender, EventArgs e)
        {
            nodePanel.CurrentNode = NodePanel.DEBUG2;
        }
        private void perlinNoiseButton_Click(object sender, EventArgs e)
        {
            nodePanel.CurrentNode = NodePanel.NOISE;
        }
        private void DrawMapButton_Click(object sender, EventArgs e)
        {
            nodePanel.CurrentNode = NodePanel.DRAW;
        }

        private void mapDisplay_Click(object sender, EventArgs e)
        {
            
            selectedNode = nodePanel.Selected;
            if (selectedNode != null)
            {
                Graphics g = this.mapDisplay.CreateGraphics();
                g.DrawImage(selectedNode.ToBitmap(),new Point(0,0));
            }
        }

       
    }
}
