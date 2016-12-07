using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    [Serializable]
    class OutputNode : Node
    {
        const int SRS = 16;

        public OutputNode(NodeMap map) : base(map)
        {
            this.parent = null;
            this.mask = null;
        }

        //This is the final output node and the root of the tree. It shouldn't have a parent nor should hand it's output off to another node.
        override public void setOutputNode(Node n) { return; }
        override public void maskEnabled(bool e) { return; }
        override public void doOperation() { return; }

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
            return;
        }
    }
}
