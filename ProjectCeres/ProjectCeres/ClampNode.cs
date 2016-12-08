using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (cutoff == true)
            {
                for (int row = 0; row < map.Height; row++)
                {
                    for (int col = 0; col < map.Width; col++)
                    {
                        
                        if (outGrid.getTile(row, col).Value > max)
                        {
                            outGrid.setTile(row, col, (float)max);
                        }
                        else if (outGrid.getTile(row, col).Value < min)
                        {
                            outGrid.setTile(row, col, (float)min);
                        }

                    }
                }
            }
            else
            {

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
