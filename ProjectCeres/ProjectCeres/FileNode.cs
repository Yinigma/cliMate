using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCeres
{
    [Serializable]
    public class FileNode : InputNode
    {
        int xPos;
        int yPos;
        float xScale;
        float yScale;
        public Bitmap image;

        public FileNode(NodeMap map, String fileName) : base(map)
        {
            image = null;
            xPos = 0;
            yPos = 0;
            xScale = 1;
            yScale = 1;
        }

        

        public override void doOperation()
        {
            setDefault();
            //So we don't go out of bounds
            int startX = Math.Max(0, xPos);
            int startY = Math.Max(0, yPos);
            int endX = Math.Min(outGrid.Width, (int)((image.Width * xScale) + xPos));
            int endY = Math.Min(outGrid.Height, (int)((image.Height * yScale) + yPos));
            //I just put these guys here so I wouldn't have to declare them in the loop
            //Stands for image x and image y
            int imX;
            int imY;
            Color current;
            float heightVal;
            for(int row = startY; row<endY; row++)
            {
                for (int col = startX; col < endX; col++)
                {
                    imX = Math.Min(col * image.Width / (endX - startX),image.Width-1);
                    imY = Math.Min(row * image.Height / (endY - startY),image.Height - 1);
                    current = image.GetPixel(imX, imY);
                    //if the value isn't greyscale
                    if (current.B != current.G || current.B != current.R)
                    {
                        //Formula I got off a matlab page
                        heightVal = 0.2989f * current.R + 0.5870f * current.G + 0.1140f * current.B;

                        heightVal = Math.Min(heightVal, 255.0f);
                    }
                    else
                    {
                        heightVal = current.R;
                    }
                    heightVal /= 255.0f;
                    outGrid.getTile(row, col).Value = heightVal;
                }
            }
        }

        public override int getOptional()
        {
            return 0;
        }

        public override void openForm()
        {
            FileForm fileWin = new FileForm(this);
            fileWin.ShowDialog();
            if (fileWin.Valid) {
                xPos = fileWin.XPosition;
                yPos = fileWin.YPosition;
                xScale = fileWin.XScale;
                yScale = fileWin.YScale;
                image = fileWin.LoadedImage;
                doOperation();
            }
        }

        public int XPos { get { return xPos; } }
        public int YPos { get { return yPos; } }
        public float XScale { get { return xScale; } }
        public float YScale { get { return yScale; } }
    }
}
