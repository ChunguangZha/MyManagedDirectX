using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyManagedDirectX
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemViewAll_Click(object sender, EventArgs e)
        {
            this.map3DControl1.Action = de3DAction.ViewAll;
        }

        private void toolStripMenuItemPan_Click(object sender, EventArgs e)
        {
            this.map3DControl1.Action = de3DAction.Pan;
        }

        private void toolStripMenuItemRotatePan_Click(object sender, EventArgs e)
        {
            this.map3DControl1.Action = de3DAction.PanRotate;
        }

        private void toolStripMenuItemZoomIn_Click(object sender, EventArgs e)
        {
            this.map3DControl1.Action = de3DAction.ZoomIn;
        }

        private void toolStripMenuItemZoomOut_Click(object sender, EventArgs e)
        {
            this.map3DControl1.Action = de3DAction.ZoomOut;
        }

        private void toolStripMenuItemRotateX_Click(object sender, EventArgs e)
        {
            this.map3DControl1.Action = de3DAction.RotateX;
        }

        private void toolStripMenuItemRotateY_Click(object sender, EventArgs e)
        {
            this.map3DControl1.Action = de3DAction.RotateY;
        }

        private void toolStripMenuItemRotateZ_Click(object sender, EventArgs e)
        {
            this.map3DControl1.Action = de3DAction.RotateZ;
        }

        private void toolStripMenuItemLoadSplitLayerData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "*.txt|*.txt";
            if (dig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.map3DControl1.LoadData(dig.FileName);
            }
        }

        private void map3DControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this.PointToScreen(e.Location));
            }
            else
            {
                this.contextMenuStrip1.Close();
            }
        }
    }
}
