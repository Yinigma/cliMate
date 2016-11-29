using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCeres
{
    public abstract class Node
    {
        //I know it's bass ackwards, but the way we've been taught tree traversal led me to think it'd be best to consider output the root
        protected RectGrid outGrid;
        protected Node mask;
        protected Node parent;
        protected Node[] children;
        protected bool enableMask;
        protected NodeMap map { get; }


        

        public Node(NodeMap map)
        {
            int needed = getNeeded();
            int opt = getOptional();
            enableMask = false;
            //This is here to make sure that setInput can always be called
            children = new Node[needed+opt];
            this.map = map;
            outGrid = new RectGrid(map.Height, map.Width);
            setDefault();
        }

        public abstract void openForm();



        public virtual Node getChild(int kiddo)
        {
            if (kiddo < children.Length && kiddo >= 0) {
                return children[kiddo];
            }
            else
            {
                return null;
            }
        }

        protected virtual void setDefault()
        {
            for (int row = 0; row < map.Height; row++)
            {
                for(int col = 0; col<map.Width; col++)
                {
                    outGrid.setTile(row,col,0.0f);
                }
            }
        }

        //Checks to see if this node has all it's inputs and it's children have all their inputs, etc. 
        public bool isValid()
        {
            for(int i = 0; i<this.getNeeded(); i++)
            {
                if (children[i] != null||!children[i].isValid())
                {
                    return false;
                }
            }
            return true;
        }

        public virtual String toString()
        {
            return this.toString(0);
        }

        public virtual String toString(int steps)
        {
            String id = "I am a " + this.GetType() + " and my children are...\n";
            if (parent != null)
            {
                id += "My parent is a " + parent.GetType()+" \n";
            }
            for (int i = 0; i < children.Length; i++)
            {
                for (int j = 0; j< steps; j++)
                {
                    id += "\t";
                }
                if (children[i] != null)
                {
                    id += children[i].toString(steps+1);
                }
                else
                {
                    id += "\tslot " + i + " unoccupied\n";
                }
            }
            return id;
        }

        //returns the needed input of a given type of node
        public abstract int getNeeded();
        //returns the optional input of a given type of node
        public abstract int getOptional();

        public virtual void maskEnabled(bool enable) { enableMask = enable; }

        public abstract void doOperation();

        public virtual void setOutputNode(Node pops) { parent = pops; }

        public virtual void setInputNode(Node kiddo, int dex) {
            
            if (dex < children.Length && dex >= 0)
            {
                children[dex] = kiddo;
            }
            else if (dex == children.Length)
            {
                mask = kiddo;
            }
        }

        public virtual Bitmap ToBitmap()
        {
            Bitmap bmp = new Bitmap(map.Width, map.Height);
            for (int col = 0; col < map.Width; col++)
            {
                for (int row = 0; row < map.Height; row++)
                {
                    bmp.SetPixel(col,row,outGrid.getTile(row,col).getColor());
                }
            }
            return bmp;
        }

        public int numInputs() { return children.Length; }

        public Node Mask { get { return mask; } set { mask = value; } }

        public Node Parent { get { return this.parent; } set { this.parent = value; } }

        public RectGrid getOutputGrid() { return outGrid; }
    }
}
