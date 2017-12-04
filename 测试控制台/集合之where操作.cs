using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    public class 集合之where操作
    {
        public static void c()
        {
            List<stu> lstu = new List<stu>{
                new stu{id=1,name="zs",age=5,pc=1},
                new stu{id=2,name="zs",age=4,pc=2},
                new stu{id=3,name="zs",age=3,pc=3},
                new stu{id=4,name="ls",age=6,pc=1},
                new stu{id=5,name="ls",age=1,pc=2},
                new stu{id=6,name="ls",age=1,pc=2},
                new stu{id=7,name="lr",age=1,pc=2}
            };
            string value = "";
            //小技巧：比如在可能联动时，value值有无不确定，则可以如下：
            lstu = lstu.Where(s => s.age > 1 && (string.IsNullOrEmpty(value) || Convert.ToInt32(value) > s.pc)).ToList();
        }
    }
}
