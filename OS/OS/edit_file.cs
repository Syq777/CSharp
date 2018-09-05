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
    public partial class edit_file : Form
    {
        FileFunction _fileFunction = new FileFunction();
        DrawFunction _drawFunction = new DrawFunction();
        PathFunction _pathFunction = new PathFunction();
        string[] _path = new string[3];
        string _newContent;
        string _oldContent;       
        Panel _panelHarddisk;
        Panel _panelHarddiskChild;
        TreeNode _node;
        ContextMenuStrip _contextMenuStrip;
        bool _editClose = false;
        public edit_file(ContextMenuStrip scontextMenuStripFile, Panel spanelHarddisk, TreeNode snode)
        {
            InitializeComponent();
            _panelHarddisk = spanelHarddisk;
            _contextMenuStrip = scontextMenuStripFile;
            _node = snode;
            _path[0] = _node.FullPath;
            _path[2] = "";
            if (_pathFunction.SplitPathInterface(_path) == 0)
            {
                return;
            }
            int[] file_address = _fileFunction.SearchAddress(_path);
            if (file_address[0] == 0)
            {
                return;
            }
            if (file_address[1] == 64)
            {
                MessageBox.Show("文件或目录不存在");
                return;
            }
            Show();
            MainForm.form.Enabled = false;
            textBox_content.Focus();
            FCB fcb = _fileFunction.ReadItem(_path[0], file_address[0], file_address[1]);
            textBox_name.Text = fcb.GetName().TrimStart();
            int attribute = fcb.GetAttribute();
            if (attribute == 3 || attribute == 5)
            {
                checkBox_readonly.Checked = true;
                if (attribute==3)
                {
                    radioButton_exe.Checked = true;
                }
                else
                {
                    radioButton_txt.Checked = true;
                }
            }
            else if (attribute == 2 || attribute == 4)
            {
                checkBox_readonly.Checked = false;
                if (attribute == 2)
                {
                    radioButton_exe.Checked = true;
                }
                else
                {
                    radioButton_txt.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("文件类型未知");
            }
            textBox_content.Text = _fileFunction.ReadContent(_path[0], file_address[2]);
            _oldContent = textBox_content.Text;
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认保存修改", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            string name;
            string type;
            int attribute;           
            if (checkBox_readonly.Checked == false && radioButton_exe.Checked == true)
            {
                attribute = 2;
                type = "ex";
            }
            else if (checkBox_readonly.Checked == true && radioButton_exe.Checked == true)
            {
                attribute = 3;
                type = "ex";
            }
            else if (checkBox_readonly.Checked == false && radioButton_txt.Checked == true)
            {
                attribute = 4;
                type = "tx";
            }
            else if (checkBox_readonly.Checked == true && radioButton_txt.Checked == true)
            {
                attribute = 5;
                type = "tx";
            }
            else
            {
                MessageBox.Show("请选择要保存文件的类型");
                return;
            }
            if (textBox_name.Text == "")
            {
                MessageBox.Show("文件名不可为空");
                return;
            }
            name= textBox_name.Text;            
            for (int i = 0; i < 3 - textBox_name.Text.Length; i++)
            {
                name = " " + name;
            }
            _newContent = textBox_content.Text;
            if (_newContent == _oldContent)
            {
                _fileFunction.EditFile(_path, name, type, attribute);
                _drawFunction.EditTreeNode(_node, name,attribute);
                _editClose = true;
                Close();
                return;
            }
            int[] disknum = _fileFunction.EditFile(_path, name,type, attribute, _newContent);
            if (disknum[0] != 0)
            {
                int[] delete_disknum = new int[128];
                int[] create_disknum = new int[128];                
                Array.Copy(disknum, 0, delete_disknum, 0, disknum[0] + 1);                
                Array.Copy(disknum, disknum[0] + 1, create_disknum, 0, disknum[disknum[0] + 1] + 1);
                if (_path[0] == "harddisk1.txt")
                {
                    _panelHarddiskChild = (Panel)_panelHarddisk.Controls["panel_harddisk1"]; 
                }
                else if (_path[0] == "harddisk2.txt")
                {
                    _panelHarddiskChild = (Panel)_panelHarddisk.Controls["panel_harddisk2"];
                }
                _drawFunction.DeleteDisknum(_panelHarddiskChild, delete_disknum);
                _drawFunction.AddDisknum(_panelHarddiskChild, create_disknum);
                _drawFunction.EditTreeNode(_node, name,attribute);
                _editClose = true;
                Close();
            }
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("清除文件内容", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                textBox_content.Text = "";
                textBox_content.Focus();
            }               
        }
        private void checkBox_readonly_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_readonly.Checked==false)
            {
                textBox_content.ReadOnly = false;
                textBox_name.ReadOnly = false;
                button_clear.Enabled = true;
                radioButton_exe.Enabled = true;
                radioButton_txt.Enabled = true;
            }
            else
            {
                textBox_content.ReadOnly = true;
                textBox_name.ReadOnly = true;
                button_clear.Enabled = false;
                radioButton_exe.Enabled = false;
                radioButton_txt.Enabled = false;
            }           
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
        private void edit_file_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_editClose)
            {
                if (MessageBox.Show("是否退出编辑", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void edit_file_FormClosed(object sender, FormClosedEventArgs e)
        {
           MainForm.form.Enabled = true;
        }
    }
}
