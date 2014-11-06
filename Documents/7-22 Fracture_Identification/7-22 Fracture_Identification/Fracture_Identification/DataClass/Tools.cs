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
               // 获取剪切板的内容，并按行分割
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
                   // 按 Tab 分割数据,并从选中单元格开始
                   string[] vals = lines[j].Split('\t');

                   //是否允许用户添加行，不允许则当剪切板中数据超过行数则忽略，反之则自动添加行
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
               // 不处理
           }
       }

       public static string GetConcessionAndProjectName(string prjPath)
       {
           //example: C:\\区块1\\项目1\\项目1.daps
           string sFile = GetFileFullPathWithoutExt(prjPath);//C:\\区块1\\项目1\\项目1
           string prjName = sFile.Substring(sFile.LastIndexOf("\\") + 1);//项目1
           string stemp = sFile.Substring(0, sFile.LastIndexOf('\\'));//C:\\区块1\\项目1
           stemp = stemp.Substring(0, stemp.LastIndexOf('\\'));//C:\\区块1
           string blockName = stemp.Substring(stemp.LastIndexOf('\\') + 1);//区块1
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
