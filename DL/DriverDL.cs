using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
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
            Driver diver = await SchoolBusContext.Drivers.FindAsync(id);
            List<Driver> drivers = await SchoolBusContext.Drivers.Include(a => a.User).Where(dri => dri.User.Id == dri.UserId).ToListAsync();
            return drivers[0];
            
        }
        public async Task<DriverDTO> AddNewDriver(DriverDTO newDriver)
        {
            Driver driver = new Driver {Id=newDriver.Id,Email=newDriver.Email,Phone=newDriver.Phone,FirstName=newDriver.FirstName,LastName=newDriver.LastName,UserId=newDriver.Id};
            await SchoolBusContext.Drivers.AddAsync(driver);
             await  SchoolBusContext.SaveChangesAsync();
            newDriver.Id = driver.Id;
            return newDriver;
        }
        public async Task changeDriverdetails(int id, DriverDTO driverToUpdate)
        {
            Driver driver1 = new Driver {Id=id,Email= driverToUpdate.Email,Phone= driverToUpdate.Phone,FirstName= driverToUpdate.FirstName,LastName= driverToUpdate.LastName,UserId= driverToUpdate.Id};
            Driver driver = await SchoolBusContext.Drivers.FindAsync(id);
            SchoolBusContext.Entry(driver).CurrentValues.SetValues(driver1);
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
