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
    /// ls_role 业务
    /// <summary>
    public class ls_roleBiz : BaseBiz<Models.ls_role, ls_role>
    {
        /// <summary>
        /// ls_roleBiz 私有实例
        /// </summary>
        private static ls_roleBiz instance;

        /// <summary>
        /// ls_roleBiz 实例
        /// </summary>
        public static ls_roleBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ls_roleBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 分页获取 ls_role 信息
        /// </summary>
        public IEnumerable<Models.ls_role> GetList(Models.ls_role model, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;

            List<Models.ls_role> roles = null;

            try
            {
                // 查询条件
                Expression<Func<ls_role, bool>> predicate = PredicateBuilder.True<ls_role>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.role_name))
                    {
                        predicate = predicate.And(p => p.role_name.Contains(model.role_name));
                    }
                }

                // 排序
                Expression<Func<ls_role, int>> orderby = r => r.role_id;

                roles = GetObjects(predicate, orderby, true, pageIndex, pageSize, out totalCount).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 role 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (roles == null)
            {
                roles = new List<Models.ls_role>();
            }

            return roles;
        }

        /// <summary>
        /// 获取 ls_role 信息
        /// </summary>
        public IEnumerable<Models.ls_role> GetList(Models.ls_role model)
        {
            List<Models.ls_role> roles = null;

            try
            {
                // 查询条件
                Expression<Func<ls_role, bool>> predicate = PredicateBuilder.True<ls_role>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.role_name))
                    {
                        predicate = predicate.And(p => p.role_name.Contains(model.role_name));
                    }
                }

                // 排序
                Expression<Func<ls_role, int>> orderby = r => r.role_id;

                roles = GetObjects(predicate, orderby, true).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取 role 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (roles == null)
            {
                roles = new List<Models.ls_role>();
            }

            return roles;
        }

        /// <summary>
        /// 通过Id获取 ls_role 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.ls_role GetModelById(int role_id)
        {
            var role = GetObject(s => s.role_id == role_id);

            if (role == null)
            {
                return new Models.ls_role();
            }

            return role;
        }

        /// <summary>
        /// 添加 ls_role 信息
        /// </summary>
        /// <returns></returns>
        public bool AddModel(Models.ls_role model)
        {
            return AddObject(model);
        }

        /// <summary>
        /// 修改 ls_role 信息
        /// </summary>
        /// <returns></returns>
        public bool EditModel(Models.ls_role model)
        {
            if (model != null)
            {
                try
                {
                    using (Ls_dataContext db = new Ls_dataContext())
                    {
                        int result = db.ls_role.Where(u => u.role_id == model.role_id)
                                               .Update(u => new ls_role
                                               {
                                                   role_name = model.role_name,
                                                   role_code = model.role_code
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
                    Common.Logger.Error("修改权限出错，ERROR：", ex);
                }
            }

            return false;
        }

        /// <summary>
        /// 删除 ls_role 信息
        /// </summary>
        /// <returns></returns>
        public bool Delete(int role_id)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.ls_role.Where(u => u.role_id == role_id).Delete();

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
                Common.Logger.Error("删除权限出错，ERROR：", ex);
            }

            return false;
        }
    }
}