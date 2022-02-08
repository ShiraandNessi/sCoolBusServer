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
            if(_schoolBusContext.Users.Find(id).UserType.Id == (int)(UserTypeEnum.Manager))
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
