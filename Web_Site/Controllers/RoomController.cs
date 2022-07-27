using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Site.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        IRoomBL roomBL;
        public RoomController(IRoomBL room)
        {
            roomBL = room;
        }

        // GET api/<UserController>/5
        [HttpGet("{start}/{end}")]
        public async Task<ActionResult<Room>> Get(DateTime start, DateTime end)
        {
            if (start > end)
            {
                return Ok();
            }
            List<Room> newRoom = await roomBL.Get(start, end);
           
                return Ok(newRoom);
          
        }

        [HttpGet("{num}")]
        public int Get(int num)
        {
            return 100;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<Room>> Post([FromBody] Room room)
        {
            Room newRoom = await roomBL.Post(room);
            return Ok(newRoom);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Room roomToUpdate)
        {
           await roomBL.Put(id, roomToUpdate);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{roomId}")]
        public async Task<ActionResult> Delete(int roomId)
        {
            await roomBL.Delete(roomId);
            return Ok();
        }
    }
}
