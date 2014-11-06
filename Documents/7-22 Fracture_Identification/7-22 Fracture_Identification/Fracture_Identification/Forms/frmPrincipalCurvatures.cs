using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fractal.newClass;
using System.IO;

namespace Fracture_Identification
{
    public partial class frmPrincipalCurvatures : Form
    {
        public frmPrincipalCurvatures(frmMain parent)
        {
            InitializeComponent();
            this.MdiParent = parent;

        }
        public frmPrincipalCurvatures()
        {
            InitializeComponent();         

        }
        List<data3> gridData = new List<data3>();
        List<data3> minCur = new List<data3>();//最小主曲率
        List<data3> maxCur = new List<data3>();//最大主曲率
        int NX, NY;
        private void btnFracIden_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "TXT文本文件|*.txt|ALL FIlES|*.*";
            DialogResult dr = sd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.txtFracData.Text = sd.FileName;
            }
            else
            { 
                return; 
            }
            PrincipalCurvaturesFI();
            //List<double> xx = new List<double>();
            //List<double> yy = new List<double>();
            //for (int i = 0; i < gridData.Count; i++)
            //{
            //    xx.Add(gridData[i].xx);
            //    yy.Add(gridData[i].yy);
            //}
            string str1, str2, str;
            int length = sd.FileName.Length;
            str1 = sd.FileName.Substring(0, length - 4) + "max.txt";
            str2 = sd.FileName.Substring(0, length - 4) + "min.txt";
            for (int i = 0; i < maxCur.Count; i++)
            {
                str = maxCur[i].xx.ToString() + " " + maxCur[i].yy.ToString() + " " + maxCur[i].zz.ToString();
                CreatFile(str1, str);
            }
            for (int i = 0; i < minCur.Count; i++)
            {
                str = minCur[i].xx.ToString() + " " + minCur[i].yy.ToString() + " " + minCur[i].zz.ToString();
                CreatFile(str2, str);
            }
            this.btnMaxCur.Enabled = true;
            this.btnMinCur.Enabled = true;
        }

        private void PrincipalCurvaturesFI()
        {
            //double[] x = new double[NX];
            //double[] y = new double[NY];
            double[,] z = new double[NY, NX];
            double[,] maxpcur = new double[NY, NX];
            double[,] minpcur = new double[NY, NX];
            double dx, dy;
            for (int i = 0; i < NY; i++)
            {
                for (int j = 0; j < NX; j++)
                {
                    z[i, j] = gridData[i * NX + j].zz;
                }
            }
            dx = Math.Abs(gridData[1].xx - gridData[0].xx);
            dy = Math.Abs(gridData[NX].yy - gridData[0].yy);

            if (dx == 0 || dy == 0)
            {
                MessageBox.Show("网格数据错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double dfdxx, dfdyy, dfdxdy, tmp1, tmp2, res1, res2;

            # region 中间区域主曲率
            for (int i = 1; i < NY - 1; i++)
            {
                for (int j = 1; j < NX - 1; j++)
                {
                    dfdxx = 0; dfdyy = 0; dfdxdy = 0;
                    dfdxx = (z[i, j - 1] - z[i, j] - z[i, j] + z[i, j + 1]) / dx / dx;
                    dfdyy = (z[i - 1, j] - z[i, j] - z[i, j] + z[i + 1, j]) / dy / dy;
                    dfdxdy = (z[i + 1, j + 1] - z[i - 1, j + 1] - z[i + 1, j - 1] + z[i - 1, j - 1]) / 4 / dx / dy;
                    if (dfdxx == 0)
                    {
                        MessageBox.Show("dfdxx==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dfdyy == 0)
                    {
                        MessageBox.Show("dfdyy==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dfdxdy == 0)
                    {
                        MessageBox.Show("dfdxdy==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dfdxx = 1.0 / dfdxx;
                    dfdyy = 1.0 / dfdyy;
                    dfdxdy = 1.0 / dfdxdy;
                    tmp1 = 0; tmp2 = 0;
                    tmp1 = (dfdxx + dfdyy) / 2;
                    tmp2 = Math.Sqrt((dfdxx - dfdyy) * (dfdxx - dfdyy) / 4 + dfdxdy * dfdxdy);

                    res1 = tmp1 + tmp2;
                    res2 = tmp1 - tmp2;
                    if (res1 > res2)
                    {
                        maxpcur[i, j] = res1;
                        minpcur[i, j] = res2;
                    }
                    else
                    {
                        maxpcur[i, j] = res2;
                        minpcur[i, j] = res1;
                    }
                }
            }

            #endregion

            for (int j = 1; j < NX - 1; j++)
            {
                maxpcur[0, j] = maxpcur[1, j];
                minpcur[0, j] = minpcur[1, j];
                maxpcur[NY - 1, j] = maxpcur[NY - 2, j];
                minpcur[NY - 1, j] = minpcur[NY - 2, j];
            }
            for (int i = 0; i < NY; i++)
            {
                maxpcur[i, 0] = maxpcur[i, 1];
                minpcur[i, 0] = minpcur[i, 1];
                maxpcur[i, NX - 1] = maxpcur[i, NX - 2];
                minpcur[i, NX - 1] = minpcur[i, NX - 2];
            }
            data3 d1 = new data3();
            data3 d2 = new data3();
            for (int i = 0; i < NY; i++)
            {
                for (int j = 0; j < NX; j++)
                {
                    d1.xx = gridData[i * NX + j].xx;
                    d1.yy = gridData[i * NX + j].yy;

                    d2.xx = d1.xx;
                    d2.yy = d1.yy;

                    d1.zz = maxpcur[i, j];
                    d2.zz = minpcur[i, j];

                    maxCur.Add(d1);
                    minCur.Add(d2);
                }
            }
        }

        private void btnMaxCur_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMinCur_Click(object sender, EventArgs e)
        {

        }

        private bool CreatFile(string FullFileName, string TextAll)
        {
            if (File.Exists(FullFileName))//文件存在，继续写入
            {
                StreamWriter sw = new StreamWriter(FullFileName, true, Encoding.Default);
                //该编码类型不会改变已有文件的编码类型
                sw.WriteLine(TextAll);
                sw.Close();
                return true;
            }
            else//不能存在，创建文件写入数据
            {
                try
                {
                    FileStream fs = new FileStream(FullFileName, FileMode.CreateNew);
                    fs.Close();
                    StreamWriter sw = new StreamWriter(FullFileName, true, Encoding.Default);
                    //该编码类型不会改变已有文件的编码类型
                    sw.WriteLine(TextAll);
                    sw.Close();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                    return false;
                }
            }
        }//写入数据

        private void btnReadGridData_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "*.txt(XYZ)|*txt|*.grd(ASC网格数据)|*grd|*.*(所有文件)|*.*"; 
            ofd.Filter = "*.txt(XYZ)|*txt|*.*(所有文件)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtGridData.Text = ofd.FileName;
                #region txt文件
                if (ofd.FileName.Contains(".txt"))
                {
                    List<string> ls = new List<string>();
                    System.IO.StreamReader file1 = null;
                    try
                    {
                        file1 = new System.IO.StreamReader(ofd.FileName);
                        while (!file1.EndOfStream)
                        {
                            ls.Add(file1.ReadLine());
                        }
                    }
                    catch
                    {
                        MessageBox.Show("数据导入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (file1 != null)
                        {
                            file1.Close();
                        }
                    }
                    try
                    {
                        gridData.Clear();
                        string line = "";
                        data3 dd = new data3();
                        for (int i = 0; i < ls.Count; i++)
                        {
                            line = ls[i].Trim();
                            string[] splitStr = line.Split(' ', '\t');
                            dd.xx = Convert.ToDouble(splitStr[0]);
                            dd.yy = Convert.ToDouble(splitStr[1]);
                            dd.zz = Convert.ToDouble(splitStr[2]);
                            gridData.Add(dd);
                        }
                    }
                    catch
                    {
                        gridData = null;
                        MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    double tmp = gridData[0].xx;
                    NX = 0;
                    for (int i = 1; i < gridData.Count; i++)
                    {
                        NX++;
                        if (tmp == gridData[i].xx) break;                        
                    }
                    if (NX <= 1)
                    {
                        MessageBox.Show("请确认数据文件是否为网格化数据！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    NY = (int)(gridData.Count / NX);

                    if (NY == 1 || NX * NY != gridData.Count)
                    {
                        MessageBox.Show("请确认数据文件是否为网格化数据！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //double[] x = new double[gridData.Count];
                    //double[] y = new double[gridData.Count];
                    //double[] z = new double[gridData.Count];
                    //for (int i = 0; i < gridData.Count; i++)
                    //{
                    //    x[i] = gridData[i].xx;
                    //    y[i] = gridData[i].yy;
                    //    z[i] = gridData[i].zz;
                    //}
                    //List<double> xx = new List<double>();
                    //List<double> yy = new List<double>();
                    //for (int i = 0; i < gridData.Count; i++)
                    //{
                    //    xx.Add(gridData[i].xx);
                    //    yy.Add(gridData[i].yy);
                    //}

                    //MaxX = xx.Max();
                    //MinX = xx.Min();
                    //MaxY = yy.Max();
                    //MinY = yy.Min();
                    //mapForm mf = new mapForm(flag);
                    //mf.x = x;
                    //mf.y = y;
                    //mf.z = z;
                    //mf.MaxX = MaxX;
                    //mf.MinX = MinX;
                    //mf.MaxY = MaxY;
                    //mf.MinY = MinY;
                    //mf.MdiParent = this;
                    //mf.Show();
                }
                #endregion

                #region grd|asc文件
                //if (ofd.FileName.Contains(".grd"))
                //{
                //    List<string> ls = new List<string>();
                //    List<data> ld1 = new List<data>();
                //    System.IO.StreamReader file1 = null;
                //    try
                //    {
                //        file1 = new System.IO.StreamReader(ofd.FileName, Encoding.ASCII);
                //        while (!file1.EndOfStream)
                //        {
                //            ls.Add(file1.ReadLine());
                //        }
                //    }
                //    catch
                //    {
                //        MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //    finally
                //    {
                //        if (file1 != null)
                //        {
                //            file1.Close();
                //        }
                //    }
                //    try
                //    {
                //        ld.Clear();
                //        string line = "";
                //        data dd2 = new data();
                //        if (ls[0] == "DSAA")
                //        {
                //            for (int i = 1; i < 5; i++)
                //            {
                //                line = ls[i].Trim();
                //                string[] splitString1 = line.Split(' ', '\t');
                //                dd2.xx = Convert.ToDouble(splitString1[0]);
                //                dd2.yy = Convert.ToDouble(splitString1[1]);
                //                ld1.Add(dd2);
                //            }
                //            nx = Convert.ToInt32(ld1[0].xx);
                //            ny = Convert.ToInt32(ld1[0].yy);
                //            MinX = ld1[1].xx;
                //            MaxX = ld1[1].yy;
                //            MinY = ld1[2].xx;
                //            MaxY = ld1[2].yy;
                //            int k = 0;
                //            double[] zz = new double[nx * ny];
                //            double[] xx = new double[nx];
                //            double[] yy = new double[ny];
                //            for (int i = 5; i < ls.Count; i++)
                //            {
                //                if (ls[i] == "")
                //                {
                //                    continue;
                //                }
                //                line = ls[i].Trim();
                //                string[] splitString = line.Split(' ');
                //                for (int j = 0; j < splitString.Length; j++)
                //                {
                //                    zz[k++] = Convert.ToDouble(splitString[j]);
                //                }
                //            }
                //            xlevel = (MaxX - MinX) / (nx - 1);
                //            ylevel = (MaxY - MinY) / (ny - 1);
                //            for (int i = 0; i < nx; i++)
                //            {
                //                xx[i] = MinX + i * xlevel;
                //            }
                //            for (int i = 0; i < ny; i++)
                //            {
                //                yy[i] = MinY + i * ylevel;
                //            }
                //            mapForm mf = new mapForm(flag);
                //            mf.x = xx;
                //            mf.y = yy;
                //            mf.z = zz;
                //            mf.MaxX = MaxX;
                //            mf.MinX = MinX;
                //            mf.MaxY = MaxY;
                //            mf.MinY = MinY;
                //            mf.MdiParent = this;
                //            mf.Show();
                //        }
                //    }
                //    catch
                //    {
                //        ld = null;
                //        MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //}
                #endregion

                this.txtNX.Text = NX.ToString();
                this.txtNY.Text = NY.ToString();
                this.btnFracIden.Enabled = true;
            }
            else
            {
                return;
            }
            
        }
    }
}
