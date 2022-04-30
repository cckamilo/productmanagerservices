using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.ServiceProducts.Interfaces;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Models;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;
using MongoDB.Bson;

namespace Business.ServiceProducts.Logic
{
    public class SubCategoriesLogic : ISubCategoriesLogic
    {
        private readonly ICategoriesRepository repository;
        private ServiceResponse response;
        private readonly IMapper iMapper;

        public SubCategoriesLogic(ICategoriesRepository _respository, ServiceResponse _response, IMapper _iMapper)
        {
            this.repository = _respository;
            this.response = _response;
            this.iMapper = _iMapper;
        }

        public async Task<ServiceResponse> DeleteByIdAsync(string id)
        {
            //try
            //{
            //    var subCategory = await repository.GetByIdAsync(id);
            //    if (subCategory != null)
            //    {



            //            bool result = await repository.DeleteByIdAsync(id);
            //            response.error = null;
            //            response.result = result;

            //    }
            //    else
            //    {
            //        response.error = "No existe la categoria.";
            //        response.result = null;
            //    }
            //    return response;
            //}
            //catch (Exception ex)
            //{
            //    response.error = ex.Message;
            //    return response;
            //}
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            //var result = await repository.GetByIdAsync(id);
            //response.result = new List<object>();
            //if (result != null)
            //{
            //    response.error = null;
            //    response.result = result;
            //}
            //else
            //{
            //    response.error = "No hay resgistros";
            //    response.result = null;
            //}

            //return response;
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> InsertAsync(SubCategoriesModel subCategoryModel, string id)
        {
            SubCategories subcategoriesModel = iMapper.Map<SubCategories>(subCategoryModel);
            try
            {
                //var subCategory = await repository.GetByIdAsync(id);
                //if (subCategory != null)
                //{
                 
             
                //        subcategoriesModel.id = ObjectId.GenerateNewId().ToString();
                //        subcategoriesModel.active = true;
                //        subcategoriesModel.creationDate = DateTime.Now;
            
                //        bool result = await repository.InsertAsync(subCategory);
                //        response.error = null;
                //        response.result = result;



                //}
                //else
                //{
                //    response.error = "No existe la categoria.";
                //    response.result = null;
                //}
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                return response;
            }
            return response;

        }

        public async Task<ServiceResponse> UpdateAsync(SubCategoriesModel subCategoryModel, string idCategory)
        {
            //try
            //{
            //    var category = await repository.GetByIdAsync(idCategory);

            //    if (category != null)
            //    {
            //        var subCategory = category.subCategories.Find(x => x.id == subCategoryModel.id);
            //        if (subCategory != null)
            //        {
            //            subCategory.name = subCategoryModel.name;
            //            subCategory.modificationDate = DateTime.Now;
            //            subCategory.active = subCategory.active;              
            //            bool result = await repository.UpdateAsync(category);
            //            response.error = null;
            //            response.result = result;
            //        }
            //        else
            //        {
            //            response.error = "La subcategoria no existe.";
            //            response.result = null;
            //        }
            //    }
            //    else
            //    {
            //        response.error = "No existe la categoria.";
            //        response.result = null;
            //    }
            //    return response;
            //}
            //catch (Exception ex)
            //{
            //    response.error = ex.Message;
            //    return response;
            //}
            throw new NotImplementedException();
        }
    }
}
