using System;
using System.Collections.Generic;

namespace Yj.DataAccess.Models
{
    public partial class ls_log
    {
        public int log_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string user_name { get; set; }
        public string log_description { get; set; }
        public System.DateTime log_date { get; set; }
    }
}
