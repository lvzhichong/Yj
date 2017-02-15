using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;

namespace Yj.Models
{
    /// <summary>
    /// yj_team_teacher 页面模型
    /// </summary>
    public class yj_team_teacherModel : BaseObjectModel<yj_team_teacher> { }

    /// <summary>
    /// yj_team_teacher
    /// </summary>
    public class yj_team_teacher : BaseObject
    {
        /// <summary>
        /// id
        /// </summary>		
        public int id { get; set; }
        /// <summary>
        /// team_id
        /// </summary>		
        public int team_id { get; set; }
        /// <summary>
        /// teacher_id
        /// </summary>		
        public int teacher_id { get; set; }
    }
}