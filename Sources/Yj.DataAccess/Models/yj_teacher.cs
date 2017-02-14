using System;
using System.Collections.Generic;

namespace Yj.DataAccess.Models
{
    public partial class yj_teacher
    {
        public int teacher_id { get; set; }
        public string teacher_name { get; set; }
        public string teacher_description { get; set; }
        public int is_del { get; set; }
        public System.DateTime create_date { get; set; }
        public Nullable<int> create_user_id { get; set; }
        public System.DateTime modify_date { get; set; }
        public Nullable<int> modify_user_id { get; set; }
    }
}
