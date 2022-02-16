using DTO;
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
        AuthorizationFuncs _passwordHashHelper;
          SchoolBusContext schoolBusContext;
        public UserDL(SchoolBusContext schoolBusContext, AuthorizationFuncs _passwordHashHelper)
        {
            this.schoolBusContext = schoolBusContext;
            this._passwordHashHelper = _passwordHashHelper;
        }
        public async Task<User> GetUser(string email)
        {
            var res = await schoolBusContext.Users.SingleOrDefaultAsync( u => u.Email== email);

            return res;
        }
        public async Task<User> AddNewFamilyUser(FamilyDTO newFamily)
        {
            User newUser = new User() { Email = newFamily.Email ,Password= newFamily.Password, UserTypeId = (int)UserTypeEnum.Family+1 };
            newUser.Salt = _passwordHashHelper.GenerateSalt(8);
            newUser.Password = _passwordHashHelper.HashPassword(newUser.Password, newUser.Salt, 1000, 8);
            await schoolBusContext.Users.AddAsync(newUser);
             await schoolBusContext.SaveChangesAsync();
            return newUser;
        }
        
        public async Task<User> AddNewDriverUser(DriverDTO newDriver)
        {

            User newUser = new User() { Email = newDriver.Email, UserTypeId = (int)UserTypeEnum.Driver+1 };
            newUser.Salt = _passwordHashHelper.GenerateSalt(8);
            newUser.Password = _passwordHashHelper.HashPassword(newUser.Password, newUser.Salt, 1000, 8);
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

        public async Task removeUser(int? userId)
        {
            User user = await schoolBusContext.Users.FindAsync(userId);

            if (user != null)
            {
                
                schoolBusContext.Users.Remove(user);
                await schoolBusContext.SaveChangesAsync();
            }
        }
    }
}
