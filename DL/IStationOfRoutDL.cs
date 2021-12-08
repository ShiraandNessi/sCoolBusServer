using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IStationOfRoutDL
    {
       Task<StationOfRoute> AddStationOfRoute(int newStationId, int newRoutId);
    }
}