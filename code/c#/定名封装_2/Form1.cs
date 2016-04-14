using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        int SUM = 0;
        int currentRnd = 0;
        string filepath = Application.StartupPath + @"\pic\";
        List<Student> stulist = new List<Student>();
        private void Form1_Load(object sender, EventArgs e)
        {           
            StreamReader sr = new StreamReader(filepath + "15软件一班花名册.txt",Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] str = line.Split(new char[]{'\t'},StringSplitOptions.RemoveEmptyEntries);
                if (str.Length == 3)
                {
                    Student stu = new Student("15软件1班");
                    stu.stuID = str[0];
                    stu.stuName = str[1];
                    stulist.Add(stu);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Random rnd = new Random();
            currentRnd = rnd.Next(0, stulist.Count);
            if (stulist.Count > 0)
            {
                Student stu = new Student();
                stu=stulist[currentRnd];
                picRandom.Image = System.Drawing.Bitmap.FromFile(filepath + stu.stuID+".jpg");
                label1.Text = stu.stuID;
                label2.Text = stu.stuName;

            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("所有人员已经抽取完毕！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 100;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Add2Panel(filepath + stulist[currentRnd].stuID+".jpg");
            RemoveDouble(currentRnd);
        }
        private void Add2Panel(string filename)
        {
            PictureBox pic = new PictureBox();
            pic.Width = 100;
            pic.Height = 80;
            pic.Top = SUM / 4 * 90 + 20;
            pic.Left = SUM % 4 * 100 + 20;
            pic.Image = System.Drawing.Bitmap.FromFile(filename);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            this.panel1.VerticalScroll.Value = this.panel1.VerticalScroll.Minimum;
            this.panel1.Controls.Add(pic);
            SUM++;
        }
        private void RemoveDouble(int fileindex)
        {
            stulist.RemoveAt(currentRnd);
        }
    }
}
