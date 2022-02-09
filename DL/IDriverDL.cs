using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IDriverDL
    {
        public Task<List<Driver>> GetAllDrivers();
        public Task<Driver> GetDriverById(int id);
        public Task<DriverDTO> AddNewDriver(DriverDTO newDriver);
        public Task changeDriverdetails(int id,DriverDTO driverToUpdate);
        public  Task<Driver> GatUserById(int userId);



    }
}