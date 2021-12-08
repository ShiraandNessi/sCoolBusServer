using Entities;
using System;
using System.Threading.Tasks;

namespace DL
{
    public interface IStationOfRoutDL
    {
       Task<StationOfRoute> AddStationOfRoute(int newStationId, int newRoutId , TimeSpan? newAssumTime);
        Task changeDetailsStationOfRoute(int id, int newStationId, int newRoutId, TimeSpan? newAssumTime);
    }
}