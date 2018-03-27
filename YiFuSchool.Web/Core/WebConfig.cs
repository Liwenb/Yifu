using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace YiFuSchool.Web.Core
{
    public class WebConfig
    {
        //总站地址
        public static string DefaultSiteUrl = ConfigurationManager.AppSettings["DefaultSiteUrl"];
    }
}