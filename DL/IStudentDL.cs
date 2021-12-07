using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IStudentDL
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<int> AddNewStudent(Student student);
        Task<List<Student>> GetStudentByFamilyId(int familyId);
        public Task changeStudentDetails(int id, Student studentToUpdate);
    }
}