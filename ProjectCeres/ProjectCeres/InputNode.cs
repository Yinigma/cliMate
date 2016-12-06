using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    public abstract class InputNode : Node
    {
        //Parent class for generation things
        //subclass of normal nodes
        //start of the chain type deal
        public InputNode(NodeMap map) : base(map) { }

        //you are not allowed to set kiddos. bad. no kiddos
        public override void setInputNode(Node kiddo, int Dex)
        {
            return;
        }
        public override int getNeeded()
        {
            return 0;
        }
        public override String toString()
        {
            return "I am an Input node! I have no children.";
        }
        public override string toString(int steps)
        {
            return this.toString();
        }
    }
}
