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
        public async Task<int> GetCountOfStudentsBystationId(int stationId, int routeId)
        {
           var list= await SchoolBusContext.Students.Where(s => s.RoutId == routeId && s.Family.StationId == stationId).ToListAsync();
            return list.Count();
        }
        public async Task<List<Student>> GetAllStudents()
        {
            return await SchoolBusContext.Students.ToListAsync();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await SchoolBusContext.Students.FindAsync(id);
        }
        public async Task<bool> saveImage(int id,string path)
        {
            Student s = await SchoolBusContext.Students.FindAsync(id);
            if (s==null)
                return false;
            s.Passport = path;
            await SchoolBusContext.SaveChangesAsync();
            return true;

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
        public async Task<List<Student>> GetStudentByRouteId(int routeId)
        {
            return await SchoolBusContext.Students.Where(student => student.RoutId == routeId).ToListAsync();
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
