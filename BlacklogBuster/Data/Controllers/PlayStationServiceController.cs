using BlacklogBuster.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PlayStationController : ControllerBase
{
    private readonly PlayStationService _playStationService;

    public PlayStationController(PlayStationService playStationService)
    {
        _playStationService = playStationService;
    }

    // POST: api/PlayStation
    [HttpPost]
    public async Task<IActionResult> GetPlayStationGames([FromBody] PlayStationRequest request)
    {
        var games = await _playStationService.GetGamesAsync(request.PsnUsername, request.PsnPassword, request.UserId);
        return Ok(games);
    }
}

public class PlayStationRequest
{
    public string PsnUsername { get; set; }
    public string PsnPassword { get; set; }
    public string UserId { get; set; }
}
