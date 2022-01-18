using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class StationOfRoutDL : IStationOfRoutDL
    {
        SchoolBusContext SchoolBusContext;
        public StationOfRoutDL(SchoolBusContext _SchoolBusContext)
        {
            SchoolBusContext = _SchoolBusContext;
        }
        public async Task addNewStationToRoute(int routeId,int  newStationId)
        {
            StationOfRoute stationOfRoute = new StationOfRoute() { StationId = newStationId, RouteId = routeId };
            await SchoolBusContext.StationOfRoutes.AddAsync(stationOfRoute);
            await SchoolBusContext.SaveChangesAsync();
           
        }

        public async Task changeDetailsStationOfRoute(int id, int newStationId, int newRoutId, TimeSpan? newAssumTime)
        {
            StationOfRoute stationOfRoute = await SchoolBusContext.StationOfRoutes.FindAsync(id);
            if(stationOfRoute!=null)
            {
                SchoolBusContext.Entry(stationOfRoute).CurrentValues.SetValues(new StationOfRoute() { Id = id, StationId = newStationId, RouteId = newRoutId, AssumArrivalTime = newAssumTime });
                await SchoolBusContext.SaveChangesAsync();
            }
        }
        public async Task<List<StationOfRoute>> GetStationsByRouteId(int RouteId)
        {
            return await SchoolBusContext.StationOfRoutes.Include(a=>a.Station).Where(sor=>sor.RouteId== RouteId).ToListAsync();
        }
        public async Task<List<StationOfRoute>> GetStationsByDriverId(int driverId)
        {
            return await SchoolBusContext.StationOfRoutes.Include(a => a.Route).Where(sor => sor.Route.DriverId == driverId).Include(a=>a.Station).ToListAsync();
        }
    }
}
