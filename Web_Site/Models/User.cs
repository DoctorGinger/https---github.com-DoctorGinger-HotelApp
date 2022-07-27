using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Site.Models
{
    public partial class User
    {
        public User()
        {
            CreditCards = new HashSet<CreditCard>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public short? Status { get; set; }
        public string IdentityNum { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public virtual UserStatus StatusNavigation { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
