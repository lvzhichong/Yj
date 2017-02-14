using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;

namespace Yj.Models
{
    /// <summary>
    /// ls_duty 页面模型
    /// </summary>
    public class ls_dutyModel : BaseObjectModel<ls_duty> { }

    /// <summary>
    /// ls_duty
    /// </summary>
    public class ls_duty : BaseObject
    {
        /// <summary>
        /// duty_id
        /// </summary>		
        public int duty_id { get; set; }
        /// <summary>
        /// duty_name
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        [RegularExpression("^[\u4e00-\u9fa5]{2,20}$", ErrorMessage = "2-20个汉字")]
        public string duty_name { get; set; }
        /// <summary>
        /// description
        /// </summary>		
        public string description { get; set; }

        /// <summary>
        /// 角色权限
        /// </summary>
        public string[] roles { get; set; }
    }
}