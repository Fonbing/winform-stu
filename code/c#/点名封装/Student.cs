using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDemo
{
    public class Student
    {
        public string stupath = ".\\pic\\";     //学生信息的路径
        private PictureBox stupic;                //学生照片
        private static List<string> stuname;    //学生姓名
        private static List<string> stuid;        //学生学号
        public PictureBox Stupic
        {
            get
            {
                return stupic;
            }

            set
            {
                stupic = value;
            }
        }
        public List<string> Stuname
        {
            get
            {
                return stuname;
            }

            set
            {
                stuname = value;
            }
        }

        public List<string> Stuid
        {
            get
            {
                return stuid;
            }

            set
            {
                stuid = value;
            }
        }

        

        public void StartFind()
        {
        }
        public void Clear()   //清楚学生的相关信息（姓名，学号）
        {
            Stuname.Clear();
            Stuid.Clear();
        }
    }
}
