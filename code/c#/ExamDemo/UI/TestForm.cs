using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace UI
{
    public partial class TestForm : Form
    {
        private DataTable dt;
        private Button bt;
        private int bt_tag = 0;   //按钮的唯一标志

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button3, "交卷前请三思");
            BtColor.initialBtColor();
            ResultManager.InitialReslist();
            addBt();
            dt = Change.Get(""); //从数据库获取题目
            addTopic();
            findBt().BackColor = BtColor.select;  //初始化第一题颜色为黄色

        }


        private void addBt()
        {
            for (int i = 0; i < 20; i++)   //动态生成20个按钮
            {
                Button bt1 = new Button();
                bt1.Size = new Size(70, 30);
                bt1.Left = i % 10 * 70;
                bt1.Top = i / 10 * 30;            //************
                bt1.Click += Bt_Click;
                bt1.Tag = i;            //给按钮指定唯一标志（0——19）
                bt1.BackColor = Color.Red;          //全部按钮初始化为红色
                bt1.Text = "第" + (i + 1) + "题";
                panel2.VerticalScroll.Value = panel2.VerticalScroll.Minimum;
                panel2.Controls.Add(bt1);
            }
        }

        private void addTopic()
        {
            label1.Text = dt.Rows[bt_tag][1].ToString();        //题目
            radioButton1.Text = dt.Rows[bt_tag][2].ToString();  //各选项
            radioButton2.Text = dt.Rows[bt_tag][3].ToString();
            radioButton3.Text = dt.Rows[bt_tag][4].ToString();
            radioButton4.Text = dt.Rows[bt_tag][5].ToString();
            // bt_sum++;
            label2.Text = "第" + (bt_tag + 1) + "题";
            //if (bt_sum == 10)
            //  bt_sum = 0;
        }    //将题目添加到各控件

        private void Bt_Click(object sender, EventArgs e)
        {
            ChangeLastBtColor();        //改变上一按钮颜色（在还没存储当前按钮时使用）
            bt = (Button)sender;        //将当前按钮暂存
            bt_tag = Convert.ToInt32(bt.Tag);  //将按钮唯一标志暂存
            ChangePresentBt();      //改变当前按钮相应属性
        }

        //改变上一按钮颜色
        private void ChangeLastBtColor()
        {
            if (ResultManager.resList[bt_tag].TopKey != 0)
            {
                findBt().BackColor = BtColor.finish;
            }
            else {
                findBt().BackColor = BtColor.noFin;
            }
        }

        //点击当前按钮时，应做
        private void ChangePresentBt()
        {
            addTopic();                   //添加题目
            initial();                   //初始化选项
            bt = findBt();              //找到本按钮，并将本按钮暂存
            bt.BackColor = BtColor.select;
            if (ResultManager.resList[bt_tag].TopKey != 0)  //如果本题已做过，则
            {
                FinishResult(ResultManager.resList[bt_tag].TopKey);   //把本题选项回归原先状态
            }
        }
        private Button findBt()   //查找按钮
        {
            Button bt0 = (Button)panel2.GetChildAtPoint(new Point(bt_tag % 10 * 70, bt_tag / 10 * 30));
            return bt0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChangeLastBtColor();
            --bt_tag;
            if (bt_tag <= 0)
                bt_tag = 0;
            ChangePresentBt();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            ChangeLastBtColor();
            ++bt_tag;
            if (bt_tag >= 19)
                bt_tag = 19;
            ChangePresentBt();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int s = 0;
            foreach (Result r in ResultManager.resList)    //判断总成绩
            {
                s = s + r.OResult;
            }
            if (MessageBox.Show("确认要提交吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                toolTip1.Show("dasd", label1);
                MessageBox.Show("成绩为：" + s + "分");
                new Thread(new Teacher().DoWork).Start();  //开启判卷系统
                Application.ExitThread();
                //Thread.Sleep(1000);
                //System.Environment.Exit(0);
            }
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)         //如果已选中则
            {
                checkedTF(rb.Tag.ToString());
            }
        }

        private void checkedTF(string tag)          //将考生答题情况添加进集合
        {
            Result res = new Result();
            res.TopID = bt_tag + 1;              //保存题目ID
            res.TopKey = Convert.ToInt32(tag);    //保存考生答案
            if (tag == dt.Rows[bt_tag][6].ToString()) //判断是否答对
                res.OResult = 5;  //答对加五分
            ResultManager.UpdateAt(bt_tag, res);  //更新此处的元素
        }

        private void FinishResult(int tag)    //回归原先结果
        {
            switch (tag)
            {
                case 1:
                    radioButton1.Checked = true;
                    break;
                case 2:
                    radioButton2.Checked = true;
                    break;
                case 3:
                    radioButton3.Checked = true;
                    break;
                case 4:
                    radioButton4.Checked = true;
                    break;
            }
        }

        private void initial()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }    //初始化各选项

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("正在考试中不允许退出,如需退出请点击交卷", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //MessageBox.Show("正在考试中不允许退出,如需退出请点击交卷");
            e.Cancel = true;
        }




        //截图

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
           IntPtr hdcDest, // 目标 DC的句柄
           int nXDest,
         int nYDest,
      int nWidth,
         int nHeight,
         IntPtr hdcSrc,  // 源DC的句柄
           int nXSrc,
         int nYSrc,
         System.Int32 dwRop  // 光栅的处理数值
           );
        private void timer1_Tick(object sender, EventArgs e)
        {
            //获得当前屏幕的大小
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);
            //创建一个以当前屏幕为模板的图象
            Graphics g1 = this.CreateGraphics();
            //创建以屏幕大小为标准的位图 
            Image MyImage = new Bitmap(rect.Width, rect.Height, g1);
            Graphics g2 = Graphics.FromImage(MyImage);
            //得到屏幕的DC
            IntPtr dc1 = g1.GetHdc();
            //得到Bitmap的DC 
            IntPtr dc2 = g2.GetHdc();
            //调用此API函数，实现屏幕捕获
            BitBlt(dc2, 0, 0, rect.Width, rect.Height, dc1, 0, 0, 13369376);
            //释放掉屏幕的DC
            g1.ReleaseHdc(dc1);
            //释放掉Bitmap的DC 
            g2.ReleaseHdc(dc2);
            //以JPG文件格式来保存
            MyImage.Save("Capture.jpg", ImageFormat.Jpeg);
            MessageBox.Show("当前屏幕已经保存为F盘的capture.jpg文件！");
        }
    }
}
