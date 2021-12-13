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
        public StationBL(IStationDL _IStationDL)
        {
            IStationDL = _IStationDL;
        }

        public async Task<Station> getStationById(int id)
        {
            return await IStationDL.getStationById(id);
        }
        public async Task<List<Station>> getAllStation()
        {
            return await IStationDL.getAllStation();
        }
        //public async Task<List<Student>> GetStationsByDriverId(int driverId)
        //{
        //    return await IStationDL.GetStationsByDriverId(driverId);
        //}
        public async Task<Station> addNewStation(Station newStation)
        {
            return await IStationDL.addNewStation(newStation);
        }
    }
}
