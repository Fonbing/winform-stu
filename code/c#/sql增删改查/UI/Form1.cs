using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            select_cb1.Visible = false;
            select_cb2.Visible = false;
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Login.CheckSelect("*", "");
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void insert_bt1_Click(object sender, EventArgs e)
        {
            int i = Login.CheckInsert(insert_tb1.Text, insert_tb2.Text, insert_tb3.Text);
            if (i == 1)
            {
                dataGridView1.DataSource = Login.CheckSelect("*", "");
                show.Text = "插入成功";
            }
            else
                MessageBox.Show("学号不能为空");
        }

        private void delete_bt1_Click(object sender, EventArgs e)
        {
            int i = Login.CheckDelte(delete_tb1.Text);
            if (i == 1)
            {
                dataGridView1.DataSource = Login.CheckSelect("*", "");
                show.Text = "删除成功";
            }
            else
                MessageBox.Show("请输入学号");
        }

        private void update_bt1_Click(object sender, EventArgs e)
        {
            int i = Login.CheckUpdate(update_tb1.Text, update_tb2.Text, update_tb3.Text);
            if (i == 1)
            {
                dataGridView1.DataSource = Login.CheckSelect("*", "");
                show.Text = "修改成功";
            }
            else
                MessageBox.Show("请输入学号");
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            select_rb1.Checked = false;
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            select_cb1.Visible = true;
            select_cb2.Visible = false;
            if (select_cb1.Items.Count == select_cb1.Items.Count)
                select_cb1.Items.Clear();
            DataTable dt = Login.CheckSelect("distinct stuClass", "");
            foreach (DataRow data in dt.Rows)    
            {
                select_cb1.Items.Add(data[0].ToString());
            }
            select_cb1.SelectedIndex = 0;

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            select_rb1.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            select_cb1.Visible = false;
            select_cb2.Visible = true;
            if (select_cb2.Items.Count == select_cb2.Items.Count)
                select_cb2.Items.Clear();
            DataTable dt = Login.CheckSelect("distinct stuDepartment ", "");
            foreach (DataRow data in dt.Rows)
            {
                select_cb2.Items.Add(data[0].ToString());
            }
            select_cb2.SelectedIndex = 0;
        }

        private void select_bt1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                dataGridView1.DataSource = Login.CheckSelect("*", "stuClass = '" + select_cb1.SelectedItem + "'");
            if (checkBox2.Checked)
                dataGridView1.DataSource = Login.CheckSelect("*", "stuDepartment = '" + select_cb2.SelectedItem + "'");
        }
    }
}
