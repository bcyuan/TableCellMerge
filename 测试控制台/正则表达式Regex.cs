using System.Text.RegularExpressions;
namespace 测试控制台
{
    class 正则表达式
    {
        public static void c()
        {
            string str0 = "2/";
            string par_str0 = @"^(" + str0 + ")";
            string str = "666";
            string str3 = "101，102，103,104$";
            string par = @"\d{3,4}";
            string par3 = @"[，]";
            string par4 = @"\d+";
            // 一，常用方法：  
            //1.IsMatch判断是否为（3到4位的数字）  
            bool b = Regex.IsMatch(str, par);
            bool ceshi = Regex.IsMatch("2/1/3", par_str0);
            //2.Matches可计算匹配到的个数  
            int i3 = Regex.Matches(str3, par3).Count;
            //3.Match 返回第一个匹配项  
            string s4 = Regex.Match(str3, par4).Value;//或者Regex.Match(str3, par4).ToString();  
            // 二，RegEx类的实例  
            // 1,替换  
            string c = Regex.Replace("1人做事1人当", @"\d", "2");
            // str.Replace("\", "\\")用于简单的替换  
            string s20 = "1人做事1人当";
            string s21 = s20.Replace("1", "2");
            // 2，取值 利用小括号()分组  
            string line = "lane=1;speed=30.3mph;speed=32.2m/s;acceleration=2.5mph/s";
            MatchCollection matches = Regex.Matches(line, @"speed=([\d\.]+)(m/s|mph)");
            string a1 = matches[0].Groups[1].Value;//30.3  
            string a2 = matches[0].Groups[2].Value;//mph  
            string b1 = matches[1].Groups[1].Value;//32.2  
            string b2 = matches[1].Groups[2].Value;//m/s  
        }
    }
}