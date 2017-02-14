using System;
using System.Collections.Generic;

namespace Yj.DataAccess.Models
{
    public partial class yj_task
    {
        public int task_id { get; set; }
        public string task_name { get; set; }
        public string task_description { get; set; }
        public int is_del { get; set; }
        public System.DateTime create_date { get; set; }
        public Nullable<int> create_user_id { get; set; }
        public System.DateTime modify_date { get; set; }
        public Nullable<int> modify_user_id { get; set; }
    }
}
