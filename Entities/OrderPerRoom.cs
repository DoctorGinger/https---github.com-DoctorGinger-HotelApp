using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class OrderPerRoom
    {
        public int OrderPerRoomId { get; set; }
        public int OrderId { get; set; }
        public int RoomId { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual Room Room { get; set; }
    }
}
