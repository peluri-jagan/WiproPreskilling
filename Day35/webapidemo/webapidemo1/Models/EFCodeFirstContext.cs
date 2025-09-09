using Microsoft.EntityFrameworkCore;

namespace webapidemo1.Models
{
    public class EFCodeFirstContext : DbContext
    {
        public EFCodeFirstContext(DbContextOptions<EFCodeFirstContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-One relationship
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<StudentAddress>(a => a.StudentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
