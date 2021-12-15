using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IStationOfRoutDL
    {
        Task addNewStationToRoute(int routeId, int newStationId);
        //Task changeDetailsStationOfRoute(int id, int newStationId, int newRoutId, TimeSpan? newAssumTime);
        Task<List<StationOfRoute>> GetStationsByRouteId(int RouteId);
        Task<List<StationOfRoute>> GetStationsByDriverId(int driverId);
    }
}