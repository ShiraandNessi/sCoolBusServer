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

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await IStudentBL.GetStudentById(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<Student> Post([FromBody] Student newStudent)
        {
            return await IStudentBL.AddNewStudent(newStudent);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Student correntStudent)
        {
            await IStudentBL.changeStudentDetailes(correntStudent);
        }

    }
}
