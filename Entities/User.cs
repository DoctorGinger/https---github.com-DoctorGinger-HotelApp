using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using DL.Models;

#nullable disable

namespace Entities
{
    public partial class User
    {
        public User()
        {
            CreditCards = new HashSet<CreditCard>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        [Range(4,6)]
        public short? Status { get; set; }
        [StringLength(9)]
        public string IdentityNum { get; set; }
        public string Name { get; set; }
        public string Password { get; set; } 
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        [JsonIgnore]
        public virtual UserStatus StatusNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}

