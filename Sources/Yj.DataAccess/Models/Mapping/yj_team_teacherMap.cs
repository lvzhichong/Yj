using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class yj_team_teacherMap : EntityTypeConfiguration<yj_team_teacher>
    {
        public yj_team_teacherMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("yj_team_teacher");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.team_id).HasColumnName("team_id");
            this.Property(t => t.teacher_id).HasColumnName("teacher_id");
        }
    }
}
