using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.ServiceProducts.Interfaces;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Models;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;
using System.Linq;
using MongoDB.Bson;

namespace Business.ServiceProducts.Logic
{
    public class SizesLogic<T> : IProductsFactory<T> where T : SizesModel
    {
        private readonly ISettingsRepository repository;
        private ServiceResponse response;
        private readonly IMapper iMapper;

        public SizesLogic(ISettingsRepository _repository, IMapper _iMapper, ServiceResponse _response)
        {
            this.repository = _repository;
            this.iMapper = _iMapper;
            this.response = _response;
        }

        public Task<ServiceResponse> DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> InsertAsync(T model)
        {
            try
            {
                var exist = repository.SearchForAsync(x => x.sizes.Any(c => c.name == model.name));

                if (!exist.Any())
                {
                    Sizes size = iMapper.Map<Sizes>(model);
                    size.id = ObjectId.GenerateNewId().ToString();
                    List<Sizes> sizes = new List<Sizes>();
                    sizes.Add(size);
                    Settings settings = new Settings() { sizes = sizes };
                    var result = await repository.InsertAsync(settings);
                    response.error = null;
                    response.result = true;

                }
                else
                {
                    response.error = "El registro ya existe";
                    response.result = null;
                }
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                response.result = null;
            }
            return response;
        }

        public Task<ServiceResponse> UpdateAsync(T model, string id)
        {
            throw new NotImplementedException();
        }
    }
}

