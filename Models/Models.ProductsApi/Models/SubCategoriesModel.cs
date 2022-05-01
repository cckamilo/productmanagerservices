using System;
namespace Models.ProductsApi.Models
{
    public class SubCategoriesModel
    {
        public SubCategoriesModel()
        {

        }
        public string id { get; set; }

        public string categoryId { get; set; }

        public string name { get; set; }

        public DateTime? creationDate { get; set; }

        public DateTime? modificationDate { get; set; }

        public bool active { get; set; }
    }
}
