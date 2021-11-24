using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL IUserDl;
        public UserBL(IUserDL IUserDl)
        {
            this.IUserDl = IUserDl;
        }
        public async Task<User> GetUser(string email, string password)
        {
            return await IUserDl.GetUser(email, password);
        }
    }
}
