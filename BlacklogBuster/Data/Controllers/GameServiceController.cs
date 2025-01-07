using BlacklogBuster.Data.Models;
using BlacklogBuster.Data;
using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly GameService _gameService;

        public GamesController(GameService gameService)
        {
            _gameService = gameService;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<IActionResult> GetGames([FromQuery] string userId)
        {
            var games = await _gameService.GetGamesAsync(userId);
            return Ok(games);
        }

        // POST: api/Games
        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] Game game)
        {
            await _gameService.AddGameAsync(game);
            return CreatedAtAction(nameof(GetGames), new { userId = game.UserId }, game);
        }

        // PUT: api/Games/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] Game game)
        {
            if (id != game.Id)
            {
                return BadRequest("Game ID mismatch.");
            }

            await _gameService.UpdateGameAsync(game);
            return NoContent();
        }

        // DELETE: api/Games/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await _gameService.DeleteGameAsync(id);
            return NoContent();
        }
    }
