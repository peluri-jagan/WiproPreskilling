using Jagan.EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Jagan.EmployeeApp.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<AppUser> Users => Set<AppUser>();
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(e =>
            {
                e.HasIndex(u => u.UserName).IsUnique();
                e.Property(u => u.UserName).HasMaxLength(64).IsRequired();
                e.Property(u => u.PasswordHash).HasMaxLength(256).IsRequired();
                e.Property(u => u.Role).HasMaxLength(32).IsRequired();
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.Property(x => x.Name).HasMaxLength(100).IsRequired();
                e.Property(x => x.Email).HasMaxLength(150).IsRequired();
                e.Property(x => x.Department).HasMaxLength(50);
            });
        }
    }
}
