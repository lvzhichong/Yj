using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel.DataAnnotations;

namespace Yj.Models
{
    /// <summary>
    /// ls_duty_module 页面模型
    /// </summary>
    public class ls_duty_moduleModel : BaseObjectModel<ls_duty_module> { }

    /// <summary>
    /// ls_duty_module
    /// </summary>
    public class ls_duty_module : BaseObject
    {
        /// <summary>
        /// id
        /// </summary>		
        public int id { get; set; }
        /// <summary>
        /// duty_id
        /// </summary>		
        public int duty_id { get; set; }
        /// <summary>
        /// module_id 模块id
        /// </summary>		
        public int module_id { get; set; }
        /// <summary>
        /// 模块权限
        /// </summary>
        public string duty_module_roles { get; set; }
    }
}