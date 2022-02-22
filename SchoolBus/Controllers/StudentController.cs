using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Authorization;
using DL;
using Microsoft.AspNetCore.Http;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StudentController : ControllerBase
    {
        IStudentBL IStudentBL;
        IAuthorizationFuncs _IAuthorizationFuncs;
     
        
        public StudentController(IStudentBL IStudentBL , IAuthorizationFuncs IAuthorizationFuncs)
        {
            this.IStudentBL = IStudentBL;
            _IAuthorizationFuncs = IAuthorizationFuncs;
           
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<List<Student>> Get()
        {
            if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Manager)))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            return await IStudentBL.GetAllStudents();
        }

       // GET api/<StudentController>
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Family)))
            {
               HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            return await IStudentBL.GetStudentById(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<Student> Post([FromBody] Student student)
        {

            if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Family)))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            return await IStudentBL.AddNewStudent(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Student studentToUpdate)
        {

            if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Family)))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            await IStudentBL.changeStudentDetails(id, studentToUpdate);
        }
        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Family)))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            await IStudentBL.removeStudent(id);
        }

        [HttpGet("family/{familyId}")]
        public async Task<List<Student>> GetStudentByFamilyId(int familyId)
        {
            if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Family)))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            return await IStudentBL.GetStudentByFamilyId(familyId);
        }

        [HttpGet("route/{routeId}")]
        public async Task<List<Student>> GetStudentByRouteId(int routeId)
        {
            //if (!(_IAuthorizationFuncs.isAthorized(Convert.ToInt16(HttpContext.User.Identity.Name), (int)UserTypeEnum.Driver)))
            //{
            //    HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //}
            return await IStudentBL.GetStudentByRouteId(routeId);
        }



    }
}
