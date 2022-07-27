using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BL;
using Entities;
using DTO;
using AutoMapper;
using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


////from me! For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Web_Site.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        IMapper mapper;
        HotelContext myHotel;
        public UserController(IUserBL user, IMapper _mapper, HotelContext _myHotel)
        {
            userBL = user;
            mapper = _mapper;
            myHotel = _myHotel;
        }

        // GET api/<UserController>/5
        
        [HttpGet("{password}/{identity}")]
        //[Authorize]
        public  async Task<ActionResult<UserDTO>> Get(string password, string identity)
        {
            //User newuser = await userBL.Get(password, identity);
            //newuser.StatusNavigation


            UserDTO newuser =   mapper.Map<User,UserDTO>(await userBL.Get(password, identity));
            if (newuser != null)
            {
                UserStatus matchStatus = await myHotel.UserStatuses.FirstOrDefaultAsync<UserStatus>(status => status.Id == newuser.Status);
                newuser.StatusDescription = matchStatus.UserStatus1;
                //Console.WriteLine(matchStatus.UserStatus1);
                return Ok(newuser);
            }
            else
            {
                return Ok();
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            User posteduser = await userBL.Post(user);
            return Ok(posteduser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userToUpdate)
        {
          await userBL.Put(id, userToUpdate);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
        }
    }
}
