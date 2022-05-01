using System;
using System.Threading.Tasks;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

namespace Business.ServiceProducts.Interfaces
{
    public interface ICategoriesLogic
    {
        Task<ServiceResponse> GetAsync();
        Task<ServiceResponse> GetByIdAsync(string id);
        Task<ServiceResponse> DeleteByIdAsync(string id);
        Task<ServiceResponse> UpdateAsync(CategoriesModel category, string id);
        Task<ServiceResponse> InsertAsync(CategoriesModel category);
    }
}
