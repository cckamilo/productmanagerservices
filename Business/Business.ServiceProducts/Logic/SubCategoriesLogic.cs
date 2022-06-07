using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.ServiceProducts.Interfaces;
using DataAccess.MongoDB.Interfaces;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Models;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;
using MongoDB.Bson;

namespace Business.ServiceProducts.Logic
{
    public class SubCategoriesLogic<T> : IProductsFactory<T> where T : SubCategoriesModel
    {
        //SubCategoriesLogic<T> : IProductFactory<T> where T : SubCategoriesModel
        private readonly ISubCategoriesRepository subcategoriesRepository;
        private readonly ICategoriesLookup iCategoriesLookup;
        private ServiceResponse response;
        private readonly IMapper iMapper;

        public SubCategoriesLogic(ISubCategoriesRepository _subcategoriesRepository, ServiceResponse _response, IMapper _iMapper, ICategoriesLookup _iCategoriesLookup)
        {
            this.subcategoriesRepository = _subcategoriesRepository;
            this.response = _response;
            this.iMapper = _iMapper;
            this.iCategoriesLookup = _iCategoriesLookup;

        }

        public async Task<ServiceResponse> GetAsync()
        {
            var result = await iCategoriesLookup.GetSubCategoriesAsync();
            if (result != null)
            {
                response.result = result;
            }

            return response;
        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            var result = await subcategoriesRepository.GetByIdAsync(id);
            response.result = new List<object>();
            if (result != null)
            {
                response.error = null;
                response.result = result;
            }
            else
            {
                response.error = "No hay resgistros";
                response.result = null;
            }

            return response;
        }

        public async Task<ServiceResponse> DeleteByIdAsync(string id)
        {
            try
            {
                var subcategory = await subcategoriesRepository.GetByIdAsync(id);
                if (subcategory != null)
                {
                    bool result = await subcategoriesRepository.DeleteByIdAsync(id);
                    response.error = null;
                    response.result = result;
                }
                else
                {
                    response.error = "No existe la categoria.";
                    response.result = null;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse> UpdateAsync(T model, string id)
        {
            SubCategories subcategory = iMapper.Map<SubCategories>(model);
            try
            {
                var data = await subcategoriesRepository.GetByIdAsync(id);
                if (data != null)
                {
                    subcategory.id = id;
                    subcategory.modificationDate = DateTime.Now;
                    bool result = await subcategoriesRepository.UpdateAsync(subcategory);
                    response.error = null;
                    response.result = result;
                }
                else
                {
                    response.error = "La subcategoria no existe.";
                    response.result = null;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse> InsertAsync(T model)
        {
            SubCategories subcategory = iMapper.Map<SubCategories>(model);
            try
            {

                var subCategories = subcategoriesRepository.SearchForAsync(x => x.categoryId == model.categoryId);
                if (subCategories.Any())
                {
                    var exist = subCategories.Where(x => x.name == model.name).FirstOrDefault();
                    if (exist != null)
                    {
                        response.error = "La subcategoria " + exist.name + " ya existe";
                        response.result = null;
                        return response;
                    }
                    subcategory.id = ObjectId.GenerateNewId().ToString();
                    subcategory.name = model.name;
                    subcategory.categoryId = model.categoryId;
                    subcategory.active = true;
                    subcategory.creationDate = DateTime.Now;
                    var result = await subcategoriesRepository.InsertAsync(subcategory);
                    response.error = null;
                    response.result = result.id;
                }
                else
                {
                    response.error = "La categoria no existe";
                    response.result = null;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                return response;
            }
            return response;
        }

    }
}
