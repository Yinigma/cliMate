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
        private bool valid;
        CombinerNode combiner;

        public CombinerForm(CombinerNode node)
        {
            InitializeComponent();
            combineBox.SelectedIndex = CombinerNode.AVERAGE;
            combiner = node;
            valid = false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            valid = true;
            combiner.Mode = combineBox.SelectedIndex;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool Valid {get{ return valid; } }
    }
}
