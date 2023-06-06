using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyTournaments.Data.Entitites;

public class Team
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public DateTime Created { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }
    public string CaptainId { get; set; }
    public List<string> PlayerIds { get; set; }
    public List<string> TournamentIds { get; set; }
}