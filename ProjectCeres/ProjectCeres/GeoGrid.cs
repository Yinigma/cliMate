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
        const int NUMPARA = 5;

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
            this.frequency = (int) Math.Pow(2.0f,subdivisions) + 1;
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
