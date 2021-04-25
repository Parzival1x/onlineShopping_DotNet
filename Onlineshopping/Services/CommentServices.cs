using Onlineshopping.Models;
using Onlineshopping.Respons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Onlineshopping.Services
{


    public class CommentServices
    {
        private readonly CoreDbContext context = new CoreDbContext();
        IConfiguration _configuration;

        private readonly IHttpContextAccessor httpContextAccessor;

        public CommentServices(IHttpContextAccessor HttpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            httpContextAccessor = HttpContextAccessor;
        }

        #region This method are related to checkout/product listing by pravin
        public async Task<ActionResult> AddUpdate(Comment _comment)
        {
            try
            {
                if (_comment == null)
                    return new OkObjectResult(new JSONResponse { Status = ResponseConstants.Info, Message = "Woops! Something went wrong" });

                var existinguser = context.Comments.AsQueryable().Where(x => x.Id == _comment.Id).FirstOrDefault();
                if (existinguser == null)
                    context.Comments.Add(_comment);
                else
                {
                    existinguser.Imageurl = _comment.Imageurl;
                    existinguser.Product = _comment.Product;
                    existinguser.Rating = _comment.Rating;
                    existinguser.Text = _comment.Text;
                    existinguser.User = _comment.User;
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
                var data = context.Comments.AsQueryable();
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