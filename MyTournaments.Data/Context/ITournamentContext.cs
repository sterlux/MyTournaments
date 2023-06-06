using MongoDB.Driver;
using MyTournaments.Data.Entitites;

namespace MyTournaments.Data.Context;

public interface ITournamentContext
{
    IMongoCollection<Player> Players { get; }
    IMongoCollection<Team> Teams { get; }
}