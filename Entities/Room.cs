using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Room
    {
        public Room()
        {
            OrderPerRooms = new HashSet<OrderPerRoom>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public short? Floor { get; set; }
        public string IsView { get; set; }
        public short Status { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public short? BedsNum { get; set; }

        public virtual RoomStatus StatusNavigation { get; set; }
        public virtual ICollection<OrderPerRoom> OrderPerRooms { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
