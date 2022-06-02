using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.MongoDB.Interfaces;
using DataAccess.MongoDB.Interfaces.Configuration;
using DataAccess.MongoDB.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DataAccess.MongoDB.Lookup
{
    public class CategoriesLookup : ICategoriesLookup
    {
        private readonly IMongoCollection<Categories> categoriesCollection;
        private readonly IMongoCollection<SubCategories> subcategoriesCollection;

        public CategoriesLookup(IStoreDataBaseSettings settings)
        {
            var mdbClient = new MongoClient(settings.connectionString);
            var database = mdbClient.GetDatabase(settings.dataBaseName);
            subcategoriesCollection = database.GetCollection<SubCategories>("SubCategories");
            categoriesCollection = database.GetCollection<Categories>("Categories");
        }

        public async Task<IList<CategoriesLookedUp>> GetSubCategoriesAsync()
        {
            var query = from sc in subcategoriesCollection.AsQueryable()
                        join c in categoriesCollection.AsQueryable()
                        on sc.categoryId equals c.id into joinedCategories
                        select new CategoriesLookedUp()
                        {
                            id = sc.id,
                            name = sc.name,
                            creationDate = sc.creationDate,
                            modificationDate = sc.modificationDate,
                            active = sc.active,
                            categories = joinedCategories                    
                        };
            return await query.ToListAsync();
        }
    }
}
