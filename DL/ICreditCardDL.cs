using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICreditCardDL
    {
        Task<List<CreditCard>> Get(int userId);
        Task<CreditCard> Post(CreditCard creditCard);
        public Task Delete(int id);
    }
}