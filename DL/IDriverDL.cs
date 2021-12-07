using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IDriverDL
    {
        public Task<List<Driver>> GetAllDrivers();
        public Task<Driver> GetDriverById(int id);
        public Task<Driver> AddNewDriver(Driver newDriver);
        public Task changeDriverdetails(int id,Driver driverToUpdate);
        public  Task removeDriver(int id);
    }
}