using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
   public class TryCatch
    {
       public static void c()
       {
           try
           {
               int c = int.Parse("y");
               Console.WriteLine("1");
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {

           }
           Console.WriteLine("1");

           
       }
    }
}
