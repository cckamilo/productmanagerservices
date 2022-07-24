using System;
using System.Collections.Generic;
using Models.ProductsApi.Interfaces;

namespace Models.ProductsApi.Models
{
    public class ColorsModel : IItemsModel
    {
        public ColorsModel()
        {
        }

        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public List<GroupItemsModel> items { get; set; }
        public bool active { get; set; }

    }
}
