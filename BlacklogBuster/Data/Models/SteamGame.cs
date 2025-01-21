using System.Text.Json.Serialization;

namespace BlacklogBuster.Data.Models
{
    public class SteamGame
    {
        [JsonPropertyName("appid")]
        public int AppId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("playtime_forever")]
        public int PlaytimeForever { get; set; }

        [JsonPropertyName("img_icon_url")]
        public string ImgIconUrl { get; set; }

        [JsonPropertyName("playtime_windows_forever")]
        public int PlaytimeWindows { get; set; }

        [JsonPropertyName("playtime_mac_forever")]
        public int PlaytimeMac { get; set; }

        [JsonPropertyName("playtime_linux_forever")]
        public int PlaytimeLinux { get; set; }

        [JsonPropertyName("playtime_deck_forever")]
        public int PlaytimeDeck { get; set; }

        [JsonPropertyName("rtime_last_played")]
        public DateTime LastPlayed { get; set; }
    }
}