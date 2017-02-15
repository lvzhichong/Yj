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
    public class TeacherController : BaseAuthorizeController
    {
        /// <summary>
        /// 系统教师
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSearch"></param>
        /// <returns></returns>
        public ActionResult Index(yj_teacher model, string isSearch)
        {
            int pageIndex = 1;

            PagedList<yj_teacher> pagerModel = GetTeachers(model, pageIndex);

            //返回数据
            if (!string.IsNullOrWhiteSpace(isSearch) && isSearch == "1")
            {
                return PartialView("TeacherListPartial", pagerModel);
            }

            return View(pagerModel);
        }

        /// <summary>
        /// 系统教师
        /// </summary>
        /// <param name="model"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(yj_teacher model, int? page = 1)
        {
            int pageIndex = page ?? 1;

            PagedList<yj_teacher> pagerModel = GetTeachers(model, pageIndex);

            return PartialView("TeacherListPartial", pagerModel);
        }

        /// <summary>
        /// 获取教师数据
        /// </summary>
        /// <returns></returns>
        private PagedList<yj_teacher> GetTeachers(yj_teacher model, int pageIndex)
        {
            int totalRow = 0;
            int pageSize = Common.Config.PageSize;

            PagedList<yj_teacher> pagerModel = yj_teacherBiz.Instance.GetList(model, pageIndex - 1, pageSize, out totalRow).AsQueryable().ToPagedList(1, pageSize);

            if (pagerModel != null)
            {
                pagerModel.TotalItemCount = totalRow;
                pagerModel.CurrentPageIndex = pageIndex;
            }

            return pagerModel;
        }

        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult EditTeacher(int? teacher_id)
        {
            yj_teacher model = new yj_teacher { teacher_id = 0 };

            if (teacher_id != null)
            {
                model = Biz.yj_teacherBiz.Instance.GetModelById(teacher_id.Value);
            }

            return View(model);
        }

        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTeacher(yj_teacher model)
        {
            bool result = false;

            Common.JsonData<yj_teacher> data = new Common.JsonData<yj_teacher>
            {
                Message = "操作失败！"
            };

            // 验证是否全部通过
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["teacher_id"]))
                    {
                        // 修改教师信息
                        result = Biz.yj_teacherBiz.Instance.EditModel(model);

                        if (result)
                        {
                            data.Message = "修改教师成功！";
                        }
                    }
                    else
                    {
                        // 添加教师信息
                        result = Biz.yj_teacherBiz.Instance.AddModel(model);

                        if (result)
                        {
                            data.Message = "添加教师成功！";
                        }
                    }
                }
            }

            data.Flag = result;

            return Json(data);
        }

        /// <summary>
        /// 删除教师
        /// </summary>
        /// <param name="teacher_id"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteTeacher(int? teacher_id)
        {
            bool result = false;

            if (teacher_id != null)
            {
                result = Biz.yj_teacherBiz.Instance.Delete(teacher_id.Value);
            }

            return result;
        }

        /// <summary>
        /// 教师名是否存在
        /// </summary>
        /// <returns></returns>
        public ActionResult IsExistTeacherName(int teacher_id, string teacher_name)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
