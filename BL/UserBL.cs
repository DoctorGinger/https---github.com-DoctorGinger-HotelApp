using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL userDl;
        IConfiguration _configuration;
        public UserBL(IUserDL Iuser, IConfiguration configuration)
        {
            userDl = Iuser;
            _configuration = configuration;
        }
        public async Task<User> Get(string password, string identity)
        {
            User user  = await userDl.Get(password, identity);
            if (user == null) return null;
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return WithoutPassword(user);
            return user;

        }
        public static User WithoutPassword(User user)
        {
            user.Password = null;
            return user;
        }

        public async Task<User> Post(User user)
        {
            return await userDl.Post(user);
        }
        public async Task Put(int id, User userToUpdate)

        {
            await userDl.Put(id, userToUpdate);
        }

        public async Task Delete(int id)
        {
            await userDl.Delete(id);
        }
    }
}
