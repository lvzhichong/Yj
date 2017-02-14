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
    /// ls_log 业务
    /// <summary>
    public class ls_logBiz : BaseBiz<Models.ls_log, ls_log>
    {
        /// <summary>
        /// ls_logBiz 私有实例
        /// </summary>
        private static ls_logBiz instance;

        /// <summary>
        /// ls_logBiz 实例
        /// </summary>
        public static ls_logBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ls_logBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 分页获取 ls_log 信息
        /// </summary>
        public IEnumerable<Models.ls_log> GetList(Models.ls_log model, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;

            List<Models.ls_log> logs = null;

            try
            {
                // 查询条件
                Expression<Func<ls_log, bool>> predicate = PredicateBuilder.True<ls_log>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.log_description))
                    {
                        predicate = predicate.And(p => p.log_description.Contains(model.log_description));
                    }
                }

                // 排序
                Expression<Func<ls_log, int>> orderby = r => r.log_id;

                logs = GetObjects(predicate, orderby, true, pageIndex, pageSize, out totalCount).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 log 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (logs == null)
            {
                logs = new List<Models.ls_log>();
            }

            return logs;
        }

        /// <summary>
        /// 获取 ls_log 信息
        /// </summary>
        public IEnumerable<Models.ls_log> GetList(Models.ls_log model)
        {
            List<Models.ls_log> logs = null;

            try
            {
                // 查询条件
                Expression<Func<ls_log, bool>> predicate = PredicateBuilder.True<ls_log>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.log_description))
                    {
                        predicate = predicate.And(p => p.log_description.Contains(model.log_description));
                    }
                }

                // 排序
                Expression<Func<ls_log, int>> orderby = r => r.log_id;

                logs = GetObjects(predicate, orderby, true).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取 log 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (logs == null)
            {
                logs = new List<Models.ls_log>();
            }

            return logs;
        }

        /// <summary>
        /// 通过Id获取 ls_log 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.ls_log GetModelById(int log_id)
        {
            var log = GetObject(s => s.log_id == log_id);

            if (log == null)
            {
                return new Models.ls_log();
            }

            return log;
        }

        /// <summary>
        /// 添加 ls_log 信息
        /// </summary>
        /// <returns></returns>
        public bool AddModel(Models.ls_log model)
        {
            return AddObject(model);
        }
    }
}