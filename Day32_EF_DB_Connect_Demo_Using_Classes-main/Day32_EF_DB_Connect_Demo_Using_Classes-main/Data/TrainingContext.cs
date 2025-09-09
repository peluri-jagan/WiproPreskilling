using Microsoft.EntityFrameworkCore;

using EF_DB_Connect_Demo.Models;

namespace EF_DB_Connect_Demo.Data
{
    //Db context class is base class for entity framework
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}