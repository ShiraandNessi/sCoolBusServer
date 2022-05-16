using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentStatusController : ControllerBase
    {
        IStudentStatuseBL _IStudentStatuseBL;
        public StudentStatusController(IStudentStatuseBL IStudentStatuseBL)
        {
            _IStudentStatuseBL = IStudentStatuseBL;
        }
        // GET: api/<StudentController> 
        [HttpGet("{studentId}")]
        public async Task<bool> Get(int studentId , int driverId)
        {

            return await _IStudentStatuseBL.sentMessege(studentId, driverId);
        }


    }
 
    
}
