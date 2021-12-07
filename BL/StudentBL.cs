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

        public async Task<List<Student>> GetAllStudents()
        {
            return await IStudentDL.GetAllStudents();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await IStudentDL.GetStudentById(id);
        }
        public async Task<Student> AddNewStudent(Student newStudent)
        {
            return await IStudentDL.AddNewStudent(newStudent);
        }
        public async Task changeStudentDetailes(Student correntStudent)
        {
            await IStudentDL.changeStudentDetailes(correntStudent);
        }
    }
}
