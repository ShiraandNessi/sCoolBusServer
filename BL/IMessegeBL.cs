using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IMessegeBL
    {
        Task<List<Messege>> GetAllMessegesByDriverId(int driverId);
        Task<Messege> AddNewMessege(Messege newMessege);
        
    }
}