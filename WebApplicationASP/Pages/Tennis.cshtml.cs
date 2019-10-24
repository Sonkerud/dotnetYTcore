using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplicationASP.Models;
using WebApplicationASP.Services;

namespace WebApplicationASP.Pages
{
    public class TennisModel : PageModel
    {
        private readonly ILogger<TennisModel> _logger;
        public JsonFileProductService ProductService;
        public IEnumerable<Product> Products { get; private set; }

        public TennisModel(ILogger<TennisModel> logger,
            JsonFileProductService productService
            )
        {
            _logger = logger;
            ProductService = productService;
            
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}