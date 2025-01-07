using System.Text.Json.Serialization;

namespace BlacklogBuster.Data.Models
{
    public class SteamGamesResponse
    {
        [JsonPropertyName("game_count")]
        public int GameCount { get; set; }

        [JsonPropertyName("games")]
        public List<SteamGame>? Games { get; set; }
    }
}
