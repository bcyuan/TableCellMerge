using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    class List集合基础操作
    {
        public static void c()
        {
            List<stu> lstu = new List<stu>{
            new stu{id=3,name="zs",age=5,pc=1},
            new stu{id=3,name="zs",age=4,pc=2},
            new stu{id=3,name="zs",age=3,pc=3},
            new stu{id=2,name="ls",age=1,pc=1},
            new stu{id=4,name="ls",age=1,pc=2},
            new stu{id=4,name="ls",age=1,pc=2},
            new stu{id=4,name="lr",age=1,pc=2}
            };
            List<stu> lstugroup = lstu;
            List<stu> lstugroup0101 = lstu;

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
            bool bbh2 = lstu.Exists(s => s.age == 1 && s.id == 5);
            List<string> lsqc = lsa.Distinct().ToList();//一维去重
            List<string> lsqc4 = lstu.Select(p => p.name).Distinct().ToList();//选择name属性并去重
            
            //2,排序，求和
            lsa.Sort();//排序，无返回值；
            lstu = lstu.OrderBy(s => s.id).ThenBy(s => s.age).ToList();// 以id，age排序
            decimal sum = lsint.Sum();//合计,list 必须为int等类型
            decimal sum2 = lstu.Sum(s => s.age);

            // 2 set操作 两个集合：交差并 集合；
            bool bjj = lsa.Intersect(lsb).Count() > 0;//判断是否有交集
            List<string> lsjj = lsa.Intersect(lsb).ToList();//求交集   1,3,9

            List<string> lscj = lsa.Except(lsb).ToList();//求相对差集  相对las得2,6 
            List<string> lsbj2 = lsa.Union(lsc).ToList();//求并集（并保留重复项） 1,2,3,6,9,9,1,3,5,7,9
            List<string> lsbj1 = lsa.Union(lsb).ToList();//求并集（并剔除重复项）  1,2,3,5,6,7,9

            lstu = lstu.Skip(2).Take(3).ToList(); //从第二项开始取3个项目；System.Linq.Enumerable
            stu t = lstu.Find(s => s.id > 2);
            lstu = lstu.Where(s => s.id > 2).ToList();

            //3 group by
            var ab2 = (from p in lstugroup group p by p.name into g select new { name = g.Key }).ToList();//单属性distinct
            var ab3 = (from p in lstugroup group p by new { p.name, p.age } into g select new { name = g.Key }).ToList();//多属性distinct

            //4 过滤
            List<stu> ab4 = lstugroup.GroupBy(p => p.id).Select(p => new stu { id = p.Key, name = p.FirstOrDefault().name }).ToList();//单属性distinct并默认其他属性

            // 5 linq where findAll 的比较_形式
            List<stu> ab5 = (from i in lstugroup where i.id > 3 select i).ToList();
            List<stu> ab6 = lstugroup.Where(s => s.id > 3).ToList();
            List<stu> ab7 = lstugroup.FindAll(s => s.id > 3);//直接返回该对象，不需要toList()

            // 6 linq where findAll 的比较_性能  》数据比较功能 where≈findAll > linq
            List<stu> stuceshi = new List<stu>();
            for (int i = 0; i < 100000; i++)
            {
                stuceshi.Add(new stu { id = i, name = "name" + i, age = i, mm = "zs" });
            }
            //10w次比对数据
            //List<stu> ab8 = (from i in stuceshi where i.mm =="zs" select i).ToList();//11.1742ms
            //List<stu> ab9 = lstugroup.Where(s => s.mm == "zs").ToList();//0.3283ms
            //List<stu> ab10 = lstugroup.FindAll(s => s.mm == "zs");//0.3225ms
            // 8千DM_DORM对象筛选 三者性能略同
            string name1;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {

                //name1 = stuceshi.Find(s => s.id == 99999) == null ? "" : stuceshi.Find(s => s.id == 99999).name;
                //stuceshi = stuceshi.Where(s => s.name == "").ToList();
                stuceshi = stuceshi.Where(s => s.name.Length == 0).ToList();
            }
            sw.Stop();
            string ts2 = sw.Elapsed.TotalMilliseconds.ToString();

            // 7 处理find异常.大量数据时，自己处理异常效率是try catch的6倍；
            string name3 = lstu.Find(s => s.id == 8) == null ? "" : lstu.Find(s => s.id == 8).name;
            //string name1 = stuceshi.Find(s => s.id == -1) == null ? "" : stuceshi.Find(s => s.id == -1).name;  //3.9594
            //string name1 = stuceshi.Find(s => s.id == 99999) == null ? "" : stuceshi.Find(s => s.id == 99999).name;  //7.0533
            #region try catch情况 18403
            //for (int i = 0; i > -1000; i--)  // 18403.0000
            //{
            //    try //22.5663
            //    {
            //        name1 = stuceshi.Find(s => s.id == -1).name;
            //    }
            //    catch (Exception)
            //    {

            //        name1 = "";
            //    }
            //}
            #endregion
            #region 自处理情况 3250
            //for (int i = 0; i > -1000; i--) 时间0.3274~8490.0000(全比较是8490)
            //{
            //    name1 = stuceshi.Find(s => s.id == 99999) == null ? "" : stuceshi.Find(s => s.id == 99999).name;
            //}
            #endregion

            // 8双问号操作符
            // string strParam= Request.Params["param"]?? "";
            int? cc = null;
            int name4 = cc ?? 0;

            // 9 StartsWith()
            lstugroup = lstugroup.Where(s => s.name.StartsWith("l")).ToList(); // 筛选name以l开头；
            //lstugroup =lstugroup.Where(s => s.name.StartsWith("l")).

            //10 遍历集合
            int ii = 0;
            foreach (stu item in lstugroup)
            {
                ii = lstugroup.IndexOf(item);
            }

            //11 处理Where,找不到是count=0而不报错。
            lstugroup = lstugroup.Where(s => s.name.StartsWith("m")).ToList(); // 筛选name以l开头；

            //12

            var g2 = lstugroup0101.GroupBy(x => x.id);

           //lstugroup0101= g2.Where(v => v.Key ==3).ToList();
            List<stu> dddd=new List<stu>();
            foreach (var item in g2)
            {
                foreach (var item2 in item)
                {
                    dddd.Add(item2);
                }
            }

        }//断点处
    }
    public class stu
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int pc { get; set; }
        public string mm { get; set; }
    }
}
