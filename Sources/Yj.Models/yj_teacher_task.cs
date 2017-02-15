using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;

namespace Yj.Models
{
    /// <summary>
    /// yj_teacher_task 页面模型
    /// </summary>
    public class yj_teacher_taskModel : BaseObjectModel<yj_teacher_task> { }

    /// <summary>
    /// yj_teacher_task
    /// </summary>
    public class yj_teacher_task : BaseObject
    {
        /// <summary>
        /// id
        /// </summary>		
        public int id { get; set; }
        /// <summary>
        /// teacher_id
        /// </summary>		
        public int teacher_id { get; set; }
        /// <summary>
        /// task_id
        /// </summary>		
        public int task_id { get; set; }
    }
}