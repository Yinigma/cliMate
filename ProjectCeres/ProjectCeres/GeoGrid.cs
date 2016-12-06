using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace ProjectCeres
{
    public class GeoGrid
    {
        private Tile[][][] grid;
        int frequency;
        public const int NUMPARA = 5;

        public GeoGrid(int subdivisions)
        {

            /*So anyway, this breaks up the icosahedron into 5 parallelograms
            I implemented it this way to avoid confusion with the middle row 
            being twice as dense as the top and bottom rows when flattend into 
            a grid.

                   /\      /\      /\      /\      /\
                  /  \    /  \    /  \    /  \    /  \
                 /0, 0\  /1, 0\  /2, 0\  /3, 0\  /4, 0\
                /______\/______\/______\/______\/______\
                \      /\      /\      /\      /\      /\
                 \0, 1/  \1, 1/  \2, 1/  \3, 1/  \4, 1/  \
                  \  /0, 2\  /1, 2\  /2, 2\  /3, 2\  /4, 2\
                   \/______\/______\/______\/______\/______\
                    \      /\      /\      /\      /\      /
                     \0, 3/  \1, 3/  \2, 3/  \3, 3/  \4, 3/
                      \  /    \  /    \  /    \  /    \  /
                       \/      \/      \/      \/      \/
                  
                  |
                  |
            One parallelogram
            goes into a matrix like this
                  |
                 \|/
                  V
               __________
               |   /|   /|
               |  / |  / |
               | /  | /  |
               |/___|/___|
                
            
            Don't ever say I don't leave helpful comments.
            *Burp*
            */
            Random rando = new Random();
            grid = new Tile[NUMPARA][][];
            frequency = (int) Math.Pow(2.0f,subdivisions) + 1;
            for(int i = 0; i< NUMPARA; i++)
            {
                grid[i] = new Tile[frequency][];
                for (int j = 0; j < frequency; j++)
                {
                    grid[i][j] = new Tile[frequency * 2-1];
                    for (int k = 0; k < (frequency * 2)-1; k++)
                    {
                        //I wish I could explain this with a picture as usual. 
                        //These if fix it so that the seams point to the same object.
                        //Figured I'd do it on instantiation.
                        if (i != 0)
                        {
                            if (k == 0)
                            {
                                grid[i][j][k] = grid[i - 1][0][j];
                                
                            }
                            else if (j == (frequency - 1))
                            {
                                if (k <= frequency-1&&k>0)
                                {
                                    grid[i][j][k] = grid[i - 1][0][k + frequency - 1];
                                }
                                else if (k > frequency-1)
                                {
                                    grid[i][j][k] = grid[i - 1][k-(frequency-1)][2*frequency-2];//new Tile(Color.Green);

                                }
                            }
                            else
                            {
                                grid[i][j][k] = new Tile(0);
                            }
                            //on the last parallelogram
                            if (i == NUMPARA - 1)
                            {
                                if (j == 0)
                                {
                                    if (k < frequency)
                                    {
                                        grid[i][j][k] = grid[0][k][0];//new Tile(Color.Cyan);//
                                    }
                                    if (k >= frequency)
                                    {
                                        grid[i][j][k] = grid[0][frequency - 1][k-frequency];//new Tile(Color.Yellow);//
                                    }
                                }
                                else if (k == (2 * frequency) - 2)
                                {
                                    grid[i][j][k] = grid[0][frequency - 1][frequency - 1 + j];//new Tile(Color.Magenta); 
                                }
                            }
                        }
                        else
                        {
                            grid[i][j][k] = new Tile(0);

                        }
                    }
                }
            }
        }
        
        //Returns color at the specified parallelogram (see diagram above), row and column of given parallelogram
        public Color getColor(int parallel,  int row, int column)
        {
            return grid[parallel][row][column].getColor();
        }
        //Returns tile at coordinates
        public Tile getTile(int parallel, int row, int col)
        {
            return grid[parallel][row][col];
        }
        //Returns the resoultion of the grid
        public int getFrequency()
        {
            return frequency;
        }

        public Tile[] neighbors(int row, int col, int par)
        {
            //I'm gonna fucking kill myself debugging this.
            Tile[] mates = new Tile[6];
            for(int i = 0; i<6; i++)
            {
                mates[i] = null;
            }
            if (row == 0)
            {
                if (col == 0)
                {
                    //Corner Case: upper left pentagon
                    mates = new Tile[5];
                    for(int i = 0; i< NUMPARA; i++)
                    {
                        mates[i] = grid[i][1][0];
                    }
                    return mates;
                }
                else if(col < frequency - 1)
                {
                    //edge case: upper left edge
                    mates[2] = grid[(par + 1) % (NUMPARA)][col-1][1];
                    mates[3] = grid[(par + 1) % (NUMPARA)][col][1];
                }
                else if (col==2*frequency-2)
                {
                    //Corner case: upper right pentagon
                    mates = new Tile[5];
                    mates[0] = grid[par][row+1][col-1];
                    mates[1] = grid[par][row][col - 1];
                    mates[2] = grid[(par + 1) % (NUMPARA)][frequency - 2][col - (frequency - 1)];
                    mates[3] = grid[(par + 1) % (NUMPARA)][frequency - 2][col - (frequency - 1) + 1];
                    mates[4] = grid[par][row+1][col];
                    return mates;
                }
                else if(col > frequency - 1)
                {
                    //upper right edge
                    mates[2] = grid[(par + 1) % (NUMPARA)][frequency - 2][col - (frequency - 1)];
                    mates[3] = grid[(par + 1) % (NUMPARA)][frequency - 2][col - (frequency - 1) + 1];
                }
                else
                {
                    //Corner case: upper middle pentagon
                    mates = new Tile[5];
                    mates[0] = grid[par][1][col - 1];
                    mates[1] = grid[par][0][col - 1];
                    mates[2] = grid[(par + 1) % (NUMPARA)][frequency-2][1];
                    mates[3] = grid[par][0][col + 1];
                    mates[4] = grid[par][1][col];
                    return mates;
                }
            }
            else if (row == frequency - 1)
            {
                int nextPara = (par == 0) ? NUMPARA - 1 : par - 1;
                if (col == 0)
                {
                    //Corner Case: lower left pentagon
                    mates = new Tile[5];
                    mates[0] = grid[nextPara][1][frequency-2];
                    mates[1] = grid[par][row - 1][col];
                    mates[2] = grid[par][row - 1][col + 1];
                    mates[3] = grid[par][row][col + 1];
                    mates[4] = grid[nextPara][1][frequency - 1];
                    return mates;
                }
                else if (col < frequency - 1)
                {
                    //edge case: lower left edge
                    mates[5] = grid[nextPara][1][frequency - 1 + col];
                    mates[0] = grid[nextPara][1][frequency - 2 + col];
                }
                else if (col == 2 * frequency - 2)
                {
                    //Corner case: lower right pentagon
                    mates = new Tile[5];
                    for (int i = 0; i < NUMPARA; i++)
                    {
                        mates[i] = grid[i][frequency-1][2 * frequency - 3];
                    }
                    return mates;
                }
                else if (col > frequency - 1)
                {
                    //edge case: lower right edge
                    mates[5] = grid[nextPara][col-(frequency-1)+1][2 * frequency - 3];
                    mates[0] = grid[nextPara][col-(frequency-1)][2 * frequency - 3];
                }
                else
                {
                    //Corner case: lower middle pentagon
                    mates = new Tile[5];
                    mates[0] = grid[nextPara][1][2 * frequency - 3];
                    mates[1] = grid[par][row][col - 1];
                    mates[2] = grid[par][row - 1][col];
                    mates[3] = grid[par][row - 1][col + 1];
                    mates[4] = grid[par][row][col + 1];
                    return mates;
                }
            }
            else if (col == 0)
            {
                //Edge case: left edge
                int nextPara = (par == 0) ? NUMPARA - 1 : par - 1;
                mates[0] = grid[nextPara][1][row];
                mates[1] = grid[nextPara][1][row-1];

            }
            else if(col == frequency * 2 - 2)
            {
                //Edge case: Right edge
                mates[3] = grid[(par + 1) % (NUMPARA)][frequency - 2][frequency - 1 + row];
                mates[4] = grid[(par + 1) % (NUMPARA)][frequency - 2][frequency  + row];
            }
            //I bet you could do this with a for loop and mod ops
            //but fuck that, it's 2 am
            if (mates[0] == null) { mates[0] = grid[par][row+1][col-1]; }
            if (mates[1] == null) { mates[1] = grid[par][row][col-1]; }
            if (mates[2] == null) { mates[2] = grid[par][row-1][col]; }
            if (mates[3] == null) { mates[3] = grid[par][row-1][col+1]; }
            if (mates[4] == null) { mates[4] = grid[par][row][col+1]; }
            if (mates[5] == null) { mates[5] = grid[par][row+1][col]; }
            return mates;
        }

        public void DBrandom()
        {
            Random r = new Random();
            for (int i = 0; i<NUMPARA; i++)
            {
                for (int j = 0; j<frequency; j++)
                {
                    for(int k = 0; k < 2 * frequency - 1; k++)
                    {
                        grid[i][j][k].Value = ((float)r.Next(255)) / 255.0f;
                    }
                }
            }
        }

        public GeoGrid deepCopy(int numsubs)
        {
            GeoGrid dup = new GeoGrid(numsubs);
            for (int i = 0; i < NUMPARA; i++)
            {
                for (int j = 0; j < frequency-1; j++)
                {
                    for (int k = 0; k < 2 * frequency - 1; k++)
                    {
                        dup.getTile(i,j,k).Value = grid[i][j][k].Value;
                        dup.getTile(i, j, k).Rank = grid[i][j][k].Rank;
                    }
                }
            }
            return dup;
        }

        public void DBfaceColors()
        {
            float[] rand = new float[20];
            Random r = new Random();
            for(int i = 0; i < rand.Length; i++)
            {
                rand[i] = (float)r.NextDouble();
            }
            for(int i = 0; i < NUMPARA; i++)
            {
                for (int row = 0; row < frequency-1; row++)
                {
                    for(int col = 1; col< frequency*2-1; col++)
                    {
                        //first half of parallelogram
                        if (col <= frequency - 1)
                        {
                            if (row < frequency - col)
                            {
                                grid[i][row][col].Value = rand[4 * i];
                            }
                            else
                            {
                                grid[i][row][col].Value = rand[4 * i +1];
                            }
                        }
                        //second half
                        else
                        {
                            if (row < 2 * frequency - col - 1)
                            {
                                grid[i][row][col].Value = rand[4 * i + 2];
                            }
                            else
                            {
                                grid[i][row][col].Value = rand[4 * i + 3];
                            }
                        }
                    }
                }
            }
        }

    }
}
