using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDL : IRatingDL
    {
        HotelContext myHotel;
        public RatingDL(HotelContext _myHotel)
        {
            myHotel = _myHotel;
        }
        public async Task<Rating> Post(Rating rating)
        {
            await myHotel.AddAsync(rating);
            return rating;
        }
    }
}
