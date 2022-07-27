using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CreditCardBL : ICreditCardBL
    {
        ICreditCardDL creditCardDl;
        public CreditCardBL(ICreditCardDL Iorder)
        {
            creditCardDl = Iorder;
        }
        public async Task<List<CreditCard>> Get(int userId)
        {
            return await creditCardDl.Get(userId);
        }
        public async Task<CreditCard> Post(CreditCard room)
        {
            return await creditCardDl.Post(room);
        }
      
        public async Task Delete(int id)
        {
            await creditCardDl.Delete(id);
        }
    }
}
