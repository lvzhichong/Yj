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
    public class ModuleController : BaseAuthorizeController
    {
        /// <summary>
        /// 系统模块
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSearch"></param>
        /// <returns></returns>
        public ActionResult Index(ls_module model, string isSearch)
        {
            int pageIndex = 1;

            PagedList<ls_module> pagerModel = GetModules(model, pageIndex);

            //返回数据
            if (!string.IsNullOrWhiteSpace(isSearch) && isSearch == "1")
            {
                return PartialView("ModuleListPartial", pagerModel);
            }

            return View(pagerModel);
        }

        /// <summary>
        /// 系统模块
        /// </summary>
        /// <param name="model"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(ls_module model, int? page = 1)
        {
            int pageIndex = page ?? 1;

            PagedList<ls_module> pagerModel = GetModules(model, pageIndex);

            return PartialView("ModuleListPartial", pagerModel);
        }

        /// <summary>
        /// 获取模块数据
        /// </summary>
        /// <returns></returns>
        private PagedList<ls_module> GetModules(ls_module model, int pageIndex)
        {
            int totalRow = 0;
            int pageSize = Common.Config.PageSize;

            PagedList<ls_module> pagerModel = ls_moduleBiz.Instance.GetList(model, pageIndex - 1, pageSize, out totalRow).AsQueryable().ToPagedList(1, pageSize);

            if (pagerModel != null)
            {
                pagerModel.TotalItemCount = totalRow;
                pagerModel.CurrentPageIndex = pageIndex;
            }

            return pagerModel;
        }

        /// <summary>
        /// 修改模块信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult EditModule(int? module_id)
        {
            ls_module model = new ls_module { module_id = 0 };

            if (module_id != null)
            {
                model = Biz.ls_moduleBiz.Instance.GetModelById(module_id.Value);
            }

            // 系统分类
            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Text = "-- 请选择 --" } };

            foreach (var item in Biz.Cache.CommonCache.ModuleCategories)
            {
                items.Add(new SelectListItem { Text = item.Value, Value = item.Key });
            }

            ViewBag.ModuleCategories = items;

            // 权限信息
            // 分类
            List<string> categories = new List<string> { "模块权限" };
            ViewBag.Categories = categories;

            // 权限信息
            List<CheckBoxObject> objs = new List<CheckBoxObject>();

            // 获取所有权限信息
            List<ls_role> roles = Biz.Cache.CommonCache.Roles;

            CheckBoxObject obj = new CheckBoxObject
            {
                Title = ""
            };

            if (roles != null)
            {
                obj.Datas = new List<SelectListItem>();

                foreach (ls_role role in roles.OrderBy(r => r.role_id))
                {
                    SelectListItem item = new SelectListItem
                    {
                        Text = role.role_name,
                        Value = role.role_code,
                        Selected = false
                    };

                    if (model != null && !string.IsNullOrEmpty(model.module_roles) && model.module_roles.Contains(role.role_code))
                    {
                        item.Selected = true;
                    }

                    obj.Datas.Add(item);
                }
            }

            objs.Add(obj);

            ViewBag.CheckBoxDatas = objs;

            return View(model);
        }

        /// <summary>
        /// 修改模块信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditModule(ls_module model, string[] modules, string[] module_roles)
        {
            // 无需验证的字段
            //ModelState.Remove("user_old_password");

            bool result = false;

            Common.JsonData<ls_module> data = new Common.JsonData<ls_module>
            {
                Message = "操作失败！"
            };

            // 验证是否全部通过
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    if (module_roles != null && module_roles.Count() > 0)
                    {
                        model.module_roles = string.Join(",", module_roles);
                    }

                    if (!string.IsNullOrEmpty(Request.QueryString["module_id"]))
                    {
                        // 修改模块信息
                        result = Biz.ls_moduleBiz.Instance.EditModel(model);

                        if (result)
                        {
                            data.Message = "修改模块成功！";
                        }
                    }
                    else
                    {
                        // 添加模块信息
                        result = Biz.ls_moduleBiz.Instance.AddModel(model);

                        if (result)
                        {
                            data.Message = "添加模块成功！";
                        }
                    }
                }
            }

            data.Flag = result;

            return Json(data);
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="module_id"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteModule(int? module_id)
        {
            bool result = false;

            if (module_id != null)
            {
                result = Biz.ls_moduleBiz.Instance.Delete(module_id.Value);
            }

            return result;
        }

        /// <summary>
        /// 模块名是否存在
        /// </summary>
        /// <returns></returns>
        public ActionResult IsExistModuleName(int module_id, string role_name)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
