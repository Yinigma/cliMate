using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpNoise.Modules;

namespace ProjectCeres
{
    public class NoiseNode : InputNode
    {
        private Perlin nodePerlin;

        public NoiseNode(NodeMap map) : base(map)
        {
            //The perlin class sets its own defaults upon instantiation
            nodePerlin = new Perlin();
            doOperation();
        }

        public override void doOperation()
        {

            for (int row = 0; row < map.Height; row++)
            {
                for (int col = 0; col < map.Width; col++)
                {
                    //Add the corresponding noise value to this pixel
                    double noiseVal = nodePerlin.GetValue((double)row, (double)col, 0D);
                    //GetValue returns a value between -1 and 1 with some error
                    noiseVal = (noiseVal + 1.0D) / 2.0D;
                    if (noiseVal>1.0D)
                    {
                        noiseVal = 1.0D;
                    }
                    else if (noiseVal<0.0D)
                    {
                        noiseVal = 0.0D;
                    }
                    outGrid.setTile(row, col, (float)noiseVal);
                }
            }
        }

        public override int getOptional()
        {
            return 0;
        }

        public override void openForm()
        {
            NoiseForm noiseWin = new NoiseForm(this);
            noiseWin.ShowDialog();
            doOperation();
        }

        public Perlin NodePerlin { get { return nodePerlin; } }
    }
}
