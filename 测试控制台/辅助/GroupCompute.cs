using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台.辅助
{
    public class GroupCompute
    {

        public static void c()
        {
            List<ModelStu> list = DataInfo.GetData();
            var cc = list.GroupBy(s => s.age).ToList();
            list = ListGroup<ModelStu>(list,  "name" , new List<string> { "pc" }, "avg");
        }



        public static List<T> ListGroup<T>(List<T> list, string itemGroup, List<string> lstValue, string method)
        {
            Type type = typeof(T);
            //var lstValue = new List<string>();
            var allValue = new List<string>();//所有属性名称
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo item in properties)
            {
                allValue.Add(item.Name);
            }
            //lstValue = allValue.Except(noList).ToList();
            // lstValue.Remove(groupItem);
            //noList.Add(groupItem);
            List<T> listNew = new List<T>();

            var g = list.GroupBy(s => s.GetType().GetProperty(itemGroup).GetValue(s));

            foreach (var item in g)
            {
                List<T> listPre = new List<T>();
                foreach (var item2 in item)
                {
                    listPre.Add(item2);
                }//新的一组
                var tmpClass = (T)Activator.CreateInstance(typeof(T), new object[] { });
                foreach (var value in allValue)
                {
                    if (itemGroup == value)
                    {
                        //var tmp = tmpClass.GetType().GetProperty(value).GetValue(tmpClass);
                        tmpClass.GetType().GetProperty(value).SetValue(tmpClass, item.Key);
                    }
                    else if (lstValue.Contains(value))
                    {
                        if (method == "avg")
                        {
                            var avg = listPre.Average(m => Convert.ToDouble(m.GetType().GetProperty(value).GetValue(m)));
                            tmpClass.GetType().GetProperty(value).SetValue(tmpClass, avg);
                        }

                    }

                }
                listPre.Add(tmpClass);
                listNew.AddRange(listPre);
            }

            return list;
        }
    }
}
