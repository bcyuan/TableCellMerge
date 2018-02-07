using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 测试控制台.辅助;

namespace 测试控制台
{
    public class DataInfo
    {

        //
        private static ConcurrentQueue<Product2> products = new ConcurrentQueue<Product2>();
        private static List<ModelStu> lstu = new List<ModelStu>();
        private static ModelStu modelStu = new ModelStu();
        public static List<ModelStu> GetData()
        {
            lstu = new List<ModelStu>{
            new ModelStu{id=1,age=1,name="zs",pc=1},
            new ModelStu{id=2,age=1,name="zs",pc=2},
            new ModelStu{id=3,age=3,name="zs",pc=3},
            new ModelStu{id=4,age=3,name="ls",pc=1},
            new ModelStu{id=5,age=5,name="ls",pc=2},
            new ModelStu{id=6,age=5,name="ls",pc=2},
            new ModelStu{id=7,age=10,name="lr",pc=2}
            };
            return lstu;
        }
        public static List<ModelStu> GetData1K()
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                modelStu = new ModelStu { id = i, age = i, name = "zs" + i, pc = i };
                lstu.Add(modelStu);
            }
            sw.Stop();
           // Console.WriteLine("采用for 耗时:{0}", sw.ElapsedMilliseconds);

            //sw.Restart();
            //Parallel.For(0,1000,(num)=>
            //{
            //    products.Enqueue(new Product2() { Category = "Category" + num, Name = "Name" + num, SellPrice = num });
            //});
            //sw.Stop();
           // Console.WriteLine("采用Linq 耗时:{0}", sw.ElapsedMilliseconds);
           
            return lstu;
            
        }
    }
}
