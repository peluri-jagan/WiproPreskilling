using Jagan.EmployeeApp.Models;

namespace Jagan.EmployeeApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task SaveAsync();
    }
}
