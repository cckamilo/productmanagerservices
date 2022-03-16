using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ServiceProducts.Interfaces;
using DataAccess.Azure.Interfaces;
using DataAccess.MongoDB.Interfaces.Repository;
using DataAccess.MongoDB.Models;
using Microsoft.AspNetCore.Http;

namespace Business.ServiceProducts.Logic
{
    public class ProductsLogic : IProductsLogic
    {
        private readonly IBlobService iBlobService;
        private readonly IProductsRepository iRepository;
        public ProductsLogic(IBlobService _iBlobService, IProductsRepository _iRepository)
        {
            this.iBlobService = _iBlobService;
            this.iRepository = _iRepository;
        }

        public async Task<bool> DeleteById(string id)
        {
            var blob = await iRepository.GetByIdAsync(id);
            if (blob != null)
            {
                foreach (var item in blob.images)
                {
                    await iBlobService.DeleteBlobAsync(item.name);
                }
                return await iRepository.DeleteByIdAsync(id);
            }
            else
            {
                return false;
            }
        }

        public async Task<Products> GetById(string id)
        {
            var result = await iRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<IList<Products>> GetProducts()
        {
            var result = await iRepository.GetAllAsync();            
            return result;
        }

        public async Task<bool> Update(Products products, List<IFormFile> files)
        {
           int i = 0;
            var newfile = new Products();
            if (files.Count > 0)
            {
                var blobs = await iBlobService.UploadFileBlobAsync(files);
                blobs.ForEach(element =>
                {
                    products.images.Add(new File
                    {
                        url = element,
                        name = files[i].FileName
                    });
                    i++;
                });

            }
           
             return await iRepository.UpdateAsync(products);
        }

        public async Task<Products> UploadFilesAsync(List<IFormFile> files, Products products)
        {
           int i = 0;
            
            var blobs = await iBlobService.UploadFileBlobAsync(files);
            if (blobs != null)
            {
                blobs.ForEach( element =>
                {
                    products.images.Add(new File
                    {
                        url = element,
                        name = files[i].FileName
                    });
                    i++;
                });
                products.date = DateTime.Now.ToString();                
                return await iRepository.InsertAsync(products);
            }
            else
            {
                return null;
            }
        }
    }
}