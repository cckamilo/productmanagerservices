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
    public class CategoriesLogic<T> : IProductsFactory<T> where T : CategoriesModel
    {
        private readonly ICategoriesRepository repository;
        private ServiceResponse response;
        private readonly IMapper iMapper;

        public CategoriesLogic(ICategoriesRepository _respository, ServiceResponse _response, IMapper _iMapper)
        {
            this.repository = _respository;
            this.response = _response;
            this.iMapper = _iMapper;
        }

        public async Task<ServiceResponse> GetAsync()
        {
            var result = await repository.GetAllAsync();
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

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            var result = await repository.GetByIdAsync(id);
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
                var exist = await repository.GetByIdAsync(id);
                if (exist != null)
                {
                    var res = await repository.DeleteByIdAsync(id);
                    response.error = null;
                    response.result = res;
                }
                else
                {
                    response.error = "No existen datos";
                    response.result = null;
                }
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse> UpdateAsync(T model, string id)
        {
            try
            {
                var exist = await repository.GetByIdAsync(id);
                if (exist != null)
                {
                    exist.active = model.active;
                    exist.modificationDate = DateTime.Now;
                    exist.name = model.name;

                    bool result = await repository.UpdateAsync(exist);
                    if (result)
                    {
                        response.error = null;
                        response.result = result;
                    }
                    else
                    {
                        response.error = "Error al modificar la información";
                        response.result = null;
                    }
                }
                else
                {
                    response.error = "No hay registros";
                    response.result = null;
                }
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                return response;
            }

            return response;
        }


        public async Task<ServiceResponse> InsertAsync(T model)
        {
            Categories categories = iMapper.Map<Categories>(model);
            try
            {
                var query = repository.SearchForAsync(x => x.name == categories.name);
                if (!query.Any())
                {
                    categories.active = true;
                    categories.creationDate = DateTime.Now;
                    var result = await repository.InsertAsync(categories);
                    response.error = null;
                    response.result = result.id;
                }
                else
                {
                    response.error = "La categoria ya existe. Por favor validar";
                    response.result = null;
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
