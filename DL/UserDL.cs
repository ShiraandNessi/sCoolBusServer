using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{//
    public class UserDL : IUserDL
    {
        SchoolBusContext schoolBusContext;
        public UserDL(SchoolBusContext schoolBusContext)
        {
            this.schoolBusContext = schoolBusContext;
        }
        public async Task<User> GetUser(string email, string password)
        {
            var res = await schoolBusContext.Users.SingleOrDefaultAsync( u => u.Email== email && u.Password== password);

            return res;
        }
        public async Task<User> AddNewFamilyUser(Family newFamily, string password)
        {
            User newUser = new User() { Email = newFamily.Email, Password = password, UserTypeId = (int)UserTypeEnum.Driver };
            await schoolBusContext.Users.AddAsync(newUser);
             await schoolBusContext.SaveChangesAsync();
            return newUser;
        }
        
        public async Task<User> AddNewDriverUser(Driver newDriver,string password)
        {

            User newUser = new User() { Email = newDriver.Email, Password = password, UserTypeId = (int)UserTypeEnum.Driver };
            await schoolBusContext.Users.AddAsync(newUser);
            await schoolBusContext.SaveChangesAsync();
            return newUser;

        }
    
        public async Task changeUserdetails(int? userId, string password, string newPassword,string email )
        {
            User user = await schoolBusContext.Users.FindAsync(userId);
            if(user!=null && user.Password == password)
            {
                user.Password = newPassword;
                if(email!= user.Email)
                {
                    user.Email = email;
                }
                await schoolBusContext.SaveChangesAsync();
            }
        }

    }
}
