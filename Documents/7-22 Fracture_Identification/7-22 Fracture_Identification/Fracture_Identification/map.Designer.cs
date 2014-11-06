namespace Fracture_Identification
{
    partial class mapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mapForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.井坐标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断层线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointerPB = new System.Windows.Forms.RadioButton();
            this.zoomInPB = new System.Windows.Forms.RadioButton();
            this.zoomOutPB = new System.Windows.Forms.RadioButton();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.zoomLevelLabel = new System.Windows.Forms.Label();
            this.navigatePad = new System.Windows.Forms.Panel();
            this.navigateWindow = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.winChartViewer1 = new ChartDirector.WinChartViewer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.navigatePad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.井坐标ToolStripMenuItem,
            this.断层线ToolStripMenuItem,
            this.清空ToolStripMenuItem});
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            // 
            // 井坐标ToolStripMenuItem
            // 
            this.井坐标ToolStripMenuItem.Name = "井坐标ToolStripMenuItem";
            this.井坐标ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.井坐标ToolStripMenuItem.Text = "井坐标";
            this.井坐标ToolStripMenuItem.Click += new System.EventHandler(this.井坐标ToolStripMenuItem_Click);
            // 
            // 断层线ToolStripMenuItem
            // 
            this.断层线ToolStripMenuItem.Name = "断层线ToolStripMenuItem";
            this.断层线ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.断层线ToolStripMenuItem.Text = "断层线";
            this.断层线ToolStripMenuItem.Click += new System.EventHandler(this.断层线ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // pointerPB
            // 
            this.pointerPB.Appearance = System.Windows.Forms.Appearance.Button;
            this.pointerPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pointerPB.Image = ((System.Drawing.Image)(resources.GetObject("pointerPB.Image")));
            this.pointerPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pointerPB.Location = new System.Drawing.Point(1, 1);
            this.pointerPB.Name = "pointerPB";
            this.pointerPB.Size = new System.Drawing.Size(117, 37);
            this.pointerPB.TabIndex = 1;
            this.pointerPB.TabStop = true;
            this.pointerPB.Text = " Pointer";
            this.pointerPB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pointerPB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.pointerPB, "点击参数");
            this.pointerPB.UseVisualStyleBackColor = true;
            this.pointerPB.CheckedChanged += new System.EventHandler(this.pointerPB_CheckedChanged);
            // 
            // zoomInPB
            // 
            this.zoomInPB.Appearance = System.Windows.Forms.Appearance.Button;
            this.zoomInPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomInPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomInPB.Image")));
            this.zoomInPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomInPB.Location = new System.Drawing.Point(1, 37);
            this.zoomInPB.Name = "zoomInPB";
            this.zoomInPB.Size = new System.Drawing.Size(117, 40);
            this.zoomInPB.TabIndex = 2;
            this.zoomInPB.TabStop = true;
            this.zoomInPB.Text = " Zoom In";
            this.zoomInPB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.zoomInPB, "放大");
            this.zoomInPB.UseVisualStyleBackColor = true;
            this.zoomInPB.CheckedChanged += new System.EventHandler(this.zoomInPB_CheckedChanged);
            // 
            // zoomOutPB
            // 
            this.zoomOutPB.Appearance = System.Windows.Forms.Appearance.Button;
            this.zoomOutPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomOutPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutPB.Image")));
            this.zoomOutPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomOutPB.Location = new System.Drawing.Point(1, 76);
            this.zoomOutPB.Name = "zoomOutPB";
            this.zoomOutPB.Size = new System.Drawing.Size(117, 44);
            this.zoomOutPB.TabIndex = 3;
            this.zoomOutPB.TabStop = true;
            this.zoomOutPB.Text = " Zoom Out";
            this.zoomOutPB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.zoomOutPB, "缩小");
            this.zoomOutPB.UseVisualStyleBackColor = true;
            this.zoomOutPB.CheckedChanged += new System.EventHandler(this.zoomOutPB_CheckedChanged);
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.LightGray;
            this.leftPanel.Controls.Add(this.zoomBar);
            this.leftPanel.Controls.Add(this.zoomLevelLabel);
            this.leftPanel.Controls.Add(this.navigatePad);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Controls.Add(this.zoomOutPB);
            this.leftPanel.Controls.Add(this.zoomInPB);
            this.leftPanel.Controls.Add(this.pointerPB);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(118, 481);
            this.leftPanel.TabIndex = 4;
            // 
            // zoomBar
            // 
            this.zoomBar.Location = new System.Drawing.Point(0, 150);
            this.zoomBar.Maximum = 100;
            this.zoomBar.Minimum = 1;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(116, 45);
            this.zoomBar.TabIndex = 38;
            this.zoomBar.TabStop = false;
            this.zoomBar.TickFrequency = 10;
            this.zoomBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip1.SetToolTip(this.zoomBar, "滑动伸缩比例");
            this.zoomBar.Value = 1;
            this.zoomBar.ValueChanged += new System.EventHandler(this.zoomBar_ValueChanged);
            // 
            // zoomLevelLabel
            // 
            this.zoomLevelLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomLevelLabel.Location = new System.Drawing.Point(12, 127);
            this.zoomLevelLabel.Name = "zoomLevelLabel";
            this.zoomLevelLabel.Size = new System.Drawing.Size(96, 18);
            this.zoomLevelLabel.TabIndex = 37;
            this.zoomLevelLabel.Text = "Zoom Level";
            // 
            // navigatePad
            // 
            this.navigatePad.AllowDrop = true;
            this.navigatePad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.navigatePad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.navigatePad.Controls.Add(this.navigateWindow);
            this.navigatePad.Location = new System.Drawing.Point(1, 203);
            this.navigatePad.Name = "navigatePad";
            this.navigatePad.Size = new System.Drawing.Size(115, 95);
            this.navigatePad.TabIndex = 35;
            this.toolTip1.SetToolTip(this.navigatePad, "移动显示区域");
            // 
            // navigateWindow
            // 
            this.navigateWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navigateWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.navigateWindow.Location = new System.Drawing.Point(15, 19);
            this.navigateWindow.Name = "navigateWindow";
            this.navigateWindow.Size = new System.Drawing.Size(67, 52);
            this.navigateWindow.TabIndex = 0;
            this.toolTip1.SetToolTip(this.navigateWindow, "移动显示区域");
            this.navigateWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.navigateWindow_MouseDown);
            this.navigateWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.navigateWindow_MouseMove);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(117, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 481);
            this.label1.TabIndex = 4;
            // 
            // winChartViewer1
            // 
            this.winChartViewer1.ChartSizeMode = ChartDirector.WinChartSizeMode.StretchImage;
            this.winChartViewer1.ContextMenuStrip = this.contextMenuStrip1;
            this.winChartViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winChartViewer1.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.winChartViewer1.Location = new System.Drawing.Point(118, 0);
            this.winChartViewer1.Name = "winChartViewer1";
            this.winChartViewer1.ScrollDirection = ChartDirector.WinChartDirection.HorizontalVertical;
            this.winChartViewer1.Size = new System.Drawing.Size(593, 481);
            this.winChartViewer1.TabIndex = 5;
            this.winChartViewer1.TabStop = false;
            this.winChartViewer1.ZoomDirection = ChartDirector.WinChartDirection.HorizontalVertical;
            this.winChartViewer1.ClickHotSpot += new ChartDirector.WinHotSpotEventHandler(this.winChartViewer1_ClickHotSpot);
            this.winChartViewer1.ViewPortChanged += new ChartDirector.WinViewPortEventHandler(this.winChartViewer1_ViewPortChanged);
            this.winChartViewer1.MouseEnter += new System.EventHandler(this.winChartViewer1_MouseEnter);
            // 
            // mapForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(711, 481);
            this.Controls.Add(this.winChartViewer1);
            this.Controls.Add(this.leftPanel);
            this.Name = "mapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "map";
            this.Load += new System.EventHandler(this.mapForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.navigatePad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 井坐标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断层线ToolStripMenuItem;
        private System.Windows.Forms.RadioButton pointerPB;
        private System.Windows.Forms.RadioButton zoomInPB;
        private System.Windows.Forms.RadioButton zoomOutPB;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label label1;
        private ChartDirector.WinChartViewer winChartViewer1;
        private System.Windows.Forms.Panel navigatePad;
        private System.Windows.Forms.Label navigateWindow;
        private System.Windows.Forms.TrackBar zoomBar;
        private System.Windows.Forms.Label zoomLevelLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
    }
}