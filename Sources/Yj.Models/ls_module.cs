using System;
using System.Collections.Generic;

namespace Yj.Models
{
    /// <summary>
    /// ls_moduleModel ҳ��ģ��
    /// </summary>
    public class ls_moduleModel : BaseObjectModel<ls_module> { }

    /// <summary>
    /// ls_module
    /// </summary>
    public class ls_module
    {
        /// <summary>
        /// ģ��id
        /// </summary>
        public int module_id { get; set; }
        /// <summary>
        /// ģ�����
        /// </summary>
        public string module_category { get; set; }
        /// <summary>
        /// ģ������
        /// </summary>
        public string module_name { get; set; }
        /// <summary>
        /// ģ��·��
        /// </summary>
        public string module_path { get; set; }
        /// <summary>
        /// ģ��Ȩ��
        /// </summary>
        public string module_roles { get; set; }
    }
}
