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
        float maximum;
        float minimum;

        public ClampForm(ClampNode clampNode)
        {
            this.clampNode = clampNode;
            InitializeComponent();
            maxBox.LostFocus += MaxBox_LostFocus;
            minBox.LostFocus += MinBox_LostFocus;
            minimum = clampNode.Minimum;
            maximum = clampNode.Maximum;
            CutoffButton.Checked = clampNode.Cutoff;
            maxBox.Text = "" + maximum;
            minBox.Text = "" + minimum;
        }

        private void MinBox_LostFocus(object sender, EventArgs e)
        {
            try { minimum = float.Parse(minBox.Text); }
            catch (Exception fe) {/*do nothing*/}
            minimum = Math.Max(minimum, 0);
            minimum = Math.Min((maximum-0.01f), minimum);
            minBox.Text = "" + minimum;
        }

        private void MaxBox_LostFocus(object sender, EventArgs e)
        {
            try { maximum = float.Parse(maxBox.Text); }
            catch (Exception fe) {/*do nothing*/}
            maximum = Math.Min(maximum, 1);
            maximum = Math.Max((minimum + 0.01f), maximum);
            maxBox.Text = "" + maximum;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            //call clampnode or something?
            //Fuck you, Rami
            clampNode.Minimum = minimum;
            clampNode.Maximum = maximum;
            clampNode.Cutoff = CutoffButton.Checked;
            Close();
        }
    }
}
