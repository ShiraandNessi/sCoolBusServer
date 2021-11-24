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
        public async Task<int> AddNewDriver(Driver newDriver, string passsword)
        {
            int newDriverId = await IUserDL.AddNewDriverUser(newDriver, passsword);
            newDriver.UserId = newDriverId;
            return await IDriverDL.AddNewDriver(newDriver);
           
        }
    }
}
