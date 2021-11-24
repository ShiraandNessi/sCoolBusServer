using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DriverDL : IDriverDL
    {
        SchoolBusContext SchoolBusContext;
        public DriverDL(SchoolBusContext SchoolBusContext)
        {
            this.SchoolBusContext = SchoolBusContext;
        }
        public async Task<List<Driver>> GetAllDrivers()
        {
            return await SchoolBusContext.Drivers.ToListAsync();

        }
    }
}
