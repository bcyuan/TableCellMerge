using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 测试控制台.辅助;

namespace 测试控制台
{
    class List集合基础操作2
    {
        public static void c()
        {
            List<ModelStu> lstu = new List<ModelStu>{
            new ModelStu{id=1,age=1,name="zs",pc=1},
            new ModelStu{id=2,age=1,name="zs",pc=2},
            new ModelStu{id=3,age=3,name="zs",pc=3},
            new ModelStu{id=4,age=3,name="ls",pc=1},
            new ModelStu{id=5,age=5,name="ls",pc=2},
            new ModelStu{id=6,age=5,name="ls",pc=2},
            new ModelStu{id=7,age=5,name="lr",pc=2}
            };
            #region init数据
            List<ModelStu> lstu1 = lstu;
            List<ModelStu> lstuNull = lstu;
            List<ModelStu> lstu3 = lstu;
            List<ModelStu> lstu4 = lstu;
            #endregion

            #region 分组
            var g1 = lstu1.GroupBy(x => x.age);
            foreach (var item in g1)
            {
                // Console.WriteLine("按此分组" + item.Key);
                foreach (var item2 in item)
                {
                    //    Console.WriteLine("名称" + item2.name);
                }
            }
            foreach (var item in g1)
            {
                List<ModelStu> lstTmp = new List<ModelStu>();
                foreach (var item2 in item)
                {
                    lstTmp.Add(item2);
                }
            }
            #endregion

            #region zip：分配座位
            var employees = new List<Employee>  
                    {  
                         new Employee { Id = 13, Name = "John Doe", Salary = 13482.50 },  
                         new Employee { Id = 42, Name = "Sue Smith", Salary = 98234.13 },  
                         new Employee { Id = 99, Name = "Jane Doe", Salary = 32421.12 }  
                    };
            var seats = new List<Seat>  
                 {  
                     new Seat { Id = 1, Cost = 42 },  
                     new Seat { Id = 2, Cost = 42 },  
                     new Seat { Id = 3, Cost = 100 },  
                     new Seat { Id = 4, Cost = 100 },  
                     new Seat { Id = 5, Cost = 125 },  
                     new Seat { Id = 6, Cost = 125 },  
                 };
            var seatingAssignments = employees.Zip(seats, (e, s) => new { EmployeeId = e.Id, SeatId = s.Id });
            foreach (var seat in seatingAssignments)
            {
                Console.WriteLine("雇员: " + seat.EmployeeId + " 预约了座位 " + seat.SeatId);

            }
            #endregion

            #region groupjoin ：联合分组
            var badges = new List<Badge>  
                {  
                    new Badge { EmployeeId = 10, BadgeNumber = 1 },  
                    new Badge { EmployeeId = 13, BadgeNumber = 2 },  
                    new Badge { EmployeeId = 20, BadgeNumber = 3 },  
                    new Badge { EmployeeId = 25, BadgeNumber = 4 },  
                    new Badge { EmployeeId = 42, BadgeNumber = 5 },  
                    new Badge { EmployeeId = 10, BadgeNumber = 6 },  
                    new Badge { EmployeeId = 13, BadgeNumber = 7 },  
                };
            var badgeAssignments = employees.GroupJoin(badges, e => e.Id, b => b.EmployeeId,(e, bList) => new { Name = e.Name, Badges = bList.ToList() });
            #endregion

            #region Lsit判断null
            lstuNull = null;
            //lstuNull = lstuNull.FindAll(s => s.name == ""); 报错
            //lstuNull = lstuNull.Where(s => s.name == "").ToList(); 报错

            //总结：list 进行linq查询前和取查询结果后的属性值前都要判断null
            #endregion

            // Console.ReadKey();
        }//断点处
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
    public class Seat
    {
        public int Id { get; set; }
        public double Cost { get; set; }
    }
    public class Badge
    {
        public int EmployeeId { get; set; }
        public int BadgeNumber { get; set; }
    }
}
