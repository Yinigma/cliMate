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
    public partial class WidthHeightDialog : Form
    {
        public int width;
        public int height;

        public WidthHeightDialog()
        {
            InitializeComponent();
        }

        private void widthBox_TextChanged(object sender, EventArgs e)
        {
            EnableOKButton();
        }

        private void heightBox_TextChanged(object sender, EventArgs e)
        {
            EnableOKButton();
        }

        private void EnableOKButton()
        {
            //Enables/disables the OK button, depending on if the textboxes are valid.

            bool widthSuccess = int.TryParse(widthBox.Text, out width);
            bool heightSuccess = int.TryParse(heightBox.Text, out height);

            okButton.Enabled = widthSuccess && heightSuccess;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
