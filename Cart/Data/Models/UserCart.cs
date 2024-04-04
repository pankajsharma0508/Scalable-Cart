using MongoDB.Bson;

namespace Cart.Data.Models
{
    public class UserCart
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }
}
