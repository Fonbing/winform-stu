using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectDemo
{
   public class FinishStudent:Student
    {
        int sum_0, sum_1;
        public Panel stuinfo;
        public new Label stuname;
        // Label label1;
        public Panel Stuinfo
        {
            get { return stuinfo; }
            set { stuinfo = value;}
        }
        public void AddStuPic(PictureBox pic)  //添加图片
        {
            stupic = new PictureBox();
            stupic.Width = 50;
            stupic.Height = 70;
            stupic.Top = sum_0 / 4 * 100;  //************
            stupic.Left = sum_0 % 4 * 70;
            stupic.SizeMode = PictureBoxSizeMode.StretchImage;  //强制图片自适应控件
            stupic.Image = pic.Image;
            sum_0++;
            stuinfo.VerticalScroll.Value = stuinfo.VerticalScroll.Minimum;
            stuinfo.Controls.Add(stupic);
        }
        public void AddStuName(string name , Label id)  //动态生成标签并添加到panel容器中
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
        public new void Clear()
        {
            sum_0 = 0;
            sum_1 = 1;
            stuinfo.Controls.Clear();
        }
    }
}
