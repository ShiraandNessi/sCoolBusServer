using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StudentBL : IStudentBL
    {
        IStudentDL IStudentDL;
        public StudentBL(IStudentDL IStudentDL)
        {
            this.IStudentDL = IStudentDL;
        }
        public async Task<int> GetCountOfStudentsBystationId(int stationId, int routeId)

        {
            return await IStudentDL.GetCountOfStudentsBystationId(stationId,  routeId);
        }
      
        public async Task<List<Student>> GetAllStudents()
        {
            return await IStudentDL.GetAllStudents();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await IStudentDL.GetStudentById(id);
        }
        public async Task<Student> AddNewStudent(Student student)
        {
            return await IStudentDL.AddNewStudent(student);
        }
        public async Task<List<Student>> GetStudentByFamilyId(int familyId)
        {
            return await IStudentDL.GetStudentByFamilyId(familyId);
        }
        public async Task changeStudentDetails(int id, Student studentToUpdate)
        {
           await IStudentDL.changeStudentDetails(id, studentToUpdate);
        }
        public async Task removeStudent(int id)
        {
            await IStudentDL.removeStudent(id);
        }
        public async Task<List<Student>> GetStudentByRouteId(int routeId)
        {
            return await IStudentDL.GetStudentByRouteId(routeId);
        }
    }
}
