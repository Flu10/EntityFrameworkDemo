namespace EntityFrameworkDemo.HrContext
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Model;
    using Model.Nomenclatures;
    using System.Linq;
    public class HrContext : DbContext
    {
        public HrContext() : base("Hr")
        {
            Init();
        }

        private void Init()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Project>Projects { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            ConfigurePropertyId(modelBuilder);
            ApplyCustomConventions(modelBuilder);

            modelBuilder.Entity<Employee>().Property(x => x.Email).IsRequired().HasMaxLength(35)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("UX_Email") { IsUnique = true }));

            modelBuilder.Entity<Employee>()
                .HasMany<Project>(s => s.Projects)
                .WithMany(c => c.Employees)
                .Map(cs =>
                {
                    cs.MapLeftKey("EmployeeId");
                    cs.MapRightKey("ProjectId");
                    cs.ToTable("EmployeeProject", "Hr");
                });
        }

        private void ApplyCustomConventions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(10,2));
            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(250));
        }

        private void ConfigurePropertyId(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(c =>
            {
                c.Property("Id").HasColumnName(c.ClrType.Name + "Id");
                
            });
        }
    }
}
