using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ResultManager
    {
        public static List<Result> resList = new List<Result>();

        public static void InitialReslist()
        {
            for (int i = 0; i < 20; i++)
            {
                resList.Add(new Result());
            }
        }
        public static void UpdateAt(int index, Result res)
        {
            resList.RemoveAt(index);
            resList.Insert(index, res);
        }

    }
}
