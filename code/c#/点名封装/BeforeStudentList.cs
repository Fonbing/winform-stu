using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace ObjectDemo
{
    public class BeforeStudentList : Student   //未点名学生
    {
        private ListBox stulist;   //学生信息列表
        private PictureBox stupic_0; //闪动学生的照片
        private Label stuname_0; //闪动学生姓名
        Label stuid_0;  //闪动学生的学号
        public PictureBox Stupic_0
        {
            get { return stupic_0; }
            set { stupic_0 = value; }
        }

        public Label Stuname_0
        {
            get
            {
                return stuname_0;
            }

            set
            {
                stuname_0 = value;
            }
        }

        public ListBox Stulist
        {
            get
            {
                return stulist;
            }

            set
            {
                stulist = value;
            }
        }

        public Label Stuid_0
        {
            get
            {
                return stuid_0;
            }

            set
            {
                stuid_0 = value;
            }
        }


        public new int StartFind()            //开始点名
        {
            Random rd = new Random();
            //int currRnd = rd.Next(0, listBox1.Items.Count);
            int currRnd = rd.Next(0, Stuid.Count);
            //pictureBox1.Image = System.Drawing.Bitmap.FromFile(filepath + listBox1.Items[currRnd]);
            stupic_0.Image = Image.FromFile(stupath + Stuid[currRnd] + ".jpg");
            stuname_0.Text = Stuname[currRnd];
            stuid_0.Text = Stuid[currRnd];
            stulist.SelectedIndex = stulist.FindString(Stuid[currRnd]);  //获取选定项
            return currRnd;
        }
        public void AddStudent()    //读取并添加学生的信息
        {
            Stuname = new List<string>();
            Stuid = new List<string>();
            StreamReader sr = new StreamReader(stupath + "15软件一班花名册.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                Stulist.Items.Add(line);
                string[] str = line.Split('\t');
                Stuid.Add(str[0]);
                Stuname.Add(str[1]);
            }
        }
        public new void Clear()  //清楚学生的相关信息
        {
            Stupic_0.Image = null;
            Stuid_0.Text = null;
            stuname_0.Text = null;
            stulist.Items.Clear();
        }
    }
}
