using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.MongoDB.Interfaces;
using DataAccess.MongoDB.Interfaces.Configuration;
using DataAccess.MongoDB.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
namespace DataAccess.MongoDB.Lookup
{
    public class ProductsLookup : IProductsLookup
    {
        private readonly IMongoCollection<Products> productsCollection;
        private readonly IMongoCollection<Categories> categoriesCollection;
        private readonly IMongoCollection<SubCategories> subcategoriesCollection;
        public ProductsLookup(IStoreDataBaseSettings settings)
        {
            var mdbClient = new MongoClient(settings.connectionString);
            var database = mdbClient.GetDatabase(settings.dataBaseName);
            productsCollection = database.GetCollection<Products>("Products");
            categoriesCollection = database.GetCollection<Categories>("Categories");
            subcategoriesCollection = database.GetCollection<SubCategories>("SubCategories");
        }

        public async Task<IList<ProductsLookedUp>> GetProductsAsync()
        {
            try
            {
                var query = from p in productsCollection.AsQueryable()
                            join c in categoriesCollection.AsQueryable()
                            on p.categoryId equals c.id into joinedCategories
                            join s in subcategoriesCollection.AsQueryable()
                            on p.subCategoryId equals s.id into joinedSubcategories
                            select new ProductsLookedUp()
                            {
                                id = p.id,                            
                                title = p.title,
                                description = p.description,
                                images = p.images,
                                date = p.date,
                                categories = joinedCategories,
                                subcategories = joinedSubcategories,
                                price = p.price,
                                stock = p.stock
                            };

                return await query.ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
    }
}
