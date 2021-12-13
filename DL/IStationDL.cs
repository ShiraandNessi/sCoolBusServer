using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IStationDL
    {
        Task<List<Station>> getAllStation();
        Task<Station> getStationById(int id);
        Task<List<Student>> GetStationsByDriverId(int driverId);
        Task<Station> addNewStation(Station newStation);
    }
}