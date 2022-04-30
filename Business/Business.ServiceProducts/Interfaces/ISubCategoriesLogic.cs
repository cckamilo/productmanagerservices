using System;
using System.Threading.Tasks;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

namespace Business.ServiceProducts.Interfaces
{
    public interface ISubCategoriesLogic
    {
        Task<ServiceResponse> GetAsync();

        Task<ServiceResponse> GetByIdAsync(string id);

        Task<ServiceResponse> DeleteByIdAsync(string id);

        Task<ServiceResponse> UpdateAsync(SubCategoriesModel SubCategory, string id);

        Task<ServiceResponse> InsertAsync(SubCategoriesModel SubCategory, string id);
    }
}
