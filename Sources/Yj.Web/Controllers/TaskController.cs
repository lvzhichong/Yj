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
    public class TaskController : BaseAuthorizeController
    {
        /// <summary>
        /// 系统任务
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSearch"></param>
        /// <returns></returns>
        public ActionResult Index(yj_task model, string isSearch)
        {
            int pageIndex = 1;

            PagedList<yj_task> pagerModel = GetTasks(model, pageIndex);

            //返回数据
            if (!string.IsNullOrWhiteSpace(isSearch) && isSearch == "1")
            {
                return PartialView("TaskListPartial", pagerModel);
            }

            return View(pagerModel);
        }

        /// <summary>
        /// 系统任务
        /// </summary>
        /// <param name="model"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(yj_task model, int? page = 1)
        {
            int pageIndex = page ?? 1;

            PagedList<yj_task> pagerModel = GetTasks(model, pageIndex);

            return PartialView("TaskListPartial", pagerModel);
        }

        /// <summary>
        /// 获取任务数据
        /// </summary>
        /// <returns></returns>
        private PagedList<yj_task> GetTasks(yj_task model, int pageIndex)
        {
            int totalRow = 0;
            int pageSize = Common.Config.PageSize;

            PagedList<yj_task> pagerModel = yj_taskBiz.Instance.GetList(model, pageIndex - 1, pageSize, out totalRow).AsQueryable().ToPagedList(1, pageSize);

            if (pagerModel != null)
            {
                pagerModel.TotalItemCount = totalRow;
                pagerModel.CurrentPageIndex = pageIndex;
            }

            return pagerModel;
        }

        /// <summary>
        /// 修改任务信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult EditTask(int? task_id)
        {
            yj_task model = new yj_task { task_id = 0 };

            if (task_id != null)
            {
                model = Biz.yj_taskBiz.Instance.GetModelById(task_id.Value);
            }

            return View(model);
        }

        /// <summary>
        /// 修改任务信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTask(yj_task model)
        {
            bool result = false;

            Common.JsonData<yj_task> data = new Common.JsonData<yj_task>
            {
                Message = "操作失败！"
            };

            // 验证是否全部通过
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["task_id"]))
                    {
                        // 修改任务信息
                        result = Biz.yj_taskBiz.Instance.EditModel(model);

                        if (result)
                        {
                            data.Message = "修改任务成功！";
                        }
                    }
                    else
                    {
                        // 添加任务信息
                        result = Biz.yj_taskBiz.Instance.AddModel(model);

                        if (result)
                        {
                            data.Message = "添加任务成功！";
                        }
                    }
                }
            }

            data.Flag = result;

            return Json(data);
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="task_id"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteTask(int? task_id)
        {
            bool result = false;

            if (task_id != null)
            {
                result = Biz.yj_taskBiz.Instance.Delete(task_id.Value);
            }

            return result;
        }

        /// <summary>
        /// 任务名是否存在
        /// </summary>
        /// <returns></returns>
        public ActionResult IsExistTaskName(int task_id, string task_name)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
