using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using MyManagedDirectX.Data.Geometry;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace MyManagedDirectX.Data.Dataset
{
    public class D3DBoreBreakStripDataset : ID3DDataset
    {
        #region Properties

        #region World View Bounds

        private Vector3 _3DViewBoundsMinPoint = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

        /// <summary>
        /// 世界视图范围最小边界
        /// </summary>
        public Vector3 ThreeDViewBoundsMinPoint
        {
            get { return new Vector3(); }
        }

        public Vector3 _3DViewBoundsMaxPoint = new Vector3(float.MinValue, float.MinValue, float.MinValue);

        /// <summary>
        /// 世界视界范围最大边界
        /// </summary>
        public Vector3 ThreeDViewBoundsMaxPoint
        {
            get
            {
                Vector3 max = this._3DViewBoundsMaxPoint - this._3DViewBoundsMinPoint;
                max.Scale(1f / this.Scale);
                return max;
            }
        }

        public float Scale
        {
            get
            {
                float maxLengthofSide = Utility.MaxLengthOfSide(this._3DViewBoundsMaxPoint, this._3DViewBoundsMinPoint);
                return maxLengthofSide / DescMaxBounds;
            }
        }

        /// <summary>
        /// 最大目标区宽度，由于真实坐标范围过大，绘制出效果不清，因为将真实地理坐标缩小为以该值为边正方体的范围内。
        /// </summary>
        private float DescMaxBounds = 10f;

        #endregion

        private List<ID3DGeometry> _listGeometries = new List<ID3DGeometry>();

        public List<ID3DGeometry> ListGeometries
        {
            get { return this._listGeometries; }
        }

        public int GeometryCount
        {
            get
            {
                if (_listGeometries == null)
                {
                    return 0;
                }

                return this._listGeometries.Count;
            }
        }

        #endregion


        public void LoadDataFile(string filePath)
        {
            this.ClearAllData();

            FileStream stream = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(stream);

            int geoID = -1;
            bool isFirstLine = true;
            List<PointF> pointList = new List<PointF>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                string[] items = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length != 3)
                {
                    continue;
                }

                float x, y;
                int index;
                if (!float.TryParse(items[0], out x))
                {
                    continue;
                }
                if (!float.TryParse(items[1], out y))
                {
                    continue;
                }
                if (!int.TryParse(items[2], out index))
                {
                    continue;
                }
                if (isFirstLine)
                {
                    isFirstLine = false;

                    geoID = index;
                }

                if (geoID == index)
                {
                    PointF p = new PointF(x, y);
                    if (pointList.Count > 0 && pointList[pointList.Count - 1] == p)
                    {
                        continue;
                    }
                    pointList.Add(p);
                }
                else
                {
                    if (pointList.Count > 2)
                    {
                        D3DParallelGengonGeometry geo = new D3DParallelGengonGeometry(pointList, 1, 0);
                        float high = Utility.DistanceOfTwoVector(geo.ThreeDViewBoundsMaxPoint, geo.ThreeDViewBoundsMinPoint);
                        geo.SetTopBottom((float)Math.Ceiling(high), 0);
                        this._listGeometries.Add(geo);
                    }

                    pointList.Clear();

                    geoID = index;
                    pointList.Add(new PointF(x, y));
                }
            }

            if (pointList.Count > 2)
            {
                D3DParallelGengonGeometry geo = new D3DParallelGengonGeometry(pointList, 1, 0);
                float high = Utility.DistanceOfTwoVector(geo.ThreeDViewBoundsMaxPoint, geo.ThreeDViewBoundsMinPoint);
                geo.SetTopBottom((float)Math.Ceiling(high), 0);
                this._listGeometries.Add(geo);
            }

            pointList.Clear();

            stream.Close();
            stream.Dispose();

            if (this._listGeometries.Count > 0)
            {
                ID3DGeometry firstGeo = this._listGeometries[0];

                float high = Utility.DistanceOfTwoVector(firstGeo.ThreeDViewBoundsMaxPoint, firstGeo.ThreeDViewBoundsMinPoint);

                float x1 = firstGeo.ThreeDViewBoundsMinPoint.X - (high / 10);
                float x2 = firstGeo.ThreeDViewBoundsMaxPoint.X + (high / 10);
                float y = (firstGeo.ThreeDViewBoundsMaxPoint.Z + firstGeo.ThreeDViewBoundsMinPoint.Z) / 2f;
                float z = (firstGeo.ThreeDViewBoundsMaxPoint.Y + firstGeo.ThreeDViewBoundsMinPoint.Y) / 2f;

                List<Vector3> pointList1 = new List<Vector3>();
                pointList1.Add(new Vector3(x1, y, z));
                pointList1.Add(new Vector3(x2, y, z));
                D3DCylinderGeometry geo1 = new D3DCylinderGeometry(pointList1, (high / 20), Color.Red);
                this._listGeometries.Add(geo1);
            }

            ComputeWorldViewBounds();
        }

        private void ComputeWorldViewBounds()
        {
            foreach (var item in this._listGeometries)
            {
                if (item.ThreeDViewBoundsMinPoint.X < this._3DViewBoundsMinPoint.X)
                {
                    this._3DViewBoundsMinPoint.X = item.ThreeDViewBoundsMinPoint.X;
                }
                if (item.ThreeDViewBoundsMaxPoint.X > this._3DViewBoundsMaxPoint.X)
                {
                    this._3DViewBoundsMaxPoint.X = item.ThreeDViewBoundsMaxPoint.X;
                }
                if (item.ThreeDViewBoundsMinPoint.Y < this._3DViewBoundsMinPoint.Y)
                {
                    this._3DViewBoundsMinPoint.Y = item.ThreeDViewBoundsMinPoint.Y;
                }
                if (item.ThreeDViewBoundsMaxPoint.Y > this._3DViewBoundsMaxPoint.Y)
                {
                    this._3DViewBoundsMaxPoint.Y = item.ThreeDViewBoundsMaxPoint.Y;
                }
                if (item.ThreeDViewBoundsMinPoint.Z < this._3DViewBoundsMinPoint.Z)
                {
                    this._3DViewBoundsMinPoint.Z = item.ThreeDViewBoundsMinPoint.Z;
                }
                if (item.ThreeDViewBoundsMaxPoint.Z > this._3DViewBoundsMaxPoint.Z)
                {
                    this._3DViewBoundsMaxPoint.Z = item.ThreeDViewBoundsMaxPoint.Z;
                }
            }
        }

        public void ClearAllData()
        {
            foreach (var item in this._listGeometries)
            {
                item.Dispose();
            }
            _3DViewBoundsMinPoint = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            _3DViewBoundsMaxPoint = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            this._listGeometries.Clear();
        }

        public void CreateVertexBuffer(Device device)
        {
            foreach (var item in this._listGeometries)
            {
                item.CreateVertexBuffer(device);
            }
        }

        public void Render(Device device)
        {
            Matrix oldWorldMatrix = device.Transform.World;

            device.Transform.World = Matrix.Translation(this._3DViewBoundsMinPoint * -1) * Matrix.Scaling(1f / this.Scale, 1f / this.Scale, 1f / this.Scale) * oldWorldMatrix;

            foreach (var item in this._listGeometries)
            {
                item.Render(device);
            }

            device.Transform.World = oldWorldMatrix;
        }
    }
}
