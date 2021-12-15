using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IStationBL
    {
        Task<Station> getStationById(int id);
        Task<List<Station>> getAllStation();
        Task<List<StationOfRoute>> GetStationsByRouteId(int RouteId);
        Task<Station> addNewStation(Station newStation);
        Task<List<StationOfRoute>> GetStationsByDriverId(int driverId);
    }
}