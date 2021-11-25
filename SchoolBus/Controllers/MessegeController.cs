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
        public MessegeController(IMessegeBL IMessegeBL)
        {
            this.IMessegeBL = IMessegeBL;
        }

        // GET: api/<MessegesController>
        [HttpGet("{id}")]
        public async Task<List<Messege>> Get(int id)
        {
            return await IMessegeBL.GetAllMessegesByDriverId(id);
        }

       
        // POST api/<MessegesController>
        [HttpPost]
        public async Task<int> Post([FromBody] Messege newMessege)
        {
             return await IMessegeBL.AddNewMessege(newMessege);
        }

       
    }
}
