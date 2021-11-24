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
    public class DriverController : ControllerBase
    {
        DriverBL DriverBL;
        public DriverController(DriverBL DriverBL)
        {
            this.DriverBL = DriverBL;
        }
        // GET: api/<DriverController>
        [HttpGet]
        public async Task<List<Driver>> Get()
        {
            return await DriverBL.GatAllDrivers();
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public async Task<Driver> Get(int id)
        {
            return await DriverBL.GatDriverById(id);
        }

        // POST api/<DriverController>
        [HttpPost("{passsword}")]
        public async Task<int> Post(string passsword,[FromBody] Driver newDriver)
        {
           return await DriverBL.AddNewDriver(newDriver, passsword);
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
