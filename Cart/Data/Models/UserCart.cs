using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cart.Data.Models
{
    public class UserCart
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        

        public string Name { get; set; }
        public Decimal TotalCost { get; set; }
        public int TotalItem { get; set; }
        public DateTime CreatedOn { get; set; } 
    }
}
