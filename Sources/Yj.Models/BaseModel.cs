using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;

namespace Yj.Models
{
    /// <summary>
    /// 基础模型
    /// </summary>
    public class BaseObjectModel<T>
        where T : class
    {
        /// <summary>
        /// 行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int TotalRows { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        public IEnumerable<T> Datas { get; set; }
    }

    /// <summary>
    /// 基础信息
    /// </summary>
    public class BaseObject
    {
        /// <summary>
        /// 是否已删除
        /// </summary>
        [Display(Name = "是否已删除")]
        public bool IsDelete { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int Ordinal { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        private DateTime _CreateDate = DateTime.Now;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; } }

        /// <summary>
        /// 修改时间
        /// </summary>
        private DateTime _ModifyDate = DateTime.Now;

        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        public DateTime ModifyDate { get { return DateTime.Now; } set { _ModifyDate = value; } }
    }
}
