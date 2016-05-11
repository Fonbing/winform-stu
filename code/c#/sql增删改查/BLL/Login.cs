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
        public static DataTable CheckSelect(string sqlColumns ,string sqlWhere)
        {
            string cmd = "SELECT " + sqlColumns + " FROM Students WHERE 1=1 ";
            if (sqlWhere != "")
            {
                cmd += "and " + sqlWhere;
            }
            return DBHelper.GetDt(cmd);
        }

        public static int CheckInsert(string sql_ID, string sql_Name, string sql_Class)
        {
            if (sql_ID != "")
            {
                string cmd = "INSERT INTO Students(stuID,stuName,stuClass) VALUES ('" + sql_ID + "','" + sql_Name + "', '" + sql_Class + "')";
                DBHelper.SetDt(cmd);
                return 1;
            }
            else
                return 0;
        }

        public static int CheckDelte(string sql_ID)
        {
            if (sql_ID != "")
            {
                string cmd = "DELETE FROM Students WHERE stuID = '" + sql_ID + "'";
                DBHelper.SetDt(cmd);
                return 1;
            }
            else
                return 0;
        }

        public static int CheckUpdate(string sql_ID, string sql_Name, string sql_Class)
        {
            if (sql_ID != "")
            {
                string cmd = "UPDATE Students SET stuName='" + sql_Name + "',stuClass='" + sql_Class + "' WHERE stuID ='" + sql_ID + "'";
                DBHelper.SetDt(cmd);
                return 1;
            }
            else
                return 0;
        }
    }
}
