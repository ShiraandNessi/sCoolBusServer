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
        public FamilyDL(SchoolBusContext SchoolBusContext)
        {
            this.SchoolBusContext = SchoolBusContext;
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
    }
}
