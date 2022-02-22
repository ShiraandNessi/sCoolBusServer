using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IRouteBL
    {
        Task<List<Route>> getAllRoutes();
        Task<Route> getAllRoutesByDriverId(int driverId);
        Task<Route> addNewRoute(Route newRoute);
        Task addNewStationToRoute(int routeId,int newStationId);
    }
}