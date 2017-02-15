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
    /// yj_teacher 业务
    /// <summary>
    public class yj_teacherBiz : BaseBiz<Models.yj_teacher, yj_teacher>
    {
        /// <summary>
        /// yj_teacherBiz 私有实例
        /// </summary>
        private static yj_teacherBiz instance;

        /// <summary>
        /// yj_teacherBiz 实例
        /// </summary>
        public static yj_teacherBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new yj_teacherBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 分页获取 yj_teacher 信息
        /// </summary>
        public IEnumerable<Models.yj_teacher> GetList(Models.yj_teacher model, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;

            List<Models.yj_teacher> teachers = null;

            try
            {
                // 查询条件
                Expression<Func<yj_teacher, bool>> predicate = PredicateBuilder.True<yj_teacher>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.teacher_name))
                    {
                        predicate = predicate.And(p => p.teacher_name.Contains(model.teacher_name));
                    }
                }

                // 排序
                Expression<Func<yj_teacher, int>> orderby = r => r.teacher_id;

                teachers = GetObjects(predicate, orderby, true, pageIndex, pageSize, out totalCount).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 teacher 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (teachers == null)
            {
                teachers = new List<Models.yj_teacher>();
            }

            return teachers;
        }

        /// <summary>
        /// 获取 yj_teacher 信息
        /// </summary>
        public IEnumerable<Models.yj_teacher> GetList(Models.yj_teacher model)
        {
            List<Models.yj_teacher> teachers = null;

            try
            {
                // 查询条件
                Expression<Func<yj_teacher, bool>> predicate = PredicateBuilder.True<yj_teacher>();

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.teacher_name))
                    {
                        predicate = predicate.And(p => p.teacher_name.Contains(model.teacher_name));
                    }
                }

                // 排序
                Expression<Func<yj_teacher, int>> orderby = r => r.teacher_id;

                teachers = GetObjects(predicate, orderby, true).ToList();
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取 teacher 信息，ERROR：", ex);
            }

            // 为空时，给默认
            if (teachers == null)
            {
                teachers = new List<Models.yj_teacher>();
            }

            return teachers;
        }

        /// <summary>
        /// 通过Id获取 yj_teacher 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.yj_teacher GetModelById(int teacher_id)
        {
            return GetObject(s => s.teacher_id == teacher_id);
        }

        /// <summary>
        /// 添加 yj_teacher 信息
        /// </summary>
        /// <returns></returns>
        public bool AddModel(Models.yj_teacher model)
        {
            return AddObject(model);
        }

        /// <summary>
        /// 修改 yj_teacher 信息
        /// </summary>
        /// <returns></returns>
        public bool EditModel(Models.yj_teacher model)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.yj_teacher.Where(u => u.teacher_id == model.teacher_id).Update(u => new yj_teacher
                    {
                        teacher_name = model.teacher_name,
                        teacher_description = model.teacher_description,
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
                Common.Logger.Error("修改 teacher 出错，ERROR：", ex);
            }

            return false;
        }

        /// <summary>
        /// 删除 yj_teacher 信息
        /// </summary>
        /// <returns></returns>
        public bool Delete(int teacher_id)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    int result = db.yj_teacher.Where(u => u.teacher_id == teacher_id).Update(u => new yj_teacher { is_del = 1 });

                    if (result >= 0)
                    {
                        // 删除成功
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("删除 teacher 出错，ERROR：", ex);
            }

            return false;
        }
    }
}