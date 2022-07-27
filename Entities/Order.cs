using Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
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
        [JsonIgnore]
        public virtual CreditCard CreditCard { get; set; }
        [JsonIgnore]
        public virtual Room Room { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public virtual ICollection<OrderPerRoom> OrderPerRooms { get; set; }
    }
}
