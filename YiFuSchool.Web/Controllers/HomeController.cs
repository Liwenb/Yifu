using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiFuSchool.Manager;
using YiFuSchool.Model;

namespace YiFuSchool.Web.Controllers
{
    public class HomeController : Controller
    {
        #region 初始化

        Cat_BodyManager cm = new Cat_BodyManager();

        #endregion
        // GET: Home
        public ActionResult Index()
        {
            int count = 0;
            var sceneryData = cm.SelectAll(new Cat_Body() { cat_id = 670 }, 1, 20, ref count, "cat_body_id", false);
            var surveyData = cm.SelectAll(new Cat_Body() { cat_id = 669 }, 1, 20, ref count, "cat_body_id", false);
            ViewBag.SceneryData = JsonConvert.SerializeObject(sceneryData);
            ViewBag.SurveyData = JsonConvert.SerializeObject(surveyData);
            return View();

        }
    }
}