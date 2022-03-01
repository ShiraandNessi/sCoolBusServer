using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
namespace BL
{
    public class StationBL : IStationBL
    {
        IStationDL IStationDL;
        IStationOfRoutDL IStationOfRoutDL;
        public StationBL(IStationDL _IStationDL, IStationOfRoutDL _IStationOfRoutDL)
        {
            IStationDL = _IStationDL;
            IStationOfRoutDL = _IStationOfRoutDL;
        }
     
        public async Task<Station> getStationById(int id)
        {
            return await IStationDL.getStationById(id);
        }
        public async Task<List<Station>> getAllStation()
        {
            return await IStationDL.getAllStation();
        }
        public async Task<List<StationOfRoute>> GetStationsByRouteId(int RouteId)
        {
            return await IStationOfRoutDL.GetStationsByRouteId(RouteId);
        }
        public async Task<Station> addNewStation(Station newStation)
        {
            return await IStationDL.addNewStation(newStation);
        }
        public async Task<List<StationOfRoute>> GetStationsByDriverId(int driverId)
        {
            return await IStationOfRoutDL.GetStationsByDriverId(driverId);
        }

    }
}
