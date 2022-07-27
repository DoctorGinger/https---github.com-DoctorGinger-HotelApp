using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CreditCardDL : ICreditCardDL
    {
        HotelContext myHotel;
        public CreditCardDL(HotelContext _myHotel)
        {
            myHotel = _myHotel;
        }
        public async Task<List<CreditCard>> Get(int userId)
        {
            var cards = myHotel.CreditCards
                .Where(card => card.UserId == userId)
                .Select(card => card)
                .ToList();
            if (cards.ToArray().Length > 0)
            {
                return cards;
            }
            return null;
        }
        public async Task<CreditCard> Post(CreditCard creditCard)
        {
            await myHotel.CreditCards.AddAsync(creditCard);
            await myHotel.SaveChangesAsync();
            return creditCard;
        }
       
        public async Task Delete(int id)
        {

            CreditCard cardToDelete = await myHotel.CreditCards.FindAsync(id);
            if (cardToDelete != null)
            {
                myHotel.CreditCards.Remove(cardToDelete);

            }
            await myHotel.SaveChangesAsync();
        }

    }
}
