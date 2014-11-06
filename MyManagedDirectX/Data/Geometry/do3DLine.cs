using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using System.Drawing;
using Microsoft.DirectX.Direct3D;

namespace MyManagedDirectX.Data
{
    /// <summary>
    /// 三维线段
    /// </summary>
    public sealed class do3DLine
    {
        private Vector3 _startP;
        private Vector3 _endP;
        private Color _LineColor;
        private VertexBuffer vb;

        /// <summary>
        /// 获取/设置 预留，样式对象，暂不使用
        /// </summary>
        //private object _objStyle;

        public Color Color
        {
            get { return _LineColor; }
            set { _LineColor = value; }
        }

        /// <summary>
        /// 获取 节点个数
        /// </summary>
        public int PointCount
        {
            get { return 2; }
        }

        /// <summary>
        /// 构造三维线段对象
        /// </summary>
        /// <param name="startP">起始点坐标</param>
        /// <param name="endP">终止点坐标</param>
        public do3DLine(Vector3 startP, Vector3 endP)
        {
            _startP = startP;
            _endP = endP;
            _LineColor = Color.Yellow;
        }

        /// <summary>
        /// 获取节点
        /// </summary>
        /// <returns></returns>
        public List<Vector3> GetPoint()
        {
            List<Vector3> _points = new List<Vector3>();
            _points.Add(_startP);
            _points.Add(_endP);
            return _points;
        }

        /// <summary>
        /// 绘制三维线段
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool Draw(Device device)
        {
            try
            {
                vb = new VertexBuffer(typeof(CustomVertex.PositionColored), 2, device, 0, CustomVertex.PositionColored.Format, Pool.Default);
                CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vb.Lock(0, 0);
                verts[0] = new CustomVertex.PositionColored(_startP.X, _startP.Z, _startP.Y, _LineColor.ToArgb());
                verts[1] = new CustomVertex.PositionColored(_endP.X, _endP.Z, _endP.Y, _LineColor.ToArgb());
                vb.Unlock();
                device.SetStreamSource(0, vb, 0);
                device.DrawPrimitives(PrimitiveType.LineList, 0, 1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
