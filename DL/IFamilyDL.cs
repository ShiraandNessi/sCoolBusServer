using DTO;
using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IFamilyDL
    {
        Task<Family> GetFamilyById(int id);
        Task<FamilyDTO> AddNewFamily(FamilyDTO newFamily);
        Task changeFamilyDetails(int id, FamilyDTO familyToUpdate);
        
    }
}