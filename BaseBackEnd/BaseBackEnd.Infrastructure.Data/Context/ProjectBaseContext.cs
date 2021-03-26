using BaseBackEnd.Domain.Entities.Security;
using BaseBackEnd.Infrastructure.Data.Context.DatabaseFunctions;
using BaseBackEnd.Infrastructure.Data.Mappings.Security;
using BaseBackEnd.Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace BaseBackEnd.Infrastructure.Data.Context
{
    public partial class ProjectBaseContext : DbContext
    {
        public ProjectBaseContext(DbContextOptions<ProjectBaseContext> options) : base(options) { }

        #region Security
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Functionality> Functionality { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModulePage> ModulePage { get; set; }
        public virtual DbSet<ModulePageFunctionality> ModulePageFunctionality { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<ProfileModulePageFunctionality> ProfileModulePageFunctionality { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<User> User { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");

            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new FunctionalityMap());
            modelBuilder.ApplyConfiguration(new ModuleMap());
            modelBuilder.ApplyConfiguration(new ModulePageFunctionalityMap());
            modelBuilder.ApplyConfiguration(new ModulePageMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new ProfileModulePageFunctionalityMap());
            modelBuilder.ApplyConfiguration(new SessionMap());
            modelBuilder.ApplyConfiguration(new PageMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.Entity<DbFuncs>()
                .ToSqlQuery("SELECT GETDATE() AS DateTime, NEWID() as NewId")
                .HasNoKey();

            modelBuilder.SeedAsync();

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
