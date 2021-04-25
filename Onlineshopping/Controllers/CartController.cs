
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
    public class CartController : ControllerBase
    {
        private readonly CartServices _CartServices;
        public CartController(CartServices CartServices)
        {
            _CartServices = CartServices;
        }

        [HttpPost]
        public Task<ActionResult> AddUpdate(Cart _cart)
        {
            return _CartServices.AddUpdate(_cart);
        }

        [HttpGet]
        public Task<ActionResult> Getall()
        {
            return _CartServices.GetAll();
        }
    }
}
