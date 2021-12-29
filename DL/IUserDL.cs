using DTO;
using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        public Task<User> GetUser(string email, string password);
        public Task<User> AddNewDriverUser(Driver newDriver, string password);
        public Task<User> AddNewFamilyUser(FamilyDTO newFamily);
        public Task changeUserdetails(int? userId, string password, string newPassword,string email);
        public Task removeUser(int? userId);
    }
}