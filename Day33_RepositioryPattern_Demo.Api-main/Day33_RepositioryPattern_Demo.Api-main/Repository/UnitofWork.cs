// here in this class we are implementing the Unit of Work pattern with the help of
// a generic repository
// This class will coordinate the work of multiple repositories
// It will ensure that all changes are saved to the database in a single transaction
// This helps to maintain data integrity and consistency

using RepositioryDemo.Api.Data;
using RepositioryDemo.Api.Models;
using RepositioryDemo.Api.Repository.Interfaces;

namespace RepositioryDemo.Api.Repository
{
    public class UnitOfWork : IUnitOfWork//Here IUnitOfWork is defined in previous interface
    {
        private readonly AppDbContext _context;
        private readonly IGenericRepository<Product> _productRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _productRepository = new GenericRepository<Product>(_context);
        }
        public IGenericRepository<Product> Products => _productRepository;

        public void Dispose()
        {
            _context?.Dispose();
        }

        // userdefined entity types
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}