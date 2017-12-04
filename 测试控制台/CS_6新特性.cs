using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//vs2013不支持c#6
namespace 测试控制台
{
    public class CS_6新特性
    {
        public static void c()
        {
            string a = "张三";
            int age = 20;
            //string info = $"{a}+今年{age}岁了";
            //等价于：string.Format();
            //switch (age)
            //{
            //    case age > 5: a = "张三5岁了";
            //        break;
            //    case age < 5: a = "张三0岁了";
            //        break;
            //    default: a = "张三100岁了";

            //}
        }
    }
}
