//Objective of creating a repository is to provide a centralized data access layer, 
//promoting separation of concerns and making the application easier to maintain and test.

using System.Linq.Expressions;
using RepositioryDemo.Api.Models; //For specifying query filters

namespace RepositioryDemo.Api.Repository.Interfaces
{
    //we are calling this class as IGenericRepository as it is a genric interface for all the repository
    //We can also call this class as Metadata , as it only containes only method signatures which we will implement in the derived classes
    public interface IGenericRepository<T> where T : class
    {
        //This method retrieves all entities asynchronously
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);//Task type helps us in performing asynchronous operations

        //This method adds a new entity asynchronously
        Task AddAsync(T entity);

        //This method updates an existing entity asynchronously
        Task UpdateAsync(T entity);

        //This method deletes an existing entity asynchronously
        Task DeleteAsync(int id);

        //This method retrieves entities asynchronously based on a filter
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task RemoveAsync(T entity);
    }
}

//All the methods that are defined in the IGenericRepository interface will help us in performing CRUD operations on entities
//For example, we can use the Products repository to add, update, delete, or retrieve products from the database.