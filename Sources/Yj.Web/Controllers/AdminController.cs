using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yj.Web.Controllers
{
    [Authorize]
    public class AdminController : BaseAuthorizeController
    {
        /// <summary>
        /// 首页 2016-12-01 基础版
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
