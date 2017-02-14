using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Yj.DataAccess.Models.Mapping
{
    public class ls_userMap : EntityTypeConfiguration<ls_user>
    {
        public ls_userMap()
        {
            // Primary Key
            this.HasKey(t => t.user_id);

            // Properties
            this.Property(t => t.user_name)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.user_password)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.nick_name)
                .HasMaxLength(256);

            this.Property(t => t.email)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("ls_user");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.duty_id).HasColumnName("duty_id");
            this.Property(t => t.user_name).HasColumnName("user_name");
            this.Property(t => t.user_password).HasColumnName("user_password");
            this.Property(t => t.nick_name).HasColumnName("nick_name");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.is_approved).HasColumnName("is_approved");
            this.Property(t => t.is_lock).HasColumnName("is_lock");
            this.Property(t => t.lock_date).HasColumnName("lock_date");
            this.Property(t => t.create_date).HasColumnName("create_date");
            this.Property(t => t.modify_date).HasColumnName("modify_date");
            this.Property(t => t.last_login_date).HasColumnName("last_login_date");
            this.Property(t => t.is_del).HasColumnName("is_del");
        }
    }
}
