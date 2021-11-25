using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IMessegeBL
    {
        Task<List<Messege>> GetAllMessegesByDriverId(int id);
        Task<int> AddNewMessege(Messege newMessege);
        
    }
}