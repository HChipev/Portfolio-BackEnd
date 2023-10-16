using Data.Entities;
using Data.ModelBuilding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Framework> Frameworks { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new WorkConfigurator().Configure(modelBuilder.Entity<Work>());
            SeedConfigurator.Seed(modelBuilder);
        }
    }
}