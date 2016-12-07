using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    public class CombinerNode : Node
    {
        public const int AVERAGE = 0;
        public const int ADD = 1;
        public const int SUBTRACT = 2;
        public const int MULTIPLY = 3;
        public const int DIVIDE = 4;
        public const int MIN = 5;
        public const int MAX = 6;

        private int currentMode;

        public CombinerNode(NodeMap map) : base(map)
        {
            currentMode = 0;
        }

        public override void doOperation()
        {
            for(int r = 0; r<outGrid.Height; r++)
            {
                for(int c = 0; c<outGrid.Width; c++)
                {
                    float v0 = children[0].getOutputGrid().getTile(r, c).Value;
                    float v1 = children[1].getOutputGrid().getTile(r, c).Value;
                    outGrid.getTile(r,c).Value = subOp(0,v0,v1);
                }
            }
        }

        private float subOp(int opCode, float v0, float v1)
        {
            switch (opCode) {
                case AVERAGE:
                    return (v0 + v1) / 2;
                case ADD:
                    return Math.Min((v0 + v1), 1f);
                case SUBTRACT:
                    return Math.Max((v0 - v1), 0f);
                case MULTIPLY:
                    return Math.Min((v0 * v1), 1f);
                case DIVIDE:
                    if (v1 == 0)
                    {
                        return 1f;
                    }
                    else
                    {
                        return Math.Min((v0 / v1), 1f);
                    }
                case MIN:
                    return Math.Min(v0,v1);
                case MAX:
                    return Math.Max(v0,v1);
                default:
                    return 0f;
            }
        }

        public override int getNeeded()
        {
            return 2;
        }

        public override int getOptional()
        {
            return 0;
        }

        public override void openForm()
        {
            return;
        }

        public int Mode { get { return currentMode; } set { currentMode = value; } }
    }
}
