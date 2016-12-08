using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing.Imaging;

namespace ProjectCeres
{
    public partial class MainWindow : Form
    {
        int[] replacements = {0,1,2,3,4,5,6,7,8,9,10};
        int counterDB;
        Project currentProject;
        NodeMap map;
        Node selectedNode;

        public MainWindow()
        {
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();
            System.Threading.Thread.Sleep(3000);
            splashScreen.Close();
            InitializeComponent();
            testPanel.Click += TestPanel_Click;
            SetProject(new Project());
            mapDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            DisplayOptionBox.SelectedIndex = 0;
            counterDB = 0;
            tundraBox.SelectedIndex = 0;
            grassBox.SelectedIndex = 1;
            woodBox.SelectedIndex = 2;
            borBox.SelectedIndex = 3;
            seasonBox.SelectedIndex = 4;
            temperBox.SelectedIndex = 5;
            tropBox.SelectedIndex = 6;
            savBox.SelectedIndex = 7;
            desertBox.SelectedIndex = 8;
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

        private void SetProject(Project project)
        {
            //Sets the current project to the given one
            currentProject = project;
            nodePanel.Map = currentProject.getMap();
            nodePanel.CurrentNode = NodePanel.NONE;
            selectedNode = null;
            nodePanel.Selected = null;
            mapDisplay.Image = null;

            //Also update map display and node panel
            nodePanel.UpdateGraph();
            UpdateMapDisplay();
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
                    replacements[0] = tundraBox.SelectedIndex;
                    replacements[1] = grassBox.SelectedIndex;
                    replacements[2] = woodBox.SelectedIndex;
                    replacements[3] = borBox.SelectedIndex;
                    replacements[4] = seasonBox.SelectedIndex;
                    replacements[5] = temperBox.SelectedIndex;
                    replacements[6] = tropBox.SelectedIndex;
                    replacements[7] = savBox.SelectedIndex;
                    replacements[8] = desertBox.SelectedIndex;
                    if (SeasonSwitcher.SelectedIndex == 1)
                    {
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, .4f, replacements);
                        mapDisplay.Image = Biomes.renderBiomes(biome);
                    }
                    else if (SeasonSwitcher.SelectedIndex == 2)
                    {
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, .6f, replacements);
                        mapDisplay.Image = Biomes.renderBiomes(biome);
                    }
                    else
                    {
                        RectGrid biome = Biomes.BiomeMap(selectedNode.getOutputGrid(), currentProject, 3 * currentProject.Frequency, .5f ,replacements);
                        mapDisplay.Image = Biomes.renderBiomes(biome);
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
        private void combinerButton_Click(object sender, EventArgs e)
        {
            nodePanel.CurrentNode = NodePanel.COMBINER;
        }
        private void clampButton_Click(object sender, EventArgs e)
        {
            nodePanel.CurrentNode = NodePanel.CLAMP;
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

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            /*try
            {
                selectedNode = null;
                currentProject.ClearMap();
            } catch (System.NullReferenceException)
            {
                MessageBox.Show("lol");
            }
            mapDisplay.Image = null;
            UpdateMapDisplay();
            testPanel.Update();
            nodePanel.UpdateGraph();*/
            this.SetProject(new Project());
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Get the file name to save as.
            saveProjectDialog.ShowDialog();

            //Save the project
            /*FileStream saveStream = new FileStream(saveProjectDialog.FileName, FileMode.Create);
            XmlSerializer serialize = new XmlSerializer(typeof(Project));
            serialize.Serialize(saveStream, currentProject);
            saveStream.Close();*/
            try
            {
                FileStream saveStream = new FileStream(saveProjectDialog.FileName, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(saveStream, currentProject);
                saveStream.Close();
            }
            catch (ArgumentException)
            {

            }
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Get the file name to open from
            openProjectDialog.ShowDialog();

            //Open the project
            FileStream openStream;
            try
            {
                openStream = new FileStream(openProjectDialog.FileName, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Project openedProject = (Project)formatter.Deserialize(openStream);
                SetProject(openedProject);
                openStream.Close();
                MessageBox.Show("" + currentProject.Frequency);
            }
            catch (FileNotFoundException)
            {

            }
        }

        private void saveCurrentImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //insert saving.
            //Taken from stackoverflow http://stackoverflow.com/questions/11055258/how-to-use-savefiledialog-for-saving-images-in-c
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                mapDisplay.Image.Save(sfd.FileName, format);
            }
        }
    }
}
