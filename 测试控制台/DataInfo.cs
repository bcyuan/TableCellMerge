//=================================================================================
//
//        Copyright (C) bigfeng工作室    
//        All rights reserved
//        filename :DataInfo
//        description : 任何人不得重新反编译或用于任何商业程序或网站。
//   	  本人将保留一切权利予以追究！
//        2018/1/10 21:38:30
//        created by bigfeng at  2018/1/10 21:38:30
//        新浪微博：weibo.com/xihushui
//
//==================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 测试控制台.辅助;

namespace 测试控制台
{
    public class DataInfo
    {
        internal static List<ModelStu> GetData()
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
            return lstu;
        }
    }
}
