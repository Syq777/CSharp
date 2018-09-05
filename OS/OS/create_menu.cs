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
    public partial class create_menu : Form
    {        
        FileFunction _fileFunction = new FileFunction();
        DrawFunction _drawFunction = new DrawFunction();
        PathFunction _pathFunction = new PathFunction();
        string[] _path = new string[3];
        Panel _panelHarddisk;
        Panel _panelHarddiskChild;
        TreeView _treeViewFile;
        TreeNode _fatherNode;
        ContextMenuStrip _contextMenuStrip;
        bool _saveClose = false;
        public create_menu(ContextMenuStrip scontextMenuStripMenu,Panel spanelHarddisk,TreeView streeViewFile , TreeNode snode)
        {
            InitializeComponent();
            Show();
            MainForm.form.Enabled = false;
            textBox_name.Focus();
            _panelHarddisk = spanelHarddisk;
            _treeViewFile = streeViewFile;
            _contextMenuStrip = scontextMenuStripMenu;
            _fatherNode = snode;
        } 
        private void button_sure_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text == "")
            {
                MessageBox.Show("目录名不可为空");
                return;
            }
            _path[0] = _fatherNode.FullPath;
            _path[2] = "";
            if (_pathFunction.SplitPathInterface(_path) == 0)
            {
                return;
            }
            if (_path[2] != "")
            {
                if (_path[1] != "")
                {
                    _path[1] = _path[1] + "\\" + _path[2];
                }
                else
                {
                    _path[1] = _path[2];
                }
            }
            _path[2] = textBox_name.Text;
            for (int i = 0; i < 3 - textBox_name.Text.Length; i++)
            {
                _path[2] = " " + _path[2];
            }
            int[] disknum = _fileFunction.CreatMenu(_path);
            if (disknum[0] != 0)
            {
                _drawFunction.AddTreeNode(_fatherNode, _contextMenuStrip, _path[2], 8);
                if (_path[0] == "harddisk1.txt")
                {
                    _panelHarddiskChild = (Panel)_panelHarddisk.Controls["panel_harddisk1"];
                }
                else if (_path[0] == "harddisk2.txt")
                {
                    _panelHarddiskChild = (Panel)_panelHarddisk.Controls["panel_harddisk2"];
                }
                _drawFunction.AddDisknum(_panelHarddiskChild, disknum);
                _saveClose = true;
                _treeViewFile.ExpandAll();
                Close();
            }
            textBox_name.Text = "";
        }
        private void textBox_name_Leave(object sender, EventArgs e)
        {
            textBox_name.Focus();
        }
        private void textBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)8) || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void create_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_saveClose)
            {
                if (MessageBox.Show("是否放弃新建文件夹", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }                
        }

        private void create_menu_FormClosed(object sender, FormClosedEventArgs e)
        {
           MainForm.form.Enabled = true;
        }

    }
}
