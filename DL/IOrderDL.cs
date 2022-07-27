using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IOrderDL
    {
        Task<Order> Get(int userId);
        Task<Order> Post(Order orders);
        Task Put(int id, Order orderToUpdate);
        public Task Delete();
    }
}