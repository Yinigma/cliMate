using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    public class Project
    {
        private int Width { get; }
        private int Height { get; }
        private NodeMap map;
       

        public Project(int w, int h)
        {
            Width = w;
            Height = h;
            map = new NodeMap(Width, Height);
        }
        public Project(){
            Width = 640;
            Height = 480;
            map = new NodeMap(Width, Height);
        }
        public NodeMap getMap()
        {
            return map;
        }

    }
}
