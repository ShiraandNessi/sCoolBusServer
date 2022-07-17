﻿using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
            return await IStudentDL.GetCountOfStudentsBystationId(stationId, routeId);
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await IStudentDL.GetAllStudents();
        }

        public async Task<Student> GetStudentById(int id)
        {
            Student s = await IStudentDL.GetStudentById(id);
            string path = Path.GetFullPath("Images/" + Convert.ToString(id)+ ".png");
            var array = File.ReadAllBytes(path);
            s.Passport = Convert.ToBase64String(array, 0, array.Length);
            return s;

        }
        public async Task<Student> AddNewStudent(Student student)
        {
            ////student.Passport = "M:\\sCoolBusClient\\sCoolBusClient\\src\\assets\\1.png";
            return await IStudentDL.AddNewStudent(student);
        }
        public async Task<List<Student>> GetStudentByFamilyId(int familyId)
        {
            List<Student> students = await IStudentDL.GetStudentByFamilyId(familyId);
            foreach (Student s in students)
            {
                string path = Path.GetFullPath("Images/" + Convert.ToString(s.Id)+ ".png");
                var array = File.ReadAllBytes(path);
                s.Passport = Convert.ToBase64String(array, 0, array.Length);
            }
            return students;

        }
        public async Task changeStudentDetails(int id, Student studentToUpdate)
        {
            await IStudentDL.changeStudentDetails(id, studentToUpdate);
        }
        public async Task<bool> saveImage(int id, string path)
        {
            return await IStudentDL.saveImage(id, path);

        }
        public async Task removeStudent(int id)
        {
            await IStudentDL.removeStudent(id);
        }
        public async Task<List<Student>> GetStudentByRouteId(int routeId)
        {
            List<Student> students = await IStudentDL.GetStudentByRouteId(routeId);
            foreach (Student s in students)
            {
                string path = Path.GetFullPath("Images/" + Convert.ToString(s.Id)+ ".png");
                var array = File.ReadAllBytes(path);
                s.Passport = Convert.ToBase64String(array, 0, array.Length);
            }
            return students;
        }
    }
}
