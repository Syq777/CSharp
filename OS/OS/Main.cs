using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS
{
    public partial class Main : System.Windows.Forms.Form
    {
        FileFunction _fileFunction = new FileFunction();
        DrawFunction _drawFunction = new DrawFunction();
        PathFunction _pathFunction = new PathFunction();        
        TreeNode _startNode;
        TreeNode _endNode;
        int _flag = 0;

        public Main()
        {
            InitializeComponent();
            //button_format_Click(null, null);
            DrawWindow();
        }
        public void DrawWindow()
        {
            PictureBox[] pb1 = new PictureBox[128];
            PictureBox[] pb2 = new PictureBox[128];
            for (int i = 0; i < 128; i++)
            {
                pb1[i] = new PictureBox();
                pb2[i] = new PictureBox();
                pb1[i].BorderStyle = pb2[i ].BorderStyle = BorderStyle.Fixed3D;
                pb1[i].Size = pb2[i ] .Size= new Size(15, 15);
                pb1[i].Location = pb2[i].Location = new Point((i % 16) * 15, (i / 16) * 15);
                if (i < 3)
                {
                    pb1[i].BackColor = pb2[i].BackColor = Color.Red;
                }
                else
                {
                    pb1[i].BackColor = pb2[i].BackColor= Color.Aqua;
                }
                panel_harddisk1.Controls.Add(pb1[i]);
                panel_harddisk2.Controls.Add(pb2[i]);
            }
            update_Click(null, null);
        }
        private void button_format_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("格式化硬盘", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            _fileFunction.Format("harddisk1.txt");
            _fileFunction.Format("harddisk2.txt");
            update_Click(null,null); 
        }
        private void update_Click(object sender, EventArgs e)
        {
            TreeNode node_C = treeView_file.Nodes.Find("本地磁盘C", true)[0];
            TreeNode node_D = treeView_file.Nodes.Find("本地磁盘D", true)[0];
            node_C.Nodes.Clear();
            node_D.Nodes.Clear();
            _drawFunction.SerachTreeNode("harddisk1.txt", node_C, 2, contextMenuStrip_menu, contextMenuStrip_file);
            _drawFunction.SerachTreeNode("harddisk2.txt", node_D, 2, contextMenuStrip_menu, contextMenuStrip_file);
            treeView_file.ExpandAll();
            _drawFunction.DrawHarddisk(panel_harddisk1, "harddisk1.txt");
            _drawFunction.DrawHarddisk(panel_harddisk2, "harddisk2.txt");
        }
        private void 文件夹ToolStripMenuItem_menu_Click(object sender, EventArgs e)
        {            
            create_menu file = new create_menu(contextMenuStrip_menu, panel_harddisk, treeView_file, treeView_file.SelectedNode);
        }
        private void TXT文件ToolStripMenuItem_menu_Click(object sender, EventArgs e)
        {
            create_file file = new create_file(contextMenuStrip_file, panel_harddisk, treeView_file, treeView_file.SelectedNode, "txt");
        }
        private void 可执行文件ToolStripMenuItem_menu_Click(object sender, EventArgs e)
        {
            create_file file = new create_file(contextMenuStrip_file , panel_harddisk, treeView_file, treeView_file.SelectedNode, "exe");            
        }
        private void 剪切ToolStripMenuItem_menu_Click(object sender, EventArgs e)
        {
            _startNode = treeView_file.SelectedNode;
            if(_startNode.Name=="本地磁盘C"|| _startNode.Name == "本地磁盘D")
            {
                MessageBox.Show("根目录不可更改");
                return;
            }
            粘贴ToolStripMenuItem_menu.Enabled = true;
            _flag = 1;
        }
        private void 复制ToolStripMenuItem_menu_Click(object sender, EventArgs e)
        {
            _startNode = treeView_file.SelectedNode;
            if (_startNode.Name == "本地磁盘C" || _startNode.Name == "本地磁盘D")
            {
                MessageBox.Show("根目录不可更改");
                return;
            }
            粘贴ToolStripMenuItem_menu.Enabled = true;
            _flag = 2;
        }
        private void 粘贴ToolStripMenuItem_menu_Click(object sender, EventArgs e)
        {
            _endNode = treeView_file.SelectedNode;
            copy_cut_delete move = new copy_cut_delete();
            if(_flag == 1)
            {
                move.cut(panel_harddisk, _startNode, _endNode);
            }
            else if(_flag == 2)
            {
                move.copy(panel_harddisk, _startNode, _endNode);
            }
            else
            {
                MessageBox.Show("程序出错");
            }
            treeView_file.ExpandAll();
        }
        private void 重命名ToolStripMenuItem_menu_Click(object sender, EventArgs e)
        {
            edit_menu file = new edit_menu(treeView_file.SelectedNode);
        }
        private void 删除ToolStripMenuItem_menu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除文件", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            TreeNode node = treeView_file.SelectedNode;
            copy_cut_delete deleteFunction = new copy_cut_delete();
            deleteFunction.delete(node, panel_harddisk);
        }
        private void 属性ToolStripMenuItem_menu_Click(object sender, EventArgs e)
        {          
            attribute file = new attribute(treeView_file.SelectedNode);
        }
        private void 运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView_file.SelectedNode;
            string[] path = new string[3];
            string content="";
            path[0] = node.FullPath;
            path[2] = "";
            if (_pathFunction.SplitPathInterface(path) == 0)
            {
                return;
            }
            int[] fileAddress = _fileFunction.SearchAddress(path);
            if (fileAddress[0] == 0)
            {
                return;
            }
            if (fileAddress[1] == 64)
            {
                MessageBox.Show("文件或目录不存在");
                return;
            }
            FCB fcb = _fileFunction.ReadItem(path[0], fileAddress[0], fileAddress[1]);
            int attribute = fcb.GetAttribute();
            if (attribute == 2 || attribute == 3)
            {
                content = _fileFunction.ReadContent(path[0], fileAddress[2]);
            }
            else
            {
                MessageBox.Show("不是可执行文件");
                return;
            }
        }
        private void 打开ToolStripMenuItem_file_Click(object sender, EventArgs e)
        {
            edit_file file = new edit_file(contextMenuStrip_file, panel_harddisk, treeView_file.SelectedNode);
        }
        private void 剪切ToolStripMenuItem_file_Click(object sender, EventArgs e)
        {
            _startNode = treeView_file.SelectedNode;
            粘贴ToolStripMenuItem_menu.Enabled = true;
            _flag = 1;
        }
        private void 复制ToolStripMenuItem_file_Click(object sender, EventArgs e)
        {
            _startNode = treeView_file.SelectedNode;
            粘贴ToolStripMenuItem_menu.Enabled = true;
            _flag = 2;
        }
        private void 删除ToolStripMenuItem_file_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除文件", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            TreeNode node = treeView_file.SelectedNode;
            copy_cut_delete deletefunction = new copy_cut_delete();
            deletefunction.delete(node, panel_harddisk);
        }
        private void 属性ToolStripMenuItem_file_Click(object sender, EventArgs e)
        {           
            attribute file = new attribute(treeView_file.SelectedNode);
        }
        private void button_command_Click(object sender, EventArgs e)
        {
            string command = textBox_command.Text;
            string[] str = System.Text.RegularExpressions.Regex.Split(command, @"\s+");
            if(str[0]=="create_menu")
            {
                if(str.Length!=2)
                {
                    MessageBox.Show("命令不正确");
                    textBox_command.Text = "";
                    textBox_command.Focus();
                    return;
                }
                TreeNode node =_pathFunction.SelectNode(str[1], treeView_file);
                if(node!=null)
                {
                    create_menu file = new create_menu(contextMenuStrip_menu, panel_harddisk, treeView_file, node);
                }
                else
                {
                    MessageBox.Show("路径错误");
                }
            }
            else if (str[0] == "create_txt"|| str[0] == "create_file")
            {
                if (str.Length != 2)
                {
                    MessageBox.Show("命令不正确");
                    textBox_command.Text = "";
                    textBox_command.Focus();
                    return;
                }
                TreeNode node = _pathFunction.SelectNode(str[1], treeView_file);
                if (node != null)
                {
                    create_file file = new create_file(contextMenuStrip_file, panel_harddisk, treeView_file, node, "txt");
                }
                else
                {
                    MessageBox.Show("路径错误");
                }
            }
            else if (str[0] == "create_exe")
            {
                if (str.Length != 2)
                {
                    MessageBox.Show("命令不正确");
                    textBox_command.Text = "";
                    textBox_command.Focus();
                    return;
                }
                TreeNode node = _pathFunction.SelectNode(str[1], treeView_file);
                if (node != null)
                {
                    create_file file = new create_file(contextMenuStrip_file, panel_harddisk, treeView_file, node, "exe");
                }
                else
                {
                    MessageBox.Show("路径错误");
                }
            }
            else if(str[0]=="copy")
            {
                TreeNode startNode = _pathFunction.SelectNode(str[1], treeView_file);
                TreeNode endNode = _pathFunction.SelectNode(str[2], treeView_file);
                if (startNode != null&& endNode != null)
                {
                    if (startNode.Name == "本地磁盘C" || startNode.Name == "本地磁盘D")
                    {
                        MessageBox.Show("根目录不可更改");
                        textBox_command.Text = "";
                        return;
                    }
                    copy_cut_delete move = new copy_cut_delete();
                    move.copy(panel_harddisk, startNode, endNode);
                }
                else
                {
                    MessageBox.Show("路径错误");
                }
            }
            else if (str[0] == "cut")
            {
                if (str.Length != 3)
                {
                    MessageBox.Show("命令不正确");
                    textBox_command.Text = "";
                    textBox_command.Focus();
                    return;
                }
                TreeNode startNode = _pathFunction.SelectNode(str[1], treeView_file);
                TreeNode endNode = _pathFunction.SelectNode(str[2], treeView_file);
                if (startNode != null && endNode != null)
                {
                    if (startNode.Name == "本地磁盘C" || startNode.Name == "本地磁盘D")
                    {
                        MessageBox.Show("根目录不可更改");
                        textBox_command.Text = "";
                        textBox_command.Focus();
                        return;
                    }
                    copy_cut_delete move = new copy_cut_delete();
                    move.cut(panel_harddisk, startNode, endNode);
                }
                else
                {
                    MessageBox.Show("路径错误");
                }
            }
            else if (str[0] == "delete")
            {
                if (str.Length != 2)
                {
                    MessageBox.Show("命令不正确");
                    textBox_command.Text = "";
                    textBox_command.Focus();
                    return;
                }
                if (MessageBox.Show("删除文件", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    textBox_command.Focus();
                    return;
                }                    
                TreeNode node = _pathFunction.SelectNode(str[1], treeView_file);
                if (node != null)
                {
                    copy_cut_delete deletefunction = new copy_cut_delete();
                    deletefunction.delete(node, panel_harddisk);
                }
                else
                {
                    MessageBox.Show("路径错误");
                }                
            }
            else if (str[0] == "edit")
            {
                if (str.Length != 2)
                {
                    MessageBox.Show("命令不正确");
                    textBox_command.Text = "";
                    textBox_command.Focus();
                    return;
                }
                TreeNode node = _pathFunction.SelectNode(str[1], treeView_file);
                if (node != null)
                {
                    string[] path = str[1].Split(new char[] { '\\' });
                    string[] nameType = path[path.Length - 1].Split(new char[] { '.' });
                    if (nameType.Length == 1)
                    {
                        edit_menu file = new edit_menu(node);
                    }
                    else
                    {
                        edit_file file = new edit_file(contextMenuStrip_file,panel_harddisk,node);
                    }
                }
                else
                {
                    MessageBox.Show("路径错误");
                }                
            }
            else if (str[0] == "attribute")
            {
                if (str.Length != 2)
                {
                    MessageBox.Show("命令不正确");
                    textBox_command.Text = "";
                    textBox_command.Focus();
                    return;
                }
                TreeNode node = _pathFunction.SelectNode(str[1], treeView_file);
                if (node != null)
                {
                    attribute file = new attribute(node);
                }
                else
                {
                    MessageBox.Show("路径错误");
                }
            }
            else
            {
                MessageBox.Show("操作指令错误");
                textBox_command.Text = "";
                textBox_command.Focus();
                return;
            }
            textBox_command.Text = str[0]+" ";
            textBox_command.Focus();
            textBox_command.SelectionStart = textBox_command.Text.Length;
        }
        private void treeView_file_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView_file.SelectedNode = treeView_file.GetNodeAt(new Point(e.X, e.Y));
            }
        }

        private void textBox_command_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                button_command_Click(null, null);
                textBox_command.Focus();
            }
        }
    }
}
