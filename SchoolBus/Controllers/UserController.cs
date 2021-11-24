using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL IUserBl;
        public UserController(IUserBL IUserBl)
        {
            this.IUserBl = IUserBl;
        }


        // GET api/<UserController>/5
        [HttpGet("{email}/{password}")]
        public async Task<User> Get(string email, string password)
        {
            return await IUserBl.GetUser(email, password);
        }
    }
}
