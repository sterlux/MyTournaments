namespace MyTournaments.Data;

public class TournamentDBSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string PlayersCollectionName { get; set; }
    public string TeamsCollectionName { get; set; }
}