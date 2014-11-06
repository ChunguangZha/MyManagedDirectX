namespace DAPS.Simulator
{
    partial class frmResourceManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResourceManager));
            this.treeMain = new System.Windows.Forms.TreeView();
            this.cMenuResource = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddConcession = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuAddNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuAddOldProject = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuEditName = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cMenuResource.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeMain
            // 
            this.treeMain.CheckBoxes = true;
            this.treeMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMain.HideSelection = false;
            this.treeMain.ImageIndex = 0;
            this.treeMain.ImageList = this.imageList1;
            this.treeMain.LabelEdit = true;
            this.treeMain.Location = new System.Drawing.Point(0, 0);
            this.treeMain.Name = "treeMain";
            this.treeMain.SelectedImageIndex = 0;
            this.treeMain.Size = new System.Drawing.Size(283, 508);
            this.treeMain.TabIndex = 6;
            this.treeMain.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeMain_BeforeLabelEdit);
            this.treeMain.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeMain_AfterLabelEdit);
            this.treeMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMain_AfterSelect);
            this.treeMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeMain_MouseClick);
            this.treeMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeMain_MouseDoubleClick);
            // 
            // cMenuResource
            // 
            this.cMenuResource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuOpen,
            this.mnuAddConcession,
            this.cMenuAdd,
            this.cMenuDelete,
            this.cMenuEditName});
            this.cMenuResource.Name = "cMenuResource";
            this.cMenuResource.Size = new System.Drawing.Size(125, 114);
            // 
            // cMenuOpen
            // 
            this.cMenuOpen.Name = "cMenuOpen";
            this.cMenuOpen.Size = new System.Drawing.Size(124, 22);
            this.cMenuOpen.Text = "打开";
            this.cMenuOpen.Click += new System.EventHandler(this.cMenuOpen_Click);
            // 
            // mnuAddConcession
            // 
            this.mnuAddConcession.Name = "mnuAddConcession";
            this.mnuAddConcession.Size = new System.Drawing.Size(124, 22);
            this.mnuAddConcession.Text = "添加区块";
            this.mnuAddConcession.Click += new System.EventHandler(this.mnuAddConcession_Click);
            // 
            // cMenuAdd
            // 
            this.cMenuAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMenuAddNewProject,
            this.cMenuAddOldProject});
            this.cMenuAdd.Name = "cMenuAdd";
            this.cMenuAdd.Size = new System.Drawing.Size(124, 22);
            this.cMenuAdd.Text = "添加";
            // 
            // cMenuAddNewProject
            // 
            this.cMenuAddNewProject.Name = "cMenuAddNewProject";
            this.cMenuAddNewProject.Size = new System.Drawing.Size(136, 22);
            this.cMenuAddNewProject.Text = "新工程";
            this.cMenuAddNewProject.Click += new System.EventHandler(this.cMenuAddNewProject_Click);
            // 
            // cMenuAddOldProject
            // 
            this.cMenuAddOldProject.Name = "cMenuAddOldProject";
            this.cMenuAddOldProject.Size = new System.Drawing.Size(136, 22);
            this.cMenuAddOldProject.Text = "已存在工程";
            this.cMenuAddOldProject.Click += new System.EventHandler(this.cMenuAddOldProject_Click);
            // 
            // cMenuDelete
            // 
            this.cMenuDelete.Name = "cMenuDelete";
            this.cMenuDelete.Size = new System.Drawing.Size(124, 22);
            this.cMenuDelete.Text = "删除";
            this.cMenuDelete.Click += new System.EventHandler(this.cMenuDelete_Click);
            // 
            // cMenuEditName
            // 
            this.cMenuEditName.Name = "cMenuEditName";
            this.cMenuEditName.Size = new System.Drawing.Size(124, 22);
            this.cMenuEditName.Text = "修改名称";
            this.cMenuEditName.Click += new System.EventHandler(this.cMenuEditName_Click);
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
            // frmResourceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 508);
            this.Controls.Add(this.treeMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmResourceManager";
            this.Text = "工程资源管理器";
            this.Activated += new System.EventHandler(this.frmResourceManager_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmResourceManager_FormClosing);
            this.Load += new System.EventHandler(this.frmResourceManager_Load);
            this.cMenuResource.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeMain;
        private System.Windows.Forms.ContextMenuStrip cMenuResource;
        private System.Windows.Forms.ToolStripMenuItem cMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem cMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem cMenuAddNewProject;
        private System.Windows.Forms.ToolStripMenuItem cMenuAddOldProject;
        private System.Windows.Forms.ToolStripMenuItem cMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem cMenuEditName;
        private System.Windows.Forms.ToolStripMenuItem mnuAddConcession;
        private System.Windows.Forms.ImageList imageList1;
    }
}