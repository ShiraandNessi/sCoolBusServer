using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        IUserBL IUserBL;
        public UserController(IUserBL IUserBL)
        {
            this.IUserBL = IUserBL;
        }


        // GET api/<UserController>/5
        //Alert when the school bus apourching
        [HttpPost]
        public async Task<User> Get([FromBody]UserDTO userDet)

        {
            return await IUserBL.GetUser(userDet.Email, userDet.Password);
        }

        
       
    }
}
