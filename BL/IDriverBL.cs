using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IDriverBL
    {
        Task<List<Driver>> GatAllDrivers();
        public Task<Driver> GatDriverById(int id);
        public Task<Driver> AddNewDriver(Driver newDriver, string passsword);
        public Task changeDriverdetails(int id,Driver driverToUpdate, string password, string newPassword);

    }
}