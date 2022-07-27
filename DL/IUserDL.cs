using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        Task<User>  Get(string password, string identity);
        Task<User> Post(User user);
        Task Put(int id, User userToUpdate);
        public  Task Delete(int id);
    }
}