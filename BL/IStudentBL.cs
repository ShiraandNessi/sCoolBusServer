using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IStudentBL
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddNewStudent(Student student);
        Task<List<Student>> GetStudentByFamilyId(int familyId);
        Task changeStudentDetails(int id, Student studentToUpdate);
        Task<List<Student>> GetStudentByRouteId(int routeId);
        Task removeStudent(int id);
    
    }
}