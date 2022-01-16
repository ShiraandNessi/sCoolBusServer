using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DL;
namespace BL
{
    public class MessegeBL : IMessegeBL
    {
        IMessegeDL IMessegeDL;
        public MessegeBL(IMessegeDL IMessegeDL)
        {
            this.IMessegeDL = IMessegeDL;

        }

        public async Task<List<Messege>> GetAllMessegesByDriverId(int driverId)
        {
            return await IMessegeDL.GetAllMessegesByDriverId(driverId);
        }

        public async Task<Messege> AddNewMessege(Messege newMessege)
        {
            return await IMessegeDL.AddNewMessege(newMessege);
        }
    }
}
