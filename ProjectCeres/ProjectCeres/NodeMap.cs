using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCeres
{
    [Serializable]
    public class NodeMap
    {
        [Serializable]
        public struct Edge
        {
            public guiNode n1;
            public guiNode n2;
            public Point p1;
            public Point p2;
            public int dex;
        }

        [Serializable]
        public struct guiNode
        {
            public Node node;
            public Rectangle[] rects;
            public int x;
            public int y;
            public String name;
        }

        private Node output;
        List<guiNode> nodes;
        List<Edge> connections;
        private int outHeight;
        private int outWidth;
        public int Width { get { return outWidth; } }
        public int Height { get { return outHeight; } }

        public List<guiNode> Nodes
        {
            get { return nodes; }
        }
        public List<Edge> Connections
        {
            get { return connections; }
        }

        public NodeMap(int width, int height)
        {
            outWidth = width;
            outHeight = height;
            nodes = new List<guiNode>();
            connections = new List<Edge>();
        }

        public bool isValid(Edge e)
        {
            Node next = e.n2.node.Parent;
            if (e.n1.node == e.n2.node)
            {
                return false;
            }
            while (next != null)
            {
                if (ReferenceEquals(e.n1.node, next) || ReferenceEquals(e.n2.node, next))
                {
                    return false;
                }
                next = next.Parent;
            }
            return true;
        }

        public void AddNode(guiNode n) { nodes.Add(n); }

        public void AddEdge(Edge e)
        {
            
            //If the destination socket is already occupied
            if (e.n2.node.getChild(e.dex)!= null|| e.n1.node.Parent!=null)
            {
                foreach (Edge hay in Connections)
                {
                    //For the kids that try and be redundant
                    if (isEqiuvalent(hay, e))
                    {
                        return;
                    }
                }
                bool foundConflict = false;
                if (e.n2.node.getChild(e.dex) != null) {
                    foreach (Edge hay in Connections)
                    {
                        if (inputConflict(hay, e))
                        {
                            removeEdge(hay);
                            foundConflict = true;
                            break;
                        }
                    }
                }
                if (e.n1.node.Parent != null)
                {
                    foreach (Edge hay in Connections)
                    {
                        if (outputConflict(hay, e))
                        {
                            removeEdge(hay);
                            foundConflict = true;
                            break;
                        }
                    }
                }
                if (!foundConflict)
                {
                    return;
                }
            }
            //*sigh* this method used to be cute
            e.n1.node.Parent = e.n2.node;
            e.n2.node.setInputNode(e.n1.node, e.dex);
            connections.Add(e);
            /*
             * Debug bullshit. Do not eat.
            foreach (Edge ed in Connections)
            {
                MessageBox.Show(EdgeToString(ed));
            }
            */
        }
        public void removeEdge(Edge e)
        {
            e.n1.node.Parent = null;
            e.n2.node.setInputNode(null, e.dex);
            int remDex = FindEdge(e);
            Connections.Remove(Connections.ElementAt(remDex));
            //It's becoming evident that I have no fucking clue what is good practice with these
        }
        //When ur data is garbage but there ain't much of it
        //X'D X'D X'D X'D OK
        //Fucking kill me
        public int FindEdge(Edge needle)
        {
            int length = Connections.Count();
            for(int i = 0; i<length; i++)
            {
                if (isEqiuvalent(needle,Connections.ElementAt(i)))
                {
                    return i;
                }
            }
            return -1;
        }
        public bool isEqiuvalent(Edge e1, Edge e2)
        {
            return (e1.dex==e2.dex&&
                e1.n1.node==e2.n1.node&&
                e1.n2.node==e2.n2.node);
        }
        //Returns true if both edges are trying to write to the same input
        public bool inputConflict(Edge e1, Edge e2)
        {
            return (e1.dex == e2.dex &&
                e1.n2.node==e2.n2.node);
        }
        //Returns true if both edges are trying to get info from the same output
        public bool outputConflict(Edge e1, Edge e2)
        {
            return e1.n1.node==e2.n1.node;
        }
        
        public String EdgeToString(Edge e)
        {
            String output = "Edge:\n dex = "+e.dex+"\n"+e.n1.node.toString()+"\n"+e.n2.node.toString()+"\n\n";
            return output;
        }
    }
}
