using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IStudentDL
    {
        Task<Student> AddNewStudent(Student student);
        Task changeStudentDetails(int id, Student studentToUpdate);
        Task<List<Student>> GetAllStudents();
        Task<List<Student>> GetStudentByFamilyId(int familyId);
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetStudentByRouteId(int routeId);
        Task removeStudent(int id);
       Task<int> GetCountOfStudentsBystationId(int stationId, int routeId);


    }
}