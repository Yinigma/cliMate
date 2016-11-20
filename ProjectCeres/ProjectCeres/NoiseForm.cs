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
    public partial class NoiseForm : Form
    {
        int seed;
        int octaves;
        int lucarinity;
        int frequency;
        int persistence;
        NoiseNode node;

        public NoiseForm(NoiseNode node)
        {
            this.node = node;
            InitializeComponent();
            seedBox.LostFocus += SeedBox_CommitText;
            PersBox.LostFocus += PersBox_LostFocus;
            OctBox.LostFocus += OctBox_LostFocus;
        }

        private void OctBox_LostFocus(object sender, EventArgs e)
        {
            try { persistence = int.Parse(OctBox.Text); }
            catch(Exception fe) { octaves = 0; }
            OctBox.Text = "" + octaves;
        }

        private void PersBox_LostFocus(object sender, EventArgs e)
        {
            try { persistence = int.Parse(PersBox.Text); }
            catch (Exception fe) { persistence = 0; }
            PersBox.Text = "" + persistence;
        }

        private void SeedBox_CommitText(object sender, EventArgs e)
        {
            try {seed = int.Parse(seedBox.Text);}
            catch (Exception fe) { seed = 0;}
            seedBox.Text = "" + seed;
        }
    }
}
