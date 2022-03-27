using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.ServiceProducts.Interfaces;
using DataAccess.Azure.Interfaces;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Models;
using Microsoft.AspNetCore.Http;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

namespace Business.ServiceProducts.Logic
{
    public class ProductsLogic : IProductsLogic
    {
        private readonly IMapper iMapper;
        private readonly IBlobService iBlobService; 
        private readonly IProductsRepository iRepository;


        public ProductsLogic(IBlobService _iBlobService, IProductsRepository _iRepository, IMapper _iMapper)
        {
            this.iBlobService = _iBlobService;
            this.iRepository = _iRepository;
            this.iMapper = _iMapper;
        }

        public async Task<ServiceResponse> DeleteById(string id, string container)
        {
            var response = new ServiceResponse();
            try
            {
                var isExist = await iRepository.GetByIdAsync(id);
                if (isExist != null)
                {
                    foreach (var item in isExist.images)
                    {
                        await iBlobService.DeleteBlobAsync(item.name, container);
                    }
                    var result = await iRepository.DeleteByIdAsync(id);
                    response.result = result;
                }
                else
                {
                    response.error = "No existen registros";
                }
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse> GetById(string id)
        {
            var response = new ServiceResponse();
            var result = await iRepository.GetByIdAsync(id);
            response.result = result;
            return response;
        }

        public async Task<ServiceResponse> GetProducts()
        {
            var response = new ServiceResponse();
            var result = await iRepository.GetAllAsync();
            response.result = result;
            return response;
        }

        public async Task<ServiceResponse> Update(ProductsModel productsModel, List<IFormFile> files, string container)
        {
            var response = new ServiceResponse();
            int i = 0;
            var newfile = new Products();
            if (files.Count > 0)
            {
                var blobs = await iBlobService.UploadFileBlobAsync(files, container);
                blobs.ForEach(element =>
                {
                    productsModel.images.Add(new FileModel
                    {
                        url = element,
                        name = files[i].FileName
                    });
                    i++;
                });
            }
            Products products = iMapper.Map<Products>(productsModel);
            var result = await iRepository.UpdateAsync(products);
            response.result = result;
            return response;
        }

        public async Task<ServiceResponse> UploadFilesAsync(List<IFormFile> files, ProductsModel productsModel, string container)
        {
            var response = new ServiceResponse();
            try
            {      
                int i = 0;
                var blobs = await iBlobService.UploadFileBlobAsync(files, container);
                if (blobs.Any())
                {
                    blobs.ForEach(element =>
                    {
                        productsModel.images.Add(new FileModel
                        {
                            url = element,
                            name = files[i].FileName
                        });
                        i++;
                    });
                    productsModel.date = DateTime.Now.ToString();
                    Products products = iMapper.Map<Products>(productsModel);
                    var result = await iRepository.InsertAsync(products);
                    response.result = result.id; 
                }
                else
                {
                    response.error = "El archivo ya existe. Por favor validar";       
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