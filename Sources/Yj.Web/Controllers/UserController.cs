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
    public class UserController : BaseAuthorizeController
    {
        /// <summary>
        /// 系统管理员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSearch"></param>
        /// <returns></returns>
        public ActionResult Index(ls_user model, string isSearch)
        {
            int pageIndex = 1;

            PagedList<ls_user> pagerModel = GetUsers(model, pageIndex);

            //返回数据
            if (!string.IsNullOrWhiteSpace(isSearch) && isSearch == "1")
            {
                return PartialView("UserListPartial", pagerModel);
            }

            return View(pagerModel);
        }

        /// <summary>
        /// 系统管理员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(ls_user model, int? page = 1)
        {
            int pageIndex = page ?? 1;

            PagedList<ls_user> pagerModel = GetUsers(model, pageIndex);

            return PartialView("UserListPartial", pagerModel);
        }

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        private PagedList<ls_user> GetUsers(ls_user model, int pageIndex)
        {
            int totalRow = 0;
            int pageSize = Common.Config.PageSize;

            PagedList<ls_user> pagerModel = ls_userBiz.Instance.GetList(model, pageIndex - 1, pageSize, out totalRow).AsQueryable().ToPagedList(1, pageSize);

            if (pagerModel != null)
            {
                pagerModel.TotalItemCount = totalRow;
                pagerModel.CurrentPageIndex = pageIndex;
            }

            return pagerModel;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult EditUser(int? user_id)
        {
            ls_user model = new ls_user { user_id = 0 };

            if (user_id != null)
            {
                model = Biz.ls_userBiz.Instance.GetModelById(user_id.Value);
            }

            // 角色
            IEnumerable<ls_duty> dutys = ls_dutyBiz.Instance.GetList();

            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Text = "-- 请选择 --" } };

            if (dutys != null)
            {
                foreach (var duty in dutys)
                {
                    items.Add(new SelectListItem { Text = duty.duty_name, Value = duty.duty_id.ToString() });
                }
            }

            ViewBag.Dutys = items;

            return View(model);
        }

        /// <summary>
        /// 修改定义信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditUser(ls_user model)
        {
            // 无需验证的字段
            ModelState.Remove("user_old_password");

            bool result = false;

            Common.JsonData<ls_user> data = new Common.JsonData<ls_user>
            {
                Message = "操作失败！"
            };

            // 验证是否全部通过
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["user_id"]))
                    {
                        // 修改用户信息
                        result = Biz.ls_userBiz.Instance.EditModel(model);

                        if (result)
                        {
                            data.Message = "修改用户成功！";
                        }
                    }
                    else
                    {
                        // 添加用户信息
                        // 默认值修改
                        model.is_approved = true;
                        model.create_date = DateTime.Now;
                        model.last_login_date = DateTime.Now;

                        result = Biz.ls_userBiz.Instance.AddModel(model);

                        if (result)
                        {
                            data.Message = "添加用户成功！";
                        }
                    }
                }
            }

            data.Flag = result;

            return Json(data);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword(int? user_id)
        {
            ls_user model = new ls_user { user_id = 0 };

            if (user_id != null)
            {
                model = Biz.ls_userBiz.Instance.GetModelById(user_id.Value);
            }

            return View(model);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(ls_user model)
        {
            // 无需验证的字段
            ModelState.Remove("email");

            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    // 创建用户信息
                    bool result = false;

                    if (!string.IsNullOrEmpty(Request.QueryString["userId"]))
                    {
                        result = Biz.ls_userBiz.Instance.EditModel(model);
                    }

                    if (result)
                    {
                        return RedirectToAction("Index", "ls_user", null);
                    }
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        /// <summary>
        /// 锁定用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public bool LockUser(int? userId, bool? is_lock)
        {
            bool result = false;

            if (userId != null && is_lock != null)
            {
                result = Biz.ls_userBiz.Instance.Lock(userId.Value, is_lock.Value);
            }

            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteUser(int? userId)
        {
            bool result = false;

            if (userId != null)
            {
                result = Biz.ls_userBiz.Instance.Delete(userId.Value);
            }

            return result;
        }

        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <returns></returns>
        public ActionResult IsExistUserName(int user_id, string user_name)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 邮箱是否存在
        /// </summary>
        /// <returns></returns>
        public ActionResult IsExistEmail(int user_id, string email)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
