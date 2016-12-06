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
    public partial class MainWindow : Form
    {
        int counterDB;
        Project currentProject;
        NodeMap map;
        Node selectedNode;
        private static readonly ColorGrad.gradElement[][] DISPMODES = { ColorGrad.LandGradient, ColorGrad.tempGradient };

        public MainWindow()
        {
            
            InitializeComponent();
            testPanel.Click += TestPanel_Click;
            //DisplayOptionBox.
            currentProject = new Project();
            nodePanel.Map = currentProject.getMap();
            nodePanel.CurrentNode = NodePanel.NONE;
            selectedNode = null;
            mapDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            DisplayOptionBox.SelectedIndex = 0;
            counterDB = 0;
        }

        //Draws the equiGrid
        private void TestPanel_Click(object sender, EventArgs e)
        {
            renderGrid();
        }

        public void renderGrid()
        {
            if (selectedNode == null)
            {
                return;
            }
            Graphics g = testPanel.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.Red);
            GridDisplayEquiRect.Hexagon[] hexList = currentProject.EquiDisp.dispHex;
            GeoGrid geo = new GeoGrid(currentProject.Frequency);
            PointF[] curHex = new PointF[6];
            float offX = testPanel.Width / 2.0f;
            float offY = testPanel.Height / 2.0f;
            int brightness;

            RectGrid moisture = Biomes.moisture(selectedNode.getOutputGrid(), currentProject,6);
            currentProject.EquiDisp.RectToGeo(moisture, geo);

            //currentProject.EquiDisp.RectToGeo(selectedNode.getOutputGrid(), geo);


            //geo = Biomes.seaLevel(geo, currentProject);
            //currentProject.EquiDisp.LoadGrid(geo);

            /*Tile[] mates = geo.neighbors(0,geo.getFrequency()-1,1);
            for(int i=0; i<mates.Length; i++)
            {
                mates[i].Value = 0.1f * i;
            }*/

            for (int i = 0; i < hexList.Length; i++)
            {
                brightness = (int)(hexList[i].tile.Value * 255);
                b.Color = Color.FromArgb(brightness, brightness, brightness);
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
            counterDB++;
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
                if (DisplayOptionBox.SelectedIndex == 0)
                {
                    mapDisplay.Image = selectedNode.getOutputGrid().gridToBitmapOcean(ColorGrad.LandGradient,ColorGrad.OceanGradient,currentProject.SeaLevel);
                }
                else if (DisplayOptionBox.SelectedIndex == 1)
                {
                    mapDisplay.Image = selectedNode.ToBitmap();
                }
                else if (DisplayOptionBox.SelectedIndex == 2)
                {
                    RectGrid moisture = Biomes.moisture(selectedNode.getOutputGrid(),currentProject, 3*currentProject.Frequency);
                    mapDisplay.Image = moisture.gridToBitmap(ColorGrad.MoistureGradient);
                }
            }
        }

        
    }
}
