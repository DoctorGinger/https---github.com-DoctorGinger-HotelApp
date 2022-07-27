using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;

namespace BL
{
    public class RoomBL : IRoomBL
    {
        IRoomDL roomDl;
        public RoomBL(IRoomDL Iroom)
        {
            roomDl = Iroom;
        }
        public async Task<List<Room>> Get(DateTime start, DateTime end)
        {
             return await roomDl.Get(start, end);
        }

        public async Task<Room> Post(Room room)
        {
            return await roomDl.Post(room);
        }
        public async Task Put(int id, Room roomToUpdate)
        {
            await roomDl.Put(id, roomToUpdate);
        }
        public async Task Delete(int roomId)
        {
            await roomDl.Delete(roomId);
        }


    }
}
