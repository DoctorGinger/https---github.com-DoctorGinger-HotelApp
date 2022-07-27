using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        IOrderBL orderBL;
        IMapper mapper;
        public OrderController(IOrderBL order, IMapper mapper)
        {
            orderBL = order;
            this.mapper = mapper;
        }

        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<OrderDTO>> Get(int userId)
        {
            Order orders = await orderBL.Get(userId);
            if (orders != null)
            {
                return Ok(mapper.Map<Order,OrderDTO>(orders));
            }
            else
            {
                return Ok();
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orders)
        {
            Order newOrders = await orderBL.Post(mapper.Map<OrderDTO, Order>(orders));
            return Ok(newOrders);
        }
        //public async Task<ActionResult<Order>> Post([FromBody]Order orders)
        //{
        //    Order newOrders = await orderBL.Post(orders);
        //    return Ok(newOrders);
        //}

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Order orderToUpdate)
        {
           await orderBL.Put(id, orderToUpdate);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete()]
        public async Task<ActionResult> Delete()
        {
            await orderBL.Delete();
            return Ok();
        }
    }
}
