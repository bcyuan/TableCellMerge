//=================================================================================
//
//        Copyright (C) bigfeng工作室    
//        All rights reserved
//        filename :字符串操作
//        description : 任何人不得重新反编译或用于任何商业程序或网站。
//   	  本人将保留一切权利予以追究！
//        2018/1/7 17:34:49
//        created by bigfeng at  2018/1/7 17:34:49
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
    public class 字符串操作
    {
        public static void c()
        {
            string ids2 = "";// DotNet.Utilities.CookieHelper.GetCookie("Cookie_TenantID");
            ids2 = ids2.Replace("%7B", "{");//
            ids2 = ids2.Replace("%22", "\"");//
            ids2 = ids2.Replace("%3A", ":");//
            ids2 = ids2.Replace("%2C", ",");//
            ids2 = ids2.Replace("%7D", "}");//
            ids2 = ids2.Replace("%5D", "]");//
            ids2 = ids2.Replace("%5B", "[");//
        }
    }
}
