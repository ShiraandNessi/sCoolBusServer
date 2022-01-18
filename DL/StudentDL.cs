using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await SchoolBusContext.Students.FindAsync(id);
        }
        public async Task<Student> AddNewStudent(Student student)
        {
            await SchoolBusContext.Students.AddAsync(student);
            await SchoolBusContext.SaveChangesAsync();
            return student;
        }
        public async Task<List<Student>> GetStudentByFamilyId(int familyId)
        {
            return await SchoolBusContext.Students.Where(student => student.FamilyId == familyId).ToListAsync();
        }
        public async Task changeStudentDetails(int id, Student studentToUpdate)
        {
            Student student = await SchoolBusContext.Students.FindAsync(id);
            SchoolBusContext.Entry(student).CurrentValues.SetValues(studentToUpdate);
            await SchoolBusContext.SaveChangesAsync();
        }
        public async Task removeStudent(int id)
        {
            Student student = await SchoolBusContext.Students.FindAsync(id);
            if (student != null)
            {
                SchoolBusContext.Students.Remove(student);
                await SchoolBusContext.SaveChangesAsync();
            }
        }
    }
}
