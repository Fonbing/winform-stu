using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectDemo
{
    public class FinishStudent : Student  //点到的学生
    {
        private int sum_0, sum_1;
        private Panel stuinfo;
        private Label stuname;
        // Label label1;
        public Panel Stuinfo
        {
            get { return stuinfo; }
            set { stuinfo = value; }
        }
        //动态生成控件并添加到panel容器中
        public void AddStuPic(PictureBox pic)  //添加点到的学生照片
        {
            Stupic = new PictureBox();
            Stupic.Width = 50;
            Stupic.Height = 70;
            Stupic.Top = sum_0 / 4 * 100;  //************
            Stupic.Left = sum_0 % 4 * 70;
            Stupic.SizeMode = PictureBoxSizeMode.StretchImage;  //强制图片自适应控件
            Stupic.Image = pic.Image;
            sum_0++;
            stuinfo.VerticalScroll.Value = stuinfo.VerticalScroll.Minimum;
            stuinfo.Controls.Add(Stupic);
        }
        public void AddStuName(string name)  //添加点到的学生姓名
        {
            stuname = new Label();
            stuname.Width = 70;
            stuname.Height = 20;
            stuname.Top = sum_1 / 4 * 100 + 80;  //************
            stuname.Left = sum_1 % 4 * 70 + 5;
            sum_1++;
            stuinfo.VerticalScroll.Value = stuinfo.VerticalScroll.Minimum;
            stuname.Text = name;
            stuinfo.Controls.Add(stuname);
        }
        public new void Clear()  //清除点到学生的信息
        {
            sum_0 = 0;
            sum_1 = 0;
            stuinfo.Controls.Clear();
        }
    }
}
