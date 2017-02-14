using System;
using System.Collections.Generic;

namespace Yj.DataAccess.Models
{
    public partial class ls_user
    {
        public int user_id { get; set; }
        public Nullable<int> duty_id { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public string nick_name { get; set; }
        public string email { get; set; }
        public bool is_approved { get; set; }
        public bool is_lock { get; set; }
        public Nullable<System.DateTime> lock_date { get; set; }
        public System.DateTime create_date { get; set; }
        public System.DateTime modify_date { get; set; }
        public System.DateTime last_login_date { get; set; }
        public bool is_del { get; set; }
    }
}
