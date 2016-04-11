using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04winform_loop1
{
    public partial class Form1 : Form
    {
        int i = 0, t = 1;
        bool flag = true;
        Color now;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "ABCDEFGHIGKLMNOPQRSTVWXYZ";
            now = richTextBox1.SelectionColor; //备份当前颜色
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //在一个按钮中实现滚动暂停
            if (flag)
            {
                timer1.Enabled = true;
                button1.Text = "暂停";
                flag = false;
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "开始";
                flag = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //返回开头并停止滚动
            i = 0;
            t = 1;
            timer1.Enabled = false;
            flag = true;
            button1.Text = "开始";
            richTextBox1.SelectionColor = now;  //返回初始颜色
            MessageBoxButtons bt = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("是否退出!!!", "提示", bt);
            if ("Yes" == result.ToString())   //选择是则退出
                Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {  
            richTextBox1.SelectionColor = now;//返回初始颜色
            // richTextBox1.SelectionStart = i；
            richTextBox1.Select(i, 1); //从第i-1个数，开始变颜色，，
            //richTextBox1.SelectionLength = 1;
            richTextBox1.SelectionColor = Color.Red;
            //控制下标实现循环滚动
            i += t;
            if (i == 0 || i == richTextBox1.Text.Length - 1)
                t = -t;

        }
    }
}
