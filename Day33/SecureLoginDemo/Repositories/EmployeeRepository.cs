using Jagan.EmployeeApp.Data;
using Jagan.EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Jagan.EmployeeApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _db;

        public EmployeeRepository(EmployeeDbContext db) => _db = db;

        public Task<List<Employee>> GetAllAsync() => _db.Employees.AsNoTracking().ToListAsync();

        public Task<Employee?> GetByIdAsync(int id) => _db.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        public async Task AddAsync(Employee employee)
        {
            await _db.Employees.AddAsync(employee);
        }

        public Task UpdateAsync(Employee employee)
        {
            _db.Employees.Update(employee);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Employees.FindAsync(id);
            if (entity != null) _db.Employees.Remove(entity);
        }

        public Task<bool> ExistsAsync(int id) => _db.Employees.AnyAsync(e => e.Id == id);

        public Task SaveAsync() => _db.SaveChangesAsync();
    }
}
