using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        public Task<User> GetUser(string email, string password);
        public Task<User> AddNewDriverUser(Driver newDriver, string password);
        public Task<User> AddNewFamilyUser(Family newFamily, string password);
    }
}