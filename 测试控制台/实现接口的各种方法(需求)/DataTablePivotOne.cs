using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试控制台
{
    public class DataTablePivotOne : IDataTablePivot
    {
        public DataTable DataTablePivot(DataTable dt, List<string> DimensionList, string DynamicColumn, string DataColumn, out List<string> AllDynamicColumn)
        {
            //获取所有动态列
            AllDynamicColumn = new List<string>();
            foreach (DataRow dr in dt.DefaultView.ToTable(true, DynamicColumn).Rows)
            {
                if (dr[DynamicColumn] != null && !string.IsNullOrEmpty(dr[DynamicColumn].ToString()))
                {
                    AllDynamicColumn.Add(dr[DynamicColumn].ToString());
                }
            }

            //数值列
            Dictionary<string, Type> AllNumberColumn = new Dictionary<string, Type>();
            foreach (DataColumn item in dt.Columns)
            {
                //if (item.DataType == typeof(int) || item.DataType == typeof(double) || item.DataType == typeof(float))
                //{
                //    AllNumberColumn.Add(item.ColumnName, item.DataType);
                //}
                if (item.ColumnName == DataColumn)
                {
                    AllNumberColumn.Add(item.ColumnName, item.DataType);
                }
            }

            //结果DataTable创建
            DataTable dtResult = new DataTable();
            foreach (var item in DimensionList)
            {
                dtResult.Columns.Add(item, typeof(string));
            }
            //动态列
            foreach (var dynamicValue in AllDynamicColumn)
            {
                foreach (var item in AllNumberColumn.Keys)
                {
                    dtResult.Columns.Add(item + dynamicValue, AllNumberColumn[item]);
                }
            }

            //分组
            var dtGroup = dt.DefaultView.ToTable(true, DimensionList.ToArray());
            foreach (DataRow dr in dtGroup.Rows)
            {
                DataRow drReult = dtResult.NewRow();
                string filter = "";
                foreach (var key in DimensionList)
                {
                    drReult[key] = dr[key];
                    filter += key + "='" + dr[key] + "' AND ";
                }
                string dynamicFilter = "";
                foreach (var dynamicValue in AllDynamicColumn)
                {
                    dynamicFilter = DynamicColumn + "='" + dynamicValue + "'";
                    foreach (var numColumn in AllNumberColumn.Keys)
                    {
                        drReult[numColumn + dynamicValue] = dt.Compute("sum(" + numColumn + ")", filter + dynamicFilter);
                    }
                }
                dtResult.Rows.Add(drReult);
            }

            return dtResult;
        }
    }
}
