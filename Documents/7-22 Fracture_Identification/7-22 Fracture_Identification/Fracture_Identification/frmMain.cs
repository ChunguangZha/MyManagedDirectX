using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fractal;
using fractal.newClass;
using DAPS.Simulator;
using SmartSolutions.Controls;
using System.IO;
using ChartDirector;
namespace Fracture_Identification
{
    public partial class frmMain : Form
    { 
        public frmMain()
        {
            InitializeComponent();
        }
        MainData TotalData = new MainData();//存储所有数据，区块数据，井数据，断层数据，裂缝识别结果数据等。
        TriStateTreeNode rootNode = new TriStateTreeNode();//左边树形列表
        frmRSFractal RSFractalForm = null;
        frmPrincipalCurvatures PrincipalCurForm1 = null;
        frmPrincipalCurvatures PrincipalCurForm = null;
        frmPlainStress PlainStressForm = null;
        fractalF fractalForm = null;
        FratalThread fractalTForm = null;
        FormGrid fg = null;

        string currentSelectedWell = "wellname";//当前选择井的名字；
        

        private void mnuRSFractal_Click(object sender, EventArgs e)
        {
            if (RSFractalForm == null || RSFractalForm.IsDisposed)
            {
                RSFractalForm = new frmRSFractal();
            }
            //RSFractalForm.WindowState = FormWindowState.Maximized;
            RSFractalForm.Show();
        }

        private void mnuPrincipalCurvatures_Click(object sender, EventArgs e)
        {
            if (PrincipalCurForm1 == null || PrincipalCurForm1.IsDisposed)
            {
                PrincipalCurForm1 = new frmPrincipalCurvatures(this);
            }
            PrincipalCurForm1.WindowState = FormWindowState.Maximized;


            PrincipalCurForm1.Show();
        }

        private void 分形平面插值ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fractalForm = new fractalF();
      //      fractalForm.MdiParent = this;
            fractalForm.Show();
        }

        private void 分形曲线插值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fractalTForm = new FratalThread();
      //     fractalTForm.MdiParent = this;
            fractalTForm.ShowDialog();
        }
        double MaxX, MinX, MaxY, MinY;
        int nx, ny;
        double xlevel, ylevel;
        private void 距离反比网格化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fg = new FormGrid();
            fg.ShowDialog();
        }
        List<data3> ld = new List<data3>();
        private void OpenDialog(int flag)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt(XYZ)|*txt|*.grd(ASC网格数据)|*grd|*.*(所有文件)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
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
                        ld.Clear();
                        string line = "";
                        data3 dd = new data3();
                        for (int i = 0; i < ls.Count; i++)
                        {
                            line = ls[i].Trim();
                            string[] splitStr = line.Split(' ', '\t');
                            dd.xx = Convert.ToDouble(splitStr[0]);
                            dd.yy = Convert.ToDouble(splitStr[1]);
                            dd.zz = Convert.ToDouble(splitStr[2]);
                            ld.Add(dd);
                        }
                    }
                    catch
                    {
                        ld = null;
                        MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    double[] x = new double[ld.Count];
                    double[] y = new double[ld.Count];
                    double[] z = new double[ld.Count];
                    for (int i = 0; i < ld.Count; i++)
                    {
                        x[i] = ld[i].xx;
                        y[i] = ld[i].yy;
                        z[i] = ld[i].zz;
                    }
                    List<double> xx = new List<double>();
                    List<double> yy = new List<double>();
                    for (int i = 0; i < ld.Count; i++)
                    {
                        xx.Add(ld[i].xx);
                        yy.Add(ld[i].yy);
                    }

                    MaxX = xx.Max();
                    MinX = xx.Min();
                    MaxY = yy.Max();
                    MinY = yy.Min();
                    mapForm mf = new mapForm(flag);
                    mf.x = x;
                    mf.y = y;
                    mf.z = z;
                    mf.MaxX = MaxX;
                    mf.MinX = MinX;
                    mf.MaxY = MaxY;
                    mf.MinY = MinY;
           //         mf.MdiParent = this;
                    mf.Show();
                }
                #endregion
                #region grd|asc文件
                if (ofd.FileName.Contains(".grd"))
                {
                    List<string> ls = new List<string>();
                    List<data> ld1 = new List<data>();
                    System.IO.StreamReader file1 = null;
                    try
                    {
                        file1 = new System.IO.StreamReader(ofd.FileName, Encoding.ASCII);
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
                        ld.Clear();
                        string line = "";
                        data dd2 = new data();
                        if (ls[0] == "DSAA")
                        {
                            for (int i = 1; i < 5; i++)
                            {
                                line = ls[i].Trim();
                                string[] splitString1 = line.Split(' ', '\t');
                                dd2.xx = Convert.ToDouble(splitString1[0]);
                                dd2.yy = Convert.ToDouble(splitString1[1]);
                                ld1.Add(dd2);
                            }
                            nx = Convert.ToInt32(ld1[0].xx);
                            ny = Convert.ToInt32(ld1[0].yy);
                            MinX = ld1[1].xx;
                            MaxX = ld1[1].yy;
                            MinY = ld1[2].xx;
                            MaxY = ld1[2].yy;
                            int k = 0;
                            double[] zz = new double[nx * ny];
                            double[] xx = new double[nx];
                            double[] yy = new double[ny];
                            for (int i = 5; i < ls.Count; i++)
                            {
                                if (ls[i] == "")
                                {
                                    continue;
                                }
                                line = ls[i].Trim();
                                string[] splitString = line.Split(' ');
                                for (int j = 0; j < splitString.Length; j++)
                                {
                                    zz[k++] = Convert.ToDouble(splitString[j]);
                                }
                            }
                            xlevel = (MaxX - MinX) / (nx - 1);
                            ylevel = (MaxY - MinY) / (ny - 1);
                            for (int i = 0; i < nx; i++)
                            {
                                xx[i] = MinX + i * xlevel;
                            }
                            for (int i = 0; i < ny; i++)
                            {
                                yy[i] = MinY + i * ylevel;
                            }
                            mapForm mf = new mapForm(flag);
                            mf.x = xx;
                            mf.y = yy;
                            mf.z = zz;
                            mf.MaxX = MaxX;
                            mf.MinX = MinX;
                            mf.MaxY = MaxY;
                            mf.MinY = MinY;
                            mf.MdiParent = this;
                            mf.Show();
                        }
                    }
                    catch
                    {
                        ld = null;
                        MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                #endregion
            }
            else
            {
                return;
            }
        }
        private void OpenLineDialog(int flag)
        {
            List<data> ll = new List<data>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt(XY)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> ls = new List<string>();
                System.IO.StreamReader sr = null;
                try
                {
                    sr = new System.IO.StreamReader(ofd.FileName);
                    while (!sr.EndOfStream)
                    {
                        ls.Add(sr.ReadLine());
                    }
                }
                catch
                {
                    MessageBox.Show("数据导入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
                try
                {
                    ll.Clear();
                    string line = "";
                    data dd = new data();
                    for (int i = 0; i < ls.Count; i++)
                    {
                        line = ls[i].Trim();
                        string[] splitStr = line.Split(' ', '\t');
                        dd.xx = Convert.ToDouble(splitStr[0]);
                        dd.yy = Convert.ToDouble(splitStr[1]);
                        ll.Add(dd);
                    }
                }
                catch
                {
                    ld = null;
                    MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                double[] x = new double[ll.Count];
                double[] y = new double[ll.Count];
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = ll[i].xx;
                    y[i] = ll[i].yy;
                }
                mapForm mf = new mapForm(flag);
                mf.x = x;
                mf.y = y;
               // mf.MdiParent = this;
                mf.Show();
            }
        }
        private void OpenSanDianDialog(int flag)
        {
 
        }
        private void 等值线图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog(0);
        }

        private void 表面图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog(1);
        }

        private void 二维图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLineDialog(2);
        }

        private void 张贴图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLineDialog(3);
        }
        private void 裂缝玫瑰花图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLineDialog(7);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            ConfigureTreeView();
            //////frmResourceManager resource;
            //////resource = new frmResourceManager();
            //////resource.MdiParent = this;
            //////resource.Height = this.ClientSize.Height;
            //////resource.Location = new Point(0, 0);
            //////resource.Dock = DockStyle.Left;
            ////////resource.Height = resource.MaximumSize.Height;
            //////resource.Show();
            RefreshMap();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
            this.Dispose();
        }
 
        private void mnuPlainStress_Click(object sender, EventArgs e)
        {
            if (PlainStressForm == null || PlainStressForm.IsDisposed)
            {
                //TectonicStressForm = new frmTectonicStress(this); 
                PlainStressForm = new frmPlainStress();
            }
            //TectonicStressForm.WindowState = FormWindowState.Maximized;

            PlainStressForm.Show();
        }

        private void triStateTreeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = this.triStateTreeView1.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    this.triStateTreeView1.SelectedNode = node;
                }
                else
                {
                    return;
                }
                SetMenuVisible(node);
                this.cMnuStrip.Show(this.triStateTreeView1, e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {
                TreeNode node = this.triStateTreeView1.GetNodeAt(e.X, e.Y);
                if (node.Level > 0 && node != null)
                {
                    RefreshMap();
                }
                else
                {
                    return;
                }
                //RefreshMap();
                //SetMenuVisible(node);
                //this.cMnuStrip.Show(this.triStateTreeView1, e.Location);
            }
        }

        /// <summary>
        /// 初始化树形菜单
        /// </summary>
        private void ConfigureTreeView()
        {
            rootNode.Text = "区块名称";
            rootNode.CheckboxVisible = false;
            rootNode.IsContainer = true;

            int nodeNumber = 7;
            for (int i = 0; i < nodeNumber; i++)
            {
                TriStateTreeNode folderNode = new TriStateTreeNode(" ", 0, 1);
                folderNode.IsContainer = true;
                rootNode.Nodes.Add(folderNode);
                folderNode.CheckboxVisible = false;
            }

            TriStateTreeNode firstFolder = rootNode.FirstNode as TriStateTreeNode;
            firstFolder.Text = "地层数据";
            firstFolder.Name = "LayerData";

            TriStateTreeNode boundaryFolder = firstFolder.NextNode as TriStateTreeNode;
            boundaryFolder.Text = "工区边界";
            boundaryFolder.Name = "BoundaryData";
            boundaryFolder.CheckboxVisible = true;

            TriStateTreeNode secondFolder = boundaryFolder.NextNode as TriStateTreeNode;
            secondFolder.Text = "井数据";
            secondFolder.Name = "WellData";
            secondFolder.CheckboxVisible = true;
            
            TriStateTreeNode thirdFolder = secondFolder.NextNode as TriStateTreeNode;
            thirdFolder.Text = "断层数据";
            thirdFolder.Name = "FaultData";
            thirdFolder.CheckboxVisible = true;
            
            #region 裂缝识别部分
            TriStateTreeNode fourthFolder = thirdFolder.NextNode as TriStateTreeNode;
            fourthFolder.Text = "主曲率法裂缝识别";
            fourthFolder.Name = "Zhuqulv";
            
            TriStateTreeNode fifthFolder = fourthFolder.NextNode as TriStateTreeNode;
            fifthFolder.Text = "平面应力法裂缝识别";
            fifthFolder.Name = "Pingmianyingli";
          
            #endregion
            TriStateTreeNode sixFolder = fifthFolder.NextNode as TriStateTreeNode;
            sixFolder.Text = "玫瑰花图";
            sixFolder.Name = "RoseData";

            this.triStateTreeView1.SuspendLayout();
            this.triStateTreeView1.Nodes.Add(rootNode);
            this.triStateTreeView1.ResumeLayout();
            triStateTreeView1.ExpandAll();
 
        }
        
        /// <summary>
        /// 右键菜单显示，
        /// </summary>
        /// <param name="tn">根据tn的Level 和 Name 来确定显示那几条菜单，这就是菜单初始化中要设置Name的原因</param>
        void SetMenuVisible(TreeNode tn)
        {
            bool bOpenDicengData = false;
            bool bOpenDuancengData = false;
            bool bOpenJingweiData = false;
            bool bPrincipalCurFI = false;
            bool bTectonicStrFI = false;
            bool bDisplayMaxCurSurfaceandContour = false;
            bool bDisplayMinCurSurfaceandContour = false;

            bool bDisplayMaxStressSurfaceandContour = false;
            bool bDisplayMinStressSurfaceandContour = false;
            bool bDisplayMaxShearSurfaceandContour = false;
            bool bDisplayRose = false;
            
            bool bDisplayRS = false;
            bool bOpenBoundaryData = false;
            if (tn.Level == 1 && tn.Name == "LayerData")
            {
                bOpenDicengData = true;                
            }
            else if (tn.Level == 1 && tn.Name == "WellData")
            {
                bOpenJingweiData = true;
            }
            else if (tn.Level == 1 && tn.Name == "FaultData")
            {
                bOpenDuancengData = true;
            }
            else if (tn.Level == 1 && tn.Name == "RoseData")
            {
                bDisplayRose = true;
            }
            else if (tn.Level == 1 && tn.Name == "BoundaryData")
            {
                bOpenBoundaryData = true;
            }

            else if (tn.Level == 2 && tn.Name == "MaxCur")
            {
                bDisplayMaxCurSurfaceandContour = true;
            }
            else if (tn.Level == 2 && tn.Name == "MinCur")
            {
                bDisplayMinCurSurfaceandContour = true;
            }
            else if (tn.Level == 2 && tn.Name == "MaxStress")
            {
                bDisplayMaxStressSurfaceandContour = true;
            }
            else if (tn.Level == 2 && tn.Name == "MinStress")
            {
                bDisplayMinStressSurfaceandContour = true;
            }
            else if (tn.Level == 2 && tn.Name == "MaxShear")
            {
                bDisplayMaxShearSurfaceandContour = true;
            }
            else if (tn.Level == 2 && tn.Name == "well")
            {
                bDisplayRS = true;
                currentSelectedWell = tn.Text;
            }
            
            this.toolMnuOpenLayerData.Visible = bOpenDicengData;
            this.toolMnuOpenFaultData.Visible = bOpenDuancengData;
            this.toolMnuOpenWellData.Visible = bOpenJingweiData;
            this.toolMnuOpenBoundaryData.Visible = bOpenBoundaryData;

            this.toolMnuPrincipalCurPara.Visible = bPrincipalCurFI;
            this.toolTectonicFilter.Visible = bTectonicStrFI;
            this.toolMnuMaxCurContour.Visible = bDisplayMaxCurSurfaceandContour;
            this.toolMnuMaxCurSurface.Visible = bDisplayMaxCurSurfaceandContour;

            this.toolMnuMinCurContour.Visible = bDisplayMinCurSurfaceandContour;
            this.toolMnuMinCurSurface.Visible = bDisplayMinCurSurfaceandContour;

            this.toolMnuMaxStressContour.Visible = bDisplayMaxStressSurfaceandContour;
            this.toolMnuMaxStressSurface.Visible = bDisplayMaxStressSurfaceandContour;

            this.toolMnuMinStressContour.Visible = bDisplayMinStressSurfaceandContour;
            this.toolMnuMinStressSurface.Visible = bDisplayMinStressSurfaceandContour;

            this.toolMnuMaxShearContour.Visible = bDisplayMaxShearSurfaceandContour;
            this.toolMnuMaxShearSurface.Visible = bDisplayMaxShearSurfaceandContour;
            this.ToolMenuOpenRose.Visible = bDisplayRose;

            this.toolMnuRS.Visible = bDisplayRS;
        }

        private void toolMnuOpenLayerData_Click(object sender, EventArgs e)
        {

            //只需要把数据读入到TotalData中的LayerData中
            //OpenDialog(0);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt(XYZ)|*txt|*.*(所有文件)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
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
                        //树形控件 地层数据节点 下面添加相应子节点 节点名字可以设置为文件名
                        foreach (TriStateTreeNode node in rootNode.Nodes)
                        {
                            if (node.Name == "LayerData")
                            {
                                node.Nodes.Clear();
                                TriStateTreeNode itemNode = new TriStateTreeNode(Path.GetFileNameWithoutExtension(ofd.FileName), 2, 2);
                                node.Nodes.Add(itemNode);
                                itemNode.CheckboxVisible = true;
                                itemNode.Checked = true;
                                node.Expand();
                            }
                        }
                        TotalData.layerData = new LayerDataClass();
                        //TotalData.bDisplayLayerdata = true;

                        TotalData.layerData.Datalist.Clear();
                        //ld.Clear();
                        string line = "";
                        data3 dd = new data3();
                        for (int i = 0; i < ls.Count; i++)
                        {
                            line = ls[i].Trim();
                            string[] splitStr = line.Split(' ', '\t');
                            dd.xx = Convert.ToDouble(splitStr[0]);
                            dd.yy = Convert.ToDouble(splitStr[1]);
                            dd.zz = Convert.ToDouble(splitStr[2]);
                            //ld.Add(dd);
                            TotalData.layerData.Datalist.Add(dd);
                        }
                        double tmp = TotalData.layerData.Datalist[0].xx;
                        int NX = 0;
                        for (int i = 1; i < TotalData.layerData.Datalist.Count; i++)
                        {
                            NX++;
                            if (tmp == TotalData.layerData.Datalist[i].xx) break;
                        }
                        if (NX <= 1)
                        {
                            MessageBox.Show("请确认数据文件是否为网格化数据！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int NY = (int)(TotalData.layerData.Datalist.Count / NX);

                        if (NY == 1 || NX * NY != TotalData.layerData.Datalist.Count)
                        {
                            MessageBox.Show("请确认数据文件是否为网格化数据！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        TotalData.NX = NX;
                        TotalData.NY = NY;

                        RefreshMap();
                    }
                    catch
                    {
                        TotalData.layerData = null;
                        //TotalData.bDisplayLayerdata = false;
                        MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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
                //            mapForm mf = new mapForm(0);
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
            }
            else
            {
                return;
            }
        }

        private void toolMnuOpenFaultData_Click(object sender, EventArgs e)
        {
            List<data3> ll = new List<data3>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt(XY)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                List<string> ls = new List<string>();
                System.IO.StreamReader str = null;
                try
                {
                    str = new System.IO.StreamReader(ofd.FileName);
                    while (!str.EndOfStream)
                    {
                        ls.Add(str.ReadLine());
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                TotalData.faultData = new FaultDataClass();
                TotalData.faultData.DataList.Clear();
                try
                {
                    ll.Clear();
                    string line = "";
                    data3 dd = new data3();
                    for (int i = 0; i < ls.Count; i++)
                    {
                        line = ls[i].Trim();
                        string[] splitStr = line.Split(' ', '\t');
                        dd.xx = Convert.ToDouble(splitStr[0]);
                        dd.yy = Convert.ToDouble(splitStr[1]);
                        dd.zz = Convert.ToDouble(splitStr[2]);
                        ll.Add(dd);
                    }
                    // xFault = new double[ll.Count];
                    // yFault = new double[ll.Count];
                    //for (int i = 0; i < xFault.Length; i++)
                    //{
                    //    xFault[i] = ll[i].xx;
                    //    yFault[i] = ll[i].yy;
                    //}
                    int len = 1;
                    List<double> li = new List<double>();
                    li.Add(ll[0].zz);
                    for (int i = 0; i < ll.Count - 1; i++)
                    {
                        if (ll[i].zz != ll[i + 1].zz)
                        {
                            len++;
                            li.Add(ll[i + 1].zz);
                        }
                    }
                    for (int i = 0; i < len; i++)
                    {
                        List<data3> le = new List<data3>();
                        for (int j = 0; j < ll.Count; j++)
                        {
                            if (ll[j].zz == li[i])
                            {
                                le.Add(ll[j]);
                            }
                        }
                        TotalData.faultData.DataList.Add(le);
                        TotalData.faultData.bDisplay.Add(true);
                    }

                    foreach (TriStateTreeNode node in rootNode.Nodes)
                    {
                        if (node.Name == "FaultData")
                        {
                            node.Nodes.Clear();
                            for (int i = 0; i < len; i++)
                            {
                                TriStateTreeNode itemNode = new TriStateTreeNode(string.Format("断层 {0}",li[i]), 2, 2);
                                itemNode.Name = li[i].ToString();
                                node.Nodes.Add(itemNode);
                                itemNode.CheckboxVisible = true;
                                itemNode.Checked = true;
                                //itemNode.CheckState = CheckState.Checked;
                            }
                            node.Expand();
                        }
                        
                    }
                    RefreshMap();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ToolMnuOpenWellData_Click(object sender, EventArgs e)
        {
            List<DataStr4> ll = new List<DataStr4>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt(XY)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> ls = new List<string>();
                System.IO.StreamReader str = null;
                try
                {
                    str = new System.IO.StreamReader(ofd.FileName);
                    while (!str.EndOfStream)
                    {
                        ls.Add(str.ReadLine());
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                TotalData.wellData = new WellDataClass();
                TotalData.wellData.DataList.Clear();
                try
                {
                    string line = "";
                    DataStr4 dd = new DataStr4();
                    for (int i = 0; i < ls.Count; i++)
                    {
                        line = ls[i].Trim();
                        string[] splitStr = line.Split(' ', '\t');
                        dd.xx = Convert.ToDouble(splitStr[0]);
                        dd.yy = Convert.ToDouble(splitStr[1]);
                        dd.zz = Convert.ToString(splitStr[2]);
                        //dd.Display = true;
                        try
                        {
                            dd.ww = Convert.ToDouble(splitStr[3]);
                        }
                        catch
                        {
                            dd.ww = 0;
                        }
                        TotalData.wellData.DataList.Add(dd);
                        TotalData.wellData.bDisplay.Add(true);
                    }

                    foreach (TriStateTreeNode node in rootNode.Nodes)
                    {
                        if (node.Name == "WellData")
                        { 
                            node.Nodes.Clear();
                            for (int i = 0; i < TotalData.wellData.DataList.Count; i++)
                            {
                               
                                TriStateTreeNode itemNode = new TriStateTreeNode(TotalData.wellData.DataList[i].zz, 2, 2);
                                //itemNode.Name = TotalData.wellData.DataList[i].zz;
                                itemNode.Name = "well";
                                node.Nodes.Add(itemNode);
                                itemNode.CheckboxVisible = true;
                                itemNode.Checked = true;
                            }
                            node.Expand();
                        }
                    }
                    RefreshMap();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void ToolMenuOpenRose_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt(XY)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> ls = new List<string>();
                System.IO.StreamReader sr = null;
                try
                {
                    sr = new System.IO.StreamReader(ofd.FileName);
                    while (!sr.EndOfStream)
                    {
                        ls.Add(sr.ReadLine());
                    }
                }
                catch
                {
                    MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                TotalData.RoseData = new RoseDataClass();
                TotalData.RoseData.Datalist.Clear();
                try
                {
                    string line = "";
                    data dd = new data();
                    for (int i = 0; i < ls.Count; i++)
                    {
                        line = ls[i].Trim();
                        string[] splitStr = line.Split(' ', '\t');
                        dd.xx = Convert.ToDouble(splitStr[0]);
                        dd.yy = Convert.ToDouble(splitStr[1]);
                        TotalData.RoseData.Datalist.Add(dd);
                    }
                    foreach (TriStateTreeNode node in rootNode.Nodes)
                    {
                        if (node.Name == "RoseData")
                        {
                            node.Nodes.Clear();
                            TriStateTreeNode itemNode = new TriStateTreeNode(Path.GetFileNameWithoutExtension(ofd.FileName), 2, 2);
                            node.Nodes.Add(itemNode);
                            itemNode.CheckboxVisible = true;
                            itemNode.Checked = true;
                            node.Expand();
                        }
                    }
                    RefreshMap();
                }
                catch
                {
                    ld = null;
                    MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// 根据树形控件中各个数据的复选框状态和TotalData中布尔变量的值来确定显示哪些数据
        /// </summary>
        void RefreshMap()
        {
            foreach (TriStateTreeNode node in rootNode.Nodes)
            {
                if (node.Name == "LayerData")
                {
                        if (node.GetNodeCount(false) > 0)
                        {
                            //当前设定只能添加一个地层
                            TriStateTreeNode itemNode = node.FirstNode as TriStateTreeNode;
                            
                            TotalData.bDisplayLayerdata = itemNode.Checked;
 
                        }
                }
                else if (node.Name == "FaultData")
                {
                    if (node.GetNodeCount(false) > 0)
                    {
                        TriStateTreeNode childnode = node.FirstNode as TriStateTreeNode;
                        for (int i = 0; i < node.Nodes.Count; i++)
                        {
                            TotalData.faultData.bDisplay[i] = childnode.Checked;
                            childnode = childnode.NextNode as TriStateTreeNode;
                        }
                    }
                    
                }
                else if (node.Name == "WellData")
                {
                    if (node.GetNodeCount(false) > 0)
                    {
                        TriStateTreeNode childnode = node.FirstNode as TriStateTreeNode;
                        for (int i = 0; i < node.Nodes.Count; i++)
                        {
                            TotalData.wellData.bDisplay[i] = childnode.Checked;
                            childnode = childnode.NextNode as TriStateTreeNode;
                        }                            
                    }                  
                }
                else if (node.Name == "RoseData")
                {
                    if (node.GetNodeCount(false) > 0)
                    {
                        TriStateTreeNode itemNode = node.FirstNode as TriStateTreeNode;
                        TotalData.bDisplayRosedata = itemNode.Checked;
                    }
                }
                else if (node.Name == "BoundaryData")
                {
                    if (node.GetNodeCount(false) > 0)
                    {
                        TriStateTreeNode itemNode = node.FirstNode as TriStateTreeNode;
                        TotalData.bDisplayBoundarydata = itemNode.Checked;
                    }
                }
            }
            TotalData.DisplayLayer(this.MainChart);  

        }

        private void triStateTreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //RefreshMap();
        }

        private void pointerPB_CheckedChanged(object sender, EventArgs e)
        {
            pointerPB.BackColor = pointerPB.Checked ? Color.PaleGreen : pointerPB.Parent.BackColor;
            if (pointerPB.Checked)
                MainChart.MouseUsage = WinChartMouseUsage.ScrollOnDrag;
        }

        private void zoomInPB_CheckedChanged(object sender, EventArgs e)
        {
            zoomInPB.BackColor = zoomInPB.Checked ? Color.PaleGreen : zoomInPB.Parent.BackColor;
            if (zoomInPB.Checked)
               MainChart.MouseUsage = WinChartMouseUsage.ZoomIn;
        }

        private void zoomOutPB_CheckedChanged(object sender, EventArgs e)
        {
            zoomOutPB.BackColor = zoomOutPB.Checked ? Color.PaleGreen : zoomOutPB.Parent.BackColor;
            if (zoomOutPB.Checked)
                MainChart.MouseUsage = WinChartMouseUsage.ZoomOut;
        }

        private void MainChart_ViewPortChanged(object sender, WinViewPortEventArgs e)
        {
            RefreshMap();
        }

        private void toolMnuPrincipalCurPara_Click(object sender, EventArgs e)
        {
            if (PrincipalCurForm == null || PrincipalCurForm.IsDisposed)
            {
                PrincipalCurForm = new frmPrincipalCurvatures();
            }
            
            PrincipalCurForm.Show();
        }

        private void triStateTreeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeNode node = this.triStateTreeView1.GetNodeAt(e.X, e.Y);
                if (node != null && node.Name == "Zhuqulv")
                {
                    this.triStateTreeView1.SelectedNode = node;
                    if (MessageBox.Show("是否利用主曲率算法进行裂缝识别？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TotalData.PrincipalCurvaturesFI();

                        node.Nodes.Clear();
                        TriStateTreeNode itemNode1 = new TriStateTreeNode("最大曲率作图", 2, 2);
                        itemNode1.CheckboxVisible = true;
                        itemNode1.Name = "MaxCur";
                        node.Nodes.Add(itemNode1);
                        TriStateTreeNode itemNode2 = new TriStateTreeNode("最小曲率作图", 2, 2);
                        itemNode2.CheckboxVisible = true;
                        itemNode2.Name = "MinCur";
                        node.Nodes.Add(itemNode2);
                        
                    }
                    node.Expand();
                }
                else if (node != null && node.Name == "Pingmianyingli")
                {
                    this.triStateTreeView1.SelectedNode = node;
                    if (MessageBox.Show("是否利用平面应力算法进行裂缝识别？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TotalData.PlainStressFI();

                        node.Nodes.Clear();
                        TriStateTreeNode itemNode1 = new TriStateTreeNode("最大主应力作图", 2, 2);
                        itemNode1.CheckboxVisible = true;
                        itemNode1.Name = "MaxStress";
                        node.Nodes.Add(itemNode1);
                        TriStateTreeNode itemNode2 = new TriStateTreeNode("最小主应力作图", 2, 2);
                        itemNode2.CheckboxVisible = true;
                        itemNode2.Name = "MinStress";
                        node.Nodes.Add(itemNode2);
                        TriStateTreeNode itemNode3 = new TriStateTreeNode("最大剪切力作图", 2, 2);
                        itemNode3.CheckboxVisible = true;
                        itemNode3.Name = "MaxShear";
                        node.Nodes.Add(itemNode3);
                    }
                    node.Expand();
                }
                else
                {
                    return;
                }
                
            }
        }

        #region 裂缝识别图像显示
        private void DrawMap(List<data3> ld,int flag, string FrameName)
        {
            double[] x = new double[ld.Count];
            double[] y = new double[ld.Count];
            double[] z = new double[ld.Count];
            for (int i = 0; i < ld.Count; i++)
            {
                x[i] = ld[i].xx;
                y[i] = ld[i].yy;
                z[i] = ld[i].zz;
            }
            List<double> xx = new List<double>();
            List<double> yy = new List<double>();
            for (int i = 0; i < ld.Count; i++)
            {
                xx.Add(ld[i].xx);
                yy.Add(ld[i].yy);
            }

            MaxX = xx.Max();
            MinX = xx.Min();
            MaxY = yy.Max();
            MinY = yy.Min();
            mapForm mf = new mapForm(flag);
            mf.Text = FrameName;
            mf.x = x;
            mf.y = y;
            mf.z = z;
            mf.MaxX = MaxX;
            mf.MinX = MinX;
            mf.MaxY = MaxY;
            mf.MinY = MinY;
            //mf.WindowState = WindowState.Normal;
            //mf.MdiParent = this;
            mf.Show();
        }

        private void toolMnuMaxCurContour_Click(object sender, EventArgs e)
        {
            DrawMap(TotalData.maxCur, 0, "最大主曲率等值线图——裂缝识别");
        }

        private void toolMnuMaxCurSurface_Click(object sender, EventArgs e)
        {
            DrawMap(TotalData.maxCur, 1, "最大主曲率等值面图——裂缝识别");
        }

        private void toolMnuMinCurContour_Click(object sender, EventArgs e)
        {
            DrawMap(TotalData.minCur, 0, "最小主曲率等值线图——裂缝识别");
        }

        private void toolMnuMinCurSurface_Click(object sender, EventArgs e)
        {
            DrawMap(TotalData.minCur, 1, "最小主曲率等值线图——裂缝识别");
        }
        
        private void toolMnuMaxStressContour_Click(object sender, EventArgs e)
        {
            DrawMap(TotalData.maxStress, 0, "最大主应力等值线图——裂缝识别");
        }

        private void toolMnuMaxStressSurface_Click(object sender, EventArgs e)
        {
            DrawMap(TotalData.maxStress, 1, "最大主应力等值面图——裂缝识别");
        }

        private void toolMnuMinStressContour_Click(object sender, EventArgs e)
        {
            DrawMap(TotalData.minStress, 0, "最小主应力等值线图——裂缝识别");
        }

        private void toolMnuMinStressSurface_Click(object sender, EventArgs e)
        {
            DrawMap(TotalData.minStress, 1, "最小主应力等值面图——裂缝识别");
        }

        private void toolMnuMaxShearContour_Click(object sender, EventArgs e)
        {
            DrawMap(TotalData.maxShear, 0, "最大剪切力等值线图——裂缝识别");
        }

        private void toolMnuMaxShearSurface_Click(object sender, EventArgs e)
        {
            DrawMap(TotalData.maxStress, 1, "最大剪切力等值面图——裂缝识别");
        }
        #endregion

        private void btSurfer_Click(object sender, EventArgs e)
        {
            TotalData.createSurfaceChart(MainChart);
        }

        private void toolMnuRS_Click(object sender, EventArgs e)
        {
            if (RSFractalForm == null || RSFractalForm.IsDisposed)
            {
                RSFractalForm = new frmRSFractal(currentSelectedWell);
            }
            //RSFractalForm.WindowState = FormWindowState.Maximized;
            RSFractalForm.ShowDialog();
        }

        private void toolMnuOpenBoundaryData_Click(object sender, EventArgs e)
        {
            List<data3> lb = new List<data3>();//原始边界数据

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TXT文本文件|*.txt|ALL FILES|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
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

                TotalData.boundarydata = new List<data3>();
                TotalData.boundarydata = lb;
                //树形控件 地层数据节点 下面添加相应子节点 节点名字可以设置为文件名
                foreach (TriStateTreeNode node in rootNode.Nodes)
                {
                    if (node.Name == "BoundaryData")
                    {
                        node.Nodes.Clear();
                        TriStateTreeNode itemNode = new TriStateTreeNode("工区边界1", 2, 2);
                        node.Nodes.Add(itemNode);
                        itemNode.CheckboxVisible = true;
                        itemNode.Checked = true;
                        node.Expand();
                    }
                }
                RefreshMap();

            }
            catch
            {
                lb = null;
                MessageBox.Show("数据导入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }



    
    }
}
