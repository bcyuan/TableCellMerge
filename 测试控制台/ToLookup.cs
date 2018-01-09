//=================================================================================
//
//        Copyright (C) bigfeng工作室    
//        All rights reserved
//        filename :ToLookup
//        description : 任何人不得重新反编译或用于任何商业程序或网站。
//   	  本人将保留一切权利予以追究！
//        2018/1/9 21:49:43
//        created by bigfeng at  2018/1/9 21:49:43
//        新浪微博：weibo.com/xihushui
//
//==================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    public class ToLookup
    {
    }
    public sealed class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }


        public override string ToString()
        {
            return string.Format("[{0}: {1} - {2}]", Id, Category, Value);
        }
        public static List<Product> GetList0()
        {
            var products = new List<Product>
                               {
                                   new Product {Id = 1, Category = "Electronics", Value = 15.0},
                                   new Product {Id = 2, Category = "Groceries", Value = 40.0},
                                   new Product {Id = 3, Category = "Garden", Value = 210.3},
                                   new Product {Id = 4, Category = "Pets", Value = 2.1},
                                   new Product {Id = 5, Category = "Electronics", Value = 19.95},
                                   new Product {Id = 6, Category = "Pets", Value = 21.25},
                                   new Product {Id = 7, Category = "Pets", Value = 5.50},
                                   new Product {Id = 8, Category = "Garden", Value = 13.0},
                                   new Product {Id = 9, Category = "Automotive", Value = 10.0},
                                   new Product {Id = 10, Category = "Electronics", Value = 250.0},
                               };
            return products;
        }

        public static void GetList()
        {
            List<Product> products = GetList0();
            var groups = products.GroupBy(p => p.Category);
            var groups2 = products.ToLookup(p => p.Category);
            //删除所有属于Garden的产品
            products.RemoveAll(p => p.Category == "Garden");

            foreach (var group in groups)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("\t" + item);
                }
            }
        }


    }
}
