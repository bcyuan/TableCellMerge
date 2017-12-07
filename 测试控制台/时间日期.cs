using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    public static class 时间日期
    {
        public static void c()
        {
            string year = "2013";
            string month = "12";
            string day = "07";
            /*能否转换
             Convert.ToDateTime("2017-12-07");  是
             Convert.ToDateTime("2017/12/07");  是
             Convert.ToDateTime("2017.12.07");  是
             Convert.ToDateTime("20171207");    否
             DateTime.ParseExact("20170405", "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);是
             */
            var dd0 = Convert.ToDateTime("2017-12-07");
            dd0 = Convert.ToDateTime("2017/12/07");
            dd0 = Convert.ToDateTime("2017.12.07");
            dd0 = DateTime.ParseExact("20170405", "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            dd0 = DateTime.ParseExact(year, "yyyy", System.Globalization.CultureInfo.CurrentCulture);
           bool cc= Convert.ToDateTime(int.Parse(year)+3+"-07-01")<DateTime.UtcNow;
             
        }
    }
}
