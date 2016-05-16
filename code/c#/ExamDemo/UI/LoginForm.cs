using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class LoginForm : Form
    {
        private TestForm f2;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            f2 = new TestForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int isLogin = Change.CheckLogin(textBox1.Text, textBox2.Text);
            if (isLogin == -1)
                MessageBox.Show("请输入用户");
            else if (isLogin == -2)
                MessageBox.Show("请输入密码");
            else if (isLogin == 0)
                MessageBox.Show("无此用户");
            else if (isLogin == 1)
            {
                MessageBox.Show("登陆成功");
               // f2.Show();
                f2.ShowDialog();//显示第二个窗口
                this.Hide();
            }
            else if (isLogin == 2)
                MessageBox.Show("密码错误");
        }
    }
}
