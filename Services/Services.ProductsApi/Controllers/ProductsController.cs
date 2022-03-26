using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.ServiceProducts.Interfaces;
using DataAccess.MongoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.ProductsApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v2/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        
        public readonly IProductsLogic productsLogic;
     
        public ProductsController(IProductsLogic _productsLogic)
        {
            this.productsLogic = _productsLogic;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = productsLogic.GetProducts();
            await Task.WhenAll( response );
            return Ok(response.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var response = productsLogic.GetById(id);
                await Task.WhenAll(response);
                return Ok(response.Result);
            }
            catch
            {
                return BadRequest();
            }
        }
     
        [HttpPost]
        public async Task<IActionResult> Post(List<IFormFile> files, [FromForm] ProductsModel products)
        {
            var response = new ServiceResponse();
            try
            {
                if (files.Count > 0 && products != null)
                {
                    var result = productsLogic.UploadFilesAsync(files, products, "camisetas");
                    await Task.WhenAll(result);
                    return Ok(result.Result);
                }
                else
                {
                    response.error = "Los archivos son obligatorios. Por favor revisar";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = new ServiceResponse();
            try
            {
                var result =  productsLogic.DeleteById(id, "camisetas");
                await Task.WhenAll(result);
                return Ok(result.Result);
            }
            catch(Exception ex)
            {
                response.error = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
