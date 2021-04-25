

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
    public class UserController : ControllerBase
    {
        private readonly UsersServices _UserServices;
        public UserController(UsersServices UserServices)
        {
            _UserServices = UserServices;
        }

        [HttpPost]
        public Task<ActionResult> AddUpdate(User _user)
        {
            return _UserServices.AddUpdate(_user);
        }

        [HttpGet]
        public Task<ActionResult> Getall()
        {
            return _UserServices.GetAll();
        }
    }
}
