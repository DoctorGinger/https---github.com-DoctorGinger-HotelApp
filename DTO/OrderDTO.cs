//using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int CreditCardId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public short? TakenBeds { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<OrderPerRoom> OrderPerRooms { get; set; }
    }
}
