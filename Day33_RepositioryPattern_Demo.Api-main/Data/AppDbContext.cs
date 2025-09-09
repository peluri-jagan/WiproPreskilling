//this file contains the application database context
using Microsoft.EntityFrameworkCore;
using RepositioryDemo.Api.Models;

namespace RepositioryDemo.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
