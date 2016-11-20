using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    class DebugNode2 : Node
    {
        public DebugNode2(NodeMap map) : base(map)
        {

        }

        protected override void setDefault()
        {
            Random r = new Random();
            for (int row = 0; row < map.Height; row++)
            {
                for (int col = 0; col < map.Width; col++)
                {
                    outGrid.setTile(row, col, (float)r.NextDouble());
                }
            }
        }

        public override void doOperation()
        {
            if (this.isValid())
            {
                float grid1 = 0;
                float grid2 = 0;
                float currentVal = 0;
                for (int row = 0; row < map.Height; row++)
                {
                    for (int col = 0; col < map.Width/2; col++)
                    {
                        grid1 = children[0].getOutputGrid().getTile(row,col).Value;
                        grid2 = children[1].getOutputGrid().getTile(row, col).Value;
                        currentVal = (grid1+grid2)/2;
                        outGrid.setTile(row, col, currentVal);
                    }
                }
            }
        }

        public override int getNeeded()
        {
            return 2;
        }

        public override int getOptional()
        {
            return 3;
        }

        public override void openForm()
        {
            return;
        }
    }
}
