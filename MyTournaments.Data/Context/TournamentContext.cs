using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyTournaments.Data.Entitites;

namespace MyTournaments.Data.Context;

public class TournamentContext: ITournamentContext
{
    public IMongoCollection<Player> Players { get; }
    public IMongoCollection<Team> Teams { get; }
    
    public TournamentContext(IOptionsMonitor<TournamentDBSettings> settings)
    {
        var client = new MongoClient(settings.CurrentValue.ConnectionString);
        var database = client.GetDatabase(settings.CurrentValue.DatabaseName);
        Players = database.GetCollection<Player>(settings.CurrentValue.PlayersCollectionName);
        Teams = database.GetCollection<Team>(settings.CurrentValue.TeamsCollectionName);
        // TournamentContextSeed.SeedData(Players);
        // TournamentContextSeed.SeedData(Teams);
    }
}