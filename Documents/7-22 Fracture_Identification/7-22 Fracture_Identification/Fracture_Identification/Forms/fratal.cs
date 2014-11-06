using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fractal.newClass;
using ChartDirector;
namespace fractal
{
    public partial class fractalF : Form
    {
        public fractalF()
        {
            InitializeComponent();
        }
        public int k = 0;
        public int l = 0;
        private void OpenButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.txt(XYZ)|*txt|*.*(所有文件)|*.*";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
        private void Excute_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择原始值！");
            }
            if (textBox1.Text != "")
            {
                richTextBox1.Text = "";
                data3 data = new data3();
                data3[] xyz = data.GetXyz(openFileDialog1.FileName);
                double[] juZheng = { xyz.Length, data.GetSumxyz(xyz, 0), data.GetSumxyz(xyz, 1), data.GetSumxyz(xyz, 0), data.GetSumxy2(xyz, 0), data.GetSumxyzJi(xyz, 0), data.GetSumxyz(xyz, 1), data.GetSumxyzJi(xyz, 0), data.GetSumxy2(xyz, 1) };
                double[] yJuZheng = { data.GetSumxyz(xyz, 2), data.GetSumxyzJi(xyz, 2), data.GetSumxyzJi(xyz, 1) };
                Matrix mx = new Matrix(3, 3);
                for (int i = 0; i < 9; i++)
                {
                    mx.setValueS(3, 3, juZheng);
                }
                Matrix my = new Matrix(3, 1);
                for (int i = 0; i < 3; i++)
                {
                    my.setValueS(3, 1, yJuZheng);
                }
                Matrix mz = new Matrix(3, 1);
                mz = mx.Inverse() * my;//计算趋势面系数
                double[] bb = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    bb[i] = mz[i, 0];
                }
                double[] p = data.GetPianchazhi(xyz, data.GetQushizhi(xyz, bb));//计算偏差值
                double[] d = data.GetDI(p);//计算压缩系数
                /*    foreach(object item in p)
                    {
                        foreach (object item1 in d)
                        {
                            richTextBox1.Text += (item1 + " " + item + "\r\n"); break;
                        }
                    }*/
                int[] lenth = data.GetXYsum(xyz);//原始x，y值个数
                int lenthx = lenth[0];
                int lenthy = lenth[1];
                double[,] zz = Fractalifs.GetNewZ(xyz, data.GetX(xyz), data.GetY(xyz), d);//新z值
                //for (int i = 0; i < lenthy * (lenthy - 1) ; i++)
                //{
                //    for (int j = 0; j < lenthx * (lenthx - 1) ; j++)
                //    {
                //        richTextBox1.Text += Convert.ToString(zz[j, i])+"\r\n";
                //    }
                //}
                double[] x = Fractalifs.GetNewXY(data.GetX(xyz), data.GetY(xyz), 0);//新x值
                double[] y = Fractalifs.GetNewXY(data.GetX(xyz), data.GetY(xyz), 1);//新y值
                for (int j = 0; j < y.Length; j++)
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        richTextBox1.Text += x[i].ToString() + "  " + y[j].ToString() + "   " + zz[i, j].ToString() + "\r\n";
                    }
                }

                //double[] y = Fractalifs.GetNewXY(data.GetX(xyz), data.GetY(xyz),1);
                //for (int i = 0; i < y.Length; i++)
                //{
                //    richTextBox2.Text += y[i] + "\r\n";
                //}
            }
        }
        private void SaveWorth_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("数据为空！");
            }
            else
            {
                saveFileDialog1.Filter = "*.txt|*.txt";
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text.Replace("\n", "\r\n"), Encoding.Default);
                }
            }
        }
        private void JubuExcute_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""||textBox2.Text == "")
            {
                MessageBox.Show("请选择原始值或局部邻域数据个数！");
            }
            if (textBox1.Text != ""&&textBox2.Text!="")
            {
                richTextBox1.Text = "";
                int mx = 0;
                int my = 0;
                data3 data = new data3();
                data3[] xyz = data.GetXyz(openFileDialog1.FileName);
                double[] juZheng = { xyz.Length, data.GetSumxyz(xyz, 0), data.GetSumxyz(xyz, 1), data.GetSumxyz(xyz, 0), data.GetSumxy2(xyz, 0), data.GetSumxyzJi(xyz, 0), data.GetSumxyz(xyz, 1), data.GetSumxyzJi(xyz, 0), data.GetSumxy2(xyz, 1) };
                double[] yJuZheng = { data.GetSumxyz(xyz, 2), data.GetSumxyzJi(xyz, 2), data.GetSumxyzJi(xyz, 1) };
                Matrix mx1 = new Matrix(3, 3);
                for (int i = 0; i < 9; i++)
                {
                    mx1.setValueS(3, 3, juZheng);
                }
                Matrix my1 = new Matrix(3, 1);
                for (int i = 0; i < 3; i++)
                {
                    my1.setValueS(3, 1, yJuZheng);
                }
                Matrix mz = new Matrix(3, 1);
                mz = mx1.Inverse() * my1;//计算趋势面系数
                double[] bb = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    bb[i] = mz[i, 0];
                }
                double[] p = data.GetPianchazhi(xyz, data.GetQushizhi(xyz, bb));//计算偏差值
                double[] d = data.GetDI(p);//计算压缩系数


                double[] xxx = data.GetX(xyz);//取原始x值
                double[] yyy = data.GetY(xyz);//取原始y值
                double[,] zzz = data.TranserZ(xyz);//取原始z值
                double[,] s = data.TranserS(xyz, d);//原始di坐标化
                int[] lenth = data.GetXYsum(xyz);//原始x，y值个数
                int lenthx = lenth[0];
                int lenthy = lenth[1];
                int pd = Convert.ToInt32(textBox2.Text);//局域领域数据数据个数
                int mb = 0;//x轴x初始值
                int me = 0;//x轴x终止值
                int nb = 0, ne = 0;//y轴y初始和终止值 
             
                while (my < lenthy - 1)
                {
                    nb = my;
                    ne = nb + pd - 1;
                    if (ne > lenthy - 1)
                    {
                        ne = lenthy - 1;
                        nb = ne - pd+1;
                    }
                    mx = 0;
                    while (mx < lenthx - 1)
                    {
                        mb = mx;
                        me = mx + pd - 1;
                        if (me > lenthx - 1)
                        {
                            me = lenthx - 1;
                            mb = me - pd + 1;
                        }
                        double[]xx=data.GetPxy(xxx, mb, me);
                        double[]yy=data.GetPxy(yyy, nb, ne);
                        double[,] pz = Fractalifs.GetNewPZ(xx, yy, data.GetPz(zzz, mb, me, nb, ne), data.GetPs(s, mb, me, nb, ne));
                        double[] x = Fractalifs.GetNewXY(xx, yy, 0);//新x值
                        double[] y = Fractalifs.GetNewXY(xx, yy, 1);//新y值
                        for (int j = 0; j < y.Length; j++)//一个邻域内先x变，y轴不变，铺向整个领域。
                        {
                            for (int i = 0; i < x.Length; i++)
                            {
                                  richTextBox1.Text += x[i].ToString() + " " + y[j].ToString() + " " + pz[i, j].ToString() + "\r\n";            
                            }
                        }
                            mx = me;
                    }
                    my = ne;
                }
            }
            ProcessData();
        }

        private void ClearRich_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }        
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            data3 data = new data3();
            data3[] xyz = data.GetXyz(openFileDialog1.FileName);
            int[] lenth = data.GetXYsum(xyz);//原始x，y值个数
            int lenthx = lenth[0];
            int lenthy = lenth[1];
            int pd = Convert.ToInt32(textBox2.Text);//局域领域数据数据个数
            if (pd <= 1)
            {
                MessageBox.Show("局部领域数据个数应大于1！");
                textBox2.Focus();
                textBox2.Text = Convert.ToString(2);
                richTextBox1.Text = "";
            }
            if ((lenthy - pd) < 0)
            {
                MessageBox.Show("局部领域个数超过原值y值个数！");
                textBox2.Focus();
                textBox2.Text = Convert.ToString(2);
                richTextBox1.Text = "";
            }
            if ((lenthx - pd) < 0)
            {
                MessageBox.Show("局部领域个数超过原值x值个数！");
                textBox2.Focus();
                textBox2.Text = Convert.ToString(2);
                richTextBox1.Text = "";
            }
        }

        private void ProData_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                List<data3> ld = new List<data3>();
                data3[] str = data3.GetXyzP(richTextBox1.Text);//取richtextbox中的数据
                str = str.OrderBy(n => n.yy).ToArray();//按y值数据由低到高排列
                richTextBox1.Text = "";
                ld = data3.DeleteXT(str);//删除x值相同的项
                ld = ld.OrderBy(n => n.xx).ToList();//按x值数据由低到高排列
                ld = data3.DeleteYT(ld);//删除y值相同的项
                ld = ld.OrderBy(n => n.yy).ToList();//按y值数据由低到高
                int i = 0;
                while (i < ld.Count)
                {
                    richTextBox1.Text += ld[i].xx.ToString() + " " + ld[i].yy.ToString() + " " + ld[i].zz.ToString() + "\r\n";
                    i++;
                }
                k = 0; l = 0;
            }
        }
        private void ProcessData()
        {
            if (richTextBox1.Text != "")
            {
                List<data3> ld = new List<data3>();
                data3[] str = data3.GetXyzP(richTextBox1.Text);//取richtextbox中的数据
                str = str.OrderBy(n => n.yy).ToArray();//按y值数据由低到高排列
                richTextBox1.Text = "";
                ld = data3.DeleteXT(str);//删除x值相同的项
                ld = ld.OrderBy(n => n.xx).ToList();//按x值数据由低到高排列
                ld = data3.DeleteYT(ld);//删除y值相同的项
                ld = ld.OrderBy(n => n.yy).ToList();//按y值数据由低到高
                int i = 0;
                while (i < ld.Count)
                {
                    richTextBox1.Text += ld[i].xx.ToString() + " " + ld[i].yy.ToString() + " " + ld[i].zz.ToString() + "\r\n";
                    i++;
                }
                k = 0; l = 0;
            }
        }
        private void ContourMap_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Text != "" && k == 0)
            {
                data3[] str1 = data3.GetXyzP(richTextBox1.Text);
                data3 data = new data3();
                double[] x = data.GetX(str1);
                double[] y = data.GetY(str1);
                //  double[,] z = data.TranserZ(str1);
                double[] z = data.GetZ(str1);
                int[] lenthXY = data.GetXYsum(str1);
                int lenthX = lenthXY[0];
                int lenthY = lenthXY[1];
                k = 1;
                ContourPicture cp = new ContourPicture(0);
                cp.x = x;//将x,y,z值传入图形显示处理form中
                cp.y = y;
                cp.z = z;
                //   cp.flag = 0;
                cp.Owner = this;
                cp.Show();
                //this.Hide();
            }
        }

        private void surfaceDraw_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && l == 0)
            {
                data3[] str1 = data3.GetXyzP(richTextBox1.Text);
                data3 data = new data3();
                double[] x = data.GetX(str1);
                double[] y = data.GetY(str1);
                //  double[,] z = data.TranserZ(str1);
                double[] z = data.GetZ(str1);
                int[] lenthXY = data.GetXYsum(str1);
                int lenthX = lenthXY[0];
                int lenthY = lenthXY[1];
                l = 1;
                ContourPicture cp = new ContourPicture(1);
                cp.x = x;
                cp.y = y;
                cp.z = z;
                //    cp.flag = 1;
                cp.Owner = this;
                cp.Show();
            }
        }
    }
}
