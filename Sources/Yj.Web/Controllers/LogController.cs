using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using Yj.Biz;
using Yj.Models;
using Webdiyer.WebControls.Mvc;

namespace Yj.Web.Controllers
{
    public class LogController : BaseAuthorizeController
    {
        /// <summary>
        /// 系统权限
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSearch"></param>
        /// <returns></returns>
        public ActionResult Index(ls_log model, string isSearch)
        {
            int pageIndex = 1;

            PagedList<ls_log> pagerModel = GetLogs(model, pageIndex);

            //返回数据
            if (!string.IsNullOrWhiteSpace(isSearch) && isSearch == "1")
            {
                return PartialView("LogListPartial", pagerModel);
            }

            return View(pagerModel);
        }

        /// <summary>
        /// 系统权限
        /// </summary>
        /// <param name="model"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(ls_log model, int? page = 1)
        {
            int pageIndex = page ?? 1;

            PagedList<ls_log> pagerModel = GetLogs(model, pageIndex);

            return PartialView("LogListPartial", pagerModel);
        }

        /// <summary>
        /// 获取权限数据
        /// </summary>
        /// <returns></returns>
        private PagedList<ls_log> GetLogs(ls_log model, int pageIndex)
        {
            int totalRow = 0;
            int pageSize = Common.Config.PageSize;

            PagedList<ls_log> pagerModel = ls_logBiz.Instance.GetList(model, pageIndex - 1, pageSize, out totalRow).AsQueryable().ToPagedList(1, pageSize);

            if (pagerModel != null)
            {
                pagerModel.TotalItemCount = totalRow;
                pagerModel.CurrentPageIndex = pageIndex;
            }

            return pagerModel;
        }
    }
}
