using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationASP.Models;
using WebApplicationASP.Services;

namespace WebApplicationASP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }


        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery]string ProductId, 
                                [FromQuery ]int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }

    }
}