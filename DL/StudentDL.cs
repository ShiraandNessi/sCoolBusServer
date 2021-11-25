using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DL
{
    public class StudentDL : IStudentDL
    {
       SchoolBusContext SchoolBusContext;
        public StudentDL(SchoolBusContext SchoolBusContext)
        {
            this.SchoolBusContext = SchoolBusContext;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await SchoolBusContext.Students.ToListAsync();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await SchoolBusContext.Students.FirstAsync();
        }
        public async Task<Student> AddNewStudent(Student newStudent)
        {
            await SchoolBusContext.Students.AddAsync(newStudent);
            await SchoolBusContext.SaveChangesAsync();
            return newStudent;
        }
        public async Task changeStudentDetailes(Student correntStudent)
        {
            SchoolBusContext.Students.Update(correntStudent);
            await SchoolBusContext.SaveChangesAsync();
        }
    }
}
