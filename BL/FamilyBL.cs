using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class FamilyBL: IFamilyBL
    {
        IFamilyDL IFamilyDL;
        IUserDL IUserDL;
        public FamilyBL(IFamilyDL IFamilyDL, IUserDL IUserDL)
        {
            this.IFamilyDL = IFamilyDL;
            this.IUserDL = IUserDL;
        }
        public async Task<Family> GetFamilyById(int id)
        {
            return await IFamilyDL.GetFamilyById(id);
        }
        public async Task<Family> AddNewFamily(Family newFamily, string passsword)
        {
            User newUser = await IUserDL.AddNewFamilyUser(newFamily, passsword);
            newFamily.UserId = newUser.Id;
            return await IFamilyDL.AddNewFamily(newFamily);
        }
        public async Task changeFamilyDetails(int id,Family familyToUpdate, string password, string newPassword)
        {
            await IUserDL.changeUserdetails(familyToUpdate.UserId, password, newPassword, familyToUpdate.Email);
            await IFamilyDL.changeFamilyDetails(id, familyToUpdate);
        }

        public async Task removeFamily(int id)
        {
         
            IFamilyDL.removeFamily(id);
        }
    }
}
