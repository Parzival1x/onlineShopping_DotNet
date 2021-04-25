
using Onlineshopping.Models;
using Onlineshopping.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Onlineshopping.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentServices _CommentServices;
        public CommentController(CommentServices CommentServices)
        {
            _CommentServices = CommentServices;
        }

        [HttpPost]
        public Task<ActionResult> AddUpdate(Comment _comment)
        {
            return _CommentServices.AddUpdate(_comment);
        }

        [HttpGet]
        public Task<ActionResult> Getall()
        {
            return _CommentServices.GetAll();
        }
    }
}
