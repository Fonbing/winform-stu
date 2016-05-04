using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class Form1 : Form
    {
        private Form2 f2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f2 = new Form2();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int isLogin = Login.CheckLogin(textBox1.Text, textBox2.Text);
            if (isLogin == -1)
                MessageBox.Show("请输入用户");
            else if (isLogin == -2)
                MessageBox.Show("请输入密码");
            else if (isLogin == 0)
                MessageBox.Show("无此用户");
            else if (isLogin == 1)
            {
                MessageBox.Show("登陆成功");
                f2.Show();
            }
            else if (isLogin == 2)
                MessageBox.Show("密码错误");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            f2.Show();
        }


    }
}
