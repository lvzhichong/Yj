using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;

namespace Yj.Models
{
    /// <summary>
    /// ls_log 页面模型
    /// </summary>
    public class ls_logModel : BaseObjectModel<ls_log> { }

    /// <summary>
    /// ls_log
    /// </summary>
    public class ls_log : BaseObject
    {
        /// <summary>
        /// id
        /// </summary>
        public int log_id { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public Nullable<int> user_id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// 日志描述
        /// </summary>
        public string log_description { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public System.DateTime log_date { get; set; }
    }
}