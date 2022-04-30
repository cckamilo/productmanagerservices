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

        private readonly ICategoriesLogic iCategoriesLogic;
        private readonly ISubCategoriesLogic iSubCategoriesLogic;
        private ServiceResponse response;

        public CategoriesController(ICategoriesLogic _iCategoriesLogic, ServiceResponse _response, ISubCategoriesLogic _iSubCategoriesLogic)
        {
            this.iCategoriesLogic = _iCategoriesLogic;
            this.response = _response;
            this.iSubCategoriesLogic = _iSubCategoriesLogic;
        }

        [HttpGet]
        // GET: /<controller>/
        public async Task<IActionResult> GetCategories()
        {
            var result = iCategoriesLogic.GetAsync();
            await Task.WhenAll(result);
            return Ok(result.Result);
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
                return Ok(result.Result);
            }
            else
            {
                response.error = "Datos incorrectos";
                response.result = null;
                return Ok(response);
            }     
        }

        //[HttpGet("subcategories/{id}")]
        //public async Task<IActionResult> GetSubCategories(string id)
        //{
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        var result = iSubCategoriesLogic.GetByIdAsync(id);
        //        await Task.WhenAll(result);
        //        return Ok(result.Result);
        //    }
        //    else
        //    {
        //        response.error = "Datos incorrectos";
        //        response.result = null;
        //        return Ok(response);
        //    }
        //}

        //[HttpPost("subcategories/{id}")]
        //public async Task<IActionResult> PostSubCategories(SubCategoriesModel subCategoryModel, string id)
        //{

        //    if (subCategoryModel != null)
        //    {
        //        var result = iSubCategoriesLogic.InsertAsync(subCategoryModel, id);
        //        await Task.WhenAll(result);
        //        return Ok(result.Result);
        //    }
        //    else
        //    {
        //        response.error = "Información incorrecta. Por favor revisar";
        //        return Ok(response);
        //    }
        //}

        //[HttpPut("subcategories/{id}")]
        //public async Task<IActionResult> PutSubCategories(SubCategoriesModel subCategoryModel, string id)
        //{

        //    if (subCategoryModel != null)
        //    {
        //        var result = iSubCategoriesLogic.UpdateAsync(subCategoryModel, id);
        //        await Task.WhenAll(result);
        //        return Ok(result.Result);
        //    }
        //    else
        //    {
        //        response.error = "Información incorrecta. Por favor revisar";
        //        return Ok(response);
        //    }
        //}

        //[HttpDelete("subcategories/{id}")]
        //public async Task<IActionResult> DeleteSubCategories(SubCategoriesModel subCategoryModel, string id)
        //{

        //    if (subCategoryModel != null)
        //    {
        //        var result = iSubCategoriesLogic.DeleteByIdAsync(id, subCategoryModel.id);
        //        await Task.WhenAll(result);
        //        return Ok(result.Result);
        //    }
        //    else
        //    {
        //        response.error = "Información incorrecta. Por favor revisar";
        //        return Ok(response);
        //    }
        //}



    }
}
