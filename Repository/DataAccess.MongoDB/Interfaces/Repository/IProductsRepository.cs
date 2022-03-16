using DataAccess.MongoDB.Models;

namespace DataAccess.MongoDB.Interfaces.Repository
{
    public interface IProductsRepository : IMongoDbRepository<Products>
    {
         
    }
}