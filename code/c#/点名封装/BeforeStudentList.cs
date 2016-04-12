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
    public class BeforeStudentList : Student
    {
        ListBox stulist;
        PictureBox stupic_0;
        Label stuname_0;
        Label stuid_0;
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

        public void AddStudent()
        {
            //stuname = new List<string>();
            //stuid = new List<string>();
            StreamReader sr = new StreamReader(stupath + "15软件一班花名册.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                Stulist.Items.Add(line);
                string[] str = line.Split('\t');
                stuid.Add(str[0]);
                stuname.Add(str[1]);
            }
        }
        public new int StartFind()
        {
            Random rd = new Random();
            //int currRnd = rd.Next(0, listBox1.Items.Count);
            int currRnd = rd.Next(0, stuid.Count);
            //pictureBox1.Image = System.Drawing.Bitmap.FromFile(filepath + listBox1.Items[currRnd]);
            stupic_0.Image = Image.FromFile(stupath + stuid[currRnd] + ".jpg");
            // temp =stuname[currRnd] ;  //将抽到的文件名临时存起来
            stuname_0.Text = stuname[currRnd];
            stuid_0.Text = stuid[currRnd];
           // stulist.SetSelected(currRnd, true);
            return currRnd;
        }
        public new void Clear()
        {
            Stupic_0.Image= null;
            Stuid_0.Text= null;
            stuname_0 .Text= null;
            stulist.Items.Clear();
        }
    }
}
