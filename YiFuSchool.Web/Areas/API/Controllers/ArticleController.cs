using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YiFuSchool.Manager;
using YiFuSchool.Model;
using YiFuSchool.Web;
using YiFuSchool.Web.Core;

namespace PetHospital.Areas.API.Controllers
{
    public class ArticleController : ApiController
    {
        #region 初始化

        Cat_BodyManager cm = new Cat_BodyManager();

        #endregion

        [HttpPost]
        public LappResponse<List<Cat_Body>> GetListPage(Cat_Body cat_Body)
        {
            int count = 0;
            var data = cm.SelectAll(cat_Body, cat_Body.PageIndex, cat_Body.PageSize, ref count, "cat_body_id", false);
            var result = new LappResponse<List<Cat_Body>>();
            result.Data = data;
            result.Count = count;
            result.Code = cm.Status == "1" ? Code.Success : Code.Failure;
            result.Page = new Pager().GetJumperForAjax(cat_Body.PageIndex, cat_Body.PageSize, count, "ArticleList.PageSelect({0})");

            return result;
        }

        [HttpPost]
        public LappResponse<List<Cat_Body>> GetListByCat_Id(Cat_Body cat_Body)
        {
            int count = 0;
            var data = cm.SelectAll(new Cat_Body() { cat_id = Convert.ToInt32(cat_Body.cat_id) }, 1, 5, ref count, "cat_body_id", false);
            var result = new LappResponse<List<Cat_Body>>();
            result.Data = data;
            result.Count = count;
            result.Code = cm.Status == "1" ? Code.Success : Code.Failure;

            return result;
        }
    }
}
