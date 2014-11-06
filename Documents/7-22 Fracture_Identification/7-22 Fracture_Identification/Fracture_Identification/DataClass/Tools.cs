using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DAPS.Simulator
{
   public static class Tools
    {
        public static bool IsNumber(string s)
        {
            if (IsInteger(s) || IsFloat(s) || IsDouble(s))
                return true;
            return false;
        }
       public static bool IsInteger(string s)
       {
           int d = 0;
           if (Int32.TryParse(s, out d))
               return true;
           return false;
       }
       public static bool IsFloat(string s)
       {
           float d = 0;
           if (Single.TryParse(s, out d))
               return true;
           return false;
       }
       public static bool IsDouble(string s)
       {
           double d = 0;
           if (double.TryParse(s, out d))
               return true;
           return false;
       }
       public static void DataGirdViewCellPaste(DataGridView p_Data,bool allowAutoAddRow)
       {
           try
           {
               // ��ȡ���а�����ݣ������зָ�
               string pasteText = Clipboard.GetText();
               if (string.IsNullOrEmpty(pasteText))
               {
                   return;
               }
               string[] lines = pasteText.Split(new char[] { '\r', '\n' });
               int i = 0;
               for (int j = 0; j < lines.Length; j++)
               {
                   if (string.IsNullOrEmpty(lines[j].Trim()))
                   {
                       continue;
                   }
                   // �� Tab �ָ�����,����ѡ�е�Ԫ��ʼ
                   string[] vals = lines[j].Split('\t');

                   //�Ƿ������û�����У��������򵱼��а������ݳ�����������ԣ���֮���Զ������
                   if (allowAutoAddRow)
                   {
                       if (p_Data.SelectedCells[0].RowIndex == p_Data.Rows.Count - 1)
                       {
                           p_Data.Rows.Add();
                           int iindex = p_Data.SelectedCells[0].ColumnIndex;
                           p_Data.ClearSelection();
                           p_Data.Rows[p_Data.Rows.Count - 2].Cells[iindex].Selected = true;
                       }
                       if (p_Data.SelectedCells[0].RowIndex + i >= p_Data.Rows.Count - 1)
                       {
                           p_Data.Rows.Add();
                       }
                   }
                   else
                   {
                       if (p_Data.SelectedCells[0].RowIndex + i > p_Data.Rows.Count)
                       {
                           return;
                       }
                   }

                   for (int k = 0; k < vals.Length; k++)
                   {
                       if (p_Data.SelectedCells[0].ColumnIndex + k >= p_Data.Columns.Count)
                       {
                           break;
                       }
                       if (!p_Data.Rows[p_Data.SelectedCells[0].RowIndex + i].Cells[p_Data.SelectedCells[0].ColumnIndex + k].ReadOnly && p_Data.Rows[p_Data.SelectedCells[0].RowIndex + i].Cells[p_Data.SelectedCells[0].ColumnIndex + k].GetType() == typeof(DataGridViewTextBoxCell))
                       {
                           p_Data.Rows[p_Data.SelectedCells[0].RowIndex + i].Cells[p_Data.SelectedCells[0].ColumnIndex + k].Value = vals[k];
                       }
                   }
                   i++;
               }
           }
           catch
           {
               // ������
           }
       }

       public static string GetConcessionAndProjectName(string prjPath)
       {
           //example: C:\\����1\\��Ŀ1\\��Ŀ1.daps
           string sFile = GetFileFullPathWithoutExt(prjPath);//C:\\����1\\��Ŀ1\\��Ŀ1
           string prjName = sFile.Substring(sFile.LastIndexOf("\\") + 1);//��Ŀ1
           string stemp = sFile.Substring(0, sFile.LastIndexOf('\\'));//C:\\����1\\��Ŀ1
           stemp = stemp.Substring(0, stemp.LastIndexOf('\\'));//C:\\����1
           string blockName = stemp.Substring(stemp.LastIndexOf('\\') + 1);//����1
           return blockName + "\\" + prjName;
       }
       public static string GetFileFullPathWithoutExt(string file)
       {
           if (file == null) return null;
           if (file.Trim() == "") return "";
           string path = file.Substring(0, file.LastIndexOf('\\'));
           string fileNameWithoutExt = Path.GetFileNameWithoutExtension(file);
           return path + "\\" + fileNameWithoutExt;
       }
       public static bool CopyFolder(string sourceDirName, string destDirName)
       {
           try
           {
               if (sourceDirName.Substring(sourceDirName.Length - 1) != "\\")
               {
                   sourceDirName = sourceDirName + "\\";
               }
               if (destDirName.Substring(destDirName.Length - 1) != "\\")
               {
                   destDirName = destDirName + "\\";
               }
               if (Directory.Exists(sourceDirName))
               {
                   if (!Directory.Exists(destDirName))
                   {
                       Directory.CreateDirectory(destDirName);
                   }
                   foreach (string item in Directory.GetFiles(sourceDirName))
                   {
                       File.Copy(item, destDirName + Path.GetFileName(item), true);
                   }
                   foreach (string item in Directory.GetDirectories(sourceDirName))
                   {
                       CopyFolder(item, destDirName + item.Substring(item.LastIndexOf("\\") + 1));
                   }
               }
               return true;
           }
           catch { return false; }
       }
       public static bool RenameFolder(string oldName,string newName)
       {
           try
           {
               Directory.Move(oldName, newName);
               return true;
           }
           catch
           {
               return false;
           }
       }
       public static bool RenameFile(string oldName, string newName)
       {
           try
           {
               File.Move(oldName, newName);
               return true;
           }
           catch
           {
               return false;
           }
       }
       public static bool DeleteFile(string filePath)
       {
           if (string.IsNullOrEmpty(filePath)) return true;
           try
           {
               File.Delete(filePath);
               return true;
           }
           catch
           {
               return false;
           }
       }
       public static bool DeleteFolder(string folderPath)
       {
           if (string.IsNullOrEmpty(folderPath)) return true;
           try
           {
               Directory.Delete(folderPath,true);
               return true;
           }
           catch
           {
               return false;
           }
       }
    }
}
