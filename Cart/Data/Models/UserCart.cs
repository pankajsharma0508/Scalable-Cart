using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cart.Data.Models
{
    public class UserCart
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        public string Id => this._id.ToString();
        public string Name { get; set; }
        public Decimal TotalCost { get; set; }
        public int TotalItem { get; set; }
        public DateTime CreatedOn => DateTime.UtcNow;

        public List<UserCartItem> Items { get; set; }   

        public UserCart() { 
        
        Items = new List<UserCartItem>();
        }
    }

    public class UserCartItem
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        
        public string ProductName { get; set; }
        public Decimal TotalCost { get; set; }
        public int Quantity { get; set; }
        
    }
}
