using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiFuSchool.Model;
using YiFuSchool.Tool.DB;

namespace YiFuSchool.Services
{
    public class Cat_BodyServices
    {
        #region 初始化

        private string _Status;

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

        public Cat_BodyServices()
        {
            _Status = "1";
        }

        public string Status
        {
            get { return _Status; }
        }

        #endregion

        #region 新增

        /// <summary>
        /// Function Name：新增
        /// Powered By：General_Y
        /// Create Date：
        /// </summary>
        /// <param name="cat_body">【cat_body】实体类</param>
        /// <returns></returns>
        public int Add(Cat_Body cat_body)
        {
            //组装SQL语句
            sql = "insert into cat_body(cat_id,cat_body_title,cat_body_author,cat_body_type,cat_body_url,cat_body_keyword,cat_body_content,cat_body_indate,cat_body_outdate,cat_body_click,cat_body_recommend,cat_body_confirm,cat_body_icon) values(@cat_id,@cat_body_title,@cat_body_author,@cat_body_type,@cat_body_url,@cat_body_keyword,@cat_body_content,@cat_body_indate,@cat_body_outdate,@cat_body_click,@cat_body_recommend,@cat_body_confirm,@cat_body_icon)";

            //取得传入参数
            MySqlParameter[] param =
            {
                        new MySqlParameter("@cat_id", MySqlDbType.Int32,20) ,
                        new MySqlParameter("@cat_body_title", MySqlDbType.VarChar,100) ,
                        new MySqlParameter("@cat_body_author", MySqlDbType.VarChar,100) ,
                        new MySqlParameter("@cat_body_type", MySqlDbType.VarChar,1) ,
                        new MySqlParameter("@cat_body_url", MySqlDbType.VarChar,255) ,
                        new MySqlParameter("@cat_body_keyword", MySqlDbType.VarChar,255) ,
                        new MySqlParameter("@cat_body_content", MySqlDbType.LongText) ,
                        new MySqlParameter("@cat_body_indate", MySqlDbType.VarChar,10) ,
                        new MySqlParameter("@cat_body_outdate", MySqlDbType.VarChar,10) ,
                        new MySqlParameter("@cat_body_click", MySqlDbType.Int32,20) ,
                        new MySqlParameter("@cat_body_recommend", MySqlDbType.TinyText,4) ,
                        new MySqlParameter("@cat_body_confirm", MySqlDbType.TinyText,1) ,
                        new MySqlParameter("@cat_body_icon", MySqlDbType.VarChar,20)

            };

            if (cat_body.cat_id == null)
                param[0].Value = DBNull.Value;
            else
                param[0].Value = cat_body.cat_id;

            if (cat_body.cat_body_title == null)
                param[1].Value = DBNull.Value;
            else
                param[1].Value = cat_body.cat_body_title;

            if (cat_body.cat_body_author == null)
                param[2].Value = DBNull.Value;
            else
                param[2].Value = cat_body.cat_body_author;

            if (cat_body.cat_body_type == null)
                param[3].Value = DBNull.Value;
            else
                param[3].Value = cat_body.cat_body_type;

            if (cat_body.cat_body_url == null)
                param[4].Value = DBNull.Value;
            else
                param[4].Value = cat_body.cat_body_url;

            if (cat_body.cat_body_keyword == null)
                param[5].Value = DBNull.Value;
            else
                param[5].Value = cat_body.cat_body_keyword;

            if (cat_body.cat_body_content == null)
                param[6].Value = DBNull.Value;
            else
                param[6].Value = cat_body.cat_body_content;

            if (cat_body.cat_body_indate == null)
                param[7].Value = DBNull.Value;
            else
                param[7].Value = cat_body.cat_body_indate;

            if (cat_body.cat_body_outdate == null)
                param[8].Value = DBNull.Value;
            else
                param[8].Value = cat_body.cat_body_outdate;

            if (cat_body.cat_body_click == null)
                param[9].Value = DBNull.Value;
            else
                param[9].Value = cat_body.cat_body_click;

            if (cat_body.cat_body_recommend == null)
                param[10].Value = DBNull.Value;
            else
                param[10].Value = cat_body.cat_body_recommend;

            if (cat_body.cat_body_confirm == null)
                param[11].Value = DBNull.Value;
            else
                param[11].Value = cat_body.cat_body_confirm;

            if (cat_body.cat_body_icon == null)
                param[12].Value = DBNull.Value;
            else
                param[12].Value = cat_body.cat_body_icon;

            //执行SQL语句，并返回结果
            return DBHelper.ExecuteCommand(sql, CommandType.Text, param);
        }

        #endregion

        #region 查询

        /// <summary>
        /// Function Name：查询
        /// Powered By：TangLong
        /// Create Date：
        /// </summary>
        /// <param name="membersinfo">【MembersInfo】实体类</param>
        /// <param name="PageIndex">页数</param>
        /// <param name="PageSize">每页显示的数量</param>
        /// <param name="RecordCount">返回：当前查询条件下的数据量(查询时传入0)</param>
        /// <param name="OrderByStr">排序(字段名 desc/字段名 asc)</param>
        /// <param name="IsLike">true：模糊查询 false：非模糊查询</param>
        /// <returns></returns>
        public List<Cat_Body> SelectAll(Cat_Body body, int PageIndex, int PageSize, ref int RecordCount, string OrderByStr, bool IsLike)
        {
            //取得存储过程名称
            sql = "ProcPage";

            //取得查询条件
            GetSelectWhere(body, IsLike);
            //取得要查询的表名
            SqlDataTable = "cat_body";
            //取得查询需要返回的列
            Fields = "*";
            //取得排序字段
            OrderByStr = "cat_body_id";

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

            List<Cat_Body> List = GetDataListFill(DBHelper.GetDataSet(sql, CommandType.StoredProcedure, param));

            //取得当前条件下的数据数量
            RecordCount = Convert.ToInt32(p.Value);

            return List;
        }

        #endregion

        #region 取得查询条件

        /// <summary>
        /// 取得查询条件
        /// </summary>
        /// <param name="cat_body">【cat_body】实体类</param>
        /// <param name="IsLike">true：模糊查询 false：非模糊查询</param>
        private void GetSelectWhere(Cat_Body cat_body, bool IsLike)
        {
            //取得公共查询条件
            if (cat_body.cat_body_id != null && cat_body.cat_body_id != 0)
            {
                StrWhere.Append(" and cat_body_id = '" + cat_body.cat_body_id.ToString() + "'");
            }
            if (cat_body.cat_id != null)
            {
                StrWhere.Append(" and cat_id = '" + cat_body.cat_id.ToString() + "'");
            }
            if (cat_body.cat_body_click != null)
            {
                StrWhere.Append(" and cat_body_click = '" + cat_body.cat_body_click.ToString() + "'");
            }
            if (cat_body.cat_body_recommend != null)
            {
                StrWhere.Append(" and cat_body_recommend = '" + cat_body.cat_body_recommend.ToString() + "'");
            }
            if (cat_body.cat_body_confirm != null)
            {
                StrWhere.Append(" and cat_body_confirm = '" + cat_body.cat_body_confirm.ToString() + "'");
            }
            //判断是模糊查询还是非模糊查询
            if (IsLike)
            {
                if (cat_body.cat_body_title != null && cat_body.cat_body_title != "")
                {
                    StrWhere.Append(" and cat_body_title like '%" + (cat_body.cat_body_title.Replace("'", "")).Replace(";", "") + "%'");
                }
                if (cat_body.cat_body_author != null && cat_body.cat_body_author != "")
                {
                    StrWhere.Append(" and cat_body_author like '%" + (cat_body.cat_body_author.Replace("'", "")).Replace(";", "") + "%'");
                }
                if (cat_body.cat_body_type != null && cat_body.cat_body_type != "")
                {
                    StrWhere.Append(" and cat_body_type like '%" + (cat_body.cat_body_type.Replace("'", "")).Replace(";", "") + "%'");
                }
                if (cat_body.cat_body_url != null && cat_body.cat_body_url != "")
                {
                    StrWhere.Append(" and cat_body_url like '%" + (cat_body.cat_body_url.Replace("'", "")).Replace(";", "") + "%'");
                }
                if (cat_body.cat_body_keyword != null && cat_body.cat_body_keyword != "")
                {
                    StrWhere.Append(" and cat_body_keyword like '%" + (cat_body.cat_body_keyword.Replace("'", "")).Replace(";", "") + "%'");
                }
                if (cat_body.cat_body_content != null && cat_body.cat_body_content != "")
                {
                    StrWhere.Append(" and cat_body_content like '%" + (cat_body.cat_body_content.Replace("'", "")).Replace(";", "") + "%'");
                }
                if (cat_body.cat_body_indate != null && cat_body.cat_body_indate != "")
                {
                    StrWhere.Append(" and cat_body_indate like '%" + (cat_body.cat_body_indate.Replace("'", "")).Replace(";", "") + "%'");
                }
                if (cat_body.cat_body_outdate != null && cat_body.cat_body_outdate != "")
                {
                    StrWhere.Append(" and cat_body_outdate like '%" + (cat_body.cat_body_outdate.Replace("'", "")).Replace(";", "") + "%'");
                }
                if (cat_body.cat_body_icon != null && cat_body.cat_body_icon != "")
                {
                    StrWhere.Append(" and cat_body_icon like '%" + (cat_body.cat_body_icon.Replace("'", "")).Replace(";", "") + "%'");
                }
            }
            else
            {
                if (cat_body.cat_body_title != null && cat_body.cat_body_title != "")
                {
                    StrWhere.Append(" and cat_body_title = '" + (cat_body.cat_body_title.Replace("'", "")).Replace(";", "") + "'");
                }
                if (cat_body.cat_body_author != null && cat_body.cat_body_author != "")
                {
                    StrWhere.Append(" and cat_body_author = '" + (cat_body.cat_body_author.Replace("'", "")).Replace(";", "") + "'");
                }
                if (cat_body.cat_body_type != null && cat_body.cat_body_type != "")
                {
                    StrWhere.Append(" and cat_body_type = '" + (cat_body.cat_body_type.Replace("'", "")).Replace(";", "") + "'");
                }
                if (cat_body.cat_body_url != null && cat_body.cat_body_url != "")
                {
                    StrWhere.Append(" and cat_body_url = '" + (cat_body.cat_body_url.Replace("'", "")).Replace(";", "") + "'");
                }
                if (cat_body.cat_body_keyword != null && cat_body.cat_body_keyword != "")
                {
                    StrWhere.Append(" and cat_body_keyword = '" + (cat_body.cat_body_keyword.Replace("'", "")).Replace(";", "") + "'");
                }
                if (cat_body.cat_body_content != null && cat_body.cat_body_content != "")
                {
                    StrWhere.Append(" and cat_body_content = '" + (cat_body.cat_body_content.Replace("'", "")).Replace(";", "") + "'");
                }
                if (cat_body.cat_body_indate != null && cat_body.cat_body_indate != "")
                {
                    StrWhere.Append(" and cat_body_indate = '" + (cat_body.cat_body_indate.Replace("'", "")).Replace(";", "") + "'");
                }
                if (cat_body.cat_body_outdate != null && cat_body.cat_body_outdate != "")
                {
                    StrWhere.Append(" and cat_body_outdate = '" + (cat_body.cat_body_outdate.Replace("'", "")).Replace(";", "") + "'");
                }
                if (cat_body.cat_body_icon != null && cat_body.cat_body_icon != "")
                {
                    StrWhere.Append(" and cat_body_icon = '" + (cat_body.cat_body_icon.Replace("'", "")).Replace(";", "") + "'");
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
        private List<Cat_Body> GetDataListFill(DataSet ds)
        {
            List<Cat_Body> list = new List<Cat_Body>();

            Cat_Body table = null;

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    table = new Cat_Body();
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
        /// <param name="cat_body"></param>
        private void GetDataTableFill(DataRow row, Cat_Body cat_body)
        {
            if (row["cat_body_id"] != DBNull.Value)
                cat_body.cat_body_id = Convert.ToInt32(row["cat_body_id"]);
            if (row["cat_id"] != DBNull.Value)
                cat_body.cat_id = Convert.ToInt32(row["cat_id"]);
            if (row["cat_body_title"] != DBNull.Value)
                cat_body.cat_body_title = Convert.ToString(row["cat_body_title"]);
            if (row["cat_body_author"] != DBNull.Value)
                cat_body.cat_body_author = Convert.ToString(row["cat_body_author"]);
            if (row["cat_body_type"] != DBNull.Value)
                cat_body.cat_body_type = Convert.ToString(row["cat_body_type"]);
            if (row["cat_body_url"] != DBNull.Value)
                cat_body.cat_body_url = Convert.ToString(row["cat_body_url"]);
            if (row["cat_body_keyword"] != DBNull.Value)
                cat_body.cat_body_keyword = Convert.ToString(row["cat_body_keyword"]);
            if (row["cat_body_content"] != DBNull.Value)
                cat_body.cat_body_content = Convert.ToString(row["cat_body_content"]);
            if (row["cat_body_indate"] != DBNull.Value)
                cat_body.cat_body_indate = Convert.ToString(row["cat_body_indate"]);
            if (row["cat_body_outdate"] != DBNull.Value)
                cat_body.cat_body_outdate = Convert.ToString(row["cat_body_outdate"]);
            if (row["cat_body_click"] != DBNull.Value)
                cat_body.cat_body_click = Convert.ToInt32(row["cat_body_click"]);
            if (row["cat_body_recommend"] != DBNull.Value)
                cat_body.cat_body_recommend = Convert.ToInt32(row["cat_body_recommend"]);
            if (row["cat_body_confirm"] != DBNull.Value)
                cat_body.cat_body_confirm = Convert.ToInt32(row["cat_body_confirm"]);
            if (row["cat_body_icon"] != DBNull.Value)
                cat_body.cat_body_icon = Convert.ToString(row["cat_body_icon"]);
        }

        #endregion
    }
}
