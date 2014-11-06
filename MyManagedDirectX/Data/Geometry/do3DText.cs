using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using System.Drawing;
using Microsoft.DirectX.Direct3D;

namespace MyManagedDirectX.Data
{
    /// <summary>
    /// 三维文本对象
    /// </summary>
    public sealed class do3DText
    {
        private Vector3 _position;
        private string _strText;
        private System.Drawing.Font _font;
        private Color _color;



        /// <summary>
        /// 获取/设置 文本位置坐标
        /// </summary>
        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        /// <summary>
        /// 获取/设置 文本内容
        /// </summary>
        public string Text
        {
            get { return _strText; }
            set { _strText = value; }
        }

        /// <summary>
        /// 获取/设置 文本字体属性
        /// </summary>
        public System.Drawing.Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        /// <summary>
        /// 获取/设置 文本颜色
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public do3DText(Vector3 position, string text)
        {
            if (text != null)
            {
                _position = position;
                _strText = text;
                _font = new System.Drawing.Font("宋体", 10, FontStyle.Regular);
                _color = Color.White;
            }
        }
        
        /// <summary>
        /// 在输入的设备上绘制二维文本
        /// </summary>
        public bool Draw(Device device, float scale)
        {
            try
            {
                float fontsize = 0;
                if (scale * 10 <= 2)
                {
                    fontsize = 8;
                }
                else if (scale * 10 >= 20)
                {
                    fontsize = 25;
                }
                else
                {
                    fontsize = scale * 10;
                }

                System.Drawing.Font newFont = new System.Drawing.Font(_font.FontFamily, fontsize, _font.Style);
                Microsoft.DirectX.Direct3D.Font font = new Microsoft.DirectX.Direct3D.Font(device, newFont);
                Vector3 vt = new Vector3(_position.X, _position.Z, _position.Y);
                vt.Project(device.Viewport, device.Transform.Projection, device.Transform.View, device.Transform.World);
                font.DrawText(null, _strText, new Rectangle((int)vt.X, (int)vt.Y, 0, 0), DrawTextFormat.NoClip, _color);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
