using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Business.ServiceProducts.Interfaces;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Models;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

namespace Business.ServiceProducts.Logic
{
    public class GendersLogic<T> : IProductsFactory<T> where T : GendersModel
    {
        private readonly ISettingsRepository repository;
        private ServiceResponse response;
        private readonly IMapper iMapper;

        public GendersLogic(ISettingsRepository _repository, ServiceResponse _response, IMapper _iMapper)
        {
            this.repository = _repository;
            this.response = _response;
            this.iMapper = _iMapper;
        }

        public async Task<ServiceResponse> InsertAsync(T model)
        {
            Genders gender = iMapper.Map<Genders>(model);
            List<Genders> genders = new List<Genders>();
            genders.Add(gender);
            Settings settings = new Settings() { genders = genders };
            var result = await repository.InsertAsync(settings);
            response.error = null;
            response.result = true;
            return response;
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

        public Task<ServiceResponse> UpdateAsync(T model, string id)
        {
            throw new NotImplementedException();
        }
    }
}
