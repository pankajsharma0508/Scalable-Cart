using Cart.Data.Models;
using MediatR;
using MongoDB.Bson;

namespace Cart.Data.Query
{
    public class GetCartQuery: IRequest<UserCart>
    {
        public string Id { get; set; }
    }

    public class GetCartsQuery : IRequest<List<UserCart>>
    {
       
    }
}
