using Cart.Data.Models;
using Cart.Data.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserCartController>/5
        [HttpGet("{id}")]
        public async Task<UserCart> Get(ObjectId id) => await mediator.Send(new GetCartQuery(id));


        // POST api/<UserCartController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserCartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserCartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
