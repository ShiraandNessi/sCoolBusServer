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
        IStationOfRoutDL IStationOfRoutDL;
        public RouteBL(IRouteDL IRouteDL , IStationOfRoutDL IStationOfRoutDL)
        {
            this.IRouteDL = IRouteDL;
            this.IStationOfRoutDL = IStationOfRoutDL;
        }

        public async Task<Route> addNewRoute(Route newRoute)
        {
            return await IRouteDL.addNewRoute(newRoute);
        }

        public async Task<List<Route>> getAllRoutes()
        {
            return await IRouteDL.getAllRoutes();
        }
        public async Task<Route> getAllRoutesByDriverId(int driverId)
        {
            return await IRouteDL.getAllRoutesByDriverId(driverId);
        }
        public async Task addNewStationToRoute(int routeId, int newStationId)
        {
            await IStationOfRoutDL.addNewStationToRoute(routeId, newStationId);
        }
        public async Task<Route> getRouteById(int id)
        {
            return await IRouteDL.getRouteById(id);
        }
    }
}
