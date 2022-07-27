using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RoomDL : IRoomDL
    {
        HotelContext myHotel;
        public RoomDL(HotelContext _myHotel)
        {
            myHotel = _myHotel;
        }
        public async Task<List<Room>>Get(DateTime start, DateTime end)
        {
            List<Room> availableRooms = myHotel.Rooms.Where(room =>! room.OrderPerRooms
            .Any(OPR => ((OPR.Order.DateStart <= start && OPR.Order.DateEnd > start) || OPR.Order.DateStart >= start))).ToList();
            return availableRooms;
        }

        public async Task<Room> Post(Room room)
        {
            await myHotel.Rooms.AddAsync(room);
            await myHotel.SaveChangesAsync();
            return room;
        }

        public async Task Put(int id, Room roomToUpdate)
        {
            Room room = await myHotel.Rooms.FindAsync(id);
            if (room !=null) { 
            myHotel.Entry(room).CurrentValues.SetValues(roomToUpdate);
            await myHotel.SaveChangesAsync();
            }
        }

        public async Task Delete(int roomId)
        {
            Room roomToDelete = await myHotel.Rooms.FindAsync(roomId);
            if (roomToDelete != null)
            {
                myHotel.Rooms.Remove(roomToDelete);

            }
            await myHotel.SaveChangesAsync();
        }

    }
}
