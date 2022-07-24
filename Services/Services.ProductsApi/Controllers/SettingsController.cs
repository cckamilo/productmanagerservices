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
    [Route("api/v1/{controller}/")]
    [ApiController]
    public class SettingsController : Controller
    {
        private readonly IProductsFactory<GendersModel> gendersLogic;
        private readonly IProductsFactory<SizesModel> sizesLogic;
        private ServiceResponse response;
        public SettingsController(IProductsFactory<GendersModel> _gendersLogic, ServiceResponse _response, IProductsFactory<SizesModel> _sizesLogic)
        {
            this.gendersLogic = _gendersLogic;
            this.response = _response;
            this.sizesLogic = _sizesLogic;
        }

        [HttpPost("{context}")]
        // GET: /<controller>/
        public async Task<IActionResult> Post(SettingsEntity entity, string context)
        {
            try
            {
                if (entity != null)
                {
                    switch (context)
                    {
                        case "genders":
                            var responseGenders = gendersLogic.InsertAsync(entity.genders);
                            await Task.WhenAll(responseGenders);
                            response = responseGenders.Result;
                            break;
                        case "colors":
                            break;
                        case "sizes":
                            var resultSizes = sizesLogic.InsertAsync(entity.sizes);
                            await Task.WhenAll(resultSizes);
                            response = resultSizes.Result;
                            break;
                        default:
                            response.error = "Error de contexto.";
                            response.result = null;
                            break;
                    }
                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }          
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            } 
        }
    }
}
