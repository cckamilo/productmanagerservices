using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

namespace Business.ServiceProducts.Interfaces
{
    public interface IProductsLogic
    {
        Task<object> GetProducts();
        Task<ServiceResponse> GetById(string id);
        Task<ServiceResponse> DeleteById(string id, string container);
        Task<ServiceResponse> Update(ProductsModel productsModel, List<IFormFile> files, string container);
        Task<ServiceResponse> UploadFilesAsync(List<IFormFile> files, ProductsModel products, string container);
    }
}