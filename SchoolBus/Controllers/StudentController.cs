using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentBL IStudentBL;
        public StudentController(IStudentBL IStudentBL)
        {
            this.IStudentBL = IStudentBL;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<List<Student>> Get()
        {
            return await IStudentBL.GetAllStudents();
        }

       // GET api/<StudentController>
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await IStudentBL.GetStudentById(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<int> Post([FromBody] Student student)
        {
            return await IStudentBL.AddNewStudent(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Student studentToUpdate)
        {
            await IStudentBL.changeStudentDetails(id, studentToUpdate);
        }
        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await IStudentBL.removeStudent(id);
        }

        //[Route("[action]/{familyId}")]
        //public async Task<List<Student>> GetStudentByFamilyId(int familyId)
        //{
        //    return await IStudentBL.GetStudentByFamilyId(familyId);
        //}



        //[HttpGet("{id}")]
        //public async Task<List<Student>> Get(int id)
        //{
        //    return await IStudentBL.GetStudentByFamilyId(id);
        //}

    }
}
