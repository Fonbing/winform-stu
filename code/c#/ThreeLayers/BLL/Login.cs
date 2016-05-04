using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class Login
    {
        public static int CheckLogin(string userName, string passWord)
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

        public static DataTable SetCb()  //设置combox1数据
        {
           // DataSet ds = new DataSet();
            DataTable dt = DBHelper.GetDt("select distinct(userName) from Login ");
            //ds.Tables.Add(dt);
            return dt;
        }

        public static DataTable SetDg(string item)  //设置gridview1数据
        {
            DataTable dt = DBHelper.GetDt("select * from Login where userName='" + item + "'");
               return dt;
        }
    }
}
