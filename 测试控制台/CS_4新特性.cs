using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    public class CS_4新特性
    {
        public static void c()
        {
            Show();//可选参数
            Show(msg: "lzf",age:"20");//命名参数
            Console.ReadKey();
        }

        public static void Show(string msg = "mr", string age = "18")
        {
            Console.WriteLine(msg + "~" + age);
        }
        public static void Show2()
        {
            dynamic person = new ExpandoObject();
            person.Name = "cary";
            person.Age = 25;
            person.ShowDescription = new Func<string>(() => person.Name + person.Age);
            Console.WriteLine(person.Name + person.Age + person.ShowDescription());      
        }
    }

}
