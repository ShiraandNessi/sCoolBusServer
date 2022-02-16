using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBus
{
   public class AuthorizationFuncs: IAuthorizationFuncs
    {
        public  SchoolBusContext _schoolBusContext { get; set; }
        public  AuthorizationFuncs(SchoolBusContext SchoolBusContext)
        {
            _schoolBusContext = SchoolBusContext;
        }
        public  bool isAthorized(int id)
        {
            User d = _schoolBusContext.Users.Find(id);
            var x = (int)(UserTypeEnum.Driver) +1;
            if (d.UserTypeId == x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
