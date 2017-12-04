using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    public class 单类型集合
    {
        public static void c()
        {
            string strTmp = "50,60,61,100,9";
            List<string> lsStr = strTmp.Split(',').ToList();
            lsStr.Sort();//排序结果：100,50,60,61,9  依次比较每个对象的第一位...数值大小
        }
    }
}
