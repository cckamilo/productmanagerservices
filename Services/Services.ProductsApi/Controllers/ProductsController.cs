using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.ServiceProducts.Interfaces;
using DataAccess.MongoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var response = await productsLogic.GetProducts();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var response = await productsLogic.GetById(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(List<IFormFile> files, [FromForm] Products products)
        {
            try
            {
                if (files.Count > 0 && products != null)
                {
                    var response = await productsLogic.UploadFilesAsync(files, products);
                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }
    }
}
