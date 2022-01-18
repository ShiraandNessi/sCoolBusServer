using DL;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DriverBL : IDriverBL
   
    {
        IDriverDL IDriverDL;
        IUserDL IUserDL;
        public DriverBL(IDriverDL IDriverDL, IUserDL IUserDL)
        {
            this.IDriverDL = IDriverDL;
            this.IUserDL = IUserDL;
        }
        public async Task<List<Driver>> GatAllDrivers()
        {
            return await IDriverDL.GetAllDrivers();
        }
        public async Task<Driver> GatDriverById(int id)
        {
            return await IDriverDL.GetDriverById(id);
        }
        public async Task<DriverDTO> AddNewDriver(DriverDTO newDriver)
        {
            User newUser = await IUserDL.AddNewDriverUser(newDriver);
            newDriver.UserId = newUser.Id;
            return await IDriverDL.AddNewDriver(newDriver);

           
        }
        public async Task changeDriverdetails(int id,DriverDTO driverToUpdate,string newPassword)
        {
            await IUserDL.changeUserdetails(driverToUpdate.UserId, driverToUpdate.Password,newPassword, driverToUpdate.Email);
            await IDriverDL.changeDriverdetails(id,driverToUpdate);

        }
        
    }
}
