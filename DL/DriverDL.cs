using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{//שירה אם זה ההערה אצלך זה אומר שזה מעודכן
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
             await  SchoolBusContext.SaveChangesAsync();
            return newDriver;
        }
        public async Task changeDriverdetails(int id, Driver driverToUpdate)
        {
            
            Driver driver = await SchoolBusContext.Drivers.FindAsync(id);
            SchoolBusContext.Entry(driver).CurrentValues.SetValues(driverToUpdate);
            await SchoolBusContext.SaveChangesAsync();
        }
        public async Task removeDriver(int id)
        {
            Driver driver = await SchoolBusContext.Drivers.FindAsync(id);
            if(driver!=null)
            {
                SchoolBusContext.Drivers.Remove(driver);
                await SchoolBusContext.SaveChangesAsync();
            }

        }
    }
}
