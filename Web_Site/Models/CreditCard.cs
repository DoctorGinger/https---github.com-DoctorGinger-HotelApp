using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Site.Models
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public DateTime? ExpireDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
