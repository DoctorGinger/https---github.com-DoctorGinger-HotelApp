using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OrderDL : IOrderDL
    {

        HotelContext myHotel;
        public OrderDL(HotelContext _myHotel)
        {
            myHotel = _myHotel;
        }
        public async Task<Order> Get(int userId)
        {
            var orders = await myHotel.Orders
              .FirstOrDefaultAsync(order => order.UserId == userId);
            orders.OrderPerRooms = myHotel.OrderPerRooms.Where<OrderPerRoom>(orderPerRoom => orderPerRoom.OrderId == orders.Id).
                Select(orderPerRoom=> orderPerRoom).ToList();
             return orders;
        }

        public async Task<Order> Post(Order orders)
        {
           await myHotel.Orders.AddAsync(orders);
           await myHotel.SaveChangesAsync();
            
            return orders;
        }

        public async Task Put(int id, Order orderToUpdate)
        {

        }
        public async Task Delete()
        {
            int id = 1013;

            // Order toDelete = myHotel.Orders.Find(id);
            //  Order toDelete = myHotel.Orders.Include(order => order.OrderPerRooms).FirstOrDefault(order => order.Id == id);
            //     myHotel.Remove(toDelete);
            //  await myHotel.SaveChangesAsync();


            //entity.HasOne(d => d.User)
            //        .WithOne(p => p.BusinessOwner)
            //        .HasForeignKey<BusinessOwner>(d => d.UserId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK__business___user___7E37BEF6");

            //foreach (var order in myHotel.Orders)
            //{
            //    if (order.DateEnd < DateTime.Now)
            //    {
            //        //OrderPerRoom OPRToDelete = myHotel.OrderPerRooms
            //        //    .FirstOrDefault(o => Convert.ToInt32(o.OrderId) == order.Id);
            //        //myHotel.OrderPerRooms.Remove(OPRToDelete);
            //        //await myHotel.SaveChangesAsync();
            //        myHotel.Orders.Remove(order);
            //        //await myHotel.SaveChangesAsync();
            //    }
            //}
            //        foreach (var artistType in this._db.ArtistTypes
            //.Where(at => vm.SelectedIds.Contains(at.ArtistTypeID)))
            //        {
            //            artistDetail.ArtistTypes.Remove(artistType);
            //        }

            //        this._db.Entry(artistDetail).State = EntityState.Modified;
            //        this._db.SaveChanges();
            //        myHotel.Orders.Remove();
            //        await myHotel.SaveChangesAsync(); 
        }
    }
}
