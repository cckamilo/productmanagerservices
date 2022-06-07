using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.ServiceProducts.Interfaces;
using DataAccess.MongoDB.Interfaces.Repository;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

namespace Business.ServiceProducts.Logic
{
    public class ColorsLogic<T> : IProductsFactory<T> where T : ColorsModel 
    {
        private readonly ISettingsRepository repository;
        private ServiceResponse response;
        private readonly IMapper iMapper;

        public ColorsLogic(ISettingsRepository _repository, ServiceResponse _response, IMapper _iMapper)
        {
            this.repository = _repository;
            this.response = _response;
            this.iMapper = _iMapper;

        }

        public Task<ServiceResponse> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(T model, string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> InsertAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}
