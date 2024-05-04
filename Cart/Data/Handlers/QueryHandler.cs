using Cart.Data.Models;
using Cart.Data.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cart.Data.Handlers
{
    public class GetCartQueryHandler : BaseRequestHandler, IRequestHandler<GetCartQuery, UserCart?>
    {
        public Task<UserCart?> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var dbContext = GetDBContext();
            return dbContext.UserCarts.FindAsync(new ObjectId(request.Id)).AsTask();
        }
    }

    public class GetCartsQueryHandler : BaseRequestHandler, IRequestHandler<GetCartsQuery, List<UserCart>>
    {
        public Task<List<UserCart>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            var dbContext = GetDBContext();
            return dbContext.UserCarts.ToListAsync();
        }
    }


    public class BaseRequestHandler
    {
        protected MongoDbContext GetDBContext()
        {
            var connectionString = "mongodb+srv://pankMongo:Mongo123@pankcluster0.jwx8zze.mongodb.net/?retryWrites=true&w=majority";
            if (connectionString == null)
            {
                Console.WriteLine("You must set your 'DB_URL' environment variable. ");
                Environment.Exit(0);
            }
            var client = new MongoClient(connectionString);
            return MongoDbContext.Create(client.GetDatabase("Carts_DB"));
        }
    }
}
