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
        IStudentDL _IStudentDL;
        SchoolBusContext _SchoolBusContext;
        public StudentStatuseBL(IStudentStatuseDL IStudentStatuseDL, SchoolBusContext SchoolBusContext , IStudentDL IStudentDL)
        {
            _IStudentStatuseDL = IStudentStatuseDL;
            _IStudentDL = IStudentDL;
            //_SchoolBusContext = SchoolBusContext;
        }
        public async Task<bool> sentMessege(int studentId)
        {
            //checking if the student already got a mail
            if (await _IStudentStatuseDL.isSentMessege(studentId))
                return true;
            else
            {
                //find the current user
                Student student = await _IStudentDL.GetStudentById(studentId);
                //send a mail
                MailAddress to = new MailAddress(student.Family.Email);
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
