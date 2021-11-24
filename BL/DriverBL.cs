using DL;
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
        DriverDL DriverDL;
        IUserDL IUserDL;
        public DriverBL(DriverDL DriverDL, IUserDL IUserDL)
        {
            this.DriverDL = DriverDL;
            this.IUserDL = IUserDL;
        }
        public async Task<List<Driver>> GatAllDrivers()
        {
            return await DriverDL.GetAllDrivers();
        }
        public async Task<Driver> GatDriverById(int id)
        {
            return await DriverDL.GetDriverById(id);
        }
        public async Task<int> AddNewDriver(Driver newDriver, string passsword)
        {
            int newDriverId = await IUserDL.AddNewDriverUser(newDriver, passsword);
            newDriver.UserId = newDriverId;
            return await DriverDL.AddNewDriver(newDriver);
           
        }
    }
}
