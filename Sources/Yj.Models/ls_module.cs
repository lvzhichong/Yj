using System;
using System.Collections.Generic;

namespace Yj.Models
{
    /// <summary>
    /// ls_moduleModel 页面模型
    /// </summary>
    public class ls_moduleModel : BaseObjectModel<ls_module> { }

    /// <summary>
    /// ls_module
    /// </summary>
    public class ls_module
    {
        /// <summary>
        /// 模块id
        /// </summary>
        public int module_id { get; set; }
        /// <summary>
        /// 模块分类
        /// </summary>
        public string module_category { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string module_name { get; set; }
        /// <summary>
        /// 模块路径
        /// </summary>
        public string module_path { get; set; }
        /// <summary>
        /// 模块权限
        /// </summary>
        public string module_roles { get; set; }
    }
}
