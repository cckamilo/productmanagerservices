using System;
namespace Models.ProductsApi.ResponseModels
{
    public class Error
    {
        public Error()
        {
        }

        public bool succeeded { get; set; }

        public string message { get; set; }

    }
}
