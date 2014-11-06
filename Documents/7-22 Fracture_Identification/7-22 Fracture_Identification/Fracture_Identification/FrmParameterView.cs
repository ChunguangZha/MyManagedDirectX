using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Fracture_Identification
{
    public partial class FrmParameterView : Form
    {
        public FrmParameterView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void Display(object sender, ChartDirector.WinHotSpotEventArgs e)
        {
            // Add the name of the ChartViewer control that is being clicked
            listView.Items.Add(new ListViewItem(new string[] {"source", 
				((ChartDirector.WinChartViewer)sender).Name}));

            // List out the parameters of the hot spot
            foreach (DictionaryEntry key in e.GetAttrValues())
            {
                listView.Items.Add(new ListViewItem(
                    new string[] { (string)key.Key, (string)key.Value }));
            }

            // Display the form
            ShowDialog();
        }
    }
}
