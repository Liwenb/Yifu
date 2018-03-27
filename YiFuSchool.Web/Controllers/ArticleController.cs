using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiFuSchool.Manager;
using YiFuSchool.Model;
using YiFuSchool.Web;
using YiFuSchool.Web.Core;

namespace PetHospital.Controllers
{
    public class ArticleController : Controller
    {
        #region 初始化

        Cat_BodyManager cm = new Cat_BodyManager();
        Cat_MainManager cmain = new Cat_MainManager();

        #endregion
        public ActionResult Article(int id)
        {
            int count = 0;
            var cat_Body = new Cat_Body();
            cat_Body.cat_body_id = id;
            var data = cm.SelectAll(cat_Body, 1, 1, ref count, "cat_body_id", false)[0];
            var result = new LappResponse<Cat_Body>();
            result.Data = data;
            result.Code = cm.Status == "1" ? Code.Success : Code.Failure;
            ViewBag.PageData = JsonConvert.SerializeObject(result);

            List<Cat_Body> rList = new List<Cat_Body>();
            var list = cm.SelectAll(new Cat_Body() { cat_body_keyword=data.cat_body_keyword }, 1, 1000, ref count, "cat_body_id", false);
            List<int> raList = GenerateRandom(list.Count, 15);

            raList.ForEach(x =>
            {
                rList.Add(list[x]);
            });

            ViewBag.ListData = JsonConvert.SerializeObject(rList);

            return View();
        }
        public ActionResult List(string id)
        {
            string title = "";
            string[] strs = id.Split('-');

            string pid = strs.Length > 0 ? strs[0] : "0";

            string newId = strs.Length > 0 ? strs[1] : "0";

            switch (pid)
            {
                case "355":
                    title = "校园动态";
                    break;
                case "x":
                    pid = "660,849";
                    title = "通知公告";
                    break;
                case "y":
                    pid = "369,557,699";
                    title = "作品园地";
                    break;
                case "560":
                    title = "基层党务";
                    break;
                case "582":
                    title = "基层党务";
                    break;
                case "563":
                    title = "基层党务";
                    break;
                case "824":
                    title = "行为规范";
                    break;
                case "825":
                    title = "行为规范";
                    break;
                case "826":
                    title = "行为规范";
                    break;
                case "827":
                    title = "行为规范";
                    break;
                case "853":
                    title = "文明在线";
                    break;
                case "854":
                    title = "文明在线";
                    break;
                case "668":
                    title = "学校信息公开";
                    break;
                case "691":
                    title = "学校信息公开";
                    break;
                case "692":
                    title = "学校信息公开";
                    break;
                case "704":
                    title = "学校信息公开";
                    break;
            }

            int count = 0;

            var menus = cmain.SelectAll(new Cat_Main() { cat_parent_ids = pid }, 1, 100, ref count, "cat_id", false);

            ViewBag.MenuList = JsonConvert.SerializeObject(menus);
            if (pid == "660,849")
            {
                pid = "x";
            }
            else if (pid == "369,557,699")
            {
                pid = "y";
            }


            var cat_Body = new Cat_Body();
            cat_Body.cat_id = Convert.ToInt32(newId);
            cat_Body.PageIndex = 1;
            cat_Body.PageSize = 30;
            var data = cm.SelectAll(cat_Body, cat_Body.PageIndex, cat_Body.PageSize, ref count, "cat_body_id", false);
            var result = new LappResponse<List<Cat_Body>>();
            result.Message = title;
            result.TitleName = menus.Where(x => x.cat_id == Convert.ToInt32(newId)).ToList().First().cat_name;
            result.ID = pid;
            result.Data = data;
            result.Code = cm.Status == "1" ? Code.Success : Code.Failure;
            result.Page = new Pager().GetJumperForAjax(cat_Body.PageIndex, cat_Body.PageSize, count, "ArticleList.PageSelect({0})");
            ViewBag.PageData = JsonConvert.SerializeObject(result);
            return View();
        }

        public List<int> GenerateRandom(int iMax, int iNum)
        {
            List<int> lstRet = new List<int>();
            for (int i = 0; i < iNum; i++)
            {
                long lTick = DateTime.Now.Ticks;
                Random ran = new Random((int)lTick * i);
                int iTmp = ran.Next(iMax);
                lstRet.Add(iTmp);
            }
            return lstRet;
        }
    }
}