using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class UserDL : IUserDL
    {
        HotelContext myHotel;
        public UserDL(HotelContext _myHotel)
        {
            myHotel = _myHotel;
        }
        public async Task<User> Get(string password, string identity)
        {
            var user = await myHotel.Users            
                .FirstOrDefaultAsync<User>(u => u.IdentityNum == identity);
            if (user != null && user.Password == password)
            {
               return user;
            }
            return null;
        }

        public async Task<User> Post(User user)
        {
            await myHotel.Users.AddAsync(user);
            await myHotel.SaveChangesAsync();
            return user;
        }
        public async Task Put(int id, User userToUpdate)
        {
            User user = await myHotel.Users.FindAsync(id);
            if (user != null)
            {
                myHotel.Entry(user).CurrentValues.SetValues(userToUpdate);
                await myHotel.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            User userToDelete = await myHotel.Users.FindAsync(id);
            if (userToDelete != null)
            {
                myHotel.Users.Remove(userToDelete);
            }
            await myHotel.SaveChangesAsync();
        }
    }
}
