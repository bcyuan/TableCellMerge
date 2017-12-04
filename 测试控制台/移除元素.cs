using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    public class 移除元素
    {
        public void c()
        {
            string bu = "8177,-1,289327,289328,289329,289330,289331,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1";

            //移除某个元素 方法一
            string[] arrkey = bu.Split(',');
            string tmp = string.Empty;
            for (int i = 0; i < arrkey.Length; i++)
            {
                if (arrkey[i] != "-1")
                {
                    tmp += arrkey[i] + ",";
                }
            }
            tmp = tmp.TrimEnd(',');//8177,289327,289328,289329,289330,289331

            //移除某个元素 方法二    linq表达式
            List<string> la = bu.Split(',').ToList();
            var newArr2 = from i in la where i != "-1" select i;
            tmp = string.Join(",", newArr2);//8177,289327,289328,289329,289330,289331

            //移除某个元素 方法三    委托
            List<string> la2 = bu.Split(',').ToList();
            la2.RemoveAll(n => n == "-1");
            tmp = string.Join(",", la2);//8177,289327,289328,289329,289330,289331

            //总结
            // Predicate<T>委托
            //方法：RemoveAll(Predicate<T> match);//参数是泛型委托
            //用法：la2.RemoveAll(n => bool表达式)
        }

    }
}
