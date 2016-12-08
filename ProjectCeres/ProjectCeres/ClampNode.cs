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
        private float max;
        private float min;
        private bool cutoff;

        public ClampNode(NodeMap map) : base(map)
        {
            max = 1;
            min = 0;
            cutoff = true;
            doOperation();
        }

        public override void doOperation()
        {
            if (!isValid())
            {
                return;
            }
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
            updateInputs();
        }

        public float Maximum { set { max = value; } get { return max; } }
        public float Minimum { set { min = value; } get { return min; } }
        public bool Cutoff { set { cutoff = value; } get { return cutoff; } }
    }
}
