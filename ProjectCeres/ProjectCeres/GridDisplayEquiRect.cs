using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace CliMate
{
    //This is still beyond broken.
    class GridDisplayEquiRect
    {

        //Some of these I can switch to local vars in the constructor later. I wanna get it working first, though...
        GameWindow window;
        Hexagon[] hexList;
        Color[] colors;
        int numSubs;
        int count = 0;

        private class Triangle
        {

            public Vector3 t0, t1, t2;
            public Triangle n0, n1, n2;
            public Triangle(Vector3 t0, Vector3 t1, Vector3 t2)
            {
                this.t0 = t0;
                this.t1 = t1;
                this.t2 = t2;
                n0 = null;
                n1 = null;
                n2 = null;
            }
            public void neighbor0(Triangle t)
            {
                this.n0 = t;
            }
            public void neighbor1(Triangle t)
            {
                this.n1 = t;
            }
            public void neighbor2(Triangle t)
            {
                this.n2 = t;
            }
            public Vector3 mid()
            {
                //This method is documented and pretty quick.
                //There's a link
                //github.com/mono/opentk/blob/master/Source/OpenTK/Math/Vector3.cs
                return Vector3.BaryCentric(t0,t1,t2, 1.0f / 3.0f, 1.0f / 3.0f);
            }

        };

        private class Hexagon
        {

            public Vector3[] points;
            public Vector2[] equiVec;
            bool proj;
            public bool isEdge;
            public float weight;
            public Tile tile;
            public Hexagon(Vector3 h0, Vector3 h1, Vector3 h2, Vector3 h3, Vector3 h4, Vector3 h5)
            {
                points = new Vector3[6];
                points[0] = h0;
                points[1] = h1;
                points[2] = h2;
                points[3] = h3;
                points[4] = h4;
                points[5] = h5;
                proj = false;
                isEdge = false;
                weight = 0.0f;
                equiVec = new Vector2[6];
                tile = null;
            }
            public void project()
            {
                proj = true;
                for (int i = 0; i < 6; i++) {

                    float offset = 0.25f;
                    if (points[i].X < 0)
                    {
                        offset = -0.25f;
                    }
                    float r = (float)Math.Sqrt(points[i].X * points[i].X + points[i].Y * points[i].Y + points[i].Z * points[i].Z);
                    float phi = (float) Math.Acos(points[i].Z/r);
                    float theta = (float)Math.Atan(points[i].Y/ points[i].X);

                    equiVec[i] = new Vector2();
                    equiVec[i].X = 2 * (theta / (2 * (float)Math.PI) + offset) + 0.5f;
                    equiVec[i].Y = 2 * (phi / ((float)Math.PI)-0.5f);
                    if (equiVec[i].X > 1.0f)
                    {
                        equiVec[i].X = equiVec[i].X - 2.0f;
                    }

                }
                if (equiVec[0].X>0.0f&&equiVec[4].X<0.0f|| equiVec[1].X > 0.0f && equiVec[3].X < 0.0f)
                {
                    isEdge = true;
                }

            }
            public bool isProj()
            {
                return proj;
            }
        };

        private class Pentagon
        {

            public Vector3 h0, h1, h2, h3, h4;
            private Vector2[] equiVec;
            bool proj;
            public Pentagon(Vector3 h0, Vector3 h1, Vector3 h2, Vector3 h3, Vector3 h4)
            {
                this.h0 = h0;
                this.h1 = h1;
                this.h2 = h2;
                this.h3 = h3;
                this.h4 = h4;
                proj = false;
                equiVec = new Vector2[5];
            }
            public void project()
            {
                //TODO apply equirectangular projection
            }
        };

        public GridDisplayEquiRect(int numSubs, GameWindow window)
        {
            this.numSubs = numSubs;
            Triangle[] ico = new Triangle[20];
            Triangle[][] icoEdge = new Triangle[20][];
            for (int i = 0; i < 5; i++)
            {
                //Each iteration of this loop will produce a 3d coordinates for 4 triangles in the parallelogram strip (did this so it'd play nice with the data representation)
                Vector3 t0;
                Vector3 t1;
                Vector3 t2;

                t0 = new Vector3(0.0f, 0.0f, 1.0f);
                t1 = new Vector3((float)Math.Cos(((2 * i) * Math.PI) / 5), (float)Math.Sin(((2 * i) * Math.PI) / 5), 0.5f);
                t2 = new Vector3((float)Math.Cos(((2 * i + 2) * Math.PI) / 5), (float)Math.Sin(((2 * i + 2) * Math.PI) / 5), 0.5f);
                ico[4 * i] = new Triangle(t0, t1, t2);

                t0 = new Vector3((float)Math.Cos(((2 * i + 1) * Math.PI) / 5), (float)Math.Sin(((2 * i + 1) * Math.PI) / 5), -0.5f);
                t1 = new Vector3((float)Math.Cos(((2 * i + 2) * Math.PI) / 5), (float)Math.Sin(((2 * i + 2) * Math.PI) / 5), 0.5f);
                t2 = new Vector3((float)Math.Cos(((2 * i) * Math.PI) / 5), (float)Math.Sin(((2 * i) * Math.PI) / 5), 0.5f);
                ico[4 * i + 1] = new Triangle(t0, t1, t2);


                t0 = new Vector3((float)Math.Cos(((2 * i + 2) * Math.PI) / 5), (float)Math.Sin(((2 * i + 2) * Math.PI) / 5), 0.5f);
                t1 = new Vector3((float)Math.Cos(((2 * i + 1) * Math.PI) / 5), (float)Math.Sin(((2 * i + 1) * Math.PI) / 5), -0.5f);
                t2 = new Vector3((float)Math.Cos(((2 * i + 3) * Math.PI) / 5), (float)Math.Sin(((2 * i + 3) * Math.PI) / 5), -0.5f);
                ico[4 * i + 2] = new Triangle(t0, t1, t2);

                t0 = new Vector3(0.0f, 0.0f, -1.0f);
                t1 = new Vector3((float)Math.Cos(((2 * i + 3) * Math.PI) / 5), (float)Math.Sin(((2 * i + 3) * Math.PI) / 5), -0.5f);
                t2 = new Vector3((float)Math.Cos(((2 * i + 1) * Math.PI) / 5), (float)Math.Sin(((2 * i + 1) * Math.PI) / 5), -0.5f);
                ico[4 * i + 3] = new Triangle(t0, t1, t2);

                icoEdge[4 * i] = Subdivide(ico[4 * i], numSubs);
                icoEdge[4 * i+1] = Subdivide(ico[4 * i + 1], numSubs);
                icoEdge[4 * i + 2] = Subdivide(ico[4 * i + 2], numSubs);
                icoEdge[4 * i + 3] = Subdivide(ico[4 * i + 3], numSubs);

                //Ignore index hell. It's not worth it. This assigns the neighbors of all the edges since subdivide only does a face at a time
                //Optimization comes later if we need it. Considering that I can render a face in a few seconds, I don't think it'll be critical.
                for(int j = 0; j < icoEdge[0].Length/3; j++)
                {
                    int edgeSize = icoEdge[0].Length / 3;

                    //
                    icoEdge[4 * i][j].neighbor0(icoEdge[4 * i + 1][edgeSize - j - 1]);
                    icoEdge[4 * i + 1][edgeSize - j - 1].neighbor0(icoEdge[4 * i][j]);

                    icoEdge[4 * i + 1][2 * edgeSize + j].neighbor2(icoEdge[4 * i + 2][(icoEdge[0].Length - 1) - j]);
                    icoEdge[4 * i + 2][(icoEdge[0].Length - 1) - j].neighbor2(icoEdge[4 * i + 1][2 * edgeSize + j]);

                    icoEdge[4 * i + 2][j].neighbor0(icoEdge[4 * i + 3][edgeSize - j - 1]);
                    icoEdge[4 * i + 3][edgeSize - j - 1].neighbor0(icoEdge[4 * i + 2][j]);

                    if (i != 0)
                    {
                        //icoEdge[4*i-4] is the previous parallelogram

                        //Top seam
                        icoEdge[4 * i][(icoEdge[0].Length - 1) - j].neighbor2(icoEdge[4 * i - 4][edgeSize + j]);
                        icoEdge[4 * i - 4][edgeSize + j].neighbor1(icoEdge[4 * i][(icoEdge[0].Length - 1) - j]);
                        //Middle seam
                        icoEdge[4 * i + 1][(2 * edgeSize - 1) - j].neighbor1(icoEdge[4 * i - 2][edgeSize + j]);
                        icoEdge[4 * i - 2][edgeSize + j].neighbor1(icoEdge[4 * i + 1][(2 * edgeSize - 1) - j]);
                        //Bottom seam
                        icoEdge[4 * i + 3][edgeSize + j].neighbor1(icoEdge[4 * i - 1][(icoEdge[0].Length - 1) - j]);
                        icoEdge[4 * i - 1][(icoEdge[0].Length - 1) - j].neighbor2(icoEdge[4 * i + 3][edgeSize + j]);

                    }
                    if (i == 4)
                    {
                        //Top seam
                        icoEdge[16][edgeSize + j].neighbor1(icoEdge[0][(icoEdge[0].Length - 1) - j]);
                        icoEdge[0][(icoEdge[0].Length - 1) - j].neighbor2(icoEdge[16][edgeSize + j]);
                        //Middle seam
                        icoEdge[18][2 * edgeSize - 1 - j].neighbor1(icoEdge[1][edgeSize + j]);
                        icoEdge[1][edgeSize + j].neighbor1(icoEdge[18][2 * edgeSize - 1 - j]);
                        //Bottom seam
                        icoEdge[19][(icoEdge[0].Length - 1) - j].neighbor2(icoEdge[3][edgeSize + j]);
                        icoEdge[3][edgeSize + j].neighbor1(icoEdge[19][(icoEdge[0].Length - 1) - j]);
                    }
                }


            }
            //Now everthing should be built for the traingles


            //Convert to hexagons
            hexList = HexConvert(icoEdge);
            for(int i = 0; i<hexList.Length; i++)
            {
                hexList[i].project();
            }

            this.window = window;

            window.Load += Window_Load;
            window.UpdateFrame += Window_UpdateFrame;
            window.RenderFrame += Window_RenderFrame;
            window.Closing += Window_Closing;
            


        }

        private void Window_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.LightSkyBlue);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-(window.Width / window.Height), -(window.Width / window.Height), -1, 1, -1, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Scale(-1.0f, 1.0f, 1.0f);
            GL.Rotate(180, 0.0f, 0.0f, 1.0f);
        }

        private void Window_UpdateFrame(object sender, FrameEventArgs e)
        {
            
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Color c;
            int dex = Triangular((int)Math.Pow(2, numSubs)) - 1;
            int dex2 = Triangular((int)Math.Pow(2, numSubs)-1);
            for (int i = 0; i < hexList.Length; i++)
            {
                if (i == count)
                {
                    c = Color.Red;
                }
                else if (hexList[i].tile==null)
                {
                    c = Color.Black;
                }
                else
                {
                    c = hexList[i].tile.getColor();
                }
                if (hexList[i].isProj())
                {
                    drawProj(hexList[i], c);
                }
                
            }
            count++;
            if (count >= hexList.Length)
            {
                count %= hexList.Length;
            }
            GL.Flush();
            window.SwapBuffers();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private int Triangular(int tri)
        {
            return (tri + 1) * tri / 2;
        }

        //Like lerping, but on a sphere!
        private Vector3 Slerp(Vector3 p0, Vector3 p1, float t)
        {
            //So check the wikipedia article on slerping
            Vector3 temp0 = new Vector3(p0.X, p0.Y, p0.Z);
            Vector3 temp1 = new Vector3(p1.X, p1.Y, p1.Z);
            temp0.Normalize();
            temp1.Normalize();
            float omega = (float) Math.Acos(Vector3.Dot(temp0,temp1));
            float scale0 = (float)(Math.Sin((1.0f - t) * omega) / Math.Sin(omega));
            float scale1 = (float)(Math.Sin(t * omega) / Math.Sin(omega));
            temp0.X = p0.X;
            temp0.Y = p0.Y;
            temp0.Z = p0.Z;
            temp1.X = p1.X;
            temp1.Y = p1.Y;
            temp1.Z = p1.Z;
            p0 = Vector3.Multiply(temp0, scale0);
            p1 = Vector3.Multiply(temp1, scale1);
            Vector3 res = Vector3.Add(p0, p1);
            return res;
        }

        private Triangle[] Subdivide(Triangle t, int sub)
        {
            //Split triangle
            Vector3 p01 = Slerp(t.t0,t.t1, 0.5f);
            Vector3 p12 = Slerp(t.t1, t.t2, 0.5f);
            Vector3 p20 = Slerp(t.t2, t.t0,0.5f);
            Triangle t0 = new Triangle(t.t0,p01,p20);
            Triangle t1 = new Triangle(p01, t.t1, p12);
            Triangle t2 = new Triangle(p20, p12, t.t2);
            t = new Triangle(p12, p20, p01);
            //Basis Case
            if (sub == 1)
            {
                t.neighbor0(t0);
                t.neighbor1(t1);
                t.neighbor2(t2);
                t0.neighbor0(t);
                t1.neighbor1(t);
                t2.neighbor2(t);
                Triangle[] e = {t1, t2, t2, t0, t0, t1};
                return e;
            }
            else
            {

                Triangle[] e = Subdivide(t, sub - 1);
                Triangle[] e0 = Subdivide(t0, sub - 1);
                Triangle[] e1 = Subdivide(t1, sub - 1);
                Triangle[] e2 = Subdivide(t2, sub - 1);


                int third = e.Length / 3;

                //Assign neighbors
                for (int i = 0; i<third; i++)
                {
                    e[third - i - 1].neighbor0(e0[i]);
                    e0[i].neighbor0(e[third - i - 1]) ;
                    e[(2 * third) - i - 1].neighbor1(e1[third + i]);
                    e1[third + i].neighbor1(e[(2 * third) - i - 1]);
                    e[(3 * third) - i - 1].neighbor2(e2[(2 * third) + i]);
                    e2[(2 * third) + i].neighbor2(e[(3 * third) - i - 1]);
                }

                //return new edge list
                Triangle[] next = new Triangle[6*third];
                for(int i = 0; i<next.Length; i++)
                {
                    if (i<third)
                    {
                        next[i] = e1[i];
                    }
                    else if (i >= third && i < (3 * third))
                    {
                        next[i] = e2[i-third];
                    }
                    else if (i >= (3 * third) && i < (5 * third))
                    {
                        next[i] = e0[i - (2 * third)];
                    }
                    else
                    {
                        next[i] = e1[i - (3 * third)];
                    }
                    
                }

                return next;
            }
        }

        Triangle[] GetFace(Triangle t)
        {
            int size = (int)Math.Pow(4,numSubs);
            Triangle[] face = new Triangle[size];
            int index = 0;
            face[index++] = t;
            Triangle next = t.n1;
            Triangle branch;
            
            while (next != null)
            {
                face[index++] = next;
                branch = next.n2;
                face[index++] = branch;
                while (branch.n1 != null)
                {
                    branch = branch.n1;
                    face[index++] = branch;
                    branch = branch.n2;
                    face[index++] = branch;
                }
                next = next.n0;
                face[index++] = next;
                next = next.n1;
            }
            return face;
        }
        
        private Hexagon[] HexConvert (Triangle[][] faces)
        {
            int faceLen = faces[0].Length / 3;
            int edgeLen = (int)Math.Pow(2, numSubs) - 1;
            int tri = (edgeLen-1) * (edgeLen) / 2;
            int hexnum = 30 * edgeLen + 20 * tri;
            Hexagon[] sphere = new Hexagon[hexnum];
            Pentagon[] verts = new Pentagon[12];
            int dex = 0;
            int hexDex = 0;
            verts[dex++] = new Pentagon(faces[0][2 * faceLen].mid(),
                    faces[0][2 * faceLen].n1.mid(),
                    faces[0][2 * faceLen].n1.n1.mid(),
                    faces[0][2 * faceLen].n1.n1.n1.mid(),
                    faces[0][2 * faceLen].n1.n1.n1.n1.mid());
            verts[dex++] = new Pentagon(faces[3][2 * faceLen].mid(),
                    faces[3][2 * faceLen].n1.mid(),
                    faces[3][2 * faceLen].n1.n1.mid(),
                    faces[3][2 * faceLen].n1.n1.n1.mid(),
                    faces[3][2 * faceLen].n1.n1.n1.n1.mid());
            for (int i = 1; i < 18; i+=3)
            {
                verts[dex++] = new Pentagon(faces[i][0].mid(),
                    faces[i][0].n1.mid(),
                    faces[i][0].n1.n1.mid(),
                    faces[i][0].n1.n1.n1.mid(),
                    faces[i][0].n1.n1.n1.n1.mid());
                i++;
                verts[dex++] = new Pentagon(faces[i][0].mid(),
                    faces[i][0].n1.mid(),
                    faces[i][0].n1.n1.mid(),
                    faces[i][0].n1.n1.n1.mid(),
                    faces[i][0].n1.n1.n1.n1.mid());
            }
            for (int i = 0; i<20; i++)
            {
                if (i % 2 == 0)
                {
                    Triangle anchor = faces[i][2 * faceLen];
                    for (int j = 0; j < edgeLen; j++) {
                        int rowLen = edgeLen + 1 - j;
                        Triangle cursor = anchor;
                        
                        for (int k = 0; k < rowLen; k++)
                        {
                            if (k == 0 && i % 4 == 0)
                            {
                                sphere[hexDex++] = new Hexagon(cursor.mid(),
                                    cursor.n0.mid(),
                                    cursor.n0.n2.mid(),
                                    cursor.n0.n2.n1.mid(),
                                    cursor.n0.n2.n1.n1.mid(),
                                    cursor.n0.n2.n1.n1.n0.mid());
                            }
                            else
                            {
                                sphere[hexDex++] = new Hexagon(cursor.mid(),
                                        cursor.n0.mid(),
                                        cursor.n0.n2.mid(),
                                        cursor.n0.n2.n1.mid(),
                                        cursor.n0.n2.n1.n0.mid(),
                                        cursor.n0.n2.n1.n0.n2.mid());
                            }
                            cursor = cursor.n0.n1;
                        }
                        anchor = anchor.n0.n2;
                    }
                }
                else
                {
                    Triangle anchor = faces[i][2 * faceLen].n0;
                    for (int j = 0; j < edgeLen; j++)
                    {
                        int rowLen = j + 1;
                        Triangle cursor = anchor;

                        for (int k = 0; k < rowLen; k++)
                        {
                            if (k == 0 && i % 4 == 3)
                            {
                                sphere[hexDex++] = new Hexagon(cursor.mid(),
                                    cursor.n1.mid(),
                                    cursor.n1.n2.mid(),
                                    cursor.n1.n2.n2.mid(),
                                    cursor.n1.n2.n2.n0.mid(),
                                    cursor.n1.n2.n2.n0.n1.mid());
                            }
                            else
                            {
                                sphere[hexDex++] = new Hexagon(cursor.mid(),
                                        cursor.n1.mid(),
                                        cursor.n1.n2.mid(),
                                        cursor.n1.n2.n0.mid(),
                                        cursor.n1.n2.n0.n1.mid(),
                                        cursor.n1.n2.n0.n1.n2.mid());
                            }
                            cursor = cursor.n2.n1;
                        }
                        anchor = anchor.n1.n0;
                    }
                }

            }
            return sphere;
        }

        void drawTriangle(Triangle t, Color c)
        {
            GL.Begin(BeginMode.Polygon);
                GL.Color3(c);
                GL.Vertex3(t.t0.X, t.t0.Y, t.t0.Z);
                GL.Vertex3(t.t1.X, t.t1.Y, t.t1.Z);
                GL.Vertex3(t.t2.X, t.t2.Y, t.t2.Z);
            GL.End();
        }

        void drawHexagon(Hexagon h, Color c)
        {
            GL.Begin(BeginMode.Polygon);
            GL.Color3(c);
            GL.Vertex3(h.points[0].X, h.points[0].Y, h.points[0].Z);
            GL.Vertex3(h.points[1].X, h.points[1].Y, h.points[1].Z);
            GL.Vertex3(h.points[2].X, h.points[2].Y, h.points[2].Z);
            GL.Vertex3(h.points[3].X, h.points[3].Y, h.points[3].Z);
            GL.Vertex3(h.points[4].X, h.points[4].Y, h.points[4].Z);
            GL.Vertex3(h.points[5].X, h.points[5].Y, h.points[5].Z);
            GL.End();
        }

        void drawProj(Hexagon h, Color c)
        {

            if (!h.isEdge)
            {
                GL.Begin(BeginMode.Polygon);
                GL.Color3(c);
                GL.Vertex2(h.equiVec[0].X, h.equiVec[0].Y);
                GL.Vertex2(h.equiVec[1].X, h.equiVec[1].Y);
                GL.Vertex2(h.equiVec[2].X, h.equiVec[2].Y);
                GL.Vertex2(h.equiVec[3].X, h.equiVec[3].Y);
                GL.Vertex2(h.equiVec[4].X, h.equiVec[4].Y);
                GL.Vertex2(h.equiVec[5].X, h.equiVec[5].Y);
                GL.End();
            }
            else
            {
                GL.Begin(BeginMode.Polygon);
                GL.Color3(c);
                for (int i = 0; i < 6; i++)
                {
                    if (h.equiVec[i].X <= 0)
                    {
                        GL.Vertex2(h.equiVec[i].X + 2.0f, h.equiVec[i].Y);
                    }
                    else
                    {
                        GL.Vertex2(h.equiVec[i].X, h.equiVec[i].Y);
                    }
                }
                GL.End();

                GL.Begin(BeginMode.Polygon);
                GL.Color3(c);
                for (int i = 0; i < 6; i++)
                {
                    if (h.equiVec[i].X >= 0)
                    {
                        GL.Vertex2(h.equiVec[i].X - 2.0f, h.equiVec[i].Y);
                    }
                    else
                    {
                        GL.Vertex2(h.equiVec[i].X, h.equiVec[i].Y);
                    }
                }
                GL.End();
            }
        }
        public void LoadGrid(GeoGrid g)
        {
            int edgeLen = (int)Math.Pow(2, numSubs);
            //Number of hexagons on an even face
            int even = Triangular(edgeLen) - 1;
            //Number of hexagons on an odd face
            int odd = Triangular(edgeLen - 1);
            int hexDex = 0;
            //This loop assigns the display hexagons to an index in the data representation
            //While there's five parallelograms, I end up doing the same thing twice in each one, so I did some simple integer division trickery.
            //Hopefully it doesn't fuck me in the butt down the road.

            //I'm down the road and pretty sure I'm being fucked in the butt

            System.Console.WriteLine("HexLen: " + hexList.Length);
            System.Console.WriteLine("Even: " + even);
            System.Console.WriteLine("Odd: " + odd);
            for (int par = 0; par<10; par++)
            {
                int start = (par % 2) * edgeLen;
                for (int col = 1; col<edgeLen; col++)
                {
                    for (int row = 0; row <= edgeLen - col; row++)
                    {
                        hexList[hexDex++].tile = g.getTile(par/2,row,col+start);
                        //hexDex++;
                    }
                }
                for (int row = edgeLen - 1; row > 0; row--)
                {
                    int iter = 0;
                    for (int col = edgeLen; col > row; col--)
                    {
                        hexList[hexDex++].tile = g.getTile(par/2, row + iter, col + start);
                        iter++;
                    }
                }
            }

        }
    }
}
