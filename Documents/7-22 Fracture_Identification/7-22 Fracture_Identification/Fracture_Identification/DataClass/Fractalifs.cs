using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace fractal.newClass
{
    class Fractalifs
    {
        public static double[] GetNewXY(double[]xx,double[]yy,int m)//生成x轴y轴新数据
        {
                int lenthx= xx.Length;
                int lenthy = yy.Length;
                ArrayList arr = new ArrayList();
                if (m == 0)//x轴
                {
                    for (int i = 0; i < lenthx - 1; i++)
                    {
                        for (int j = 0; j < lenthx; j++)
                        {
                            arr.Add(xx[i] + (xx[i + 1] - xx[i]) * (xx[j] - xx[0]) / (xx[lenthx - 1] - xx[0]));
                        }
                    }
                  //  arr.Add(xx[lenthx - 2] + (xx[lenthx - 1] - xx[lenthx - 2]) * (xx[lenthx - 1] - xx[0]) / (xx[lenthx - 1] - xx[0]));
                    double[] x = new double[arr.Count];
                    for (int i = 0; i < arr.Count; i++)
                    {
                        x[i] = Convert.ToDouble(arr[i]);
                    }
       
                    return x;
                }
                else //y轴
                {
                    for (int i = 0; i < lenthy - 1; i++)
                    {
                        for (int j = 0; j < lenthy; j++)
                        {
                            arr.Add(yy[i] + (yy[i + 1] - yy[i]) * (yy[j] - yy[0]) / (yy[lenthy - 1] - yy[0]));
                        }
                    }
               //     arr.Add(yy[lenthy - 2] + (yy[lenthy - 1] - yy[lenthy - 2]) * (yy[lenthy - 1] - yy[0]) / (yy[lenthy - 1] - yy[0]));
                    double[] x = new double[arr.Count];
                    for (int i = 0; i < arr.Count; i++)
                    {
                        x[i] = Convert.ToDouble(arr[i]);
                    }
                    return x;
                }
        }
        public static double[,] GetNewZ(data3[] xyz,double[]xx, double[]yy,double []di)//生成z轴新数据
        {
                int lenthx= xx.Length;
                int lenthy = yy.Length;
                int l=0;
                double[,]z=new double[lenthx,lenthy];
                double[,]s=new double[lenthx,lenthy];
                for (int i = 0; i < lenthy; i++)
                {
                    for (int j = 0; j < lenthx; j++)
                    {
                        if (l < lenthx * lenthy)
                        {
                            z[j,i] = xyz[l++].zz;
                        }
                    }
                }
                l=0;
                for(int i=0;i<lenthy;i++)
                {
                    for(int j=0;j<lenthx;j++)
                    {
                        if(l < lenthx * lenthy)
                        {
                        s[j,i]=di[l++];
                        if (s[j, i] == 0)
                        {
                            s[j, i] = 0.1;
                        }
                        }
                    }
                }
            //一个小网格从下到上，从左至右；
                double g = 0.0, e = 0.0, f = 0.0, k = 0.0;
                double[,] zz = new double[lenthx * (lenthx - 1), lenthy * (lenthy - 1)];
                for (int i = 1; i < lenthx; i++)
                {
                    for (int j = 1; j < lenthy; j++)
                    {
                        g = (z[i - 1, j - 1] - z[i - 1, j] - z[i, j - 1] + z[i, j] - s[i, j] * (z[0, 0] - z[lenthx - 1, 0] - z[0, lenthy - 1] + z[lenthx - 1, lenthy - 1])) / (xx[0] * yy[0] - xx[lenthx - 1] * yy[0] - xx[0] * yy[lenthy - 1] + xx[lenthx - 1] * yy[lenthy - 1]);
                        e = (z[i - 1, j - 1] - z[i, j - 1] - s[i, j] * (z[0, 0] - z[lenthx - 1, 0]) - g * (xx[0] * yy[0] - xx[lenthx - 1] * yy[0])) / (xx[0] - xx[lenthx - 1]);
                        f = (z[i - 1, j - 1] - z[i - 1, j] - s[i, j] * (z[0, 0] - z[0, lenthy - 1]) - g * (xx[0] * yy[0] - xx[0] * yy[lenthy - 1])) / (yy[0] - yy[lenthy - 1]);
                        k = z[i, j] - e * xx[lenthx - 1] - f * yy[lenthy - 1] - s[i, j] * z[lenthx - 1, lenthy - 1] - g * xx[lenthx - 1] * yy[lenthy - 1];
                        for (int m = 0; m < lenthx; m++)
                        {
                            for (int n = 0; n < lenthy; n++)
                            {
                               /* if (xx[m] >= xx[lenthx - 2] && xx[m] < xx[lenthx - 1])
                                {
 
                                }*/
                                zz[(i-1) * lenthx + m, (j-1) * lenthy + n] = e * xx[m] + f * yy[n] + g * xx[m] * yy[n] + s[i, j] * z[m, n] + k;
                            }
                        }
                      
                    }         
                }
                return zz;
        }
        public static double[,] GetNewPZ(double[] xx, double[] yy,double[,]z,double [,]s)//生成局部z轴数据
        {
            int lenthx = xx.Length;
            int lenthy = yy.Length; 
            //一个小网格从下到上，从左至右；
                double g = 0.0, e = 0.0, f = 0.0, k = 0.0;
                double[,] zz = new double[lenthx * (lenthx - 1), lenthy * (lenthy - 1)];
                for (int i = 1; i < lenthx; i++)
                {
                    for (int j = 1; j < lenthy; j++)
                    {
                        g = (z[i - 1, j - 1] - z[i - 1, j] - z[i, j - 1] + z[i, j] - s[i, j] * (z[0, 0] - z[lenthx - 1, 0] - z[0, lenthy - 1] + z[lenthx - 1, lenthy - 1])) / (xx[0] * yy[0] - xx[lenthx - 1] * yy[0] - xx[0] * yy[lenthy - 1] + xx[lenthx - 1] * yy[lenthy - 1]);
                        e = (z[i - 1, j - 1] - z[i, j - 1] - s[i, j] * (z[0, 0] - z[lenthx - 1, 0]) - g * (xx[0] * yy[0] - xx[lenthx - 1] * yy[0])) / (xx[0] - xx[lenthx - 1]);
                        f = (z[i - 1, j - 1] - z[i - 1, j] - s[i, j] * (z[0, 0] - z[0, lenthy - 1]) - g * (xx[0] * yy[0] - xx[0] * yy[lenthy - 1])) / (yy[0] - yy[lenthy - 1]);
                        k = z[i, j] - e * xx[lenthx - 1] - f * yy[lenthy - 1] - s[i, j] * z[lenthx - 1, lenthy - 1] - g * xx[lenthx - 1] * yy[lenthy - 1];
                        for (int m = 0; m < lenthx; m++)
                        {
                            for (int n = 0; n < lenthy; n++)
                            {
                               /* if (xx[m] >= xx[lenthx - 2] && xx[m] < xx[lenthx - 1])
                                {
 
                                }*/
                                zz[(i-1) * lenthx + m, (j-1) * lenthy + n] = e * xx[m] + f * yy[n] + g * xx[m] * yy[n] + s[i, j] * z[m, n] + k;
                            }
                        }
                      
                    }         
                }
                return zz;
        }

    }
}
