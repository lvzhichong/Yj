using System;
using System.Collections.Generic;

namespace Yj.DataAccess.Models
{
    public partial class yj_teacher_task
    {
        public int id { get; set; }
        public int teacher_id { get; set; }
        public int task_id { get; set; }
    }
}
