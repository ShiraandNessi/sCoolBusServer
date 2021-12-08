using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationOfRoutController : ControllerBase
    {
        IStationOfRoutBL IStationOfRoutBL;

        public StationOfRoutController(IStationOfRoutBL _IStationOfRoutBL)
        {
            IStationOfRoutBL = _IStationOfRoutBL;
        }
        // GET: api/<StationOfRoutController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StationOfRoutController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StationOfRoutController>
        [HttpPost]
        public async Task<StationOfRoute> Post( int newStation,   int newRout)
        {
            return await IStationOfRoutBL.AddStationOfRoute(newStation, newRout);
        }

        // PUT api/<StationOfRoutController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
        }

        // DELETE api/<StationOfRoutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
