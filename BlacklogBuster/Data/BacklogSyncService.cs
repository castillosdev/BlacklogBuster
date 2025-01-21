using BlacklogBuster.Data.Models;

namespace BlacklogBuster.Data
{
    public class BacklogSyncService
    {
        private readonly SteamService _steamService;
        private readonly PlayStationService _PlayStationService;
        private readonly GameService _gameService;

        public BacklogSyncService(SteamService steamService, PlayStationService PlayStationService, GameService gameService)
        {
            _steamService = steamService;
            _PlayStationService = PlayStationService;
            _gameService = gameService;
        }
        public async Task SyncBacklogAsync(string? steamId, string? psnUsername, string? psnPassword, string userId)
        {
            Console.WriteLine("Starting backlog sync...");
            var existingGames = await _gameService.GetGamesAsync(userId);

            if (!string.IsNullOrWhiteSpace(steamId))
            {
                Console.WriteLine("Fetching Steam games...");
                var steamGames = await _steamService.GetSteamGamesAsync(steamId);
                await SyncGamesAsync(steamGames, "Steam", existingGames);
                Console.WriteLine("Steam sync completed.");
            }

            if (!string.IsNullOrWhiteSpace(psnUsername) && !string.IsNullOrWhiteSpace(psnPassword))
            {
                Console.WriteLine("Fetching PlayStation games...");
                var psGames = await _PlayStationService.GetGamesAsync(psnUsername, psnPassword, userId);
                await SyncGamesAsync(psGames, "PlayStation", existingGames);
                Console.WriteLine("PlayStation sync completed.");
            }

            Console.WriteLine("Backlog sync completed.");
        }

        private async Task SyncGamesAsync(IEnumerable<Game> games, string platform, List<Game> existingGames)
        {
            foreach (var game in games)
            {
                var exists = existingGames.Any(g => g.Name == game.Name && g.Platforms.Name == platform);
                if (!exists)
                {
                    await _gameService.AddGameAsync(game);
                }
            }
        }
    }
}
