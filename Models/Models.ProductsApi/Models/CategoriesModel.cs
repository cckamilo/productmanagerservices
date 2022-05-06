using System;
using System.Collections.Generic;

namespace Models.ProductsApi.Models
{
    public class CategoriesModel
    {
        public CategoriesModel()
        {
        }
        public string id { get; set; }

        public string name { get; set; }

        public DateTime creationDate { get; set; }

        public DateTime? modificationDate { get; set; }

        public bool active { get; set; }

    }
}
