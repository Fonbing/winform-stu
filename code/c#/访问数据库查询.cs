using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;//

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(55454.ToString());

            string strConn = "data source=.;initial catalog=test;uid=sa;password=sa";  //数据库路径
            SqlConnection conn = new SqlConnection(strConn);   //修路
            conn.Open();    //通车

            string strSQL = "select * from student";  //查询数据库（干什么，工人）  
            DataTable dt = new DataTable();   //查询过来的数据用什么装（数据表）
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);  //创建适配器，通道  （让工人通过修的路去取数据）
            da.Fill(dt);   //将取来的数据填到容器里
         
            conn.Close(); //关闭道路

            dataGridView1.DataSource = dt; //将数据存到data~~
            
        }
    }
 }