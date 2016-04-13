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
            fs.Stuinfo = panel1;  //传入容器存放学生姓名及id
            if (flag)    //实现开始功能
            {
                if (listBox1.GetSelected(index))     //删除选中的同学
                    listBox1.Items.RemoveAt(index);
                button1.Text = "停止";
                if (stu.Stuname.Count == 0)    //抽完后重新读取文件
                {
                    MessageBox.Show("人员已抽完，将重新开始");
                    Clear();
                    MassArgs();
                    button1.Text = "开始";
                }
                else
                {
                    timer1.Enabled = true;
                    flag = false;
                }
                
            }
            else     //实现停止功能
            {
                button1.Text = "开始";
                fs.AddStuPic(pictureBox1);  //添加点完的学生照片
                fs.AddStuName(label1.Text);  //…………姓名
                timer1.Enabled = false;
                stu.Stuname.RemoveAt(index);     //移除学生姓名
                stu.Stuid.RemoveAt(index);
                //listBox1.SetSelected(index, true);
                flag = true;
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
            index = bsl.StartFind();  //返回停止时学生信息的下标，用作移除
        }
        private void Clear()  //清理学生信息
        {
            stu.Clear();
            fs.Clear();
            bsl.Clear();
        }
        private void MassArgs()    //  传入参数
        {
            fs = new FinishStudent();
            bsl = new BeforeStudentList();
            stu = new Student();
            bsl.Stulist = listBox1;  
            bsl.Stuname_0 = label1;
            bsl.Stuid_0 = label2;
            bsl.Stupic_0 = pictureBox1;
            bsl.AddStudent();
           // fs.Stuinfo = panel1;
           
        }
    }
}
