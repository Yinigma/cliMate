using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCeres
{
    class Biomes
    {
        public const int SEA = 9;
        public const int TUNDRA = 0;
        public const int GRASSLAND = 1;
        public const int WOODLAND = 2;
        public const int BOREALFOREST = 3;
        public const int SEASONALFOREST = 4;
        public const int TEMPERATEFOREST = 5;
        public const int TROPICALFOREST = 6;
        public const int SAVANNAH = 7;
        public const int DESERT = 8;
        private const float MAXALTIMPACT = 0.7f;

        private static readonly int[,] biomeTable = new int[6, 6]{ { TUNDRA, TUNDRA, GRASSLAND, DESERT, DESERT, DESERT },
                                                             { TUNDRA, TUNDRA, GRASSLAND, DESERT, DESERT, DESERT},
                                                             { TUNDRA, TUNDRA, WOODLAND, WOODLAND, SAVANNAH, SAVANNAH},
                                                             { TUNDRA, TUNDRA, BOREALFOREST, WOODLAND, SAVANNAH, SAVANNAH},
                                                             { TUNDRA, TUNDRA, BOREALFOREST, SEASONALFOREST, TROPICALFOREST, TROPICALFOREST},
                                                             { TUNDRA, TUNDRA, BOREALFOREST, TEMPERATEFOREST, TROPICALFOREST, TROPICALFOREST} };
        private static readonly Color[] colors =  {Color.White, Color.LawnGreen, Color.Peru, Color.DarkMagenta, Color.Tomato, Color.DarkGreen, Color.Teal, Color.Coral, Color.Beige, Color.SteelBlue };


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
                    for (int r = 0; r < freq - 1; r++)
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
                                        output.getTile(par, r, c).Rank = Math.Min(rank, cutoff);
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
                for (int r = 0; r < freq - 1; r++)
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
                    if (input.getTile(r, c).Value <= sea)
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
                for (int r = 0; r < freq - 1; r++)
                {
                    for (int c = 0; c < 2 * freq - 1; c++)
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
                        else if (r == 0 && c == freq - 1)
                        {
                            landForms.getTile(par, r, c).Value = 1f;
                        }
                        else if (r == 0 && c == 2 * freq - 2)
                        {
                            landForms.getTile(par, r, c).Value = 1f;
                        }
                        else if (r == freq - 1 && c == 0)
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

        public static RectGrid Temperature(RectGrid input, float equator)
        {
            Math.Abs(equator);
            equator -= (int)equator;
            int gridEquator = (int)(input.Height * equator);
            float dist;
            float latTemp;
            float altTemp;
            RectGrid temp = new RectGrid(input.Height, input.Width);
            for (int row = 0; row < input.Height; row++)
            {
                for (int col = 0; col < input.Width; col++)
                {
                    dist = (float)(gridEquator - row) / (input.Height / 2);
                    latTemp = 1 - dist*dist;
                    altTemp = MAXALTIMPACT * input.getTile(row, col).Value;
                    temp.getTile(row, col).Value = Math.Max(0, latTemp - altTemp);
                }
            }
            return temp;
        }

        public static RectGrid Temperature(RectGrid input)
        {
            return Temperature(input, 0.5f);
        }

        public static RectGrid BiomeMap(RectGrid input, Project proj, int cutoff, int[] newRank)
        {
            RectGrid moistureGrid = Biomes.moisture(input, proj, cutoff);
            RectGrid tempGrid = Biomes.Temperature(input);
            RectGrid biomeGrid = new RectGrid(input.Height, input.Width);

            int[,] converted = new int[6, 6];

            for(int i = 0; i<6; i++)
            {
                for(int j = 0; j<6; j++)
                {
                    converted[i, j] = newRank[biomeTable[i,j]];
                }
            }

            int tempDex;
            int moistDex;
            for(int row = 0; row < input.Height; row++)
            {
                for (int col = 0; col < input.Width; col++)
                {
                    if (input.getTile(row,col).Value<proj.SeaLevel)
                    {
                        biomeGrid.getTile(row, col).Rank = 9;
                        continue;
                    }
                    moistDex = (int)(moistureGrid.getTile(row,col).Value * 5);
                    tempDex = (int)(tempGrid.getTile(row, col).Value * 5);
                    biomeGrid.getTile(row, col).Rank = converted[moistDex,tempDex];
                }
            }

            return biomeGrid;
        }
        public static Bitmap renderBiomes(RectGrid rg)
        {
           
            Bitmap img = new Bitmap(rg.Width, rg.Height);
            int toggle;
            for(int row = 0; row < rg.Height; row++)
            {
                for (int col = 0; col < rg.Width; col++)
                {
                    toggle = rg.getTile(row, col).Rank;
                    img.SetPixel(col, row, colors[toggle]);
                }
            }
            return img;
        }
    }
}