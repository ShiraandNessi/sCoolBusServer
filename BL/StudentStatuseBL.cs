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
using Google.Maps;
using Google.Maps.DistanceMatrix;

namespace BL
{
    public class StudentStatuseBL : IStudentStatuseBL
    {
        IStudentStatuseDL _IStudentStatuseDL;
        IStudentDL _IStudentDL;
        SchoolBusContext _SchoolBusContext;
        IDriverDL _IDriverDL;
        IFamilyDL _IFamilyDL;
        IStationDL _IStationDL;
        public StudentStatuseBL(IStationDL IStationDL, IFamilyDL IFamilyDL, IStudentStatuseDL IStudentStatuseDL, SchoolBusContext SchoolBusContext, IStudentDL IStudentDL, IDriverDL IDriverDL)
        {
            _IFamilyDL = IFamilyDL;
            _IStudentStatuseDL = IStudentStatuseDL;
            _IStudentDL = IStudentDL;
            _IDriverDL = IDriverDL;
            _IStationDL = IStationDL;

            //_SchoolBusContext = SchoolBusContext;
        }
        public async Task<bool> sentMessege(int studentId, int driverId)
        {
            //checking if the student already got a mail
            if (await _IStudentStatuseDL.isSentMessege(studentId))
                return true;
            else
            {
                //find the current user
                Student student = await _IStudentDL.GetStudentById(studentId);
                if (await distance(student, driverId))
                {
                    //send a mail
                    MailAddress to = new MailAddress(student.Family.Email);
                    MailAddress from = new MailAddress("SchoolBusProject2022@gmail.com");
                    MailMessage message = new MailMessage(from, to);
                    message.Subject = "Hi!!";
                    message.Body = " schoolBus clousing!!" + student.FirstName + " must get down!!";
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
                else
                {
                    return false;
                }
            }
        }
        public async Task<bool> distance(Student student, int driverId)
        {
            GoogleSigned googleSigned = new GoogleSigned("AIzaSyCR5cpWuGnLOHc-Vjvo0Xe6p91hdGH7FDo");
            DistanceMatrixService distanceMatrixService = new DistanceMatrixService(googleSigned);
            DistanceMatrixRequest request = new DistanceMatrixRequest();
            Driver driver = await _IDriverDL.GetDriverById(driverId);
            Family family = await _IFamilyDL.GetFamilyById(student.FamilyId);
            Station station = await _IStationDL.getStationById(family.StationId);
            request.AddDestination(new LatLng(latitude: Convert.ToDecimal(driver.CurrPositionX), longitude: Convert.ToDecimal(driver.CurrPositionY)));
            request.AddOrigin(new LatLng(latitude: Convert.ToDecimal(station.PointX), longitude: Convert.ToDecimal(station.PointY)));
            request.Mode = TravelMode.driving;
            var x = await distanceMatrixService.GetResponseAsync(request);
            return true;
        }
    }
}

