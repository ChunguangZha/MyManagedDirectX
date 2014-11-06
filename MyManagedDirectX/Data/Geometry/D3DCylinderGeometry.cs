using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using Microsoft.DirectX;

namespace MyManagedDirectX.Data.Geometry
{
    /// <summary>
    /// 圆柱体（包含空心和实心）
    /// </summary>
    public class D3DCylinderGeometry : ID3DGeometry
    {
        #region Properties

        #region World View Bounds

        private Vector3 _3DViewBoundsMinPoint = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

        /// <summary>
        /// 世界视图范围最小边界
        /// </summary>
        public Vector3 ThreeDViewBoundsMinPoint
        {
            get { return _3DViewBoundsMinPoint; }
        }

        public Vector3 _3DViewBoundsMaxPoint = new Vector3(float.MinValue, float.MinValue, float.MinValue);

        /// <summary>
        /// 世界视界范围最大边界
        /// </summary>
        public Vector3 ThreeDViewBoundsMaxPoint
        {
            get { return _3DViewBoundsMaxPoint; }
        }

        #endregion

        /// <summary>
        /// 绘制几何对象时的三维顶点集合的点个数，不是几何对象的点个数
        /// </summary>
        private int _vertexPointsCount = 0;

        public Color Color { get; set; }

        /// <summary>
        /// 世界坐标点集合，Z值表示高值。
        /// </summary>
        private List<Vector3> _worldPoints;

        public float Radius { get; private set; }

        #endregion

        #region Fields

        /// <summary>
        /// 3D坐标，Y值表示高值。
        /// </summary>
        private VertexBuffer vertexBuffer;

        /// <summary>
        /// 多段圆柱体，分段绘制
        /// </summary>
        private List<VertexBuffer> listSurfaceBuffer = new List<VertexBuffer>();

        /// <summary>
        /// 将环形表面分成若干多边形，例如该值为50时，表示分成49边形。
        /// </summary>
        private const int CYLINDERFACEPOINTCOUNT = 50;

        #endregion

        /// <summary>
        /// 与(-1,0,0),(1,0,0)平行
        /// </summary>
        /// <param name="worldPoints"></param>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        public D3DCylinderGeometry(List<Vector3> worldPoints, float radius, Color color)
        {
            this._worldPoints = worldPoints;
            this.Radius = radius;
            this.Color = color;

            ComputeWorldViewBounds();

            this._vertexPointsCount = this._worldPoints.Count * CYLINDERFACEPOINTCOUNT;
        }

        /// <summary>
        /// 地理坐标的Y作为三维坐标中的Z，地理坐标中的Z作为三维坐标中的Y。
        /// </summary>
        private void ComputeWorldViewBounds()
        {
            foreach (var item in this._worldPoints)
            {
                if (item.X < this._3DViewBoundsMinPoint.X)
                {
                    this._3DViewBoundsMinPoint.X = item.X;
                }
                if (item.X > this._3DViewBoundsMaxPoint.X)
                {
                    this._3DViewBoundsMaxPoint.X = item.X;
                }

                float minWorldY = item.Y - Radius;
                if (minWorldY < this._3DViewBoundsMinPoint.Z)
                {
                    this._3DViewBoundsMinPoint.Z = minWorldY;
                }
                float maxWorldY = item.Y + Radius;
                if (maxWorldY > this._3DViewBoundsMaxPoint.Z)
                {
                    this._3DViewBoundsMaxPoint.Z = maxWorldY;
                }

                float minWorldZ = item.Z - Radius;
                if (minWorldZ < this._3DViewBoundsMinPoint.Y)
                {
                    this._3DViewBoundsMinPoint.Y = minWorldZ;
                }
                float maxWorldZ = item.Z + Radius;
                if (maxWorldZ > this._3DViewBoundsMaxPoint.Y)
                {
                    this._3DViewBoundsMaxPoint.Y = maxWorldZ;
                }
            }
        }

        public void CreateVertexBuffer(Device device)
        {
            if (vertexBuffer == null)
            {
                vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), _vertexPointsCount, device, Usage.SoftwareProcessing, CustomVertex.PositionColored.Format, Pool.Default);
            }
            if (this._worldPoints.Count < 2)
            {
                return;
            }

            CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vertexBuffer.Lock(0, 0);

            for (int i = 0; i < this._worldPoints.Count - 1; i++)
            {
                for (int j = 0; j < CYLINDERFACEPOINTCOUNT; j++)
                {
                    float theta = (float)(2 * Math.PI * j) / (CYLINDERFACEPOINTCOUNT - 1);

                    Vector3 position1 = new Vector3(0, (float)Math.Cos(theta) * Radius, (float)Math.Sin(theta) * Radius);
                    position1.Add(new Vector3(this._worldPoints[i].X, this._worldPoints[i].Z, this._worldPoints[i].Y));

                    verts[2 * j].Position = position1;
                    verts[2 * j].Color = this.Color.ToArgb();

                    Vector3 position2 = new Vector3(0, (float)Math.Cos(theta) * Radius, (float)Math.Sin(theta) * Radius);
                    position2.Add(new Vector3(this._worldPoints[i + 1].X, this._worldPoints[i + 1].Z, this._worldPoints[i + 1].Y));

                    verts[2 * j + 1].Position = position2;
                    verts[2 * j + 1].Color = this.Color.ToArgb();
                }
            }


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

            vertexBuffer.Unlock();
        }

        private void ComputeYaw(float x1, float y1, float x2, float y2)
        {

        }

        public void Render(Device device)
        {
            if (vertexBuffer != null)
            {
                Material mtrl = new Material();
                mtrl.Ambient = this.Color;
                mtrl.Diffuse = this.Color;
                mtrl.Emissive = this.Color;
                mtrl.Specular = this.Color;

                device.Material = mtrl;
                device.SetStreamSource(0, vertexBuffer, 0);
                device.VertexFormat = CustomVertex.PositionColored.Format;

                device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, _vertexPointsCount - 2);
            }
        }

        public void Dispose()
        {
            if (vertexBuffer != null)
            {
                vertexBuffer.Dispose();
                vertexBuffer = null;

                this._worldPoints.Clear();
            }
        }

    }
}
