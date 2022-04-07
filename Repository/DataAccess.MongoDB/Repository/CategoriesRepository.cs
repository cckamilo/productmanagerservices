using System;
using DataAccess.MongoDB.Interfaces.Configuration;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Models;

namespace DataAccess.MongoDB.Repository
{
    public class CategoriesRepository : MongoDbRepository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(IStoreDataBaseSettings settings) : base(settings)
        {
        }
    }
}
