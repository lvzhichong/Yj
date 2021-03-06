using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Yj.DataAccess.Models.Mapping;

namespace Yj.DataAccess.Models
{
    public partial class Ls_dataContext : DbContext
    {
        static Ls_dataContext()
        {
            Database.SetInitializer<Ls_dataContext>(null);
        }

        public Ls_dataContext()
            : base("Name=Ls_dataContext")
        {
        }

        public DbSet<ls_duty> ls_duty { get; set; }
        public DbSet<ls_duty_module> ls_duty_module { get; set; }
        public DbSet<ls_log> ls_log { get; set; }
        public DbSet<ls_module> ls_module { get; set; }
        public DbSet<ls_role> ls_role { get; set; }
        public DbSet<ls_user> ls_user { get; set; }
        public DbSet<yj_task> yj_task { get; set; }
        public DbSet<yj_teacher> yj_teacher { get; set; }
        public DbSet<yj_teacher_task> yj_teacher_task { get; set; }
        public DbSet<yj_team> yj_team { get; set; }
        public DbSet<yj_team_teacher> yj_team_teacher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ls_dutyMap());
            modelBuilder.Configurations.Add(new ls_duty_moduleMap());
            modelBuilder.Configurations.Add(new ls_logMap());
            modelBuilder.Configurations.Add(new ls_moduleMap());
            modelBuilder.Configurations.Add(new ls_roleMap());
            modelBuilder.Configurations.Add(new ls_userMap());
            modelBuilder.Configurations.Add(new yj_taskMap());
            modelBuilder.Configurations.Add(new yj_teacherMap());
            modelBuilder.Configurations.Add(new yj_teacher_taskMap());
            modelBuilder.Configurations.Add(new yj_teamMap());
            modelBuilder.Configurations.Add(new yj_team_teacherMap());
        }
    }
}
