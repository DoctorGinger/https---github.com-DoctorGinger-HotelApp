using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class RoomStatus
    {
        public RoomStatus()
        {
            Rooms = new HashSet<Room>();
        }

        public short Id { get; set; }
        public string RoomStatus1 { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
