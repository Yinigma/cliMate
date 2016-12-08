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
    public partial class ClampForm : Form
    {
        ClampNode clampNode;
        int maximum = 1;
        int minimum = 0;

        public ClampForm(ClampNode clampNode)
        {
            this.clampNode = clampNode;
            InitializeComponent();
            maxBox.Text = "" + maximum;
            minBox.Text = "" + minimum;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            //call clampnode or something?
            try { maximum = int.Parse(maxBox.Text); }
            catch (Exception fe) { maximum = 1; }
            try { minimum = int.Parse(minBox.Text); }
            catch (Exception fe) { minimum = 0; }
            clampNode.Minimum = minimum;
            clampNode.Maximum = maximum;
            clampNode.Cutoff = CutoffButton.Checked;
            Close();
        }
    }
}
