using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace OS
{
    class copy_cut_delete
    {
        FileFunction _fileFunction = new FileFunction();
        DrawFunction _drawFunction = new DrawFunction();
        PathFunction _pathFunction = new PathFunction();
        public void delete(TreeNode node, Panel panelHarddisk)
        {
            string[] path = new string[3];
            path[0] = node.FullPath;
            path[2] = "";
            int flag = _pathFunction.SplitPathInterface(path);
            if (flag == 1 || flag == 2)
            {
                if (path[2] == "")
                {
                    MessageBox.Show("根目录不可删除");
                    return;
                }
                int[] disknum;
                if (flag == 1)
                {
                    disknum = _fileFunction.DeleteMenu(path);
                }
                else
                {
                    disknum = _fileFunction.DeleteFile(path);
                }
                if (disknum[0] != 0)
                {
                    _drawFunction.DeleteTreeNode(node);
                    if (path[0] == "harddisk1.txt")
                    {
                        _drawFunction.DeleteDisknum((Panel)panelHarddisk.Controls["panel_harddisk1"], disknum);
                    }
                    else if (path[0] == "harddisk2.txt")
                    {
                        _drawFunction.DeleteDisknum((Panel)panelHarddisk.Controls["panel_harddisk2"], disknum);
                    }
                }
            }
        }
        public void cut(Panel panelHarddisk, TreeNode startNode, TreeNode endNode)
        {
            string[] path = new string[3];
            string[] startPath = new string[3];
            path[0] = startNode.FullPath;
            path[2] = "";
            int fileMenu = _pathFunction.SplitPathInterface(path);
            if (fileMenu == 1 || fileMenu == 2)
            {
                for (int i = 0; i < 3; i++)
                    startPath[i] = path[i];
                if (fileMenu == 1)
                {
                    paste(panelHarddisk, startPath, startNode, endNode, 1);
                }
                else
                {
                    paste(panelHarddisk, startPath, startNode, endNode, 3);
                }
            }
            else
            {
                return;
            }
        }
        public void copy(Panel panelHarddisk, TreeNode startNode, TreeNode endNode)
        {
            string[] path = new string[3];
            string[] startPath = new string[3];
            path[0] = startNode.FullPath;
            path[2] = "";            
            int fileMenu = _pathFunction.SplitPathInterface(path);
            if (fileMenu == 1 || fileMenu == 2)
            {               
                for (int i = 0; i < 3; i++)
                    startPath[i] = path[i];
                if (fileMenu == 1)
                {
                    paste(panelHarddisk, startPath, startNode, endNode, 2);
                }
                else
                {
                    paste(panelHarddisk, startPath, startNode, endNode, 4);
                }
            }
            else
            {
                return;
            }
        }
        private void paste(Panel panelHarddisk, string[] startPath, TreeNode startNode, TreeNode endNode, int flag)
        {
            string[] path = new string[3];
            string[] endPath = new string[3];
            path[0] = endNode.FullPath;
            path[2] = "";

            
            if (_pathFunction.SplitPathInterface(path) == 1)
            {
                for (int i = 0; i < 3; i++)
                    endPath[i] = path[i];
                int[] disknum = new int[256];
                Panel panel = new Panel();
                if (endPath[0] == "harddisk1.txt")
                {
                    panel = (Panel)panelHarddisk.Controls["panel_harddisk1"];
                }
                else if (endPath[0] == "harddisk2.txt")
                {
                    panel = (Panel)panelHarddisk.Controls["panel_harddisk2"];
                }
                if (flag == 1 || flag == 3)
                {
                    if (flag == 1)
                    {
                        disknum = _fileFunction.CutMenu(startPath, endPath);
                    }
                    else
                    {
                        disknum = _fileFunction.CutFile(startPath, endPath);
                    }
                    if (disknum[0] != 0)
                    {
                        _drawFunction.CutTreeNode(startNode, endNode);
                        if (disknum[0] < 128)
                        {
                            int[] deleteDisknum = new int[128];
                            int[] createDisknum = new int[128];
                            Array.Copy(disknum, 0, deleteDisknum, 0, disknum[0] + 1);
                            Array.Copy(disknum, disknum[0] + 1, createDisknum, 0, disknum[disknum[0] + 1] + 1);
                            _drawFunction.AddDisknum(panel, createDisknum);
                            if (startPath[0] == "harddisk1.txt")
                            {
                                panel = (Panel)panelHarddisk.Controls["panel_harddisk1"];
                            }
                            else if (startPath[0] == "harddisk2.txt")
                            {
                                panel = (Panel)panelHarddisk.Controls["panel_harddisk2"];
                            }
                            _drawFunction.DeleteDisknum(panel, deleteDisknum);
                        }
                    }
                }
                else if (flag == 2 || flag == 4)
                {
                    if (flag == 2)
                    {
                        disknum = _fileFunction.CopyMenu(startPath, endPath);
                    }
                    else
                    {
                        disknum = _fileFunction.CopyFile(startPath, endPath);
                    }
                    if (disknum[0] != 0)
                    {
                        _drawFunction.CopyTreeNode(startNode, endNode);
                        _drawFunction.AddDisknum(panel, disknum);
                    }
                }
                else
                {
                    MessageBox.Show("粘贴出错");
                    return;
                }
            }
        }
    }
}
