using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.ServiceProducts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.ProductsApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/subcategories")]
    [ApiController]
    public class SubCategoriesController : Controller
    {
        private readonly IProductsFactory<SubCategoriesModel> logic;
        private readonly IProductsFactory<CategoriesModel> categories;
        private ServiceResponse response;

        public SubCategoriesController( IProductsFactory<SubCategoriesModel> _logic, ServiceResponse _response, IProductsFactory<CategoriesModel> _categories) 
        {
            this.logic = _logic;
            this.response = _response;
            this.categories = _categories;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = logic.GetAsync();
            await Task.WhenAll(response);
            return Ok(response.Result.result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (id != null)
            {
                var result = logic.GetByIdAsync(id);
                await Task.WhenAll(result);
                return Ok(result.Result.result);
            }
            else
            {
                response.error = "Información incorrecta. Por favor revisar";
                return Ok(response);
            }
        }
        /// <summary>
        /// Prueba de commit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(SubCategoriesModel model)
        {
            if (model != null && !string.IsNullOrEmpty(model.categoryId) && !string.IsNullOrEmpty(model.name))
            {
                var exist = categories.GetByIdAsync(model.categoryId);
                if (exist.Result.result != null)
                {
                    var subcategories = logic.InsertAsync(model);
                    await Task.WhenAll(subcategories);
                    if (subcategories.Result.error != null)
                    {
                        return Ok(subcategories.Result);                   
                    }
                    else
                    {
                        return Ok(subcategories.Result.result);
                    }      
                }
                else
                {
                    response.error = "La categoria no existe";
                    return Ok(response);
                }       
            }
            else
            {
                response.error = "Información incorrecta. Por favor revisar";
                return Ok(response);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, SubCategoriesModel model)
        {
            if (model != null)
            {
                var result = logic.UpdateAsync(model, id);
                await Task.WhenAll(result);
                return Ok(result.Result);
            }
            else
            {
                response.error = "Información incorrecta. Por favor revisar";
                return Ok(response);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = logic.DeleteByIdAsync(id);
                await Task.WhenAll(result);
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                return Ok(response);
            }
        }
    }
}
