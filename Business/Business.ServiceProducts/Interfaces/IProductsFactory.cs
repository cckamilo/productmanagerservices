using System;
using System.Threading.Tasks;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

namespace Business.ServiceProducts.Interfaces
{
    public interface IProductsFactory<T> where T : class
    {
        Task<ServiceResponse> GetAsync();

        Task<ServiceResponse> GetByIdAsync(string id);

        Task<ServiceResponse> DeleteByIdAsync(string id);

        Task<ServiceResponse> UpdateAsync(T model, string id);

        Task<ServiceResponse> InsertAsync(T model);
    }
}
