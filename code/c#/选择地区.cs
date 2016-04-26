using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = GetDataBySql("select ProvinceName from dbo.Data_Province ");
            foreach (DataRow data in dt.Rows)
            {
                comboBox1.Items.Add(data["ProvinceName"]);
            }
            comboBox1.Text = dt.Rows[0]["ProvinceName"] + "";
        }
        private DataTable GetDataBySql(string sql)
        {
            string connStr = "data source=.;initial catalog=Address;uid=sa;pwd=31412580jfb";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count != 0)
                comboBox2.Items.Clear();
            DataTable dt = GetDataBySql
            ("select * from dbo.Data_City,dbo.Data_Province where dbo.Data_City.ProvinceCode=dbo.Data_Province.ProvinceCode and dbo.Data_Province.ProvinceName='" + comboBox1.SelectedItem + "'");
            comboBox2.Text = dt.Rows[0]["CityName"] + "";
            foreach (DataRow data in dt.Rows)
            {
                comboBox2.Items.Add(data["CityName"]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Items.Count != 0)
                comboBox3.Items.Clear();
            DataTable dt = GetDataBySql
           ("select * from dbo.Data_City,dbo.Data_Area where dbo.Data_City.CityCode=dbo.Data_Area.CityCode and dbo.Data_City.CityName='" + comboBox2.SelectedItem + "'");
            comboBox3.Text = dt.Rows[0]["AreaName"] +"";
            foreach (DataRow data in dt.Rows)
            {
                comboBox3.Items.Add(data["AreaName"]);
            }
        }

    }
}
