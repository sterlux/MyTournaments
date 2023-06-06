using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyTournaments.Data.Entitites;
using MyTournaments.Data.Repository;

namespace MyTournaments.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerRepository _repository;
    private readonly ILogger<PlayersController> _logger;

    public PlayersController(IPlayerRepository repository, ILogger<PlayersController> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Player>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
    {
        var players = await _repository.GetAll();
        return Ok(players);
    }

    [HttpGet("{id:length(24)}", Name = "GetPlayer")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Player), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Player>> GetPlayerById(string id)
    {
        var player = await _repository.Get(id);
        if (player == null)
        {
            _logger.LogError($"Player with id: {id}, not found.");
            return NotFound();
        }

        return Ok(player);
    }

    
    [HttpPost]
    [ProducesResponseType(typeof(Player), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Player>> CreateProduct([FromBody] Player player)
    {
        await _repository.Create(player);
        return CreatedAtRoute("GetPlayer", new { id = player.Id }, player);
    }

    [HttpPut]
    [ProducesResponseType(typeof(Player), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateProduct([FromBody] Player player)
    {
        await _repository.Update(player);
        return Ok($"Player {player.Id} updated successfully.");
    }

    [HttpDelete("{id:length(24)}", Name = "DeletePlayer")]
    [ProducesResponseType(typeof(Player), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeletePlayerById(string id)
    {
        await _repository.Delete(id);
        return Ok("Player deleted successfully.");
    }
}