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
   // [Authorize]
    public class DriverController : ControllerBase
    {
        IDriverBL IDriverBL;
        IMapper IMapper;
        IAuthorizationFuncs _IAuthorizationFuncs;
        IHttpContextAccessor httpContext;


        public DriverController( IDriverBL IDriverBL, IMapper IMapper, IAuthorizationFuncs IAuthorizationFuncs, IHttpContextAccessor httpContext)
        {
            this.IDriverBL = IDriverBL;
           this.IMapper = IMapper;
            this._IAuthorizationFuncs = IAuthorizationFuncs;
            this.httpContext = httpContext;
        }
        // GET: api/<DriverController>
        [HttpGet]
        public async Task<List<DriverDTO>> Get()
        {
            //string s = HttpContext.User.Identity.Name;
            //if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Manager)))
            //{
            //    httpContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //}
            List<Driver> res = await IDriverBL.GatAllDrivers();
            List<DriverDTO> resDriers = IMapper.Map<List<Driver>, List<DriverDTO>>(res);
            return resDriers;


        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public async Task<DriverDTO> Get(int id)
        {
            //string s = HttpContext.User.Identity.Name;
            //if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Driver)))
            //{
            //    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //}

            Driver res= await IDriverBL.GatDriverById(id);
            return IMapper.Map<Driver, DriverDTO>(res);
        }
        [HttpGet("user/{userId}")]
        public async Task<DriverDTO> GetDriverByUserId(int userId)
        {
            //string s = HttpContext.User.Identity.Name;
            //if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Driver) ))
            //{
            //    httpContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //}

            Driver res = await IDriverBL.GatUserById(userId);
            return IMapper.Map<Driver, DriverDTO>(res);
             
        }
        // POST api/<DriverController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<DriverDTO> Post([FromBody] DriverDTO newDriver)
        {
            //string s = httpContext.HttpContext.User.Identity.Name;
            //if (!_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Manager))
            //{
            //    httpContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //}
            return await IDriverBL.AddNewDriver(newDriver);
            
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public async Task Put(int id,[FromQuery] UserDTO userDetails ,[FromBody] DriverDTO driverToUpdate)
        {
            string s = HttpContext.User.Identity.Name;
            if (!_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Driver))
            {
                httpContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            await IDriverBL.changeDriverdetails(id, driverToUpdate, userDetails.NewPassword);
        }
        

        

        // DELETE api/<DriverController>/5
       
    }
}
