using System;
using DataAccess.MongoDB.Models;

namespace DataAccess.MongoDB.Interfaces.Repository
{
    public interface ISubCategoriesRepository : IMongoDbRepository<SubCategories>
    {
        
    }
}
