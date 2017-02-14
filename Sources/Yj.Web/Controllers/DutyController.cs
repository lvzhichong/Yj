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
    public class DutyController : BaseAuthorizeController
    {
        /// <summary>
        /// 系统角色
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSearch"></param>
        /// <returns></returns>
        public ActionResult Index(ls_duty model, string isSearch)
        {
            int pageIndex = 1;

            PagedList<ls_duty> pagerModel = GetUsers(model, pageIndex);

            //返回数据
            if (!string.IsNullOrWhiteSpace(isSearch) && isSearch == "1")
            {
                return PartialView("DutyListPartial", pagerModel);
            }

            return View(pagerModel);
        }

        /// <summary>
        /// 系统角色
        /// </summary>
        /// <param name="model"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(ls_duty model, int? page = 1)
        {
            int pageIndex = page ?? 1;

            PagedList<ls_duty> pagerModel = GetUsers(model, pageIndex);

            return PartialView("DutyListPartial", pagerModel);
        }

        /// <summary>
        /// 获取角色数据
        /// </summary>
        /// <returns></returns>
        private PagedList<ls_duty> GetUsers(ls_duty model, int pageIndex)
        {
            int totalRow = 0;
            int pageSize = Common.Config.PageSize;

            PagedList<ls_duty> pagerModel = ls_dutyBiz.Instance.GetList(model, pageIndex - 1, pageSize, out totalRow).AsQueryable().ToPagedList(1, pageSize);

            if (pagerModel != null)
            {
                pagerModel.TotalItemCount = totalRow;
                pagerModel.CurrentPageIndex = pageIndex;
            }

            return pagerModel;
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="duty_id"></param>
        /// <returns></returns>
        public ActionResult EditDuty(int? duty_id)
        {
            ls_duty model = new ls_duty { duty_id = 0 };

            if (duty_id != null)
            {
                model = Biz.ls_dutyBiz.Instance.GetModelById(duty_id.Value);
            }

            return View(model);
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditDuty(ls_duty model)
        {
            // 无需验证的字段
            //ModelState.Remove("user_old_password");

            bool result = false;

            Common.JsonData<ls_duty> data = new Common.JsonData<ls_duty>
            {
                Message = "操作失败！"
            };

            // 验证是否全部通过
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["duty_id"]))
                    {
                        // 修改用户信息
                        result = Biz.ls_dutyBiz.Instance.EditModel(model);

                        if (result)
                        {
                            data.Message = "修改角色成功！";
                        }
                    }
                    else
                    {
                        // 添加用户信息
                        result = Biz.ls_dutyBiz.Instance.AddModel(model);

                        if (result)
                        {
                            data.Message = "添加角色成功！";
                        }
                    }
                }
            }

            data.Flag = result;

            return Json(data);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="duty_id"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteDuty(int? duty_id)
        {
            bool result = false;

            if (duty_id != null)
            {
                result = Biz.ls_dutyBiz.Instance.Delete(duty_id.Value);
            }

            return result;
        }

        /// <summary>
        /// 角色名是否存在
        /// </summary>
        /// <returns></returns>
        public ActionResult IsExistDutyName(int duty_id, string duty_name)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 角色权限编辑
        /// </summary>
        /// <param name="duty_id"></param>
        /// <returns></returns>
        public ActionResult DutyModule(int? duty_id)
        {
            // 分类
            List<string> categories = new List<string>();

            // 模块和权限信息
            List<CheckBoxObject> objs = new List<CheckBoxObject>();

            if (duty_id != null)
            {
                // 用户所拥有的模块和权限
                List<ls_duty_module> duty_modules = Biz.ls_duty_moduleBiz.Instance.GetList(duty_id.Value).ToList();

                ls_duty model = Biz.ls_dutyBiz.Instance.GetModelById(duty_id.Value);

                // 获取所有Modules
                List<ls_module> modules = Biz.ls_moduleBiz.Instance.GetList().ToList();

                // 权限信息
                foreach (var category in modules.Where(m => !string.IsNullOrEmpty(m.module_category)).Select(m => m.module_category).Distinct())
                {
                    categories.Add(Biz.Cache.CommonCache.GetModuleCategory(category));

                    // 模块和权限信息
                    foreach (var module in modules.Where(m => m.module_category == category))
                    {
                        CheckBoxObject obj = new CheckBoxObject
                        {
                            Title = module.module_name,
                            Text = module.module_name,
                            Value = module.module_id.ToString()
                        };

                        if (!string.IsNullOrEmpty(module.module_roles))
                        {
                            string[] role_codes = module.module_roles.Split(',').Where(m => !string.IsNullOrEmpty(m)).ToArray();

                            if (role_codes != null && role_codes.Count() > 0)
                            {
                                obj.Datas = new List<SelectListItem>();

                                foreach (var code in role_codes)
                                {
                                    List<ls_role> roles = Biz.Cache.CommonCache.Roles;

                                    ls_role role = roles.Where(r => r.role_code == code).FirstOrDefault();

                                    if (role != null && !string.IsNullOrEmpty(role.role_name))
                                    {
                                        SelectListItem item = new SelectListItem { Text = role.role_name, Value = role.role_code, Selected = false };

                                        if (duty_modules != null && duty_modules.Count > 0)
                                        {
                                            // 判断是否选择
                                            ls_duty_module duty_module = duty_modules.Where(dm => dm.module_id == module.module_id).FirstOrDefault();

                                            if (duty_module != null && duty_module.duty_module_roles.Contains(role.role_code))
                                            {
                                                item.Selected = true;
                                            }
                                        }

                                        obj.Datas.Add(item);
                                    }
                                }

                                objs.Add(obj);
                            }
                        }
                    }
                }

                ViewBag.Categories = categories;
                ViewBag.CheckBoxDatas = objs;

                if (model == null)
                {
                    model = new ls_duty { duty_id = 0 };
                }

                return View(model);
            }

            return Content("参数有误");
        }

        /// <summary>
        /// 角色权限编辑
        /// </summary>
        /// <param name="duty_id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DutyModule(ls_duty model, string[] modules, string[] duty_roles)
        {
            // 无需验证的字段
            //ModelState.Remove("user_old_password");

            bool result = false;

            Common.JsonData<ls_duty_module> data = new Common.JsonData<ls_duty_module>
            {
                Message = "操作失败！"
            };

            // 验证是否全部通过
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    // 删除角色所有的模块
                    if (Biz.ls_duty_moduleBiz.Instance.Delete(model.duty_id))
                    {
                        List<int> duty_modules = new List<int>();

                        foreach (var duty_role in duty_roles.Where(r => !string.IsNullOrEmpty(r)))
                        {
                            string[] module_roles = duty_role.Split('_').Where(r => !string.IsNullOrEmpty(r)).ToArray();

                            int module_id = 0;

                            if (module_roles != null && module_roles.Count() == 2 && int.TryParse(module_roles[0], out module_id))
                            {
                                duty_modules.Add(module_id);
                            }
                        }

                        foreach (var module_id in duty_modules)
                        {
                            // 修改角色权限信息
                            ls_duty_module duty_module = new ls_duty_module();

                            duty_module.duty_id = model.duty_id;
                            duty_module.module_id = module_id;

                            List<string> roles = new List<string>();

                            foreach (var role in duty_roles.Where(r => !string.IsNullOrEmpty(r)))
                            {
                                string[] module_roles = role.Split('_').Where(r => !string.IsNullOrEmpty(r)).ToArray();

                                if (module_roles != null && module_roles.Count() == 2 && module_roles[0] == module_id.ToString())
                                {
                                    roles.Add(module_roles[1]);
                                }
                            }

                            if (roles.Count > 0)
                            {
                                duty_module.duty_module_roles = string.Join(",", roles);

                                if (Biz.ls_duty_moduleBiz.Instance.AddModel(duty_module))
                                {
                                    Common.Logger.Info("添加角色权限成功，模块ID：" + module_id);
                                }
                            }
                        }

                        result = true;
                        data.Message = "设置角色权限成功！";
                    }
                }
            }

            data.Flag = result;

            return Json(data);
        }
    }
}
