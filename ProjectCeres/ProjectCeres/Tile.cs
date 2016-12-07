using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    [Serializable]
    public class Tile
    {
        private float val;
        private int rank;

        public Tile(float val)
        {
            rank = 0;
            this.val = val;
        }

        public Color getColor()
        {
            int iVal = (int)(val * 255);
            return Color.FromArgb(iVal, iVal, iVal);
        }
        public float Value { get { return val; } set { val = value; } }
        public int Rank {get { return rank; } set{ rank = value; } }
    }
}
