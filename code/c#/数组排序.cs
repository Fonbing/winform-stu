using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortDemo
{
    public partial class Form1 : Form
    {
        double[] a = new double[5];
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double element = double.Parse(textBox1.Text);
            a[i] = element;
            textBox2.Text += a[i] + " ";
            i++;
            textBox1.Text = "";
            label2.Text = "请输入第" + (i + 1) + "个元素";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Array.Sort(a);
            for (i = 0; i < 5; i++)
                textBox3.Text += a[i] + " ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "请输入第1个元素";
            this.Text = "排序";
        }
    }
}
