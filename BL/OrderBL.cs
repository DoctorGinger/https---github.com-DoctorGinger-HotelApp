using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public  class OrderBL : IOrderBL
    {
        IOrderDL orderDl;
        public OrderBL(IOrderDL Iorder)
        {
            orderDl = Iorder;
        }
        public async Task<Order> Get(int userId)
        {
            return await orderDl.Get(userId);
        }
        public async Task<Order> Post(Order orders)
        {
            return await orderDl.Post(orders);
        }
        public async Task Put(int id, Order roomToUpdate)
        {
            await orderDl.Put(id, roomToUpdate);

        }
        public async Task Delete()
        {
           await orderDl.Delete();
        }
    }
}
