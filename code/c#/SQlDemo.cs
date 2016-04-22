using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = GetDataBySql("select * from 学生信息");

	   /* DataTable dt = new DataTable();
            dt.Columns.Add("studentID",typeof(string));    //在dt表中添加数据并指定类型
            dt.Columns.Add("studentName",typeof(string)); 
            dt.Columns.Add("studentSex",typeof(string));
            dt.Columns.Add("studentAge", typeof(int));

            DataRow dr = dt.NewRow();
            dr[0]  =  "2015555"; 
            dr[1]  = "lisi";
            dr[2]  = "男";
            dr[3] = 21;
            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1[0] = "2015556";
            dr1[1] = "zs";
            dr1[2] = "男";
            dr1[3] = 20;
            dt.Rows.Add(dr1);*/
            //    int j = 0;
            //    for (int i = 0; i < dt.Rows.Count; j++)
            //    {
            //        MessageBox.Show(dt.Rows[i][j] + "");
            //        if ((j + 1) ==(dt.Columns.Count))
            //        {
            //            i++;
            //            j = -1;
            //        }
            //    }
            //}

            for (int i = 0; i < ((dt.Rows.Count) * (dt.Columns.Count)); i++)
            {
                MessageBox.Show(dt.Rows[i/(dt.Columns.Count)][i%dt.Columns.Count] + "");
            }
        }

        //    foreach (DataRow i in dt.Rows)
        //    {
        //        foreach(DataColumn j in dt.Columns)
        //        MessageBox.Show(i[j] + "");
        //        //if ((j + 1) % (dt.Columns.Count) == 0)
        //        //{
        //        //    j = 0;
        //        //}
        //        //j++;
        //    }
        //}

        private DataTable GetDataBySql(string sql)
        {
            string connStr = "data source=.;initial catalog=学生成绩管理系统;uid=sa;pwd=31412580jfb";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();

            dataGridView1.DataSource = dt;
            return dt;
        }
    }
}
