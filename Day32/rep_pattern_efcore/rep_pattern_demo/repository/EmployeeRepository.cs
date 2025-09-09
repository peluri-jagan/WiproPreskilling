using System.Collections.Generic;
using System.Linq;
using rep_pattern_demo.Models;
using rep_pattern_demo.Repository;
using rep_pattern_demo.Models;

namespace rep_pattern_demo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.Find(employeeId);
        }

        public void AddEmployee(Employee employeeEntity)
        {
            _context.Employees.Add(employeeEntity);
            _context.SaveChanges();
        }

        public string? GetEmployeeNameById(int id)
    {
         return _context.Employees
        .Where(e => e.EmployeeId == id)
        .Select(e => e.EmployeeName)
        .FirstOrDefault();
    }

        public void UpdateEmployee(Employee employeeEntity)
        {
            _context.Employees.Update(employeeEntity);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public string? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
