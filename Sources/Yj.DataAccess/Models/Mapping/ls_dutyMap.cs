using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class ls_dutyMap : EntityTypeConfiguration<ls_duty>
    {
        public ls_dutyMap()
        {
            // Primary Key
            this.HasKey(t => t.duty_id);

            // Properties
            this.Property(t => t.duty_name)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ls_duty");
            this.Property(t => t.duty_id).HasColumnName("duty_id");
            this.Property(t => t.duty_name).HasColumnName("duty_name");
            this.Property(t => t.description).HasColumnName("description");
        }
    }
}
