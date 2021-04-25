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


    public class UsersServices
    {
        private readonly CoreDbContext context = new CoreDbContext();
        IConfiguration _configuration;

        private readonly IHttpContextAccessor httpContextAccessor;

        public UsersServices(IHttpContextAccessor HttpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            httpContextAccessor = HttpContextAccessor;
        }

        #region This method are related to checkout/product listing by pravin
        public async Task<ActionResult> AddUpdate(User _User)
        {
            try
            {
                if (_User == null)
                    return new OkObjectResult(new JSONResponse { Status = ResponseConstants.Info, Message = "Woops! Something went wrong" });

                var existinguser = context.Users.AsQueryable().Where(x => x.Id == _User.Id).FirstOrDefault();
                if (existinguser == null)
                    context.Users.Add(_User);
                else
                {
                    existinguser.Email = _User.Email;
                    existinguser.Password = _User.Password;
                    existinguser.Purchasehistory = _User.Purchasehistory;
                    existinguser.Shipingaddress = _User.Shipingaddress;
                    existinguser.Username = _User.Username;
                }

                await context.SaveChangesAsync();
                return new OkObjectResult(new JSONResponse { Status = ResponseConstants.Ok, Message = "User Saved successfully" });
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
                var data = context.Users.AsQueryable();
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