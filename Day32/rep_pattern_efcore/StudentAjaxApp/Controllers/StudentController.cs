using StudentAjaxApp.Models;
using Microsoft.AspNetCore.Mvc;
public class StudentController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index() => View();

    public IActionResult GetAll() => PartialView("_StudentList", _context.Students.ToList());

    public IActionResult Create() => PartialView("_StudentForm", new Student());

    [HttpPost]
    public IActionResult Create(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
        return Json(new { success = true });
    }

    public IActionResult Edit(int id)
    {
        var student = _context.Students.Find(id);
        return PartialView("_StudentForm", student);
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        _context.Students.Update(student);
        _context.SaveChanges();
        return Json(new { success = true });
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var student = _context.Students.Find(id);
        _context.Students.Remove(student);
        _context.SaveChanges();
        return Json(new { success = true });
    }
}
