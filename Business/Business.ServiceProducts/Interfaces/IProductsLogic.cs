using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.MongoDB.Models;
using Microsoft.AspNetCore.Http;

namespace Business.ServiceProducts.Interfaces
{
    public interface IProductsLogic
    {
        Task<IList<Products>> GetProducts();
        Task<Products> GetById(string id);
        Task<bool> DeleteById(string id);
        Task<bool> Update(Products products, List<IFormFile> files);
        Task<Products> UploadFilesAsync(List<IFormFile> files, Products products);
    }
}