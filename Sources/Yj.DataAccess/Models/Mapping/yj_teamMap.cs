using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class yj_teamMap : EntityTypeConfiguration<yj_team>
    {
        public yj_teamMap()
        {
            // Primary Key
            this.HasKey(t => t.team_id);

            // Properties
            this.Property(t => t.team_name)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.team_description)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("yj_team");
            this.Property(t => t.team_id).HasColumnName("team_id");
            this.Property(t => t.team_name).HasColumnName("team_name");
            this.Property(t => t.team_description).HasColumnName("team_description");
            this.Property(t => t.is_del).HasColumnName("is_del");
            this.Property(t => t.create_date).HasColumnName("create_date");
            this.Property(t => t.create_user_id).HasColumnName("create_user_id");
            this.Property(t => t.modify_date).HasColumnName("modify_date");
            this.Property(t => t.modify_user_id).HasColumnName("modify_user_id");
        }
    }
}
