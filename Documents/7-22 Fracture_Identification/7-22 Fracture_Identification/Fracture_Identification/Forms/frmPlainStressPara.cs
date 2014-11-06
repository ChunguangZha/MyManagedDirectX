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
    public partial class frmPlainStressPara : Form
    {
        public frmPlainStressPara(frmMain parent)
        {
            InitializeComponent();
            this.MdiParent = parent;

        }
        public frmPlainStressPara()
        {
            InitializeComponent();
            //this.MdiParent = parent;

        }
        List<data3> gridData = new List<data3>();
        //List<data3> minStress = new List<data3>();//最小主曲率
        //List<data3> maxStress = new List<data3>();//最大主曲率
        List<data3> minStress = new List<data3>();//最小主应力
        List<data3> maxStress = new List<data3>();//最大主应力
        List<data3> maxShear = new List<data3>();//最大剪应力
        int NX, NY;
        double E, v, thickness;

        public double Para_Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public double Para_V
        {
            get { return v; }
            set { v = value; }
        }

        public double Para_E
        {
            get { return E; }
            set { E = value; }
        }

        private void btnShearAnalysis_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sd = new SaveFileDialog();
            //sd.Filter = "TXT文本文件|*.txt|ALL FIlES|*.*";
            //DialogResult dr = sd.ShowDialog();
            //if (dr == DialogResult.OK)
            //{
            //    this.txtFracData.Text = sd.FileName;
            //}
            //else
            //{ 
            //    return; 
            //}
            //E = 10000;
            //v = 0.24;
            //thickness = 10;
            //TectonicStressAnalysis();
            ////List<double> xx = new List<double>();
            ////List<double> yy = new List<double>();
            ////for (int i = 0; i < gridData.Count; i++)
            ////{
            ////    xx.Add(gridData[i].xx);
            ////    yy.Add(gridData[i].yy);
            ////}
            //string str1, str2, str, str3;
            //int length = sd.FileName.Length;
            //str1 = sd.FileName.Substring(0, length - 4) + "maxStress.txt";
            //str2 = sd.FileName.Substring(0, length - 4) + "minStress.txt";
            //str3 = sd.FileName.Substring(0, length - 4) + "maxShear.txt";
            //for (int i = 0; i < maxStress.Count; i++)
            //{
            //    str = maxStress[i].xx.ToString() + " " + maxStress[i].yy.ToString() + " " + maxStress[i].zz.ToString();
            //    CreatFile(str1, str);
            //}
            //for (int i = 0; i < minStress.Count; i++)
            //{
            //    str = minStress[i].xx.ToString() + " " + minStress[i].yy.ToString() + " " + minStress[i].zz.ToString();
            //    CreatFile(str2, str);
            //}
            //for (int i = 0; i < maxShear.Count; i++)
            //{
            //    str = maxShear[i].xx.ToString() + " " + maxShear[i].yy.ToString() + " " + maxShear[i].zz.ToString();
            //    CreatFile(str3, str);
            //}
            //this.btnMaxStress.Enabled = true;
            //this.btnMinStress.Enabled = true;
            //this.btnMaxShearing.Enabled = true;
        }

        private void TectonicStressAnalysis()
        {
        //    //double[] x = new double[NX];
        //    //double[] y = new double[NY];
        //    double[,] z = new double[NY, NX];
        //    double[,] maxtecstr = new double[NY, NX];
        //    double[,] minptecstr = new double[NY, NX];
        //    double[,] maxs = new double[NY, NX];
        //    //double[,] maxtecstr = new double[NY, NX];
        //    //double[,] minptecstr = new double[NY, NX];
        //    double dx, dy;
        //    for (int i = 0; i < NY; i++)
        //    {
        //        for (int j = 0; j < NX; j++)
        //        {
        //            z[i, j] = gridData[i * NX + j].zz;
        //        }
        //    }
        //    dx = Math.Abs(gridData[1].xx - gridData[0].xx);
        //    dy = Math.Abs(gridData[NX].yy - gridData[0].yy);

        //    if (dx == 0 || dy == 0)
        //    {
        //        MessageBox.Show("网格数据错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    double dfdxx, dfdyy, dfdxdy, tmp1, tmp2, res1, res2;
        //    double sigmaxx, sigmayy, sigmaxy;
        //    # region 中间区域主曲率
        //    for (int i = 1; i < NY - 1; i++)
        //    {
        //        for (int j = 1; j < NX - 1; j++)
        //        {
        //            dfdxx = 0; dfdyy = 0; dfdxdy = 0;
        //            dfdxx = (z[i, j - 1] - z[i, j] - z[i, j] + z[i, j + 1]) / dx / dx;
        //            dfdyy = (z[i - 1, j] - z[i, j] - z[i, j] + z[i + 1, j]) / dy / dy;
        //            dfdxdy = (z[i + 1, j + 1] - z[i - 1, j + 1] - z[i + 1, j - 1] + z[i - 1, j - 1]) / 4 / dx / dy;
        //            if (dfdxx == 0)
        //            {
        //                MessageBox.Show("dfdxx==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //            if (dfdyy == 0)
        //            {
        //                MessageBox.Show("dfdyy==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //            if (dfdxdy == 0)
        //            {
        //                MessageBox.Show("dfdxdy==0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //            dfdxx = 1.0 / dfdxx;
        //            dfdyy = 1.0 / dfdyy;
        //            dfdxdy = 1.0 / dfdxdy;
        //            sigmaxx = E * thickness / 2 / (1 - v * v) * (dfdxx + dfdyy * v);
        //            sigmayy = E * thickness / 2 / (1 - v * v) * (dfdyy + dfdxx * v);
        //            sigmaxy = E * thickness / 2 / (1 + v) * dfdxdy;
        //            tmp1 = 0; tmp2 = 0;
        //            tmp1 = (sigmaxx + sigmayy) / 2;
        //            tmp2 = Math.Sqrt((sigmaxx - sigmayy) * (sigmaxx - sigmayy) / 4 + sigmaxy * sigmaxy);

        //            res1 = tmp1 + tmp2;
        //            res2 = tmp1 - tmp2;
        //            if (res1 > res2)
        //            {
        //                maxtecstr[i, j] = res1;
        //                minptecstr[i, j] = res2;
        //            }
        //            else
        //            {
        //                maxtecstr[i, j] = res2;
        //                minptecstr[i, j] = res1;
        //            }
        //            maxs[i, j] = (maxtecstr[i, j] - minptecstr[i, j]) / 2;                    
        //        }
        //    }

        //    #endregion

        //    for (int j = 1; j < NX - 1; j++)
        //    {
        //        maxtecstr[0, j] = maxtecstr[1, j];
        //        minptecstr[0, j] = minptecstr[1, j];
        //        maxtecstr[NY - 1, j] = maxtecstr[NY - 2, j];
        //        minptecstr[NY - 1, j] = minptecstr[NY - 2, j];
        //        maxs[0, j] = maxs[1, j];
        //        maxs[NY - 1, j] = maxs[NY - 2, j];
        //    }
        //    for (int i = 0; i < NY; i++)
        //    {
        //        maxtecstr[i, 0] = maxtecstr[i, 1];
        //        minptecstr[i, 0] = minptecstr[i, 1];
        //        maxtecstr[i, NX - 1] = maxtecstr[i, NX - 2];
        //        minptecstr[i, NX - 1] = minptecstr[i, NX - 2];
        //        maxs[i, 0] = maxs[i, 1];
        //        maxs[i, NX - 1] = maxs[i, NX - 2];
        //    }
        //    data3 d1 = new data3();
        //    data3 d2 = new data3(); 
        //    data3 d3 = new data3();
        //    for (int i = 0; i < NY; i++)
        //    {
        //        for (int j = 0; j < NX; j++)
        //        {
        //            d1.xx = gridData[i * NX + j].xx;
        //            d1.yy = gridData[i * NX + j].yy;

        //            d2.xx = d1.xx;
        //            d2.yy = d1.yy; 
        //            d3.xx = d1.xx;
        //            d3.yy = d1.yy;

        //            d1.zz = maxtecstr[i, j];
        //            d2.zz = minptecstr[i, j];
        //            d3.zz = maxs[i, j];

        //            maxStress.Add(d1);
        //            minStress.Add(d2);
        //            maxShear.Add(d3);
        //        }
        //    }
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
            //OpenFileDialog ofd = new OpenFileDialog();
            ////ofd.Filter = "*.txt(XYZ)|*txt|*.grd(ASC网格数据)|*grd|*.*(所有文件)|*.*"; 
            //ofd.Filter = "*.txt(XYZ)|*txt|*.*(所有文件)|*.*";
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    this.txtGridData.Text = ofd.FileName;
            //    #region txt文件
            //    if (ofd.FileName.Contains(".txt"))
            //    {
            //        List<string> ls = new List<string>();
            //        System.IO.StreamReader file1 = null;
            //        try
            //        {
            //            file1 = new System.IO.StreamReader(ofd.FileName);
            //            while (!file1.EndOfStream)
            //            {
            //                ls.Add(file1.ReadLine());
            //            }
            //        }
            //        catch
            //        {
            //            MessageBox.Show("数据导入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        finally
            //        {
            //            if (file1 != null)
            //            {
            //                file1.Close();
            //            }
            //        }
            //        try
            //        {
            //            gridData.Clear();
            //            string line = "";
            //            data3 dd = new data3();
            //            for (int i = 0; i < ls.Count; i++)
            //            {
            //                line = ls[i].Trim();
            //                string[] splitStr = line.Split(' ', '\t');
            //                dd.xx = Convert.ToDouble(splitStr[0]);
            //                dd.yy = Convert.ToDouble(splitStr[1]);
            //                dd.zz = Convert.ToDouble(splitStr[2]);
            //                gridData.Add(dd);
            //            }
            //        }
            //        catch
            //        {
            //            gridData = null;
            //            MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //        double tmp = gridData[0].xx;
            //        NX = 0;
            //        for (int i = 1; i < gridData.Count; i++)
            //        {
            //            NX++;
            //            if (tmp == gridData[i].xx) break;                        
            //        }
            //        if (NX <= 1)
            //        {
            //            MessageBox.Show("请确认数据文件是否为网格化数据！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //        NY = (int)(gridData.Count / NX);

            //        if (NY == 1 || NX * NY != gridData.Count)
            //        {
            //            MessageBox.Show("请确认数据文件是否为网格化数据！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        //double[] x = new double[gridData.Count];
            //        //double[] y = new double[gridData.Count];
            //        //double[] z = new double[gridData.Count];
            //        //for (int i = 0; i < gridData.Count; i++)
            //        //{
            //        //    x[i] = gridData[i].xx;
            //        //    y[i] = gridData[i].yy;
            //        //    z[i] = gridData[i].zz;
            //        //}
            //        //List<double> xx = new List<double>();
            //        //List<double> yy = new List<double>();
            //        //for (int i = 0; i < gridData.Count; i++)
            //        //{
            //        //    xx.Add(gridData[i].xx);
            //        //    yy.Add(gridData[i].yy);
            //        //}

            //        //MaxX = xx.Max();
            //        //MinX = xx.Min();
            //        //MaxY = yy.Max();
            //        //MinY = yy.Min();
            //        //mapForm mf = new mapForm(flag);
            //        //mf.x = x;
            //        //mf.y = y;
            //        //mf.z = z;
            //        //mf.MaxX = MaxX;
            //        //mf.MinX = MinX;
            //        //mf.MaxY = MaxY;
            //        //mf.MinY = MinY;
            //        //mf.MdiParent = this;
            //        //mf.Show();
            //    }
            //    #endregion

            //    #region grd|asc文件
            //    //if (ofd.FileName.Contains(".grd"))
            //    //{
            //    //    List<string> ls = new List<string>();
            //    //    List<data> ld1 = new List<data>();
            //    //    System.IO.StreamReader file1 = null;
            //    //    try
            //    //    {
            //    //        file1 = new System.IO.StreamReader(ofd.FileName, Encoding.ASCII);
            //    //        while (!file1.EndOfStream)
            //    //        {
            //    //            ls.Add(file1.ReadLine());
            //    //        }
            //    //    }
            //    //    catch
            //    //    {
            //    //        MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //        return;
            //    //    }
            //    //    finally
            //    //    {
            //    //        if (file1 != null)
            //    //        {
            //    //            file1.Close();
            //    //        }
            //    //    }
            //    //    try
            //    //    {
            //    //        ld.Clear();
            //    //        string line = "";
            //    //        data dd2 = new data();
            //    //        if (ls[0] == "DSAA")
            //    //        {
            //    //            for (int i = 1; i < 5; i++)
            //    //            {
            //    //                line = ls[i].Trim();
            //    //                string[] splitString1 = line.Split(' ', '\t');
            //    //                dd2.xx = Convert.ToDouble(splitString1[0]);
            //    //                dd2.yy = Convert.ToDouble(splitString1[1]);
            //    //                ld1.Add(dd2);
            //    //            }
            //    //            nx = Convert.ToInt32(ld1[0].xx);
            //    //            ny = Convert.ToInt32(ld1[0].yy);
            //    //            MinX = ld1[1].xx;
            //    //            MaxX = ld1[1].yy;
            //    //            MinY = ld1[2].xx;
            //    //            MaxY = ld1[2].yy;
            //    //            int k = 0;
            //    //            double[] zz = new double[nx * ny];
            //    //            double[] xx = new double[nx];
            //    //            double[] yy = new double[ny];
            //    //            for (int i = 5; i < ls.Count; i++)
            //    //            {
            //    //                if (ls[i] == "")
            //    //                {
            //    //                    continue;
            //    //                }
            //    //                line = ls[i].Trim();
            //    //                string[] splitString = line.Split(' ');
            //    //                for (int j = 0; j < splitString.Length; j++)
            //    //                {
            //    //                    zz[k++] = Convert.ToDouble(splitString[j]);
            //    //                }
            //    //            }
            //    //            xlevel = (MaxX - MinX) / (nx - 1);
            //    //            ylevel = (MaxY - MinY) / (ny - 1);
            //    //            for (int i = 0; i < nx; i++)
            //    //            {
            //    //                xx[i] = MinX + i * xlevel;
            //    //            }
            //    //            for (int i = 0; i < ny; i++)
            //    //            {
            //    //                yy[i] = MinY + i * ylevel;
            //    //            }
            //    //            mapForm mf = new mapForm(flag);
            //    //            mf.x = xx;
            //    //            mf.y = yy;
            //    //            mf.z = zz;
            //    //            mf.MaxX = MaxX;
            //    //            mf.MinX = MinX;
            //    //            mf.MaxY = MaxY;
            //    //            mf.MinY = MinY;
            //    //            mf.MdiParent = this;
            //    //            mf.Show();
            //    //        }
            //    //    }
            //    //    catch
            //    //    {
            //    //        ld = null;
            //    //        MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //        return;
            //    //    }
            //    //}
            //    #endregion

            //    this.txtNX.Text = NX.ToString();
            //    this.txtNY.Text = NY.ToString();
            //    this.btnShearAnalysis.Enabled = true;
            //}
            //else
            //{
            //    return;
            //}
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                E = double.Parse(this.txtY.Text);
                v = double.Parse(this.txtPr.Text);
                thickness = double.Parse(this.txtThickness.Text);
                //return DialogResult.OK;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("参数输入有误！", "错误", MessageBoxButtons.OK);
                //return DialogResult.Cancel;
            }
            
        }
        //private DialogResult btn_OK_Click1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        E = double.Parse(this.txtY.Text);
        //        v = double.Parse(this.txtPr.Text);
        //        thickness = double.Parse(this.txtThickness.Text);
        //        return DialogResult.OK;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show("参数输入有误！", "错误", MessageBoxButtons.OK);
        //        return DialogResult.Cancel;
        //    }

        //}
    }
}
