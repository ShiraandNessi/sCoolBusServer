using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IRouteBL
    {
        Task<List<Route>> getAllRoutes();
        Task<List<Route>> getAllRoutesByDriverId(int driverId);
        Task<Route> addNewRoute(Route newRoute);
    }
}