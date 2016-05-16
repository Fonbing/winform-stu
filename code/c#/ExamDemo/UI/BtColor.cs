using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BtColor
    {
        public static Color select;
        public static Color noFin;
        public static Color finish;

        public static void initialBtColor()
        {
            BtColor.select = Color.Yellow;     //初始化按钮的各种颜色
            BtColor.noFin = Color.Red;
            BtColor.finish = Color.Blue;
        }
    }
}
