
using Onlineshopping.Models;
using Onlineshopping.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlineshopping.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _ProductServices;
        public ProductController(ProductServices ProductServices)
        {
            _ProductServices = ProductServices;
        }

        [HttpPost]
        public Task<ActionResult> AddUpdate(Product _product)
        {
            return _ProductServices.Add(_product);
        }

        [HttpGet]
        public Task<ActionResult> Getall()
        {
            return _ProductServices.GetAll();
        }
    }
}
