using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using DataAccess.Azure.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Azure.Repository
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobServiceClient;
        public BlobService(BlobServiceClient _blobServiceClient)
        {
            this.blobServiceClient = _blobServiceClient;
        }

        public async Task<bool> DeleteBlobAsync(string blobName, string container)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(container);
            var blobClient = containerClient.GetBlobClient(blobName);
            var result = await blobClient.DeleteIfExistsAsync();
            return result.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<List<string>> UploadFileBlobAsync(List<IFormFile> files, string container)
        {
            List<string> lstUrl = new List<string>();
            var containerClient = blobServiceClient.GetBlobContainerClient(container);
            var isExist = await GetExistsBlobAsync(files, containerClient);
            if (!isExist)
            {
                foreach (var item in files)
                {
                    var blobClient = containerClient.GetBlobClient(item.FileName);
                    lstUrl.Add(blobClient.Uri.ToString());
                    using (var stream = item.OpenReadStream())
                    {
                        var result = await blobClient.UploadAsync(stream);

                    }
                }
            }
            return lstUrl;
        }

        public async Task<bool> GetExistsBlobAsync(List<IFormFile> files, BlobContainerClient containerClient)
        {
            bool isExist = false;
            foreach (var file in files)
            {
                var blobClient = containerClient.GetBlobClient(file.FileName);
                if (await blobClient.ExistsAsync())
                {
                    isExist = true;
                }
            }

            return isExist;
        }
    }
}