using System;
using System.Threading.Tasks;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

namespace Business.ServiceProducts.Interfaces
{
    public interface ICategoriesLogic
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse> GetAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse> GetByIdAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse> DeleteByIdAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateAsync(CategoriesModel category, string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        Task<ServiceResponse> InsertAsync(CategoriesModel category);
    }
}
