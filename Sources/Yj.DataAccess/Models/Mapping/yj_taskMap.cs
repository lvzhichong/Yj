using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class yj_taskMap : EntityTypeConfiguration<yj_task>
    {
        public yj_taskMap()
        {
            // Primary Key
            this.HasKey(t => t.task_id);

            // Properties
            this.Property(t => t.task_name)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.task_description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("yj_task");
            this.Property(t => t.task_id).HasColumnName("task_id");
            this.Property(t => t.task_name).HasColumnName("task_name");
            this.Property(t => t.task_description).HasColumnName("task_description");
            this.Property(t => t.is_del).HasColumnName("is_del");
            this.Property(t => t.create_date).HasColumnName("create_date");
            this.Property(t => t.create_user_id).HasColumnName("create_user_id");
            this.Property(t => t.modify_date).HasColumnName("modify_date");
            this.Property(t => t.modify_user_id).HasColumnName("modify_user_id");
        }
    }
}
