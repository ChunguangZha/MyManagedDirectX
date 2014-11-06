using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;

namespace MyManagedDirectX
{
    public partial class TestForm : Form
    {
        Device device = null;

        VertexBuffer vertexBuffer = null;

        CustomVertex.TransformedColored[] verts = null, verts1 = null;

        float Angle = 0, ViewZ = -6f;

        IndexBuffer indexBuffer = null;

        public TestForm()
        {
            InitializeComponent();

            InitializeGraphics();
        }

        public bool InitializeGraphics()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                presentParams.EnableAutoDepthStencil = true;
                presentParams.AutoDepthStencilFormat = DepthFormat.D16;

                device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams);
                device.DeviceReset += new EventHandler(OnResetDevice);
                this.OnCreateDevice(device, null);
                this.OnResetDevice(device, null);
                return true;
            }
            catch (Direct3DXException)
            {
                return false;
            }
        }

        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;
            vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), 100, dev, Usage.WriteOnly, CustomVertex.PositionColored.Format, Pool.Default);
            indexBuffer = new IndexBuffer(typeof(int), 36, dev, 0, Pool.Default);

            vertexBuffer.Created += new EventHandler(OnCreateVertexBuffer);
            indexBuffer.Created += new EventHandler(indexBuffer_Created);
            this.OnCreateVertexBuffer(vertexBuffer, null);
            this.indexBuffer_Created(indexBuffer, null);

            //verts = new CustomVertex.TransformedColored[6];

            //verts[0].Position = new Microsoft.DirectX.Vector4(10f, 10f, 0.5f, 1.0f);
            //verts[0].Color = Color.Aqua.ToArgb();
            //verts[1].Position = new Microsoft.DirectX.Vector4(210f, 10f, 0.5f, 1.0f);
            //verts[1].Color = Color.Brown.ToArgb();
            //verts[2].Position = new Microsoft.DirectX.Vector4(110f, 60f, 0.5f, 1.0f);
            //verts[2].Color = Color.LightPink.ToArgb();
            //verts[3].Position = new Microsoft.DirectX.Vector4(210f, 210f, 0.5f, 1.0f);
            //verts[3].Color = Color.Aqua.ToArgb();
            //verts[4].Position = new Microsoft.DirectX.Vector4(110f, 160f, 0.5f, 1.0f);
            //verts[4].Color = Color.Brown.ToArgb();
            //verts[5].Position = new Microsoft.DirectX.Vector4(10f, 210f, 0.5f, 1.0f);
            //verts[5].Color = Color.LightPink.ToArgb();
        }

        void indexBuffer_Created(object sender, EventArgs e)
        {
            int[] index = {
                              4,5,6,
                              5,7,6,
                              5,1,7,
                              7,1,3,
                              4,0,1,
                              4,1,5,
                              2,0,4,
                              2,4,6,
                              3,1,0,
                              3,0,2,
                              2,6,7,
                              2,7,3
                          };
            int[] indexV = (int[])indexBuffer.Lock(0, 0);

            for (int i = 0; i < 36; i++)
            {
                indexV[i] = index[i];
            }

            indexBuffer.Unlock();
        }

        void OnCreateVertexBuffer(object sender, EventArgs e)
        {
            CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vertexBuffer.Lock(0, 0);

            //verts[0].Position = new Vector3(0f, 0f, 0f);
            //verts[0].Color = Color.Red.ToArgb();
            //verts[1].Position = new Vector3(0f, 2f, 0f);
            //verts[1].Color = Color.Green.ToArgb();
            //verts[2].Position = new Vector3(1f, 0f, 0f);
            //verts[2].Color = Color.Yellow.ToArgb();
            //verts[3].Position = new Vector3(3f, 3f, 0f);
            //verts[3].Color = Color.Pink.ToArgb();
            //verts[4].Position = new Vector3(4f, 0f, 0f);
            //verts[4].Color = Color.Gray.ToArgb();
            //verts[5].Position = new Vector3(7f, 2f, 0f);
            //verts[5].Color = Color.Gold.ToArgb();

            for (int i = 0; i < 50; i++)
            {
                float theta = (float)(2 * Math.PI * i) / 49;
                verts[2 * i].Position = new Vector3((float)Math.Sin(theta), -1, (float)Math.Cos(theta));
                verts[2 * i].Color = Color.Blue.ToArgb();
                verts[2 * i + 1].Position = new Vector3((float)Math.Sin(theta), 1, (float)Math.Cos(theta));
                verts[2 * i + 1].Color = Color.Green.ToArgb();
            }

            //verts[0].Position = new Microsoft.DirectX.Vector3(-1f, 1f, 1f);
            //verts[0].Color = Color.Blue.ToArgb();
            //verts[1].Position = new Microsoft.DirectX.Vector3(1f, 1f, 1f);
            //verts[1].Color = Color.Red.ToArgb();
            //verts[2].Position = new Microsoft.DirectX.Vector3(-1f, -1f, 1f);
            //verts[2].Color = Color.Green.ToArgb();
            //verts[3].Position = new Microsoft.DirectX.Vector3(1f, -1f, 1f);
            //verts[3].Color = Color.Yellow.ToArgb();

            //verts[4].Position = new Microsoft.DirectX.Vector3(-1f, 1f, -1f);
            //verts[4].Color = Color.Blue.ToArgb();
            //verts[5].Position = new Microsoft.DirectX.Vector3(1f, 1f, -1f);
            //verts[5].Color = Color.Red.ToArgb();
            //verts[6].Position = new Microsoft.DirectX.Vector3(-1f, -1f, -1f);
            //verts[6].Color = Color.Green.ToArgb();
            //verts[7].Position = new Microsoft.DirectX.Vector3(1f, -1f, -1f);
            //verts[7].Color = Color.Yellow.ToArgb();

            //verts[8].Position = new Microsoft.DirectX.Vector3(-2f, -2f, -2f);
            //verts[8].Color = Color.Yellow.ToArgb();
            //verts[9].Position = new Microsoft.DirectX.Vector3(-2f, -2f, 2f);
            //verts[9].Color = Color.Yellow.ToArgb();
            //verts[10].Position = new Microsoft.DirectX.Vector3(2f, -2f, 2f);
            //verts[10].Color = Color.Yellow.ToArgb();
            //verts[11].Position = new Microsoft.DirectX.Vector3(-2f, -2f, -2f);
            //verts[11].Color = Color.Yellow.ToArgb();
            //verts[12].Position = new Microsoft.DirectX.Vector3(2f, -2f, 2f);
            //verts[12].Color = Color.Yellow.ToArgb();
            //verts[13].Position = new Microsoft.DirectX.Vector3(2f, -2f, -2f);
            //verts[13].Color = Color.Yellow.ToArgb();

            //verts[14].Position = new Microsoft.DirectX.Vector3(-2f, -2f, 2f);
            //verts[14].Color = Color.Yellow.ToArgb();
            //verts[15].Position = new Microsoft.DirectX.Vector3(-2f, 2f, 2f);
            //verts[15].Color = Color.Yellow.ToArgb();
            //verts[16].Position = new Microsoft.DirectX.Vector3(2f, 2f, 2f);
            //verts[16].Color = Color.Yellow.ToArgb();
            //verts[17].Position = new Microsoft.DirectX.Vector3(-2f, -2f, 2f);
            //verts[17].Color = Color.Yellow.ToArgb();
            //verts[18].Position = new Microsoft.DirectX.Vector3(2f, 2f, 2f);
            //verts[18].Color = Color.Yellow.ToArgb();
            //verts[19].Position = new Microsoft.DirectX.Vector3(2f, -2f, 2f);
            //verts[19].Color = Color.Yellow.ToArgb();



            //verts[0].Position = new Microsoft.DirectX.Vector4(100f, 50f, 0.5f, 1f);
            //verts[0].Color = Color.Red.ToArgb();
            //verts[1].Position = new Microsoft.DirectX.Vector4(200f, 50f, 0.5f, 1f);
            //verts[1].Color = Color.Red.ToArgb();
            //verts[2].Position = new Microsoft.DirectX.Vector4(50f, 100f, 0.5f, 1f);
            //verts[2].Color = Color.Red.ToArgb();

            //verts[3].Position = new Microsoft.DirectX.Vector4(50f, 100f, 0.5f, 1f);
            //verts[3].Color = Color.Red.ToArgb();
            //verts[4].Position = new Microsoft.DirectX.Vector4(200f, 50f, 0.5f, 1f);
            //verts[4].Color = Color.Red.ToArgb();
            //verts[5].Position = new Microsoft.DirectX.Vector4(150f, 100f, 0.5f, 1f);
            //verts[5].Color = Color.Red.ToArgb();

            //verts[6].Position = new Microsoft.DirectX.Vector4(50f, 100f, 0.5f, 1f);
            //verts[6].Color = Color.Green.ToArgb();
            //verts[7].Position = new Microsoft.DirectX.Vector4(150f, 100f, 0.5f, 1f);
            //verts[7].Color = Color.Green.ToArgb();
            //verts[8].Position = new Microsoft.DirectX.Vector4(50f, 200f, 0.5f, 1f);
            //verts[8].Color = Color.Green.ToArgb();

            //verts[9].Position = new Microsoft.DirectX.Vector4(50f, 200f, 0.5f, 1f);
            //verts[9].Color = Color.Green.ToArgb();
            //verts[10].Position = new Microsoft.DirectX.Vector4(150f, 100f, 0.5f, 1f);
            //verts[10].Color = Color.Green.ToArgb();
            //verts[11].Position = new Microsoft.DirectX.Vector4(150f, 200f, 0.5f, 1f);
            //verts[11].Color = Color.Green.ToArgb();

            //verts[12].Position = new Microsoft.DirectX.Vector4(150f, 100f, 0.5f, 1f);
            //verts[12].Color = Color.Blue.ToArgb();
            //verts[13].Position = new Microsoft.DirectX.Vector4(200f, 50f, 0.5f, 1f);
            //verts[13].Color = Color.Blue.ToArgb();
            //verts[14].Position = new Microsoft.DirectX.Vector4(200f, 150f, 0.5f, 1f);
            //verts[14].Color = Color.Blue.ToArgb();

            //verts[15].Position = new Microsoft.DirectX.Vector4(150f, 100f, 0.5f, 1f);
            //verts[15].Color = Color.Blue.ToArgb();
            //verts[16].Position = new Microsoft.DirectX.Vector4(200f, 150f, 0.5f, 1f);
            //verts[16].Color = Color.Blue.ToArgb();
            //verts[17].Position = new Microsoft.DirectX.Vector4(150f, 200f, 0.5f, 1f);
            //verts[17].Color = Color.Blue.ToArgb();

            vertexBuffer.Unlock();
        }

        public void OnResetDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;
            dev.RenderState.CullMode = Cull.None;//取消背面剔除
            dev.RenderState.Lighting = false;//取消灯光
            dev.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, 1f, 1f, 100f);
        }

        void Modify(float x1, float y1)
        {
            verts1 = (CustomVertex.TransformedColored[])verts.Clone();

            for (int i = 0; i < 6; i++)
            {
                verts1[i].X += x1;
                verts1[i].Y += y1;
            }
        }

        public void Render()
        {
            if (device == null)
            {
                return;
            }

            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);

            device.BeginScene();

            //device.VertexFormat = CustomVertex.TransformedColored.Format;
            //Modify(1f, 1f);
            //device.DrawUserPrimitives(PrimitiveType.TriangleFan, 5, verts1);
            //Modify(250f, 0f);
            //device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 4, verts1);
            //Modify(500f, 0f);
            //device.DrawUserPrimitives(PrimitiveType.TriangleList, 5, verts1);
            //Modify(0f, 250f);
            //device.DrawUserPrimitives(PrimitiveType.LineList, 5, verts1);
            //Modify(250f, 250f);
            //device.DrawUserPrimitives(PrimitiveType.LineStrip, 5, verts1);
            //Modify(500f, 250f);
            //device.DrawUserPrimitives(PrimitiveType.PointList, 5, verts1);

            //verts1 = null;

            SetupMatrices();//在程序运行期间，Device的三个变换不变，因此放在此处。

            device.SetStreamSource(0, vertexBuffer, 0);
            device.VertexFormat = CustomVertex.PositionColored.Format;

            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 98);

            //device.Indices = indexBuffer;

            //device.Transform.View = Matrix.LookAtLH(new Vector3(0f, 0f, -6f), new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f));

            //device.DrawPrimitives(PrimitiveType.TriangleList, 8, 2);
            //device.DrawPrimitives(PrimitiveType.TriangleList, 14, 2);

            //SetupMatrices();
            //device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 8, 0, 12);

            ////绘制正前面
            //device.Transform.World = Matrix.Translation(0, 0, -1) * Matrix.RotationY(Angle);            
            //device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            ////绘制正后面
            //device.Transform.World = Matrix.RotationY((float)Math.PI) * Matrix.Translation(0, 0, 1) * Matrix.RotationY(Angle);
            //device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            ////绘制右侧面
            //device.Transform.World = Matrix.RotationY(-(float)Math.PI / 2) * Matrix.Translation(1, 0, 0) * Matrix.RotationY(Angle);
            //device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            ////绘制左侧面
            //device.Transform.World = Matrix.RotationY((float)Math.PI / 2) * Matrix.Translation(-1, 0, 0) * Matrix.RotationY(Angle);
            //device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            ////绘制下面
            //device.Transform.World = Matrix.RotationX((float)Math.PI / 2) * Matrix.Translation(0, 1, 0) * Matrix.RotationY(Angle);
            //device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            ////绘制上面
            //device.Transform.World = Matrix.RotationX(-(float)Math.PI / 2) * Matrix.Translation(0, -1, 0) * Matrix.RotationY(Angle);
            //device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            device.EndScene();
            device.Present();
        }

        private void SetupMatrices()
        {
            //int iTime = Environment.TickCount % 1000;
            //Angle = iTime * (2f * (float)Math.PI) / 1000f;

            device.Transform.World = Matrix.RotationY(Angle);

            //device.Transform.World = Matrix.RotationAxis((new Vector3((float)Math.Cos(Environment.TickCount/250f), 1, (float)Math.Sin(Environment.TickCount/250f))), Environment.TickCount/3000f);


            //Vector3 v1 = new Vector3(0f, 0f, -5f);
            //v1.TransformCoordinate(Matrix.RotationYawPitchRoll(Angle, ViewZ, 0));
            device.Transform.View = Matrix.LookAtLH(new Vector3(0f, 3f, ViewZ), new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f));

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.Render();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Angle += 0.1f;
                    break;
                case Keys.Right:
                    Angle -= 0.1f;
                    break;
                case Keys.Down:
                    ViewZ += 0.1f;
                    break;
                case Keys.Up:
                    ViewZ -= 0.1f;
                    break;
                default:
                    break;
            }

            Render();
        }
    }
}
