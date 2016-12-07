using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

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

        private void UpdateMapDisplay()
        {
            //Updates the map display in the map tab

            selectedNode = nodePanel.Selected;
            if (selectedNode != null)
            {
                if (DisplayOptionBox.SelectedIndex == 0)
                {
                    mapDisplay.Image = selectedNode.getOutputGrid().gridToBitmapOcean(ColorGrad.LandGradient, ColorGrad.OceanGradient, currentProject.SeaLevel);
                }
                else if (DisplayOptionBox.SelectedIndex == 1)
                {
                    if (SeasonSwitcher.SelectedIndex == 1)
                    {
                        mapDisplay.Image = Biomes.Temperature(selectedNode.getOutputGrid(), 0.4f).gridToBitmap(ColorGrad.tempGradient);
                    }
                    else if(SeasonSwitcher.SelectedIndex == 2)
                    {
                        mapDisplay.Image = Biomes.Temperature(selectedNode.getOutputGrid(), 0.6f).gridToBitmap(ColorGrad.tempGradient);
                    }
                    else
                    {
                        mapDisplay.Image = Biomes.Temperature(selectedNode.getOutputGrid()).gridToBitmap(ColorGrad.tempGradient);
                    }
                }
                else if (DisplayOptionBox.SelectedIndex == 2)
                {
                    RectGrid moisture = Biomes.moisture(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency);
                    mapDisplay.Image = moisture.gridToBitmap(ColorGrad.MoistureGradient);
                }
            }
        }

        //Events

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
            UpdateMapDisplay();
        }

        private void MainTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If we changed to Map, update the map display.
            if (MainTabs.SelectedTab == imageTab)
            {
                UpdateMapDisplay();
            }

            //If we changed to Node, repaint the control
            if (MainTabs.SelectedTab == NodeTab)
            {
                nodePanel.UpdateGraph();
            }
        }

        private void DisplayOptionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Enable/Disable Season Swithcer
            if (DisplayOptionBox.SelectedIndex == 0)
            {
                SeasonSwitcher.SelectedIndex = 0;
                SeasonSwitcher.Enabled = false;
            }
            else if (DisplayOptionBox.SelectedIndex == 1)
            {
                SeasonSwitcher.SelectedIndex = 0;
                SeasonSwitcher.Enabled = true;
            }
            else if (DisplayOptionBox.SelectedIndex == 2)
            {
                SeasonSwitcher.SelectedIndex = 0;
                SeasonSwitcher.Enabled = false;
            }
            else if (DisplayOptionBox.SelectedIndex == 3)
            {
                SeasonSwitcher.SelectedIndex = 0;
                SeasonSwitcher.Enabled = false;
            }

            //Update map display when we change modes
            UpdateMapDisplay();
        }

        private void SeasonSwitcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMapDisplay();
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Get the file name to save as.
            saveProjectDialog.ShowDialog();

            //Save the project
            FileStream saveStream = new FileStream(saveProjectDialog.FileName, FileMode.Create);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(saveStream, currentProject);

            saveStream.Close();
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Get the file name to open from
            openProjectDialog.ShowDialog();

            //Open the project
            FileStream openStream = new FileStream(openProjectDialog.FileName, FileMode.Open);
            SoapFormatter formatter = new SoapFormatter();
            currentProject = (Project)formatter.Deserialize(openStream);

            openStream.Close();
        }
    }
}
