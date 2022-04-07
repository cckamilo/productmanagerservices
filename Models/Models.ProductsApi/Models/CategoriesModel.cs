using System;
using System.Collections.Generic;

namespace Models.ProductsApi.Models
{
    public class CategoriesModel
    {
        public CategoriesModel()
        {
            this.subCategories = new List<SubCategories>();
        }
        public string id { get; set; }

        public string name { get; set; }

        public DateTime creationDate { get; set; }

        public DateTime? modificationDate { get; set; }

        public bool active { get; set; }

        public List<SubCategories> subCategories { get; set; }

        public class SubCategories
        {
            public string _id { get; set; }

            public string name { get; set; }

            public List<Items> genders { get; set; }

            public List<Items> sizes { get; set; }

            public List<Items> colors { get; set; }

            public DateTime creationDate { get; set; }

            public DateTime? modificationDate { get; set; }

            public bool active { get; set; }

        }

        public class Items
        {
            public string item { get; set; }
        }

    }
}
