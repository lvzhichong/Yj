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
        public ActionResult Index(ls_role model, string isSearch)
        {
            int pageIndex = 1;

            PagedList<ls_role> pagerModel = GetRoles(model, pageIndex);

            //返回数据
            if (!string.IsNullOrWhiteSpace(isSearch) && isSearch == "1")
            {
                return PartialView("RoleListPartial", pagerModel);
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
        public ActionResult Index(ls_role model, int? page = 1)
        {
            int pageIndex = page ?? 1;

            PagedList<ls_role> pagerModel = GetRoles(model, pageIndex);

            return PartialView("RoleListPartial", pagerModel);
        }

        /// <summary>
        /// 获取权限数据
        /// </summary>
        /// <returns></returns>
        private PagedList<ls_role> GetRoles(ls_role model, int pageIndex)
        {
            int totalRow = 0;
            int pageSize = Common.Config.PageSize;

            PagedList<ls_role> pagerModel = ls_roleBiz.Instance.GetList(model, pageIndex - 1, pageSize, out totalRow).AsQueryable().ToPagedList(1, pageSize);

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
        public ActionResult EditRole(int? role_id)
        {
            ls_role model = new ls_role { role_id = 0 };

            if (role_id != null)
            {
                model = Biz.ls_roleBiz.Instance.GetModelById(role_id.Value);
            }

            return View(model);
        }

        /// <summary>
        /// 修改权限信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditRole(ls_role model)
        {
            // 无需验证的字段
            //ModelState.Remove("user_old_password");

            bool result = false;

            Common.JsonData<ls_role> data = new Common.JsonData<ls_role>
            {
                Message = "操作失败！"
            };

            // 验证是否全部通过
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["role_id"]))
                    {
                        // 修改权限信息
                        result = Biz.ls_roleBiz.Instance.EditModel(model);

                        if (result)
                        {
                            data.Message = "修改权限成功！";
                        }
                    }
                    else
                    {
                        // 添加权限信息
                        result = Biz.ls_roleBiz.Instance.AddModel(model);

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
        /// <param name="role_id"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteRole(int? role_id)
        {
            bool result = false;

            if (role_id != null)
            {
                result = Biz.ls_roleBiz.Instance.Delete(role_id.Value);
            }

            return result;
        }

        /// <summary>
        /// 权限名是否存在
        /// </summary>
        /// <returns></returns>
        public ActionResult IsExistRoleName(int role_id, string role_name)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
