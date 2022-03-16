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
        public async Task<bool> DeleteBlobAsync(string blobName)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient("camisetas");
            var blobClient = containerClient.GetBlobClient(blobName);
            var result = await blobClient.DeleteIfExistsAsync();
            return result.Value;        
        }

        public async Task<List<string>> UploadFileBlobAsync(List<IFormFile> files)
        {
             List<string> lstUrl = new List<string>();
            var containerClient = blobServiceClient.GetBlobContainerClient("camisetas");
            foreach (var item in files)
            {
                var blobClient = containerClient.GetBlobClient(item.FileName);
                lstUrl.Add(blobClient.Uri.ToString());
                using (var stream = item.OpenReadStream())
                {
                    var result = await blobClient.UploadAsync(stream);

                }
            }
            return lstUrl;
        }
    }
}