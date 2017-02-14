using System;
using System.Collections.Generic;

namespace Yj.DataAccess.Models
{
    public partial class ls_module
    {
        public int module_id { get; set; }
        public string module_category { get; set; }
        public string module_name { get; set; }
        public string module_path { get; set; }
        public string module_roles { get; set; }
    }
}
