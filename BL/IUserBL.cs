using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        Task<User> Get(string password, string identity);
        Task<User> Post(User user);
        Task Put(int id, User userToUpdate);
        public  Task Delete(int id);
    }
}