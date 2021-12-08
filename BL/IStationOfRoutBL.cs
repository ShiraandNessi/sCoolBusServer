using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IStationOfRoutBL
    {
        Task<StationOfRoute> AddStationOfRoute(int newStationId, int newRoutId);
    }
}