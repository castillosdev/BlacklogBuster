namespace BlacklogBuster.Data
{
    using BlacklogBuster.Data.Models;
    using System.Text.Json;
    using System.Text.Json.Serialization;

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

            var url = $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&steamid={steamId}&format=json";

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

                var tasks = result.Response.Games.Select(async game =>
                {
                    var details = await GetGameDetailsAsync(game.AppId);
                    if (details != null)
                    {
                        return new Game
                        {
                            Title = details.Name,
                            Platform = new Platform { Name = "Steam" },
                            Metadata = $"Added on {DateTime.Now}",
                        };
                    }
                    return null;
                });

                var games = await Task.WhenAll(tasks);
                return games.Where(g => g != null).ToList()!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        private async Task<SteamAppDetails?> GetGameDetailsAsync(int appId)
        {
            var url = $"https://store.steampowered.com/api/appdetails?appids={appId}";

            try
            {
                var response = await httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to fetch details for AppID {appId}. Status: {response.StatusCode}");
                    return null;
                }

                var appDetails = JsonSerializer.Deserialize<Dictionary<string, SteamAppDetailsResponse>>(content);
                if (appDetails != null && appDetails.ContainsKey(appId.ToString()) && appDetails[appId.ToString()].Success)
                {
                    return appDetails[appId.ToString()].Data;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching game details for AppID {appId}: {ex.Message}");
                return null;
            }
        }
    }
}
