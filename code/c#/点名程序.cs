using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_Game
{
    public partial class Form2 : Form
    {
        string filepath = ".\\新闻部\\";
        string temp;       //临时变量，用来存储抽到的同学，实现删除元素，不再抽到
        bool flag = true;    //设置标志位，实现一个按钮两种功能
        int sum_0, sum_1;   //计数器，实现控件的有序排列
        List<String> filename = new List<String>();  //构建list集合，指定存入string类型
        public Form2()
        {
            InitializeComponent();
        }

        private void AddPic()  //添加图片
        {
            PictureBox pic = new PictureBox();
            pic.Width = 50;
            pic.Height = 70;
            pic.Top = sum_0 / 4 * 100;  //************
            pic.Left = sum_0 % 4 * 70;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;  //强制图片自适应控件
            pic.Image = pictureBox1.Image;
            sum_0++;
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Minimum;
            panel1.Controls.Add(pic);
        }
        private void AddLab()  //动态生成标签并添加到panel容器中
        {
            Label lab = new Label();
            lab.Width = 70;
            lab.Height = 20;
            lab.Top = sum_1 / 4 * 100 + 80;  //************
            lab.Left = sum_1 % 4 * 70 + 5;
            sum_1++;
            lab.Text = label1.Text;
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Minimum;
            panel1.Controls.Add(lab);
        }

        private void Clear()    //所有控件归零
        {
            sum_0 = 0;     //控制图片的坐标归零
            sum_1 = 0;     //标签……
            filename.Clear();    //删除集合全部元素
            panel1.Controls.Clear();  //删除panel容器内所有控件(图片)
            label1.Text = null;   //标签赋值为空
            pictureBox1.Image = null;  //图片赋值为空
            listBox1.Items.Clear();  //清空listbox容器所有元素
            ErgodicFile();  //重新遍历并添加图片到泛型集合中
            timer1.Enabled = false;
        }
        private void ErgodicFile()   //遍历文件并添加到集合list
        {
            DirectoryInfo dir = new DirectoryInfo(filepath);
            foreach (FileInfo file in dir.GetFiles("*.jpg"))
            {
                filename.Add(file.Name);
                //listBox1.Items.Add(file.Name);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // MessageBox.Show(filename.Count.ToString());
            //listBox1.Visible = false;
            ErgodicFile();   
            Button[] but = new Button[2];     //动态加载按钮
            int x = 10, y = 50;
            for (int i = 0; i < but.Length; i++)
            {

                but[i] = new Button();
                but[i].Location = new Point(x, y);
                but[i].Size = new Size(80, 30);
                but[i].Tag = i;
                y += 70;
                this.Controls.Add(but[i]);
                but[i].Click += but_Click;  //为按钮添加事件
            }
            but[0].Text = "开始";
            but[1].Text = "重置";

        }
        private void but_Click(object sender, EventArgs e)  
        {
            Button but = (Button)sender;
            //MessageBox.Show(e.ToString());
            switch (but.Tag.ToString())
            {
                case "0":
                    if (flag)    //实现开始功能
                    {
                        but.Text = "停止";
                        if (filename.Count == 0)  //抽完后重新添加文件
                        {
                            MessageBox.Show("人员已抽完，将重新开始");
                            Clear();
                            but.Text = "开始";
                            break;
                        }
                        timer1.Enabled = true;
                        flag = false;
                    }
                    else    //实现停止功能
                    {
                        but.Text = "开始";
                        AddPic();
                        AddLab();
                        timer1.Enabled = false;
                        filename.Remove(temp);     //移除文件
                        listBox1.Items.Add(label1.Text);   //添加条目
                        flag = true;
                    }
                    break;
                case "1":  //重置
                    Clear();
                    break;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Random rd = new Random();
            //int currRnd = rd.Next(0, listBox1.Items.Count);
            int currRnd = rd.Next(0, filename.Count);
            //pictureBox1.Image = System.Drawing.Bitmap.FromFile(filepath + listBox1.Items[currRnd]);
            pictureBox1.Image = Image.FromFile(filepath + filename[currRnd]);
            temp = filename[currRnd];  //将抽到的文件名临时存起来
            label1.Text = temp.Replace(".jpg", "");
        }


    }
}
