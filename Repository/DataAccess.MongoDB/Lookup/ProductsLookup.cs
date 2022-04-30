using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.MongoDB.Interfaces;
using DataAccess.MongoDB.Interfaces.Configuration;
using DataAccess.MongoDB.Models;
using MongoDB.Driver;

namespace DataAccess.MongoDB.Lookup
{
    public class ProductsLookup : IProductsLookup
    {
        private readonly IMongoCollection<Products> productsCollection;
        private readonly IMongoCollection<Categories> categoriesCollection;
        public ProductsLookup(IStoreDataBaseSettings settings)
        {
            var mdbClient = new MongoClient(settings.connectionString);
            var database = mdbClient.GetDatabase(settings.dataBaseName);
            productsCollection = database.GetCollection<Products>("Products");
            categoriesCollection = database.GetCollection<Categories>("Categories");

        }

        public async Task<IList<ProductsLookedUp>> GetProductsAsync()
        {
            try
            {
                var result = await productsCollection.Aggregate()
                    .Lookup<Products, Categories, ProductsLookedUp>(categoriesCollection, a => a.categoryId, b => b.id, b => b.categories ).ToListAsync();
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
    }
}
