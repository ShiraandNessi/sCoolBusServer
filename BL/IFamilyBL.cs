using DTO;
using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IFamilyBL
    {
        Task<Family> GetFamilyById(int id);
        public Task<Family> GetFamilyByUserId(int userId);
        Task<FamilyDTO> AddNewFamily(FamilyDTO newFamily);
        Task changeFamilyDetails(int id, FamilyDTO familyToUpdate, string newPassword);
        
    }
}