using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class yj_teacher_taskMap : EntityTypeConfiguration<yj_teacher_task>
    {
        public yj_teacher_taskMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("yj_teacher_task");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.teacher_id).HasColumnName("teacher_id");
            this.Property(t => t.task_id).HasColumnName("task_id");
        }
    }
}
