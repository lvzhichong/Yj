using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;

namespace Yj.Models
{
    /// <summary>
    /// yj_team 页面模型
    /// </summary>
    public class yj_teamModel : BaseObjectModel<yj_team> { }

    /// <summary>
    /// yj_team
    /// </summary>
    public class yj_team : BaseObject
    {
        /// <summary>
        /// team_id
        /// </summary>		
        public int team_id { get; set; }
        /// <summary>
        /// 小组名称
        /// </summary>		
        public string team_name { get; set; }
        /// <summary>
        /// team_description
        /// </summary>		
        public string team_description { get; set; }
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