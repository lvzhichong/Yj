using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.SqlClient;
//
using AutoMapper;
//
using System.Transactions;
//
using EntityFramework.Extensions;
//
using Yj.DataAccess.Models;
//
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Yj.Biz
{
    /// <summary>
    /// yj_task 业务
    /// <summary>
    public class yj_taskBiz : BaseBiz<Models.yj_task, yj_task>
    {
        /// <summary>
        /// yj_taskBiz 私有实例
        /// </summary>
        private static yj_taskBiz instance;

        /// <summary>
        /// yj_taskBiz 实例
        /// </summary>
        public static yj_taskBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new yj_taskBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 分页获取 yj_task 信息
        /// </summary>
        public IEnumerable<Models.yj_task> GetList(Models.yj_task model, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;

            List<Models.yj_task> tasks = null;

            try
            {
                // 查询条件
                Expression<Func<yj_task, bool>> predicate = PredicateBuilder.True<yj_task>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.task_name))
                    {
                        predicate = predicate.And(p => p.task_name.Contains(model.task_name));
                    }
                }

                // 排序
                Expression<Func<yj_task, int>> orderby = r => r.task_id;

                tasks = GetObjects(predicate, orderby, true, pageIndex, pageSize, out totalCount).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 task 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (tasks == null)
            {
                tasks = new List<Models.yj_task>();
            }

            return tasks;
        }

        /// <summary>
        /// 获取 yj_task 信息
        /// </summary>
        public IEnumerable<Models.yj_task> GetList(Models.yj_task model)
        {
            List<Models.yj_task> tasks = null;

            try
            {
                // 查询条件
                Expression<Func<yj_task, bool>> predicate = PredicateBuilder.True<yj_task>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.task_name))
                    {
                        predicate = predicate.And(p => p.task_name.Contains(model.task_name));
                    }
                }

                // 排序
                Expression<Func<yj_task, int>> orderby = r => r.task_id;

                tasks = GetObjects(predicate, orderby, true).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 task 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (tasks == null)
            {
                tasks = new List<Models.yj_task>();
            }

            return tasks;
        }

        /// <summary>
        /// 通过Id获取 yj_task 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.yj_task GetModelById(int task_id)
        {
            return GetObject(s => s.task_id == task_id);
        }

        /// <summary>
        /// 添加 yj_task 信息
        /// </summary>
        /// <returns></returns>
        public bool AddModel(Models.yj_task model)
        {
            return AddObject(model);
        }

        /// <summary>
        /// 修改 yj_task 信息
        /// </summary>
        /// <returns></returns>
        public bool EditModel(Models.yj_task model)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.yj_task.Where(u => u.task_id == model.task_id).Update(u => new yj_task
                    {
                        task_name = model.task_name,
                        task_description = model.task_description,
                        modify_date = DateTime.Now
                    });

                    if (result >= 0)
                    {
                        // 删除成功
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("修改 task 出错，ERROR：", ex);
            }

            return false;
        }

        /// <summary>
        /// 删除 yj_task 信息
        /// </summary>
        /// <returns></returns>
        public bool Delete(int task_id)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.yj_task.Where(u => u.task_id == task_id).Update(u => new yj_task { is_del = 1 });

                    if (result >= 0)
                    {
                        // 删除成功
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("删除 task 出错，ERROR：", ex);
            }

            return false;
        }
    }
}