using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        public Task<User> GetUser(string email, string password);

    }
}