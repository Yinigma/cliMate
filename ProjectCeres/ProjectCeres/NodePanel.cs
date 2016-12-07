using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCeres
{
    public partial class NodePanel : Panel
    {

        //Sub Rectangle Size
        const int SRS = 16;
        public const int NONE = 0;
        public const int OUTPUT = 1;
        public const int FILE = 2;
        public const int DEBUG = 3;
        public const int DEBUG2 = 4;
        public const int NOISE = 5;
        public const int DRAW = 6;

        private int currentNode;
        public int CurrentNode { get { return currentNode; } set { currentNode = value; } }

        private NodeMap.Edge nextEdge;
        private NodeMap.guiNode selectedNode;
        public Node Selected { get { return selectedNode.node; } }
        private bool destSet;
        private bool sourceSet;
        private NodeMap map;
        public NodeMap Map { set { this.map = value; } get { return map; } }
        private Pen pen;

        public NodePanel()
        {
            InitializeComponent();
            currentNode = 0;
            pen = new Pen(Color.Black);
            selectedNode.node = null;
            selectedNode.rects = null;
            selectedNode.x = -1;
            selectedNode.y = -1;
            destSet = false;
            sourceSet = false;
            this.Click += new System.EventHandler(this.NP_Click);
        }

        private void NP_Click(object sender, EventArgs e)
        {
            
            Point point = this.PointToClient(Cursor.Position);
            //Check if user clicked a node
            NodeMap.guiNode colNode = this.checkCollision(point);
            //If so colNode would be the node they clicked
            //Check collision prioritizes the sub rectangles. 
            //I have no idea why we'd want to take a click on a sub rect 
            //as a click on the main one, but then again I'm fucking dumb.
            if (colNode.node != null)
            {
                int rDex = this.checkRectDex(point, colNode);
                if (rDex == 0)
                {
                    if (selectedNode.node == colNode.node)
                    {
                        colNode.node.openForm();
                    }
                    else
                    {
                        selectedNode = colNode;
                        
                    }
                }
                else
                {
                    //If it's an input to a node
                    if (rDex < colNode.rects.Length - 1)
                    {
                        //If the edge's destination hasn't been set
                        if (destSet == false)
                        {
                            nextEdge.n2 = colNode;
                            destSet = true;
                            //This number stores the index of the child node that will be destination
                            nextEdge.dex = rDex-1;
                        }
                        else
                        {
                            MessageBox.Show("Can't put an input into an input.\n...silly goose.");
                        }
                    }
                    //It's an output to a node
                    else
                    {
                        //If the edge's source hasn't been set
                        if (sourceSet == false)
                        {
                            nextEdge.n1 = colNode;
                            sourceSet = true;
                        }
                        else
                        {
                            MessageBox.Show("Can't put an output into an output.\n...silly goose.");
                        }
                    }
                    //If, by the end of it all, we have a valid edge
                    if (sourceSet == true && destSet == true)
                    {
                        if (map.isValid(nextEdge))
                        {
                            nextEdge.p1 = midPoint(nextEdge.n1.rects[nextEdge.n1.rects.Length-1]);
                            nextEdge.p2 = midPoint(nextEdge.n2.rects[nextEdge.dex+1]);
                            this.map.AddEdge(nextEdge);
                        }
                        else
                        {
                            MessageBox.Show("You can't create an infinite loop. Do you normally try and break anything you get your hands on?");
                        }
                        sourceSet = false;
                        destSet = false;
                    }
                }
            }
            else
            {
                if (currentNode != NONE)
                {
                    addCurrentNode(point.X, point.Y);
                }
            }
            UpdateGraph();
        }

        public void UpdateGraph()
        {
            Graphics nodeGraphics = this.CreateGraphics();
            nodeGraphics.Clear(Color.White);
            foreach(NodeMap.guiNode gn in map.Nodes)
            {
                nodeGraphics.DrawRectangles(pen, gn.rects);
                PointF p = new PointF(gn.rects[0].Left, gn.rects[0].Top - 20);
                Font f = new Font(new FontFamily("Arial"), 12, FontStyle.Regular, GraphicsUnit.Point);
                SolidBrush b = new SolidBrush(Color.Black);
                nodeGraphics.DrawString(gn.name, f, b, p);
            }
            foreach(NodeMap.Edge e in map.Connections)
            {
                nodeGraphics.DrawLine(pen, e.p1, e.p2);
            }
        }

        private void addCurrentNode(int x, int y)
        {
            bool set = false;
            NodeMap.guiNode toAdd;
            toAdd.node = null;
            toAdd.x = x;
            toAdd.y = y;
            toAdd.rects = null;
            toAdd.name = null;
            if (currentNode == OUTPUT)
            {
                toAdd.node = new OutputNode(map);
                toAdd.name = "output";
                set = true;

            }
            else if (currentNode == FILE)
            {
                toAdd.node = new FileNode(map, "");
                toAdd.name = "file";
                set = true;
            }
            else if (currentNode == DEBUG)
            {
                toAdd.node = new DebugNode(map);
                toAdd.name = "debug";
                set = true;
            }
            else if (currentNode == DEBUG2)
            {
                toAdd.node = new DebugNode2(map);
                toAdd.name = "debug2";
                set = true;
            }
            else if (currentNode == NOISE)
            {
                toAdd.node = new NoiseNode(map);
                toAdd.name = "noise";
                set = true;
            }
            else if (currentNode == DRAW)
            {
                toAdd.node = new DrawNode(map);
                toAdd.name = "draw";
                set = true;
            }
            if (set) {
                int needed = toAdd.node.getNeeded();
                int opt = toAdd.node.getOptional();
                bool isOutput = toAdd.node.GetType() == typeof(OutputNode);
                int additional = isOutput ? 2 : 3;
                toAdd.rects = new Rectangle[needed + opt + additional];
                this.initRects(x, y, toAdd);
            }
            foreach(NodeMap.guiNode gn in map.Nodes)
            {
                if (isColliding(toAdd.rects[0], gn.rects[0]))
                {
                    MessageBox.Show("Can't put a node on top of a node.\n They like personal space.");
                    set = false;
                    break;
                }
            }
            if (set)
            {
                map.Nodes.Add(toAdd);
            }
            currentNode = NONE;
        }

        private NodeMap.guiNode checkCollision(Point p)
        {
            NodeMap.guiNode colNode;
            colNode.node = null;
            colNode.x = 0;
            colNode.y = 0;
            colNode.rects = null;
            colNode.name = null;
            if (this.map.Nodes != null)
            {
                foreach (NodeMap.guiNode gn in map.Nodes)
                {
                    if (isColliding(gn.rects[0], p))
                    {
                        colNode = gn;
                        break;
                    }
                }
            }
            return colNode;
        }

        //Checks all subrectangles in a guiNode to see if any of them were also clicked
        private int checkRectDex(Point p, NodeMap.guiNode gn)
        {
            for (int i = 1; i < gn.rects.Length; i++)
            {
                if (isColliding(gn.rects[i], p))
                {
                    return i;
                }
            }
            return 0;
        }

        private bool isColliding(Rectangle r, Point p)
        {
            bool b = false;
            if ((p.X >= r.X && p.X <= (r.X + r.Width)) && (p.Y >= r.Y && p.Y <= (r.Y + r.Height)))
            {
                b = true;
            }
            return b;
        }

        private bool isColliding(Rectangle r1, Rectangle r2)
        {
            bool b = false;
            if ((r1.X <= r2.X + r2.Width) && (r1.X + r1.Width >= r2.X) && (r1.Y <= r2.Y + r2.Height) && (r1.Y + r1.Height >= r2.Y))
            {
                b = true;
            }
            return b;
        }

        private void initRects(int x, int y, NodeMap.guiNode gn)
        {
            int needed = gn.node.getNeeded();
            int opt = gn.node.getOptional();
            bool isOutput = gn.node.GetType() == typeof(OutputNode);
            int mainHeight = Math.Max((needed + opt) * SRS, 32);
            int mainWidth = 4 * SRS;
            gn.rects[0] = new Rectangle(x, y, mainWidth, mainHeight);
            for (int i = 0; i < needed + opt; i++)
            {
                int inY = i * SRS;
                gn.rects[i + 1] = new Rectangle(x, y + inY, SRS, SRS);
            }
            gn.rects[needed + opt + 1] = new Rectangle(x + mainWidth - SRS, y + mainHeight - SRS, SRS, SRS);
            if (!isOutput)
            {
                gn.rects[needed + opt + 2] = new Rectangle(x + mainWidth - SRS, y, SRS, SRS);
            }
        }

        private Point midPoint(Rectangle r)
        {
            return new Point(r.X+r.Width/2, r.Y + r.Height / 2);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}