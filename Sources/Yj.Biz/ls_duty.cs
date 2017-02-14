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
    /// ls_duty 业务
    /// </summary>
    public class ls_dutyBiz : BaseBiz<Models.ls_duty, ls_duty>
    {
        /// <summary>
        /// ls_dutyBiz 私有实例
        /// </summary>
        private static ls_dutyBiz instance;

        /// <summary>
        /// ls_dutyBiz 实例
        /// </summary>
        public static ls_dutyBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ls_dutyBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 分页获取 ls_duty 信息
        /// </summary>
        public IEnumerable<Models.ls_duty> GetList(Models.ls_duty model, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;

            List<Models.ls_duty> dutys = null;

            try
            {
                // 查询条件
                Expression<Func<ls_duty, bool>> predicate = PredicateBuilder.True<ls_duty>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.duty_name))
                    {
                        predicate = predicate.And(p => p.duty_name.Contains(model.duty_name));
                    }
                }

                //predicate = predicate.And(p => p.is_del == false);

                // 排序
                Expression<Func<ls_duty, int>> orderby = r => r.duty_id;

                dutys = GetObjects(predicate, orderby, true, pageIndex, pageSize, out totalCount).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 User 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (dutys == null)
            {
                dutys = new List<Models.ls_duty>();
            }

            return dutys;
        }

        /// <summary>
        /// 获取 ls_duty 信息
        /// </summary>
        public IEnumerable<Models.ls_duty> GetList(Models.ls_duty model = null)
        {
            List<Models.ls_duty> dutys = null;

            try
            {
                // 查询条件
                Expression<Func<ls_duty, bool>> predicate = PredicateBuilder.True<ls_duty>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.duty_name))
                    {
                        predicate = predicate.And(p => p.duty_name.Contains(model.duty_name));
                    }
                }

                // 排序
                Expression<Func<ls_duty, int>> orderby = r => r.duty_id;

                dutys = GetObjects(predicate, orderby, true).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取 duty 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (dutys == null)
            {
                dutys = new List<Models.ls_duty>();
            }

            return dutys;
        }

        /// <summary>
        /// 通过Id获取 ls_duty 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.ls_duty GetModelById(int duty_id)
        {
            var duty = GetObject(s => s.duty_id == duty_id);

            if (duty == null)
            {
                return new Models.ls_duty();
            }

            return duty;
        }

        /// <summary>
        /// 添加 ls_duty 信息
        /// </summary>
        /// <returns></returns>
        public bool AddModel(Models.ls_duty model)
        {
            return AddObject(model);
        }

        /// <summary>
        /// 修改 ls_duty 信息
        /// </summary>
        /// <returns></returns>
        public bool EditModel(Models.ls_duty model)
        {
            if (model != null)
            {
                try
                {
                    using (Ls_dataContext db = new Ls_dataContext())
                    {
                        int result = db.ls_duty.Where(u => u.duty_id == model.duty_id)
                                               .Update(u => new ls_duty
                                               {
                                                   duty_name = model.duty_name,
                                                   description = model.description
                                               });

                        if (result > 0)
                        {
                            // 写日志

                            // 修改成功
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Common.Logger.Error("修改角色出错，ERROR：", ex);
                }
            }

            return false;
        }

        /// <summary>
        /// 删除 ls_duty 信息
        /// </summary>
        /// <returns></returns>
        public bool Delete(int duty_id)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.ls_duty.Where(u => u.duty_id == duty_id).Delete();

                    if (result >= 0)
                    {
                        // 写日志

                        // 删除成功
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("删除角色出错，ERROR：", ex);
            }

            return false;
        }
    }
}