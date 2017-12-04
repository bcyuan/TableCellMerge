using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    public class Linq总结
    {
        public static void c()
        {
            List<xs> lsxs = new List<xs>{
            new xs{id=1,name=null,age=5,sc_id=1},
            new xs{id=2,name="zs",age=4,sc_id=2},
            new xs{id=3,name="zs",age=3,sc_id=3},
            new xs{id=4,name="ls",age=1,sc_id=1},
            new xs{id=5,name="ls",age=1,sc_id=2},
            new xs{id=6,name="ls",age=1,sc_id=6}
            };
            List<xx> lsxx = new List<xx>{
            new xx{id=1,name=null,age=5,pc=1},
            new xx{id=2,name="we2",age=4,pc=2},
            new xx{id=3,name="we3",age=3,pc=3},
            new xx{id=4,name="mz1",age=5,pc=1},
            new xx{id=5,name="mz2",age=4,pc=2},
            new xx{id=6,name="mz3",age=3,pc=2}
            };

            // 1,linq 之 join
            var c = (from a in lsxs from b in lsxx where a.id==1 && a.sc_id == b.id select new {a.id,a.name,xname=b.name }).ToList();
            int ina = c[0].id;
            string stra = c[0].name;//若name为null也不抛常；stra结果也是null,很是合理

            int c2 = lsxx.Sum(s => s.id);







        }//dd

    }
    public class xs
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int sc_id { get; set; }
        public string mm { get; set; }
    }
    public class xx
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int pc { get; set; }
        public string mm { get; set; }
    }
}
