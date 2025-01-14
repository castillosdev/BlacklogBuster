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
                    Name = game.Name ?? "Unknown Name", // Map Name directly from API and handle nulls
                    Platform = new Platform { Name = "Steam" },
                    Metadata = $"Added on {DateTime.Now}",
                    SteamAppId = game.AppId, // Map AppId for Steam-specific ID
                    PlaytimeForever = game.PlaytimeForever, // Total playtime
                    PlaytimeWindows = game.PlaytimeWindowsForever,
                    PlaytimeDeck = game.PlaytimeDeckForever,
                    LastPlayed = game.LastPlayedDate,
                    GameIcon = !string.IsNullOrEmpty(game.ImgIconUrl)
                        ? $"https://media.steampowered.com/steamcommunity/public/images/apps/{game.AppId}/{game.ImgIconUrl}.jpg"
                        : null // Handle missing image URLs
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
