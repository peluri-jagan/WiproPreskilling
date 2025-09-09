//IUnitofWork is used here to group related operations into a single transaction
//ex: saving changes to multiple entities in a single database transaction
//ex: committing all changes or rolling back in case of an error
// So, UnitOfWork is responsible for coordinating the work of multiple repositories by providing a single
// interface for saving changes.

//If we don't use UnitOfWork, we might end up with multiple database contexts being saved independently,
//which can lead to data inconsistency and make it harder to manage transactions.

using RepositioryDemo.Api.Models;
using RepositioryDemo.Api.Repository.Interfaces; //This will help us in accessing the weather forecast data model or any model

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Product> Products { get; }
    //Here products is a repository for the Product entity and we can do the same for other entities
    Task<int> SaveChangesAsync();
}


