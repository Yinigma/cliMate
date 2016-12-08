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
        int[,] replacements = new int[9, 2] { {1,1}, {2,2}, {3,3}, {4,4}, {5,5}, {6,6}, {7,7}, {8,8}, {9,9} };
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
                    else if (SeasonSwitcher.SelectedIndex == 2)
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
                else if (DisplayOptionBox.SelectedIndex == 3)
                {
                    if (tundraBox.SelectedIndex != 0)
                    {
                        replacements[0, 1] = tundraBox.SelectedIndex + 1;
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, replacements);
                        // mapDisplay.Image = biome.gridToBitmap(); 
                    }
                    else if (grassBox.SelectedIndex != 1)
                    {
                        replacements[1, 1] = grassBox.SelectedIndex + 1;
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, replacements);
                        // mapDisplay.Image = biome.gridToBitmap(); 
                    }
                    else if (woodBox.SelectedIndex != 2)
                    {
                        replacements[2, 1] = woodBox.SelectedIndex + 1;
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, replacements);
                        // mapDisplay.Image = biome.gridToBitmap(); 
                    }
                    else if (borBox.SelectedIndex != 3)
                    {
                        replacements[3, 1] = borBox.SelectedIndex + 1;
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, replacements);
                        // mapDisplay.Image = biome.gridToBitmap(); 
                    }
                    else if (seasonBox.SelectedIndex != 4)
                    {
                        replacements[4, 1] = seasonBox.SelectedIndex + 1;
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, replacements);
                        // mapDisplay.Image = biome.gridToBitmap(); 
                    }
                    else if (temperBox.SelectedIndex != 5)
                    {
                        replacements[5, 1] = temperBox.SelectedIndex + 1;
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, replacements);
                        // mapDisplay.Image = biome.gridToBitmap(); 
                    }
                    else if (tropBox.SelectedIndex != 6)
                    {
                        replacements[6, 1] = tropBox.SelectedIndex + 1;
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, replacements);
                        // mapDisplay.Image = biome.gridToBitmap(); 
                    }
                    else if (savBox.SelectedIndex != 7)
                    {
                        replacements[7, 1] = savBox.SelectedIndex + 1;
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, replacements);
                        // mapDisplay.Image = biome.gridToBitmap(); 
                    }
                    else if (desertBox.SelectedIndex != 8)
                    {
                        replacements[8, 1] = desertBox.SelectedIndex + 1;
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, replacements);
                        // mapDisplay.Image = biome.gridToBitmap(); 
                    }
                    else
                    {
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, replacements);
                        //mapDisplay.Image = biome.gridToBitmap(); 
                    }
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
                tundraBox.Enabled = false;
                grassBox.Enabled = false;
                woodBox.Enabled = false;
                borBox.Enabled = false;
                seasonBox.Enabled = false;
                temperBox.Enabled = false;
                tropBox.Enabled = false;
                savBox.Enabled = false;
                desertBox.Enabled = false;
            }
            else if (DisplayOptionBox.SelectedIndex == 1)
            {
                SeasonSwitcher.SelectedIndex = 0;
                SeasonSwitcher.Enabled = true;
                tundraBox.Enabled = false;
                grassBox.Enabled = false;
                woodBox.Enabled = false;
                borBox.Enabled = false;
                seasonBox.Enabled = false;
                temperBox.Enabled = false;
                tropBox.Enabled = false;
                savBox.Enabled = false;
                desertBox.Enabled = false;
            }
            else if (DisplayOptionBox.SelectedIndex == 2)
            {
                SeasonSwitcher.SelectedIndex = 0;
                SeasonSwitcher.Enabled = false;
                tundraBox.Enabled = false;
                grassBox.Enabled = false;
                woodBox.Enabled = false;
                borBox.Enabled = false;
                seasonBox.Enabled = false;
                temperBox.Enabled = false;
                tropBox.Enabled = false;
                savBox.Enabled = false;
                desertBox.Enabled = false;
            }
            else if (DisplayOptionBox.SelectedIndex == 3)
            {
                SeasonSwitcher.SelectedIndex = 0;
                SeasonSwitcher.Enabled = false;
                tundraBox.Enabled = true;
                grassBox.Enabled = true;
                woodBox.Enabled = true;
                borBox.Enabled = true;
                seasonBox.Enabled = true;
                temperBox.Enabled = true;
                tropBox.Enabled = true;
                savBox.Enabled = true;
                desertBox.Enabled = true;
            }

            //Update map display when we change modes
            UpdateMapDisplay();
        }

        private void SeasonSwitcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMapDisplay();
        }
    }
}
