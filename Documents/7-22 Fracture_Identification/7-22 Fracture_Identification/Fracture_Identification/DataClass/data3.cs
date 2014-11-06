using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
namespace fractal.newClass
{
    struct data3
    {
        private double x;
        private double y;
        private double z;
        public double xx
        {
            get { return x; }
            set { x = value; }
        }
        public double yy
        {
            get { return y; }
            set { y = value; }
        }
        public double zz
        {
            get { return z; }
            set { z = value; }
        }
        public data3[] GetXyz(string strPath)//取原值
        {
            string line;
            int counter = 0;
            int i = 0;
            System.IO.StreamReader file = null;
            try
            { 
                file = new System.IO.StreamReader(strPath);
                while ((line = file.ReadLine()) != null && line != "")
                {
                    counter++; ;
                }
            }
            catch
            {
                MessageBox.Show("错误", "格式错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                data3[] myXy = new data3[counter];
                file.Close();
                try
                {
                    System.IO.StreamReader file1 = new System.IO.StreamReader(strPath);
                    while ((line = file1.ReadLine()) != null && line != "")
                    {
                        //  string str= line.Replace('\t',' ');
                        string[] splitstring = line.Split(' ', '\t');

                        myXy[i].xx = Convert.ToDouble(splitstring[0]);
                        myXy[i].yy = Convert.ToDouble(splitstring[1]);
                        myXy[i].zz = Convert.ToDouble(splitstring[2]);
                        if (i < counter)
                        {
                            i++;
                        }
                    }
                    file1.Close();
                }
                catch
                {
                    MessageBox.Show("错误", "格式错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
                return myXy;
            
            
        }
        public  static data3[] GetXyzP(string str)//取原值
        {
            string line;
            int i = 0;
            string[] strr = str.Split('\n');
          
            data3[] myXy = new data3[strr.Length-1];
       
            while ((line = strr[i]) != null && line != "")
            {
                //  string str= line.Replace('\t',' ');
                string[] splitstring = line.Split(' ', '\t');

                myXy[i].xx = Convert.ToDouble(splitstring[0]);
                myXy[i].yy = Convert.ToDouble(splitstring[1]);
                try
                {
                    myXy[i].zz = Convert.ToDouble(splitstring[2]);
                }
                catch
                {
                    myXy[i].zz = 0;
                }
                if (i < strr.Length)
                {
                    i++;
                }
            }
            return myXy;
        }
        public static List<data3> DeleteXT(data3[] xyz)//删除x相同元素
        {
            List<data3> al = new List<data3>();
            for (int i = 0; i < xyz.Length; i++)
            {
                al.Add(xyz[i]);
            }
            int k = 0;
            for (int j = 0; j < al.Count - 1; j++)
            {
                k = j;
                while (al[j].xx == al[j + 1].xx)
                {
                    al.RemoveAt(j);
                }
            }
            return al;
        }
        public static List<data3> DeleteYT(List<data3> al)//删除y相同元素
        {
            int k=0;
            for (int j = 0; j < al.Count - 1; j++)
            {
                k = j;
                while (al[k].yy == al[k + 1].yy)
                {
                    al.RemoveAt(j);
                }
            }
            return al;
        }
        public double GetSumxyz(data3[] xyz,int m)//求x、y、z和
        {
         
                double sum = 0.0;
                if (m == 0)//x和
                {
                    for (int i = 0; i < xyz.Length; i++)
                    {
                        sum += xyz[i].xx;
                    }         
                }
                if (m == 1)//y和
                {
                    for (int i = 0; i < xyz.Length; i++)
                    {
                        sum += xyz[i].yy;
                    }
                }
                if (m == 2)//z和
                {
                    for (int i = 0; i < xyz.Length; i++)
                    {
                        sum += xyz[i].zz;
                    }
                }
               return sum;        
        }
        public double GetSumxyzJi(data3[] xyz,int m)//求xy、xz、yz和
        {
            double sum=0.0;
            if (m == 0)            //求xy和
            {
                for (int i = 0; i < xyz.Length; i++)
                {
                    sum += xyz[i].xx * xyz[i].yy;
                }
            }
            if (m == 1)            //求yz和
            {
                for (int i = 0; i < xyz.Length; i++)
                {
                    sum += xyz[i].yy * xyz[i].zz;
                }
            }
            if (m == 2)          //求xz和
            {
                for (int i = 0; i < xyz.Length; i++)
                {
                    sum += xyz[i].xx * xyz[i].zz;
                }
            }
            return sum;
        }
        public double GetSumxy2(data3[] xyz, int m)//求x，y平方和，
        {
            double sum = 0.0;
            if (m == 0)
            {
                for (int i = 0; i < xyz.Length; i++)
                {
                    sum += Math.Pow(xyz[i].xx, 2);
                }
            }
            if (m == 1)
            {
                for (int i = 0; i < xyz.Length; i++)
                {
                    sum += Math.Pow(xyz[i].yy, 2);
                }
            }
            return sum;
        }
        public double[] GetQushizhi(data3[] xyz, double[] bb)//求趋势值
        {
            double []z=new double[xyz.Length];
            for(int i=0;i<xyz.Length;i++)
            {
                z[i]=bb[0]+bb[1]*xyz[i].xx+bb[2]*xyz[i].yy;
            }
            return z;
        }
        public double[] GetPianchazhi(data3[] xyz, double[] z)//求偏差值
        {
            double[] e = new double[xyz.Length];
            for (int i = 0; i < xyz.Length; i++)
            {
                e[i] = xyz[i].zz - z[i];
            }
            return e;
        }
        public double[] GetDI(double[] e)//求比例因子
        {
            double max=e[0];
            double[] di = new double[e.Length];
            for (int i = 1; i < e.Length; i++)
            {
                if (e[i] > max)
                {
                    max = e[i];
                }
            }
            for (int i = 0; i < e.Length; i++)
            {
                di[i] = e[i] / max;
               
            }
            return di;
        }
        public int[] GetXYsum(data3[] xyz)//xy轴数量
        {
            double x =xyz[0].xx;
            int sum = 1;
            int sum1 = 1;
            int k=1;
            int []xy=new int[2];
            for (int i = 1; i < xyz.Length; i++)
            {
                if (x != xyz[i].xx&&k==1)
                {
                    sum++;          
                }
                if(x==xyz[i].xx)
                {
                    sum1++;
                    k = 0;
                }
            }
            xy[0]=sum;
            xy[1]=sum1;
            return xy;
        }
        public static int[] GetXYsumList(List<data3> xyz)
        {
            double x = xyz[0].xx;
            int sum = 1;
            int sum1 = 1;
            int k = 1;
            int[] xy = new int[2];
            for (int i = 1; i < xyz.Count; i++)
            {
                if (x != xyz[i].xx && k == 1)
                {
                    sum++;
                }
                if (x == xyz[i].xx)
                {
                    sum1++;
                    k = 0;
                }
            }
            xy[0] = sum;//x数量
            xy[1] = sum1;//y数量
            return xy;
        }
        public double[] GetX(data3[] xyz)//x值
        {
            ArrayList arr = new ArrayList();
            arr.Add( xyz[0].xx);
            for (int i = 1; i < xyz.Length; i++)
            {
                if (xyz[0].xx != xyz[i].xx)
                {
                    arr.Add(xyz[i].xx);
                }
                else
                {
                    break;
                }
            }
            double []x=new double[arr.Count];
            for (int i = 0; i < arr.Count; i++)
            {
                x[i] = Convert.ToDouble(arr[i]);
            }
            return x;
        }
        public double[] GetY(data3[] xyz)//y值
        {
            ArrayList arr = new ArrayList();
            arr.Add( xyz[0].yy);
            for (int i = 1; i < xyz.Length; i++)
            {
                if (xyz[0].xx == xyz[i].xx)
                {
                    arr.Add(xyz[i].yy);
                }
            }
            double[] y = new double[arr.Count];
            for (int i = 0; i < arr.Count; i++)
            {
                y[i] = Convert.ToDouble(arr[i]);
            }
            return y;
        }
        public double[] GetZ(data3[] xyz)//z值
        {
            ArrayList arr = new ArrayList();
            for (int i = 0; i < xyz.Length; i++)
            {
                arr.Add(xyz[i].zz);
            }
            double[] z = new double[arr.Count];
            for (int i = 0; i < arr.Count; i++)
            {
                z[i] = Convert.ToDouble(arr[i]);
            }
            return z;
        }
        public double[,] TranserZ(data3[] xyz)//把z值转化成坐标值
        {
            int l = 0;
            int[] lenth = GetXYsum(xyz);//原始x，y值个数
            int lenthx = lenth[0];
            int lenthy = lenth[1];
            double[,] z = new double[lenthx, lenthy];
            for (int i = 0; i < lenthy; i++)
            {
                for (int j = 0; j < lenthx; j++)
                {
                    if (l < xyz.Length)
                    {
                        z[j, i] = xyz[l++].zz;
                    }
                }
            }
            return z;
        }
        public double[,] TranserS(data3[]xyz, double [] di)//把d值转化成坐标值
        {
            int l = 0;
            int[] lenth = GetXYsum(xyz);//原始x，y值个数
            int lenthx = lenth[0];
            int lenthy = lenth[1];
            double[,]s = new double[lenthx, lenthy];
            for (int i = 0; i < lenthy; i++)
            {
                for (int j = 0; j < lenthx; j++)
                {
                    if (l < xyz.Length)
                    {
                        s[j, i] = di[l++];
                        if (s[j, i] == 0)
                        {
                            s[j, i] = 0.1;
                        }
                    }
                }
            }
            return s;
        }
        public double[] GetPxy(double[] xy, int m, int n)//取x轴nb至ne的x数组,取y轴mb至me的y数组
        {
            double[] xx = new double[n - m+1];
                for (int i = 0; i < xx.Length; i++)
                {
                 //   if (m < n + 1)
                  //  {
                        xx[i] = xy[m+i];
                  //  }
                } 
            return xx;
        }

        public double[,] GetPz(double[,] zz, int mb, int me, int nb, int ne)//取局部领域z值
        {
            int n=nb;
            double [,]z=new double[me-mb+1,ne-nb+1];
            for (int i = 0; i <me-mb+1; i++)
            {
                for (int j = 0; j < ne - nb + 1; j++)
                {
                    
                        z[i, j] = zz[mb+i, n+j];
                                     
                }
            }
            return z;
        }
        public double[,] GetPs(double[,] ss, int mb, int me, int nb, int ne)//取局部领域di值
        {
            int n = nb;
            double[,] s = new double[me - mb + 1, ne - nb + 1];
            for (int i = 0; i < me - mb + 1; i++)
            {
                for (int j = 0; j < ne - nb + 1; j++)
                {

                    s[i, j] = ss[mb + i, n + j];

                }
            }
            return s;
        }
    }
}
