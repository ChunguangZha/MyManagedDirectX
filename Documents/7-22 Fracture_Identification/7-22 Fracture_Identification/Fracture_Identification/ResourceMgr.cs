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
        /// ��ȡ��Դ�����ļ�
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
        /// ������Դ�����ļ�
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
