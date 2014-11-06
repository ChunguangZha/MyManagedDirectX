using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;

namespace MyManagedDirectX.Data.Geometry
{
    /// <summary>
    /// 地理坐标的Y作为三维坐标中的Z，地理坐标中的Z作为三维坐标中的Y。
    /// </summary>
    public interface ID3DGeometry : IDisposable
    {
        #region Properties

        #region World View Bounds

        /// <summary>
        /// 世界视图范围最小边界
        /// </summary>
        Vector3 ThreeDViewBoundsMinPoint { get; }
        /// <summary>
        /// 世界视界范围最大边界
        /// </summary>
        Vector3 ThreeDViewBoundsMaxPoint { get; }

        #endregion

        #endregion

        /// <summary>
        /// 创建所有几何对象的缓冲区
        /// </summary>
        void CreateVertexBuffer(Device device);

        void Render(Device device);

        void Dispose();
    }
}
