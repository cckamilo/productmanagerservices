using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.MongoDB.Models;

namespace DataAccess.MongoDB.Interfaces
{
    public interface IProductsLookup
    {
        Task<IList<ProductsLookedUp>> GetProductsAsync();
    }
}
