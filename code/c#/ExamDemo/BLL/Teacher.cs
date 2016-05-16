using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Teacher
    {
        public void DoWork()
        {
            int s = 0;
            foreach (Result r in ResultManager.resList)
            {
                s = s + r.OResult;
            }
            StreamWriter sw = new StreamWriter("考生答题信息.txt", false);
            // sw.WriteLine(resList[0].TopID);
            sw.WriteLine("考生答案：");
            for (int i = 0; i < 20; i++)
            {
                // MessageBox.Show(resList[i].TopKey.ToString());
                sw.WriteLine((i + 1) + "、  " + ResultManager.resList[i].TopKey + "     得分：" + ResultManager.resList[i].OResult);
            }
            sw.WriteLine("考生总成绩为：" + s + "分");
            sw.Close();
        }
    }
}
