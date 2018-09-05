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
    public partial class attribute : Form
    {
        FileFunction _fileFunction = new FileFunction();
        PathFunction _pathFunction = new PathFunction();
        public attribute(TreeNode node)
        {
            InitializeComponent();
            string[] path = new string[3];
            path[0] = node.FullPath;
            path[2] = "";
            if (_pathFunction.SplitPathInterface(path) == 0)
            {
                Close();
                return;
            }            
            if (path[2] == "")
            {
                MessageBox.Show(node.FullPath);
                Close();
                return;
            }              
            FCB fcb = new FCB();
            int[] fileAddress = _fileFunction.SearchAddress(path);
            if (fileAddress[0] == 0)
            {
                Close();
                return;
            }
            if (fileAddress[1] == 64)
            {
                MessageBox.Show("文件或目录不存在");
                Close();
                return;
            }
            Show();
            MainForm.form.Enabled = false;
            label_address.Focus();
            fcb = _fileFunction.ReadItem(path[0], fileAddress[0],fileAddress[1]);
            textBox_name.Text = fcb.GetName();
            int attribute = fcb.GetAttribute();
            if(attribute==8)
            {
                textBox_type.Text ="文件夹";
                label_length.Visible = false;
                textBox_length.Visible = false; 
                label_attribute.Visible = false;
                checkBox_readonly.Visible = false;
            }
            else if(attribute == 2|| attribute == 3)
            {
                textBox_type.Text ="可执行文件";
                if(attribute==3)
                {
                    checkBox_readonly.Checked = true;
                }
            }
            else if(attribute == 4||attribute == 5)
            {
                textBox_type.Text = "文本文档 (.txt)";
                if (attribute == 5)
                {
                    checkBox_readonly.Checked = true;
                }
            }
            else
            {
                textBox_type.Text ="未知文件";
            }
            textBox_path.Text = node.FullPath;
            textBox_length.Text = (fcb.GetLength()*64).ToString()+"字节";
            textBox_address.Text = fcb.GetAddress().ToString();
            textBox_disknum.Text = fileAddress[0].ToString();
        }
        private void label_address_Leave(object sender, EventArgs e)
        {
            label_address.Focus();
        }

        private void attribute_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.form.Enabled = true;
        }
    }
}
