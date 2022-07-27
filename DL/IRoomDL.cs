using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IRoomDL
    {
        Task<List<Room>> Get(DateTime start, DateTime end);
        Task<Room> Post(Room room);
        Task Put(int id, Room roomToUpdate);
        public Task Delete(int roomId);
    }
}