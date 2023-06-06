using MongoDB.Driver;
using MyTournaments.Data.Context;
using MyTournaments.Data.Entitites;

namespace MyTournaments.Data.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly ITournamentContext _context;
    
    public PlayerRepository(ITournamentContext context)
    {
        _context = context;
    }
    
    public async Task<List<Player>> GetAll()
    {
        return await _context.Players.Find(p => true).ToListAsync();
    }

    public async Task<Player> Get(string id)
    {
        return await _context.Players.Find(player => player.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Player> Create(Player player)
    {
        return await _context.Players.InsertOneAsync(player).ContinueWith(task => player);
    }

    public async Task Update(Player player)
    {
        await _context.Players.FindOneAndReplaceAsync(p => p.Id == player.Id, player);
    }

    public async Task Delete(string id)
    {
        await _context.Players.DeleteOneAsync(p => p.Id == id);
    }

    public Task<List<Player>> GetByTeamId(string teamId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Player>> GetByTournamentId(string tournamentId)
    {
        throw new NotImplementedException();
    }

    public Task<Player> GetByPlayerNumber(int playerNumber)
    {
        throw new NotImplementedException();
    }

    public Task<List<Player>> GetByName(string name)
    {
        throw new NotImplementedException();
    }
}