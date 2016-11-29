using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    public class Project
    {
        private int Width;
        private int Height;
        private int frequency;
        private NodeMap map;
        private GridDisplayEquiRect equiDisp;



        public Project(int w, int h, int f)
        {
            Width = w;
            Height = h;
            frequency = f;
            equiDisp = new GridDisplayEquiRect(frequency);
            map = new NodeMap(Width, Height);
        }
        public Project(){
            Width = 640;
            Height = 480;
            frequency = 4;
            equiDisp = new GridDisplayEquiRect(frequency);
            map = new NodeMap(Width, Height);
        }
        public NodeMap getMap()
        {
            return map;
        }
        public GridDisplayEquiRect EquiDisp { get { return equiDisp; } }

    }
}
