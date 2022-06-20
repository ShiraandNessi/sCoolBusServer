using AutoMapper;
using BL;
using DL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FamilyController : ControllerBase
    {
        IFamilyBL IFamilyBL;
        IMapper _IMapper;
        IAuthorizationFuncs _IAuthorizationFuncs;
    
        public FamilyController(IFamilyBL IFamilyBL, IMapper IMapper, IAuthorizationFuncs IAuthorizationFuncs )
        {
            this.IFamilyBL = IFamilyBL;
            _IMapper = IMapper;
            _IAuthorizationFuncs = IAuthorizationFuncs;
            
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
            if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Family)))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
            Family res = await IFamilyBL.GetFamilyByUserId(userId);
            return _IMapper.Map<Family, FamilyDTO>(res);
        }
       
        // POST api/<FamilyController>
        [HttpPost]
        public async Task<FamilyDTO> Post( [FromBody] FamilyDTO newFamily)
        {
            if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Family)))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
            return await IFamilyBL.AddNewFamily(newFamily);
        }

        // PUT api/<FamilyController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] FamilyDTO familyToUpdate, [FromQuery] UserDTO userDetails)
        {
            .if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Family)))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }
            await IFamilyBL.changeFamilyDetails(id, familyToUpdate, userDetails.NewPassword);
        }

       
    }
}
