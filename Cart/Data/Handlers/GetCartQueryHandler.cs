using Cart.Data.Models;
using Cart.Data.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Cart.Data.Handlers
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, UserCart>
    {
        public Task<UserCart> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var connectionString = "mongodb+srv://pankMongo:Mongo123@pankcluster0.jwx8zze.mongodb.net/?retryWrites=true&w=majority";
            if (connectionString == null)
            {
                Console.WriteLine("You must set your 'DB_URL' environment variable. " );
                Environment.Exit(0);
            }
            var client = new MongoClient(connectionString);
            var db = MongoDbContext.Create(client.GetDatabase("Carts"));
            return db.UserCarts.FirstAsync();
        }
    }
}
