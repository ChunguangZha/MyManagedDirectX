using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using MyManagedDirectX.Data.Geometry;

namespace MyManagedDirectX.Data.Dataset
{
    public interface ID3DDataset
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

        List<ID3DGeometry> ListGeometries { get; }

        int GeometryCount { get; }

        #endregion

        #region Methods

        void LoadDataFile(string filePath);
        
        void ClearAllData();

        /// <summary>
        /// 创建所有几何对象的缓冲区
        /// </summary>
        void CreateVertexBuffer(Device device);

        void Render(Device device);

        #endregion

    }
}
