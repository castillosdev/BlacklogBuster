using BlacklogBuster.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SteamController : ControllerBase
{
    private readonly SteamService _steamService;

    public SteamController(SteamService steamService)
    {
        _steamService = steamService;
    }

    // GET: api/Steam
    [HttpGet]
    public async Task<IActionResult> GetSteamGames([FromQuery] string steamId, [FromQuery] string userId)
    {
        var games = await _steamService.GetSteamGamesAsync(steamId);
        return Ok(games);
    }
}
