using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiFuSchool.Model;
using YiFuSchool.Tool.DB;

namespace YiFuSchool.Services
{
    public class Cat_MainServices
    {
        #region 初始化

        /// <summary>
        /// 保存存储过程名称或SQL语句的变量
        /// </summary>
        private string sql = string.Empty;

        /// <summary>
        /// 查询条件
        /// </summary>
        private StringBuilder StrWhere = new StringBuilder();

        /// <summary>
        /// 表名
        /// </summary>
        private string SqlDataTable = string.Empty;

        /// <summary>
        /// 需要返回的字段名
        /// </summary>
        private string Fields = string.Empty;

        #endregion

        #region 查询

        /// <summary>
        /// Function Name：查询
        /// Powered By：General_Y
        /// Create Date：
        /// </summary>
        /// <param name="cat_main">【cat_main】实体类</param>
        /// <param name="PageIndex">页数</param>
        /// <param name="PageSize">每页显示的数量</param>
        /// <param name="RecordCount">返回：当前查询条件下的数据量(查询时传入0)</param>
        /// <param name="OrderByStr">排序(字段名 desc/字段名 asc)</param>
        /// <param name="IsLike">true：模糊查询 false：非模糊查询</param>
        /// <returns></returns>
        public List<Cat_Main> SelectAll(Cat_Main cat_main, int PageIndex, int PageSize, ref int RecordCount, string OrderByStr, bool IsLike)
        {
            //取得存储过程名称
            sql = "ProcPage";

            //取得查询条件
            GetSelectWhere(cat_main, IsLike);
            //取得要查询的表名
            SqlDataTable = "cat_main";
            //取得查询需要返回的列
            Fields = "*";
            //取得排序字段
            OrderByStr = "cat_id";

            MySqlParameter p = new MySqlParameter("@dataCount", RecordCount);
            p.MySqlDbType = MySqlDbType.Int32;
            p.Direction = ParameterDirection.InputOutput;

            MySqlParameter[] param = new MySqlParameter[]
            {
                //new MySqlParameter("@PrimaryKey"," Id "),//主键
				new MySqlParameter("@tableName",SqlDataTable),//表名
                new MySqlParameter("@showField",Fields),//需要返回的字段名
                new MySqlParameter("@whereText",StrWhere.ToString() == "" ? " where 1=1 " : (" where " + StrWhere.ToString().Substring(4))),//查询条件
                new MySqlParameter("@orderText",OrderByStr),//排序
                new MySqlParameter("@pageIndex",PageIndex),//页数
                new MySqlParameter("@pageSize",PageSize),//数量
                p
            };
            //List<Cat_Body> List = body.Id == 0 ? GetDataListFill(DBHelper.GetDataSet("select * from cat_body where cat_body_type = 'A' order by cat_body_id limit 50")) : GetDataListFill(DBHelper.GetDataSet("select * from cat_body where cat_body_type = 'A' and cat_body_id=" + body.Id + " order by cat_body_id limit 200"));

            List<Cat_Main> List = GetDataListFill(DBHelper.GetDataSet(sql, CommandType.StoredProcedure, param));

            //取得当前条件下的数据数量
            RecordCount = Convert.ToInt32(p.Value);

            return List;
        }

        #endregion

        #region 取得查询条件

        /// <summary>
        /// 取得查询条件
        /// </summary>
        /// <param name="cat_main">【cat_main】实体类</param>
        /// <param name="IsLike">true：模糊查询 false：非模糊查询</param>
        private void GetSelectWhere(Cat_Main cat_main, bool IsLike)
        {
            //取得公共查询条件

            if (cat_main.cat_parent_ids != null && cat_main.cat_parent_ids != "")
            {
                StrWhere.Append(" and cat_parent_id in (" + cat_main.cat_parent_ids + ")");
            }

            if (cat_main.cat_id != null)
            {
                StrWhere.Append(" and cat_id = '" + cat_main.cat_id.ToString() + "'");
            }
            if (cat_main.cat_thread_id != null)
            {
                StrWhere.Append(" and cat_thread_id = '" + cat_main.cat_thread_id.ToString() + "'");
            }
            if (cat_main.cat_parent_id != null)
            {
                StrWhere.Append(" and cat_parent_id = '" + cat_main.cat_parent_id.ToString() + "'");
            }
            if (cat_main.cat_header_tpl_id != null)
            {
                StrWhere.Append(" and cat_header_tpl_id = '" + cat_main.cat_header_tpl_id.ToString() + "'");
            }
            if (cat_main.cat_footer_tpl_id != null)
            {
                StrWhere.Append(" and cat_footer_tpl_id = '" + cat_main.cat_footer_tpl_id.ToString() + "'");
            }
            if (cat_main.cat_confirm != null)
            {
                StrWhere.Append(" and cat_confirm = '" + cat_main.cat_confirm.ToString() + "'");
            }
            if (cat_main.cat_order != null)
            {
                StrWhere.Append(" and cat_order = '" + cat_main.cat_order.ToString() + "'");
            }
            //判断是模糊查询还是非模糊查询
            if (IsLike)
            {
                if (cat_main.cat_name != null && cat_main.cat_name != "")
                {
                    StrWhere.Append(" and cat_name like '%" + (cat_main.cat_name.Replace("'", "")).Replace(";", "") + "%'");
                }
                if (cat_main.cat_user_type != null && cat_main.cat_user_type != "")
                {
                    StrWhere.Append(" and cat_user_type like '%" + (cat_main.cat_user_type.Replace("'", "")).Replace(";", "") + "%'");
                }
            }
            else
            {
                if (cat_main.cat_name != null && cat_main.cat_name != "")
                {
                    StrWhere.Append(" and cat_name = '" + (cat_main.cat_name.Replace("'", "")).Replace(";", "") + "'");
                }
                if (cat_main.cat_user_type != null && cat_main.cat_user_type != "")
                {
                    StrWhere.Append(" and cat_user_type = '" + (cat_main.cat_user_type.Replace("'", "")).Replace(";", "") + "'");
                }
            }
        }

        #endregion

        #region 填充集合

        /// <summary>
        /// 填充集合
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private List<Cat_Main> GetDataListFill(DataSet ds)
        {
            List<Cat_Main> list = new List<Cat_Main>();

            Cat_Main table = null;

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    table = new Cat_Main();
                    GetDataTableFill(row, table);
                    list.Add(table);
                }
            }

            //释放资源
            sql = string.Empty;
            return list;
        }

        #endregion

        #region 填充表

        /// <summary>
        /// 填充表
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cat_main"></param>
        private void GetDataTableFill(DataRow row, Cat_Main cat_main)
        {
            if (row["cat_id"] != DBNull.Value)
                cat_main.cat_id = Convert.ToInt32(row["cat_id"]);
            if (row["cat_name"] != DBNull.Value)
                cat_main.cat_name = Convert.ToString(row["cat_name"]);
            if (row["cat_thread_id"] != DBNull.Value)
                cat_main.cat_thread_id = Convert.ToInt32(row["cat_thread_id"]);
            if (row["cat_parent_id"] != DBNull.Value)
                cat_main.cat_parent_id = Convert.ToInt32(row["cat_parent_id"]);
            if (row["cat_user_type"] != DBNull.Value)
                cat_main.cat_user_type = Convert.ToString(row["cat_user_type"]);
            if (row["cat_header_tpl_id"] != DBNull.Value)
                cat_main.cat_header_tpl_id = Convert.ToInt32(row["cat_header_tpl_id"]);
            if (row["cat_footer_tpl_id"] != DBNull.Value)
                cat_main.cat_footer_tpl_id = Convert.ToInt32(row["cat_footer_tpl_id"]);
            if (row["cat_confirm"] != DBNull.Value)
                cat_main.cat_confirm = Convert.ToInt32(row["cat_confirm"]);
            if (row["cat_order"] != DBNull.Value)
                cat_main.cat_order = Convert.ToInt32(row["cat_order"]);
        }

        #endregion
    }
}
