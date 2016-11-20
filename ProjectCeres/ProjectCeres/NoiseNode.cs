using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCeres
{
    public class NoiseNode : InputNode
    {
        public NoiseNode(NodeMap map) : base(map)
        {
        }

        public override void doOperation()
        {
            throw new NotImplementedException();
        }

        public override int getOptional()
        {
            return 0;
        }

        public override void openForm()
        {
            NoiseForm noiseWin = new NoiseForm(this);
            noiseWin.ShowDialog();
        }
    }
}
