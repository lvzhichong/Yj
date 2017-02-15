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
    public class TeamController : BaseAuthorizeController
    {
        /// <summary>
        /// 系统权限
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSearch"></param>
        /// <returns></returns>
        public ActionResult Index(yj_team model, string isSearch)
        {
            int pageIndex = 1;

            PagedList<yj_team> pagerModel = GetTeams(model, pageIndex);

            //返回数据
            if (!string.IsNullOrWhiteSpace(isSearch) && isSearch == "1")
            {
                return PartialView("TeamListPartial", pagerModel);
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
        public ActionResult Index(yj_team model, int? page = 1)
        {
            int pageIndex = page ?? 1;

            PagedList<yj_team> pagerModel = GetTeams(model, pageIndex);

            return PartialView("TeamListPartial", pagerModel);
        }

        /// <summary>
        /// 获取权限数据
        /// </summary>
        /// <returns></returns>
        private PagedList<yj_team> GetTeams(yj_team model, int pageIndex)
        {
            int totalRow = 0;
            int pageSize = Common.Config.PageSize;

            PagedList<yj_team> pagerModel = yj_teamBiz.Instance.GetList(model, pageIndex - 1, pageSize, out totalRow).AsQueryable().ToPagedList(1, pageSize);

            if (pagerModel != null)
            {
                pagerModel.TotalItemCount = totalRow;
                pagerModel.CurrentPageIndex = pageIndex;
            }

            return pagerModel;
        }

        /// <summary>
        /// 修改权限信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult EditTeam(int? team_id)
        {
            yj_team model = new yj_team { team_id = 0 };

            if (team_id != null)
            {
                model = Biz.yj_teamBiz.Instance.GetModelById(team_id.Value);
            }

            return View(model);
        }

        /// <summary>
        /// 修改权限信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTeam(yj_team model)
        {
            // 无需验证的字段
            //ModelState.Remove("user_old_password");

            bool result = false;

            Common.JsonData<yj_team> data = new Common.JsonData<yj_team>
            {
                Message = "操作失败！"
            };

            // 验证是否全部通过
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["team_id"]))
                    {
                        // 修改权限信息
                        result = Biz.yj_teamBiz.Instance.EditModel(model);

                        if (result)
                        {
                            data.Message = "修改权限成功！";
                        }
                    }
                    else
                    {
                        // 添加权限信息
                        result = Biz.yj_teamBiz.Instance.AddModel(model);

                        if (result)
                        {
                            data.Message = "添加权限成功！";
                        }
                    }
                }
            }

            data.Flag = result;

            return Json(data);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="team_id"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteTeam(int? team_id)
        {
            bool result = false;

            if (team_id != null)
            {
                result = Biz.yj_teamBiz.Instance.Delete(team_id.Value);
            }

            return result;
        }

        /// <summary>
        /// 权限名是否存在
        /// </summary>
        /// <returns></returns>
        public ActionResult IsExistTeamName(int team_id, string team_name)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
