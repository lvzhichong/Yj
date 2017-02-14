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
    /// ls_user 业务
    /// <summary>
    public class ls_userBiz : BaseBiz<Models.ls_user, ls_user>
    {
        /// <summary>
        /// ls_userBiz 私有实例
        /// </summary>
        private static ls_userBiz instance;

        /// <summary>
        /// ls_userBiz 实例
        /// </summary>
        public static ls_userBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ls_userBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 分页获取 ls_user 信息
        /// </summary>
        public IEnumerable<Models.ls_user> GetList(Models.ls_user model, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;

            List<Models.ls_user> users = null;

            try
            {
                // 查询条件
                Expression<Func<ls_user, bool>> predicate = PredicateBuilder.True<ls_user>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.user_name))
                    {
                        predicate = predicate.And(p => p.user_name.Contains(model.user_name));
                    }
                }

                predicate = predicate.And(p => p.is_del == false);

                // 排序
                Expression<Func<ls_user, int>> orderby = r => r.user_id;

                users = GetObjects(predicate, orderby, true, pageIndex, pageSize, out totalCount).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 User 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (users == null)
            {
                users = new List<Models.ls_user>();
            }

            return users;
        }

        /// <summary>
        /// 获取 ls_user 信息
        /// </summary>
        public IEnumerable<Models.ls_user> GetList(Models.ls_user model)
        {
            List<Models.ls_user> users = null;

            try
            {
                // 查询条件
                Expression<Func<ls_user, bool>> predicate = PredicateBuilder.True<ls_user>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.user_name))
                    {
                        predicate = predicate.And(p => p.user_name.Contains(model.user_name));
                    }
                }

                predicate = predicate.And(p => !p.is_del);

                // 排序
                Expression<Func<ls_user, int>> orderby = r => r.user_id;

                users = GetObjects(predicate, orderby, true).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取 User 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (users == null)
            {
                users = new List<Models.ls_user>();
            }

            return users;
        }

        /// <summary>
        /// 通过Id获取 ls_user 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.ls_user GetModelById(int user_id)
        {
            var user = GetObject(s => s.user_id == user_id);

            if (user == null)
            {
                return new Models.ls_user();
            }

            return user;
        }

        /// <summary>
        /// 通过user_name获取 ls_user 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.ls_user GetModelByName(string user_name)
        {
            var user = GetObject(s => s.user_name == user_name);

            if (user == null)
            {
                return new Models.ls_user();
            }

            return user;
        }

        /// <summary>
        /// 添加 ls_user 信息
        /// </summary>
        /// <returns></returns>
        public bool AddModel(Models.ls_user model)
        {
            return AddObject(model);
        }

        /// <summary>
        /// 修改 ls_user 信息
        /// </summary>
        /// <returns></returns>
        public bool EditModel(Models.ls_user model)
        {
            if (model != null)
            {
                try
                {
                    using (Ls_dataContext db = new Ls_dataContext())
                    {
                        int result = db.ls_user.Where(u => u.user_id == model.user_id)
                                               .Update(u => new ls_user
                                               {
                                                   duty_id = model.duty_id,
                                                   nick_name = model.nick_name,
                                                   email = model.email,
                                                   user_password = model.user_password,
                                                   modify_date = DateTime.Now
                                               });

                        if (result > 0)
                        {
                            // 写日志

                            // 删除成功
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Common.Logger.Error("删除用户出错，ERROR：", ex);
                }
            }

            return false;
        }

        /// <summary>
        /// 删除 ls_user 信息
        /// </summary>
        /// <returns></returns>
        public bool Delete(int user_id)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.ls_user.Where(u => u.user_id == user_id).Update(u => new ls_user { is_del = true });

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
                Common.Logger.Error("删除用户出错，ERROR：", ex);
            }

            return false;
        }

        /// <summary>
        /// 删除 ls_user 信息
        /// </summary>
        /// <returns></returns>
        public bool Lock(int user_id, bool is_lock)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.ls_user.Where(u => u.user_id == user_id).Update(u => new ls_user { is_lock = !u.is_lock, lock_date = DateTime.Now });

                    if (result > 0)
                    {
                        // 写日志
                        if (is_lock)
                        {
                            // 解锁成功
                        }
                        else
                        {
                            // 锁定成功
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("锁定用户出错，ERROR：", ex);
            }

            return false;
        }

        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="user_password"></param>
        /// <returns></returns>
        public bool ValidateUser(string user_name, string user_password)
        {
            if (!string.IsNullOrEmpty(user_name) && !string.IsNullOrEmpty(user_password))
            {
                var user = GetModelByName(user_name);

                if (user != null && user.user_password == user_password)
                {
                    return true;
                }
            }

            return false;
        }
    }
}