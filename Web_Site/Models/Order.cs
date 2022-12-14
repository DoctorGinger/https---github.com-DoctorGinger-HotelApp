using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Site.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderPerRooms = new HashSet<OrderPerRoom>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int CreditCardId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public short? TakenBeds { get; set; }
        public decimal? Price { get; set; }

        public virtual CreditCard CreditCard { get; set; }
        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderPerRoom> OrderPerRooms { get; set; }
    }
}
