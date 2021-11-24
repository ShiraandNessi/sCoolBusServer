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
            return await SchoolBusContext.Student.ToListAsync();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await SchoolBusContext.Student.FirstAsync();
        }
        public async Task<int> AddNewStudent(Student student)
        {
            await SchoolBusContext.Student.AddAsync(student);
            return await SchoolBusContext.SaveChangesAsync();
        }
    }
}
