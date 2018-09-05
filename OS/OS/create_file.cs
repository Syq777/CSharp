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
    public partial class create_file : Form
    {
        FileFunction _fileFunction = new FileFunction();
        DrawFunction _drawFunction = new DrawFunction();
        PathFunction _pathFunction = new PathFunction();
        string[] _path = new string[3];
        string _name;
        string _type;
        int _attitute=0;
        Panel _panelHarddisk;
        Panel _panelHarddiskChild;
        TreeView _treeViewFile;
        TreeNode _fatherNode;
        ContextMenuStrip _contextMenuStrip;
        bool _saveClose=false; 
        public create_file(ContextMenuStrip scontextMenuStripFile, Panel spanelHarddisk,TreeView streeViewFile, TreeNode snode, string stype)
        {
            InitializeComponent();
            Show();
            MainForm.form.Enabled = false;
            textBox_name.Focus();
            _panelHarddisk = spanelHarddisk;
            _treeViewFile = streeViewFile;
            _contextMenuStrip = scontextMenuStripFile;
            _fatherNode = snode;
            if(stype=="txt")
            {
                radioButton_txt.Checked = true;          
            }
            else if(stype=="exe")
            {
                radioButton_exe.Checked = true;
            }
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            if (checkBox_readonly.Checked == false && radioButton_exe.Checked == true)
            {
                _attitute = 2;
                _type = "ex";
            }
            else if (checkBox_readonly.Checked == true && radioButton_exe.Checked == true)
            {
                _attitute = 3;
                _type = "ex";
            }
            else if (checkBox_readonly.Checked == false && radioButton_txt.Checked == true)
            {
                _attitute = 4;
                _type = "tx";
            }
            else if (checkBox_readonly.Checked == true && radioButton_txt.Checked == true)
            {
                _attitute = 5;
                _type = "tx";
            }
            else
            {
                MessageBox.Show("请选择新建文件类型");
                return;
            }

            if (textBox_name.Text == "")
            {
                MessageBox.Show("文件名不可为空");
                textBox_name.Focus();
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
            _name = textBox_name.Text;
            for (int i = 0; i < 3 - textBox_name.Text.Length; i++)
            {
                _name = " " + _name;
            }
            _path[2] = _name + "." + _type;
            int[] disknum = _fileFunction.CreateFile(_path, textBox_content.Text, _attitute);
            if (disknum[0] != 0)
            {
                _drawFunction.AddTreeNode(_fatherNode, _contextMenuStrip, _name, _attitute);
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
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("清除文件内容","", MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                textBox_content.Text = "";
                textBox_content.Focus();
            }
                     
        }
        private void textBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar == (char)8)||(e.KeyChar>='0'&&e.KeyChar<='9')|| (e.KeyChar >='A' && e.KeyChar <= 'Z')|| (e.KeyChar >= 'a' && e.KeyChar <= 'z'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void create_file_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_saveClose)
            {
                if (MessageBox.Show("是否退出新建文件", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }            
        }
        private void create_file_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.form.Enabled = true;
        }
    }
}
