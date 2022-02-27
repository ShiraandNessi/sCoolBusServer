using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class StudentStatuseDL:IStudentStatuseDL
    {
        SchoolBusContext _SchoolBusContext;
        public StudentStatuseDL(SchoolBusContext SchoolBusContext)
        {
            _SchoolBusContext = SchoolBusContext;
        }
        public async  Task<bool> sentMessege(int studentId)
        {
            List<StudentStatus> student = await _SchoolBusContext.StudentStatuses.Where(s => s.Studentid == studentId).ToListAsync();
            if(student==null)
            {
                return false;
            }
            else{
                student[0].GetAlert = true;
               await _SchoolBusContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> isSentMessege(int studentId)
        {
            List<StudentStatus> student = await _SchoolBusContext.StudentStatuses.Where(s => s.Studentid == studentId).ToListAsync();
            if (student == null || student[0].GetAlert==false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
