using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class StationDL : IStationDL
    {
        SchoolBusContext SchoolBusContext;
        public StationDL(SchoolBusContext _SchoolBusContext)
        {
            SchoolBusContext = _SchoolBusContext;
        }
        public async Task<Station> getStationById(int id)
        {
            return await SchoolBusContext.Stations.FindAsync(id);
        }

        public async Task<List<Station>> getAllStation()
        {
            return await SchoolBusContext.Stations.ToListAsync();
        }
        //public async Task<List<Student>> GetStationsByDriverId(int driverId)
        //{
        //    SchoolBusContext.Stations.Join(SchoolBusContext.Drivers, s => s
        //    return await SchoolBusContext.Stations
        //}
        public async Task<Station> addNewStation(Station newStation)
        {
            await SchoolBusContext.Stations.AddAsync(newStation);
            await SchoolBusContext.SaveChangesAsync();
            return newStation;
        }
    }
}
