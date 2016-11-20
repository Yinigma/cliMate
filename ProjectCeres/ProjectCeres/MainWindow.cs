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
            currentProject = new Project();
            nodePanel.Map = currentProject.getMap();
            nodePanel.CurrentNode = NodePanel.NONE;
            selectedNode = null;
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
