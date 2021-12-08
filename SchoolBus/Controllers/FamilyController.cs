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
    public class FamilyController : ControllerBase
    {
        IFamilyBL IFamilyBL;
        public FamilyController(IFamilyBL IFamilyBL)
        {
            this.IFamilyBL = IFamilyBL;
        }
        // GET api/<FamilyController>/5
        [HttpGet("{id}")]
        public async Task<Family> Get(int id)
        {
            return await IFamilyBL.GetFamilyById(id);
        }

        // POST api/<FamilyController>
        [HttpPost]
        public async Task<Family> Post(string passsword, [FromBody] Family newFamily)
        {
            return await IFamilyBL.AddNewFamily(newFamily, passsword);
        }

        // PUT api/<FamilyController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Family familyToUpdate,string password, string newPassword)
        {
            await IFamilyBL.changeFamilyDetails(id, familyToUpdate, password, newPassword);
        }

        // DELETE api/<FamilyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            
        }
    }
}
