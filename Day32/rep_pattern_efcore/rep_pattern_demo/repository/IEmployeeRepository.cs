using rep_pattern_demo.Models;

public interface IEmployeeRepository : IDisposable
{
    IEnumerable<Employee> GetAllEmployee();
    Employee GetEmployeeById(int employeeId);
    void AddEmployee(Employee employeeEntity);
    void UpdateEmployee(Employee employeeEntity);
    void DeleteEmployee(int employeeId);
    string? GetById(int id);
}
