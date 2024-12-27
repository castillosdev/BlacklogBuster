namespace BlacklogBuster.Data
{
    public class BacklogSyncService
    {
        private readonly SteamService _steamService;
        private readonly PlaystationService _playstationService;
        //private readonly NintendoService _nintendoService;
        //private readonly XboxService _xboxService;
        private readonly GameService _gameService;

        public BacklogSyncService(SteamService steamService, PlaystationService playstationService, GameService gameService)
        {
            _steamService = steamService;
            _playstationService = playstationService;
            _gameService = gameService;
        }
        public async Task SyncBacklogAsync(string? steamId, string? psnUsername, string? psnPassword, string userId)
        {
            Console.WriteLine("Starting backlog sync...");
            var existingGames = await _gameService.GetGamesAsync(userId);

            if (!string.IsNullOrWhiteSpace(steamId))
            {
                Console.WriteLine("Fetching Steam games...");
                var steamGames = await _steamService.GetSteamGamesAsync(steamId, userId);
                await SyncGamesAsync(steamGames, "Steam", existingGames);
                Console.WriteLine("Steam sync completed.");
            }

            if (!string.IsNullOrWhiteSpace(psnUsername) && !string.IsNullOrWhiteSpace(psnPassword))
            {
                Console.WriteLine("Fetching PlayStation games...");
                var psGames = await _playstationService.GetGamesAsync(psnUsername, psnPassword);
                await SyncGamesAsync(psGames, "PlayStation", existingGames);
                Console.WriteLine("PlayStation sync completed.");
            }

            Console.WriteLine("Backlog sync completed.");
        }

        private async Task SyncGamesAsync(IEnumerable<Game> games, string platform, List<Game> existingGames)
        {
            foreach (var game in games)
            {
                var exists = existingGames.Any(g => g.Title == game.Title && g.Platform == platform);
                if (!exists)
                {
                    await _gameService.AddGameAsync(game);
                }
            }
        }
    }
}
