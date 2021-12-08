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
        public async Task<StationOfRoute> AddStationOfRoute(int newStationId, int newRoutId)
        {
            return await IStationOfRoutDL.AddStationOfRoute(newStationId, newRoutId);
        }
    }
}
