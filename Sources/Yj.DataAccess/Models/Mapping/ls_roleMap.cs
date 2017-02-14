using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class ls_roleMap : EntityTypeConfiguration<ls_role>
    {
        public ls_roleMap()
        {
            // Primary Key
            this.HasKey(t => t.role_id);

            // Properties
            this.Property(t => t.role_code)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.role_name)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("ls_role");
            this.Property(t => t.role_id).HasColumnName("role_id");
            this.Property(t => t.role_code).HasColumnName("role_code");
            this.Property(t => t.role_name).HasColumnName("role_name");
        }
    }
}
