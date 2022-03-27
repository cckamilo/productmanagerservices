
using System;
using System.Collections.Generic;

namespace Models.ProductsApi.Models
{
    public class ProductsModel
    {
        public ProductsModel()
        {
            this.images = new List<FileModel>();
        }

        public string id { get; set; }
        public string categories { get; set; }
        public string subCategories { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<ItemsModel> sizes { get; set; }
        public List<ItemsModel> colors { get; set; }
        public List<ItemsModel> genders { get; set; }
        public int stock { get; set; }
        public int price { get; set; }
        public List<FileModel> images { get; set; }
        public string date { get; set; }

    }

    public class ItemsModel
    {
        public string item { get; set; }
    }

    public class FileModel
    {
        public string url { get; set; }

        public string name { get; set; }
    }
}
