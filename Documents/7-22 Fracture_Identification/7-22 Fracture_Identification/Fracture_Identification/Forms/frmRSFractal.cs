using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.IO;

namespace Fracture_Identification
{
    public partial class frmRSFractal : Form
    {
        public frmRSFractal(frmMain parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
            
        }
        public frmRSFractal()
        {
            InitializeComponent();           

        }
        public frmRSFractal(string str)
        {
            InitializeComponent();
            this.Text = str;

        }
        List<OrignData> dataList = new List<OrignData>();
        PointPairList logRSlogN = new PointPairList();
        double resTop, resBottom, intTop, intBottom;//地层的顶底深，计算区间的顶底深
        double fracDim = 0;
        private void frmRSFractal_Load(object sender, EventArgs e)
        {
            //this.zed2DAdvancedProcess = new ZedGraphControl();
            this.zedGraphRS.GraphPane.Title.Text = "R/S分形法裂缝识别";
            this.zedGraphRS.GraphPane.XAxis.Title.Text = "log(n)";
            this.zedGraphRS.GraphPane.YAxis.Title.Text = "log(R(n)/S(n))";
            this.zedGraphRS.GraphPane.CurveList.Clear();

            ////this.zed2DAdvancedProcess.GraphPane.YAxis.Scale.Max = 1.0;
            //this.zedGraphRS.GraphPane.YAxis.Scale.Min = 0.0;
            //this.zedGraphRS.GraphPane.XAxis.Scale.Min = 0;

            //PointPairList probability = new PointPairList();
            //PointPairList accumprobability = new PointPairList();
            //probability.Add(i + 1, porediameter[i] * 1.0 / sum);    
            //LineItem curve1, curve2;
            //curve1 = this.zedGraphRS.GraphPane.AddCurve("概率分布", probability, Color.DarkGreen, SymbolType.Circle);
            //curve2 = this.zedGraphRS.GraphPane.AddCurve("累积概率", accumprobability, Color.Red, SymbolType.Square);

            //this.zedGraphRS.AxisChange();
            //this.zedGraphRS.Refresh();
        }

        private void btnReadRSData_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TXT文本文件|*.txt|ALL FILES|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtRSDataFile.Text = ofd.FileName;
                //orignBMPPath = ofd.FileName;
            }
            else
            {
                return;
            }
            List<string> strReader = new List<string>();

            #region readdata
            //将文件按行写入字符串数组
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = File.OpenRead(this.txtRSDataFile.Text);

                sr = new StreamReader(fs, Encoding.Default);
                while (!sr.EndOfStream)
                {
                    strReader.Add(sr.ReadLine());
                }
            }
            catch
            {
                MessageBox.Show("数据导入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (fs != null)
                {
                    sr.Close();
                }
                if (sr != null)
                {
                    fs.Close();
                }
            }

            #endregion readdata

            #region initialdata
            try
            {
                dataList.Clear();
                //文件前七行为说明字符，跳过
                for (int i = 7; i < strReader.Count; i++)//搜索一级标签
                {
                    string strTemp = "";
                    strTemp = strReader[i].Trim();
                    if (strTemp == "")
                    {
                        continue;
                    }
                    while (strTemp.Contains("\t"))
                    {
                        strTemp = strTemp.Replace("\t", " ");
                    }

                    OrignData od = new OrignData();
                    int iStart;
                    iStart = strTemp.IndexOf(" ");
                    od.depth = float.Parse(strTemp.Substring(0, iStart)); 
                    strTemp = strTemp.Remove(0, iStart + 1).Trim();

                    iStart = strTemp.IndexOf(" ");
                    od.ac = float.Parse(strTemp.Substring(0, iStart)); //日产量

                    dataList.Add(od);
                  
                    //    iStart = strTemp.IndexOf(" ");
                    //    bd.Density_Water = double.Parse(strTemp.Substring(0, iStart)); //地层水密度
                    //    strTemp = strTemp.Remove(0, iStart + 1).Trim();

                    //    iStart = strTemp.IndexOf(" ");
                    //    bd.Density_Oil = double.Parse(strTemp.Substring(0, iStart)); //地层油密度
                    //    strTemp = strTemp.Remove(0, iStart + 1).Trim();

                    //    iStart = strTemp.IndexOf(" ");
                    //    bd.Factor_Volume = double.Parse(strTemp.Substring(0, iStart)); //体积系数
                    //    strTemp = strTemp.Remove(0, iStart + 1).Trim();

                    //    //iStart = strTemp.IndexOf(" ");
                    //    bd.Porosity = double.Parse(strTemp); //孔隙度 
                    //    //strTemp = strTemp.Remove(0, iStart + 1).Trim();

                    //    dataList.Add(bd);
                    //}

                }
                if (dataList.Count < 1)
                {
                    dataList = null;
                }
            }
            catch
            {
                dataList = null;
                MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion initialdata

            List<double> depth = new List<double>();
            for (int j = 0; j < dataList.Count;j++ )
            {
                depth.Add(dataList[j].depth);
            }
            resTop = depth.Min();
            resBottom = depth.Max();

            intTop = resTop;
            intBottom = resBottom;

            this.txtResTop.Text = resTop.ToString("N2");
            this.txtResBottom.Text = resBottom.ToString("N2");
            this.txtIntTop.Text = intTop.ToString("N2");
            this.txtIntBottom.Text = intBottom.ToString("N2");
            //RSFractalIdent();
        }

        private void RSFractalIdent0(int startindex,int endindex)
        {
            
            logRSlogN.Clear();
            int datanum = this.dataList.Count;
            //double Rn, Sn, Rnterm1, Rnterm2, Snterm1, Snterm2;
            double maxZ, minZ;
            //int i = 0;//记录n的个数
            List<double> Z = new List<double>();
            //
            //for (int n = 2; n <= 100; n++)//n--间隔
            int m = 1;
            int n = 2;
            int Num = (dataList.Count - m) / n;

            Z.Clear();
            //计算距离
            for (int j = 0; j < dataList.Count - n; )
            {
                for (int u = j + n; u < dataList.Count; )
                {
                    Z.Add(Math.Abs(dataList[u].ac - dataList[j].ac));
                    u = u + n;
                }
                j = j + n;
            }
            maxZ = Z.Max();
            minZ = Z.Min();

            double deltaZ = (maxZ - minZ) / 50;
            double standZ;
            double cr;

            for (int i = 0; i < 19; i++)
            {
                standZ = minZ + (i + 1) * deltaZ;
                cr = 0;

                for (int k = 0; k < Z.Count; k++)
                {
                    if (Z[k] <= standZ) cr++;
                }
                cr = cr / Num / Num;
                logRSlogN.Add(Math.Log(standZ), Math.Log(cr));

            }
            this.zedGraphRS.GraphPane.CurveList.Clear();
            LineItem curve1;
            curve1 = this.zedGraphRS.GraphPane.AddCurve("**", logRSlogN, Color.DarkGreen, SymbolType.Circle);

            curve1.Line.IsVisible = false;
            curve1.Label.IsVisible = false;
            this.zedGraphRS.AxisChange();
            this.zedGraphRS.Refresh();
        }
        
        private void RSFractalIdent(int startindex, int endindex)
        {

            logRSlogN.Clear();
            //int datanum = this.dataList.Count; 
            int datanum = endindex - startindex;
            //double Rn, Sn, Rnterm1, Rnterm2, Snterm1, Snterm2;
            double maxZ, minZ;
            //int i = 0;//记录n的个数
            List<double> Z = new List<double>();
            //
            //for (int n = 2; n <= 100; n++)//n--间隔
            int m = 1;
            int n = 2;
            int Num = (datanum - m) / n;

            Z.Clear();
            //计算距离
            for (int j = startindex; j < endindex - n; )
            {
                for (int u = j + n; u < endindex; )
                {
                    Z.Add(Math.Abs(dataList[u].ac - dataList[j].ac));
                    u = u + n;
                }
                j = j + n;
            }
            if (Z.Count == 0)
            {
                return;
            }
            maxZ = Z.Max();
            minZ = Z.Min();

            double deltaZ = (maxZ - minZ) / 50;
            double standZ;
            double cr;

            for (int i = 0; i < 19; i++)
            {
                standZ = minZ + (i + 1) * deltaZ;
                cr = 0;

                for (int k = 0; k < Z.Count; k++)
                {
                    if (Z[k] <= standZ) cr++;
                }
                cr = cr / Num / Num;
                logRSlogN.Add(Math.Log(standZ), Math.Log(cr));

            }
            this.zedGraphRS.GraphPane.CurveList.Clear();
            LineItem curve1;
            curve1 = this.zedGraphRS.GraphPane.AddCurve("**", logRSlogN, Color.DarkGreen, SymbolType.Circle);

            curve1.Line.IsVisible = false;
            curve1.Label.IsVisible = false;
            this.zedGraphRS.AxisChange();
            this.zedGraphRS.Refresh();
        }
        private void RSFractalIdent2()
        {
            //int[] tau = {  10, 20, 30, 40, 50, 60, 80, 100, 150, 200,250,300 };
            int[] tau = new int[50];
            for (int i = 2; i < 52; i++)
            {
                tau[i - 2] = i * 4;
            }
            List<double> R = new List<double>();
            List<double> S = new List<double>();
            List<double> RS = new List<double>();
            List<double> Ztemp = new List<double>(); 
            int N = this.dataList.Count;
            logRSlogN.Clear();

            int tau0 = 0;
            for (int taui = 0; taui < tau.Length; taui++)
            {
                R.Clear();
                S.Clear();
                RS.Clear();
                tau0 = tau[taui];
                for (int jstart = 0; jstart < N - tau0; )
                {
                    double sumdata = 0;
                    for (int m = jstart; m <= jstart + tau0; m++)
                    {
                        sumdata += dataList[m].ac;
                    }
                    double avgdata = sumdata / (tau0 + 1);
                    ////Rj(tau)////
                    double maxdata = 0, mindata = 0;
                    Ztemp.Clear();
                    for (int lmd = jstart; lmd <= jstart + tau0; lmd++)
                    {
                        double ztempsum = 0;
                        for (int k = jstart; k <= lmd; k++)
                        {
                            ztempsum += dataList[k].ac - avgdata;
                        }
                        Ztemp.Add(ztempsum);
                    }
                    maxdata = Ztemp.Max();
                    mindata = Ztemp.Min();
                    R.Add(maxdata - mindata);
                    //////
                    ////Sj(tau)//////
                    double Stemp = 0;
                    for (int m = jstart; m <= jstart + tau0; m++)
                    {
                        Stemp += (dataList[m].ac - avgdata) * (dataList[m].ac - avgdata);
                    }
                    Stemp = Stemp / (tau0 + 1);

                    S.Add(Stemp);
                    RS.Add((maxdata - mindata) / Stemp);
                    jstart = jstart + 10;
                    //jstart = jstart + (int)((N - tau0) / 20);
                }

                logRSlogN.Add(Math.Log10(tau0), Math.Log10(RS.Average()));
            }
            
            this.zedGraphRS.GraphPane.CurveList.Clear();
            LineItem curve1;
            curve1 = this.zedGraphRS.GraphPane.AddCurve("**", logRSlogN, Color.DarkGreen, SymbolType.Circle);

            curve1.Line.IsVisible = false;
            curve1.Label.IsVisible = false;
            this.zedGraphRS.AxisChange();
            this.zedGraphRS.Refresh();
        }

        private void Zuixiaoercheng()
        {
            int count = logRSlogN.Count;
            if (count == 0) return;

            double avgx, avgy;
            avgx = 0; avgy = 0;
            for (int i = 0; i < count; i++)
            {
                avgx += logRSlogN[i].X;
                avgy += logRSlogN[i].Y;
            }
            avgx = avgx / count;
            avgy = avgy / count;
            double slope = 0;
            double temp1 = 0, temp2 = 0;
            for (int i = 0; i < count; i++)
            {
                temp1 += (logRSlogN[i].X - avgx) * (logRSlogN[i].Y - avgy);
                temp2 += (logRSlogN[i].X - avgx) * (logRSlogN[i].X - avgx);
            }
            slope = temp1 / temp2;
            double x0 = 0;
            x0 = avgy - slope * avgx;
            double x1, y1, x2, y2;
            x2 = logRSlogN[0].X - 1;
            y2 = slope * x2 + x0;
            x1 = logRSlogN[logRSlogN.Count - 1].X + 1;
            y1 = slope * x1 + x0;

            fracDim = slope;
            PointPairList linedata = new PointPairList();
            linedata.Add(x2, y2);
            linedata.Add(x1, y1);
            LineItem curve2;
            curve2 = this.zedGraphRS.GraphPane.AddCurve("**",linedata, Color.Black, SymbolType.None);

            curve2.Label.IsVisible = false;
            this.zedGraphRS.AxisChange();
            this.zedGraphRS.Refresh();

            this.txtBoxDimF.Text = fracDim.ToString("N2");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSCalByIntervalDepths();
        }

        private void RSCalByIntervalDepths()
        {
            try
            {
                intTop = (double.Parse(this.txtIntTop.Text));
                intBottom = double.Parse(this.txtIntBottom.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("区间顶底数据有误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (intTop >= intBottom)
            {
                MessageBox.Show("区间顶底数据有误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int startindex, endindex;
            startindex = 0;
            endindex = dataList.Count;
            for (int i = 0; i < dataList.Count; i++)
            {
                if (intTop <= dataList[i].depth)
                {
                    startindex = i;
                    break;
                }
            }
            for (int i = 0; i < dataList.Count; i++)
            {
                if (intBottom < dataList[i].depth)
                {
                    endindex = i;
                    break;
                }
            }
            RSFractalIdent(startindex, endindex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RSFractalIdent2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Zuixiaoercheng();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.txtIntTop.Text = this.txtIntBottom.Text;
        }

        //private void frmRSFractal_KeyDown(object sender, KeyEventArgs e)
        //{

        //}

        private void txtIntBottom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RSCalByIntervalDepths();
                Zuixiaoercheng();
            }
        }
    }
}
