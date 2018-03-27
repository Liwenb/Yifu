using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiFuSchool.Manager;
using YiFuSchool.Model;
using YiFuSchool.Web;

namespace PetHospital.Controllers
{
    public class MenuBarController : Controller
    {
        #region 初始化

        Cat_MainManager cm = new Cat_MainManager();

        #endregion
        public ActionResult List(string id)
        {
            string title = "";
            string pid = "";

            switch (id)
            {
                case "355":
                    title = "校园动态";
                    pid = id;
                    break;
                case "x":
                    id = "660,849";
                    title = "通知公告";
                    pid = "x";
                    break;
                case "y":
                    id = "369,557,699";
                    title = "作品园地";
                    pid = "y";
                    break;
                case "560":
                    title = "基层党务";
                    pid = id;
                    break;
                case "582":
                    title = "基层党务";
                    pid = id;
                    break;
                case "563":
                    title = "基层党务";
                    pid = id;
                    break;
                case "824":
                    title = "行为规范";
                    pid = id;
                    break;
                case "825":
                    title = "行为规范";
                    pid = id;
                    break;
                case "826":
                    title = "行为规范";
                    pid = id;
                    break;
                case "827":
                    title = "行为规范";
                    pid = id;
                    break;
                case "853":
                    title = "文明在线";
                    pid = id;
                    break;
                case "854":
                    title = "文明在线";
                    pid = id;
                    break;
                case "668":
                    title = "学校信息公开";
                    pid = id;
                    break;
                case "691":
                    title = "学校信息公开";
                    pid = id;
                    break;
                case "692":
                    title = "学校信息公开";
                    pid = id;
                    break;
                case "704":
                    title = "学校信息公开";
                    pid = id;
                    break;
            }

            int count = 0;
            var data = cm.SelectAll(new Cat_Main() { cat_parent_ids = id }, 1, 100, ref count, "cat_id", false);
            var result = new LappResponse<List<Cat_Main>>();
            result.Data = data;
            result.Code = cm.Status == "1" ? Code.Success : Code.Failure;
            result.Message = title;
            result.ID = pid;
            ViewBag.MenuList = JsonConvert.SerializeObject(result);

            return View();
        }
    }
}