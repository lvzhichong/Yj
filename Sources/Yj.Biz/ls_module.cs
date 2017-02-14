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
    /// ls_module 业务
    /// <summary>
    public class ls_moduleBiz : BaseBiz<Models.ls_module, ls_module>
    {
        /// <summary>
        /// ls_moduleBiz 私有实例
        /// </summary>
        private static ls_moduleBiz instance;

        /// <summary>
        /// ls_moduleBiz 实例
        /// </summary>
        public static ls_moduleBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ls_moduleBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 分页获取 ls_module 信息
        /// </summary>
        public IEnumerable<Models.ls_module> GetList(Models.ls_module model, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;

            List<Models.ls_module> modules = null;

            try
            {
                // 查询条件
                Expression<Func<ls_module, bool>> predicate = PredicateBuilder.True<ls_module>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.module_name))
                    {
                        predicate = predicate.And(p => p.module_name.Contains(model.module_name));
                    }
                }

                // 排序
                Expression<Func<ls_module, int>> orderby = r => r.module_id;

                modules = GetObjects(predicate, orderby, true, pageIndex, pageSize, out totalCount).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 module 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (modules == null)
            {
                modules = new List<Models.ls_module>();
            }

            return modules;
        }

        /// <summary>
        /// 获取 ls_module 信息
        /// </summary>
        public IEnumerable<Models.ls_module> GetList(Models.ls_module model = null)
        {
            List<Models.ls_module> modules = null;

            try
            {
                // 查询条件
                Expression<Func<ls_module, bool>> predicate = PredicateBuilder.True<ls_module>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.module_name))
                    {
                        predicate = predicate.And(p => p.module_name.Contains(model.module_name));
                    }
                }

                // 排序
                Expression<Func<ls_module, int>> orderby = r => r.module_id;

                modules = GetObjects(predicate, orderby, true).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取 module 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (modules == null)
            {
                modules = new List<Models.ls_module>();
            }

            return modules;
        }

        /// <summary>
        /// 通过Id获取 ls_module 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.ls_module GetModelById(int module_id)
        {
            var module = GetObject(s => s.module_id == module_id);

            if (module == null)
            {
                return new Models.ls_module();
            }

            return module;
        }

        /// <summary>
        /// 添加 ls_module 信息
        /// </summary>
        /// <returns></returns>
        public bool AddModel(Models.ls_module model)
        {
            return AddObject(model);
        }

        /// <summary>
        /// 修改 ls_module 信息
        /// </summary>
        /// <returns></returns>
        public bool EditModel(Models.ls_module model)
        {
            if (model != null)
            {
                try
                {
                    using (Ls_dataContext db = new Ls_dataContext())
                    {
                        int result = db.ls_module.Where(u => u.module_id == model.module_id)
                                               .Update(u => new ls_module
                                               {
                                                   module_name = model.module_name,
                                                   module_path = model.module_path,
                                                   module_roles = model.module_roles,
                                                   module_category = model.module_category
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
                    Common.Logger.Error("修改模块出错，ERROR：", ex);
                }
            }

            return false;
        }

        /// <summary>
        /// 删除 ls_module 信息
        /// </summary>
        /// <returns></returns>
        public bool Delete(int module_id)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.ls_module.Where(u => u.module_id == module_id).Delete();

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
                Common.Logger.Error("删除模块出错，ERROR：", ex);
            }

            return false;
        }
    }
}