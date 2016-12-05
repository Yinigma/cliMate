using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectCeres
{
    
    public class ColorGrad
    {
        //Look at Ben: making more nested classes. Ooh ah, what a dork.
        //Maybe we should eat all of his christmas lights and teach him a lesson.

            //That'll show me. Do it. Coward.
        public class gradElement
        {
            private float pos;
            private Color c;
            public gradElement(float pos, Color c)
            {
                this.c = c;
                //Ensures color is between 0 and 1.
                //I don't wanna have to check this every time we get try to render a color
                this.pos = Math.Min(pos, 1.0f);
                this.pos = Math.Max(pos, 0.0f);
            }
            public float Position { get{ return pos; } }
            public Color GradColor { get{ return c; } }
        }

        public static readonly gradElement T0 = new gradElement(0,Color.DarkRed);
        public static readonly gradElement T1 = new gradElement(0.25f, Color.IndianRed);
        public static readonly gradElement T2 = new gradElement(0.5f, Color.Orange);
        public static readonly gradElement T3 = new gradElement(0.75f, Color.LightYellow);
        public static readonly gradElement T4 = new gradElement(1.0f, Color.White);
        public static readonly gradElement[] tempGradient = {T0,T1,T2,T3,T4};

        public static readonly gradElement L0 = new gradElement(0, Color.SandyBrown);
        public static readonly gradElement L1 = new gradElement(0.25f, Color.LightGreen);
        public static readonly gradElement L2 = new gradElement(0.5f, Color.LightGoldenrodYellow);
        public static readonly gradElement L3 = new gradElement(0.75f, Color.Gray);
        public static readonly gradElement L4 = new gradElement(1.0f, Color.White);
        public static readonly gradElement[] LandGradient = { L0, L1, L2, L3, L4 };

        //Gets a color
        //Assumes a sorted array of gradElements
        //I should fix that...
        public static Color getGradColor(gradElement[] grad, float val)
        {
            if(grad.Length == 0)
            {
                return Color.Black;
            }
            else if (grad.Length == 1||val<=grad[0].Position)
            {
                return grad[0].GradColor;
            }
            else if (val >= grad[grad.Length - 1].Position)
            {
                return grad[grad.Length - 1].GradColor;
            }
            float pos;
            int index = 0;
            pos = Math.Min(val, 1.0f);
            pos = Math.Max(val, 0.0f);
            while (grad[index].Position<pos){
                index++;
            }
            //This is to avoid divide by zero errors where two elements are put in in the same place for 
            //some stupid reason
            if (grad[index].Position == grad[index - 1].Position)
            {
                return grad[index].GradColor;
            }
            gradElement g0 = grad[index - 1];
            gradElement g1 = grad[index];
            //Leave it to Alexavier
            return Utils.LerpColor(g0.GradColor,g1.GradColor, (double)((pos-g0.Position)/(g1.Position-g0.Position)));
        }
    }
}
