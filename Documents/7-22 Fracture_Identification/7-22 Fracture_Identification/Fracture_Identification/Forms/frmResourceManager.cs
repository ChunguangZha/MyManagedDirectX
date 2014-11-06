using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAPS.Simulator
{
    //public partial class frmResourceManager : Form, IResource, IToolMerge  
    public partial class frmResourceManager : Form
    {
        public frmResourceManager()
        {
            InitializeComponent();
        }
        bool bOpenVisible = false, bAddConcessionVisible = false;
        bool bAddnewProjVisible = false, bAddOldProjVisible = false, bEditVisible = false, bDeleteVisible = false;
        //bool bSaveVisible = false, bSaveAsVisible = false;
        private void frmResourceManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        //public IResource resourceOperator;
        
        private void LoadResource()
        {
            try
            {
                ResourceMgr resource = new ResourceMgr();
                resource.Read();
                if (resource.SysResource == null) return;
                this.treeMain.Nodes.Clear();

                TreeNode tn0 = this.treeMain.Nodes.Add("所有区块");

                foreach (XmlNode xn1 in resource.SysResource.SelectNodes("ResourceManager")[0].ChildNodes)
                {
                    TreeNode tn1 = tn0.Nodes.Add(XmlConvert.DecodeName(xn1.Name));
                    tn1.Tag = XmlConvert.DecodeName(xn1.Attributes["path"].Value);
                    if (!Directory.Exists(tn1.Tag.ToString()))
                    {
                        tn1.Remove();
                        continue;
                    }
                    foreach (XmlNode xn2 in xn1.ChildNodes)
                    {
                        TreeNode tn2 = tn1.Nodes.Add(XmlConvert.DecodeName(xn2.Name));
                        tn2.Tag = XmlConvert.DecodeName(xn2.Attributes["path"].Value);// tn1.Text + "\\" + tn2.Text + "\\";

                        if (!Directory.Exists(XmlConvert.DecodeName(tn2.Tag.ToString())))
                        {
                            tn2.Remove();
                            continue;

                        }
                        if (!File.Exists(XmlConvert.DecodeName(tn2.Tag.ToString() + "\\" + xn2.Name + ".DAPS"))) continue;
                        TreeNode tn3 = tn2.Nodes.Add(XmlConvert.DecodeName(xn2.Name + ".DAPS"));
                        tn3.Tag = XmlConvert.DecodeName(tn2.Tag.ToString() + "\\" + xn2.Name + ".DAPS");
                        if (File.Exists(XmlConvert.DecodeName(tn2.Tag.ToString() + "\\" + xn2.Name + ".PROD")))
                        {
                            TreeNode tn4 = tn2.Nodes.Add(XmlConvert.DecodeName(xn2.Name + ".PROD"));
                            tn4.Tag = XmlConvert.DecodeName(tn2.Tag.ToString() + "\\" + xn2.Name + ".PROD");
                        }
                        if (File.Exists(XmlConvert.DecodeName(tn2.Tag.ToString() + "\\" + xn2.Name + ".RESP")))
                        {
                            TreeNode tn4 = tn2.Nodes.Add(XmlConvert.DecodeName(xn2.Name + ".RESP"));
                            tn4.Tag = XmlConvert.DecodeName(tn2.Tag.ToString() + "\\" + xn2.Name + ".RESP");
                        }
                    }
                }
            }
            catch{}
            this.treeMain.ExpandAll();
        }

        private void frmResourceManager_Load(object sender, EventArgs e)
        {
            LoadResource();
        }

        private bool IsValidFileName(string fileName)
        {
            bool isValid = true;
            string errChar = "\\/:*?\"<>|";
            if (string.IsNullOrEmpty(fileName))
            {
                isValid = false;
            }
            else
            {
                if (fileName.ToCharArray()[0] >= '0' && fileName.ToCharArray()[0] <= '9')
                {
                    return false;
                }
                for (int i = 0; i < errChar.Length; i++)
                {
                    if (fileName.Contains(errChar[i].ToString()))
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            return isValid;
        }

        private void treeMain_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {            
            TreeNode tnSelected = this.treeMain.SelectedNode;
            //if (tnSelected.Level != 2) return;
            if (e.Label == null || e.Label.Trim() == "") return;
            {
                //名称中有空格
                if (!IsValidFileName(e.Label))
                {
                    MessageBox.Show("文件名不合法","错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.CancelEdit = true;
                    return;
                }
                //名称重复
                //if (tnSelected.Level == 2)
                {
                    foreach (TreeNode tn in e.Node.Parent.Nodes)
                    {
                        if (tn.Text == e.Label&&tn.Text!=tnSelected.Text)
                        {
                            MessageBox.Show("文件名重复", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.CancelEdit = true;
                            return;
                        }
                    }
                }
                
                //如果是工程
                if (e.Node.Level == 2)
                {
                    bool _canEidt = true;
                    //////if (this.resourceOperator != null)
                    //////{
                    //////    _canEidt = this.resourceOperator.AllowRename(tnSelected.Tag.ToString(),false);
                    //////}
                    if (!_canEidt)
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("当前工程已经加载，不允许修改名称。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (!RenameProject(tnSelected.Tag.ToString(), tnSelected.Parent.Tag.ToString() + "\\" + e.Label))
                    {
                        MessageBox.Show("重命名失败，请检查文件夹访问权限。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.CancelEdit = true;
                        return;
                    }                    
                }
                if (e.Node.Level == 1)//如果是区块
                {
                    bool _canEidt = true;
                    ////if (this.resourceOperator != null)
                    ////{
                    ////    _canEidt = this.resourceOperator.AllowRename(tnSelected.Tag.ToString(), true);
                    ////}
                    if (!_canEidt)
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("当前区块中已经有工程加载，不允许修改名称。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    RenameBlock(tnSelected.Tag.ToString(), tnSelected.Tag.ToString().Substring(0, tnSelected.Tag.ToString().LastIndexOf('\\')) + "\\" + e.Label);
                }
            }
            SaveResource();
        }

        private bool RenameProject(string oldPath, string newPath)
        {
            //oldPath:c:\abc\block\prj1 newpath:c:\abc\block\prj2
            string sOldFileNameWithoutExt =Path.GetFileNameWithoutExtension(oldPath);//prj1
            string sNewFileNameWithoutExt =Path.GetFileNameWithoutExtension(newPath);//prj2
            bool bRenameFolderSuccess = Tools.RenameFolder(oldPath, newPath);
            if (!bRenameFolderSuccess) return false;
            string sFileDaps = newPath + "\\" + sOldFileNameWithoutExt + ".DAPS";//c:\abc\block\prj2\prj1.daps
            string sFileProd = newPath + "\\" + sOldFileNameWithoutExt + ".PROD";//c:\abc\block\prj2\prj1.prod
            string sFileResp = newPath + "\\" + sOldFileNameWithoutExt + ".RESP";//c:\abc\block\prj2\prj1.resp
            bool bRenameDapsSuccess=true,bRenameProdSuccess=true,bRenameRespSuccess=true;
            if (File.Exists(sFileDaps))//c:\abc\block\prj2\prj1.daps                c:\abc\block\prj2\prj2.daps
                bRenameDapsSuccess = Tools.RenameFile(sFileDaps, newPath + "\\" + sNewFileNameWithoutExt + ".DAPS");
            if (File.Exists(sFileProd))
                bRenameProdSuccess = Tools.RenameFile(sFileProd, newPath + "\\" + sNewFileNameWithoutExt + ".PROD");
            if (File.Exists(sFileResp))
                bRenameRespSuccess = Tools.RenameFile(sFileResp, newPath + "\\" + sNewFileNameWithoutExt + ".RESP");
            if (bRenameDapsSuccess && bRenameProdSuccess && bRenameRespSuccess)
            {
                UpdateNode(oldPath,newPath);
                return true;
            }
            return false;
        }

        private void UpdateNode(string oldPath,string newPath)
        {
            foreach (TreeNode tnRoot in this.treeMain.Nodes)
            {
                foreach (TreeNode tnBlock in tnRoot.Nodes)
                {
                    foreach (TreeNode tnProject in tnBlock.Nodes)
                    {
                        if (tnProject.Tag.ToString() == oldPath)
                        {
                            tnProject.Text = newPath.Substring(newPath.LastIndexOf('\\') + 1);
                            tnProject.Tag = newPath;
                            string sFileNameWithoutExt = Path.GetFileNameWithoutExtension(newPath);
                            foreach (TreeNode tnFile in tnProject.Nodes)
                            {
                                string sExt = Path.GetExtension(tnFile.Tag.ToString());
                                tnFile.Tag = newPath + "\\" + sFileNameWithoutExt + sExt;
                                tnFile.Text = sFileNameWithoutExt + sExt;
                            }
                        }
                    }
                }
            }
        }

        private void SaveResource()
        {
            ResourceMgr resource = new ResourceMgr();
            resource.SysResource = new XmlDocument();

            resource.SysResource.CreateXmlDeclaration("1.0", "utf-8", null);

            TreeNode tn0 = this.treeMain.Nodes[0];
            XmlNode xn0 = resource.SysResource.AppendChild(resource.SysResource.CreateElement("ResourceManager"));

            foreach (TreeNode tn1 in tn0.Nodes)
            {
                XmlElement xe = resource.SysResource.CreateElement(XmlConvert.EncodeName(tn1.Text));
                xe.SetAttribute("path", XmlConvert.EncodeName(tn1.Tag.ToString()));
                XmlNode xn1 = xn0.AppendChild(xe);                

                foreach (TreeNode tn2 in tn1.Nodes)
                {
                    XmlElement xePrj = resource.SysResource.CreateElement(XmlConvert.EncodeName(tn2.Text));
                    xePrj.SetAttribute("path", XmlConvert.EncodeName(tn2.Tag.ToString()));
                    XmlNode xn2 = xn1.AppendChild(xePrj);
                    
                }
            }

            resource.Write();
        }

        private void treeMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void treeMain_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Level == 0 || e.Node.Level == 3)
            {
                e.Node.EndEdit(true);
            }
        }

        //右键菜单显示
        void SetMenuVisible(TreeNode tn)
        {
            //bSaveAsVisible = false;
            //bSaveVisible = false;
            bOpenVisible = false;
            bAddConcessionVisible = false;
            bAddnewProjVisible = false;
            bAddOldProjVisible = false;
            bEditVisible = false;
            bDeleteVisible = false;


            if (tn.Level == 0)
            {
                bOpenVisible = false;
                bAddnewProjVisible = false;
                bAddOldProjVisible = false;
                bEditVisible = false;
                bDeleteVisible = false;
                //bSaveVisible = false;
                //bSaveAsVisible = false;
                bAddConcessionVisible = true;

            }
            else if (tn.Level == 1)
            {
                bOpenVisible = false;
                bAddConcessionVisible = false;
                bAddnewProjVisible = true;
                bAddOldProjVisible = true;
                bEditVisible = true;
                bDeleteVisible = true;
                //bSaveVisible = false;
                //bSaveAsVisible = false;

            }
            else if (tn.Level == 2)
            {
                bOpenVisible = true;
                bAddConcessionVisible = false;
                bAddnewProjVisible = false;
                bAddOldProjVisible = false;
                bEditVisible = true;
                bDeleteVisible = true;
                //bSaveVisible = true;
                //bSaveAsVisible = true;
            }

            this.cMenuOpen.Visible = bOpenVisible;
            this.cMenuAdd.Visible = bAddnewProjVisible || bAddOldProjVisible;
            this.mnuAddConcession.Visible = bAddConcessionVisible;
            this.cMenuAddNewProject.Visible = bAddnewProjVisible;
            this.cMenuAddOldProject.Visible = bAddOldProjVisible;
            this.cMenuEditName.Visible = bEditVisible;
            this.cMenuDelete.Visible = bDeleteVisible;
            //this.cMenuSave.Visible = bSaveVisible;
            //this.cMenuSaveAs.Visible = bSaveAsVisible;

        }

        private void treeMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = this.treeMain.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    this.treeMain.SelectedNode = node;
                }
                else
                {
                    return;
                }
                SetMenuVisible(node);
                this.cMenuResource.Show(this.treeMain, e.Location);
            }
        }

        private void treeMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeNode node = this.treeMain.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    this.treeMain.SelectedNode = node;
                }
                else
                {
                    return;
                }

                if (node.Level == 2 || node.Level == 3)
                {
                    node.ExpandAll();
                    this.cMenuOpen_Click(this, e);
                }
            }
        }
       
        private void AddConcessions(string sConcessionName, string sPath)
        {
            foreach (TreeNode tn in treeMain.Nodes)
            {
                foreach (TreeNode tnBlock in tn.Nodes)
                {
                    if (tnBlock.Level != 1) continue;
                    if (tnBlock.Tag != null && tnBlock.Tag.ToString().Trim().ToLower() == sPath.ToLower())
                    {
                        MessageBox.Show("该区块已经存在。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            TreeNode tnn = this.treeMain.Nodes[0].Nodes.Add(sConcessionName);
            tnn.Tag = sPath;
            LoadProjects(sPath, tnn);
            tnn.ExpandAll();
            SaveResource();
        }

        private void AddProjectToConcession(string concessionPath, string projectPath)
        {
            bool bFoundBlock = false;
            TreeNode tnBloak=null;
            foreach (TreeNode tn in this.treeMain.Nodes[0].Nodes)
            {
                if (tn.Tag.ToString().ToLower() == concessionPath.ToLower())
                {
                    bFoundBlock = true;
                    tnBloak=tn;
                    break;
                }
            }
            if (bFoundBlock)
            {
                LoadProject(projectPath, tnBloak);
            }
        }

        private void AddProjectsToConcession(string concessionPath, string projectPath)
        {
            //拷贝文件夹
            bool bCopyFolderSuccess = CopyDirectory(concessionPath, projectPath);
            if (!bCopyFolderSuccess)
            {
                MessageBox.Show("拷贝文件夹失败，请确保源文件夹存在且在目标位置具有文件夹的读写权限。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //查找现有节点有无区块与concessionPath对应的区块相同
            bool bFoundBlock = false;
            TreeNode tnBloak = null;
            foreach (TreeNode tn in this.treeMain.Nodes[0].Nodes)
            {
                if (tn.Tag.ToString().ToLower() == concessionPath.ToLower())
                {
                    bFoundBlock = true;
                    tnBloak = tn;
                    break;
                }
            }
            if (bFoundBlock)
            {
                LoadProject(concessionPath, tnBloak);
            }
        }

        private void LoadProject(string sProject, TreeNode nodeConcession)
        {
            if (!Directory.Exists(sProject)) return;
            AddProjects(sProject, nodeConcession);            
        }

        /// <summary>
        /// 文件夹拷贝操作
        /// </summary>
        /// <param name="concessionPath">区块文件夹</param>
        /// <param name="projectPath">项目文件夹</param>
        /// <returns></returns>
        private bool CopyDirectory(string concessionPath, string projectPath)
        {
            if (!Directory.Exists(concessionPath)) return false;
            if (!Directory.Exists(projectPath)) return false;
            return Tools.CopyFolder(projectPath, concessionPath + "\\" + projectPath.Substring(projectPath.LastIndexOf('\\') + 1));
           
        }

        private bool RenameBlock(string oldName,string newName)
        {
            if (!Tools.RenameFolder(oldName, newName)) return false;
            foreach (TreeNode tnRoot in this.treeMain.Nodes)
            {
                foreach (TreeNode tnBlock in tnRoot.Nodes)
                {
                    if (tnBlock.Tag.ToString().ToLower() == oldName.ToLower())//找到改名的区块的节点
                    {
                        tnBlock.Tag = newName;
                        tnBlock.Text = newName.Substring(newName.LastIndexOf('\\') + 1);
                        foreach (TreeNode tnPrj in tnBlock.Nodes)
                        {
                            tnPrj.Tag = newName + "\\" + tnPrj.Text;//改项目节点tag
                            foreach (TreeNode tnFile in tnPrj.Nodes)
                            {
                                tnFile.Tag = tnPrj.Tag.ToString() + "\\" + tnFile.Text;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void LoadProjects(string sConcession,TreeNode nodeConcession)
        {
            if (!Directory.Exists(sConcession)) return;
            string[] projects = Directory.GetDirectories(sConcession);
            if (projects == null || projects.Length == 0) return;
            //查找项目
            foreach (string sPrj in projects)
            {
                AddProjects(sPrj, nodeConcession);                
            }
        }

        /// <summary>
        /// 在指定的节点下添加项目
        /// </summary>
        /// <param name="sPrj">项目文件夹</param>
        /// <param name="nodeConcession">区块节点</param>
        private void AddProjects(string sPrj, TreeNode nodeConcession)
        {
            string[] sFiles = Directory.GetFiles(sPrj);
            if (sFiles == null || sFiles.Length == 0) return;
            foreach (string sFile in sFiles)
            {
                string prjName = sPrj.Substring(sPrj.LastIndexOf('\\') + 1);//项目名称
                string sFileFullPath=sPrj+"\\"+prjName+".DAPS";//数据文件全路径期望值
                if (sFile.ToLower() == sFileFullPath.ToLower())
                {
                    if (TryOpenDataFile(sFile))
                    {
                        TreeNode tDaps = nodeConcession.Nodes.Add(prjName);
                        tDaps.Tag = sPrj;
                        TreeNode tFile = tDaps.Nodes.Add(Path.GetFileName(sFileFullPath).Substring(Path.GetFileName(sFileFullPath).LastIndexOf('\\') + 1));
                        tFile.Tag = sFileFullPath;
                        string sProdFilePath = sPrj + "\\" + prjName + ".Prod";
                        string sRespFilePath = sPrj + "\\" + prjName + ".RESP";
                        FileInfo fiProd = new FileInfo(sProdFilePath);
                        FileInfo fiResp = new FileInfo(sRespFilePath);
                        if (fiProd.Exists)
                        {
                                TreeNode tProd = tDaps.Nodes.Add(sProdFilePath.Substring(sProdFilePath.LastIndexOf('\\') + 1));
                                tProd.Tag = sProdFilePath;
                           
                        }
                       
                        if (fiResp.Exists)
                        {
                            TreeNode tResp = tDaps.Nodes.Add(sRespFilePath.Substring(sRespFilePath.LastIndexOf('\\') + 1));
                            tResp.Tag = sRespFilePath;
                        }
                       
                    }
                }
                
            }
        }

        private bool TryOpenDataFile(string file)
        {
            FileInfo fi = new FileInfo(file);
            if (!fi.Exists)
            {
                return false;
            }

            FileStream fs = null;
            //OrignData _orignData = null;           
            BinaryFormatter bf = new BinaryFormatter();
            string str = "";
            try
            {
                fs = new FileStream(file, FileMode.Open);
                object o = bf.Deserialize(fs);
                //_orignData = (OrignData)o;
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }

        //删除功能
        private void cMenuDelete_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeMain.SelectedNode;
            //移除区块
            if (tn.Level == 1)
            {
                if (MessageBox.Show("确定移除该区块及该区块下所有工程吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (tn.Nodes.Count != 0)
                {
                    if (MessageBox.Show("是否保留工程文件?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        if (Directory.Exists(tn.Tag.ToString()))
                        {
                            if (!Tools.DeleteFolder(tn.Tag.ToString()))
                            {
                                MessageBox.Show("已经删除该区块，但对应的文件夹删除失败，请检查文件夹访问权限。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }
                        }
                    }
                }
                else
                {
                    if (Directory.Exists(tn.Tag.ToString()))
                    {
                        Tools.DeleteFolder(tn.Tag.ToString());
                    }
                }
                tn.Remove();
            }
            //移除工程
            else if (tn.Level == 2)
            {
                if (MessageBox.Show("确定删除该工程吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (tn.Nodes.Count != 0)
                {
                    if (MessageBox.Show("是否保留工程文件?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        if (!Tools.DeleteFolder(tn.Tag.ToString()))
                        {
                            MessageBox.Show("已经删除该工程，但对应的文件夹删除失败，请检查文件夹访问权限。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                    }
                }
                tn.Remove();
            }
            SaveResource();

        }

        //移除工程
        private void RemoveProject(TreeNode tn, bool SaveFile)
        {
            if (!SaveFile)
            {
                Directory.Delete((string)(tn.Tag) + tn.Text, true);
            }
            tn.Remove();
        }

        //重命名
        private void cMenuEditName_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeMain.SelectedNode;
            tn.BeginEdit();
        }

        //新建工程
        private void cMenuAddNewProject_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.treeMain.SelectedNode;
            string blockPath = selectedNode.Tag.ToString();
            string strName = "工程";
            int iName = 0;
            bool bSameName;
            do
            {
                iName++;
                bSameName = false;
                foreach (TreeNode tn in selectedNode.Nodes)
                {
                    if (tn.Text.ToLower() == (strName + iName.ToString()).ToLower())
                    {
                        bSameName = true;
                        break;
                    }
                }
                if (Directory.Exists(selectedNode.Tag + "\\" + strName + iName.ToString()))
                {
                    bSameName = true;
                }
            } while (bSameName);

            try
            {
                Directory.CreateDirectory(selectedNode.Tag + "\\" + strName + iName.ToString());
                bool bCreateFileSuccess=CreateNewDAPSFile(selectedNode.Tag + "\\" + strName + iName.ToString() + "\\" + strName + iName.ToString() + ".DAPS");
                if (!bCreateFileSuccess)
                {
                    MessageBox.Show("创建文件失败，请确认文件夹的访问权限。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("创建文件失败，请检查文件夹访问权限。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TreeNode tnProj = selectedNode.Nodes.Add(strName + iName.ToString());
            tnProj.Tag = blockPath + "\\" + tnProj.Text;

            TreeNode tnDaps=tnProj.Nodes.Add(strName + iName.ToString() + ".DAPS");
            tnDaps.Tag = tnProj.Tag.ToString() + "\\" + strName + iName.ToString() + ".DAPS";
            
            this.treeMain.SelectedNode = tnProj;
            tnProj.ExpandAll();
            tnProj.BeginEdit();

            SaveResource();


        }

        private bool CreateNewDAPSFile(string p)
        {
            //////OrignData data = new OrignData();
            //RunControl runControl = new RunControl();
            //runControl.BOutPutParaData = true;
            //runControl.DataOutFrequence = 10;
            //runControl.MaxNewtonPerTimeStep = 250;
            //runControl.MaxPressureChange = 10;
            //runControl.MaxSimulateTime = 3650;
            //runControl.MaxSWChange = 0.01f;
            //runControl.MaxTimeStep = 99999;
            //runControl.PressureTolerrance = 0.01f;
            //runControl.Unit = SimulatorUnit.Metric;
            //data.RunControlData = runControl;
            ////data.DataIntergrity = false;

            FileStream fs = null;
            BinaryFormatter bf = null;
            try
            {
                fs = new FileStream(p, FileMode.Create, FileAccess.Write);
                bf = new BinaryFormatter();
                ////bf.Serialize(fs, data);
                return true;
            }
            catch
            {                
                return false;
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
        }

        //添加已存在工程
        private void cMenuAddOldProject_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "打开工程";
            folder.ShowNewFolderButton = false;
            TreeNode selectedNode = this.treeMain.SelectedNode;

            if (folder.ShowDialog() == DialogResult.OK)
            {
                //检查是否重名
                foreach (TreeNode tn in selectedNode.Nodes)
                {
                    if (tn.Text.ToLower() == folder.SelectedPath.Substring(folder.SelectedPath.LastIndexOf('\\') + 1).ToLower())
                    {
                        MessageBox.Show("已存在同名工程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }                   
                }
                //检查是否有DAPS文件
                if (!File.Exists(folder.SelectedPath + "\\" + folder.SelectedPath.Substring(folder.SelectedPath.LastIndexOf('\\') + 1) + ".DAPS"))
                {
                    MessageBox.Show("参数文件不存在","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!TryOpenDataFile(folder.SelectedPath + "\\" + folder.SelectedPath.Substring(folder.SelectedPath.LastIndexOf('\\') + 1) + ".DAPS"))
                {
                    MessageBox.Show("参数文件不合法", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Directory.Exists(selectedNode.Tag.ToString() + "\\" + folder.SelectedPath.Substring(folder.SelectedPath.LastIndexOf('\\') + 1)))
                {
                    if (!CopyDirectory(selectedNode.Tag.ToString(), folder.SelectedPath))
                    {
                        //拷贝文件夹失败
                        MessageBox.Show("添加项目失败，请确认文件夹访问权限。","提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }                    
                }
                AddProjectToConcession(selectedNode.Tag.ToString(), selectedNode.Tag.ToString()+"\\"+folder.SelectedPath.Substring(folder.SelectedPath.LastIndexOf('\\')+1));                              
                SaveResource();
            }
        }

        private void cMenuOpen_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.treeMain.SelectedNode;
            string filePathAndName="";
            if (selectedNode.Level == 2)
            {
                filePathAndName =  selectedNode.Tag.ToString();
                filePathAndName += "\\"+filePathAndName.Substring(filePathAndName.LastIndexOf('\\') + 1) + ".DAPS";
            }
            if (selectedNode.Level == 3)
            {
                string str=selectedNode.Tag.ToString();
                filePathAndName = str.Substring(0, str.Length - 5) + ".DAPS";
            }
            //////if (this.resourceOperator != null)
            //////    resourceOperator.OpenDataFile(filePathAndName);
            
        }

        private void cMenuSaveAs_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeMain.SelectedNode;

            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "另存为...";
            folder.ShowNewFolderButton = true;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                //工程文件夹重名
                if (Directory.Exists(folder.SelectedPath + "\\" + tn.Text))
                {
                    MessageBox.Show("文件夹重名","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    Directory.CreateDirectory(folder.SelectedPath + "\\" + tn.Text);
                    FileInfo fi = new FileInfo(tn.Tag.ToString() + "\\" + tn.Text + ".DAPS");
                    if (!fi.Exists) return;
                    File.Copy(tn.Tag.ToString() + "\\" + tn.Text + ".DAPS", folder.SelectedPath + "\\" + tn.Text + "\\" + tn.Text + ".DAPS");
                    fi = new FileInfo(tn.Tag.ToString() + "\\" + tn.Text + ".PROD");
                    if (fi.Exists)
                        File.Copy(tn.Tag.ToString() + "\\" + tn.Text + ".PROD", folder.SelectedPath + "\\" + tn.Text + "\\" + tn.Text + ".PROD");
                    fi = new FileInfo(tn.Tag.ToString() + "\\" + tn.Text + ".RESP");
                    if (fi.Exists)
                        File.Copy(tn.Tag.ToString() + "\\" + tn.Text + ".RESP", folder.SelectedPath + "\\" + tn.Text + "\\" + tn.Text + ".RESP");
                    AddConcessions(folder.SelectedPath.Substring(folder.SelectedPath.LastIndexOf('\\') + 1), folder.SelectedPath);
                    SaveResource();
                }
                catch
                {
                    MessageBox.Show("另存工程失败，请检查文件夹访问权限。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }


        }

        delegate void RefreshTree(string prjPath);

        private void mnuAddConcession_Click(object sender, EventArgs e)
        {
            //frmAddConcession addConForm = new frmAddConcession();
            //if (addConForm.ShowDialog() != DialogResult.OK) return;
            //if (addConForm.ConcessionName == "" || addConForm.ConcessionPath == "") return;
            //string sConcessionName = addConForm.ConcessionName;
            //string sPath = addConForm.ConcessionPath;
            ////判断所指定的区块是否已经存在
            //AddConcessions(sConcessionName, sPath);
        }

        #region IResource 成员

        public void RefreshProjectNode(string prjPath)
        {
            if(!this.treeMain.InvokeRequired)
            RefreshTreeNode(prjPath);
            else
            {
                RefreshTree operation = new RefreshTree(RefreshTreeNode);
                this.treeMain.Invoke(operation,prjPath);
            }
        }

        private void RefreshTreeNode(string prjPath)
        {
            foreach (TreeNode tnBlock in this.treeMain.Nodes)
            {
                foreach (TreeNode tnProject in tnBlock.Nodes)
                {
                    foreach (TreeNode tn in tnProject.Nodes)
                    {
                        if (tn.Level == 2)
                        {
                            string prjFolder = prjPath.Substring(0, prjPath.LastIndexOf('\\'));
                            if (tn.Tag.ToString().ToLower() == prjFolder.ToLower())
                            {
                                tn.Nodes.Clear();
                                string fileNameWithoutExt = prjFolder + "\\" + prjFolder.Substring(prjFolder.LastIndexOf('\\') + 1);
                                FileInfo fi = new FileInfo(fileNameWithoutExt + ".DAPS");
                                if (fi.Exists)
                                {
                                    TreeNode tnDaps = tn.Nodes.Add(prjFolder.Substring(prjFolder.LastIndexOf('\\') + 1) + ".DAPS");
                                    tnDaps.Tag = fileNameWithoutExt + ".DAPS";
                                }
                                fi = new FileInfo(fileNameWithoutExt + ".PROD");
                                if (fi.Exists)
                                {
                                    TreeNode tnProd = tn.Nodes.Add(prjFolder.Substring(prjFolder.LastIndexOf('\\') + 1) + ".PROD");
                                    tnProd.Tag = fileNameWithoutExt + ".PROD";
                                }
                                fi = new FileInfo(fileNameWithoutExt + ".RESP");
                                if (fi.Exists)
                                {
                                    TreeNode tnResp = tn.Nodes.Add(prjFolder.Substring(prjFolder.LastIndexOf('\\') + 1) + ".RESP");
                                    tnResp.Tag = fileNameWithoutExt + ".RESP";
                                }

                            }
                            tn.ExpandAll();
                        }
                    }
                }
            }
        }

        public void OpenDataFile(string prjPath)
        {
            
        }

        public void SaveData(string prjPath)
        {
            
        }

        public bool AllowRename(string path, bool bBlock)
        {
            return true;
        }        

        public void OpenProject()
        {
            this.cMenuOpen_Click(null, null);
        }

        public void SaveProject()
        {
            //this.cMenuSave_Click(null, null);
        }

        public void SaveProjectAs()
        {
            this.cMenuSaveAs_Click(null, null);

        }

        public void Edit()
        {
            this.cMenuEditName_Click(null, null);
        }

        public void Delete()
        {
            this.cMenuDelete_Click(null, null);
        }

        public void AddConcession()
        {
            this.mnuAddConcession_Click(null, null);
        }

        public void AddNewProject()
        {
            this.cMenuAddNewProject_Click(null, null);
        }

        public void AddOldProject()
        {
            this.cMenuAddOldProject_Click(null, null);
        }

        public void SetMenuVisible(ToolStripMenuItem mOpenProj,ToolStripMenuItem mEdit, ToolStripMenuItem mDelete, 
            ToolStripMenuItem mAddConcession, ToolStripMenuItem mAddNewProj, ToolStripMenuItem mAddOldProj)
        {
            TreeNode tn = this.treeMain.SelectedNode;
            if (tn == null) return;
            SetMenuVisible(tn);
            mOpenProj.Visible = bOpenVisible;
            //mSaveProj.Visible = bSaveVisible;
            //mSaveAsProj.Visible = bSaveAsVisible;
            mEdit.Visible = bEditVisible;
            mDelete.Visible = bDeleteVisible;
            mAddConcession.Visible = bAddConcessionVisible;
            mAddNewProj.Visible = bAddnewProjVisible;
            mAddOldProj.Visible = bAddOldProjVisible;
        }

        #endregion
        private void frmResourceManager_Activated(object sender, EventArgs e)
        {
            if (this.ParentForm == null) return;
            this.Location = new Point(0, 0);
        }

        #region IToolMerge 成员

        public ToolStrip[] GetToolStrip
        {
            get { return null; }
        }
        public void RefreshTools()
        {

        }
        #endregion

     
       
    }
}