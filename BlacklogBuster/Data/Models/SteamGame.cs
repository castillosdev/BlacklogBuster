using System.Text.Json.Serialization;

namespace BlacklogBuster.Data.Models
{
    public class SteamGame
    {
        [JsonPropertyName("appid")]
        public int AppId { get; set; }

        [JsonPropertyName("playtime_forever")]
        public int PlaytimeForever { get; set; }
    }
}
