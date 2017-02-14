using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class yj_teacherMap : EntityTypeConfiguration<yj_teacher>
    {
        public yj_teacherMap()
        {
            // Primary Key
            this.HasKey(t => t.teacher_id);

            // Properties
            this.Property(t => t.teacher_name)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.teacher_description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("yj_teacher");
            this.Property(t => t.teacher_id).HasColumnName("teacher_id");
            this.Property(t => t.teacher_name).HasColumnName("teacher_name");
            this.Property(t => t.teacher_description).HasColumnName("teacher_description");
            this.Property(t => t.is_del).HasColumnName("is_del");
            this.Property(t => t.create_date).HasColumnName("create_date");
            this.Property(t => t.create_user_id).HasColumnName("create_user_id");
            this.Property(t => t.modify_date).HasColumnName("modify_date");
            this.Property(t => t.modify_user_id).HasColumnName("modify_user_id");
        }
    }
}
