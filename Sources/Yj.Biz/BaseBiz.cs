using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//
using System.Transactions;
//
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Yj.DataAccess.Models;
using System.Linq.Expressions;

namespace Yj.Biz
{
    /// <summary>
    /// 业务操作基类
    /// </summary>
    public class BaseBiz<VD, DD>
        where VD : class
        where DD : class
    {
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="predicate">where 条件（必填）</param>
        /// <param name="keySelector">分页（必填）</param>
        /// <param name="isDesc">是否倒序排序（必填）</param>
        /// <param name="pageSize">行数（必填）</param>
        /// <param name="pageIndex">第几页（必填）</param>
        /// <param name="totalRow">总行数（必填）</param>
        /// <returns>List</returns>
        public IEnumerable<VD> GetObjects<DDKey>(Expression<Func<DD, bool>> predicate, Expression<Func<DD, DDKey>> keySelector, bool isDesc, int pageIndex, int pageSize, out int totalRow)
        {
            totalRow = 0;

            // 数据源
            List<VD> datas = new List<VD>();

            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    // Where
                    var query = db.Set<DD>().AsQueryable();
                    if (predicate != null)
                    {
                        query = query.Where(predicate).AsQueryable();
                    }
                    // TotalCount
                    totalRow = query.Count();

                    if (totalRow > 0)
                    {
                        // 排序
                        if (isDesc)
                        {
                            // 倒序
                            query = query.OrderByDescending(keySelector).AsQueryable();
                        }
                        else
                        {
                            // 正序
                            query = query.OrderBy(keySelector).AsQueryable();
                        }
                        // 分页
                        query = query.Skip(pageIndex * pageSize).Take(pageSize);

                        foreach (var data in query)
                        {
                            // 数据转化
                            datas.Add(Mapper.Map<DD, VD>(data));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取数据出错，Error：", ex);
            }

            return datas;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="predicate">where 条件（必填）</param>
        /// <param name="keySelector">分页（必填）</param>
        /// <param name="isDesc">是否倒序排序（必填）</param>
        /// <param name="pageSize">行数（必填）</param>
        /// <param name="pageIndex">第几页（必填）</param>
        /// <param name="totalRow">总行数（必填）</param>
        /// <returns>List</returns>
        public IEnumerable<VD> GetObjects<DDKey>(Expression<Func<DD, bool>> predicate, Expression<Func<DD, DDKey>> keySelector, Expression<Func<DD, VD>> selector, bool isDesc, int pageIndex, int pageSize, out int totalRow)
        {
            totalRow = 0;

            // 数据源
            List<VD> datas = new List<VD>();

            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    // Where
                    var query = db.Set<DD>().AsQueryable();

                    if (predicate != null)
                    {
                        query = query.Where(predicate).AsQueryable();
                    }

                    // TotalCount
                    totalRow = query.Count();

                    if (totalRow > 0)
                    {
                        // 排序
                        if (isDesc)
                        {
                            // 倒序
                            query = query.OrderByDescending(keySelector).AsQueryable();
                        }
                        else
                        {
                            // 正序
                            query = query.OrderBy(keySelector).AsQueryable();
                        }

                        // 分页
                        return query.Skip(pageIndex * pageSize).Take(pageSize).Select(selector).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("分页获取数据出错，Error：", ex);
            }

            return datas;
        }

        /// <summary>
        /// 获取数据出错（不分页）带排序
        /// </summary>
        /// <param name="predicate">where 条件</param>
        /// <returns></returns>
        public IEnumerable<VD> GetObjects<DDKey>(Expression<Func<DD, bool>> predicate = null, Expression<Func<DD, DDKey>> keySelector = null, bool isDesc = true)
        {
            List<VD> datas = new List<VD>();

            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    // Where
                    var query = db.Set<DD>().AsQueryable();

                    if (predicate != null)
                    {
                        query = query.Where(predicate).AsQueryable();
                    }

                    if (keySelector != null)
                    {
                        // 排序
                        if (isDesc)
                        {
                            // 倒序
                            query = query.OrderByDescending(keySelector).AsQueryable();
                        }
                        else
                        {
                            // 正序
                            query = query.OrderBy(keySelector).AsQueryable();
                        }
                    }

                    foreach (var data in query)
                    {
                        // 数据转化
                        datas.Add(Mapper.Map<DD, VD>(data));
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取数据出错（不分页）出错，Error：", ex);
            }

            return datas;
        }

        /// <summary>
        /// 获取数据出错（不分页）
        /// </summary>
        /// <param name="predicate">where 条件</param>
        /// <returns></returns>
        public IEnumerable<VD> GetObjects(Expression<Func<DD, bool>> predicate = null)
        {
            List<VD> datas = new List<VD>();

            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    // Where
                    var query = db.Set<DD>().AsQueryable();

                    if (predicate != null)
                    {
                        query = query.Where(predicate).AsQueryable();
                    }

                    foreach (var data in query)
                    {
                        // 数据转化
                        datas.Add(Mapper.Map<DD, VD>(data));
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取数据出错（不分页）出错，Error：", ex);
            }

            return datas;
        }

        /// <summary>
        /// 获取数据总数（不分页）
        /// </summary>
        /// <param name="predicate">where 条件</param>
        /// <returns></returns>
        public int GetCount(Expression<Func<DD, bool>> predicate = null)
        {
            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    // Where
                    var query = db.Set<DD>().AsQueryable();

                    if (predicate != null)
                    {
                        query = query.Where(predicate).AsQueryable();
                    }

                    return query.Count();
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取数据出错（不分页）出错，Error：", ex);
            }

            return 0;
        }

        /// <summary>
        /// 获取TOP数据带排序，默认倒序
        /// </summary>
        /// <param name="predicate">where 条件</param>
        /// <returns></returns>
        public IEnumerable<VD> GetTOPObjects<DDKey>(int top, Expression<Func<DD, bool>> predicate = null, Expression<Func<DD, DDKey>> keySelector = null, bool isDesc = true)
        {
            List<VD> datas = new List<VD>();

            try
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    // Where
                    var query = db.Set<DD>().AsQueryable();

                    if (predicate != null)
                    {
                        query = query.Where(predicate).AsQueryable();
                    }

                    if (keySelector != null)
                    {
                        // 排序
                        if (isDesc)
                        {
                            // 倒序
                            query = query.OrderByDescending(keySelector).AsQueryable();
                        }
                        else
                        {
                            // 正序
                            query = query.OrderBy(keySelector).AsQueryable();
                        }
                    }

                    if (top > 0)
                    {
                        query = query.Take(top).AsQueryable();
                    }

                    foreach (var data in query)
                    {
                        // 数据转化
                        datas.Add(Mapper.Map<DD, VD>(data));
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取TOP数据出错，Error：", ex);
            }

            return datas;
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="predicate">where 条件</param>
        /// <returns></returns>
        public VD GetObject(Expression<Func<DD, bool>> predicate)
        {
            if (predicate != null)
            {
                try
                {
                    using (Ls_dataContext db = new Ls_dataContext())
                    {
                        // Where
                        var data = db.Set<DD>().Where(predicate).FirstOrDefault();

                        // 数据转化
                        VD v_data = Mapper.Map<DD, VD>(data);

                        return v_data;
                    }
                }
                catch (Exception ex)
                {
                    Common.Logger.Error("获取单个对象数据出错，Error：", ex);
                }
            }

            return null;
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="v_data"></param>
        /// <returns></returns>
        public bool AddObject(VD v_data)
        {
            if (v_data != null)
            {
                try
                {
                    using (Ls_dataContext db = new Ls_dataContext())
                    {
                        DD data = Mapper.Map<VD, DD>(v_data);

                        DbSet set = db.Set(typeof(DD));
                        set.Add(data);
                        db.Configuration.ValidateOnSaveEnabled = false;

                        return db.SaveChanges() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Common.Logger.Error("添加对象出错，ERROR：", ex);
                }
            }

            return false;
        }

        /// <summary>
        /// 删除对象（建议使用EntityFramework.Extended提供的方法）
        /// </summary>
        /// <param name="predicate">where 条件</param>
        /// <returns></returns>
        public bool DeleteObjects(Expression<Func<DD, bool>> predicate)
        {
            if (predicate != null)
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    IEnumerable<DD> datas = db.Set<DD>().Where(predicate);

                    foreach (var data in datas)
                    {
                        DbEntityEntry entry = db.Entry<DD>(data);
                        entry.State = EntityState.Deleted;
                    }
                    return db.SaveChanges() > 0;
                }
            }

            return false;
        }

        /// <summary>
        /// 修改对象（建议使用EntityFramework.Extended提供的方法）
        /// </summary>
        /// <param name="v_data"></param>
        /// <returns></returns>
        public bool ModifyObject(VD v_data)
        {
            if (v_data != null)
            {
                using (Ls_dataContext db = new Ls_dataContext())
                {
                    DD data = Mapper.Map<VD, DD>(v_data);

                    DbEntityEntry entry = db.Entry<DD>(data);
                    entry.State = EntityState.Modified;
                    //entry.Property("").IsModified = true;

                    return db.SaveChanges() > 0;
                }
            }

            return false;
        }

        /// <summary>
        /// EF SQL 语句返回 dataTable
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable SqlQueryForDataTatable(string sql, SqlParameter[] parameters)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            DataTable table = new DataTable();
            using (Ls_dataContext db = new Ls_dataContext())
            {

                conn.ConnectionString = db.Database.Connection.ConnectionString;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            return table;
        }
    }

    /// <summary>
    /// 拼接查询条件类
    /// </summary>
    public static class PredicateBuilder
    {
        /// <summary>
        /// 预设true条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>() { return f => true; }

        /// <summary>
        /// 预设false条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        /// <summary>
        /// Compose
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="merge"></param>
        /// <returns></returns>
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// And
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        /// <summary>
        /// Or
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }

    /// <summary>
    /// ParameterRebinder
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor
    {
        /// <summary>
        /// map
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}
