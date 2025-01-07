using System.Text.Json.Serialization;

namespace BlacklogBuster.Data.Models
{
    public class SteamResponse
    {
        [JsonPropertyName("response")]
        public SteamGamesResponse? Response { get; set; }
    }
}
