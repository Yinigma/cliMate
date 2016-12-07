using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    [Serializable]
    class DebugNode : InputNode
    {
        public DebugNode(NodeMap map) : base(map) {}

        public override void doOperation()
        {
            return;
        }

        protected override void setDefault()
        {
            Random r = new Random();
            for (int row = 0; row < map.Height; row++)
            {
                for (int col = 0; col < map.Width; col++)
                {
                    outGrid.setTile(row,col, (float)row/map.Width);
                }
            }
        }

        public override string toString()
        {
            return "I'm the debug node that has no children!";
        }
        public override string toString(int steps)
        {
            return this.toString();
        }

        public override int getOptional()
        {
            return 0;
        }

        public override void openForm()
        {
            return;
        }
    }
}
