using DL;
using DTO;
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
        public async Task<Family> GetFamilyByUserId(int userId)
        {
            return await IFamilyDL.GetFamilyByUserId(userId);
        }
        public async Task<FamilyDTO> AddNewFamily(FamilyDTO newFamily)
        {
            User newUser = await IUserDL.AddNewFamilyUser(newFamily);
            newFamily.UserId = newUser.Id;
            return await IFamilyDL.AddNewFamily(newFamily);
        }
        public async Task changeFamilyDetails(int id,FamilyDTO familyToUpdate,string newPassword)
        {
            //change the email and pass in userDL
            await IUserDL.changeUserdetails(familyToUpdate.UserId, familyToUpdate.Password, newPassword, familyToUpdate.Email);
            await IFamilyDL.changeFamilyDetails(id, familyToUpdate);
        }

       
    }
}
