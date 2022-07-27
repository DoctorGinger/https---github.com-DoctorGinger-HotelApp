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
    public class CreditCardController : ControllerBase
    {
        ICreditCardBL creditCardBL;
        IMapper mapper;
        public CreditCardController(ICreditCardBL creditCard, IMapper mapper)
        {
            creditCardBL = creditCard;
            this.mapper = mapper;
        }

        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<CreditCardDTO>> Get(int userId)
        {
            //throw new Exception("oooooohhhhhhhhhhhhhh"); 
            List<CreditCard> CreditCards = await creditCardBL.Get(userId);
            if (CreditCards != null)
            {
                return Ok(mapper.Map<List<CreditCard>, List<CreditCardDTO>>(CreditCards));
            }
            else
            {
                return Ok();
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<CreditCardDTO>> Post([FromBody] CreditCardDTO creditCard)
        {
            CreditCard newCreditCard = await creditCardBL.Post(mapper.Map< CreditCardDTO, CreditCard>(creditCard));
            if (newCreditCard != null)
            {
                return Ok(newCreditCard);
            }
            return Ok();
        }

      

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await creditCardBL.Delete(id);
            return Ok();
        }
    }
}
