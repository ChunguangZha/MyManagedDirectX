using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using System.Threading;
using MyManagedDirectX.Data;
using MyManagedDirectX.Properties;
using MyManagedDirectX.Data.Geometry;

namespace MyManagedDirectX
{
    public partial class Map3DControl : UserControl
    {
        #region 变量

        /// <summary>
        /// 设备
        /// </summary>
        private Device _device;

        /// <summary>
        /// 设备状态
        /// </summary>
        private bool bDeviceLost = false;

        /// <summary>
        /// 缩放比例
        /// </summary>
        private float _scale;
        /// <summary>
        ///  记录鼠标位置
        /// </summary>
        private Vector3 _mousePosition;

        /// <summary>
        /// 场景中心位置
        /// </summary>
        private Vector3 _cameraT = new Vector3();
        /// <summary>
        /// 摄影机位置
        /// </summary>
        private Vector3 _cameraP = new Vector3(0, 3, -6);

        /// <summary>
        /// 方向
        /// </summary>
        private Vector3 _cameraUp = new Vector3(0, 1, 0);

        /// <summary>
        /// 三维场景背景颜色,默认为灰色
        /// </summary>
        private Color _backGroundColor = Color.Black;

        /// <summary>
        /// 鼠标动作
        /// </summary>
        private de3DAction _action = de3DAction.PanRotate;

        #region 平面投影的坐标范围

        private float maxX
        {
            get
            {
                if (this._d3dProvider.GeometryCount == 0)
                {
                    return 1;
                }
                return this._d3dProvider.WorldViewBoundsMaxPoint.X;
            }
        }

        private float minX
        {
            get
            {
                if (this._d3dProvider.GeometryCount == 0)
                {
                    return 0;
                }

                return this._d3dProvider.WorldViewBoundsMinPoint.X;
            }
        }

        private float maxY
        {
            get
            {
                if (this._d3dProvider.GeometryCount == 0)
                {
                    return 1;
                }
                return this._d3dProvider.WorldViewBoundsMaxPoint.Y;
            }
        }

        private float minY
        {
            get
            {
                if (this._d3dProvider.GeometryCount == 0)
                {
                    return 0;
                } 
                return this._d3dProvider.WorldViewBoundsMinPoint.Y;
            }
        }

        private float maxZ
        {
            get
            {
                if (this._d3dProvider.GeometryCount == 0)
                {
                    return 1;
                }
                return this._d3dProvider.WorldViewBoundsMaxPoint.Z;
            }
        }

        private float minZ
        {
            get
            {
                if (this._d3dProvider.GeometryCount == 0)
                {
                    return 0;
                }
                return this._d3dProvider.WorldViewBoundsMinPoint.Z;
            }
        }

        
        #endregion

        /// <summary>
        /// 绕Y轴旋转角度
        /// </summary>
        private float rotateAngleY = 0.1f;
        /// <summary>
        /// 绕X轴旋转角度
        /// </summary>
        private float rotateAngleX = 0.1f;
        /// <summary>
        /// 绕Z轴旋转角度
        /// </summary>
        private float rotateAngleZ = 0.1f;
                
        float tempAngleX = 0;
        float tempAngleY = 0;
        
        #endregion

        #region 属性
        
        /// <summary>
        /// 获取/设置 场景颜色
        /// </summary>
        public Color BackGroundColor
        {
            get
            {
                return _backGroundColor;
            }
            set
            {
                _backGroundColor = value;
            }
        }
        
        /// <summary>
        /// 获取/设置 三维控件的操作
        /// </summary>
        public de3DAction Action
        {
            get { return _action; }
            set
            {
                _action = value;

                if (ActionChange != null)
                {
                    ActionChange(value);
                }
            }
        }
        
        #endregion

        List<Texture> listTexture = new List<Texture>();
        
        private D3DProvider _d3dProvider;

        public Map3DControl()
        {
            InitializeComponent();
            _d3dProvider = new D3DProvider();

            InitializeGraphics();
            this.MouseWheel += new MouseEventHandler(OnMouseWheel);
            this.ActionChange += new AfterActionChange(OnAction);
        }

        public void LoadData(string filePath)
        {
            _d3dProvider.LoadDataFile(filePath);
            ViewAll();
            OnCreateDevice(this._device, null);
            Render();
        }

        #region 建立场景

        public void InitializeGraphics()
        {
            Device.IsUsingEventHandlers = false;    //关闭MDX的自动事件布线机制!

            PresentParameters presentParams = SetPresentParameters();
            CreateFlags createFlags = SetCreateFlags();
            DeviceType deviceType = SetDeviceType();
            _device = new Device(0, deviceType, this, createFlags, presentParams);
            
            _device.DeviceReset += new EventHandler(OnResetDevice);

            //OnCreateDevice(this._device, null);
            OnResetDevice(this._device, null);

            ViewAll();
            Render();
            this.Action = de3DAction.PanRotate;
        }

        private DeviceType SetDeviceType()
        {
            DeviceType deviceType = DeviceType.Hardware;
            //Caps caps = Manager.GetDeviceCaps(0, DeviceType.Hardware);//可以用来检测设备的一些功能
            //if (caps.DeviceCaps.SupportsHardwareRasterization && caps.DeviceCaps.SupportsHardwareTransformAndLight)
            //{
            //    //显卡是否支持硬件顶点处理即硬件几何变换和光源计算
            //    deviceType = DeviceType.Hardware;
            //}

            return deviceType;
        }

        private CreateFlags SetCreateFlags()
        {
            CreateFlags createFlags = CreateFlags.SoftwareVertexProcessing;

            ////检验设备
            //if (Manager.CheckDeviceMultiSampleType(0, DeviceType.Hardware, Format.VertexData, true, MultiSampleType.None))
            //{
            //    createFlags = CreateFlags.MixedVertexProcessing;//| CreateFlags.PureDevice;
            //}

            return createFlags;
        }

        private PresentParameters SetPresentParameters()
        {
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;

            presentParams.BackBufferFormat = Format.Unknown;
            presentParams.EnableAutoDepthStencil = true;//允许使用一个深度缓存和一个深度模板，深度模板允许程序掩饰被渲染图像的一部分，使它们不被显示出来
            presentParams.AutoDepthStencilFormat = DepthFormat.D16;//设置16位的深度缓存
            presentParams.PresentFlag = PresentFlag.DiscardDepthStencil;
            presentParams.MultiSample = MultiSampleType.FourSamples;
            presentParams.MultiSampleQuality = 0;
            
            return presentParams;
        }

        public void Release()
        {
            if (_device != null)
            {
                _device.Dispose();
                _device = null;
            }
        }

        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;
            this._d3dProvider.CreateVertexBuffer(dev);
        }
        
        /// <summary>
        /// 设备重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnResetDevice(object sender, EventArgs e)
        {
            try
            {
                if (sender == null)
                {
                    AttemptRecovery();
                    return;
                }

                Device dev = (Device)sender;

                dev.RenderState.ZBufferEnable = true;
                dev.RenderState.Lighting = false;
                dev.RenderState.CullMode = Cull.None;
                dev.RenderState.AntiAliasedLineEnable = false;
                dev.SetRenderState(RenderStates.MultisampleAntiAlias, true);
                //dev.RenderState.FillMode = FillMode.Solid;
                dev.RenderState.ShadeMode = ShadeMode.Gouraud;
                //dev.RenderState.ZBufferWriteEnable = true;
            }
            catch (Exception)
            {

            }
        }

        protected void AttemptRecovery()
        {
            int ret;
            _device.CheckCooperativeLevel(out ret);

            switch (ret)
            {
                case (int)ResultCode.DeviceLost:
                    break;
                case (int)ResultCode.DeviceNotReset:
                    try
                    {
                        InitializeGraphics();
                        bDeviceLost = false;
                    }
                    catch (DeviceLostException)
                    {
                        Thread.Sleep(50);
                    }
                    break;
            }
        }

        #endregion
        
        #region 绘制

        public void ViewAll()
        {
            this._cameraT = new Vector3((maxX + minX) / 2, (maxY + minY) / 2, (maxZ + minZ) / 2);
            //float dis = (maxX - minX) > (maxZ - minZ) ? (maxX - minX) : (maxZ - minZ);
            float dis = Utility.DistanceOfTwoVector(this._d3dProvider.WorldViewBoundsMaxPoint, this._d3dProvider.WorldViewBoundsMinPoint);
            this._cameraP = new Vector3((maxX + minX) / 2, (maxY + minY) / 2, -1 * dis + minZ);

            //this.SetupMatrices();
            //Microsoft.DirectX.Matrix currentView = _device.Transform.View;//当前摄像机的视图矩阵
            //_cameraP.Subtract(_cameraT);
            //Vector4 tempV = Vector3.Transform(_cameraP, Microsoft.DirectX.Matrix.RotationQuaternion(
            //   Quaternion.RotationAxis(new Vector3(currentView.M11, currentView.M21, currentView.M31), 45)));
            //_cameraP.X = tempV.X + _cameraT.X;
            //_cameraP.Y = tempV.Y + _cameraT.Y;
            //_cameraP.Z = tempV.Z + _cameraT.Z;

            _scale = _device.Viewport.Height / (float)(Math.Cos(45 * Math.PI / 180) * (maxY - minY));
            _device.Transform.World = Microsoft.DirectX.Matrix.Identity;
            rotateAngleX = rotateAngleY = rotateAngleZ = 0f;

        }

        protected void SetupMatrices()
        {
            _device.Transform.View = Microsoft.DirectX.Matrix.LookAtLH(this._cameraP, this._cameraT, this._cameraUp);

            float zfarPlane = Utility.DistanceOfTwoVector(this._cameraP, this._cameraT) + Utility.DistanceOfTwoVector(this._d3dProvider.WorldViewBoundsMaxPoint, this._d3dProvider.WorldViewBoundsMinPoint);
            _device.Transform.Projection = Microsoft.DirectX.Matrix.PerspectiveFovLH((float)Math.PI / 4.0F, _device.Viewport.Width / _device.Viewport.Height, 1f, zfarPlane);

        }

        public void Render()
        {
            try
            {
                System.GC.Collect();

                if (bDeviceLost)
                    AttemptRecovery();
                if (bDeviceLost) return;

                _device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Gray, 1.0F, 0);
                _device.BeginScene();
                SetupMatrices();

                _device.VertexFormat = CustomVertex.PositionColored.Format;



                //DrawAxisData();

                this._d3dProvider.Render(this._device);

                _device.EndScene();
                try
                {
                    _device.Present();
                }
                catch (DeviceLostException)
                {
                    bDeviceLost = true;
                }
            }
            catch (Exception)
            {
                bDeviceLost = true;
                this.Release();
            }
        }

        private void DrawAxisData()
        {
            Vector3 dpto, dpx, dpy, dpz;

            dpto = new Vector3(minX, minY, minZ);
            dpx = new Vector3(maxX, dpto.Y, dpto.Z);
            dpy = new Vector3(dpto.X, maxY, dpto.Z);
            dpz = new Vector3(dpto.X, dpto.Y, maxZ);

            //添加X/Y/Z坐标
            do3DLine objLx = new do3DLine(dpto, dpx);
            objLx.Color = Color.Red;
            do3DLine objLy = new do3DLine(dpto, dpz);
            objLy.Color = Color.Yellow;
            do3DLine objLz = new do3DLine(dpto, dpy);
            objLz.Color = Color.Blue;
            objLx.Draw(_device);
            objLy.Draw(_device);
            objLz.Draw(_device);

            //添加X/Y/Z坐标上的文字
            float distance = 100 * Math.Abs(_scale);
            dpx.Add(new Vector3(1, 0, 0));
            dpy.Add(new Vector3(0, 1, 0));  
            dpz.Add(new Vector3(0, 0, 1));          
            
            do3DText objTextx = new do3DText(dpx, "X正方向");
            do3DText objTexty = new do3DText(dpy, "Y正方向");
            do3DText objTextz = new do3DText(dpz, "Z正方向");

            objTextx.Draw(_device, 1);
            objTexty.Draw(_device, 1);
            objTextz.Draw(_device, 1);

            //添加箭头数据
        }

        #endregion

        #region 鼠标事件

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            float scaleFactor = -1 * (float)e.Delta / 2000 + 1f;//比例因子
            if (e.Delta > 0)
                _scale += scaleFactor / 5;
            else
                _scale -= scaleFactor / 5;

            this._cameraP.Subtract(this._cameraT);
            _cameraP.Scale(scaleFactor);
            _cameraP.Add(_cameraT);

            Render();
        }

        private void OnAction(de3DAction action)
        {
            Cursor cursor = Cursors.Default;//鼠标形状定义
            Bitmap img = null;

            switch (action)
            {
                case de3DAction.ZoomIn:
                    ZoomIn();
                    img = Resources.放大;
                    cursor = new Cursor(img.GetHicon());
                    break;
                case de3DAction.ZoomOut:
                    ZoomOut();
                    img = Resources.缩小;
                    cursor = new Cursor(img.GetHicon());
                    break;
                case de3DAction.RotateX:
                    RotateX(true);
                    img = Resources.绕X旋转;
                    cursor = new Cursor(img.GetHicon());
                    break;

                case de3DAction.RotateY:
                    RotateY(true);
                    img = Resources.绕Z旋转;
                    cursor = new Cursor(img.GetHicon());
                    break;
                case de3DAction.RotateZ:
                    RotateZ(true);
                    break;
                case de3DAction.PanRotate:
                    img = Resources.环游;
                    cursor = new Cursor(img.GetHicon());
                    break;
                case de3DAction.VerticalView:
                    _cameraP = new Vector3((maxX + minX) / 2, 300f, (maxY + minY) / 2);
                    _cameraT = new Vector3((maxX + minX) / 2, (maxZ + minZ) / 2, (maxY + minY) / 2);
                    Microsoft.DirectX.Matrix currentView5 = _device.Transform.View;//当前摄像机的视图矩阵
                    break;
                case de3DAction.LeftView:
                    _cameraP = new Vector3(minX - 100f, (maxZ + minZ) / 2, (maxY + minY) / 2);
                    _cameraT = new Vector3((maxX + minX) / 2, (maxZ + minZ) / 2, (maxY + minY) / 2);
                    break;
                case de3DAction.RightView:
                    _cameraP = new Vector3(maxX + 100f, (maxY + minY) / 2, (maxZ + minZ) / 2);
                    _cameraT = new Vector3((maxX + minX) / 2, 100f, (maxZ + minZ) / 2);
                    break;
                case de3DAction.Pan:
                    img = Resources.平移;
                    cursor = new Cursor(img.GetHicon());
                    break;
                case de3DAction.NULL:
                    break;
                default:
                    break;
            }

            this.Cursor = cursor;
            try
            {
                //SetupMatrices();
                this.Render();
            }
            catch (Exception)
            {
                //throw new Exception("OnAction " + ex.Message);
            }
        }

        private void ZoomOut()
        {
            float scaleFactor1 = 1.05f;
            _cameraP.Subtract(_cameraT);
            _cameraP.Scale(scaleFactor1);
            _cameraP.Add(_cameraT);
        }

        private void ZoomIn()
        {
            float scaleFactor = 0.95f;
            _cameraP.Subtract(_cameraT);
            _cameraP.Scale(scaleFactor);
            _cameraP.Add(_cameraT);
        }

        private void RotateX(bool bIsClockWise)
        {
            float angle = rotateAngleX;
            if (!bIsClockWise)
            {
                angle *= -1;
            }

            Microsoft.DirectX.Matrix mW = _device.Transform.World;
            Microsoft.DirectX.Matrix mT = Microsoft.DirectX.Matrix.Translation(_cameraT);
            Microsoft.DirectX.Matrix mT1 = Microsoft.DirectX.Matrix.Translation(_cameraT * -1);
            Microsoft.DirectX.Matrix mR = Microsoft.DirectX.Matrix.RotationYawPitchRoll(0, angle, 0);
            mW.Multiply(mT1);
            mW.Multiply(mR);
            mW.Multiply(mT);
            _device.Transform.World = mW;
        }

        private void RotateY(bool bIsClockWise)
        {
            float angle = rotateAngleY;
            if (!bIsClockWise)
            {
                angle *= -1;
            }

            Microsoft.DirectX.Matrix mW = _device.Transform.World;
            Microsoft.DirectX.Matrix mT = Microsoft.DirectX.Matrix.Translation(_cameraT);
            Microsoft.DirectX.Matrix mT1 = Microsoft.DirectX.Matrix.Translation(_cameraT * -1);
            Microsoft.DirectX.Matrix mR = Microsoft.DirectX.Matrix.RotationYawPitchRoll(angle, 0, 0);
            mW.Multiply(mT1);
            mW.Multiply(mR);
            mW.Multiply(mT);
            _device.Transform.World = mW;
        }

        private void RotateZ(bool bIsClockWise)
        {
            float angle = rotateAngleZ;
            if (!bIsClockWise)
            {
                angle *= -1;
            }

            Microsoft.DirectX.Matrix mW = _device.Transform.World;
            Microsoft.DirectX.Matrix mT = Microsoft.DirectX.Matrix.Translation(_cameraT);
            Microsoft.DirectX.Matrix mT1 = Microsoft.DirectX.Matrix.Translation(_cameraT * -1);
            Microsoft.DirectX.Matrix mR = Microsoft.DirectX.Matrix.RotationYawPitchRoll(0, 0, angle);
            mW.Multiply(mT1);
            mW.Multiply(mR);
            mW.Multiply(mT);
            _device.Transform.World = mW;
        }

        private void Map3DControl_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Render();
            }
            catch (Exception)
            {
            }
        }
        
        private void Map3DControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //Action = Enum.de3DAction.NULL;
            }
            else if (e.Button == MouseButtons.Left)
            {
                #region Rotate
                if (Action == de3DAction.PanRotate)
                {
                    tempAngleX = 4 * (float)(e.Y - _mousePosition.Y) / this.Height;
                    tempAngleY = 2 * (float)(e.X - _mousePosition.X) / this.Width;

                    Matrix mW = _device.Transform.World;

                    mW.Multiply(Matrix.Translation(_cameraT * -1));
                    mW.Multiply(Matrix.RotationYawPitchRoll(-1 * tempAngleY, 0, 0));
                    mW.Multiply(Matrix.RotationYawPitchRoll(0, -1 * tempAngleX, 0));
                    mW.Multiply(Matrix.Translation(_cameraT));

                    _device.Transform.World = mW;
                }
                #endregion

                #region Pan
                if (Action == de3DAction.Pan)
                {
                    Vector3 endP = new Vector3(e.X, e.Y, 0);
                    endP.Subtract(_mousePosition);
                    if (endP.Length() != 0)
                    {
                        Microsoft.DirectX.Matrix mW = _device.Transform.World;
                        endP.Normalize();
                        endP.Y *= -1;
                        float distance = endP.Length();
                        float n = (distance) / 0.03f;
                        endP.Multiply(n);
                        Microsoft.DirectX.Matrix mT = Microsoft.DirectX.Matrix.Translation(endP);
                        mW.Multiply(mT);
                        _device.Transform.World = mW;
                    }
                }

                #endregion
                
                #region

                //if (Action == de3DAction.Pan)
                //{
                    //Vector3 delt = new Vector3(e.X, e.Y, 0);
                    //delt.Unproject(_device.Viewport, _device.Transform.Projection, _device.Transform.View, _device.Transform.World);
                    //Vector3 v2 = new Vector3(_mousePosition.X, _mousePosition.Y, 0);
                    //v2.Unproject(_device.Viewport, _device.Transform.Projection, _device.Transform.View, _device.Transform.World);
                    //delt.Subtract(v2);
                    //delt.Scale(1000);
                    //_cameraP.Add(delt);
                    //_cameraT.Add(delt);


                    //Microsoft.DirectX.Matrix matT =Microsoft.DirectX.Matrix.Identity;
                    //_device.Transform.World.Translate(-_cameraP);
                    //matT.Multiply(_device.Transform.World.Multiply);

                    //D3DXMATRIX matT;
                    //D3DXMatrixIdentity(&matT);                         //定义单位矩阵
                    //D3DXMatrixTanslation(&matT, x, y, z);                  //建立平移矩阵
                    //D3DXMatrixMultiply(&m_matPosition, &matT, &m_matPosition);
                    //D3DXMatrixInverse(&m_matView, NULL, &m_matPosition);   //为什么要进行逆矩阵变换
                    //pd3dDevice->SetTransform(&D3DTS_VIEW, &m_matView);


                //}
                #endregion

                Render();
                _mousePosition.X = e.X;
                _mousePosition.Y = e.Y;

            }
        }

        private void Map3DControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mousePosition.X = e.X;
                _mousePosition.Y = e.Y;

                Vector3 v1 = new Vector3(e.X, e.Y, 0f);
                v1.Unproject(_device.Viewport, _device.Transform.Projection, _device.Transform.View, _device.Transform.World);

                if (this._action == de3DAction.ZoomIn)
                {
                    ZoomIn();
                }
                if (this._action == de3DAction.ZoomOut)
                {
                    ZoomOut();
                }
                if (this._action == de3DAction.RotateX)
                {
                    RotateX(true);
                }
                if (this._action == de3DAction.RotateY)
                {
                    //rotateAngleY += 0.1f;
                    RotateY(true);
                }
                if (this._action == de3DAction.RotateZ)
                {
                    //rotateAngleZ += 0.1f;
                    RotateZ(true);
                }
                this.Render();
            }
            else
            {
                Action = de3DAction.PanRotate;
            }
        }

        private void Map3DControl1_Resize(object sender, EventArgs e)
        {
            try
            {
                if (bDeviceLost)
                    AttemptRecovery();
                if (_device == null)
                    InitializeGraphics();
                this.Render();
            }
            catch (Exception)
            {

            }
        }

        #endregion



        public event AfterActionChange ActionChange;
    }

    public delegate void AfterActionChange(de3DAction action);

    /// <summary>
    /// 三维操作
    /// </summary>
    public enum de3DAction
    {
        /// <summary>
        /// 放大
        /// </summary>
        ZoomIn,
        /// <summary>
        /// 缩小
        /// </summary>
        ZoomOut,
        /// <summary>
        /// 自由缩放
        /// </summary>
        ZoomFree,
        /// <summary>
        /// 绕X轴旋转
        /// </summary>
        RotateX,
        /// <summary>
        /// 绕Y轴旋转
        /// </summary>
        RotateY,
        /// <summary>
        /// 绕Z轴旋转
        /// </summary>
        RotateZ,
        /// <summary>
        /// 环游
        /// </summary>
        PanRotate,
        /// <summary>
        /// 俯视图
        /// </summary>
        VerticalView,
        /// <summary>
        /// 左视图
        /// </summary>
        LeftView,
        /// <summary>
        /// 右视图
        /// </summary>
        RightView,
        /// <summary>
        /// 空操作
        /// </summary>
        NULL,
        /// <summary>
        /// 漫游
        /// </summary>
        Pan,
        /// <summary>
        /// 三维网状图
        /// </summary>
        GridView,
        /// <summary>
        /// 三维实体图
        /// </summary>
        SolidView,
        /// <summary>
        /// 三维点阵图
        /// </summary>
        PointView


    }
}
