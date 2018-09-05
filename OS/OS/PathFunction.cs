using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace OS
{
    class PathFunction
    {        
        public int PathError(string[] path)//判断路径是否有错
        {
            int value = 0;
            if (path[0] == "c:" || path[0] == "C:")
            {
                path[0] = "harddisk1.txt";
            }
            else if (path[0] == "d:" || path[0] == "D:")
            {
                path[0] = "harddisk2.txt";
            }
            else
            {
                MessageBox.Show("根目录错误");
                return 0;
            }
            if (path[2] == "")
            {
                path[1] = "";
                return 1;
            }
            string[] name = path[2].Split(new char[] { '.' });
            if (name.Length > 2)
            {
                return 0;
            }
            if (name[0].Length > 3)
            {
                MessageBox.Show("文件/目录名错误");
                return 0;
            }
            for (int i = 0; i < (3 - name[0].Length); i++)
            {
                path[2] = " " + path[2];
            }
            if (name.Length == 1)
            {
                value = 1;
            }
            else
            {
                if (name[1] == "e" || name[1] == "ex" || name[1] == "exe")
                {
                    name[1] = "ex";
                    path[2] = name[0] + "." + name[1];
                    value = 2;
                }
                else if (name[1] == "t" || name[1] == "tx" || name[1] == "txt")
                {
                    name[1] = "tx";
                    path[2] = name[0] + "." + name[1];
                    value = 2;
                }
                else
                {
                    MessageBox.Show("文件类型错误");
                    return 0;
                }
            }           
            if (path[1] != "")
            {
                string[] spath = path[1].Split(new char[] { '\\' });
                for (int i = 0; i < spath.Length; i++)
                {
                    if (spath[i].Length > 3 || spath[i] == "   ")
                    {
                        MessageBox.Show("目录错误");
                        return 0;
                    }
                }
            }
            return value;
        }        
        public int SplitPathInterface(string []path)
        {
            if(path.Length<3)
            {
                MessageBox.Show("程序错误");
                return 0;
            }
            string[] s = path[0].Split(new char[] { '\\' });
            if(s.Length<2)
            {
                MessageBox.Show("路径解析出错");
                return 0;
            }
            if (s[1] == "本地磁盘D")
            {
                path[0] = "d:";
            }
            else if (s[1] == "本地磁盘C")
            {
                path[0] = "c:";
            }
            else
            {
                MessageBox.Show("根目录解析错误");
                return 0;
            }
            if (s.Length == 2)
            {
                path[1] = "";
                path[2] = "";
            }
            else
            {
                if (s.Length == 3)
                {
                    path[1] = "";
                }
                else
                {
                    path[1] = s[2];
                    for (int i = 3; i < s.Length - 1; i++)
                    {
                        path[1] = path[1] + "\\" + s[i];
                    }
                }
                path[2] = s[s.Length - 1];
            }           
            return PathError(path);
        }
        public TreeNode SelectNode(string path, TreeView treeViewFile)
        {
            TreeNode fatherNode = treeViewFile.Nodes["计算机"]; ;
            TreeNode node;
            string[] str = path.Split(new char[] { '\\' });
            if (str[0] == "c:" || str[0] == "C:")
            {
                fatherNode = fatherNode.Nodes["本地磁盘C"];
            }
            else if (str[0] == "d:" || str[0] == "D:")
            {
                fatherNode = fatherNode.Nodes["本地磁盘D"];
            }
            else
            {
                return null;
            }
            for (int i = 1; i < str.Length; i++)
            {
                node = fatherNode.Nodes[str[i]];
                if (node != null)
                {
                    fatherNode = node;
                }
                else
                {
                    return null;
                }
            }
            return fatherNode;
        }
    }
}
