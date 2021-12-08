using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IFamilyDL
    {
        Task<Family> GetFamilyById(int id);
        Task<Family> AddNewFamily(Family newFamily);
        Task changeFamilyDetails(int id, Family familyToUpdate);
    }
}