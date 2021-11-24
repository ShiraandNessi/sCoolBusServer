using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        public Task<User> GetUser(string email, string password);
        public Task<int> AddNewDriverUser(Driver newDriver, string password);
        public Task<int> AddNewFamilyUser(Family newFamily, string password);
    }
}