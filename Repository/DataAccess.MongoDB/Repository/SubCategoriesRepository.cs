using System;
using DataAccess.MongoDB.Interfaces.Configuration;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Models;

namespace DataAccess.MongoDB.Repository
{
    public class SubCategoriesRepository: MongoDbRepository<SubCategories>, ISubCategoriesRepository
    {
        public SubCategoriesRepository(IStoreDataBaseSettings settings) : base(settings)
        {
        }
    }
}
