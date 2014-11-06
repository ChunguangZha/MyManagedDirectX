using System;
using System.Collections.Generic;
using System.Text;

namespace MyManagedDirectX.Data.Geometry
{
    public class doRect
    {
        /// <summary>
        /// 左上角点的坐标
        /// </summary>
        private doPoint topLeft = new doPoint(0, 0);
        /// <summary>
        /// 右下角点的坐标
        /// </summary>
        private doPoint bottomRight = new doPoint(0, 0);
        /// <summary>
        /// 是否为空
        /// </summary>
        private bool bIsEmpty;
        /// <summary>
        /// 返回 矩形的高
        /// </summary>
        public double Height
        {
            get
            {
                return Math.Abs(bottomRight.Y - topLeft.Y);
            }
        }

        /// <summary>
        /// 返回 矩形的宽
        /// </summary>
        public double Width
        {
            get
            {
                return Math.Abs(bottomRight.X - topLeft.X);
            }
        }
        /// <summary>
        /// 返回 左边框中点
        /// </summary>
        public doPoint LeftCentroid
        {
            get
            {
                return new doPoint(topLeft.X, (topLeft.Y + bottomRight.Y) / 2);
            }
        }

        /// <summary>
        /// 返回 右左边框中点
        /// </summary>
        public doPoint RightCentroid
        {
            get
            {
                return new doPoint(bottomRight.X, (topLeft.Y + bottomRight.Y) / 2);
            }
        }
        /// <summary>
        /// 返回 上边框中点
        /// </summary>
        public doPoint TopCentroid
        {
            get
            {
                return new doPoint((topLeft.X + bottomRight.X) / 2, topLeft.Y);
            }
        }
        /// <summary>
        /// 返回 下边框中点
        /// </summary>
        public doPoint BottomCentroid
        {
            get
            {
                return new doPoint((topLeft.X + bottomRight.X) / 2, bottomRight.Y);
            }
        }
        /// <summary>
        /// 返回 是否为空值
        /// </summary>
        public bool IsEmpty
        {
            get { return bIsEmpty; }
        }


        public doRect(double minX, double minY, double maxX, double maxY)
        {
            topLeft = new doPoint(minX, maxY, 0);
            bottomRight = new doPoint(maxX, minY, 0);
            CheckMinMax();
        }

        /// <summary>
        /// 创建一个空的Rect
        /// </summary>
        public doRect()
        {
            topLeft = new doPoint(0, 0);
            bottomRight = new doPoint(0, 0);
            bIsEmpty = true;
        }

        /// <summary>
        /// 由两点构成矩形
        /// </summary>
        /// <param name="TopLeft">左上</param>
        /// <param name="BottomRight">右下</param>
        public doRect(doPoint TopLeft, doPoint BottomRight)
        {
            topLeft = TopLeft.Clone();
            bottomRight = BottomRight.Clone();
            CheckMinMax();
        }

        /// <summary>
        /// 由一点构成矩形
        /// </summary>
        /// <param name="TopLeft">左上</param>
        /// <param name="Width">宽</param>
        /// <param name="Height">高</param>
        public doRect(doPoint TopLeft, double Width, double Height)
        {
            topLeft = TopLeft.Clone();
            bottomRight = new doPoint(TopLeft.X + Width, TopLeft.Y - Height);
        }

        /// <summary>
        /// 判断左上、右下的值，交换并正确赋值
        /// </summary>
        /// <returns></returns>
        private void CheckMinMax()
        {
            if (topLeft.X > bottomRight.X)
            {
                double tmp = topLeft.X;
                topLeft.X = bottomRight.X;
                bottomRight.X = tmp;
            }
            if (topLeft.Y < bottomRight.Y)
            {
                double tmp = topLeft.Y;
                topLeft.Y = bottomRight.Y;
                bottomRight.Y = tmp;
            }
        }

    }
}
