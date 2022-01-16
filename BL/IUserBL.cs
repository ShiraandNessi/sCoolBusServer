using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        public Task<User> GetUser(string email, string password);

    }
}