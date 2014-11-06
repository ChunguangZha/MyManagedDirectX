using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DAPS.Simulator
{
    class ResourceMgr
    {
        public XmlDocument SysResource;

        /// <summary>
        /// 读取资源管理文件
        /// </summary>
        public void Read()
        {
            try
            {
                SysResource = new XmlDocument();
                SysResource.Load(System.Windows.Forms.Application.StartupPath + "\\" + "Resource.dat");
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// 保存资源管理文件
        /// </summary>
        public void Write()
        {
            try
            {
                SysResource.Save(System.Windows.Forms.Application.StartupPath + "\\" + "Resource.dat");
            }
            catch (Exception e)
            {

            }
        }
    }
}
