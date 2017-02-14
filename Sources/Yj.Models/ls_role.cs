using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;

namespace Yj.Models
{
    /// <summary>
    /// ls_role 页面模型
    /// </summary>
    public class ls_roleModel : BaseObjectModel<ls_role> { }

    /// <summary>
    /// ls_role
    /// </summary>
    public class ls_role : BaseObject
    {
        /// <summary>
        /// role_id
        /// </summary>		
        public int role_id { get; set; }
        /// <summary>
        /// role_name
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        [RegularExpression("^[\u4e00-\u9fa5]{2,20}$", ErrorMessage = "2-20个汉字")]
        public string role_name { get; set; }
        /// <summary>
        /// 代号
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        [RegularExpression("^[a-z]{2,20}$", ErrorMessage = "2-20个字母")]
        public string role_code { get; set; }
    }
}