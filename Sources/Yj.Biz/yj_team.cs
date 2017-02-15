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
    /// yj_team 业务
    /// <summary>
    public class yj_teamBiz : BaseBiz<Models.yj_team, yj_team>
    {
        /// <summary>
        /// yj_teamBiz 私有实例
        /// </summary>
        private static yj_teamBiz instance;

        /// <summary>
        /// yj_teamBiz 实例
        /// </summary>
        public static yj_teamBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new yj_teamBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 分页获取 yj_team 信息
        /// </summary>
        public IEnumerable<Models.yj_team> GetList(Models.yj_team model, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;

            List<Models.yj_team> teams = null;

            try
            {
                // 查询条件
                Expression<Func<yj_team, bool>> predicate = PredicateBuilder.True<yj_team>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.team_name))
                    {
                        predicate = predicate.And(p => p.team_name.Contains(model.team_name));
                    }
                }

                // 排序
                Expression<Func<yj_team, int>> orderby = r => r.team_id;

                teams = GetObjects(predicate, orderby, true, pageIndex, pageSize, out totalCount).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 team 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (teams == null)
            {
                teams = new List<Models.yj_team>();
            }

            return teams;
        }

        /// <summary>
        /// 获取 yj_team 信息
        /// </summary>
        public IEnumerable<Models.yj_team> GetList(Models.yj_team model)
        {
            List<Models.yj_team> teams = null;

            try
            {
                // 查询条件
                Expression<Func<yj_team, bool>> predicate = PredicateBuilder.True<yj_team>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.team_name))
                    {
                        predicate = predicate.And(p => p.team_name.Contains(model.team_name));
                    }
                }

                // 排序
                Expression<Func<yj_team, int>> orderby = r => r.team_id;

                teams = GetObjects(predicate, orderby, true).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 team 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (teams == null)
            {
                teams = new List<Models.yj_team>();
            }

            return teams;
        }

        /// <summary>
        /// 通过Id获取 yj_team 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.yj_team GetModelById(int team_id)
        {
            return GetObject(s => s.team_id == team_id);
        }

        /// <summary>
        /// 添加 yj_team 信息
        /// </summary>
        /// <returns></returns>
        public bool AddModel(Models.yj_team model)
        {
            return AddObject(model);
        }

        /// <summary>
        /// 修改 yj_team 信息
        /// </summary>
        /// <returns></returns>
        public bool EditModel(Models.yj_team model)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.yj_team.Where(u => u.team_id == model.team_id).Update(u => new yj_team
                    {
                        team_name = model.team_name,
                        team_description = model.team_description,
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
                Common.Logger.Error("修改 team 出错，ERROR：", ex);
            }

            return false;
        }

        /// <summary>
        /// 删除 yj_team 信息
        /// </summary>
        /// <returns></returns>
        public bool Delete(int team_id)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.yj_team.Where(u => u.team_id == team_id).Update(u => new yj_team { is_del = 1 });

                    if (result >= 0)
                    {
                        // 删除成功
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("删除 team 出错，ERROR：", ex);
            }

            return false;
        }
    }
}