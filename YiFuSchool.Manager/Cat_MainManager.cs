using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiFuSchool.Model;
using YiFuSchool.Services;

namespace YiFuSchool.Manager
{
    public class Cat_MainManager
    {
        #region 初始化

        private string _Status;

        private Cat_MainServices cat_MainService;

        public Cat_MainManager()
        {
            _Status = "1";
        }

        public string Status
        {
            get { return _Status; }
        }

        #endregion


        #region 分页查询

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="UserInfo">【用户表】实体类</param>
        /// <param name="PageIndex">页数</param>
        /// <param name="PageSize">每页显示的数量</param>
        /// <param name="RecordCount">返回：当前查询条件下的数据量(查询时传入0)</param>
        /// <param name="OrderByStr">排序(字段名 desc/字段名 asc)</param>
        /// <param name="IsLike">true：模糊查询 false：非模糊查询</param>
        /// <returns></returns>
        public List<Cat_Main> SelectAll(Cat_Main cat, int PageIndex, int PageSize, ref int RecordCount, string OrderByStr, bool IsLike)
        {
            #region 初始化

            cat_MainService = new  Cat_MainServices();

            #endregion

            #region 执行操作并返回结果

            return cat_MainService.SelectAll(cat, PageIndex, PageSize, ref RecordCount, OrderByStr, IsLike);

            #endregion
        }

        #endregion
    }
}
