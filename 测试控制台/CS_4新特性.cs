using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using 测试控制台.辅助;

namespace 测试控制台
{
    public class CS_4新特性
    {
        public static void c()
        {
            ceshi2(new { name = "zs", age = 5 });
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
        public static void ceshi()
        {
            List<ModelStu> lst = DataInfo.GetData();
            //lst.Where("name=@0", "zs");
            lst.Where("name=@0", "张三");
        }

        public static void ceshi2(dynamic dyobj )
        {
           
            dynamic dyobj2 = dyobj;
            dyobj2.pc = 99;
            var cccc = dyobj2.GetType().GetProperty("name").GetValue(dyobj2);
            foreach (var ss in dyobj2.Keys)
            {
                var ii = dyobj2[ss];
            }
            List<ModelStu> lst = DataInfo.GetData();
            //lst.Where("name=@0", "zs");
            lst.Where("name=@0", "张三");
        }
    }

}
