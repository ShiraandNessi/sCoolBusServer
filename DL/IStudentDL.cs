﻿using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IStudentDL
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
    }
}