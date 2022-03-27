using System;
namespace Models.ProductsApi.ResponseModels
{
    public class ServiceResponse
    {
        public ServiceResponse()
        {
        }

        public string error { get; set; }
        public object result { get; set; }

    }
}
