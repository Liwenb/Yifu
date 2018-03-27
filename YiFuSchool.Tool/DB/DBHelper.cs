using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace YiFuSchool.Tool.DB
{
    /// <summary>
    /// DBHelper类
    /// Powered By：Project_Y
    /// Create Date：2010-04-05
    /// </summary>
    public class DBHelper
    {
        /// <summary>
        /// 获取配置文件中的连接字符串 
        /// </summary>
        private static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GSqlServer"].ConnectionString;

        /// <summary>
        /// 执行增（INSERT）删（DELETE）改（UPDATE）语句。
        /// 这个方法自己会创建连接、打开连接并且自动关闭连接。
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static int ExecuteCommand(string sql)
        {
            MySqlCommand cmd = null;
            MySqlTransaction trans = null;
            int flag = 0;
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                try
                {
                    //设置Command对象
                    cmd = GetCommand(sql, CommandType.Text);
                    cmd.Connection = conn;
                    //打开连接
                    conn.Open();
                    trans = conn.BeginTransaction();
                    cmd.Transaction = trans;
                    //执行命令操作
                    flag = cmd.ExecuteNonQuery();
                    //释放资源
                    cmd.Parameters.Clear();
                    trans.Commit();
                    conn.Close();
                    cmd.Dispose();
                    cmd = null;
                }
                catch (Exception e)
                {
                    //回滚事物
                    trans.Rollback();
                }
                finally
                {
                    if (trans != null)
                    {
                        trans.Dispose();
                    }
                }

                return flag;
            }
        }

        /// <summary>
        /// 执行增（INSERT）删（DELETE）改（UPDATE）语句。
        /// 这个方法自己会创建连接、打开连接并且自动关闭连接。
        /// </summary>
        /// <param name="name">存储过程名称/或SQL语句</param>
        /// <param name="Type">类型</param>
        /// <param name="param">参数</param>
        /// <returns>int flag</returns>
        public static int ExecuteCommand(string name, CommandType Type, params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                //设置Command对象
                MySqlCommand cmd = GetCommand(name, Type, param);
                cmd.CommandTimeout = 720;//设置数据库超时时间(3分钟),如果设置为0代表不限制时间慎用
                cmd.Connection = conn;
                //打开连接
                conn.Open();
                //执行命令操作
                int flag = 0;
                try
                {
                    cmd.Transaction = conn.BeginTransaction();
                    flag = cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    if (cmd.Transaction != null)
                        cmd.Transaction.Rollback();

                    throw e;
                }
                //释放资源
                cmd.Parameters.Clear();
                conn.Close();
                cmd.Dispose();
                cmd = null;
                return flag;
            }
        }

        /// <summary>
        /// 执行增（INSERT）删（DELETE）改（UPDATE）语句。
        /// 这个方法自己会创建连接、打开连接并且自动关闭连接。
        /// </summary>
        /// <param name="name">存储过程名称/或SQL语句</param>
        /// <param name="Type">类型</param>
        /// <param name="i">无意义的参数</param>
        /// <param name="param">参数</param>
        /// <returns>int flag</returns>
        public static int ExecuteCommand(string name, CommandType Type, int i, params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                //设置Command对象
                MySqlCommand cmd = GetCommand(name, Type, param);
                cmd.Connection = conn;
                //打开连接
                conn.Open();
                //执行命令操作
                int flag = 0;
                try
                {
                    cmd.Transaction = conn.BeginTransaction();
                    flag = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    if (cmd.Transaction != null)
                        cmd.Transaction.Rollback();

                    throw e;
                }
                //释放资源
                cmd.Parameters.Clear();
                conn.Close();
                cmd.Dispose();
                cmd = null;
                return flag;
            }
        }


        /// <summary>
        /// 执行查询（SELECT）语句，第一行第一列的值。
        /// 这个方法自己会创建连接、打开连接并且自动关闭连接。
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="param">参数</param>
        /// <returns>int flag</returns>
        public static string GetScalar(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                //设置Command对象
                MySqlCommand cmd = GetCommand(sql, CommandType.Text);
                cmd.Connection = conn;
                //打开连接
                conn.Open();
                //执行命令操作
                string flag = Convert.ToString(cmd.ExecuteScalar());
                //释放资源
                cmd.Parameters.Clear();
                conn.Close();
                cmd.Dispose();
                cmd = null;
                return flag;
            }
        }

        /// <summary>
        /// 执行查询（SELECT）语句，第一行第一列的值。
        /// 这个方法自己会创建连接、打开连接并且自动关闭连接。
        /// </summary>
        /// <param name="name">存储过程名称/或SQL语句</param>
        /// <param name="Type">类型</param>
        /// <param name="param">参数</param>
        /// <returns>int flag</returns>
        public static string GetScalar(string name, CommandType Type, params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                //设置Command对象
                MySqlCommand cmd = GetCommand(name, Type, param);
                cmd.Connection = conn;
                //打开连接
                
                conn.Open();
                string flag = "-1";
                //执行命令操作
                flag = Convert.ToString(cmd.ExecuteScalar());

                //释放资源
                cmd.Parameters.Clear();
                conn.Close();
                cmd.Dispose();
                cmd = null;
                return flag;
            }
        }

        /// <summary>
        /// 执行查询（SELECT）语句，获取填充后数据集。
        /// 这个方法自己会创建连接、打开连接并且自动关闭连接。
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="param">参数</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                //设置Command对象
                MySqlCommand cmd = GetCommand(sql, CommandType.Text);
                cmd.Connection = conn;
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, "Table");
                //释放资源
                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
                return ds;
            }
        }


        /// <summary>
        /// 执行查询（SELECT）语句，获取填充后数据集。
        /// 这个方法自己会创建连接、打开连接并且自动关闭连接。
        /// </summary>
        /// <param name="name">存储过程名称/或SQL语句</param>
        /// <param name="Type">类型</param>
        /// <param name="param">参数</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string name, CommandType Type, params MySqlParameter[] param)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                //设置Command对象
                MySqlCommand cmd = GetCommand(name, Type, param);
                cmd.Connection = conn;
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                
                sda.Fill(ds, "Table");
                //释放资源
                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
                return ds;
            }
        }

        /// <summary>
        /// 执行查询（SELECT）语句，获取只读只进的MySqlDataReader对象。
        /// 这个方法自己会创建连接、打开连接并且自动关闭连接。
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="param">参数</param>
        /// <returns>MySqlDataReader</returns>
        public static MySqlDataReader GetReader(string sql)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = GetCommand(sql, CommandType.Text);
            cmd.Connection = conn;

            MySqlDataReader sdr = null;
            try
            {
                conn.Open();
                sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //释放资源
                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
            }
            catch (MySqlException e)
            {
                conn.Close();
                throw e;
            }

            return sdr;
        }

        /// <summary>
        /// 执行查询（SELECT）语句，获取只读只进的MySqlDataReader对象。
        /// 这个方法自己会创建连接、打开连接并且自动关闭连接。
        /// </summary>
        /// <param name="name">存储过程名称/或SQL语句</param>
        /// <param name="Type">类型</param>
        /// <param name="param">参数</param>
        /// <returns>MySqlDataReader</returns>
        public static MySqlDataReader GetReader(string name, CommandType Type, params MySqlParameter[] param)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = GetCommand(name, Type, param);
            cmd.Connection = conn;
            MySqlDataReader sdr = null;
            try
            {
                conn.Open();
                sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //释放资源
                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
            }
            catch (MySqlException e)
            {
                conn.Close();
                throw e;
            }
            return sdr;
        }

        /// <summary>
        /// 给MySqlCommand赋值
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <returns></returns>
        private static MySqlCommand GetCommand(string sql)
        {
            //设置Command对象
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// 给MySqlCommand赋值
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        private static MySqlCommand GetCommand(string sql, params MySqlParameter[] param)
        {
            //设置Command对象
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            //添加参数
            if (param != null && param.Length > 0)
            {
                cmd.Parameters.AddRange(param);
            }
            return cmd;
        }

        /// <summary>
        /// 给MySqlCommand赋值
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="Type">类型</param>
        /// <returns></returns>
        private static MySqlCommand GetCommand(string sql, CommandType type)
        {
            //设置Command对象
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = type;

            return cmd;
        }

        /// <summary>
        /// 给MySqlCommand赋值
        /// </summary>
        /// <param name="name">存储过程名称</param>
        /// <param name="Type">类型</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        private static MySqlCommand GetCommand(string name, CommandType type, params MySqlParameter[] param)
        {
            //设置Command对象
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = name;
            cmd.CommandType = type;

            //添加参数
            if (param.Length > 0)
            {
                cmd.Parameters.AddRange(param);
            }
            return cmd;
        }

        public static List<T> TableToList<T>(DataTable dt) where T : class,new()
        {
            Type t = typeof(T);
            PropertyInfo[] propertys = t.GetProperties();
            List<T> lst = new List<T>();
            string typeName = string.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                T entity = new T();
                foreach (PropertyInfo pi in propertys)
                {
                    typeName = pi.Name;
                    if (dt.Columns.Contains(typeName))
                    {
                        if (!pi.CanWrite) continue;
                        object value = dr[typeName];
                        if (value == DBNull.Value) continue;
                        if (pi.PropertyType == typeof(string))
                        {
                            pi.SetValue(entity, value.ToString(), null);
                        }
                        else if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(int?))
                        {
                            pi.SetValue(entity, int.Parse(value.ToString()), null);
                        }
                        else if (pi.PropertyType == typeof(DateTime?) || pi.PropertyType == typeof(DateTime))
                        {
                            pi.SetValue(entity, DateTime.Parse(value.ToString()), null);
                        }
                        else if (pi.PropertyType == typeof(float))
                        {
                            pi.SetValue(entity, float.Parse(value.ToString()), null);
                        }
                        else if (pi.PropertyType == typeof(double))
                        {
                            pi.SetValue(entity, double.Parse(value.ToString()), null);
                        }
                        else
                        {
                            pi.SetValue(entity, value, null);
                        }
                    }
                }
                lst.Add(entity);
            }
            return lst;
        }
    }
}
