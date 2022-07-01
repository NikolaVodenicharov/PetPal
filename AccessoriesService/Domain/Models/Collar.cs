using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AccessoriesService.Domain.Models
{
    public class Collar
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
    }
}
