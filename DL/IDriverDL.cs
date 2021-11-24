using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IDriverDL
    {
        Task<List<Driver>> GetAllDrivers();
    }
}