using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCeres
{
    class Biomes
    {
        //cutoff determines the amount of steps before moisture reaches its lowest point
        public static RectGrid moisture(RectGrid input, Project proj, int cutoff)
        {
            
            GeoGrid geo = new GeoGrid(proj.Frequency);
            GeoGrid output = new GeoGrid(proj.Frequency);
            RectGrid coastDist = new RectGrid(input.Height, input.Width);
            GridDisplayEquiRect temp = new GridDisplayEquiRect(proj.Frequency);
            temp.RectToGeo(input, geo);
            GeoGrid landForms = seaLevel(geo, proj);
            int freq = landForms.getFrequency();
            int rank = 1;
            Tile[] mates;
            bool clear = false;
            while (!clear)
            {
                clear = true;
                GeoGrid next = landForms.deepCopy(proj.Frequency);
                //Wheeeeeeee~
                for (int par = 0; par < GeoGrid.NUMPARA; par++)
                {
                    for (int r = 0; r < freq-1; r++)
                    {
                        for (int c = 0; c < 2 * freq - 1; c++)
                        {
                            //If it's a land tile that hasn't been visited...
                            if (landForms.getTile(par, r, c).Value > .5f)
                            {
                                mates = landForms.neighbors(r, c, par);
                                for (int m = 0; m < mates.Length; m++)
                                {
                                    //if it's a sea tile
                                    if (mates[m].Value < .5f)
                                    {
                                        //Remove from next step
                                        next.getTile(par, r, c).Value = 0f;
                                        //set distance away from coast
                                        output.getTile(par, r, c).Rank = Math.Min(rank,cutoff);
                                        clear = false;
                                    }
                                }
                            }
                        }
                    }
                }
                landForms = next;
                rank++;
            }
            //Determine moisture weight by dividing by cutoff (yes, I coulda put this in the loop above)
            for (int par = 0; par < GeoGrid.NUMPARA; par++)
            {
                for (int r = 0; r < freq-1; r++)
                {
                    for (int c = 0; c < 2 * freq - 1; c++)
                    {
                        output.getTile(par, r, c).Value = 1 - ((float)output.getTile(par, r, c).Rank / cutoff);
                        output.getTile(par, r, c).Rank = 0;
                    }
                }
            }
            temp.LoadGrid(output);
            temp.GeoToRect(coastDist);
            return coastDist;
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
        public static GeoGrid seaLevel(GeoGrid input, Project proj)
        {
            float sea = proj.SeaLevel;
            int freq = input.getFrequency();
            GeoGrid landForms = new GeoGrid(proj.Frequency);
            for (int par = 0; par < GeoGrid.NUMPARA; par++)
            {
                for (int r = 0; r < freq-1; r++)
                {
                    for (int c = 0; c < 2*freq-1; c++)
                    {
                        if (input.getTile(par, r, c).Value <= sea)
                        {
                            landForms.getTile(par, r, c).Value = 0f;
                        }
                        else
                        {
                            landForms.getTile(par, r, c).Value = 1f;
                        }
                        if (r == 0 && c == 0)
                        {
                            landForms.getTile(par, r, c).Value = 1f;
                        }
                        else if (r == 0 && c == freq-1)
                        {
                            landForms.getTile(par, r, c).Value = 1f;
                        }
                        else if (r == 0 && c == 2*freq - 2)
                        {
                            landForms.getTile(par, r, c).Value = 1f;
                        }
                        else if (r == freq-1 && c == 0)
                        {
                            landForms.getTile(par, r, c).Value = 1f;
                        }
                        else if (r == freq - 1 && c == freq - 1)
                        {
                            landForms.getTile(par, r, c).Value = 1f;
                        }
                        else if (r == freq - 1 && c == 2 * freq - 2)
                        {
                            landForms.getTile(par, r, c).Value = 1f;
                        }

                    }
                }
            }
            return landForms;
        }

        public static RectGrid Temperature(RectGrid input)
        {
            RectGrid temp = new RectGrid(0,0);
            return null;
        }
    }
}
