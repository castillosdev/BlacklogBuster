namespace BlacklogBuster.Data
{
    using BlacklogBuster.Data.Models;
    using System.Text.Json;

    public class SteamService
    {
        private readonly HttpClient httpClient;
        private readonly string apiKey;

        public SteamService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.apiKey = configuration["SteamApiKey"] ?? throw new Exception("Steam API key is missing. Check your appsettings.json or configuration.");
        }

        public async Task<List<Game>> GetSteamGamesAsync(string steamId)
        {
            if (string.IsNullOrWhiteSpace(steamId))
            {
                throw new ArgumentNullException(nameof(steamId), "Steam ID is required.");
            }

            // Updated URL to include 'include_appinfo'
            var url = $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&steamid={steamId}&format=json&include_appinfo=true";

            try
            {
                var response = await httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Raw API Response: {content}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Steam API request failed. Status Code: {response.StatusCode}, Details: {content}");
                }

                var result = JsonSerializer.Deserialize<SteamResponse>(content);

                if (result?.Response?.Games == null || !result.Response.Games.Any())
                {
                    return new List<Game>();
                }

                // Map Steam games to your Game model
                var games = result.Response.Games.Select(game => new Game
                {
                    Name = game.Name ?? "Unknown Name", // Map Name from Steam API
                    Platforms = new Platform { Name = "Steam" }, // Associate with Steam platform
                    Metadata = $"Added on {DateTime.Now}", // Add metadata
                    SteamAppId = game.AppId, // Map AppId
                    PlaytimeForever = game.PlaytimeForever, // Map playtime
                    PlaytimeWindows = game.PlaytimeWindows,
                    PlaytimeLinux = game.PlaytimeLinux,
                    PlaytimeDeck = game.PlaytimeDeck,
                    LastPlayed = game.LastPlayed,
                }).ToList();

                return games;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
