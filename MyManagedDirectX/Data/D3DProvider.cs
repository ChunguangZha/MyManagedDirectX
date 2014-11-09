using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using MyManagedDirectX.Data.Dataset;

namespace MyManagedDirectX.Data
{
    public class D3DProvider
    {
        #region Properties

        #region World View Bounds

        /// <summary>
        /// 世界视图范围最小边界
        /// </summary>
        public Vector3 WorldViewBoundsMinPoint
        {
            get { return this._d3dDataset.ThreeDViewBoundsMinPoint; }
        }

        /// <summary>
        /// 世界视界范围最大边界
        /// </summary>
        public Vector3 WorldViewBoundsMaxPoint
        {
            get { return this._d3dDataset.ThreeDViewBoundsMaxPoint; }
        }

        #endregion

        private ID3DDataset _d3dDataset = null;

        public int GeometryCount
        {
            get
            {
                if (_d3dDataset == null)
                {
                    return 0;
                }

                return this._d3dDataset.GeometryCount;
            }
        }

        #endregion

        #region Methods

        public D3DProvider()
        {
            _d3dDataset = new D3DBoreBreakStripDataset();
        }

        public void LoadDataFile(string filePath)
        {
            _d3dDataset.LoadDataFile(filePath);
        }

        public void ClearAllData()
        {
            _d3dDataset.ClearAllData();
        }

        /// <summary>
        /// 创建所有几何对象的缓冲区
        /// </summary>
        public void CreateVertexBuffer(Device device)
        {
            _d3dDataset.CreateVertexBuffer(device);
        }

        public void Render(Device device)
        {
            _d3dDataset.Render(device);
        }

        #endregion
    }
}
