using System;
using Models.ProductsApi.Interfaces;

namespace Models.ProductsApi.Models
{
    public class SizesModel : IItems
    {
        public SizesModel()
        {
        }

        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public bool active { get; set; }
    }
}
