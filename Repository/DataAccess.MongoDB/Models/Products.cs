using System.Collections.Generic;
using DataAccess.MongoDB.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.MongoDB.Models
{
    public class Products : IEntityBase
    {
        public Products()
        {
            this.images = new List<File>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string categoryId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string subCategoryId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<Items> sizes { get; set; }
        public List<Items> colors { get; set; }
        public List<Items> genders { get; set; }
        public int stock { get; set; }
        public int price { get; set; }
        public List<File> images { get; set; }
        public string date { get; set; }

    }
    public class Items
    {
        public string item { get; set; }
    }

    public class File
    {
        public string url { get; set; }

        public string name { get; set; }
    }

    public class ProductsLookedUp 
    {
        public string id { get; set; }
        public IEnumerable<Categories> categories { get; set; }
        public IEnumerable<SubCategories> subcategories { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int stock { get; set; }
        public int price { get; set; }
        public List<File> images { get; set; }
        public string date { get; set; }
    }


}