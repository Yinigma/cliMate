using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    [Serializable]
    public class RectGrid
    {
        public const float MAX = 1.0f;
        public const float MIN = 0.0f;
        Tile[][] grid;
        private int width;
        public int Width { get { return width; } }
        private int height;
        public int Height { get { return height; } }
        //Yeah, you can make this whatever size you want, but this should always be projectWidth/Height
        //I just found it weird to have a project as a parameter. Project settings? Huh...
        //Maybe we should leave it as is anyway. Flexibility and all that jazz.
        public RectGrid(int numRows, int numCols)
        {
            grid = new Tile[numRows][];
            for (int r = 0; r < numRows; r++)
            {
                grid[r] = new Tile[numCols];
                for (int c = 0; c < numCols; c++)
                {
                    grid[r][c] = new Tile(0);
                }
            }
            width = numCols;
            height = numRows;
        }

        public Bitmap gridToBitmap()
        {
            Bitmap img = new Bitmap(width, height);
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    img.SetPixel(c, r, grid[r][c].getColor());
                }
            }
            return img;
        }

        public Bitmap gridToBitmap(ColorGrad.gradElement[] grad)
        {
            Bitmap img = new Bitmap(width, height);
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    img.SetPixel(c, r, ColorGrad.getGradColor(grad, grid[r][c].Value));
                }
            }
            return img;
        }
        public Bitmap gridToBitmapOcean(ColorGrad.gradElement[] landGrad, ColorGrad.gradElement[] seaGrad, float seaLevel)
        {
            Bitmap img = new Bitmap(width, height);
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    if (grid[r][c].Value > seaLevel)
                    {
                        img.SetPixel(c, r, ColorGrad.getGradColor(landGrad, (grid[r][c].Value-seaLevel)/(1 - seaLevel)));
                    }
                    else
                    {
                        img.SetPixel(c, r, ColorGrad.getGradColor(seaGrad, grid[r][c].Value / seaLevel));
                    }
                }
            }
            return img;
        }

        public void setTile(int row, int col, float val) { grid[row][col].Value = val; }
        public Tile getTile(int row, int col) { return grid[row][col]; }
    }
}
