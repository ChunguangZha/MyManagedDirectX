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
namespace fractal
{
    public partial class FormGrid : Form
    {
        public FormGrid()
        {
            InitializeComponent();
        }
        List<data3> ld = new List<data3>();//原始井数据
        List<data3> lb = new List<data3>();//原始边界数据
        List<data3> lc = new List<data3>();//原始相数据
        List<List<data3>> lld = new List<List<data3>>();//存放不同类别的数据
        double maxY, minY, maxX, minX;
        double x_edgion, y_edion;
        int cols, rows;
        private void RectGridData_Click(object sender, EventArgs e)//距离反比法
        {
            #region 距离反比网格化
            if (textBox1.Text != "" && ComboBoxMethord.SelectedItem.ToString() == "距离反比网格化"&&TBBind.Text==""&&TBFacies.Text=="")//无边界，用井数据作为边界
            {        
                try
                {
                    double[,] m_ppGridData = new double[rows, cols];
                    int tnumber = ld.Count;
                    double m_fGridX = 0;
                    double m_fGridY = 0;
                    double m_fGridZ = 0;
                    List<data3> ll = new List<data3>();//存网格数据
                    data3 d3 = new data3();
                    double m_fDist = 0;
                    for (int i = 0; i < rows; i++)    //i代表行号
                    {
                        m_fGridY = minY + i * y_edion;
                        for (int j = 0; j < cols; j++)  //j代表列号 
                        {
                            m_fGridX = minX + j * x_edgion;
                            //确定网格交点的高程值（距离平均）
                            m_ppGridData[i, j] = 0.0;
                            double m_fSumDist = 0;  //距离的倒数和
                            int k = 0;
                            List<data> list = new List<data>();
                            data dd = new data();
                            for (k = 0; k < tnumber; k++)
                            {
                                //计算每个绘图坐标点到网格交点的距离
                                m_fDist = (double)Math.Sqrt((ld[k].xx - m_fGridX) * (ld[k].xx - m_fGridX)
                                    + (ld[k].yy - m_fGridY) * (ld[k].yy - m_fGridY));
                                dd.xx = m_fDist;
                                dd.yy = ld[k].zz;
                                list.Add(dd);
                            }
                            list = GetFore4(list);
                            int l = 0;
                            for (l = 0; l < list.Count; l++)
                            {
                                if (list[l].xx == 0)
                                {
                                    m_fSumDist = 1; break;
                                }
                                else
                                {
                                    m_fSumDist += 1 / list[l].xx;
                                }
                                m_ppGridData[i, j] += list[l].yy / list[l].xx;
                            }
                            if (m_fSumDist == 1)
                            {
                                m_ppGridData[i, j] = list[l].yy;
                            }
                            else
                            {
                                m_ppGridData[i, j] = m_ppGridData[i, j] / m_fSumDist;
                            }
                            m_fGridZ = m_ppGridData[i, j];
                            //string str = m_fGridX.ToString() + " " + m_fGridY.ToString() + " " + m_fGridZ.ToString();
                            //CreatFile(textBox2.Text, str);
                            d3.xx = m_fGridX;
                            d3.yy = m_fGridY;
                            d3.zz = m_fGridZ;
                            ll.Add(d3);
                        }
                    }
                    MessageBox.Show("网格化成功！");
                    NewFile(textBox2.Text, ll);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("错误", "格式不正确", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (textBox1.Text != "" && ComboBoxMethord.SelectedItem.ToString() == "距离反比网格化" && TBBind.Text != "")//有工区边界则分为两种，若无岩相边界和有岩相边界
            {
                try
                {
                    double[,] m_ppGridData = new double[rows, cols];
                    int tnumber = ld.Count;
                    double m_fGridX = 0;
                    double m_fGridY = 0;
                    double m_fGridZ = 0;
                    List<data3> ll = new List<data3>();//存网格数据
                    data3 d3 = new data3();
                    for (int i = 0; i < rows; i++)    //i代表行号
                    {
                        m_fGridY = minY + i * y_edion;
                        for (int j = 0; j < cols; j++)  //j代表列号 
                        {
                            m_fGridX = minX + j * x_edgion;

                            //确定网格交点的高程值（距离平均）
                            d3.xx = m_fGridX;
                            d3.yy = m_fGridY;
                            d3.zz = m_fGridZ;
                            ll.Add(d3);
                        }
                    }
                    if (TBFacies.Text == "")//若无岩相边界直接在工区边界插值
                    {
                        ll = WGinCurve(ll, lb);//边界范围内的网格
                        ld = SDinCurve(ld, lb);//边界范围内的井
                        ll = InsertValue(ll, ld);//用ld井去在网格内插值
                        MessageBox.Show("网格化成功！");
                        NewFile(textBox2.Text, ll);
                        this.Close();
                    }
                    if (TBFacies.Text != "")//若有岩相边界直接在岩相内插值
                    {
                        for (int i = 0; i < lld.Count; i++)
                        {
                            List<data3> ld3 = new List<data3>();
                            List<data3> le3 = new List<data3>();//大区边界数据导入le3中
                            List<data3> lf3 = new List<data3>();//井数据导入lf3中
                            List<data3> lg3 = new List<data3>();
                            data3 da3 = new data3();
                            for (int j = 0; j < lld[i].Count; j++)
                            {
                                da3.xx = lld[i][j].xx;
                                da3.yy = lld[i][j].yy;
                                da3.zz = lld[i][j].zz;
                                ld3.Add(da3);
                            }

                            for (int l = 0; l < ll.Count; l++)
                            {
                                data3 dd3 = new data3();
                                dd3.xx = ll[l].xx;
                                dd3.yy = ll[l].yy;
                                dd3.zz = ll[l].zz;
                                le3.Add(dd3);
                            }
                            for (int l = 0; l < ld.Count; l++)
                            {
                                data3 dd3 = new data3();
                                dd3.xx = ld[l].xx;
                                dd3.yy = ld[l].yy;
                                dd3.zz = ld[l].zz;
                                lf3.Add(dd3);
                            }
                            le3 = SDinCurve(le3, ld3);//岩相范围内的网格
                            lf3 = SDinCurve(lf3, ld3);//各个岩相范围内的井
                            lg3 = InsertValue(le3, lf3);//在le3岩相范围内，用lf3中的数据进行插值
                            if (i == 0)
                            {
                                NewFileFacies(textBox2.Text, lg3, lld[i][0].zz);//第一个岩相新建文件
                            }
                            else
                            {
                                WriteFile(textBox2.Text, lg3,lld[i][0].zz);//第二个岩相直接输入文件中
                            }
                        }
                        MessageBox.Show("网格化成功！");
                        this.Close();
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    // MessageBox.Show("错误", "格式不正确", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion
            #region 随机分形距离反比网格化
            if (textBox1.Text != "" && ComboBoxMethord.SelectedItem.ToString() == "随机分形距离反比网格化")
            {
 
            }
            #endregion
            #region 克里金网格化
            if (textBox1.Text != "" && ComboBoxMethord.SelectedItem.ToString() == "克里金网格化")
            {

            }
            #endregion
        }
       /* public double[] sortDX(double []ld)//选择排序由大到小
        {
            double temp; 
            for (int i = 0; i < ld.Length - 1; i++) 
            { 
                for (int j = i; j < ld.Length; j++) 
                { 
                    if (ld[j] < ld[i]) 
                    { 
                        temp = ld[i]; 
                        ld[i] = ld[j];
                        ld[j] = temp;
                    }
                } 
            }
            return ld;
        }
        public double[] GetFore4(double[]ld)//取前4个最大的值
        {
            double[] ld4 = new double[4];
            ld = sortDX(ld);
            if (ld.Length > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    ld4[i] = ld[i];
                }
            }
            else
            {
                for (int i = 0; i < ld.Length; i++)
                {
                    ld4[i] = ld[i];
                }
            }
            return ld4;

        }*/
        private List<data> SortDX(List<data> ld)
        {
            ld = ld.OrderBy(n => n.xx).ToList();
            return ld;
        }//排序由小到大排列
        private List<data> GetFore4(List<data> ld)//取前n/2个距离计算点最近的原点
        {
            ld = SortDX(ld);
            List<data> ld4=new List<data>();
            if (ld.Count > ld.Count/2)
            {
                for (int i = 0; i < ld.Count/2; i++)
                {
                    ld4.Add(ld[i]);
                }
            }
            else
            {
                for (int i = 0; i < ld.Count; i++)
                {
                    ld4.Add(ld[i]);
                }
            }
            return ld4;
        }
     /*   private bool CreatFile(string FullFileName, string TextAll)
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
        }//写入数据*/
    /*    private bool NewFile(string name)
        {
            if (File.Exists(name))
            {
                if (DialogResult.OK == MessageBox.Show("替换存在的" + name + "?", "surfer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    File.Delete(name);
                    try
                    {
                        FileStream fs = new FileStream(name, FileMode.CreateNew);
                        fs.Close();
                        return true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message.ToString());
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    FileStream fs = new FileStream(name, FileMode.CreateNew);
                    fs.Close();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                    return false;
                }
            }
        }//判定是否新建文件*/
        private bool WriteFile(string FullFileName, List<data3> ll,double k)
          {
              if (File.Exists(FullFileName))//文件存在，继续写入
              {
                  StreamWriter sw = new StreamWriter(FullFileName, true, Encoding.Default);
                  //该编码类型不会改变已有文件的编码类型
                  for (int i = 0; i < ll.Count; i++)
                  {
                      sw.WriteLine(ll[i].xx.ToString() + " " + ll[i].yy.ToString() + " " + ll[i].zz.ToString()+" "+k.ToString());
                  }
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
                      for (int i = 0; i < ll.Count; i++)
                      {
                          sw.WriteLine(ll[i].xx.ToString() + " " + ll[i].yy.ToString() + " " + k.ToString());
                      }
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
        private bool NewFile(string name, List<data3> ll)
        {
            if (File.Exists(name))
            {
                if (DialogResult.OK == MessageBox.Show("替换存在的" + name + "?", "surfer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    File.Delete(name);
                    try
                    {
                        FileStream fs = new FileStream(name, FileMode.CreateNew);
                        fs.Close();
                        StreamWriter sw = new StreamWriter(name, true, Encoding.Default);
                        //该编码类型不会改变已有文件的编码类型
                        for (int i = 0; i < ll.Count; i++)
                        {
                            sw.WriteLine(ll[i].xx.ToString() + " " + ll[i].yy.ToString() + " " + ll[i].zz.ToString());
                        }
                        sw.Close();
                        return true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message.ToString());
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    FileStream fs = new FileStream(name, FileMode.CreateNew);
                    fs.Close();
                    StreamWriter sw = new StreamWriter(name, true, Encoding.Default);
                    //该编码类型不会改变已有文件的编码类型
                    for (int i = 0; i < ll.Count; i++)
                    {
                        sw.WriteLine(ll[i].xx.ToString() + " " + ll[i].yy.ToString() + " " + ll[i].zz.ToString());
                    }
                    sw.Close();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                    return false;
                }
            }
        }//判定是否新建文件
        private bool NewFileFacies(string name, List<data3> ll,double k)
        {
            if (File.Exists(name))
            {
                if (DialogResult.OK == MessageBox.Show("替换存在的" + name + "?", "surfer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    File.Delete(name);
                    try
                    {
                        FileStream fs = new FileStream(name, FileMode.CreateNew);
                        fs.Close();
                        StreamWriter sw = new StreamWriter(name, true, Encoding.Default);
                        //该编码类型不会改变已有文件的编码类型
                        for (int i = 0; i < ll.Count; i++)
                        {
                            sw.WriteLine(ll[i].xx.ToString() + " " + ll[i].yy.ToString() + " " + ll[i].zz.ToString()+" "+k.ToString());
                        }
                        sw.Close();
                        return true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message.ToString());
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    FileStream fs = new FileStream(name, FileMode.CreateNew);
                    fs.Close();
                    StreamWriter sw = new StreamWriter(name, true, Encoding.Default);
                    //该编码类型不会改变已有文件的编码类型
                    for (int i = 0; i < ll.Count; i++)
                    {
                        sw.WriteLine(ll[i].xx.ToString() + " " + ll[i].yy.ToString() + " " + ll[i].zz.ToString());
                    }
                    sw.Close();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                    return false;
                }
            }
        }//判定是否新建文件
        private List<data3> WGinCurve1(List<data3> ld, List<data3> ld1)//判断ld网格数据是否在闭合曲线ld1中
        {
            List<data3> fitY = new List<data3>();
            int sumJO = 0;
            int flagXianShang = 0;//如果在点在边界线上，不做处理
            int[] lenthXY = new int[2];
            lenthXY = data3.GetXYsumList(ld);
            int flag = 0;
            //一个点连一条射线如果与曲线相交为奇数个点（y值相等，曲线x点值小于或等于网格点的x值），则该点在曲线内；否则，则该点在曲线外
            //遇到连续曲线y值与求指点y值相等，则通过flag来判断只算作一次
            for (int i = 0; i < lenthXY[1]; i++)//数据横着读取，y值不变，x值变化
            {
                for (int j = 0; j < lenthXY[0]; j++)
                {
                    for (int k = 0; k < ld1.Count - 1; k++)
                    {

                        if ((ld1[k].yy < ld[i * lenthXY[0] + j].yy && ld[i * lenthXY[0] + j].yy < ld1[k + 1].yy) || (ld1[k].yy > ld[i * lenthXY[0] + j].yy && ld[i * lenthXY[0] + j].yy > ld1[k + 1].yy))
                        {

                            if (ld1[k].xx < ld[i * lenthXY[0] + j].xx && ld1[k + 1].xx < ld[i * lenthXY[0] + j].xx)
                            {
                                sumJO++;
                            }
                            if ((ld1[k].xx <= ld[i * lenthXY[0] + j].xx && ld[i * lenthXY[0] + j].xx <= ld1[k + 1].xx) || (ld1[k].xx >= ld[i * lenthXY[0] + j].xx && ld[i * lenthXY[0] + j].xx >= ld1[k + 1].xx))
                            {
                                flagXianShang = 1;
                            }
                        }
                        while (ld1[k++].yy == ld[i * lenthXY[0] + j].yy)//如果有两个连续的曲线值等于数据点值，只算一次sumJO
                        {
                            flag++;
                            if (ld1[k].xx < ld[i * lenthXY[0] + j].xx && flag == 1)
                            {
                                sumJO++;
                            }
                            if (ld1[k].xx == ld[i * lenthXY[0] + j].xx)
                            {
                                flagXianShang = 1;
                            }
                        }
                        k = k - 1;
                        flag = 0;
                        if (sumJO % 2 == 0 && flagXianShang == 0)
                        {
                            data3 newData = new data3();
                            newData.xx = 0;
                            newData.yy = 0;
                            newData.zz = 0;
                            ld[i * lenthXY[0] + j] = newData;
                        }
                        sumJO = 0;
                        flag = 0;
                        if (flagXianShang == 1)
                        {
                            flagXianShang = 0;
                        }
                    }
                }
            }
                for (int i = 0; i < ld.Count; i++)//数据横着读取，y值不变，x值变化
                {
                    while (i < ld.Count && ld[i].xx == 0 && ld[i].yy == 0 && ld[i].zz == 0)
                    {
                        ld.RemoveAt(i);
                    }
                }
           
                for (int i = 0; i < ld.Count; i++)//去除与曲线上y值(最大值，最小值)相同，但x值不同的点
                {
                    for (int j = 0; j < ld1.Count - 1; j++)
                    {
                        if ((ld[i].yy == ld1[j].yy && ld1[j].yy == maxY) || (ld[i].yy == ld1[j].yy && ld1[j].yy == minY))
                        {
                            if (ld[i].xx != ld1[j].xx)
                            {
                                data3 newData = new data3();
                                newData.xx = 0;
                                newData.yy = 0;
                                newData.zz = 0;
                                ld[i] = newData;
                            }
                        }
                    }
                }
                for (int i = 0; i < ld.Count; i++)//数据横着读取，y值不变，x值变化
                {
                    while (i < ld.Count && ld[i].xx == 0 && ld[i].yy == 0 && ld[i].zz == 0)
                    {
                        ld.RemoveAt(i);
                    }
                }
                return ld;
            }
        private List<data3> WGinCurve(List<data3> ld, List<data3> ld1)//判断ld网格数据是否在闭合曲线ld1中
        {
            List<data3> fitY = new List<data3>();
            int sumJO = 0;
            int flagXianShang = 0;//如果在点在边界线上，不做处理
            int[] lenthXY = new int[2];
            lenthXY = data3.GetXYsumList(ld);
            int flag = 0;
            //一个点连一条射线如果与曲线相交为奇数个点（y值相等，曲线x点值小于或等于网格点的x值），则该点在曲线内；否则，则该点在曲线外
            //遇到连续曲线y值与求指点y值相等，则通过flag来判断只算作一次
            for (int i = 0; i < lenthXY[1]; i++)//数据横着读取，y值不变，x值变化
            {
                for (int j = 0; j < lenthXY[0]; j++)
                {
                    for (int k = 0; k < ld1.Count - 1; k++)
                    {

                        if ((ld1[k].yy < ld[i * lenthXY[0] + j].yy && ld[i * lenthXY[0] + j].yy < ld1[k + 1].yy) || (ld1[k].yy > ld[i * lenthXY[0] + j].yy && ld[i * lenthXY[0] + j].yy > ld1[k + 1].yy))
                        {

                            if (ld1[k].xx < ld[i * lenthXY[0] + j].xx && ld1[k + 1].xx < ld[i * lenthXY[0] + j].xx)
                            {
                                sumJO++;
                            }
                            if ((ld1[k].xx <= ld[i * lenthXY[0] + j].xx && ld[i * lenthXY[0] + j].xx <= ld1[k + 1].xx) || (ld1[k].xx >= ld[i * lenthXY[0] + j].xx && ld[i * lenthXY[0] + j].xx >= ld1[k + 1].xx))
                            {
                                flagXianShang = 1;
                            }
                        }
                        while (ld1[k++].yy == ld[i * lenthXY[0] + j].yy)//如果有两个连续的曲线值等于数据点值，只算一次sumJO
                        {
                            flag++;
                            if (ld1[k].xx < ld[i * lenthXY[0] + j].xx && flag == 1)
                            {
                                sumJO++;
                            }
                            if (ld1[k].xx == ld[i * lenthXY[0] + j].xx)
                            {
                                flagXianShang = 1;
                            }
                        }
                        k = k - 1;
                    }

                    if (sumJO % 2 == 0 && flagXianShang == 0)
                    {
                        data3 newData = new data3();
                        newData.xx = 0;
                        newData.yy = 0;
                        newData.zz = 0;
                        ld[i * lenthXY[0] + j] = newData;
                    }
                    sumJO = 0;
                    flag = 0;
                    if (flagXianShang == 1)
                    {
                        flagXianShang = 0;
                    }
                }
            }

            for (int i = 0; i < ld.Count; i++)//数据横着读取，y值不变，x值变化
            {
                while (i < ld.Count && ld[i].xx == 0 && ld[i].yy == 0 && ld[i].zz == 0)
                {
                    ld.RemoveAt(i);
                }
            }

            for (int i = 0; i < ld.Count; i++)//去除与曲线上y值(最大值，最小值)相同，但x值不同的点
            {
                for (int j = 0; j < ld1.Count - 1; j++)
                {
                    if ((ld[i].yy == ld1[j].yy && ld1[j].yy == maxY) || (ld[i].yy == ld1[j].yy && ld1[j].yy == minY))
                    {
                        if (ld[i].xx != ld1[j].xx)
                        {
                            data3 newData = new data3();
                            newData.xx = 0;
                            newData.yy = 0;
                            newData.zz = 0;
                            ld[i] = newData;
                        }
                    }
                }
            }
            for (int i = 0; i < ld.Count; i++)//数据横着读取，y值不变，x值变化
            {
                while (i < ld.Count && ld[i].xx == 0 && ld[i].yy == 0 && ld[i].zz == 0)
                {
                    ld.RemoveAt(i);
                }
            }
            return ld;
        }
        private List<data3> SDinCurve(List<data3> ld, List<data3> ld1)//判断ld散点数据是否在闭合曲线ld1中
        {
            List<data3> fitY = new List<data3>();
            int sumJO = 0;
            int flag=0;
            int flagXianShang = 0;
            for (int i = 0; i < ld.Count; i++)
            {
                for (int j = 0; j < ld1.Count - 1; j++)
                {
                    if ((ld1[j].yy < ld[i].yy && ld[i].yy < ld1[j+1].yy) || (ld1[j].yy > ld[i].yy && ld[i].yy > ld1[j + 1].yy))
                    {
                        if (ld1[j].xx < ld[i].xx && ld1[j+1].xx < ld[i].xx)
                        {
                            sumJO++;
                        }
                        //if ((ld1[j].xx <= ld[i].xx && ld[i].xx <= ld1[j + 1].xx) || (ld1[j].xx >= ld[i].xx && ld[i].xx >= ld1[j + 1].xx))
                        //{
                        //    flagXianShang = 1;
                        //}
                    }
                    while (ld1[j].yy == ld[i].yy)
                    {
                        flag++;
                        if (ld1[j].xx < ld[i].xx &&flag==1)
                        {
                            sumJO++;
                        }
                        if (ld1[j].xx == ld[i].xx)
                        {
                            flagXianShang = 1;
                        }
                    }
                }
                if (sumJO % 2 == 0 && flagXianShang == 0)
                {
                    data3 newData = new data3();
                    newData.xx = 0;
                    newData.yy = 0;
                    newData.zz = 0;
                    ld[i] = newData;
                }
                sumJO = 0;
                flag = 0;
                if (flagXianShang == 1)
                {
                    flagXianShang = 0;
                }
            }

            for (int i = 0; i < ld.Count; i++)//数据横着读取，y值不变，x值变化
            {
                while (i < ld.Count &&ld[i].xx == 0 && ld[i].yy == 0 && ld[i].zz == 0)
                {
                    ld.RemoveAt(i);
                }
            }
            for (int i = 0; i < ld.Count; i++)//去除与曲线上y值(最大值，最小值)相同，但x值不同的点
            {
                for (int j = 0; j < ld1.Count - 1; j++)
                {
                    if ((ld[i].yy == ld1[j].yy && ld1[j].yy == maxY) || (ld[i].yy == ld1[j].yy && ld1[j].yy == minY))
                    {
                        if (ld[i].xx != ld1[j].xx)
                        {
                            data3 newData = new data3();
                            newData.xx = 0;
                            newData.yy = 0;
                            newData.zz = 0;
                            ld[i] = newData;
                        }
                    }
                }
            }
            for (int i = 0; i < ld.Count; i++)//数据横着读取，y值不变，x值变化
            {
                while (i < ld.Count && ld[i].xx == 0 && ld[i].yy == 0 && ld[i].zz == 0)
                {
                    ld.RemoveAt(i);
                }
            }
            return ld;
        }
        private List<data3> InsertValue(List<data3> ld, List<data3> ld1)//用已知ld1数据，在ld网格中插值
        {
            double m_fDist;
            double m_fSumDist=0;
            double m_fGridZ=0;
            for (int i = 0; i < ld.Count; i++)
            {
                List<data> list = new List<data>();
                data dd = new data();
                for (int k = 0; k < ld1.Count; k++)
                {
                    //计算每个绘图坐标点到网格交点的距离
                    m_fDist = (double)Math.Sqrt((ld1[k].xx - ld[i].xx) * (ld1[k].xx - ld[i].xx)
                        + (ld1[k].yy - ld[i].yy) * (ld1[k].yy - ld[i].yy));
                    dd.xx = m_fDist;
                    dd.yy = ld1[k].zz;
                    list.Add(dd);
                }
                list = GetFore4(list);
                int l = 0;
                m_fGridZ = 0;
                m_fSumDist = 0;
                for (l = 0; l < list.Count; l++)
                {
                    if (list[l].xx == 0)
                    {
                        m_fSumDist = 1; break;
                    }
                    else
                    {
                        m_fSumDist += 1 / list[l].xx;
                    }
                    m_fGridZ += list[l].yy / list[l].xx;
                }
                if (m_fSumDist == 1)
                {
                    m_fGridZ = list[l].yy;
                }
                else
                {
                    m_fGridZ = m_fGridZ / m_fSumDist;
                }
                data3 newData = new data3();
                newData.xx = ld[i].xx;
                newData.yy = ld[i].yy;
                newData.zz = m_fGridZ;
                ld[i] = newData;
            }
            return ld;
        }
        private string GetName(string strName)
        {
            int index = strName.LastIndexOf(@"\");
            string result = strName.Substring(index + 1, strName.Length - index - 5)+"网格化后";
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "TXT文本文件|*.txt|ALL FILES|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = ofd.FileName;
                }
                else
                {
                    return;
                }
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
                    MessageBox.Show("数据导入错误2！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
                    ld.Clear();
                    string line = "";
                    data3 dd = new data3();
                    for (int i = 0; i < ls.Count; i++)
                    {
                        line = ls[i].Trim();
                        string[] splitString = line.Split(' ', ',','\t');
                        dd.xx = Convert.ToDouble(splitString[0]);
                        dd.yy = Convert.ToDouble(splitString[1]);
                        dd.zz = Convert.ToDouble(splitString[2]);
                        ld.Add(dd);
                    }
                }
                catch
                {
                    ld = null;
                    MessageBox.Show("数据导入错误2！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string strName = GetName(textBox1.Text);//取文件名
                textBox2.Text = System.Environment.CurrentDirectory + @"\" + strName + ".txt";

                List<double> x = new List<double>();
                List<double> y = new List<double>();
                cols = Convert.ToInt32(numericUpDownX.Value);
                rows = Convert.ToInt32(numericUpDownY.Value);
                for (int i = 0; i < ld.Count; i++)
                {
                    x.Add(ld[i].xx);
                    y.Add(ld[i].yy);
                }
                maxX = x.Max();
                minX = x.Min();
                maxY = y.Max();
                minY = y.Min();
                x_edgion = (maxX - minX) / (cols - 1);
                y_edion = (maxY - minY) / (rows - 1);
                tbMinx.Text = minX.ToString();
                tbMaxX.Text = maxX.ToString();
                tbMinY.Text = minY.ToString();
                tbMaxY.Text = maxY.ToString();
                tbJX.Text = x_edgion.ToString();
                TbYj.Text = y_edion.ToString();

                if ((maxX - minX) > (maxY - minY))
                {
                    numericUpDownX.Value = 15;
                    numericUpDownY.Value = (int)((maxY - minY) * 15 / (maxX - minX));
                }
                else
                {
                    numericUpDownY.Value = 15;
                    numericUpDownX.Value = (int)((maxX - minX) * 15 / (maxY - minY));
                }
        }

        private void FormGrid_Load(object sender, EventArgs e)
        {
            string []strMethord={"距离反比网格化","随机分形距离反比网格化","克里金网格化","最小曲率网格化","最近邻点方法","多项式回归方法"};
            ComboBoxMethord.Items.AddRange(strMethord);
            ComboBoxMethord.SelectedIndex = 0;
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "TXT文本文件|*.txt|ALL FIlES|*.*";
            DialogResult dr = sd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox2.Text = sd.FileName;
            }
        }

        private void numericUpDownX_ValueChanged(object sender, EventArgs e)
        {
            cols = Convert.ToInt32(numericUpDownX.Value);
            x_edgion = (maxX - minX) / (cols - 1);
            tbJX.Text = x_edgion.ToString();
        }

        private void numericUpDownY_ValueChanged(object sender, EventArgs e)
        {
            rows = Convert.ToInt32(numericUpDownY.Value);
            y_edion = (maxY - minY) / (rows - 1);
            TbYj.Text = y_edion.ToString();
        }

        private void numericUpDownX_KeyUp(object sender, KeyEventArgs e)
        {
            cols = Convert.ToInt32(numericUpDownX.Value);
            x_edgion = (maxX - minX) / (cols - 1);
            tbJX.Text = x_edgion.ToString();
        }

        private void numericUpDownY_KeyUp(object sender, KeyEventArgs e)
        {
            rows = Convert.ToInt32(numericUpDownY.Value);
            y_edion = (maxY - minY) / (rows - 1);
            TbYj.Text = y_edion.ToString();
        }


        private void BTBind_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TXT文本文件|*.txt|ALL FILES|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TBBind.Text = ofd.FileName;
            }
            else
            {
                return;
            }
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
                MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                lb.Clear();
                string line = "";
                data3 dd = new data3();
                for (int i = 0; i < ls.Count; i++)
                {
                    line = ls[i].Trim();
                    string[] splitString = line.Split(' ', '\t');
                    dd.xx = Convert.ToDouble(splitString[0]);
                    dd.yy = Convert.ToDouble(splitString[1]);
                    dd.zz = Convert.ToDouble(splitString[2]);
                    lb.Add(dd);
                }
            }
            catch
            {
                lb= null;
                MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //string strName = GetName(textBox1.Text);//取文件名
            //textBox2.Text = System.Environment.CurrentDirectory + @"\" + strName + ".txt";

            List<double> x = new List<double>();
            List<double> y = new List<double>();
            cols = Convert.ToInt32(numericUpDownX.Value);
            rows = Convert.ToInt32(numericUpDownY.Value);
            for (int i = 0; i < lb.Count; i++)
            {
                x.Add(lb[i].xx);
                y.Add(lb[i].yy);
            }
            string strName = GetName(TBBind.Text);//取文件名
            textBox2.Text = System.Environment.CurrentDirectory + @"\" + strName + ".txt";
            maxX = x.Max();
            minX = x.Min();
            maxY = y.Max();
            minY = y.Min();
            x_edgion = (maxX - minX) / (cols - 1);
            y_edion = (maxY - minY) / (rows - 1);
            tbMinx.Text = minX.ToString();
            tbMaxX.Text = maxX.ToString();
            tbMinY.Text = minY.ToString();
            tbMaxY.Text = maxY.ToString();
            tbJX.Text = x_edgion.ToString();
            TbYj.Text = y_edion.ToString();

            if ((maxX - minX) > (maxY - minY))
            {
                numericUpDownX.Value = 15;
                numericUpDownY.Value = (int)((maxY - minY) * 15 / (maxX - minX));
            }
            else
            {
                numericUpDownY.Value = 15;
                numericUpDownX.Value = (int)((maxX - minX) * 15 / (maxY - minY));
            }
        }

        private void BTFacies_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TXT文本文件|*.txt|ALL FILES|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TBFacies.Text = ofd.FileName;
            }
            else
            {
                return;
            }
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
                MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                lc.Clear();
                string line = "";
                data3 dd = new data3();
                for (int i = 0; i < ls.Count; i++)
                {
                    line = ls[i].Trim();
                    string[] splitString = line.Split(' ', '\t');
                    dd.xx = Convert.ToDouble(splitString[0]);
                    dd.yy = Convert.ToDouble(splitString[1]);
                    dd.zz = Convert.ToDouble(splitString[2]);
                    lc.Add(dd);
                }
            }
            catch
            {
                lc = null;
                MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string strName = GetName(TBFacies.Text);//取文件名
            textBox2.Text = System.Environment.CurrentDirectory + @"\" + strName + ".txt";
            //List<data3> le = new List<data3>();
            //for (int i = 0; i < lc.Count-1; i++)
            //{
            //    if (lc[i].zz == lc[i + 1].zz)
            //    {
            //        le.Add((data3)lc[i]);
            //    }
            //    else
            //    {
            //        le.Add(lc[i]);
            //        lld.Add(le);
            //        le.Clear();       
            //    }
            //    if (i == lc.Count - 2)
            //    {
            //        le.Add(lc[lc.Count - 1]);
            //        lld.Add(le);
            //    }
            //}
            int len = 1;
            List<double> li = new List<double>();
            li.Add(lc[0].zz);
            for (int i = 0; i < lc.Count - 1; i++)
            {
                if (lc[i].zz != lc[i + 1].zz)
                {
                    len++;
                    li.Add(lc[i + 1].zz);
                }
            }
            for (int i = 0; i < len; i++)
            {
                List<data3> le = new List<data3>();
                for (int j = 0; j < lc.Count; j++)
                {
                    if (lc[j].zz == li[i])
                    {
                        le.Add(lc[j]);
                    }
                }
                lld.Add(le);
            }
        }
    }
}
