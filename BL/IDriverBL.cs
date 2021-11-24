using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IDriverBL
    {
        Task<List<Driver>> GatAllDrivers();
        public Task<Driver> GatDriverById(int id);
        public Task<int> AddNewDriver(Driver newDriver, string passsword);

    }
}