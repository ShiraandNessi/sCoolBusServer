using Entities;
using Microsoft.EntityFrameworkCore;
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
            var res = await schoolBusContext.Users.SingleOrDefaultAsync( u => u.Email== email &&u.Password== password);
            if (res == null)
                return null;
            return res;
        }
    }
}
