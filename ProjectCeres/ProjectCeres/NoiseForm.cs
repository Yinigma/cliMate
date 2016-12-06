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
        //Arbitrary cap on octaves
        private const int OCTUPPER = 20;
        private const int OCTLOWER = 1;
        //Based on recommended values in documentation
        private const double LACUPPER = 4.0D;
        private const double LACLOWER = 1.0D;
        //Based on recommended values in documentation
        private const double PERSUPPER = 1.0D;
        private const double PERSLOWER = 0.0D;
        private int seed;
        private int octaves;
        private double lacurinity;
        private double frequency;
        private double persistence;
        NoiseNode node;

        public NoiseForm(NoiseNode node)
        {
            seed = node.NodePerlin.Seed;
            octaves = node.NodePerlin.OctaveCount;
            lacurinity = node.NodePerlin.Lacunarity;
            frequency = node.NodePerlin.Frequency;
            persistence = node.NodePerlin.Persistence;
            
            this.node = node;
            InitializeComponent();
            LacBox.Text = "" + lacurinity;
            FreqBox.Text = "" + frequency;
            PersBox.Text = "" + persistence;
            OctBox.Text = "" + octaves;
            seedBox.Text = "" + seed;
            seedBox.LostFocus += SeedBox_CommitText;
            PersBox.LostFocus += PersBox_LostFocus;
            OctBox.LostFocus += OctBox_LostFocus;
            FreqBox.LostFocus += FreqBox_LostFocus;
            LacBox.LostFocus += LacBox_LostFocus;
        }

        private void LacBox_LostFocus(object sender, EventArgs e)
        {
            try { lacurinity = double.Parse(LacBox.Text); }
            catch (Exception fe) { /*do nothing*/ }
            lacurinity = Math.Max(LACLOWER, lacurinity);
            lacurinity = Math.Min(LACUPPER, lacurinity);
            LacBox.Text = "" + lacurinity;
        }

        private void FreqBox_LostFocus(object sender, EventArgs e)
        {
            try { frequency = double.Parse(FreqBox.Text); }
            catch (Exception fe) {/*do nothing*/}
            //I'm pretty sure the only constraint on frequency is that it can't be 0 or smaller
            if (frequency <= 0.001D)
            {
                frequency = 0.001D;
            }
            else if (frequency >= 1)
            {
                frequency = .99;
            }
            FreqBox.Text = "" + frequency;
        }

        private void OctBox_LostFocus(object sender, EventArgs e)
        {
            try { octaves = int.Parse(OctBox.Text); }
            catch(Exception fe) {/*do nothing*/}
            //capping octaves
            octaves = Math.Max(OCTLOWER, octaves);
            octaves = Math.Min(OCTUPPER, octaves);
            OctBox.Text = "" + octaves;
        }

        private void PersBox_LostFocus(object sender, EventArgs e)
        {
            try { persistence = double.Parse(PersBox.Text); }
            catch (Exception fe) {/*do nothing*/}
            //Capping persistence
            persistence = Math.Max(PERSLOWER, persistence);
            persistence = Math.Min(PERSUPPER, persistence);
            PersBox.Text = "" + persistence;
        }

        private void SeedBox_CommitText(object sender, EventArgs e)
        {
            try {seed = int.Parse(seedBox.Text);}
            catch (Exception fe) {/*do nothing*/}
            seedBox.Text = "" + seed;
        }
        public double Lacurinity { get { return lacurinity; } }
        public int Seed { get { return seed; } }
        public double Persistence { get { return persistence; } }
        public int Octaves { get { return octaves; } }
        public double Frequency { get { return frequency; } }

        private void OKButton_Click(object sender, EventArgs e)
        {
            node.NodePerlin.Seed = seed;
            node.NodePerlin.OctaveCount = octaves;
            node.NodePerlin.Frequency = frequency;
            node.NodePerlin.Persistence = persistence;
            node.NodePerlin.Lacunarity = lacurinity;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
