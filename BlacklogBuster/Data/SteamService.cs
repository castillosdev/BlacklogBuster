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
            this.apiKey = configuration["7D347FC018EBCB9D8E1AA118D8789DB9"];
        }

        public async Task<List<Game>> GetSteamGamesAsync(string steamId, string userId)
        {
            if (string.IsNullOrWhiteSpace(steamId))
            {
                throw new ArgumentNullException("Steam ID is required", nameof(steamId));
            }

            var url = $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&steamid={steamId}&format=json";
            var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch Steam games");
            }
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SteamResponse>(content);
            return result?.Response?.Games?.Select(g => new Game
            {
                Title = g.Name,
                Platform = "Steam",
                Status = "Unplayed",
                PlayTimeHours = g.PlayTime,
                AddedDate = DateTime.Now,
                UserId = userId
            }).ToList() ?? new List<Game>();

        }
    }
}
