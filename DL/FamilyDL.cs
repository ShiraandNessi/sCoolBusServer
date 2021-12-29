using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class FamilyDL: IFamilyDL
    {
        SchoolBusContext SchoolBusContext;
        IUserDL IUserDL;
        public FamilyDL(SchoolBusContext SchoolBusContext,IUserDL IUserDL)
        {
            this.SchoolBusContext = SchoolBusContext;
            this.IUserDL = IUserDL;
        }
        public async Task<Family> GetFamilyById(int id)
        {
            return await SchoolBusContext.Families.FindAsync(id);
        }
        public async Task<Family> AddNewFamily(FamilyDTO newFamily)
        {
            Family family = new Family { Id = newFamily.Id, FamilyName = newFamily.FamilyName, MotherName = newFamily.MotherName, FatherName = newFamily.FatherName, MotherPhone = newFamily.MotherPhone, FatherPhone = newFamily.FatherPhone, Email = newFamily.Email, Address = newFamily.Address, EnableFatherWhatsApp = newFamily.EnableFatherWhatsApp, EnableMotherWhatsApp = newFamily.EnableMotherWhatsApp, StationId = newFamily.StationId, UserId = newFamily.UserId };
            await SchoolBusContext.Families.AddAsync(family);
            await SchoolBusContext.SaveChangesAsync();
            return family;
        }
        public async Task changeFamilyDetails(int id, FamilyDTO familyToUpdate)
        {
            Family family1 = new Family { Id = familyToUpdate.Id, FamilyName = familyToUpdate.FamilyName, MotherName = familyToUpdate.MotherName, FatherName = familyToUpdate.FatherName, MotherPhone = familyToUpdate.MotherPhone, FatherPhone = familyToUpdate.FatherPhone, Email = familyToUpdate.Email, Address = familyToUpdate.Address, EnableFatherWhatsApp = familyToUpdate.EnableFatherWhatsApp, EnableMotherWhatsApp = familyToUpdate.EnableMotherWhatsApp, StationId = familyToUpdate.StationId, UserId = familyToUpdate.UserId };
            Family family = await SchoolBusContext.Families.FindAsync(id);
            SchoolBusContext.Entry(family).CurrentValues.SetValues(family1);
            await SchoolBusContext.SaveChangesAsync();
        }

        public async Task removeFamily(int id)
        {
            Family family = await SchoolBusContext.Families.FindAsync(id);

            if (family != null)
            {
                IUserDL.removeUser(family.UserId);
                SchoolBusContext.Families.Remove(family);
                await SchoolBusContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }
        
    }
}
