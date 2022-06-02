using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.ServiceProducts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.ProductsApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/{controller}")]
    [ApiController]
    public class CategoriesController : Controller
    {
        //private readonly ICategoriesLogic iCategoriesLogic;
        private readonly IProductFactory<CategoriesModel> iCategoriesLogic;
        private ServiceResponse response;

        public CategoriesController(IProductFactory<CategoriesModel> _iCategoriesLogic, ServiceResponse _response )
        {
            this.iCategoriesLogic = _iCategoriesLogic;
            this.response = _response;     
        }

        [HttpGet]
        // GET: /<controller>/
        public async Task<IActionResult> GetCategories()
        {
            var result = iCategoriesLogic.GetAsync();
            await Task.WhenAll(result);
            return Ok(result.Result.result);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategories(CategoriesModel categoryModel)
        {

            if (categoryModel != null)
            {
                var result = iCategoriesLogic.InsertAsync(categoryModel);
                await Task.WhenAll(result);
                return Ok(result.Result);
            }
            else
            {
                response.error = "Información incorrecta. Por favor revisar";
                return Ok(response);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategories(string id)
        {
            if (id != null)
            {
                var result = iCategoriesLogic.DeleteByIdAsync(id);
                await Task.WhenAll(result);
                return Ok(result.Result);
            }
            else
            {
                response.error = "Datos incorrectos";
                response.result = null;
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategories(CategoriesModel category, string id)
        {

            if (category != null && id != null)
            {
                var result = iCategoriesLogic.UpdateAsync(category, id);
                await Task.WhenAll(result);
                return Ok(result.Result);
            }
            else
            {
                response.error = "Datos incorrectos";
                response.result = null;
                return Ok(response);
            }


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategories(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var result = iCategoriesLogic.GetByIdAsync(id);
                await Task.WhenAll(result);
                return Ok(result.Result.result);
            }
            else
            {
                response.error = "Datos incorrectos";
                response.result = null;
                return Ok(response);
            }
        }


    }
}
