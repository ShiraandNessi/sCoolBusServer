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
        public DriverBL(DriverDL DriverDL)
        {
            this.DriverDL = DriverDL;
        }
        public async Task<List<Driver>> GatAllDrivers()
        {
            return await DriverDL.GetAllDrivers();
        }
    }
}
