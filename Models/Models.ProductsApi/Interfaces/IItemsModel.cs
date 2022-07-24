using System;
using System.Collections.Generic;
using Models.ProductsApi.Models;

namespace Models.ProductsApi.Interfaces
{
    public interface IItemsModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public List<GroupItemsModel> items { get; set; }
        public bool active { get; set; }
    }
}
