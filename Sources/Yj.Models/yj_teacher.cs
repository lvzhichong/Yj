using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;

namespace Yj.Models
{
    /// <summary>
    /// yj_teacher 页面模型
    /// </summary>
    public class yj_teacherModel : BaseObjectModel<yj_teacher> { }

    /// <summary>
    /// yj_teacher
    /// </summary>
    public class yj_teacher : BaseObject
    {
        /// <summary>
        /// teacher_id
        /// </summary>		
        public int teacher_id { get; set; }
        /// <summary>
        /// 教师名称
        /// </summary>		
        public string teacher_name { get; set; }
        /// <summary>
        /// teacher_description
        /// </summary>		
        public string teacher_description { get; set; }
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