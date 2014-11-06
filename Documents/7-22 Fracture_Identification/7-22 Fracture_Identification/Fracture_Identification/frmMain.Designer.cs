namespace Fracture_Identification
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSysterm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFracIdent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRSFractal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrincipalCurvatures = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlainStress = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOption = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.网格化ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.距离反比网格化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分形平面插值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分形曲线插值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分形平面插值ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.等值线图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表面图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.张贴图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二维图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.裂缝玫瑰花图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolRSFractal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTectonicFilter = new System.Windows.Forms.ToolStripButton();
            this.triStateTreeView1 = new SmartSolutions.Controls.TriStateTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cMnuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMnuOpenLayerData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuOpenFaultData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuOpenWellData = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolMenuOpenRose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuPrincipalCurPara = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuTectonicStrPara = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuMaxCurContour = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuMaxCurSurface = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuMinCurContour = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuMinCurSurface = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuMaxStressContour = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuMaxStressSurface = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuMinStressContour = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuMinStressSurface = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuMaxShearContour = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuMaxShearSurface = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMnuRS = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainChart = new ChartDirector.WinChartViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btSurfer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.zoomOutPB = new System.Windows.Forms.RadioButton();
            this.zoomInPB = new System.Windows.Forms.RadioButton();
            this.pointerPB = new System.Windows.Forms.RadioButton();
            this.toolMnuOpenBoundaryData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.cMnuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSysterm,
            this.mnuFracIdent,
            this.mnuOption,
            this.mnuHelp,
            this.网格化ToolStripMenuItem1,
            this.分形平面插值ToolStripMenuItem,
            this.地图ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(819, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuSysterm
            // 
            this.mnuSysterm.Name = "mnuSysterm";
            this.mnuSysterm.Size = new System.Drawing.Size(44, 21);
            this.mnuSysterm.Text = "系统";
            // 
            // mnuFracIdent
            // 
            this.mnuFracIdent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRSFractal,
            this.mnuPrincipalCurvatures,
            this.mnuPlainStress});
            this.mnuFracIdent.Name = "mnuFracIdent";
            this.mnuFracIdent.Size = new System.Drawing.Size(68, 21);
            this.mnuFracIdent.Text = "裂缝识别";
            // 
            // mnuRSFractal
            // 
            this.mnuRSFractal.Name = "mnuRSFractal";
            this.mnuRSFractal.Size = new System.Drawing.Size(136, 22);
            this.mnuRSFractal.Text = "R/S分形法";
            this.mnuRSFractal.Click += new System.EventHandler(this.mnuRSFractal_Click);
            // 
            // mnuPrincipalCurvatures
            // 
            this.mnuPrincipalCurvatures.Name = "mnuPrincipalCurvatures";
            this.mnuPrincipalCurvatures.Size = new System.Drawing.Size(136, 22);
            this.mnuPrincipalCurvatures.Text = "主曲率法";
            this.mnuPrincipalCurvatures.Click += new System.EventHandler(this.mnuPrincipalCurvatures_Click);
            // 
            // mnuPlainStress
            // 
            this.mnuPlainStress.Name = "mnuPlainStress";
            this.mnuPlainStress.Size = new System.Drawing.Size(136, 22);
            this.mnuPlainStress.Text = "平面应力法";
            this.mnuPlainStress.Click += new System.EventHandler(this.mnuPlainStress_Click);
            // 
            // mnuOption
            // 
            this.mnuOption.Name = "mnuOption";
            this.mnuOption.Size = new System.Drawing.Size(44, 21);
            this.mnuOption.Text = "选项";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 21);
            this.mnuHelp.Text = "帮助";
            // 
            // 网格化ToolStripMenuItem1
            // 
            this.网格化ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.距离反比网格化ToolStripMenuItem});
            this.网格化ToolStripMenuItem1.Name = "网格化ToolStripMenuItem1";
            this.网格化ToolStripMenuItem1.Size = new System.Drawing.Size(56, 21);
            this.网格化ToolStripMenuItem1.Text = "网格化";
            // 
            // 距离反比网格化ToolStripMenuItem
            // 
            this.距离反比网格化ToolStripMenuItem.Name = "距离反比网格化ToolStripMenuItem";
            this.距离反比网格化ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.距离反比网格化ToolStripMenuItem.Text = "网格化";
            this.距离反比网格化ToolStripMenuItem.Click += new System.EventHandler(this.距离反比网格化ToolStripMenuItem_Click);
            // 
            // 分形平面插值ToolStripMenuItem
            // 
            this.分形平面插值ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.分形曲线插值ToolStripMenuItem,
            this.分形平面插值ToolStripMenuItem1});
            this.分形平面插值ToolStripMenuItem.Name = "分形平面插值ToolStripMenuItem";
            this.分形平面插值ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.分形平面插值ToolStripMenuItem.Text = "分形插值";
            // 
            // 分形曲线插值ToolStripMenuItem
            // 
            this.分形曲线插值ToolStripMenuItem.Name = "分形曲线插值ToolStripMenuItem";
            this.分形曲线插值ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.分形曲线插值ToolStripMenuItem.Text = "分形曲线插值";
            this.分形曲线插值ToolStripMenuItem.Click += new System.EventHandler(this.分形曲线插值ToolStripMenuItem_Click);
            // 
            // 分形平面插值ToolStripMenuItem1
            // 
            this.分形平面插值ToolStripMenuItem1.Name = "分形平面插值ToolStripMenuItem1";
            this.分形平面插值ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.分形平面插值ToolStripMenuItem1.Text = "分形平面插值";
            this.分形平面插值ToolStripMenuItem1.Click += new System.EventHandler(this.分形平面插值ToolStripMenuItem1_Click);
            // 
            // 地图ToolStripMenuItem
            // 
            this.地图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.等值线图ToolStripMenuItem,
            this.表面图ToolStripMenuItem,
            this.张贴图ToolStripMenuItem,
            this.二维图ToolStripMenuItem,
            this.裂缝玫瑰花图ToolStripMenuItem});
            this.地图ToolStripMenuItem.Name = "地图ToolStripMenuItem";
            this.地图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.地图ToolStripMenuItem.Text = "地图";
            // 
            // 等值线图ToolStripMenuItem
            // 
            this.等值线图ToolStripMenuItem.Name = "等值线图ToolStripMenuItem";
            this.等值线图ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.等值线图ToolStripMenuItem.Text = "等值线图";
            this.等值线图ToolStripMenuItem.Click += new System.EventHandler(this.等值线图ToolStripMenuItem_Click);
            // 
            // 表面图ToolStripMenuItem
            // 
            this.表面图ToolStripMenuItem.Name = "表面图ToolStripMenuItem";
            this.表面图ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.表面图ToolStripMenuItem.Text = "表面图";
            this.表面图ToolStripMenuItem.Click += new System.EventHandler(this.表面图ToolStripMenuItem_Click);
            // 
            // 张贴图ToolStripMenuItem
            // 
            this.张贴图ToolStripMenuItem.Name = "张贴图ToolStripMenuItem";
            this.张贴图ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.张贴图ToolStripMenuItem.Text = "张贴图";
            this.张贴图ToolStripMenuItem.Click += new System.EventHandler(this.张贴图ToolStripMenuItem_Click);
            // 
            // 二维图ToolStripMenuItem
            // 
            this.二维图ToolStripMenuItem.Name = "二维图ToolStripMenuItem";
            this.二维图ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.二维图ToolStripMenuItem.Text = "曲线图";
            this.二维图ToolStripMenuItem.Click += new System.EventHandler(this.二维图ToolStripMenuItem_Click);
            // 
            // 裂缝玫瑰花图ToolStripMenuItem
            // 
            this.裂缝玫瑰花图ToolStripMenuItem.Name = "裂缝玫瑰花图ToolStripMenuItem";
            this.裂缝玫瑰花图ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.裂缝玫瑰花图ToolStripMenuItem.Text = "裂缝玫瑰花图";
            this.裂缝玫瑰花图ToolStripMenuItem.Click += new System.EventHandler(this.裂缝玫瑰花图ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRSFractal,
            this.toolStripSeparator1,
            this.toolTectonicFilter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(819, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolRSFractal
            // 
            this.toolRSFractal.Image = global::Fracture_Identification.Properties.Resources.计算器icon_2x;
            this.toolRSFractal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRSFractal.Name = "toolRSFractal";
            this.toolRSFractal.Size = new System.Drawing.Size(100, 36);
            this.toolRSFractal.Text = "R/S分形法";
            this.toolRSFractal.Click += new System.EventHandler(this.mnuRSFractal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolTectonicFilter
            // 
            this.toolTectonicFilter.Image = global::Fracture_Identification.Properties.Resources.safariicon_2x;
            this.toolTectonicFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTectonicFilter.Name = "toolTectonicFilter";
            this.toolTectonicFilter.Size = new System.Drawing.Size(92, 36);
            this.toolTectonicFilter.Text = "主曲率法";
            this.toolTectonicFilter.Click += new System.EventHandler(this.mnuPrincipalCurvatures_Click);
            // 
            // triStateTreeView1
            // 
            this.triStateTreeView1.CheckBoxes = true;
            this.triStateTreeView1.CheckedImageIndex = 3;
            this.triStateTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triStateTreeView1.ImageIndex = 0;
            this.triStateTreeView1.ImageList = this.imageList1;
            this.triStateTreeView1.IndeterminateImageIndex = 4;
            this.triStateTreeView1.Location = new System.Drawing.Point(0, 0);
            this.triStateTreeView1.Name = "triStateTreeView1";
            this.triStateTreeView1.SelectedImageIndex = 1;
            this.triStateTreeView1.Size = new System.Drawing.Size(229, 518);
            this.triStateTreeView1.TabIndex = 6;
            this.triStateTreeView1.UncheckedImageIndex = 5;
            this.triStateTreeView1.UseCustomImages = true;
            this.triStateTreeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.triStateTreeView1_AfterCheck);
            this.triStateTreeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.triStateTreeView1_MouseClick);
            this.triStateTreeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.triStateTreeView1_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            // 
            // cMnuStrip
            // 
            this.cMnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMnuOpenLayerData,
            this.toolMnuOpenFaultData,
            this.toolMnuOpenWellData,
            this.ToolMenuOpenRose,
            this.toolMnuPrincipalCurPara,
            this.toolMnuTectonicStrPara,
            this.toolMnuMaxCurContour,
            this.toolMnuMaxCurSurface,
            this.toolMnuMinCurContour,
            this.toolMnuMinCurSurface,
            this.toolMnuMaxStressContour,
            this.toolMnuMaxStressSurface,
            this.toolMnuMinStressContour,
            this.toolMnuMinStressSurface,
            this.toolMnuMaxShearContour,
            this.toolMnuMaxShearSurface,
            this.toolMnuRS,
            this.toolMnuOpenBoundaryData});
            this.cMnuStrip.Name = "cMnuStrip";
            this.cMnuStrip.Size = new System.Drawing.Size(197, 422);
            // 
            // toolMnuOpenLayerData
            // 
            this.toolMnuOpenLayerData.Name = "toolMnuOpenLayerData";
            this.toolMnuOpenLayerData.Size = new System.Drawing.Size(196, 22);
            this.toolMnuOpenLayerData.Text = "读取地层数据";
            this.toolMnuOpenLayerData.Visible = false;
            this.toolMnuOpenLayerData.Click += new System.EventHandler(this.toolMnuOpenLayerData_Click);
            // 
            // toolMnuOpenFaultData
            // 
            this.toolMnuOpenFaultData.Name = "toolMnuOpenFaultData";
            this.toolMnuOpenFaultData.Size = new System.Drawing.Size(196, 22);
            this.toolMnuOpenFaultData.Text = "读取断层数据";
            this.toolMnuOpenFaultData.Visible = false;
            this.toolMnuOpenFaultData.Click += new System.EventHandler(this.toolMnuOpenFaultData_Click);
            // 
            // ToolMnuOpenWellData
            // 
            this.toolMnuOpenWellData.Name = "ToolMnuOpenWellData";
            this.toolMnuOpenWellData.Size = new System.Drawing.Size(196, 22);
            this.toolMnuOpenWellData.Text = "读取井位数据";
            this.toolMnuOpenWellData.Visible = false;
            this.toolMnuOpenWellData.Click += new System.EventHandler(this.ToolMnuOpenWellData_Click);
            // 
            // ToolMenuOpenRose
            // 
            this.ToolMenuOpenRose.Name = "ToolMenuOpenRose";
            this.ToolMenuOpenRose.Size = new System.Drawing.Size(196, 22);
            this.ToolMenuOpenRose.Text = "读取裂缝玫瑰花图数据";
            this.ToolMenuOpenRose.Visible = false;
            this.ToolMenuOpenRose.Click += new System.EventHandler(this.ToolMenuOpenRose_Click);
            // 
            // toolMnuPrincipalCurPara
            // 
            this.toolMnuPrincipalCurPara.Name = "toolMnuPrincipalCurPara";
            this.toolMnuPrincipalCurPara.Size = new System.Drawing.Size(196, 22);
            this.toolMnuPrincipalCurPara.Text = "主曲率参数设置";
            this.toolMnuPrincipalCurPara.Visible = false;
            this.toolMnuPrincipalCurPara.Click += new System.EventHandler(this.toolMnuPrincipalCurPara_Click);
            // 
            // toolMnuTectonicStrPara
            // 
            this.toolMnuTectonicStrPara.Name = "toolMnuTectonicStrPara";
            this.toolMnuTectonicStrPara.Size = new System.Drawing.Size(196, 22);
            this.toolMnuTectonicStrPara.Text = "构造应力参数设置";
            this.toolMnuTectonicStrPara.Visible = false;
            // 
            // toolMnuMaxCurContour
            // 
            this.toolMnuMaxCurContour.Name = "toolMnuMaxCurContour";
            this.toolMnuMaxCurContour.Size = new System.Drawing.Size(196, 22);
            this.toolMnuMaxCurContour.Text = "显示等值线图";
            this.toolMnuMaxCurContour.Visible = false;
            this.toolMnuMaxCurContour.Click += new System.EventHandler(this.toolMnuMaxCurContour_Click);
            // 
            // toolMnuMaxCurSurface
            // 
            this.toolMnuMaxCurSurface.Name = "toolMnuMaxCurSurface";
            this.toolMnuMaxCurSurface.Size = new System.Drawing.Size(196, 22);
            this.toolMnuMaxCurSurface.Text = "显示等值面图";
            this.toolMnuMaxCurSurface.Visible = false;
            this.toolMnuMaxCurSurface.Click += new System.EventHandler(this.toolMnuMaxCurSurface_Click);
            // 
            // toolMnuMinCurContour
            // 
            this.toolMnuMinCurContour.Name = "toolMnuMinCurContour";
            this.toolMnuMinCurContour.Size = new System.Drawing.Size(196, 22);
            this.toolMnuMinCurContour.Text = "显示等值线图";
            this.toolMnuMinCurContour.Visible = false;
            this.toolMnuMinCurContour.Click += new System.EventHandler(this.toolMnuMinCurContour_Click);
            // 
            // toolMnuMinCurSurface
            // 
            this.toolMnuMinCurSurface.Name = "toolMnuMinCurSurface";
            this.toolMnuMinCurSurface.Size = new System.Drawing.Size(196, 22);
            this.toolMnuMinCurSurface.Text = "显示等值面图";
            this.toolMnuMinCurSurface.Visible = false;
            this.toolMnuMinCurSurface.Click += new System.EventHandler(this.toolMnuMinCurSurface_Click);
            // 
            // toolMnuMaxStressContour
            // 
            this.toolMnuMaxStressContour.Name = "toolMnuMaxStressContour";
            this.toolMnuMaxStressContour.Size = new System.Drawing.Size(196, 22);
            this.toolMnuMaxStressContour.Text = "显示等值线图";
            this.toolMnuMaxStressContour.Visible = false;
            this.toolMnuMaxStressContour.Click += new System.EventHandler(this.toolMnuMaxStressContour_Click);
            // 
            // toolMnuMaxStressSurface
            // 
            this.toolMnuMaxStressSurface.Name = "toolMnuMaxStressSurface";
            this.toolMnuMaxStressSurface.Size = new System.Drawing.Size(196, 22);
            this.toolMnuMaxStressSurface.Text = "显示等值面图";
            this.toolMnuMaxStressSurface.Visible = false;
            this.toolMnuMaxStressSurface.Click += new System.EventHandler(this.toolMnuMaxStressSurface_Click);
            // 
            // toolMnuMinStressContour
            // 
            this.toolMnuMinStressContour.Name = "toolMnuMinStressContour";
            this.toolMnuMinStressContour.Size = new System.Drawing.Size(196, 22);
            this.toolMnuMinStressContour.Text = "显示等值线图";
            this.toolMnuMinStressContour.Visible = false;
            this.toolMnuMinStressContour.Click += new System.EventHandler(this.toolMnuMinStressContour_Click);
            // 
            // toolMnuMinStressSurface
            // 
            this.toolMnuMinStressSurface.Name = "toolMnuMinStressSurface";
            this.toolMnuMinStressSurface.Size = new System.Drawing.Size(196, 22);
            this.toolMnuMinStressSurface.Text = "显示等值面图";
            this.toolMnuMinStressSurface.Visible = false;
            this.toolMnuMinStressSurface.Click += new System.EventHandler(this.toolMnuMinStressSurface_Click);
            // 
            // toolMnuMaxShearContour
            // 
            this.toolMnuMaxShearContour.Name = "toolMnuMaxShearContour";
            this.toolMnuMaxShearContour.Size = new System.Drawing.Size(196, 22);
            this.toolMnuMaxShearContour.Text = "显示等值线图";
            this.toolMnuMaxShearContour.Visible = false;
            this.toolMnuMaxShearContour.Click += new System.EventHandler(this.toolMnuMaxShearContour_Click);
            // 
            // toolMnuMaxShearSurface
            // 
            this.toolMnuMaxShearSurface.Name = "toolMnuMaxShearSurface";
            this.toolMnuMaxShearSurface.Size = new System.Drawing.Size(196, 22);
            this.toolMnuMaxShearSurface.Text = "显示等值面图";
            this.toolMnuMaxShearSurface.Visible = false;
            this.toolMnuMaxShearSurface.Click += new System.EventHandler(this.toolMnuMaxShearSurface_Click);
            // 
            // toolMnuRS
            // 
            this.toolMnuRS.Name = "toolMnuRS";
            this.toolMnuRS.Size = new System.Drawing.Size(196, 22);
            this.toolMnuRS.Text = " R/S裂缝识别";
            this.toolMnuRS.Visible = false;
            this.toolMnuRS.Click += new System.EventHandler(this.toolMnuRS_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.triStateTreeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 518);
            this.panel1.TabIndex = 9;
            // 
            // MainChart
            // 
            this.MainChart.ChartSizeMode = ChartDirector.WinChartSizeMode.StretchImage;
            this.MainChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainChart.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.MainChart.Location = new System.Drawing.Point(229, 64);
            this.MainChart.Name = "MainChart";
            this.MainChart.ScrollDirection = ChartDirector.WinChartDirection.HorizontalVertical;
            this.MainChart.Size = new System.Drawing.Size(590, 518);
            this.MainChart.TabIndex = 10;
            this.MainChart.TabStop = false;
            this.MainChart.ZoomDirection = ChartDirector.WinChartDirection.HorizontalVertical;
            this.MainChart.ViewPortChanged += new ChartDirector.WinViewPortEventHandler(this.MainChart_ViewPortChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(818, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 518);
            this.label1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(817, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 518);
            this.label2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(816, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 493);
            this.label3.TabIndex = 13;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.LightGray;
            this.leftPanel.Controls.Add(this.btSurfer);
            this.leftPanel.Controls.Add(this.label4);
            this.leftPanel.Controls.Add(this.zoomOutPB);
            this.leftPanel.Controls.Add(this.zoomInPB);
            this.leftPanel.Controls.Add(this.pointerPB);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.leftPanel.Location = new System.Drawing.Point(229, 557);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(588, 25);
            this.leftPanel.TabIndex = 15;
            // 
            // btSurfer
            // 
            this.btSurfer.Location = new System.Drawing.Point(305, 1);
            this.btSurfer.Name = "btSurfer";
            this.btSurfer.Size = new System.Drawing.Size(30, 24);
            this.btSurfer.TabIndex = 5;
            this.btSurfer.Text = "t";
            this.btSurfer.UseVisualStyleBackColor = true;
            this.btSurfer.Click += new System.EventHandler(this.btSurfer_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(587, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1, 25);
            this.label4.TabIndex = 4;
            // 
            // zoomOutPB
            // 
            this.zoomOutPB.Appearance = System.Windows.Forms.Appearance.Button;
            this.zoomOutPB.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.zoomOutPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomOutPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutPB.Image")));
            this.zoomOutPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomOutPB.Location = new System.Drawing.Point(278, 1);
            this.zoomOutPB.Name = "zoomOutPB";
            this.zoomOutPB.Size = new System.Drawing.Size(27, 24);
            this.zoomOutPB.TabIndex = 3;
            this.zoomOutPB.TabStop = true;
            this.zoomOutPB.Text = " ";
            this.zoomOutPB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.zoomOutPB.UseVisualStyleBackColor = true;
            this.zoomOutPB.CheckedChanged += new System.EventHandler(this.zoomOutPB_CheckedChanged);
            // 
            // zoomInPB
            // 
            this.zoomInPB.Appearance = System.Windows.Forms.Appearance.Button;
            this.zoomInPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomInPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomInPB.Image")));
            this.zoomInPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomInPB.Location = new System.Drawing.Point(252, 1);
            this.zoomInPB.Name = "zoomInPB";
            this.zoomInPB.Size = new System.Drawing.Size(27, 24);
            this.zoomInPB.TabIndex = 2;
            this.zoomInPB.TabStop = true;
            this.zoomInPB.Text = " ";
            this.zoomInPB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.zoomInPB.UseVisualStyleBackColor = true;
            this.zoomInPB.CheckedChanged += new System.EventHandler(this.zoomInPB_CheckedChanged);
            // 
            // pointerPB
            // 
            this.pointerPB.Appearance = System.Windows.Forms.Appearance.Button;
            this.pointerPB.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pointerPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pointerPB.Image = ((System.Drawing.Image)(resources.GetObject("pointerPB.Image")));
            this.pointerPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pointerPB.Location = new System.Drawing.Point(230, 1);
            this.pointerPB.Name = "pointerPB";
            this.pointerPB.Size = new System.Drawing.Size(22, 24);
            this.pointerPB.TabIndex = 1;
            this.pointerPB.TabStop = true;
            this.pointerPB.Text = " ";
            this.pointerPB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pointerPB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.pointerPB.UseVisualStyleBackColor = true;
            this.pointerPB.CheckedChanged += new System.EventHandler(this.pointerPB_CheckedChanged);
            // 
            // toolMnuOpenBoundaryData
            // 
            this.toolMnuOpenBoundaryData.Name = "toolMnuOpenBoundaryData";
            this.toolMnuOpenBoundaryData.Size = new System.Drawing.Size(196, 22);
            this.toolMnuOpenBoundaryData.Text = "读取边界数据";
            this.toolMnuOpenBoundaryData.Visible = false;
            this.toolMnuOpenBoundaryData.Click += new System.EventHandler(this.toolMnuOpenBoundaryData_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 582);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainChart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "裂缝识别系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cMnuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSysterm;
        private System.Windows.Forms.ToolStripMenuItem mnuFracIdent;
        private System.Windows.Forms.ToolStripMenuItem mnuOption;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuRSFractal;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolRSFractal;
        private System.Windows.Forms.ToolStripMenuItem mnuPrincipalCurvatures;
        private System.Windows.Forms.ToolStripButton toolTectonicFilter;
        private System.Windows.Forms.ToolStripMenuItem 分形平面插值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分形平面插值ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 分形曲线插值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 网格化ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 距离反比网格化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 等值线图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 张贴图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 二维图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表面图ToolStripMenuItem;
        private SmartSolutions.Controls.TriStateTreeView triStateTreeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem mnuPlainStress;
        private System.Windows.Forms.ContextMenuStrip cMnuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolMnuOpenLayerData;
        private System.Windows.Forms.ToolStripMenuItem toolMnuOpenFaultData;
        private System.Windows.Forms.ToolStripMenuItem toolMnuOpenWellData;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuOpenRose;
        private System.Windows.Forms.Panel panel1;
        private ChartDirector.WinChartViewer MainChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton zoomOutPB;
        private System.Windows.Forms.RadioButton zoomInPB;
        private System.Windows.Forms.RadioButton pointerPB;
        private System.Windows.Forms.ToolStripMenuItem 裂缝玫瑰花图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolMnuPrincipalCurPara;
        private System.Windows.Forms.ToolStripMenuItem toolMnuTectonicStrPara;
        private System.Windows.Forms.ToolStripMenuItem toolMnuMaxCurContour;
        private System.Windows.Forms.ToolStripMenuItem toolMnuMaxCurSurface;
        private System.Windows.Forms.ToolStripMenuItem toolMnuMinCurContour;
        private System.Windows.Forms.ToolStripMenuItem toolMnuMinCurSurface;
        private System.Windows.Forms.ToolStripMenuItem toolMnuMaxStressContour;
        private System.Windows.Forms.ToolStripMenuItem toolMnuMaxStressSurface;
        private System.Windows.Forms.ToolStripMenuItem toolMnuMinStressContour;
        private System.Windows.Forms.ToolStripMenuItem toolMnuMinStressSurface;
        private System.Windows.Forms.ToolStripMenuItem toolMnuMaxShearContour;
        private System.Windows.Forms.ToolStripMenuItem toolMnuMaxShearSurface;
        private System.Windows.Forms.Button btSurfer;
        private System.Windows.Forms.ToolStripMenuItem toolMnuRS;
        private System.Windows.Forms.ToolStripMenuItem toolMnuOpenBoundaryData;
    }
}

