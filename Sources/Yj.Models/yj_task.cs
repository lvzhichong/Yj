using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;

namespace Yj.Models
{
    /// <summary>
    /// yj_task 页面模型
    /// </summary>
    public class yj_taskModel : BaseObjectModel<yj_task> { }

    /// <summary>
    /// yj_task
    /// </summary>
    public class yj_task : BaseObject
    {
        /// <summary>
        /// task_id
        /// </summary>		
        public int task_id { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>		
        public string task_name { get; set; }
        /// <summary>
        /// task_description
        /// </summary>		
        public string task_description { get; set; }
        /// <summary>
        /// is_del
        /// </summary>		
        public int is_del { get; set; }
        /// <summary>
        /// create_date
        /// </summary>		
        public DateTime create_date { get; set; }
        /// <summary>
        /// create_user_id
        /// </summary>		
        public int create_user_id { get; set; }
        /// <summary>
        /// modify_date
        /// </summary>		
        public DateTime modify_date { get; set; }
        /// <summary>
        /// modify_user_id
        /// </summary>		
        public int modify_user_id { get; set; }
    }
}