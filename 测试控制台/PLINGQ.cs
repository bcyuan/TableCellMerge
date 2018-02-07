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
    class PLINGQ
    {
        public static void c()
        {
            Stopwatch sw = new Stopwatch();
            List<ModelStu> lstStu = DataInfo.GetData1K();
            List<ModelStu> lstStu2 = lstStu;
            //ConcurrentQueue<Product2> products = new ConcurrentQueue<Product2>();
            /*向集合中添加多条数据*/
            sw.Restart();
            lstStu.AsParallel().ForAll(m=>
            {
                m.name = m.name+"...";
            });
            sw.Stop();
            Console.WriteLine("ForAll():" + sw.ElapsedMilliseconds);
            sw.Restart();
            lstStu2.ForEach(s => s.name = s.name + "...");
            sw.Stop();
            Console.WriteLine("ForEach():"+sw.ElapsedMilliseconds);


            Console.ReadLine();
            // Console.ReadKey();
        }//断点处
        
    }
    class Product2
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int SellPrice { get; set; }
    }
}
