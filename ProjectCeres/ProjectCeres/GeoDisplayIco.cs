using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace CliMate
{
    class GeoDisplayIco
    {
        //These just get division out of the way so the program isn't doing it every time it draws a shape 
        const float ASPECT = (float)Screen.WIDTH / (float)Screen.HEIGHT;
        const float ROOT3 = 1.732051f;
        const float ICOASPECT = 11.0f / (ROOT3 * 3.0f);

        const int TOP = 0;
        const int LEFT = 1;
        const int RIGHT = 2;


        public GameWindow window;
        private GeoGrid grid;

        public GeoDisplayIco(GameWindow window, GeoGrid grid)
        {
            this.window = window;
            this.grid = grid;

            window.Load += Window_Load;
            window.UpdateFrame += Window_UpdateFrame;
            window.RenderFrame += Window_RenderFrame;
            window.Closing += Window_Closing;

        }

        ///////////////////////////////////////////////////////////////////////////////
        //<OPENGL HOOKS>
        ///////////////////////////////////////////////////////////////////////////////

        private void Window_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.LightSkyBlue);
            

            GL.Viewport(0,0,Screen.WIDTH,Screen.HEIGHT);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(-ASPECT, ASPECT, -1, 1, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

        }
        private void Window_UpdateFrame(object sender, FrameEventArgs e)
        {
            //GL.ClearColor(Color.LightSkyBlue);
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            //GL.ClearColor(Color.LightSkyBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            this.drawGrid();

            GL.Flush();
            window.SwapBuffers();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        ///////////////////////////////////////////////////////////////////////////////
        //</OPENGL HOOKS>
        ///////////////////////////////////////////////////////////////////////////////


        //Method for drawing a hexagon
        private void DrawHex(float x, float y, float size, Color value)
        {
            GL.Begin(BeginMode.Polygon);
            //Set that color
            GL.Color3(value);

            //This loop just goes around a circle dropping a vertex every 60 degrees
            for (int i = 0; i < 6; ++i)
            {
                GL.Vertex2(size * Math.Sin(i / 6.0 * 2 * Math.PI) + x, size * Math.Cos(i / 6.0 * 2 * Math.PI) + y);
            }
            GL.End();
        }

        //This method draws the corners of each facet
        //So I went with drawing unique shapes because stencils don't have the capability of masking 20 triangles at once and it's kinda complicated to implement anyway
        private void DrawCorner(float x, float y, float size, Color value, int orientation, bool flip)
        {
            //Boolean for when you need to draw stuff upside-down
            int reflect = flip ? -1 : 1;
            GL.Begin(BeginMode.Polygon);
            //Set that color
            GL.Color3(value);
            //This loop just goes around a circle dropping a vertex every 60 degrees
            if (orientation == TOP)
            {
                GL.Vertex2(x, y);
                //Magic numbers whatever. It's trig. Get over it.
                GL.Vertex2(x - ( ROOT3 * size / 4), y - (0.75f * size * reflect));
                GL.Vertex2(x, y - (size * reflect));
                GL.Vertex2(x + ( ROOT3 * size / 4), y - (0.75f * size * reflect));
            }
            else if (orientation == LEFT)
            {
                GL.Vertex2(x, y);
                GL.Vertex2(x + ( size * ROOT3 / 2), y);
                GL.Vertex2(x + ( size * ROOT3 / 2), y + (0.5f * size * reflect));
                GL.Vertex2(x + (ROOT3 * size / 4), y + (0.75f * size * reflect));
            }
            else if (orientation == RIGHT)
            {
                GL.Vertex2(x, y);
                GL.Vertex2(x - (size * ROOT3 / 2), y);
                GL.Vertex2(x - (size * ROOT3 / 2), y + (0.5f * size * reflect));
                GL.Vertex2(x - (ROOT3 * size / 4), y + (0.75f * size * reflect));
            }
            GL.End();
        }
        //This draws the five-sided polygons on the edges of each triangular face
        private void DrawEdge(float x, float y, float size, Color value, int orientation, bool flip)
        {
            int reflect = flip ? -1 : 1;
            GL.Begin(BeginMode.Polygon);
            GL.Color3(value);
            if (orientation==LEFT)
            {
                GL.Vertex2(x + (size * ROOT3 / 4), y + (reflect * size * 0.75f));
                for (int i = 1; i < 4; ++i)
                {
                    GL.Vertex2((size * Math.Sin(i / 6.0 * 2 * Math.PI)) + x, (reflect * size * Math.Cos(i / 6.0 * 2 * Math.PI)) + y);
                }
                GL.Vertex2(x - (size * ROOT3 / 4), y - (reflect * size * 0.75f));
            }
            if (orientation == RIGHT)
            {
                GL.Vertex2((x + (size * ROOT3 / 4)), y - (reflect * size * 0.75f));
                for (int i = 3; i < 6; ++i)
                {
                    GL.Vertex2((size * Math.Sin(i / 6.0 * 2 * Math.PI)) + x, (reflect * size * Math.Cos(i / 6.0 * 2 * Math.PI)) + y);
                }
                GL.Vertex2(x - (size * ROOT3 / 4), y + (reflect * size * 0.75f));
            }
            if (orientation == TOP)
            {
                GL.Vertex2(x - (size * ROOT3 / 2), y);
                for (int i = 5; i < 8; ++i)
                {
                    GL.Vertex2((size * Math.Sin(i / 6.0 * 2 * Math.PI)) + x, (reflect * size * Math.Cos(i / 6.0 * 2 * Math.PI)) + y);
                }
                GL.Vertex2(x + (size * ROOT3 / 2), y);
            }
            GL.End();
        }

        //I can get rid of the flip parameter here later.
        private void DrawIcoFace(int frequency, float size, float initX, float initY, int parallel, int tri)
        {
            Random rand = new Random();

            float curX = initX;
            float curY = initY;

            bool flip = !((tri % 2) == 0);
            int reflect = flip ? -1 : 1;
            int flipOffset = (frequency - 1);
            int faceOffset = (tri > 1) ? (frequency - 1) : 0;
           

            if (parallel > 4||tri>3)
            {
                return;
            }

            for (int i = 1; i < frequency + 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    float rowX = (curX + j * ROOT3 * size);
                    Color val;//Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    if(flip)
                    {
                        val = grid.getColor(parallel, flipOffset - j, flipOffset - i + 1 + j + faceOffset);
                    }
                    else
                    {
                        val = grid.getColor(parallel, i - 1 - j, j + faceOffset);
                    }

                    if (i == 1)
                    {
                        DrawCorner(rowX, curY, size, val, TOP, flip);
                    }
                    else if (i == frequency && j == 0)
                    {
                        DrawCorner(rowX, curY, size, val, LEFT, flip);
                    }
                    else if (i == frequency && j == i - 1)
                    {
                        DrawCorner(rowX, curY, size, val, RIGHT, flip);
                    }
                    else if (j == 0)
                    {
                        DrawEdge(rowX, curY, size, val, LEFT, flip);
                    }
                    else if (j == i - 1)
                    {
                        DrawEdge(rowX, curY, size, val, RIGHT, flip);
                    }
                    else if (i == frequency)
                    {
                        DrawEdge(rowX, curY, size, val, TOP, flip);
                    }
                    else
                    {
                        DrawHex(rowX, curY, size, val);
                    }
                }
                //Change current x and y to move down and to the left or up and to the right
                curX -= (ROOT3 / 2 * size);
                curY -= reflect * 1.5f * size;
            }
        }
        public void drawGrid()
        {
            int frequency = grid.getFrequency();
            float size;
            float initX;
            float initY;

            if (ASPECT <= ICOASPECT)
            {
                size = (2.0f * ASPECT) / ((11.0f) * (frequency - 1) * (ROOT3 / 2.0f));
                initX = -ASPECT + (2.0f * ASPECT) / 11.0f;
                initY = 1.0f - (1.0f - ASPECT / ICOASPECT);

                for (int i = 0; i < 5; i++)
                {
                    DrawIcoFace(frequency, size, initX, initY, i, 0);
                    DrawIcoFace(frequency, size, initX, initY - ((ROOT3 * 2.0f * ASPECT) / 5.5f), i, 1);
                    DrawIcoFace(frequency, size, initX + ((2.0f * ASPECT) / 11.0f), initY - ((ROOT3 * ASPECT) / 5.5f), i, 2);
                    DrawIcoFace(frequency, size, initX + ((2.0f * ASPECT) / 11.0f), initY - ((ROOT3 * 3.0f * ASPECT) / 5.5f), i, 3);

                    initX += (2.0f * ASPECT) / 5.5f;
                }
            }
            else
            {
                size = 4.0f / (9.0f * (frequency - 1));
                initX = -ICOASPECT + (ICOASPECT / 11.0f);
                initY = 1.0f;

                for (int i = 0; i < 5; i++)
                {
                    DrawIcoFace(frequency, size, initX + (2 * i * ICOASPECT / 5.5f), initY, i, 0);
                    DrawIcoFace(frequency, size, initX + (2 * i * ICOASPECT / 5.5f), initY - (4.0f / 3.0f), i, 1);
                    DrawIcoFace(frequency, size, initX + ((2 * i + 1) * ICOASPECT / 5.5f), initY - (2.0f / 3.0f), i, 2);
                    DrawIcoFace(frequency, size, initX + ((2 * i + 1) * ICOASPECT / 5.5f), initY - (6.0f / 3.0f), i, 3);
                }
            }
        }
    }
}
