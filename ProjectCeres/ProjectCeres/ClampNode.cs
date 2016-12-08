using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCeres
{
    public class ClampNode : Node
    {
        private int max;
        private int min;
        private bool cutoff;

        public ClampNode(NodeMap map) : base(map)
        {
            max = -1;
            min = -1;    
        }

        public override void doOperation()
        {
            if (!isValid())
            {
                return;
            }
            MessageBox.Show("Bread");
            updateInputs();
            outGrid = children[0].getOutputGrid();
            return;
            float current;
            if (cutoff == true)
            {
                for (int row = 0; row < map.Height; row++)
                {
                    for (int col = 0; col < map.Width; col++)
                    {
                        current = children[0].getOutputGrid().getTile(row, col).Value;
                        current = Math.Min(current, max);
                        current = Math.Max(current, min);
                        outGrid.setTile(row,col,current);
                    }
                }
            }
            else
            {
                for (int row = 0; row < map.Height; row++)
                {
                    for (int col = 0; col < map.Width; col++)
                    {
                        current = children[0].getOutputGrid().getTile(row, col).Value;
                        current = current * (1-(max+min)) + min;
                        outGrid.setTile(row, col, current);
                    }
                }
            }
        }

        public override int getNeeded()
        {
            return 1;
        }

        public override int getOptional()
        {
            return 0;
        }

        public override void openForm()
        {
            ClampForm clampy = new ClampForm(this);
            clampy.ShowDialog();
            doOperation();
        }

        public int Maximum { set { max = value; } }
        public int Minimum { set { min = value; } }
        public bool Cutoff { set { cutoff = value; } }
    }
}
