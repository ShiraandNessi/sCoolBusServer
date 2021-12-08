using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IStationBL
    {
        Task<Station> getStationById(int id);
        Task<List<Station>> getAllStation();
        //Task<List<Student>> GetStationsByDriverId(int driverId);
        Task<Station> addNewStation(Station newStation);
    }
}