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
    [Route("api/v2/{controller}")]
    [ApiController]
    public class SettingsController : Controller
    {
        private readonly IProductsFactory<GendersModel> gendersLogic;
        private ServiceResponse response;
        public SettingsController(IProductsFactory<GendersModel> _gendersLogic, ServiceResponse _response)
        {
            this.gendersLogic = _gendersLogic;
            this.response = _response;
        } 

        [HttpPost("{context}")]
        // GET: /<controller>/
        public async Task<IActionResult> Post(string context, SettingsBody body)
        {
            try
            {
                if (body != null)
                {
                    switch (context)
                    {
                        case "genders":
                            var result = gendersLogic.InsertAsync(body.genders);
                            await Task.WhenAll(result);
                            response = result.Result;
                            break;
                        case "colors":
                            break;
                        case "sizes":
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
