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
            return null;
        }

        /// <summary>
        /// 获取 yj_teacher 信息
        /// </summary>
        public IEnumerable<Models.yj_teacher> GetList(Models.yj_teacher model)
        {
            return null;
        }

        /// <summary>
        /// 通过Id获取 yj_teacher 信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.yj_teacher GetModelById(int id)
        {
            return null; //GetObject(s => s.user_id == sysUserId);
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
            return false;
        }

        /// <summary>
        /// 删除 yj_teacher 信息
        /// </summary>
        /// <returns></returns>
        public bool Delete(int sysUserId)
        {
            return false;
        }
    }
}