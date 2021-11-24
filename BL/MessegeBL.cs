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
        IMessegeDL IMessegesDL;
        public MessegeBL(IMessegeDL IMessegesDL)
        {
            this.IMessegesDL = IMessegesDL;

        }

        public async Task<List<Messege>> GetAllMesseges()
        {
            return await IMessegesDL.GetAllMesseges();
        }

        public async Task AddNewMessege(Messege newMessege)
        {
             await IMessegeDL.AddNewMessege(newMessege);
        }
    }
}
