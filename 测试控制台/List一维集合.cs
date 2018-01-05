using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    class List一维集合
    {
        public static void c()
        {
            string a = "1,3,2,6,9,9";
            string b = "1,3,5,7,9";
            string c = "1,3,5,7,9,7";
            string d = "1,2,3,4,5,6";

            List<string> lsa = a.Split(',').ToList();//数组转ToList集合（using System.Linq;）
            List<string> lsb = b.Split(',').ToList();
            List<string> lsc = c.Split(',').ToList();
            List<string> lsd = d.Split(',').ToList();
            List<string> lsstr = new List<string>() { "qq", "weibo", "zhihu" };
            List<int> lsint = new List<int>() { 1, 2, 5 };
            // 1 单个集合
            bool bbh = lsa.Contains("2");//是否包含
            List<string> lsqc = lsa.Distinct().ToList();//一维去重
            
            //2,排序，求和
            lsa.Sort();//排序，无返回值；
            decimal sum = lsint.Sum();//合计,list 必须为int等类型


            // 2 set操作 两个集合：交差并 集合；
            bool bjj = lsa.Intersect(lsb).Count() > 0;//判断是否有交集
            List<string> lsjj = lsa.Intersect(lsb).ToList();//求交集   1,3,9

            List<string> lscj = lsa.Except(lsb).ToList();//求相对差集  相对las得2,6 
            List<string> lsbj2 = lsa.Union(lsc).ToList();//求并集（并保留重复项） 1,2,3,6,9,9,1,3,5,7,9
            List<string> lsbj1 = lsa.Union(lsb).ToList();//求并集（并剔除重复项）  1,2,3,5,6,7,9

           

        }//断点处
    }
    
}
