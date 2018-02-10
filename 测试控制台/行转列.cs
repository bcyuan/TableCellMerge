using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 测试控制台;
using 测试控制台.辅助;

namespace DataTable_RowToColumn
{
    public class 行转列
    {
        public static void c()
        {
            //row["Name"] = "张三";
            //row["Month"] = "2016-01";
            //row["Area"] = "江夏区";
            //row["DfMoney"] = 1;

            DataTable dt = InitTable();
            List<string> DataColumn = new List<string>() { "DfMoney" };
            string DynamicColumn = "Month";
            List<string> AllDynamicColumn = null;
            //DataTablePivotOne dp1 = new DataTablePivotOne();
            //DataTable dtResult = new DataTablePivotOne().DataTablePivot(dt, DimensionList, DynamicColumn, DataColumn, out AllDynamicColumn);

            #region DataTable行转列1
            DataTable dtResult = RowToColumn(dt, DataColumn, DynamicColumn, out AllDynamicColumn);
            #endregion

            #region List集合行转列（dynamiclinq）
            List<string> DimensionList = new List<string> { "Name","Area" };
            AllDynamicColumn = null;
            IList<money> list = ModelConvertHelper<money>.DataTableToList(dt);//先转集合
            List<dynamic> dlist = DynamicLinqDemo.DynamicLinq<money>(list.ToList(), DimensionList, "Month",out AllDynamicColumn);
           //var dlistC= dlist.ToList();
            //dlist.OrderBy(s=>s.Name).ToList();
            var gArea = dlist.GroupBy(s => s.Area);
            List<dynamic> dlistNew = new List<dynamic>();
            foreach (var itemArea in gArea)
            {
                dlistNew.Add(itemArea);
            }
            //var G
            //dlistNew.Add(itemArea);
            #endregion
            Console.WriteLine(JsonConvert.SerializeObject(dtResult, Formatting.Indented));
            Console.Read();
        }

        // 本方法改造与2018年2月7日 ，可用

        /// <summary>
        /// 动态Linq方式实现行转列
        /// </summary>
        /// <param name="list">数据</param>
        /// <param name="DataList">数据名列</param>
        /// <param name="DynamicColumn">动态列</param>
        /// <returns>行转列后数据</returns>
        public static DataTable RowToColumn(DataTable dt, List<string> DataList, string DynamicColumn, out List<string> AllDynamicColumn)
        {
            //所有列
            List<string> AllColumn = new List<string>();
            foreach (DataColumn dc in dt.Columns)
            {
                AllColumn.Add(dc.ColumnName);
            }
            //维度列 （所有列-数据列）
            List<string> DimensionList = new List<string>();
            DimensionList = AllColumn.Except(DataList).ToList();
            DimensionList.Remove(DynamicColumn);
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
                if (DataList.Contains(item.ColumnName))
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



        private static DataTable InitTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Area", typeof(int));
            dt.Columns.Add("Month", typeof(string));
            dt.Columns.Add("SEX", typeof(string));
            dt.Columns.Add("DfMoney", typeof(double));


            DataRow row = dt.NewRow();
            row["Name"] = "张三";
            row["Month"] = "2016-01";
            row["Area"] = 55;
            row["SEX"] = "男";
            row["DfMoney"] = 1;

            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "张三";
            row["Month"] = "2016-02";
            row["Area"] = 55;
            row["SEX"] = "男";
            row["DfMoney"] = 2;

            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "小燕子";
            row["Month"] = "2016-01";
            row["Area"] = 55;
            row["SEX"] = "女";
            row["DfMoney"] = 3;

            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "小燕子";
            row["Month"] = "2016-02";
            row["Area"] = 55;
            row["SEX"] = "女";
            row["DfMoney"] = 4;

            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "李四";
            row["Month"] = "2016-01";
            row["Area"] = 66;
            row["SEX"] = "男";
            row["DfMoney"] = 5;

            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "李四";
            row["Month"] = "2016-02";
            row["Area"] = 66;
            row["SEX"] = "男";
            row["DfMoney"] = 6;

            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "尔康";
            row["Month"] = "2016-01";
            row["Area"] = 66;
            row["SEX"] = "男";
            row["DfMoney"] = 7;

            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "尔康";
            row["Month"] = "2016-02";
            row["Area"] = 66;
            row["SEX"] = "男";
            row["DfMoney"] = 8;

            dt.Rows.Add(row);
            return dt;
        }
    }
    public class money
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public string Month { get; set; }
        public string SEX { get; set; }
        public int DfMoney { get; set; }
    }
}