using Cart.Data.Command;
using Cart.Data.Models;
using Cart.Data.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCartController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserCartController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        // GET: api/<UserCartController>
        [HttpGet]
        public  List<UserCart> Get() { 
            var result =  mediator.Send(new GetCartsQuery()).Result;
            foreach(var item in result) { 
            
                item.TotalItem = item.Items.Sum(x=>x.Quantity);
                item.TotalCost = item.Items.Sum(x => x.TotalCost);

            }

            return result;
        
        }


        // GET api/<UserCartController>/5
        [HttpGet("{id}")]
        public async Task<UserCart> Get(string id) => await mediator.Send(new GetCartQuery { Id = id });


        // POST api/<UserCartController>
        [HttpPost]
        public  UserCart Post([FromBody] UserCart cart) { 
            
            cart.CartId = Guid.NewGuid().ToString();
            var result = mediator.Send(new CreateUserCartCommand { Cart = cart }).Result;           

            return result;
        }


        // PUT api/<UserCartController>/5
        [HttpPut("{id}")]
        public async Task<UserCart> Put(int id, [FromBody] UserCart cart) => await mediator.Send(new UpdateUserCartCommand { Cart = cart });

        // DELETE api/<UserCartController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id) => await mediator.Send(new DeleteUserCartCommand { Id = id });
        
    }
}
