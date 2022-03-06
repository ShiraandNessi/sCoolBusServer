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

        public async Task<List<Messege>> GetAllMessegesByDriverId(int driverId)
        {
            return await SchoolBusContext.Messeges.Where(messege=>messege.DriverId== driverId).ToListAsync();

        }

        public async Task<Messege> AddNewMessege(Messege newMessege)
        {
            newMessege.MessageTypeId = newMessege.MessageTypeId + 1;
            await SchoolBusContext.Messeges.AddAsync(newMessege);
                await SchoolBusContext.SaveChangesAsync();
            return newMessege;
        }
        public async Task isRead(int id)
        {
            Messege mess = await SchoolBusContext.Messeges.FindAsync(id);
            mess.IsRead = !mess.IsRead;
          await  SchoolBusContext.SaveChangesAsync();
            return;

        }
    }
}
