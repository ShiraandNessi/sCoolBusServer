using AutoMapper;
using BL;
using DTO;
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
        IDriverBL IDriverBL;
        IMapper IMapper;
        public DriverController(IDriverBL IDriverBL, IMapper IMapper)
        {
            this.IDriverBL = IDriverBL;
           this.IMapper = IMapper;
        }
        // GET: api/<DriverController>
        [HttpGet]
        public async Task<List<DriverDTO>> Get()
        {
            List<Driver> res = await IDriverBL.GatAllDrivers();
            List<DriverDTO> resDriers = IMapper.Map<List<Driver>, List<DriverDTO>>(res);
            return resDriers;


        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public async Task<DriverDTO> Get(int id)
        {
           
            Driver res= await IDriverBL.GatDriverById(id);
            return IMapper.Map<Driver, DriverDTO>(res);
        }

        // POST api/<DriverController>
        [HttpPost]
        public async Task<DriverDTO> Post([FromBody] DriverDTO newDriver)
        {
           return await IDriverBL.AddNewDriver(newDriver);
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public async Task Put(int id,[FromQuery] UserDTO userDetails ,[FromBody] DriverDTO driverToUpdate)
        {
            await IDriverBL.changeDriverdetails(id, driverToUpdate, userDetails.NewPassword);
        }
        

        

        // DELETE api/<DriverController>/5
       
    }
}
