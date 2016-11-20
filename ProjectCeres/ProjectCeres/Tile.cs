using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    public class Tile
    {
        private float val;

        public float Value
        {
            get { return val; }
            set { val = value; }
        }


        public Tile(float val)
        {
            this.val = val;
        }

        public Color getColor()
        {
            int iVal = (int)(this.val * 255);
            return Color.FromArgb(iVal, iVal, iVal);
        }
    }
}
