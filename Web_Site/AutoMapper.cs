using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
namespace Web_Site
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreditCard, CreditCardDTO>();
            CreateMap<CreditCardDTO,CreditCard>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO,Order>();
            CreateMap<User,UserDTO>();
        }

    }
}
