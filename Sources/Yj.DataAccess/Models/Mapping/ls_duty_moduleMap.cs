using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class ls_duty_moduleMap : EntityTypeConfiguration<ls_duty_module>
    {
        public ls_duty_moduleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.duty_module_roles)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ls_duty_module");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.duty_id).HasColumnName("duty_id");
            this.Property(t => t.module_id).HasColumnName("module_id");
            this.Property(t => t.duty_module_roles).HasColumnName("duty_module_roles");
        }
    }
}
