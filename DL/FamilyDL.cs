using AutoMapper;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
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
        IMapper IMapper;
        public FamilyDL(SchoolBusContext SchoolBusContext,IUserDL IUserDL,IMapper IMapper)
        {
            this.SchoolBusContext = SchoolBusContext;
            this.IUserDL = IUserDL;
            this.IMapper = IMapper;
        }
        public async Task<Family> GetFamilyById(int id)
        {
            Family family= await SchoolBusContext.Families.FindAsync(id);
           List<Family>  families=await SchoolBusContext.Families.Include(a => a.User).Where(fam => fam.User.Id == family.UserId).Include(a => a.Station).Where(fam => fam.Station.Id == family.StationId).ToListAsync();
            return families[0];
        }
        public async Task<FamilyDTO> AddNewFamily(FamilyDTO newFamily)
        {
            Family family = new Family { FamilyName = newFamily.FamilyName, MotherName = newFamily.MotherName, FatherName = newFamily.FatherName, MotherPhone = newFamily.MotherPhone, FatherPhone = newFamily.FatherPhone, Email = newFamily.Email, Address = newFamily.Address, EnableFatherWhatsApp = newFamily.EnableFatherWhatsApp, EnableMotherWhatsApp = newFamily.EnableMotherWhatsApp, StationId = newFamily.StationId, UserId = newFamily.UserId };
            await SchoolBusContext.Families.AddAsync(family);
            await SchoolBusContext.SaveChangesAsync();
            newFamily.Id = family.Id;
            return newFamily;
        }
        public async Task changeFamilyDetails(int id, FamilyDTO familyToUpdate)
        {
              Family family1 = new Family { Id = id, FamilyName = familyToUpdate.FamilyName, MotherName = familyToUpdate.MotherName, FatherName = familyToUpdate.FatherName, MotherPhone = familyToUpdate.MotherPhone, FatherPhone = familyToUpdate.FatherPhone, Email = familyToUpdate.Email, Address = familyToUpdate.Address, EnableFatherWhatsApp = familyToUpdate.EnableFatherWhatsApp, EnableMotherWhatsApp = familyToUpdate.EnableMotherWhatsApp, StationId = familyToUpdate.StationId, UserId = familyToUpdate.UserId };
           // Family family1=IMapper.Map<FamilyDTO, Family>(familyToUpdate);
              Family family = await SchoolBusContext.Families.FindAsync(id);
            SchoolBusContext.Entry(family).CurrentValues.SetValues(family1);
            await SchoolBusContext.SaveChangesAsync();
        }

        
        
    }
}
