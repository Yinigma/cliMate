using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    public class DrawNode : InputNode
    {
        public DrawNode(NodeMap map) : base(map)
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
            Canvas canvas = new Canvas(this);
            canvas.ShowDialog();
        }
    }
}
