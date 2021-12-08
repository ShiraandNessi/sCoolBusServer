using Entities;
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
        public async Task<StationOfRoute> AddStationOfRoute(int newStationId, int newRoutId)
        {
            StationOfRoute stationOfRoute = new StationOfRoute() { StationId = newStationId, RouteId = newRoutId };
            await SchoolBusContext.StationOfRoutes.AddAsync(stationOfRoute);
            await SchoolBusContext.SaveChangesAsync();
            return stationOfRoute;
        }
    }
}
