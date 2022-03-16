using DataAccess.MongoDB.Interfaces.Configuration;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Models;

namespace DataAccess.MongoDB.Repository
{
    public class ProductsRepository : MongoDbRepository<Products>, IProductsRepository
    {
        public ProductsRepository(IStoreDataBaseSettings settings) : base(settings)
        {
        }
    }
}