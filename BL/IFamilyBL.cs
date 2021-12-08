using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IFamilyBL
    {
        Task<Family> GetFamilyById(int id);
        Task<Family> AddNewFamily(Family newFamily, string passsword);
        Task changeFamilyDetails(int id, Family familyToUpdate, string password, string newPassword);
    }
}