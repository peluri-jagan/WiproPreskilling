using EF_DB_Connect_Demo.Data;
using EF_DB_Connect_Demo.Models;
using Microsoft.EntityFrameworkCore;

// Register the DbContext with dependency injection
var optionsBuilder = new DbContextOptionsBuilder<TrainingContext>();

// Configure the DbContext to use SQL Server
optionsBuilder.UseSqlServer("Data Source=AYUSHH\\SQLEXPRESS;Initial Catalog=day32;Integrated Security=True;TrustServerCertificate=True;");
using var context = new TrainingContext(optionsBuilder.Options);
if (!context.Students.Any())
{
    var trainer = new Trainer { Name = "Salman khan" };
    var student = new Student { Name = "Student1" };
    var course = new Course { Title = "Driving", Trainer = trainer };
    context.Trainers.Add(trainer);
    context.Students.Add(student);
    context.Courses.Add(course);
    context.SaveChanges();
    Console.WriteLine("Sample data inserted!");
}
else
{
    Console.WriteLine("Database already has data.");
}