using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MyManagedDirectX.Data.Geometry
{
    public class doPoint
    {
        private double x;
        private double y;
        private double z;
        private object tag1;
        private object tag2;

        #region 属性

        public object Tag1
        {
            get { return tag1; }
            set { tag1 = value; }
        }

        public object Tag2
        {
            get { return tag2; }
            set { tag2 = value; }
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }
        #endregion

        public doPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
        }

        public doPoint(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public doPoint(doPoint dpt)
        {
            this.x = dpt.x;
            this.y = dpt.y;
            this.z = dpt.z;
        }

        public doPoint(PointF ptf)
        {
            this.x = ptf.X;
            this.y = ptf.Y;
            this.z = 0;
        }

        /// <summary>
        /// 拷贝
        /// </summary>
        /// <returns>Clone</returns>
        public doPoint Clone()
        {
            doPoint dpt = new doPoint(X, Y, Z);
            dpt.Tag1 = tag1;
            dpt.tag2 = tag2;
            return dpt;
        }

    }
}
