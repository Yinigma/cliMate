using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    [Serializable]
    public class Project
    {
        private int Width;
        private int Height;
        private int frequency;
        private NodeMap map;
        private float seaLevel;
        private GridDisplayEquiRect equiDisp;



        public Project(int w, int h, int f, float sl)
        {
            Width = w;
            Height = h;
            frequency = f;
            seaLevel = sl;
            equiDisp = new GridDisplayEquiRect(frequency);
            map = new NodeMap(Width, Height);
        }
        public Project(){
            Width = 640;
            Height = 480;
            frequency = 6;
            seaLevel = 0.25f;
            equiDisp = new GridDisplayEquiRect(frequency);
            map = new NodeMap(Width, Height);
        }
        public NodeMap getMap()
        {
            return map;
        }
        public GridDisplayEquiRect EquiDisp { get { return equiDisp; } }
        public int Frequency { get { return frequency; } }
        public float SeaLevel { get { return seaLevel; } }

    }
}
