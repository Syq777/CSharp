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
    public partial class edit_menu : Form
    {
        FileFunction _fileFunction = new FileFunction();
        DrawFunction _drawFunction = new DrawFunction();
        PathFunction _pathFunction = new PathFunction();
        string[] _path = new string[3];
        string _name;
        TreeNode _node;
        bool _editClose = false;
        public edit_menu(TreeNode snode)
        {
            InitializeComponent();
            _node = snode;
            _path[0] = _node.FullPath;
            _path[2] = "";
            textBox_old.Text = _node.Text.TrimStart();
            if(_pathFunction.SplitPathInterface(_path) ==0)
            { 
                return;
            }
            if (_path[2] == "")
            {
                MessageBox.Show("根盘不可修改");
                return;
            }
            Show();
            MainForm.form.Enabled = false;
            textBox_new.Focus();
        }
        private void button_sure_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认保存", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            if (textBox_new.Text == "")
            {
                MessageBox.Show("目录名不可为空");
                return;
            }
            _name = textBox_new.Text;
            for (int i = 0; i < 3 - textBox_new.Text.Length; i++)
            {
                _name = " " + _name;
            }
            if (_fileFunction.EditMenu(_path, _name) == 1)
            {
                _drawFunction.EditTreeNode(_node, _name, 8);
                _editClose = true;
                Close();
            }                       
        }
        private void textBox_new_Leave(object sender, EventArgs e)
        {
            textBox_new.Focus();
        }
        private void textBox_new_KeyPress(object sender, KeyPressEventArgs e)
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
        private void edit_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_editClose)
            {
                if (MessageBox.Show("是否放弃修改", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }               
        }

        private void edit_menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.form.Enabled = true;
        }
    }
}
