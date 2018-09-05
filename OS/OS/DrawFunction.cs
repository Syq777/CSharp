using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace OS
{
    class DrawFunction
    {
        public void SerachTreeNode(string harddisk,TreeNode node,int disknum, ContextMenuStrip contextMenuStripMenu, ContextMenuStrip contextMenuStripFile)
        {
            byte[] name = new byte[3];
            byte[] type = new byte[2];            
            int address=0;
            int attribute;
            for (int i = 0; i < 64; i = i + 8)
            {
                FileStream disk = new FileStream(harddisk, FileMode.Open);
                disk.Seek(64 * disknum + i, SeekOrigin.Begin);
                disk.Read(name, 0, 3);
                disk.Seek(0, SeekOrigin.Current);
                disk.Read(type, 0, 2);
                disk.Seek(0, SeekOrigin.Current);
                attribute = disk.ReadByte();
                disk.Seek(0, SeekOrigin.Current);
                address = disk.ReadByte();
                disk.Close();
                TreeNode childNode = new TreeNode();
                childNode.Text = Encoding.Default.GetString(name) ;         
                if (attribute== 0)
                {
                    continue;
                }
                if (Encoding.Default.GetString(type) == "  ")
                {
                    childNode.SelectedImageIndex = 2;
                    childNode.ImageIndex = 2;
                    childNode.ContextMenuStrip = contextMenuStripMenu;
                    SerachTreeNode(harddisk, childNode, address, contextMenuStripMenu, contextMenuStripFile);                    
                }
                else
                {
                    if (Encoding.Default.GetString(type) == "ex")
                    {
                        childNode.Text = childNode.Text + ".exe";
                        childNode.SelectedImageIndex = 3;
                        childNode.ImageIndex = 3;
                    }
                    else if (Encoding.Default.GetString(type) == "tx")
                    {
                        childNode.Text = childNode.Text + ".txt";
                        childNode.SelectedImageIndex = 4;
                        childNode.ImageIndex = 4;
                    }
                    else
                    {
                        MessageBox.Show("文件损坏");
                    }
                    childNode.ContextMenuStrip = contextMenuStripFile;
                }
                childNode.Name = childNode.Text;
                node.Nodes.Add(childNode);
            }
        }
        public void AddTreeNode(TreeNode fatherNode, ContextMenuStrip contextMenuStrip, string name, int attitute)
        {
            TreeNode node;
            if (attitute == 8)
            {
                node = new TreeNode(name, 2, 2);
            }
            else if (attitute == 2|| attitute==3)
            {
                node = new TreeNode(name + ".exe", 3, 3);
            }
            else if (attitute == 4|| attitute==5)
            {
                node = new TreeNode(name + ".txt", 4, 4);
            }
            else
            {
                MessageBox.Show("树节点添加失败");
                return;
            }
            node.Name = node.Text;
            node.ContextMenuStrip = contextMenuStrip;
            fatherNode.Nodes.Add(node);
        }
        public void DeleteTreeNode(TreeNode node)
        {
            node.Nodes.Clear();
            node.Remove();
        }
        public void EditTreeNode(TreeNode node, string name,int attitute)
        {
            if (attitute == 8)
            {
                node.Text = name ;
                node.SelectedImageIndex = 2;
                node.ImageIndex = 2;
            }
            else if (attitute == 2 || attitute == 3)
            {
                node.Text = name+".exe";
                node.SelectedImageIndex = 3;
                node.ImageIndex = 3;
            }
            else if (attitute == 4 || attitute == 5)
            {
                node.Text = name + ".txt";
                node.SelectedImageIndex = 4;
                node.ImageIndex = 4;
            }
            else
            {
                MessageBox.Show("树节点修改失败");
                return;
            }
            node.Name = node.Text;
        }
        public void CopyTreeNode(TreeNode node, TreeNode fatherNode)
        {
            fatherNode.Nodes.Add((TreeNode)node.Clone());
        }
        public void CutTreeNode(TreeNode node, TreeNode fatherNode)
        {
            CopyTreeNode(node,fatherNode);
            node.Nodes.Clear();
            node.Remove();
        }
        public void DrawHarddisk(Panel panel, string harddisk)
        {
            FileStream disk = new FileStream(harddisk, FileMode.Open);
            byte[] fat = new byte[128];
            disk.Seek(0, SeekOrigin.Begin);
            disk.Read(fat, 0, 128);
            disk.Close();
            for(int i=3;i<128;i++)
            {
                if(fat[i]==0&&panel.Controls[i].BackColor != Color.Aqua)
                {
                    panel.Controls[i].BackColor = Color.Aqua;
                }
                else if(fat[i]!=0&& panel.Controls[i].BackColor != Color.Yellow)
                {
                    panel.Controls[i].BackColor  = Color.Yellow;
                }
            }
        }
        public void AddDisknum(Panel panel,int []disknum)
        {
            for(int i=1;i<=disknum[0];i++)
            {
                if(disknum[i]>2&& panel.Controls[disknum[i]].BackColor!= Color.Yellow)
                {
                    panel.Controls[disknum[i]].BackColor = Color.Yellow;
                }                
            }
        }
        public void DeleteDisknum(Panel panel, int[] disknum)
        {
            for (int i = 1; i <= disknum[0]; i++)
            {
                if (disknum[i] > 2&& panel.Controls[disknum[i]].BackColor != Color.Aqua)
                {
                    panel.Controls[disknum[i]].BackColor = Color.Aqua;
                }
            }
        }
    }
}
