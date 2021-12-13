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
    public class StationController : ControllerBase
    {

        IStationBL IStationBL;

        public StationController(IStationBL _IStationBL)
        {
            IStationBL = _IStationBL;
        }
        // GET api/<StationController>/5
        [HttpGet]
        public async Task<List<Station>> Get()
        {
            return await IStationBL.getAllStation();
        }
        // GET api/<StationController>/5
        [HttpGet("{id}")]
        public async Task<Station> Get(int id)
        {
            return await IStationBL.getStationById(id);
        }

        [Route("[action]/{driverId}")]
        public async Task<List<Student>> GetStationsByDriverId(int driverId)
        {
            return await IStationBL.GetStationsByDriverId(driverId);
        }

        // POST api/<StationController>
        [HttpPost]
        public async Task<Station> Post( [FromBody] Station newStation)
        {
            return await IStationBL.addNewStation(newStation);
        }

       


        // DELETE api/<StationController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {

        }
    }
}
