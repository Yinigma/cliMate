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
    public partial class CombinerForm : Form
    {
        public CombinerForm(CombinerNode node)
        {
            InitializeComponent();
            combineBox.SelectedIndex = CombinerNode.AVERAGE;
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }
    }
}
