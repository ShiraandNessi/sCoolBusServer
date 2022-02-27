using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;


namespace BL
{
   public class StudentStatuseBL:IStudentStatuseBL
    {
        IStudentStatuseDL _IStudentStatuseDL;
        SchoolBusContext _SchoolBusContext;
        public StudentStatuseBL(IStudentStatuseDL IStudentStatuseDL, SchoolBusContext SchoolBusContext)
        {
            _IStudentStatuseDL = IStudentStatuseDL;
            _SchoolBusContext = SchoolBusContext;
        }
        public async Task<bool> sentMessege(int studentId)
        {
            if (await _IStudentStatuseDL.isSentMessege(studentId))
                return true;
            else
            {
                List<Student> student = await _SchoolBusContext.Students.Where(s => s.Id == studentId).ToListAsync();

                List<Family> family = await _SchoolBusContext.Families.Where(f => f.Id == student[0].FamilyId).ToListAsync();
                MailAddress to = new MailAddress(family[0].Email);
                MailAddress from = new MailAddress("SchoolBusProject2022@gmail.com");
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Hi!!";
                message.Body = " schoolBus clousing!!";
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("SchoolBusProject2022@gmail.com", "SchoolBus2022");
                SmtpServer.EnableSsl = true;

                // code in brackets above needed if authentication required   

                try
                {
                    SmtpServer.Send(message);
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
                return await _IStudentStatuseDL.sentMessege(studentId);
            }
        }
    }
}
