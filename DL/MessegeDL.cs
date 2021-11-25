using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class MessegeDL : IMessegeDL
    {
        SchoolBusContext SchoolBusContext;
        public MessegeDL(SchoolBusContext SchoolBusContext)
        {
            this.SchoolBusContext = SchoolBusContext;
        }

        public async Task<List<Messege>> GetAllMessegesByDriverId(int id)
        {
            return await SchoolBusContext.Messeges.Where(messege=>messege.DriverId== id).ToListAsync();

        }

        public async Task<int> AddNewMessege(Messege newMessege)
        {
            await SchoolBusContext.Messeges.AddAsync(newMessege);
           return await SchoolBusContext.SaveChangesAsync();
        }
    }
}
