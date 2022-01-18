using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IDriverBL
    {
       public  Task<List<Driver>> GatAllDrivers();
        public Task<Driver> GatDriverById(int id);
        public Task<DriverDTO> AddNewDriver(DriverDTO newDriver);
        public Task changeDriverdetails(int id,DriverDTO driverToUpdate, string newPassword);
        

    }
}