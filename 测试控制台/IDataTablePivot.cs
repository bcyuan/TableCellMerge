using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    interface IDataTablePivot
    {
        DataTable DataTablePivot(DataTable dt, List<string> DimensionList, string DynamicColumn, string DataColumn, out List<string> AllDynamicColumn);
    }
}
