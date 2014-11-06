using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fractal.newClass;
namespace Fracture_Identification
{
    public partial class FratalThread : Form
    {
        public FratalThread()
        {
            InitializeComponent();
        }

        private void FractalInsertExcute_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "" || d.Text == "")
            {
                MessageBox.Show("请输入插值个数或比例因子！");
            }
            if (textBox13.Text != "" && d.Text != "")
            {
                //double[] x = new double[1000];
            //    double[] y = new double[1000];
                List<data> ld = new List<data>();
                data dd = new data();
                data[] dataOrigle = data.getOringle(openFileDialog1.FileName);
                double[] ai = new double[dataOrigle.Length];
                double[] ei = new double[dataOrigle.Length];
                double[] ci = new double[dataOrigle.Length];
                double[] fi = new double[dataOrigle.Length];
                int k = 0;
                for (int i = 0; i < dataOrigle.Length - 1; i++)
                {
                    ai[i] = (dataOrigle[i + 1].xx - dataOrigle[i].xx) / (dataOrigle[dataOrigle.Length - 1].xx - dataOrigle[0].xx);
                    ei[i] = (dataOrigle[dataOrigle.Length - 1].xx * dataOrigle[i].xx - dataOrigle[0].xx * dataOrigle[i + 1].xx) / (dataOrigle[dataOrigle.Length - 1].xx - dataOrigle[0].xx);
                    ci[i] = (dataOrigle[i + 1].yy - dataOrigle[i].yy - Convert.ToDouble(d.Text) * (dataOrigle[dataOrigle.Length - 1].yy - dataOrigle[0].yy)) / (dataOrigle[dataOrigle.Length - 1].xx - dataOrigle[0].xx);
                    fi[i] = (dataOrigle[dataOrigle.Length - 1].xx * dataOrigle[i].yy - dataOrigle[0].xx * dataOrigle[i + 1].yy - Convert.ToDouble(d.Text) * (dataOrigle[dataOrigle.Length - 1].xx * dataOrigle[0].yy - dataOrigle[0].xx * dataOrigle[dataOrigle.Length - 1].yy)) / (dataOrigle[dataOrigle.Length - 1].xx - dataOrigle[0].xx);
                    for (int j = 0; j < dataOrigle.Length - 1; j = j + dataOrigle.Length / Convert.ToInt32(textBox13.Text))
                    {
                        dd.xx = ai[i] * dataOrigle[j].xx + ei[i];
                        dd.yy = ci[i] * dataOrigle[j].xx + Convert.ToDouble(d.Text) * dataOrigle[j].yy + fi[i];
                        ld.Add(dd);
                        k = k + 1;
                    }
                }
                /*  data[] xy = new data[k];
                  for (int m = 0; m < k; m++)
                  {
                      xy[m].xx = x[m];
                      xy[m].yy = y[m];
                  }
                  return xy;*/
                for (int l = 0; l < k; l++)
                {
                    richTextBox6.Text += ld[l].xx.ToString() + " " + ld[l].yy.ToString() + "\r\n";
                }
            }
        }

        private void SaveFra_Click(object sender, EventArgs e)
        {
            if (richTextBox6.Text == "")
            {
                MessageBox.Show("数据为空！");
            }
            else
            {
                saveFileDialog1.Filter = "*.txt|*.txt";
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox6.Text.Replace("\n", "\r\n"), Encoding.Default);
                }
            }
        }

        private void OpenFradata_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.txt|*txt";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //    richTextBox1.Text=File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
                textBox12.Text = openFileDialog1.FileName;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != 13)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }    
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
              data[] dataOrigle = data.getOringle(openFileDialog1.FileName);
              if (Convert.ToInt32(textBox13.Text) > dataOrigle.Length || Convert.ToInt32(textBox13.Text) <1)
              {
                  MessageBox.Show("请输入1到原始数值之间的值的个数");
              }
        }

        private void d_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != 13&&e.KeyChar!=46)
            {
                MessageBox.Show("请输入数字！");
                e.Handled = true;
            }  
        }
    }
}
