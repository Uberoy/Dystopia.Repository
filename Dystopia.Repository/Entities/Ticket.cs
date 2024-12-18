using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Dystopia.Repository.Entities;

public class Ticket
{
    [BsonRepresentation(BsonType.ObjectId), BsonId]
    public string? Id { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime DateCreated { get; set; }
}