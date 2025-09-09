using Microsoft.AspNetCore.Mvc;   
using crudapidemo.Models;         
using Microsoft.EntityFrameworkCore; 

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase {
    private readonly AppDbContext _context;
    public EmployeesController(AppDbContext context) => _context = context;
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> Get() =>
        await _context.Employees.ToListAsync();
  [HttpGet("{id}")]
public async Task<ActionResult<Employee>> Get(int id)
{
    var employee = await _context.Employees.FindAsync(id);

    if (employee == null)
        return NotFound();

    return employee; 
}


    [HttpPost]
    public async Task<ActionResult<Employee>> Post(Employee employee) {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Employee employee) {
        if (id != employee.Id) return BadRequest();
        _context.Entry(employee).State = EntityState.Modified;
        await _context.SaveChangesAsync();
         return Ok(new { message = "Employee updated successfully!" });
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return NotFound();
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}