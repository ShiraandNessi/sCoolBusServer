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
             List<Driver> l=await SchoolBusContext.Drivers.ToListAsync();
            return l;
        }
        public async Task<Driver> GetDriverById(int id)
        {
            return await SchoolBusContext.Drivers.FindAsync(id);
        }
        public async Task<Driver> AddNewDriver(Driver newDriver)
        {
            await SchoolBusContext.Drivers.AddAsync(newDriver);
           return  await  SchoolBusContext.SaveChangesAsync();
        }
    }
}
