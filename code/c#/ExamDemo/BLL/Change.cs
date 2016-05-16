using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Change
    {
        public static int CheckLogin(string userName, string passWord)  //登陆操作
        {
            if (userName == "")       //判断输入是否为空
                return -1;
            else if (passWord == "")
                return -2;
            else
            {
                DataTable dt = DBHelper.GetDt("select * from Login where userName = '" + userName + "'");
                if (dt.Rows.Count == 0)   //判断用户名是否存在
                {
                    return 0;
                }
                else
                {
                    if (dt.Rows[0]["passWord"].ToString() == passWord)  //密码是否正确
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
        }
        public static DataTable Get(string sqlWhere)
        {
            // DataSet ds = new DataSet();

            string strSql = "Select TOP 20 * From Exam Order By NewID() ";
            DataTable dt = DBHelper.GetDt(strSql);
            //ds.Tables.Add(dt);
            //if (sqlWhere != "")
            //{
            //    strSql += "and" + sqlWhere;
            //}
            return dt;
        }
    }
}
