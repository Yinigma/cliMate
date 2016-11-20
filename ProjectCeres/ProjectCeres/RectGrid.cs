using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    public class RectGrid
    {
        Tile[][] grid;
        private int width;
        public int Width { get { return width; } }
        private int height;
        //Yeah, you can make this whatever size you want, but this should always be projectWidth/Height
        //I just found it weird to have a project as a parameter. Project settings? Huh...
        //Maybe we should leave it as is anyway. Flexibility and all that jazz.
        public RectGrid(int xres, int yres)
        {
            grid = new Tile[xres][];
            for (int x = 0; x < xres; x++)
            {
                grid[x] = new Tile[yres];
                for (int y = 0; y < yres; y++)
                {
                    grid[x][y] = new Tile(0);
                }
            }
            this.width = xres;
            this.height = yres;
        }

        public Bitmap gridToBitmap()
        {
            Bitmap img = new Bitmap(grid.Length, grid[0].Length);
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[x].Length; y++)
                {
                    img.SetPixel(x, y, grid[x][y].getColor());
                }
            }
            return img;
        }

        public void setTile(int x, int y, float val) { grid[x][y].Value = val; }
        public Tile getTile(int x, int y) { return grid[x][y]; }
    }
}
