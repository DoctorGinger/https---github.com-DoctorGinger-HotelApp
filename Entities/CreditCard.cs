using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        [Required, CreditCard]
        public string CardNumber { get; set; }
        [Required, StringLength(3)]
        public string Cvv { get; set; }
        [Required]
        public DateTime? ExpireDate { get; set; }
       // [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
