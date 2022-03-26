using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Azure.Interfaces
{
    public interface IBlobService
    {

        Task<List<string>> UploadFileBlobAsync(List<IFormFile> files, string container);

        Task<bool> DeleteBlobAsync(string blobName, string container);
    }
}