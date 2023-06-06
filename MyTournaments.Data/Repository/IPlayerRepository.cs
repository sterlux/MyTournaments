using MyTournaments.Data.Entitites;

namespace MyTournaments.Data.Repository;

public interface IPlayerRepository
{
    Task<List<Player>> GetAll();
    Task<Player> Get(string id);
    Task<Player> Create(Player player);
    Task Update(Player player);
    Task Delete(string id);
    Task<List<Player>> GetByTeamId(string teamId);
    Task<List<Player>> GetByTournamentId(string tournamentId);
    Task<Player> GetByPlayerNumber(int playerNumber);
    Task<List<Player>> GetByName(string name);
}