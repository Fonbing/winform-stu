using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ObjectDemo
{
    public partial class Form1 : Form
    {
        FinishStudent fs;
        BeforeStudentList bsl;
        Student stu;
        bool flag = true;  //实现一个按钮两种功能
        int index;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MassArgs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fs.Stuinfo = panel1;
            switch (flag)    //实现开始功能
            {
                case true:
                    {
                        button1.Text = "停止";
                        if (bsl.StuName.Count == 0)  //抽完后重新读取文件
                        {
                            MessageBox.Show("人员已抽完，将重新开始");
                            Clear();
                            MassArgs();
                            button1.Text = "开始";
                            break;
                        }
                        timer1.Enabled = true;
                        flag = false;
                        break;
                    }
                case false:   //实现停止功能
                    {
                        button1.Text = "开始";
                        fs.AddStuPic(pictureBox1);
                        fs.AddStuName(label1.Text, label2);
                        timer1.Enabled = false;
                        Student.stuname.RemoveAt(index);     //移除文件
                        Student.stuid.RemoveAt(index);
                        //listBox1.Items.RemoveAt(index);
                        //listBox1.SetSelected(index, true);
                        //label1.
                        flag = true;
                        break;
                    }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
            button1.Text = "开始";
            flag = true;
            timer1.Enabled = false;
            MassArgs();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            index = bsl.StartFind();
        }
        private void Clear()
        {
            stu.Clear();
            fs.Clear();
            bsl.Clear();
          //  MassArgs();
        }
        private void MassArgs()
        {
            fs = new FinishStudent();
            bsl = new BeforeStudentList();
            stu = new Student();
            bsl.Stulist = listBox1;
            fs.Stuinfo = panel1;
            bsl.Stuname_0 = label1;
            bsl.Stuid_0 = label2;
            bsl.Stupic_0 = pictureBox1;
            bsl.AddStudent();
        }
    }
}
