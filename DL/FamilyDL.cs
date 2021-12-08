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
        public async Task<Family> AddNewFamily(Family newFamily)
        {
            await SchoolBusContext.Families.AddAsync(newFamily);
            await SchoolBusContext.SaveChangesAsync();
            return newFamily;
        }
        public async Task changeFamilyDetails(int id, Family familyToUpdate)
        {

            Family family = await SchoolBusContext.Families.FindAsync(id);
            SchoolBusContext.Entry(family).CurrentValues.SetValues(familyToUpdate);
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
