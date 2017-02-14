using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class ls_moduleMap : EntityTypeConfiguration<ls_module>
    {
        public ls_moduleMap()
        {
            // Primary Key
            this.HasKey(t => t.module_id);

            // Properties
            this.Property(t => t.module_category)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.module_name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.module_path)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.module_roles)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ls_module");
            this.Property(t => t.module_id).HasColumnName("module_id");
            this.Property(t => t.module_category).HasColumnName("module_category");
            this.Property(t => t.module_name).HasColumnName("module_name");
            this.Property(t => t.module_path).HasColumnName("module_path");
            this.Property(t => t.module_roles).HasColumnName("module_roles");
        }
    }
}
