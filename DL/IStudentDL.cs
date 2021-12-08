using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IStudentDL
    {
        Task<int> AddNewStudent(Student student);
        Task changeStudentDetails(int id, Student studentToUpdate);
        Task<List<Student>> GetAllStudents();
        Task<List<Student>> GetStudentByFamilyId(int familyId);
        Task<Student> GetStudentById(int id);
        Task removeStudent(int id);
    }
}