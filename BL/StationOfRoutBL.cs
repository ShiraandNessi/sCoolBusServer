using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StationOfRoutBL : IStationOfRoutBL
    {
        IStationOfRoutDL IStationOfRoutDL;
        public StationOfRoutBL(IStationOfRoutDL _IStationOfRoutDL)
        {
            IStationOfRoutDL = _IStationOfRoutDL;
        }
        public async Task<StationOfRoute> AddStationOfRoute(int newStationId, int newRoutId , TimeSpan? newAssumTime)
        {
            return await IStationOfRoutDL.AddStationOfRoute(newStationId, newRoutId, newAssumTime);
        }

        public async Task changeDetailsStationOfRoute(int id, int newStationId, int newRoutId, TimeSpan? newAssumTime)
        {
             await IStationOfRoutDL.changeDetailsStationOfRoute(id,newStationId, newRoutId, newAssumTime);

        }
    }
}
