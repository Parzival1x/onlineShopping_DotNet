using Onlineshopping.Models;
using Onlineshopping.Respons;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Onlineshopping.Services
{


    public class CartServices
    {
        private readonly CoreDbContext context = new CoreDbContext();
        IConfiguration _configuration;

        private readonly IHttpContextAccessor httpContextAccessor;

        public CartServices(IHttpContextAccessor HttpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            httpContextAccessor = HttpContextAccessor;
        }

        #region This method are related to checkout/product listing by pravin
        public async Task<ActionResult> AddUpdate(Cart _cart)
        {
            try
            {
                if (_cart == null)
                    return new OkObjectResult(new JSONResponse { Status = ResponseConstants.Info, Message = "Woops! Something went wrong" });

                var existinguser = context.Carts.AsQueryable().Where(x => x.Id == _cart.Id).FirstOrDefault();
                if (existinguser == null)
                    context.Carts.Add(_cart);
                else
                {
                    existinguser.Product = _cart.Product;
                    existinguser.Quantities = _cart.Quantities;
                    existinguser.User = _cart.User;
                }
                await context.SaveChangesAsync();

                return new OkObjectResult(new JSONResponse { Status = ResponseConstants.Ok, Message = "Saved successfully" });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new JSONResponse { Status = ResponseConstants.Fail, Message = "Failed to save record", Description = ex.Message });
            }
        }

        public async Task<ActionResult> GetAll()
        {
            try
            {
                var data = context.Carts.AsQueryable();
                return new OkObjectResult(new JSONResponse { TotalCount = data.Count(), Result = data.ToList(), Status = ResponseConstants.Ok, Message = "succesfull." });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new JSONResponse { Status = ResponseConstants.Fail, Message = "Failed to load record", Description = ex.Message });
            }
        }

        #endregion

    }
}