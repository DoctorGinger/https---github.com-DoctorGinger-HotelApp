using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Site.Models
{
    public partial class OrderPerRoom
    {
        public int OrderPerRoomId { get; set; }
        public int OrderId { get; set; }
        public int RoomId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Room Room { get; set; }
    }
}
