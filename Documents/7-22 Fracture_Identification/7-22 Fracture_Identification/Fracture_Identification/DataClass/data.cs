using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace fractal.newClass
{
    struct data
    {
        
            private double x;
            private double y;
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
            public static data[] getOringle(string strPath)//取原始值
            {
                string line;
                int counter = 0;
                int i = 0;
                System.IO.StreamReader file = new System.IO.StreamReader(strPath);

                while ((line = file.ReadLine()) != null)
                {
                    counter++; ;
                }
                data[] myXy = new data[counter];
                try
                {                  
                    file.Close();
                    System.IO.StreamReader file1 = new System.IO.StreamReader(strPath);
                    while ((line = file1.ReadLine()) != null)
                    {
                        string[] splitstring = line.Split(' ');
                        myXy[i].xx = Convert.ToDouble(splitstring[0]);
                        myXy[i].yy = Convert.ToDouble(splitstring[1]);
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
    }

}
