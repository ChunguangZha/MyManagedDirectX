namespace MyManagedDirectX
{
    partial class MainForm
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemViewAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRotatePan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRotateX = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRotateY = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRotateZ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemLoadSplitLayerData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonViewAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotatePan = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateX = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateY = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateZ = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.map3DControl1 = new MyManagedDirectX.Map3DControl();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemViewAll,
            this.toolStripMenuItemRotatePan,
            this.toolStripMenuItemZoomIn,
            this.toolStripMenuItemZoomOut,
            this.toolStripMenuItemRotateX,
            this.toolStripMenuItemRotateY,
            this.toolStripMenuItemRotateZ,
            this.toolStripSeparator2,
            this.toolStripMenuItemLoadSplitLayerData});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 186);
            // 
            // toolStripMenuItemViewAll
            // 
            this.toolStripMenuItemViewAll.Name = "toolStripMenuItemViewAll";
            this.toolStripMenuItemViewAll.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemViewAll.Text = "显示全图";
            this.toolStripMenuItemViewAll.Click += new System.EventHandler(this.toolStripMenuItemViewAll_Click);
            // 
            // toolStripMenuItemRotatePan
            // 
            this.toolStripMenuItemRotatePan.Image = global::MyManagedDirectX.Properties.Resources.环游;
            this.toolStripMenuItemRotatePan.Name = "toolStripMenuItemRotatePan";
            this.toolStripMenuItemRotatePan.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemRotatePan.Text = "环游";
            this.toolStripMenuItemRotatePan.Click += new System.EventHandler(this.toolStripMenuItemRotatePan_Click);
            // 
            // toolStripMenuItemZoomIn
            // 
            this.toolStripMenuItemZoomIn.Image = global::MyManagedDirectX.Properties.Resources.放大;
            this.toolStripMenuItemZoomIn.Name = "toolStripMenuItemZoomIn";
            this.toolStripMenuItemZoomIn.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemZoomIn.Text = "放大";
            this.toolStripMenuItemZoomIn.Click += new System.EventHandler(this.toolStripMenuItemZoomIn_Click);
            // 
            // toolStripMenuItemZoomOut
            // 
            this.toolStripMenuItemZoomOut.Image = global::MyManagedDirectX.Properties.Resources.缩小;
            this.toolStripMenuItemZoomOut.Name = "toolStripMenuItemZoomOut";
            this.toolStripMenuItemZoomOut.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemZoomOut.Text = "缩小";
            this.toolStripMenuItemZoomOut.Click += new System.EventHandler(this.toolStripMenuItemZoomOut_Click);
            // 
            // toolStripMenuItemRotateX
            // 
            this.toolStripMenuItemRotateX.Image = global::MyManagedDirectX.Properties.Resources.绕X旋转;
            this.toolStripMenuItemRotateX.Name = "toolStripMenuItemRotateX";
            this.toolStripMenuItemRotateX.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemRotateX.Text = "绕X轴旋转";
            this.toolStripMenuItemRotateX.Click += new System.EventHandler(this.toolStripMenuItemRotateX_Click);
            // 
            // toolStripMenuItemRotateY
            // 
            this.toolStripMenuItemRotateY.Image = global::MyManagedDirectX.Properties.Resources.绕Z旋转;
            this.toolStripMenuItemRotateY.Name = "toolStripMenuItemRotateY";
            this.toolStripMenuItemRotateY.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemRotateY.Text = "绕Y轴旋转";
            this.toolStripMenuItemRotateY.Click += new System.EventHandler(this.toolStripMenuItemRotateY_Click);
            // 
            // toolStripMenuItemRotateZ
            // 
            this.toolStripMenuItemRotateZ.Image = global::MyManagedDirectX.Properties.Resources.绕Z旋转;
            this.toolStripMenuItemRotateZ.Name = "toolStripMenuItemRotateZ";
            this.toolStripMenuItemRotateZ.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemRotateZ.Text = "绕Z轴旋转";
            this.toolStripMenuItemRotateZ.Click += new System.EventHandler(this.toolStripMenuItemRotateZ_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // toolStripMenuItemLoadSplitLayerData
            // 
            this.toolStripMenuItemLoadSplitLayerData.Name = "toolStripMenuItemLoadSplitLayerData";
            this.toolStripMenuItemLoadSplitLayerData.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemLoadSplitLayerData.Text = "导入断层数据";
            this.toolStripMenuItemLoadSplitLayerData.Click += new System.EventHandler(this.toolStripMenuItemLoadSplitLayerData_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonViewAll,
            this.toolStripButtonRotatePan,
            this.toolStripButtonZoomIn,
            this.toolStripButtonZoomOut,
            this.toolStripButtonRotateX,
            this.toolStripButtonRotateY,
            this.toolStripButtonRotateZ,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(568, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonViewAll
            // 
            this.toolStripButtonViewAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonViewAll.Image = global::MyManagedDirectX.Properties.Resources.拉框放大;
            this.toolStripButtonViewAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonViewAll.Name = "toolStripButtonViewAll";
            this.toolStripButtonViewAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonViewAll.Text = "显示全图";
            this.toolStripButtonViewAll.Click += new System.EventHandler(this.toolStripMenuItemViewAll_Click);
            // 
            // toolStripButtonRotatePan
            // 
            this.toolStripButtonRotatePan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotatePan.Image = global::MyManagedDirectX.Properties.Resources.环游;
            this.toolStripButtonRotatePan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotatePan.Name = "toolStripButtonRotatePan";
            this.toolStripButtonRotatePan.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRotatePan.Text = "环游";
            this.toolStripButtonRotatePan.Click += new System.EventHandler(this.toolStripMenuItemRotatePan_Click);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomIn.Image = global::MyManagedDirectX.Properties.Resources.放大;
            this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonZoomIn.Text = "放大";
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.toolStripMenuItemZoomIn_Click);
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomOut.Image = global::MyManagedDirectX.Properties.Resources.缩小;
            this.toolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonZoomOut.Text = "缩小";
            this.toolStripButtonZoomOut.Click += new System.EventHandler(this.toolStripMenuItemZoomOut_Click);
            // 
            // toolStripButtonRotateX
            // 
            this.toolStripButtonRotateX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateX.Image = global::MyManagedDirectX.Properties.Resources.绕X旋转;
            this.toolStripButtonRotateX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateX.Name = "toolStripButtonRotateX";
            this.toolStripButtonRotateX.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRotateX.Text = "绕X轴旋转";
            this.toolStripButtonRotateX.Click += new System.EventHandler(this.toolStripMenuItemRotateX_Click);
            // 
            // toolStripButtonRotateY
            // 
            this.toolStripButtonRotateY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateY.Image = global::MyManagedDirectX.Properties.Resources.绕Z旋转;
            this.toolStripButtonRotateY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateY.Name = "toolStripButtonRotateY";
            this.toolStripButtonRotateY.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRotateY.Text = "绕Y轴旋转";
            this.toolStripButtonRotateY.Click += new System.EventHandler(this.toolStripMenuItemRotateY_Click);
            // 
            // toolStripButtonRotateZ
            // 
            this.toolStripButtonRotateZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateZ.Image = global::MyManagedDirectX.Properties.Resources.绕Z旋转;
            this.toolStripButtonRotateZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateZ.Name = "toolStripButtonRotateZ";
            this.toolStripButtonRotateZ.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRotateZ.Text = "绕Z轴旋转";
            this.toolStripButtonRotateZ.Click += new System.EventHandler(this.toolStripMenuItemRotateZ_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // map3DControl1
            // 
            this.map3DControl1.Action = MyManagedDirectX.de3DAction.PanRotate;
            this.map3DControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.map3DControl1.BackGroundColor = System.Drawing.Color.Black;
            this.map3DControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map3DControl1.Location = new System.Drawing.Point(0, 25);
            this.map3DControl1.Name = "map3DControl1";
            this.map3DControl1.Size = new System.Drawing.Size(568, 364);
            this.map3DControl1.TabIndex = 3;
            this.map3DControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.map3DControl1_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 389);
            this.Controls.Add(this.map3DControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemViewAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRotatePan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemZoomIn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemZoomOut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRotateX;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRotateY;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotatePan;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateX;
        private System.Windows.Forms.ToolStripButton toolStripButtonViewAll;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateY;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateZ;
        private Map3DControl map3DControl1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRotateZ;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadSplitLayerData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}