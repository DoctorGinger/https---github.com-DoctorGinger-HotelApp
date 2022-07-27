using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            Users = new HashSet<User>();
        }

        public short Id { get; set; }
        public string UserStatus1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
