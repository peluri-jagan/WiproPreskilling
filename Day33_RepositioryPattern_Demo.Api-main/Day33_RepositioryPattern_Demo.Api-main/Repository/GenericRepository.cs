// This file will contain the implementation of the IGenericRepository interface
// It will provide the actual data access logic for the generic repository methods
// It acts as a bridge between the application and the data source, allowing for a more organized and maintainable codebase.

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RepositioryDemo.Api.Data;
using RepositioryDemo.Api.Models;
using RepositioryDemo.Api.Repository.Interfaces;

namespace RepositioryDemo.Api.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
        //above class implements the IGenericRepository interface defined by us for <T>
        //in this class we are providing the implementation for all the methods defined in the interface,
        // so that these methods can be used for <T> ie the entity type being managed by the application
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with id {id} not found.");
            }
        }
    }
}