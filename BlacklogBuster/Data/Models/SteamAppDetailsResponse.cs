using System.Text.Json.Serialization;

namespace BlacklogBuster.Data.Models
{
    public class SteamAppDetailsResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public SteamAppDetails? Data { get; set; }
    }
}
