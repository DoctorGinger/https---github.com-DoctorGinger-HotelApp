using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IOrderBL
    {
        Task<Order> Get(int userId);
        Task<Order> Post(Order orders);
        Task Put(int id, Order roomToUpdate);
        public Task Delete();
    }
}