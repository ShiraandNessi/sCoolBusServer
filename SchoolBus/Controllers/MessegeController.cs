using BL;
using Entities;
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
    public class MessegeController : ControllerBase
    {
        IMessegeBL IMessegeBL;
        public MessegeController(IMessegeBL IMessegesBL)
        {
            this.IMessegeBL = IMessegesBL;
        }

        // GET: api/<MessegesController>
        [HttpGet]
        public async Task<List<Messege>> Get()
        {
            return await IMessegeBL.GetAllMesseges();
        }

       
        // POST api/<MessegesController>
        [HttpPost]
        public async Task Post([FromBody] Messege newMessege)
        {
             await IMessegeBL.AddNewMessege(newMessege);
        }

       
    }
}
