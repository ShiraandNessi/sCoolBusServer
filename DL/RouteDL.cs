using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RouteDL: IRouteDL
    {
        SchoolBusContext SchoolBusContext;
        public RouteDL(SchoolBusContext SchoolBusContext)
        {
            this.SchoolBusContext = SchoolBusContext;
        }

        public async Task<Route> addNewRoute(Route newRoute)
        {
            await SchoolBusContext.Routes.AddAsync(newRoute);
            await SchoolBusContext.SaveChangesAsync();
            return newRoute;
        }

        public async Task<List<Route>> getAllRoutes()
        {
            return await SchoolBusContext.Routes.ToListAsync();
        }
        public async Task<List<Route>> getAllRoutesByDriverId(int driverId)
        {
            return await SchoolBusContext.Routes.Where(route => route.DriverId == driverId).ToListAsync();
        }
    }
}
