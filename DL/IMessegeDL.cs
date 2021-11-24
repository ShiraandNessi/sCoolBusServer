using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IMessegeDL
    {
        Task<List<Messege>> GetAllMesseges();
         Task AddNewMessege(Messege newMessege);
    }
}