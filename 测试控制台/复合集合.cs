using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
   public class 复合集合
    {
        public static void c()
        {
             List<dorm> lstDorm1 =new List<dorm>
            {
                new dorm(){id=1,name="zs",score=1},
                new dorm(){id=1,name="zs",score=2},
                new dorm(){id=1,name="zs",score=3}
            };

             List<dorm> lstDorm2 = new List<dorm>
            {
                new dorm{id=1,name="zs",score=3},
                new dorm{id=1,name="zs",score=4},
                new dorm{id=1,name="zs",score=5}
            };
            List<build> lstB = new List<build>()
            {
                new build{id=1,name="b",lstDorm=lstDorm1},
                new build{id=1,name="b",lstDorm=lstDorm2}
            };
            int sumScore = lstB.Sum(s => s.lstDorm.Sum(j => j.score));//复合集合sum求和；
            double avgScore = lstB.Average(s => s.lstDorm.Average(j => j.score));//复合集合avg求平均数；
        }
    }

    public class build
    {
        public string name { get; set; }
        public List<dorm> lstDorm { get; set; }
        public int id { get; set; }
    }
    public class dorm
    {
        public int id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
    }
}
