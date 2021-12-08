using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RouteBL : IRouteBL
    {
        IRouteDL IRouteDL;
        public RouteBL(IRouteDL IRouteDL)
        {
            this.IRouteDL = IRouteDL;
        }

        public async Task<Route> addNewRoute(Route newRoute)
        {
            return await IRouteDL.addNewRoute(newRoute);
        }

        public async Task<List<Route>> getAllRoutes()
        {
            return await IRouteDL.getAllRoutes();
        }
        public async Task<List<Route>> getAllRoutesByDriverId(int driverId)
        {
            return await IRouteDL.getAllRoutesByDriverId(driverId);
        }
    }
}
