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
    public class FamilyController : ControllerBase
    {
        IFamilyBL IFamilyBL;
        IMapper _IMapper;
        public FamilyController(IFamilyBL IFamilyBL, IMapper IMapper)
        {
            this.IFamilyBL = IFamilyBL;
            _IMapper = IMapper;
        }
        // GET api/<FamilyController>/5
        [HttpGet("{id}")]
        public async Task<FamilyDTO> Get(int id)
        {
            Family res= await IFamilyBL.GetFamilyById(id);
            return _IMapper.Map<Family,FamilyDTO>(res);
        }
        [HttpGet("user/{userId}")]
        public async Task<FamilyDTO> GetFamilyByUserId(int userId)
        {
            Family res = await IFamilyBL.GetFamilyByUserId(userId);
            return _IMapper.Map<Family, FamilyDTO>(res);
        }
        // POST api/<FamilyController>
        [HttpPost]
        public async Task<FamilyDTO> Post( [FromBody] FamilyDTO newFamily)
        {
            return await IFamilyBL.AddNewFamily(newFamily);
        }

        // PUT api/<FamilyController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] FamilyDTO familyToUpdate, [FromQuery] UserDTO userDetails)
        {
            await IFamilyBL.changeFamilyDetails(id, familyToUpdate, userDetails.NewPassword);
        }

       
    }
}
