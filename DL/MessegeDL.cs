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

        public async Task<List<Messege>> GetAllMesseges()
        {
            return await SchoolBusContext.Messege.ToListAsync();

        }

        public async Task<int> AddNewMessege(Messege newMessege)
        {
            await SchoolBusContext.Messege.AddAsync(newMessege);
           return await SchoolBusContext.SaveChangesAsync();
        }
    }
}
