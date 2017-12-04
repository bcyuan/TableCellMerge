using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;//Newtonsoft.Json

namespace 测试控制台
{
    public class json类
    {
        public static void getcc()
        {
            List<stu> lstu = new List<stu>{
            new stu{id=1,name="zs",age=5,pc=1},
            new stu{id=3,name="zs",age=4,pc=2},
            new stu{id=3,name="zs",age=3,pc=3},
            new stu{id=2,name="ls",age=1,pc=1},
            new stu{id=4,name="ls",age=1,pc=2},
            new stu{id=4,name="ls",age=1,pc=2},
            new stu{id=4,name="lr",age=1,pc=2}
            };
            stu objstu = new stu { id = 1, name = "zs", age = 5, pc = 1 };
            // 1,将对象序列化为json格式
            string c = JsonConvert.SerializeObject(objstu);
            string c2 = JsonConvert.SerializeObject(lstu);

            // 2,将json格式字符串转为对象
            JsonSerializer jse = new JsonSerializer();
            StringReader sr = new StringReader(c2);
            object o = jse.Deserialize(new JsonTextReader(sr), typeof(List<stu>));
        }
    }
}
