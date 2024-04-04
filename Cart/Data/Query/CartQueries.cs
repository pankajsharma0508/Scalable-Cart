using Cart.Data.Models;
using MediatR;
using MongoDB.Bson;

namespace Cart.Data.Query
{
    public class GetCartQuery: IRequest<UserCart>
    {
        public GetCartQuery(ObjectId id)
        {
            Id = id;    
        }
        public ObjectId Id { get; set; }
    }
}
