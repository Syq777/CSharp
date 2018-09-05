using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 端口扫描器
{
    public partial class Form : System.Windows.Forms.Form
    {
        #region  自定义变量
        //常用TCP端口号数组
        private int[] portTCP = new int[180] { 0, 7, 9, 11, 13, 15, 19, 21, 22, 23, 25, 43, 49, 53, 66, 67, 68, 70, 79, 80, 81, 88, 89, 98, 109, 110, 111, 113, 118, 119, 135, 139, 143, 150, 156, 179, 256, 257, 258, 259, 264, 389, 396, 427, 443, 445, 457, 465, 512, 513, 514, 515, 524, 540, 563, 587, 593, 636, 691, 799, 900, 901, 1024, 1025, 1026, 1027, 1028, 1029, 1030, 1031, 1080, 1100, 1214, 1243, 1313, 1352, 1433, 1494, 1498, 1521, 1524, 1525, 1529, 1541, 1542, 1720, 1723, 1745, 1755, 1813, 1944, 2000, 2001, 2003, 2049, 2080, 2140, 2301, 2433, 2447, 2766, 2779, 2869, 2998, 3128, 3268, 3300, 3306, 3372, 3389, 4000, 4001, 4002, 4045, 4321, 4444, 4665, 4899, 5000, 5222, 5556, 5631, 5632, 5678, 5800, 5801, 5802, 5900, 5901, 6000, 6112, 6346, 6347, 6588, 6666, 6667, 7000, 7001, 7002, 7070, 7100, 7777, 7947, 8000, 8001, 8010, 8080, 8081, 8100, 8383, 8888, 9090, 10000, 12345, 20034, 27374, 30821, 32768, 32769, 32770, 32771, 32772, 32773, 32774, 32775, 32776, 32777, 32778, 32779, 32780, 32781, 32782, 32783, 32784, 32785, 32786, 32787, 32788, 32789, 32790 };
        //常用UDP端口号数组
        private int[] portUDP = new int[89] { 0, 7, 9, 11, 53, 67, 68, 69, 111, 123, 135, 137, 138, 161, 191, 192, 256, 260, 445, 500, 514, 520, 1009, 1024, 1025, 1027, 1028, 1030, 1033, 1034, 1035, 1037, 1041, 1058, 1060, 1091, 1352, 1434, 1645, 1646, 1812, 1813, 1900, 1978, 2002, 2049, 2140, 2161, 2301, 2365, 2493, 2631, 2967, 3179, 3327, 3456, 4045, 4156, 4296, 4469, 4802, 5631, 5632, 11487, 31337, 32768, 32769, 32770, 32771, 32772, 32773, 32774, 32775, 32776, 32777, 32778, 32779, 32780, 32781, 32782, 32783, 32784, 32785, 32786, 32787, 32788, 32789, 32790, 43981 };


        //正在运行的线程数目
        private int runningThreadCount = 0;
        //判断当前运行状态  -1:扫描结束 0:扫描暂停 1:正在扫描
        private int flag = -1;
        //保护port变量同时只被一个线程访问
        private Object thisLock = new Object();
        //开始扫描端口编号
        private int start_port;
        //结束扫描端口编号
        private int end_port;
        //当前扫描端口编号
        private int port;    
        //扫描长度
        private double length;
        //本次扫描开放TCP端口个数
        private int tcpcount = 0;
        ////本次扫描开放UDP端口个数
        //private int udpcount = 0;

        //ip地址127.0.0.1
        /*
        private int ip1 =127;
        private int ip2=0;
        private int ip3=0;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
        private int ip4=1;
        */
        //ip地址47.93.9.44
        ///*
        private int ip1 = 47;
        private int ip2 = 93;
        private int ip3 = 9;
        private int ip4 = 44;
        // */
        //ip地址60.205.185.0-+

        #endregion 



        public Form()
        {           
            InitializeComponent();            
        }



        #region 按钮
        #region 清空数据按钮
        private void button_clear_Click(object sender, EventArgs e)
        {
            if (flag==1||flag==0)//正在扫描或暂停
            {
                MessageBox.Show("正在扫描");
            }
            else
            {
                textBox1.Focus();//焦点变到第一个ip输入框
                //清空数据，进度清零
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox_startport.Text = "";
                textBox_endport .Text= "";
                label_tip.Text = "";
                listBox.Items.Clear();
                progressBar.Value = 0;
            }
            
        }
        #endregion

        #region 开始扫描按钮
        private void button_start_Click(object sender, EventArgs e)
        {
            if (flag == 0)//当前状态为暂停
            {
                flag = 1;//继续扫描
                return;
            }                      
            if (flag==-1)//当前状态为结束
            {
                //ip地址
               ///* 
                try
                {
                    ip1 = int.Parse(textBox1.Text);
                    ip2 = int.Parse(textBox2.Text);
                    ip3 = int.Parse(textBox3.Text);
                    ip4 = int.Parse(textBox4.Text);
                    start_port= int.Parse(textBox_startport.Text);
                    end_port = int.Parse(textBox_endport.Text);
                    if (start_port == 0) start_port = 1;//控制端口号>0

                    //将输入数据前的无效0去掉
                    textBox1.Text = ip1.ToString();
                    textBox2.Text = ip2.ToString();
                    textBox3.Text = ip3.ToString();
                    textBox4.Text = ip4.ToString();
                    textBox_startport.Text = start_port.ToString();
                    textBox_endport.Text = end_port.ToString();

                    if (start_port > end_port)//结束端口编号需大于等于开始端口编号
                    {
                        //开始和结束端口号自动设置为相同
                        end_port = start_port;
                        textBox_endport.Text = textBox_startport.Text;
                    }
                }
                catch
                {
                    textBox1.Focus();//从新输入
                    MessageBox.Show("请输入完整地址");
                    return;
                }
                // */
                flag = 1; //状态变为正在扫描
                progressBar.Value = 0;//进度清0
                port = start_port; //当前扫描端口
                length = end_port - start_port+1;//扫描长度
                progressBar.Maximum = (int)length;//进度条长度
                runningThreadCount = 0;//正在运行的线程数目
                tcpcount = 0;//开放tcp端口数
                listBox.Items.Clear();//数据清零
                this.backgroundWorker.RunWorkerAsync();//开始扫描
            }           
        }
        #endregion

        #region 结束扫描按钮
        private void button_end_Click(object sender, EventArgs e)
        {
            flag = -1; //扫描结束       
            this.backgroundWorker.CancelAsync();           
        }
        #endregion

        #region 暂停扫描按钮
        private void button_stop_Click(object sender, EventArgs e)
        {
            if (flag==1)     flag = 0;//扫描暂停
        }
        #endregion
        #endregion



        #region 多线程后台扫描
        #region 扫描特定IP端口
        private void scan(int ip1,int ip2,int ip3,int ip4)
        {
            int sport;
            Function fun = new Function();
            while(true)
            {
                lock (thisLock)
                {
                    while (flag == 0) ;//暂停
                    if (port >end_port || flag == -1) break;//结束扫描
                    //tport = portTCP[tport];
                    sport = port;//领取线程需要扫描的端口序号
                    port++;
                }
                //返回值大于1时说明连接成功
                int retConTCP = fun.scanTCP(ip1, ip2, ip3, ip4, sport);
                if (retConTCP >=1)
                {
                    //MessageBox.Show(retConTCP.ToString());
                    tcpcount++;// 开放TCP端口个数加1
                    //更新显示                    
                    UpdateListBox(listBox,"端口" + sport.ToString().PadLeft(5, '0') + "开放,类型：TCP");              
                }
            }                  
           runningThreadCount--;
        }
        #endregion

        #region 后台进程开始工作时，调用工作函数的地方
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = (int)length / 10;//线程数量
            Thread []thread=new Thread[1000];
            //控制线程数在端口范围不同情况下改变，线程数在500和1000之间
            //(i<=count||i<500)&&
            for (int i=0; (i <= count || i < 500) && i <1000;i++)
            {
                thread[i] = new Thread(() => scan(ip1, ip2, ip3, ip4));
                thread[i].IsBackground = true;//设置线程为后台进程
                thread[i].Start();//进程开始
                runningThreadCount++;//当前运行进程数加1
                UpdateProgressBar(progressBar);//更新进度条
                //更新扫描信息
                if (flag==1 && port <= end_port)
                    UpdateLabel(label_tip, string.Format("正在扫描{0}.{1}.{2}.{3},进度：{4}", ip1, ip2, ip3, ip4, ((port - start_port + 1) / length).ToString("p")));
                if(flag==0 && port <= end_port)
                    UpdateLabel(label_tip, string.Format("暂停扫描{0}.{1}.{2}.{3},进度：{4}", ip1, ip2, ip3, ip4, ((port - start_port + 1) / length).ToString("p")));
                
            }
            while (runningThreadCount > 0)
            {
                UpdateProgressBar(progressBar);//更新进度条
                //更新扫描信息
                if (flag == 1 && port <= end_port)
                    UpdateLabel(label_tip, string.Format("正在扫描{0}.{1}.{2}.{3},进度：{4}", ip1, ip2, ip3, ip4, ((port - start_port + 1) / length).ToString("p")));
                if (flag == 0 && port <= end_port)
                    UpdateLabel(label_tip, string.Format("暂停扫描{0}.{1}.{2}.{3},进度：{4}", ip1, ip2, ip3, ip4, ((port - start_port + 1) / length).ToString("p")));
            }

        }
        #endregion

        #region 通过响应消息，处理界面的显示工作
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        #endregion

        #region 后台工作完成后的消息处理，进行后续的处理工作
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            flag = -1;//结束扫描
            progressBar.Value =(int)length;//扫描结束进度100%
             //扫描结束显示信息
            label_tip.Text = ip1+"."+ip2+"."+ip3+"."+ip4+ "扫描完成，共开放TCP端口"+tcpcount+"个";
        }
        #endregion
        #endregion 



        #region  组件内容委托更新
        #region  progressBar更新
        private delegate void ProgressBarDelegate(ProgressBar progressBar);//委托
        private void UpdateProgressBar(ProgressBar progressBar)
        {
            try
            {
                //InvokeRequired==true:有一个创建控件以外的线程想访问控件
                if (progressBar.InvokeRequired)
                {
                    //将委托绑定到方法
                    ProgressBarDelegate a = new ProgressBarDelegate(UpdateProgressBar);                 
                    //在应用程序的主线程上执行指定的委托
                    this.Invoke(a, new object[] { progressBar });                    
                }
                else
                {
                    if (port <=end_port)
                        progressBar.Value = port-start_port+1;
                }
            }
            catch{}            
        }
        # endregion

        #region  Label更新
        private delegate void LabelDelegate(Label label, string text);//委托
        private void UpdateLabel(Label label, string text)
        {
            try
            {
                //InvokeRequired==true:有一个创建控件以外的线程想访问控件
                if (label.InvokeRequired)
                {
                    //将委托绑定到方法
                    LabelDelegate a = new LabelDelegate(UpdateLabel);
                    //在应用程序的主线程上执行指定的委托
                    this.Invoke(a, new object[] { label, text });
                }
                else
                {
                    label.Text = text.Trim();
                }
            }
            catch { }            
        }
        # endregion

        #region  ListBox更新
        private delegate void ListBoxDelegate(ListBox listBox, string text);//委托
        private void UpdateListBox(ListBox listBox, string text)
        {
            try
            {
                //InvokeRequired==true:有一个创建控件以外的线程想访问控件
                if (listBox.InvokeRequired)
                {
                    //将委托绑定到方法
                    ListBoxDelegate a = new ListBoxDelegate(UpdateListBox);
                    //在应用程序的主线程上执行指定的委托
                    this.Invoke(a, new object[] { listBox,text});
                }
                else
                {
                    listBox.Items.Add(text);
                }
            }
            catch { }            
        }
        # endregion
        # endregion



        #region  IP地址框
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 3)//当输入3个数字后跳转到下个textbox
            {
                //限制输入最大值为255
                if (int.Parse(textBox1.Text) > 255) textBox1.Text = "255";
                //焦点跳转到下个textbox
                textBox2.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 3)//当输入3个数字后跳转到下个textbox
            {
                //限制输入最大值为255
                if (int.Parse(textBox2.Text) > 255) textBox2.Text = "255";
                //焦点跳转到下个textbox
                textBox3.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 3)//当输入3个数字后跳转到下个textbox
            {
                //限制输入最大值为255
                if (int.Parse(textBox3.Text) > 255) textBox3.Text = "255";
                //焦点跳转到下个textbox
                textBox4.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 3)//限制输入最大值为255
            {
                if(int.Parse(textBox4.Text) > 255)
                            textBox4.Text = "255";
            }
        }
        private void textBox_startport_TextChanged(object sender, EventArgs e)
        {
            if (textBox_startport.Text.Length == 5)//当输入5个数字后跳转到下个textbox
            {
                //限制输入最大值为65525
                if (int.Parse(textBox_startport.Text) > 65525)
                    textBox_startport.Text = "65525";
                //焦点跳转到下个textbox
                textBox_endport.Focus();
            }
        }
        private void textBox_endport_TextChanged(object sender, EventArgs e)
        {
            if (textBox_endport.Text.Length == 5)//当输入5个数字后跳转到下个textbox
            {
                //限制输入最大值为65525
                if (int.Parse(textBox_endport.Text) > 65525)
                    textBox_endport.Text = "65525";
            }            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //限制输入数字
            if (((int)e.KeyChar <48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 )//限制输入数字
            {
                e.Handled = true;
            }
            //当前内容不为空时空格键或小数点跳转到下个textbox
            if (textBox1.Text.Length != 0 && ((int)e.KeyChar == 32 || (int)e.KeyChar == 46))
            {
                textBox2.Focus();
            }
            //输入完成后按回车开始扫描
            if ((int)e.KeyChar == 13 && textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && textBox_startport.Text.Length != 0 && textBox_endport.Text.Length != 0)
            {
                button_start_Click(sender, e);
            }
            //当IP地址输完后按回车开始输入端口号
            if ((int)e.KeyChar == 13 && textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 )
            {
                textBox_startport.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //限制输入数字
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)//限制输入数字
            {
                e.Handled = true;
            }
            //textbox2空白时退格键推到textbox1
            if ((int)e.KeyChar == 8 && textBox2.Text.Length == 0)
            {
                textBox1.Focus();
            }
            //当前内容不为空时空格键或小数点跳转到下个textbox
            if (textBox2.Text.Length != 0&&( (int)e.KeyChar == 32 || (int)e.KeyChar == 46)) 
            {
                textBox3.Focus();
            }
            //输入完成后按回车开始扫描
            if ((int)e.KeyChar == 13 && textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && textBox_startport.Text.Length != 0 && textBox_endport.Text.Length != 0)
            {
                button_start_Click(sender, e);
            }
            //当IP地址输完后按回车开始输入端口号
            if ((int)e.KeyChar == 13 && textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0)
            {
                textBox_startport.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //限制输入数字
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)//限制输入数字
            {
                e.Handled = true;
            }
            //textbox3空白时退格键推到textbox2   
            if ((int)e.KeyChar == 8 && textBox3.Text.Length == 0)
            {
                textBox2.Focus();
            }
            //当前内容不为空时空格键或小数点跳转到下个textbox   
            if (textBox3.Text.Length != 0 &&((int)e.KeyChar == 32|| (int)e.KeyChar == 46))
            {
                textBox4.Focus();
            }
            //输入完成后按回车开始扫描
            if ((int)e.KeyChar == 13 && textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && textBox_startport.Text.Length != 0 && textBox_endport.Text.Length != 0)
            {
                button_start_Click(sender, e);
            }
            //当IP地址输完后按回车开始输入端口号
            if ((int)e.KeyChar == 13 && textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0)
            {
                textBox_startport.Focus();
            }

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //限制输入数字
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
            //textbox4空白时退格键推到textbox3
            if ((int)e.KeyChar == 8 && textBox4.Text.Length == 0)                
            {
                textBox3.Focus();
            }
            //输入完成后按回车开始扫描
            if ((int)e.KeyChar == 13&& textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && textBox_startport.Text.Length != 0 && textBox_endport.Text.Length != 0)
            {
                button_start_Click(sender, e);
            }
            //当IP地址输完后按回车开始输入端口号
            if ((int)e.KeyChar == 13 && textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0)
            {
                textBox_startport.Focus();
            }
        }

        private void textBox_startport_KeyPress(object sender, KeyPressEventArgs e)
        {
            //限制输入数字
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
            //当前内容不为空时空格键或小数点跳转到下个textbox   
            if (textBox_startport.Text.Length != 0 && ((int)e.KeyChar == 32 || (int)e.KeyChar == 46))
            {
                textBox_endport.Focus();
            }
            //输入完成后按回车开始扫描
            if ((int)e.KeyChar == 13 && textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && textBox_startport.Text.Length != 0 && textBox_endport.Text.Length != 0)
            {
                button_start_Click(sender, e);
            }
        }

        private void textBox_endport_KeyPress(object sender, KeyPressEventArgs e)
        {
            //限制输入数字
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
            //textbox_endport空白时退格键推到textbox_startport
            if ((int)e.KeyChar == 8 && textBox_endport.Text.Length == 0)
            {
                textBox_startport.Focus();
            }
            //输入完成后按回车开始扫描
            if ((int)e.KeyChar == 13 && textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && textBox_startport.Text.Length != 0 && textBox_endport.Text.Length != 0)
            {
                button_start_Click(sender, e);
            }
        }
        #endregion

      
    }
}
