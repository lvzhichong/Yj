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
    /// ls_duty_module 业务
    /// </summary>
    public class ls_duty_moduleBiz : BaseBiz<Models.ls_duty_module, ls_duty_module>
    {
        /// <summary>
        /// ls_duty_moduleBiz 私有实例
        /// </summary>
        private static ls_duty_moduleBiz instance;

        /// <summary>
        /// ls_duty_moduleBiz 实例
        /// </summary>
        public static ls_duty_moduleBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ls_duty_moduleBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 获取 ls_duty_module 信息
        /// </summary>
        public IEnumerable<Models.ls_duty_module> GetList(int duty_id)
        {
            List<Models.ls_duty_module> duty_modules = null;

            try
            {
                // 查询条件
                Expression<Func<ls_duty_module, bool>> predicate = PredicateBuilder.True<ls_duty_module>();

                predicate = predicate.And(p => p.duty_id == duty_id);

                // 排序
                Expression<Func<ls_duty_module, int>> orderby = r => r.id;

                duty_modules = GetObjects(predicate, orderby, false).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取 duty_modules 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (duty_modules == null)
            {
                duty_modules = new List<Models.ls_duty_module>();
            }

            return duty_modules;
        }

        /// <summary>
        /// 添加 ls_duty_module 信息
        /// </summary>
        /// <returns></returns>
        public bool AddModel(Models.ls_duty_module model)
        {
            return AddObject(model);
        }

        /// <summary>
        /// 修改 ls_duty_module 信息
        /// </summary>
        /// <returns></returns>
        public bool EditModel(Models.ls_duty_module model)
        {
            return false;
        }

        /// <summary>
        /// 删除 ls_duty_module 信息
        /// </summary>
        /// <returns></returns>
        public bool Delete(int duty_id)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.ls_duty_module.Where(u => u.duty_id == duty_id).Delete();

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
                Common.Logger.Error("删除角色权限出错，ERROR：", ex);
            }

            return false;
        }
    }
}