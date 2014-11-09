using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;

namespace MyManagedDirectX.Data.Geometry
{
    /// <summary>
    /// 平行多边形柱体对象，要求柱体的顶和底一定是平面且跟坐标面平行，且顶和底二维坐标完全一致。
    /// </summary>
    public class D3DParallelGengonGeometry: ID3DGeometry
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

        private Vector3 _3DViewBoundsMaxPoint = new Vector3(float.MinValue, float.MinValue, float.MinValue);

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
        private int _vertexFacePointsCount = 0;

        private int _vertexTopPointsCount = 0;

        private int _vertexBottomPointsCount = 0;

        public Color Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private List<PointF> _worldPoints = new List<PointF>();

        public float Bottom { get; set; }

        public float Top { get; set; }

        #endregion

        #region Fields

        private VertexBuffer vertexBufferFace;

        private VertexBuffer vertexBufferTop;

        private VertexBuffer vertexBufferBottom;


        #endregion

        public D3DParallelGengonGeometry(List<PointF> worldPoints, float top, float bottom)
        {
            Color = Color.Green;

            foreach (var item in worldPoints)
            {
                this._worldPoints.Add(item);
            }

            this.Top = top;
            this.Bottom = bottom;

            ComputeWorldViewBounds();

            this._vertexFacePointsCount = this._worldPoints.Count * 2;
            this._vertexTopPointsCount = this._vertexBottomPointsCount = (this._worldPoints.Count - 2) * 3;
        }

        public void SetTopBottom(float top, float bottom)
        {
            this.Top = top;
            this.Bottom = bottom;

            ComputeWorldViewBounds();
        }

        /// <summary>
        /// 地理坐标的Y作为三维坐标中的Z，地理坐标中的Z作为三维坐标中的Y。
        /// </summary>
        private void ComputeWorldViewBounds()
        {
            this._3DViewBoundsMaxPoint.Y = this.Top;
            this._3DViewBoundsMinPoint.Y = this.Bottom;

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
                if (item.Y < this._3DViewBoundsMinPoint.Z)
                {
                    this._3DViewBoundsMinPoint.Z = item.Y;
                }
                if (item.Y > this._3DViewBoundsMaxPoint.Z)
                {
                    this._3DViewBoundsMaxPoint.Z = item.Y;
                }
            }
        }

        private void CreateFaceVertexBuffer(Device device)
        {
            if (vertexBufferFace == null)
            {
                vertexBufferFace = new VertexBuffer(typeof(CustomVertex.PositionColored), _vertexFacePointsCount, device, Usage.WriteOnly, CustomVertex.PositionColored.Format, Pool.Default);
            }

            CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vertexBufferFace.Lock(0, 0);

            for (int i = 0; i < this._worldPoints.Count; i++)
            {
                verts[2 * i].Position = new Vector3(this._worldPoints[i].X, this.Bottom, this._worldPoints[i].Y);
                verts[2 * i].Color = this.Color.ToArgb();
                verts[2 * i + 1].Position = new Vector3(this._worldPoints[i].X, this.Top, this._worldPoints[i].Y);
                verts[2 * i + 1].Color = this.Color.ToArgb();
            }

            vertexBufferFace.Unlock();
        }

        private void CreateTopVertexBuffer(Device device)
        {
            if (vertexBufferTop == null)
            {
                vertexBufferTop = new VertexBuffer(typeof(CustomVertex.PositionColored), _vertexTopPointsCount, device, Usage.WriteOnly, CustomVertex.PositionColored.Format, Pool.Default);
            }

            CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vertexBufferTop.Lock(0, 0);

            CreateHorizontalVertex(verts, this.Top, Color.LightGreen.ToArgb());

            vertexBufferTop.Unlock();
        }

        private void CreateBottomVertexBuffer(Device device)
        {
            if (vertexBufferBottom == null)
            {
                vertexBufferBottom = new VertexBuffer(typeof(CustomVertex.PositionColored), _vertexTopPointsCount, device, Usage.WriteOnly, CustomVertex.PositionColored.Format, Pool.Default);
            }

            CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vertexBufferBottom.Lock(0, 0);

            CreateHorizontalVertex(verts, this.Bottom, Color.DarkGreen.ToArgb());

            vertexBufferBottom.Unlock();
        }

        private void CreateHorizontalVertex(CustomVertex.PositionColored[] verts, float horizontalValue, int colorToArgb)
        {
            int indexVerts = 0;

            int triangleCount = this._worldPoints.Count - 2;
            for (int i = 0; i < triangleCount; i++)
            {
                //每个三角形都已第一个点为起始
                verts[indexVerts].Position = new Vector3(this._worldPoints[0].X, horizontalValue, this._worldPoints[0].Y);
                verts[indexVerts].Color = colorToArgb;
                indexVerts++;

                //每二个点
                verts[indexVerts].Position = new Vector3(this._worldPoints[i + 1].X, horizontalValue, this._worldPoints[i + 1].Y);
                verts[indexVerts].Color = colorToArgb;
                indexVerts++;

                //每三个点
                verts[indexVerts].Position = new Vector3(this._worldPoints[i + 2].X, horizontalValue, this._worldPoints[i + 2].Y);
                verts[indexVerts].Color = colorToArgb;
                indexVerts++;

            }
        }

        public void CreateVertexBuffer(Device device)
        {
            CreateFaceVertexBuffer(device);
            CreateTopVertexBuffer(device);
            CreateBottomVertexBuffer(device);
        }

        public void Render(Device device)
        {
            Material mtrl = new Material();
            mtrl.Ambient = this.Color;
            mtrl.Diffuse = this.Color;
            mtrl.Emissive = this.Color;
            mtrl.Specular = this.Color;

            if (vertexBufferFace != null)
            {
                device.Material = mtrl;
                device.SetStreamSource(0, vertexBufferFace, 0);
                device.VertexFormat = CustomVertex.PositionColored.Format;

                device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, _vertexFacePointsCount - 2);
            }
            if (vertexBufferTop != null)
            {
                device.Material = mtrl;
                device.SetStreamSource(0, vertexBufferTop, 0);
                device.VertexFormat = CustomVertex.PositionColored.Format;

                device.DrawPrimitives(PrimitiveType.TriangleList, 0, this._worldPoints.Count - 2);
            }
            if (vertexBufferBottom != null)
            {
                device.Material = mtrl;
                device.SetStreamSource(0, vertexBufferBottom, 0);
                device.VertexFormat = CustomVertex.PositionColored.Format;

                device.DrawPrimitives(PrimitiveType.TriangleList, 0, this._worldPoints.Count - 2);
            }
        }

        public void Dispose()
        {
            if (vertexBufferFace != null)
            {
                vertexBufferFace.Dispose();
                vertexBufferFace = null;

                this._worldPoints.Clear();
            }
            if (vertexBufferTop != null)
            {
                vertexBufferTop.Dispose();
                vertexBufferTop = null;
            }
            if (vertexBufferBottom != null)
            {
                vertexBufferBottom.Dispose();
                vertexBufferBottom = null;
            }
        }

    }
}
