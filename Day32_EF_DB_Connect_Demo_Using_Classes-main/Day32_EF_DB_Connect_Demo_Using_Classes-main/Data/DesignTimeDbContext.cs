using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace EF_DB_Connect_Demo.Data
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<TrainingContext>
    {
        public TrainingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TrainingContext>();
            optionsBuilder.UseSqlServer("Data Source=AYUSHH\\SQLEXPRESS;Initial Catalog=day32;Integrated Security=True;TrustServerCertificate=True;");
            return new TrainingContext(optionsBuilder.Options);
        }
    }
}