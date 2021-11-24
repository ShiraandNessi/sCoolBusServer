using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserDL : IUserDL
    {
        SchoolBusContext schoolBusContext;
        public UserDL(SchoolBusContext schoolBusContext)
        {
            this.schoolBusContext = schoolBusContext;
        }
        public async Task<User> GetUser(string email, string password)
        {
            var res = await schoolBusContext.Users.FindAsync(email, password);
            if (res == null)
                return null;
            //else
            //{
            //   ( List< DbSet<User>>)(res).Fin
            //}
            return res;
        }
    }
}
