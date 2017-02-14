using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class ls_logMap : EntityTypeConfiguration<ls_log>
    {
        public ls_logMap()
        {
            // Primary Key
            this.HasKey(t => t.log_id);

            // Properties
            this.Property(t => t.user_name)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ls_log");
            this.Property(t => t.log_id).HasColumnName("log_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.user_name).HasColumnName("user_name");
            this.Property(t => t.log_description).HasColumnName("log_description");
            this.Property(t => t.log_date).HasColumnName("log_date");
        }
    }
}
