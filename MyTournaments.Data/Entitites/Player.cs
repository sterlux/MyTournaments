using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyTournaments.Data.Entitites;

public class Player
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Level { get; set; }
    public int PlayerNumber { get; set; }
    public string NickName { get; set; }
    public string EmergencyContact { get; set; }
    public string BloodType { get; set; }
}