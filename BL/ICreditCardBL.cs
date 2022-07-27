using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICreditCardBL
    {
        Task<List<CreditCard>> Get(int userId);
        Task<CreditCard> Post(CreditCard room);
        public  Task Delete(int id);
    }
}