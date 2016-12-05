using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    class Biomes
    {
        public static RectGrid moisture(RectGrid input, Project proj)
        {
            RectGrid landForms = seaLevel(input, proj);
            GeoGrid geo = new GeoGrid(proj.Frequency);
            GridDisplayEquiRect temp = new GridDisplayEquiRect(proj.Frequency);
            temp.RectToGeo(landForms, geo);
            //Note to self: just make this output a new grid every iteration with the outermost layer removed
            return null;
        }
        public static RectGrid seaLevel(RectGrid input, Project proj)
        {
            float sea = proj.SeaLevel;
            RectGrid landForms = new RectGrid(input.Height, input.Width);
            for (int r = 0; r < input.Height; r++)
            {
                for (int c = 0; c < input.Width; c++)
                {
                    if(input.getTile(r,c).Value<=sea)
                    {
                        landForms.getTile(r, c).Value = 0f;
                    }
                    else
                    {
                        landForms.getTile(r, c).Value = 1f;
                    }
                }
            }
            return landForms;
        }
    }
}
