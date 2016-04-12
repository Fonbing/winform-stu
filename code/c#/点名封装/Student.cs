using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ObjectDemo
{
    public class Student
    {
        public string stupath = ".\\pic\\";
        public PictureBox stupic;
        public static List<string> stuname = new List<string>();  //??
        public static List<string> stuid = new List<string>();
        public List<string> StuName
        {
            get { return stuname; }
        }

        public void StartFind()
        {
        }
        public void Clear()
        {
            stuname.Clear();
            stuid.Clear();
        }
    }
}
